﻿namespace HashFunction
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Ok = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CreateAccount_button = new System.Windows.Forms.Button();
            this.signedTextBox = new System.Windows.Forms.RichTextBox();
            this.decryptedHashTextBox = new System.Windows.Forms.RichTextBox();
            this.signButton = new System.Windows.Forms.Button();
            this.hashTextBox = new System.Windows.Forms.RichTextBox();
            this.chechHash = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Perform";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(234, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(252, 12);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(234, 96);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(12, 149);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 4;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // chart1
            // 
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.BackColor = System.Drawing.Color.Yellow;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 190);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "F";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(880, 318);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // CreateAccount_button
            // 
            this.CreateAccount_button.Location = new System.Drawing.Point(492, 12);
            this.CreateAccount_button.Name = "CreateAccount_button";
            this.CreateAccount_button.Size = new System.Drawing.Size(89, 23);
            this.CreateAccount_button.TabIndex = 6;
            this.CreateAccount_button.Text = "CreateAccount";
            this.CreateAccount_button.UseVisualStyleBackColor = true;
            this.CreateAccount_button.Click += new System.EventHandler(this.CreateAccount_button_Click);
            // 
            // signedTextBox
            // 
            this.signedTextBox.Location = new System.Drawing.Point(587, 41);
            this.signedTextBox.Name = "signedTextBox";
            this.signedTextBox.Size = new System.Drawing.Size(234, 23);
            this.signedTextBox.TabIndex = 7;
            this.signedTextBox.Text = "";
            // 
            // decryptedHashTextBox
            // 
            this.decryptedHashTextBox.Location = new System.Drawing.Point(587, 70);
            this.decryptedHashTextBox.Name = "decryptedHashTextBox";
            this.decryptedHashTextBox.Size = new System.Drawing.Size(234, 22);
            this.decryptedHashTextBox.TabIndex = 8;
            this.decryptedHashTextBox.Text = "";
            // 
            // signButton
            // 
            this.signButton.Location = new System.Drawing.Point(827, 12);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(89, 23);
            this.signButton.TabIndex = 9;
            this.signButton.Text = "Sign";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // hashTextBox
            // 
            this.hashTextBox.Location = new System.Drawing.Point(587, 12);
            this.hashTextBox.Name = "hashTextBox";
            this.hashTextBox.Size = new System.Drawing.Size(234, 23);
            this.hashTextBox.TabIndex = 10;
            this.hashTextBox.Text = "";
            // 
            // chechHash
            // 
            this.chechHash.Location = new System.Drawing.Point(827, 41);
            this.chechHash.Name = "chechHash";
            this.chechHash.Size = new System.Drawing.Size(89, 23);
            this.chechHash.TabIndex = 11;
            this.chechHash.Text = "Check";
            this.chechHash.UseVisualStyleBackColor = true;
            this.chechHash.Click += new System.EventHandler(this.chechHash_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 520);
            this.Controls.Add(this.chechHash);
            this.Controls.Add(this.hashTextBox);
            this.Controls.Add(this.signButton);
            this.Controls.Add(this.decryptedHashTextBox);
            this.Controls.Add(this.signedTextBox);
            this.Controls.Add(this.CreateAccount_button);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button CreateAccount_button;
        private System.Windows.Forms.RichTextBox signedTextBox;
        private System.Windows.Forms.RichTextBox decryptedHashTextBox;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.RichTextBox hashTextBox;
        private System.Windows.Forms.Button chechHash;
    }
}

