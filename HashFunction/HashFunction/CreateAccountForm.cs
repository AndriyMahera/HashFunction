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
    public partial class CreateAccountForm : Form
    {
        private static string dataBase = "Database.txt";
        private string login, password;
        private string[] dbArray;
        private List<DataBase> dbClass=new List<DataBase>();
        private static Random rnd=new Random();
        private const int SALT_LENGTH = 13;
        private const string ALPHABET = Form1.Alphabet;
        public class DataBase
        {
            private int id=-1;
            private string name,hash,salt;

            public DataBase(int id,string name,string hash,string salt)
            {
                this.name = name;
                this.hash = hash;
                this.salt = salt;
                this.id = id;

            }

            public int ID
            {
                get { return id; }
            }
            public string NAME
            {
                get { return name; }
            }
            public string HASH
            {
                get { return hash; }
            }
            public string SALT
            {
                get { return salt; }
            }
            public override string ToString()
            {
                return string.Format("{0}\\{1}\\{2}\\{3}",this.id,this.name,this.hash,this.salt);
            }
        }


        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            login = loginTextBox.Text;
            password = passwordTextBox.Text;
            if (File.Exists(dataBase))
            {
                dbArray = File.ReadAllLines(dataBase);
                for (int i = 0; i < dbArray.Length; i++)
                {
                    string[] line=dbArray[i].Split(new []{'\\'});
                    dbClass.Add(new DataBase(Convert.ToInt32(line[0]),line[1],line[2],line[3]));
                }

                if (dbClass.Count > 0)
                {
                    if (!dbClass.Select(x => x.NAME).Contains(login))
                    {
                        AddNewAccount(login, password);
                    }
                }
                else { AddNewAccount(login, password); }
            }
            else
            {
                File.Create(dataBase);
                MessageBox.Show("Database can not be founded.New Database was created.");
            }
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true;

        }

        private int FindSuitableId(List<DataBase>array)
        {
            int[] idArray = array.Select(x => x.ID).ToArray();
            int i = 0;
            while (idArray.Contains(i))
            {
                i += 1;
            }
            return i;
        }
        private void AddNewAccount(string login,string password)
        {
            string newSalt = String.Concat(Enumerable.Range(0, SALT_LENGTH).Select(x => ALPHABET[rnd.Next(0, ALPHABET.Length)]));
            string newHash = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(password + newSalt), 7, 0)).ToString();
            dbClass.Add(new DataBase(FindSuitableId(dbClass), login, newHash, newSalt));
            dbClass = dbClass.OrderBy(x => x.ID).ToList();
            using (StreamWriter stream = new StreamWriter(dataBase, false))
            {
                foreach (DataBase db in dbClass)
                {
                    stream.WriteLine(db.ToString());
                }
            }
        }

    }
}
