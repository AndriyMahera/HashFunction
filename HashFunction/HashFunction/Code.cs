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
        public static List<int> HashFunction(List<int> input,int numOfBlock,int id)
        {
            List<int> output = new List<int>();
            int innerid = id;
            List<int> middle = new List<int>();
            List<int> reserve = new List<int>();
            reserve.AddRange(input);
            int order = (int)Math.Sqrt(matrix.Length);
            while (reserve.Count != 0)
            {
                if (reserve.Count < (order-1)*numOfBlock)
                {
                    while (reserve.Count != (order - 1) * numOfBlock)
                        reserve.Add(26);
                }
                middle = BlockAction(reserve.Take((order - 1) * numOfBlock).ToList(),numOfBlock,ref innerid);
                output.AddRange(BlockAction(middle,numOfBlock,ref innerid));
                innerid = id;
                reserve.RemoveRange(0, (order - 1) * numOfBlock);
                
            }  
            return output;
        }
        private static List<int> BlockAction(List<int>arr,int numOfBlock,ref int id)
        {
            List<int> output = new List<int>();
            int order=arr.Count/numOfBlock+1;
            for (int i = 0; i < numOfBlock; i++)
            {
                double[] temp = new double[order];
                Array.Copy(arr.Take(order-1).ToArray(),0,temp,1,order-1);
                temp[0] = id;
                temp = MathOperations.MultiplyMatrices(temp,matrix,alphabet);
                output.AddRange(temp.Take(order - 1).Select(x => (int)x).ToArray());
                arr.RemoveRange(0,order-1);
                id = (int)temp.Last();
            }
            return output;
        }
    }
}
