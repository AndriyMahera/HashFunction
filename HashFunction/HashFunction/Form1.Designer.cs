namespace HashFunction
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.checkHash = new System.Windows.Forms.Button();
            this.computedHashTextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.HasgFunctionPage = new System.Windows.Forms.TabPage();
            this.CipherPage = new System.Windows.Forms.TabPage();
            this.PerformancePage = new System.Windows.Forms.TabPage();
            this.Hash1Label = new System.Windows.Forms.Label();
            this.encryptedHashLabel = new System.Windows.Forms.Label();
            this.decryptedHashLabel = new System.Windows.Forms.Label();
            this.computedHashLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Encrypt = new System.Windows.Forms.Button();
            this.Decrypt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.HasgFunctionPage.SuspendLayout();
            this.CipherPage.SuspendLayout();
            this.PerformancePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Perform";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(199, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(234, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(439, 6);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(234, 96);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(199, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(199, 143);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 4;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // chart1
            // 
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.BackColor = System.Drawing.Color.Yellow;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(-4, 193);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "F";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(808, 180);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // CreateAccount_button
            // 
            this.CreateAccount_button.Location = new System.Drawing.Point(673, 165);
            this.CreateAccount_button.Name = "CreateAccount_button";
            this.CreateAccount_button.Size = new System.Drawing.Size(89, 50);
            this.CreateAccount_button.TabIndex = 6;
            this.CreateAccount_button.Text = "CreateAccount";
            this.CreateAccount_button.UseVisualStyleBackColor = true;
            this.CreateAccount_button.Click += new System.EventHandler(this.CreateAccount_button_Click);
            // 
            // signedTextBox
            // 
            this.signedTextBox.Location = new System.Drawing.Point(306, 136);
            this.signedTextBox.Name = "signedTextBox";
            this.signedTextBox.Size = new System.Drawing.Size(319, 23);
            this.signedTextBox.TabIndex = 7;
            this.signedTextBox.Text = "";
            // 
            // decryptedHashTextBox
            // 
            this.decryptedHashTextBox.Location = new System.Drawing.Point(306, 165);
            this.decryptedHashTextBox.Name = "decryptedHashTextBox";
            this.decryptedHashTextBox.Size = new System.Drawing.Size(319, 22);
            this.decryptedHashTextBox.TabIndex = 8;
            this.decryptedHashTextBox.Text = "";
            // 
            // signButton
            // 
            this.signButton.Location = new System.Drawing.Point(673, 105);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(89, 23);
            this.signButton.TabIndex = 9;
            this.signButton.Text = "Sign";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // hashTextBox
            // 
            this.hashTextBox.Location = new System.Drawing.Point(306, 107);
            this.hashTextBox.Name = "hashTextBox";
            this.hashTextBox.Size = new System.Drawing.Size(319, 23);
            this.hashTextBox.TabIndex = 10;
            this.hashTextBox.Text = "";
            // 
            // checkHash
            // 
            this.checkHash.Enabled = false;
            this.checkHash.Location = new System.Drawing.Point(673, 134);
            this.checkHash.Name = "checkHash";
            this.checkHash.Size = new System.Drawing.Size(89, 23);
            this.checkHash.TabIndex = 11;
            this.checkHash.Text = "Check";
            this.checkHash.UseVisualStyleBackColor = true;
            this.checkHash.Click += new System.EventHandler(this.checkHash_Click);
            // 
            // computedHashTextBox
            // 
            this.computedHashTextBox.Location = new System.Drawing.Point(306, 193);
            this.computedHashTextBox.Name = "computedHashTextBox";
            this.computedHashTextBox.Size = new System.Drawing.Size(319, 22);
            this.computedHashTextBox.TabIndex = 12;
            this.computedHashTextBox.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.HasgFunctionPage);
            this.tabControl1.Controls.Add(this.CipherPage);
            this.tabControl1.Controls.Add(this.PerformancePage);
            this.tabControl1.Location = new System.Drawing.Point(42, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(842, 430);
            this.tabControl1.TabIndex = 13;
            // 
            // HasgFunctionPage
            // 
            this.HasgFunctionPage.AutoScroll = true;
            this.HasgFunctionPage.Controls.Add(this.richTextBox1);
            this.HasgFunctionPage.Controls.Add(this.button1);
            this.HasgFunctionPage.Controls.Add(this.richTextBox2);
            this.HasgFunctionPage.Controls.Add(this.textBox1);
            this.HasgFunctionPage.Controls.Add(this.Ok);
            this.HasgFunctionPage.Controls.Add(this.chart1);
            this.HasgFunctionPage.Location = new System.Drawing.Point(4, 22);
            this.HasgFunctionPage.Name = "HasgFunctionPage";
            this.HasgFunctionPage.Padding = new System.Windows.Forms.Padding(3);
            this.HasgFunctionPage.Size = new System.Drawing.Size(834, 404);
            this.HasgFunctionPage.TabIndex = 0;
            this.HasgFunctionPage.Text = "HashFunction";
            this.HasgFunctionPage.UseVisualStyleBackColor = true;
            // 
            // CipherPage
            // 
            this.CipherPage.Controls.Add(this.Decrypt);
            this.CipherPage.Controls.Add(this.Encrypt);
            this.CipherPage.Location = new System.Drawing.Point(4, 22);
            this.CipherPage.Name = "CipherPage";
            this.CipherPage.Padding = new System.Windows.Forms.Padding(3);
            this.CipherPage.Size = new System.Drawing.Size(834, 404);
            this.CipherPage.TabIndex = 1;
            this.CipherPage.Text = "Cipher";
            this.CipherPage.UseVisualStyleBackColor = true;
            // 
            // PerformancePage
            // 
            this.PerformancePage.Controls.Add(this.label1);
            this.PerformancePage.Controls.Add(this.computedHashLabel);
            this.PerformancePage.Controls.Add(this.decryptedHashLabel);
            this.PerformancePage.Controls.Add(this.encryptedHashLabel);
            this.PerformancePage.Controls.Add(this.Hash1Label);
            this.PerformancePage.Controls.Add(this.hashTextBox);
            this.PerformancePage.Controls.Add(this.computedHashTextBox);
            this.PerformancePage.Controls.Add(this.CreateAccount_button);
            this.PerformancePage.Controls.Add(this.checkHash);
            this.PerformancePage.Controls.Add(this.signedTextBox);
            this.PerformancePage.Controls.Add(this.decryptedHashTextBox);
            this.PerformancePage.Controls.Add(this.signButton);
            this.PerformancePage.Location = new System.Drawing.Point(4, 22);
            this.PerformancePage.Name = "PerformancePage";
            this.PerformancePage.Size = new System.Drawing.Size(834, 404);
            this.PerformancePage.TabIndex = 2;
            this.PerformancePage.Text = "Performance";
            this.PerformancePage.UseVisualStyleBackColor = true;
            // 
            // Hash1Label
            // 
            this.Hash1Label.AutoSize = true;
            this.Hash1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Hash1Label.Location = new System.Drawing.Point(72, 107);
            this.Hash1Label.Name = "Hash1Label";
            this.Hash1Label.Size = new System.Drawing.Size(134, 24);
            this.Hash1Label.TabIndex = 13;
            this.Hash1Label.Text = "Original hash";
            // 
            // encryptedHashLabel
            // 
            this.encryptedHashLabel.AutoSize = true;
            this.encryptedHashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encryptedHashLabel.Location = new System.Drawing.Point(72, 136);
            this.encryptedHashLabel.Name = "encryptedHashLabel";
            this.encryptedHashLabel.Size = new System.Drawing.Size(156, 24);
            this.encryptedHashLabel.TabIndex = 14;
            this.encryptedHashLabel.Text = "Encrypted hash";
            // 
            // decryptedHashLabel
            // 
            this.decryptedHashLabel.AutoSize = true;
            this.decryptedHashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decryptedHashLabel.Location = new System.Drawing.Point(72, 165);
            this.decryptedHashLabel.Name = "decryptedHashLabel";
            this.decryptedHashLabel.Size = new System.Drawing.Size(156, 24);
            this.decryptedHashLabel.TabIndex = 15;
            this.decryptedHashLabel.Text = "Decrypted hash";
            // 
            // computedHashLabel
            // 
            this.computedHashLabel.AutoSize = true;
            this.computedHashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.computedHashLabel.Location = new System.Drawing.Point(72, 193);
            this.computedHashLabel.Name = "computedHashLabel";
            this.computedHashLabel.Size = new System.Drawing.Size(157, 24);
            this.computedHashLabel.TabIndex = 16;
            this.computedHashLabel.Text = "Computed hash";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(100, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(647, 31);
            this.label1.TabIndex = 17;
            this.label1.Text = "Electronic signature and creation of new account";
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(670, 59);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(75, 23);
            this.Encrypt.TabIndex = 0;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(670, 88);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(75, 23);
            this.Decrypt.TabIndex = 1;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(923, 501);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.HasgFunctionPage.ResumeLayout(false);
            this.HasgFunctionPage.PerformLayout();
            this.CipherPage.ResumeLayout(false);
            this.PerformancePage.ResumeLayout(false);
            this.PerformancePage.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button checkHash;
        private System.Windows.Forms.RichTextBox computedHashTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage HasgFunctionPage;
        private System.Windows.Forms.TabPage CipherPage;
        private System.Windows.Forms.TabPage PerformancePage;
        private System.Windows.Forms.Label computedHashLabel;
        private System.Windows.Forms.Label decryptedHashLabel;
        private System.Windows.Forms.Label encryptedHashLabel;
        private System.Windows.Forms.Label Hash1Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.Button Encrypt;
    }
}

