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
        public static double[,] KeyMatrix = { { 12, 0, 7, 4 }, { 17, 14, 21, 18 }, { 10, 24, 0, 13 }, { 3, 17, 8, 24 } };
        public static double[,] SKeyMatrix = { { 1, 2, 1, 7, 1 }, { 2, 3, 4, 5, 6 }, { 1, 2, 8, 3, 4 }, { 5, 4, 3, 2, 1 }, { 6, 7, 5, 4, 2 } };
        public static double[,] TKeyMatrix = { { 1, 2, 1, 7, 1, 0 }, { 2, 3, 4, 5, 6, 1 }, { 1, 2, 8, 3, 4, 5 }, { 5, 4, 3, 2, 1, 3 }, { 6, 7, 5, 4, 2, 4 }, { 0, 1, 7, 1, 11, 1 } };
        public static double[,] FKeyMatrix = { { 13, 14, 0 }, { 18, 8, 17 }, { 12, 11, 21 } };

        private const string openKey = "L)?O7.}H3,]YS Z=P>${%+<|)MJ'EX[B|MD?]{H<Z";
        private static double[,] InverseMatrix, SInverseMatrix;
        private List<int> encrypted = new List<int>(), encryptedF = new List<int>(), encrypted2 = new List<int>(), encrypted2F = new List<int>();
        private List<int> decrypted = new List<int>(),decrypted2=new List<int>(), digit = new List<int>();
        private string testOfRandomness = "";
        private const int SYMBOLS_FOR_LEN = 1,SYMBOLS_FOR_LEN2=6;
        private int inputC=-1;


        public Form1()
        {
            InitializeComponent();
            testOfRandomness = File.ReadAllText("randomness.txt");
            Preparation.FilterText(ref testOfRandomness);
            string result = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(testOfRandomness), 7, 0,false)).ToString();

            string resultVigenere = Preparation.FormStringFromDigit(Code.Vigenere(Preparation.FormDigitString(testOfRandomness),"mahera",true)).ToString();
            string resultFeistel = Preparation.FormStringFromDigit(Code.FeistelEncrypt_Decrypt(Preparation.FormDigitString(testOfRandomness), true)).ToString();
            string resultHill = Preparation.FormStringFromDigit(Code.Hill_Encrypt_Decrypt(Preparation.FormDigitString(testOfRandomness), SKeyMatrix,Alphabet.Length)).ToString();
            string resultHash = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(testOfRandomness), 7,0,false)).ToString();

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
                richTextBox2.Text = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(text), 7, inputC,true)).ToString();
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

        private void signButton_Click(object sender, EventArgs e)
        {
            MyEvents me = e as MyEvents;
            int symbolLen;
            if (me == null)
            {
                symbolLen = SYMBOLS_FOR_LEN;
                testOfRandomness = File.ReadAllText("randomness.txt");
                Preparation.FilterText(ref testOfRandomness);
                string result = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(testOfRandomness), 7, 0,true)).ToString();
                digit = Preparation.FormDigitString(result);
            }
            else
            {
                symbolLen = SYMBOLS_FOR_LEN2;
                testOfRandomness = rt1.Text.Length == 0 ? File.ReadAllText("randomness.txt") : rt1.Text;
                Preparation.FilterText(ref testOfRandomness);
                rt1.Text = testOfRandomness;
                digit = Preparation.FormDigitString(testOfRandomness);
            }

            //digit = Preparation.FormDigitString("MAHEROVSKYANDRIY");
            //symbolLen = SYMBOLS_FOR_LEN;

            encryptedF.Clear(); encrypted2F.Clear();            
            InverseMatrix = Preparation.FormSuitableKey(string.Concat(openKey.Take(16)));
            SInverseMatrix = Preparation.FormSuitableKey(string.Concat(openKey.Skip(16)));           
            List<int> random = new List<int>(), random2 = new List<int>();

            
            //1-й раунд шифрування
            encrypted = Code.HillPlusRandomEncrypt(digit, KeyMatrix, Alphabet.Length, random);
            //var st = string.Join(" ",encrypted.Select(x=>x.ToString()));
            int[] count = Preparation.CalcRandomList(random, symbolLen);
           // st = string.Join(" ", count.Select(x => x.ToString()));
            //st = string.Join(" ", random.Select(x => x.ToString()));
            List<int> maskedR = Preparation.FormMaskedRandomList(random);
            //st = string.Join(" ", maskedR.Select(x => x.ToString()));
            encryptedF.AddRange(count); encryptedF.AddRange(maskedR); encryptedF.AddRange(encrypted);
            //st = string.Join(" ", encryptedF.Select(x => x.ToString()));
            //2-й раунд шифрування
            encrypted2 = Code.HillPlusRandomEncrypt(encryptedF, SKeyMatrix, Alphabet.Length, random2);
            //st = string.Join(" ", encrypted2.Select(x => x.ToString()));
            int[] count2 = Preparation.CalcRandomList(random2, symbolLen);
            //st = string.Join(" ", count2.Select(x => x.ToString()));
            //st = string.Join(" ", random2.Select(x => x.ToString()));
            List<int> maskedR2 = Preparation.FormMaskedRandomList(random2);
            //st = string.Join(" ", maskedR2.Select(x => x.ToString()));          
            encrypted2F.AddRange(count2); encrypted2F.AddRange(maskedR2); encrypted2F.AddRange(encrypted2);
            //st = string.Join(" ", encrypted2F.Select(x => x.ToString()));



            if (me == null)
            {
                signedTextBox.Text = Preparation.FormStringFromDigit(encrypted2F).ToString();
                hashTextBox.Text = Preparation.FormStringFromDigit(digit).ToString();
                checkHash.Enabled = true;
            }
            else
            {
                rt2.Text = Preparation.FormStringFromDigit(encryptedF).ToString();
                Preparation.ColorText(rt1, random, KeyMatrix.GetLength(0), Color.Yellow, 0);
                Preparation.ColorText(rt2, random, KeyMatrix.GetLength(0), Color.Yellow, count.Length + maskedR.Count);
                rt3.Text = Preparation.FormStringFromDigit(encryptedF).ToString();
                rt4.Text = Preparation.FormStringFromDigit(encrypted2F).ToString();
                Preparation.ColorText(rt3, random2, SKeyMatrix.GetLength(0), Color.Blue, 0);
                Preparation.ColorText(rt4, random2, SKeyMatrix.GetLength(0), Color.Blue, count2.Length + maskedR2.Count);
            }
        }

        private void checkHash_Click(object sender, EventArgs e)
        {
            MyEvents me = e as MyEvents;
            int symbolLen;
            if (me == null)
            {
                symbolLen = SYMBOLS_FOR_LEN;
            }
            else
            {
                symbolLen = SYMBOLS_FOR_LEN2;
            }

            
            //1-й раунд розшифровки
            int count2 = Convert.ToInt32(String.Concat(encrypted2F.Take(symbolLen)));
            List<int> random2 = Preparation.FormUnmaskedRandomList(encrypted2F.Skip(symbolLen).Take(count2).ToList());
            //var st = string.Join(" ", random2.Select(x => x.ToString()));
            encrypted2 = encrypted2F.Skip(symbolLen + random2.Count).ToList();
            //st = string.Join(" ", encrypted2.Select(x => x.ToString()));
            decrypted2 = Code.HillPlusRandomDecrypt(encrypted2, SInverseMatrix, Alphabet.Length, random2);
            //st = string.Join(" ", decrypted2.Select(x => x.ToString()));
            //2-й раунд розшифровки
            int count = Convert.ToInt32(String.Concat(decrypted2.Take(symbolLen)));
            List<int> random = Preparation.FormUnmaskedRandomList(decrypted2.Skip(symbolLen).Take(count).ToList());
            //st = string.Join(" ", random.Select(x => x.ToString()));
            encrypted = decrypted2.Skip(symbolLen + random.Count).ToList();
            string gfdsf = Preparation.FormStringFromDigit(decrypted2).ToString();
            //st = string.Join(" ", encrypted.Select(x => x.ToString()));
            decrypted = Code.HillPlusRandomDecrypt(encrypted, InverseMatrix, Alphabet.Length, random);
            //st = string.Join(" ", decrypted.Select(x => x.ToString()));
            if (me == null)
            {
                decrypted = decrypted.Take(32).ToList();
                decryptedHashTextBox.Text = Preparation.FormStringFromDigit(decrypted).ToString();
                string testOfRandomness2 = File.ReadAllText("randomness.txt");
                Preparation.FilterText(ref testOfRandomness2);
                string result = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(testOfRandomness2), 7, 0,true)).ToString();
                computedHashTextBox.Text = result;

                if (decryptedHashTextBox.Text.Equals(result))
                    MessageBox.Show("Document is original!");
                else
                    MessageBox.Show("Document is fake!");
            }
            else
            {
                rt5.Text = Preparation.FormStringFromDigit(decrypted).ToString();
            }
        }
        private class MyEvents : EventArgs
        {

        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            this.signButton_Click(this, new MyEvents());
            Decrypt.Enabled = true;          
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            this.checkHash_Click(this,new MyEvents());
        }
    }
}
