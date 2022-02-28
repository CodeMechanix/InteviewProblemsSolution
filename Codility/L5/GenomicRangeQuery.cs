using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility.L5
{
    [TestClass]
    public class GenomicRangeQuery
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution("CAGCCTA", new[] { 2, 5, 0 }, new[] { 4, 5, 6 });
        }

        class Solution
        {
            private Dictionary<char, int> charToInt = new Dictionary<char, int>()
            {
                { 'A', 1 }, { 'C', 2 }, { 'G', 3 }, { 'T', 4 }
            };

            private int ToInt(char c)
            {
                return charToInt[c];
            }

            private Dictionary<int, int> blocksDictionary = new Dictionary<int, int>();
            private List<Block> Blocks = new List<Block>();

            public int[] solution(string S, int[] P, int[] Q)
            {
                #region Init Block Dic

                int blockLength = 2;
                int nextBlock = blockLength;
                int blockId = 0;

                for (int i = 0; i < S.Length; i++)
                {
                    if (i == nextBlock)
                    {
                        nextBlock += blockLength;
                        blockId++;
                    }

                    blocksDictionary[i] = blockId;



                }

                #endregion

                int tempMax = Int32.MaxValue;
                Block tempBlock = new Block();

                for (int i = 0; i < S.Length; i++)
                {
                    var i1 = blocksDictionary[i];
                }


                return null;
            }


            public class Block
            {
                public int Min { get; set; }
                public int Left { get; set; }
                public int Right { get; set; }
            }


            // class Solution
            // {
            //     private Dictionary<char, int> dictionary = new Dictionary<char, int>()
            //     {
            //         { 'A', 1 }, { 'C', 2 }, { 'G', 3 }, { 'T', 4 }
            //     };
            //
            //     public int[] solution(String S, int[] P, int[] Q)
            //     {
            //         int[] result = new int[P.Length];
            //
            //         for (int i = 0; i < P.Length; i++)
            //         {
            //             result[i] = FindMin(S, P[i], Q[i]);
            //         }
            //
            //         return result;
            //     }
            //
            //     private int FindMin(String S, int start, int end)
            //     {
            //         int min = Int32.MaxValue;
            //
            //         for (int i = start; i < end + 1; i++)
            //         {
            //             char c = S[i];
            //             int val = dictionary[c];
            //
            //             if (min > val)
            //             {
            //                 min = val;
            //             }
            //         }
            //
            //         return min;
            //     }
            // }
        }
    }
}