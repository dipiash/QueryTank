using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace QueryTank
{
    public partial class Form1 : Form
    {
        public static int countSuccess = 0;
        public static int countProcessEnd = 0;
        public static DateTime timeStart;
        public static System.Diagnostics.Stopwatch timeCode = new System.Diagnostics.Stopwatch();
        public static bool stopFlag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartQueryes_Click(object sender, EventArgs e)
        {
            stopFlag = false;
            labelCountPerSecond.Text = "0";
            labelFullTime.Text = "0";
            labelSuccessQueryes.Text = "0";

            btnStartQueryes.Enabled = false;
            countSuccess = 0;
            countProcessEnd = 0;
            timeCode.Start();

            int countThreads = Int32.Parse(countThreadsTextBox.Text.ToString().Trim());

            List<BackgroundWorker> workers = new List<BackgroundWorker>();
            for (int i = 0; i < countThreads; i++)
            {
                BackgroundWorker bg = new BackgroundWorker();
                bg.DoWork += Bg_DoWork;
                bg.RunWorkerCompleted += Bg_RunWorkerCompleted;
                workers.Add(bg);
            }

            foreach (BackgroundWorker bg in workers)
            {
                bg.RunWorkerAsync();
            }
        }

        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            countProcessEnd++;

            Double countQuery_ = Double.Parse(countThreadsTextBox.Text);

            if (countProcessEnd == Int32.Parse(((Int32)countQuery_).ToString().Trim()))
            {
                countProcessEnd = 0;
                btnStartQueryes.Enabled = true;
                timeCode.Stop();
                labelCountPerSecond.Text = Math.Round(((Double)countSuccess / timeCode.ElapsedMilliseconds * 1000)).ToString();
                labelFullTime.Text = ((Double)timeCode.ElapsedMilliseconds / 1000).ToString() + " sec";
                labelSuccessQueryes.Text = countSuccess.ToString();
            }
        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            int countQueryes = Int32.Parse(countQueryesTextBox.Text);
            WebReq(urlQueryTextBox, queryTextBox, countQueryes);
        }

        public static void WebReq(TextBox urlQueyTextBox, TextBox queryTextBox, int countQueries)
        {
            try
            {
                for (int i = 0; i < countQueries; i++)
                {
                    if (stopFlag.Equals(false))
                    {
                        WebRequest newReq = WebRequest.Create("" + urlQueyTextBox.Text);
                        newReq.Method = "POST";
                        newReq.ContentType = "application/x-www-form-urlencoded";
                        String postData = "data=" + queryTextBox.Text;
                        UTF8Encoding encoding = new UTF8Encoding();
                        byte[] bytePostData = encoding.GetBytes(postData);
                        newReq.ContentLength = bytePostData.Length;

                        Stream newStream = newReq.GetRequestStream();
                        newStream.Write(bytePostData, 0, bytePostData.Length);

                        newStream.Close();

                        WebResponse response = newReq.GetResponse();
                        Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                        newStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(newStream);
                        string responseFromServer = reader.ReadToEnd();
                        reader.Close();
                        newStream.Close();
                        response.Close();

                        if (responseFromServer.Trim() == "OK")
                        {
                            countSuccess++;
                        }
                    }
                }
            }
            catch (Win32Exception ex)
            {

            }
        }

        private void btnStopQueryes_Click(object sender, EventArgs e)
        {
            stopFlag = true;
            btnStartQueryes.Enabled = true;
            timeCode.Stop();

            labelCountPerSecond.Text = Math.Round(((Double)countSuccess / timeCode.ElapsedMilliseconds * 1000)).ToString();
            labelFullTime.Text = ((Double)timeCode.ElapsedMilliseconds / 1000).ToString() + " sec";
            labelSuccessQueryes.Text = countSuccess.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
