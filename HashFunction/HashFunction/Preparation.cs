using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Drawing;

namespace HashFunction
{
    public class Preparation
    {
        public const string alphabet = Form1.Alphabet;
        public const int SYMBOLS_FOR_LEN = 1;
        public const int BASE = 5;
        private static Random rnd = new Random();
        //count amount of symbols(bi,-threegrams)
        public static Dictionary<string, int> UniquesDict(string str, int amount)
        {

            Dictionary<string, int> dict = new Dictionary<string, int>();
            if (amount == 1)
            {
                foreach (char ch in alphabet)
                {
                    dict.Add(ch.ToString(), 0);
                }
            }
            for (int i = 0; i < str.Length - amount + 1; i++)
            {
                string value = str.Substring(i, amount);
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1;
            }
            return amount != 1 ? dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value) : dict;
        }
        //Стрічку в цифровий формат str -input string,digit - result(int list)
        public static List<int> FormDigitString(String str)
        {
            List<int> digit = new List<int>();
            foreach (char ch in str)
            {
                if (alphabet.IndexOf(ch) != -1)
                    digit.Add(alphabet.IndexOf(ch));
            }
            return digit;
        }
        //digit list into string(actually,stringbuilder)
        public static StringBuilder FormStringFromDigit(List<int> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int el in list)
                sb.Append(alphabet[el]);
            return sb;
        }
        //make chart
        public static void MakeChart(Chart chart, Dictionary<string, int> dict)
        {
            chart.Visible = true;
            chart.Series[0].Points.Clear();
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.Maximum = dict.Count + 0.5;
            foreach (KeyValuePair<string, int> kvp in dict)
            {
                chart.Series[0].Points.AddXY(kvp.Key, kvp.Value);
            }
        }
        //замалювати пробіли рандомні
        public static void ColorText(RichTextBox rtb, List<int> random, int order, Color color)
        {
            int sum = order;
            foreach (int el in random)
            {
                rtb.Select(sum, el);
                sum += el + order;
                rtb.SelectionBackColor = color;
            }
        }
        //фільтр
        public static void FilterText(ref string text)
        {
            text = text.ToUpper();
            StringBuilder sbuild = new StringBuilder();
            sbuild.Append(text);
            for (int i = 0; i < sbuild.Length; i++)
            {
                if (sbuild[i] != '\n')
                {
                    if (!alphabet.Contains(sbuild[i]))
                    {
                        sbuild.Remove(i, 1);
                        i -= 1;
                    }
                }
            }
            text = sbuild.ToString();
        }
        //середнє інтегральне відхилення
        public static double FindDeviation(Dictionary<string, int> dict, int count)
        {
            double dev = 0;
            double Max = double.MinValue;
            List<double> frequency = new List<double>();
            foreach (KeyValuePair<string, int> kpv in dict)
            {
                frequency.Add(kpv.Value / (double)count);
            }
            Max = frequency.Max();
            double Sum = frequency.Select(x => (Max - x) / Max).Sum();
            dev = Sum * 100 / alphabet.Length;
            return dev;
        }
        public static int FindBiteDiff(List<int> standard, List<int> input)
        {
            if (standard.Count != input.Count)
                throw new ArgumentException("Different lengths.Impossible to perform.");
            string standStr = FormBiteString(standard);
            string inputStr = FormBiteString(input);
            return standStr.Where((x, i) => x != inputStr[i]).Count();
        }
        private static string FormBiteString(List<int> input)
        {
            string result = "";
            foreach (int el in input)
            {
                string middle = Convert.ToString(el,2);
                while (middle.Length != 6)
                {
                    middle = "0" + middle;
                }
                result += middle;
            }
            return result;
        }
        public static double[,] FormSuitableKey(string str)
        {
            double order=Math.Sqrt(str.Length);
            int iorder=(int)order;
            if (order!= (int)order)
                throw new ArgumentException("It isn't key,fool!");
            double[,] output=new double[iorder,iorder];
            string []str2=new string[iorder];
            for(int i=0;i<iorder;i++)
                str2[i]=string.Concat(str.Skip(iorder*i).Take(iorder));
            for(int i=0;i<output.GetLength(0);i++)
                for(int j=0;j<output.GetLength(1);j++)
                    output[i,j]=alphabet.IndexOf(str2[i][j]);
            return output;
        }
        //сформувати рядок,що буде позначати кількість елементів в списку рандомів
        public static int[] CalcRandomList(List<int> rand,int symbolsForLen)
        {
            int[] result = new int[symbolsForLen];
            string str = rand.Count.ToString();
            if (str.Length > symbolsForLen)
                throw new ArgumentException("Your random list is too long");
            int[] part2 = str.Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] part1 = Enumerable.Range(0, symbolsForLen - str.Length).Select(x => 0).ToArray();
            return part1.Concat(part2).ToArray();
        }
        //знайти підходяще хєрове число
        public static int FindMaskNumber()
        {
            int res = rnd.Next(0, alphabet.Length - BASE);
            return res % BASE == 0 ? res : FindMaskNumber();
        }
        //спотворити рандомний список
        public static List<int> FormMaskedRandomList(List<int> rand)
        {
            return rand.Select(x => x + FindMaskNumber()).ToList();
        }
        public static List<int> FormUnmaskedRandomList(List<int> masked)
        {
            return masked.Select(x => x % BASE).ToList();
        }
    }
}
