using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace HashFunction
{
    using DataBase = CreateAccountForm.DataBase;
    public partial class Autorization : Form
    {
        private List<DataBase> dbClass = new List<DataBase>();
        private string dataBase="Database.txt";
        private string[] dbArray;
        private const int RAND_LENGTH = 13;
        private static Random rnd = new Random();
        private const string ALPHABET = Form1.Alphabet;
        private Form1 mainForm;

        public Autorization()
        {
            InitializeComponent();
        }

        private void log_in_Button_Click(object sender, EventArgs e)
        {
            DataBase db = dbClass.Where(x => x.NAME == loginTextBox.Text).First();
            if (db != null)
            {
                string salt = db.SALT;
                string hashValue = db.HASH;
                string randomSeq = string.Concat(Enumerable.Range(0,RAND_LENGTH).Select(x=>ALPHABET[rnd.Next(0,ALPHABET.Length)]));
                string computedHashValue = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(passwordTextBox.Text+salt),7,0,true)).ToString();
                string actual = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(randomSeq+computedHashValue),7,0,true)).ToString();
                string expected = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(randomSeq + hashValue), 7, 0,true)).ToString();
                if (actual.Equals(expected))
                {
                    mainForm = new Form1();
                    Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else { MessageBox.Show("You wrote the wrong password or login,please try again"); }
            }
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            if (File.Exists(dataBase))
            {
                dbArray = File.ReadAllLines(dataBase);
                for (int i = 0; i < dbArray.Length; i++)
                {
                    string[] line = dbArray[i].Split(new[] { '\\' });
                    dbClass.Add(new DataBase(Convert.ToInt32(line[0]), line[1], line[2], line[3]));
                }
            }
            else { MessageBox.Show("Database can not be founded!"); }
            passwordTextBox.UseSystemPasswordChar = true;

        }
    }
}
