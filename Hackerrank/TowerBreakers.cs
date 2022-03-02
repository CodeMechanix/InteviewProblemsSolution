using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    [TestClass]
    public class TowerBreakers
    {
        [TestMethod]
        public void TestMethod1()
        {
            var breakers = towerBreakers(2, 6);
        }


        public static int towerBreakers(int n, int m)
        {
            // Write your code here
            List<int> list = new List<int>();


            //init list
            for (int i = 0; i < n; i++)
            {
                list.Add(m);
            }

            int player = 1;
            int nextPlayer = 2;
            int prewPlayer;
            int h = -1;
            while (true)
            {
                list.Sort((i, i1) => i1 - i);

                for (var index = 0; index < list.Count; index++)
                {
                    int height = list[index];

                    h = FindHeigthToRemove(height);

                    if (h == -1)
                    {
                        continue;
                    }
                    else
                    {
                        list[index] = h;
                        break;
                    }
                }

                if (h == -1)
                {
                    //loose
                    break;
                }
                else
                {
                    prewPlayer = player;
                    player = nextPlayer;
                    nextPlayer = prewPlayer;
                }

               
            }

            return nextPlayer;
        }

        private static int FindHeigthToRemove(int height)
        {
            if (height > 1)
            {
                for (int i = height - 1; i >= 0; i--)
                {
                    int mod = height % i;

                    if (mod == 0)
                    {
                        return i;
                    }
                }
            }
           

            return -1;
        }
    }
}