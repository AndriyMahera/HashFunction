using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashFunction;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace UnitTestProject1
{

    [TestClass]
    public class UnitTest1
    {
        String alph = Form1.Alphabet;
        Random rnd=new Random(), rnd2=new Random();
        [TestMethod]
        public void TestMethod1()
        {
            bool isUnique = false;
            List<List<int>> megalist = new List<List<int>>();
            List<List<int>> lissssst = new List<List<int>>();
            List<int> list;
            for (int i = 0; i < 10000; i++)
            {
                
                rnd = new Random();
                list = Enumerable.Range(0, 12).Select(x => rnd2.Next(0, alph.Length)).ToList();
                if (lissssst.All(x => !x.SequenceEqual(list)))
                {
                    lissssst.Add(list);
                    megalist.Add(HashFunction.Code.HashFunction(list, 4, 0));
                }
            }
            isUnique = megalist.Count == lissssst.Count;
            Assert.AreEqual(isUnique, true, "");
        }
        [TestMethod]
        public void TestSingleSequence()
        {
         
            using (StreamWriter stream = new StreamWriter("Result.txt"))
            {
                for (int i = 0; i < alph.Length; i++)
                {

                    stream.Write(alph[i] + "\t- \t");
                    stream.Write(HashFunction.Preparation.FormStringFromDigit(HashFunction.Code.HashFunction(new[] { i }.ToList(), 4, 12)));
                    stream.WriteLine();
                }
            }
        }
        [TestMethod]
        public void TestAvalancheEffect()
        {
            string str = "MAHEROVSKY";
            FileInfo file = new FileInfo("Avalanche.txt");
            if (file.Exists == true)
                file.Delete();
            using (StreamWriter stream = new StreamWriter("Avalanche.txt", true))
            {
                for (int i = 0; i < alph.Length; i++)
                {
                    var list = Code.HashFunction(Preparation.FormDigitString(str+alph[i]), 7, 0);
                    stream.Write(str+alph[i]  + "\t");
                    stream.Write(Preparation.FormStringFromDigit(list) + "\r\n");
                }
            }
        }
        [TestMethod]
        public void TestFirstProperty()
        {
            string h = "VA5YQF,5OCUAEC4MN4'5O";
            string actual;
            List<int> list = new List<int>();
            bool isEqual = false;
            for (int i = 0; i < 10000000; i++)
            {
                list.Clear();
                for (int j = 0; j < 31; j++)
                {
                    list.Add(rnd.Next(0,alph.Length));
                }
                actual = Preparation.FormStringFromDigit(Code.HashFunction(list,7,0)).ToString();
                if (h.Equals(actual))
                {
                    isEqual = true;
                    break;
                }
                
            }
            Assert.AreEqual(isEqual, false, "Found equal value!You loose.");

        }


        [TestMethod]
        public void TestSecondProperty()
        {
            string h = "VA5YQF,5OCUAEC4MN4'5O";
            string expected = Preparation.FormStringFromDigit(Code.HashFunction(Preparation.FormDigitString(h),7,0)).ToString();
            string actual;
            List<int> list = new List<int>();
            bool isEqual = false;
            for (int i = 0; i < 10000000; i++)
            {
                list.Clear();
                for (int j = 0; j < 21; j++)
                {
                    list.Add(rnd.Next(0, alph.Length));
                }
                actual = Preparation.FormStringFromDigit(Code.HashFunction(list, 7, 0)).ToString();
                if (expected.Equals(actual))
                {
                    isEqual = true;
                    break;
                }

            }
            Assert.AreEqual(isEqual, false, "Found equal value!You loose.");
        }

        //[TestMethod]
        //public void TestMethod3()
        //{
        //    bool isUnique = false;
        //    List<List<int>> megalist = new List<List<int>>();
        //    List<int> list=Enumerable.Range(0,12).Select(x=>x=0).ToList();
        //        while (list.First() != alph.Length - 1)
        //        {
        //            megalist.Add(HashFunction.Code.HashFunction(list, 4, 0));
        //            using (StreamWriter stream = new StreamWriter("TEST3.txt"))
        //                stream.Write(megalist.Last()+"\r\n");
        //            while (list.Last() == alph.Length - 1)
        //            {
        //                list.RemoveAt(list.Count-1);
        //            }
        //            list[list.Count - 1] += 1;
        //            while (list.Count < 12)
        //                list.Add(0);
        //        }
        //    isUnique = megalist.Count == megalist.Distinct().ToList().Count;
        //    Assert.AreEqual(isUnique, true, "");
        //}
    }
}
