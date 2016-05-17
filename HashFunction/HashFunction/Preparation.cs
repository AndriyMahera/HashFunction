﻿using System;
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
    }
}
