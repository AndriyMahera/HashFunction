using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashFunction
{
    public class Code
    {
        private static int alphabet = Form1.Alphabet.Length;
        private static double[,] matrix = Form1.KeyMatrix;
        private static double[,] matrix2 = Form1.SKeyMatrix;
        private static double[,] matrix3 = Form1.TKeyMatrix;
        private static List<double[,]> matrList = new List<double[,]>();
        public static List<int> HashFunction(List<int> input,int numOfRounds,int id)
        {
            List<int> output = new List<int>();
            int innerid = id;
            List<int> middle = new List<int>();
            List<int> reserve = new List<int>();
            matrList.Clear();
            reserve.AddRange(input);
            matrList.AddRange(new []{matrix3,matrix2,matrix,matrix2,matrix3});

            int amountInBlock = matrList.Select(x=>x.GetLength(0)).Sum();
            //for (int i = 0; i < matrList.Count; i++)
            //{
            //    amountInBlock += (matrList[i].GetLength(0) - 1);
            //}

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
                output.AddRange(middle);
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
    }
}
