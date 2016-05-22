using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HashFunction
{
    public class Code
    {
        private const string ALPHABET = Form1.Alphabet;
        private static int alphabet = Form1.Alphabet.Length;
        private static double[,] matrix = Form1.KeyMatrix;
        private static double[,] matrix2 = Form1.SKeyMatrix;
        private static double[,] matrix3 = Form1.TKeyMatrix;
        private static double[,] matrix4 = Form1.FKeyMatrix;
        private static List<double[,]> matrList = new List<double[,]>();
        private const int BASE = 5;
        private const int NUM_IN_BLOCK = 2,K0=15,N=12,COEF_K=-1;


        public static List<int> HashFunction(List<int> input,int numOfRounds,int id,bool needToPinch)
        {
            List<int> output = new List<int>();
            int innerid = id;
            List<int> middle = new List<int>();
            List<int> reserve = new List<int>();
            matrList.Clear();
            reserve.AddRange(input);
            matrList.AddRange(new []{matrix,matrix4,matrix3,matrix2,matrix,matrix2,matrix3,matrix4,matrix2});

            int amountInBlock = matrList.Select(x=>x.GetLength(0)-1).Sum();

            while (reserve.Count != 0)
            {               
                if (reserve.Count < amountInBlock)
                {
                    while (reserve.Count != amountInBlock)
                        reserve.Add(26);
                }
                middle = BlockAction(reserve.Take(amountInBlock).ToList(), ref innerid);
                for (int i = 0; i < numOfRounds-1; i++)
                {
                    middle = BlockAction(middle, ref innerid);
                }

                if (needToPinch)
                {
                    if (output.Count == 0)
                    {
                        output.AddRange(middle);
                    }
                    else
                    {
                        List<int> result = Miyaguchi_Preneel(output, middle, reserve.Take(amountInBlock).ToList());
                        output.Clear();
                        output.AddRange(result);
                    }
                }
                else
                {
                    output.AddRange(middle);
                }
                innerid = id;
                reserve.RemoveRange(0, amountInBlock);
            }  
            return output;
        }
        private static List<int> BlockAction(List<int>arr,ref int id)
        {
            List<int> output = new List<int>();
            for (int j = 0; j < matrList.Count; j++)
            {
                int order = matrList[j].GetLength(0);
                double[] temp = new double[order];
                Array.Copy(arr.Take(order - 1).ToArray(), 0, temp, 1, order - 1);
                temp[0] = id;
                temp = MathOperations.MultiplyMatrices(temp, matrList[j], alphabet);
                output.AddRange(temp.Take(order - 1).Select(x => (int)x).ToArray());
                arr.RemoveRange(0, order - 1);
                id = (int)temp.Last();
            }
            return output;
        }
        private static List<int> Miyaguchi_Preneel(List<int> H_prev,List<int> H_curr,List<int> m)
        {
            if (H_prev.Count != H_curr.Count && H_curr.Count!=m.Count)
                throw new ArgumentException("Different sizes!");
            List<int> middle = m.Select((x, i) => H_curr[i]^x).ToList();
            return middle.Select((x, i) => x ^ H_prev[i]).ToList();
        }       
        public static List<int> HillPlusRandomEncrypt(List<int> list, double[,] matrix, int alphabet, List<int> random)
        {
            random.Clear();
            List<int> outList = new List<int>();
            List<int> reserve = new List<int>();
            reserve.AddRange(list);
            Random rnd = new Random();
            int order = (int)Math.Sqrt(matrix.Length);

            double[] Temp = new double[order];
            while (reserve.Count != 0)
            {
                if (reserve.Count < order)
                {
                    int resC = reserve.Count;
                    for (int i = 0; i < order - resC; i++)
                        reserve.Add(26);
                }
                Temp = MathOperations.MultiplyMatrices(reserve.Take(order).Select(x => (double)x).ToArray(), matrix, alphabet);
                outList.AddRange(Temp.Select(x => (int)x));
                reserve.RemoveRange(0, order);
                if (reserve.Count != 0)
                {
                    int ran = rnd.Next(0, BASE);
                    ran = ran > reserve.Count ? reserve.Count : ran;
                    outList.AddRange(reserve.Take(ran));
                    random.Add(ran);
                    reserve.RemoveRange(0, ran);
                }
            }
            return outList;
        }
        public static List<int> HillPlusRandomDecrypt(List<int> list, double[,] matrix, int alphabet, List<int> random)
        {
            List<int> outList = new List<int>();
            List<int> reserve = new List<int>();
            List<int> resRand = new List<int>();
            resRand.AddRange(random);
            reserve.AddRange(list);
            int order = (int)Math.Sqrt(matrix.Length);

            double[] Temp = new double[order];
            while (reserve.Count != 0)
            {
                if (reserve.Count < order)
                    break;
                Temp = MathOperations.MultiplyMatrices(reserve.Take(order).Select(x => (double)x).ToArray(), matrix, alphabet);
                outList.AddRange(Temp.Select(x => (int)x));
                reserve.RemoveRange(0, order);
                if (resRand.Count != 0)
                {
                    outList.AddRange(reserve.Take(resRand.First()));
                    reserve.RemoveRange(0, resRand.First());
                    resRand.RemoveAt(0);
                }
            }
            return outList;
        }
        public static List<int> Vigenere(List<int> list,string key,bool needToEncrypt)
        {
            List<int> result = new List<int>();
            key = key.ToUpper();
            if (needToEncrypt)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    result.Add((list[i] + ALPHABET.IndexOf(key[i % key.Length])) % alphabet);
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    result.Add((list[i] - ALPHABET.IndexOf( key[i %  key.Length]) + alphabet) % alphabet);
                }
            }
            return result;
        }
        public static List<int> FeistelEncrypt_Decrypt(List<int> digit, bool needToEncrypt)
        {
            List<int> output = new List<int>();
            int a1 = digit.Count / NUM_IN_BLOCK;
            int a2 = digit.Count % NUM_IN_BLOCK;
            if (a2 != 0)
                digit.Add(26);
            int[] Temp = new int[NUM_IN_BLOCK];
            for (int i = 0; i < digit.Count; i += NUM_IN_BLOCK)
            {
                for (int j = 0, m = i; j < NUM_IN_BLOCK; j++, m++)
                {
                    Temp[j] = digit[m];
                }
                Temp = FeistelBlockAction(Temp, needToEncrypt);
                output.AddRange(Temp.ToList());
            }
            return output;
        }
        private static int[] FeistelBlockAction(int[] matr, bool needToEncrypt)
        {
            int k; int[] output = new int[matr.Length]; ;
            switch (needToEncrypt)
            {
                case true: k = K0;
                    for (int i = 0; i < N; i++)
                    {
                        if (i != N - 1)
                        {
                            output[0] = (matr[0] * k) % alphabet ^ matr[1];
                            output[1] = matr[0];
                            matr[0] = output[0];
                            matr[1] = output[1];
                        }
                        else
                        {
                            output[1] = (matr[0] * k) % alphabet ^ matr[1];
                            matr[1] = output[1];
                        }
                        k += COEF_K;
                    }
                    break;
                case false: k = K0 - N + 1;
                    for (int i = 0; i < N; i++)
                    {
                        if (i != N - 1)
                        {
                            output[0] = (matr[0] * k) % alphabet ^ matr[1];
                            output[1] = matr[0];
                            matr[0] = output[0];
                            matr[1] = output[1];
                        }
                        else
                        {
                            output[1] = (matr[0] * k) % alphabet ^ matr[1];
                            matr[1] = output[1];
                        }
                        matr[1] = output[1];
                        k -= COEF_K;
                    }
                    break;
            }
            return output;
        }
        public static List<int> Hill_Encrypt_Decrypt(List<int> list, double[,] matrix, int alphabet)
        {
            List<int> outList = new List<int>();
            List<int> reserve = new List<int>();
            reserve.AddRange(list);
            int order = (int)Math.Sqrt(matrix.Length);
            double[] Temp = new double[order];
            while (reserve.Count != 0)
            {
                while (reserve.Count < order)
                    reserve.Add(26);
                Temp = MathOperations.MultiplyMatrices(reserve.Take(order).Select(x => (double)x).ToArray(), matrix, alphabet);
                outList.AddRange(Temp.Select(x => (int)x));
                reserve.RemoveRange(0, order);
            }
            return outList;
        }
        
    }
}
