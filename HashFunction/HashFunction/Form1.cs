using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace HashFunction
{
    public partial class Form1 : Form
    {
        public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ .,;-'0123456789@[]{}\"#$%^&*()|<>+=_?!";
        string sfdd="@[]{}\"#$%^&*()|<>+=_?!\\";//23символи
        public static double[,] KeyMatrix = { { 12, 0, 7, 4 }, { 17, 14, 21, 18 }, { 10, 24, 0, 13 }, { 3, 17, 8, 24 } };
        public static double[,] SKeyMatrix = { { 1, 2, 1, 7, 1 }, { 2, 3, 4, 5, 6 }, { 1, 2, 8, 3, 4 }, { 5, 4, 3, 2, 1 }, { 6, 7, 5, 4, 2 } };
        public static double[,] TKeyMatrix = { { 1, 2, 1, 7, 1, 0 }, { 2, 3, 4, 5, 6, 1 }, { 1, 2, 8, 3, 4, 5 }, { 5, 4, 3, 2, 1, 3 }, { 6, 7, 5, 4, 2, 4 }, { 0, 1, 7, 1, 11, 1 } };
        public static double[,] FKeyMatrix = { { 13, 14, 0 }, { 18, 8, 17 }, { 12, 11, 21 } };
        string testOfRandomness = "";
        private int inputC=-1;
        public Form1()
        {
            InitializeComponent();
            testOfRandomness = File.ReadAllText("randomness.txt");
            Preparation.FilterText(ref testOfRandomness);
            string result = Preparation.FormStringFromDigit(Code.HashFunction_withoutPinch(Preparation.FormDigitString(testOfRandomness), 7, 0)).ToString();
            string result2 = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(testOfRandomness), 7, 0)).ToString();
            var dict = Preparation.UniquesDict(result,1);
            Preparation.MakeChart(chart1,dict);
            double deviation = Preparation.FindDeviation(dict, result.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            Preparation.FilterText(ref text);
            richTextBox1.Text = text;
            if (inputC != -1)
            {
                richTextBox2.Text = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(text), 7, inputC)).ToString();
            }
            else
            {
                MessageBox.Show("Can't be performed");
            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                int input;
                if (Int32.TryParse(textBox1.Text, out input))
                {
                    if (input >= 0 && input < Alphabet.Length)
                    {
                        inputC = input;
                    }
                    else { MessageBox.Show("In interval from 0 to 63"); }
                }
                else { MessageBox.Show("You inputed not number"); }
            }
            else { MessageBox.Show("Field is empty"); }
        }

        private void CreateAccount_button_Click(object sender, EventArgs e)
        {
            var craForm = new CreateAccountForm();
            craForm.Owner = this;
            craForm.ShowDialog();
        }

        private void Log_in_button_Click(object sender, EventArgs e)
        {

        }
    }
}
