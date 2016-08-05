namespace QueryTank
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStartQueryes = new System.Windows.Forms.Button();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStopQueryes = new System.Windows.Forms.Button();
            this.countThreadsTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.urlQueryTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelSuccessQueryes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCountPerSecond = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelFullTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.countQueryesTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartQueryes
            // 
            this.btnStartQueryes.Location = new System.Drawing.Point(12, 154);
            this.btnStartQueryes.Name = "btnStartQueryes";
            this.btnStartQueryes.Size = new System.Drawing.Size(125, 44);
            this.btnStartQueryes.TabIndex = 0;
            this.btnStartQueryes.Text = "Отправить";
            this.btnStartQueryes.UseVisualStyleBackColor = true;
            this.btnStartQueryes.Click += new System.EventHandler(this.btnStartQueryes_Click);
            // 
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(12, 81);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(258, 22);
            this.queryTextBox.TabIndex = 1;
            this.queryTextBox.Text = resources.GetString("queryTextBox.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL запроса";
            // 
            // btnStopQueryes
            // 
            this.btnStopQueryes.Location = new System.Drawing.Point(145, 154);
            this.btnStopQueryes.Name = "btnStopQueryes";
            this.btnStopQueryes.Size = new System.Drawing.Size(125, 44);
            this.btnStopQueryes.TabIndex = 3;
            this.btnStopQueryes.Text = "Остановить";
            this.btnStopQueryes.UseVisualStyleBackColor = true;
            this.btnStopQueryes.Click += new System.EventHandler(this.btnStopQueryes_Click);
            // 
            // countThreadsTextBox
            // 
            this.countThreadsTextBox.Location = new System.Drawing.Point(12, 126);
            this.countThreadsTextBox.Name = "countThreadsTextBox";
            this.countThreadsTextBox.Size = new System.Drawing.Size(140, 22);
            this.countThreadsTextBox.TabIndex = 10;
            this.countThreadsTextBox.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Количество потоков";
            // 
            // urlQueryTextBox
            // 
            this.urlQueryTextBox.Location = new System.Drawing.Point(12, 31);
            this.urlQueryTextBox.Name = "urlQueryTextBox";
            this.urlQueryTextBox.Size = new System.Drawing.Size(258, 22);
            this.urlQueryTextBox.TabIndex = 12;
            this.urlQueryTextBox.Text = "http://localhost:3000/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Тело запроса";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Успешно";
            // 
            // labelSuccessQueryes
            // 
            this.labelSuccessQueryes.AutoSize = true;
            this.labelSuccessQueryes.Location = new System.Drawing.Point(161, 201);
            this.labelSuccessQueryes.Name = "labelSuccessQueryes";
            this.labelSuccessQueryes.Size = new System.Drawing.Size(16, 17);
            this.labelSuccessQueryes.TabIndex = 15;
            this.labelSuccessQueryes.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Запросов в секунду";
            // 
            // labelCountPerSecond
            // 
            this.labelCountPerSecond.AutoSize = true;
            this.labelCountPerSecond.Location = new System.Drawing.Point(161, 222);
            this.labelCountPerSecond.Name = "labelCountPerSecond";
            this.labelCountPerSecond.Size = new System.Drawing.Size(16, 17);
            this.labelCountPerSecond.TabIndex = 17;
            this.labelCountPerSecond.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Общее время";
            // 
            // labelFullTime
            // 
            this.labelFullTime.AutoSize = true;
            this.labelFullTime.Location = new System.Drawing.Point(161, 243);
            this.labelFullTime.Name = "labelFullTime";
            this.labelFullTime.Size = new System.Drawing.Size(16, 17);
            this.labelFullTime.TabIndex = 19;
            this.labelFullTime.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Запросов";
            // 
            // countQueryesTextBox
            // 
            this.countQueryesTextBox.Location = new System.Drawing.Point(159, 126);
            this.countQueryesTextBox.Name = "countQueryesTextBox";
            this.countQueryesTextBox.Size = new System.Drawing.Size(111, 22);
            this.countQueryesTextBox.TabIndex = 21;
            this.countQueryesTextBox.Text = "100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 273);
            this.Controls.Add(this.countQueryesTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelFullTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelCountPerSecond);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSuccessQueryes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.urlQueryTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countThreadsTextBox);
            this.Controls.Add(this.btnStopQueryes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.btnStartQueryes);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 320);
            this.Name = "Form1";
            this.Text = "QueryTank";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartQueryes;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStopQueryes;
        private System.Windows.Forms.TextBox countThreadsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox urlQueryTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelSuccessQueryes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCountPerSecond;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelFullTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox countQueryesTextBox;
    }
}

