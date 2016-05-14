using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashFunction
{
    public partial class Form1 : Form
    {
        public const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ .,;-'0123456789";
        public static double[,] KeyMatrix = { { 12, 0, 7, 4 }, { 17, 14, 21, 18 }, { 10, 24, 0, 13 }, { 3, 17, 8, 24 } };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            Preparation.FilterText(ref text);
            richTextBox1.Text = text;
            richTextBox2.Text = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(text),4,12)).ToString();
        }
    }
}
