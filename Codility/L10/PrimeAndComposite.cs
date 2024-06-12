using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.L10
{
    [TestClass]
    public class PrimeAndComposite
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = CountTurnedCoins(10);

            //TODO LogN solusion
        }

        private int CountTurnedCoins(int n)
        {
            /* create array of N coins
             * execute For i : 0 -> N
             * for each i
             * calculate coin index = i * 1,2,3.. <= N
             * flip coin for each index
             * count fliped coins
             */

            //create array of N coins
            Coin[] coins = new Coin[n]; 
            for (int i = 0; i < n; i++)
            {
                coins[i] = new Coin();
            }

           // execute For i: 0->N
            for (int i = 1; i < n+1; i++)//each person
            {
                //calculate coin index = i * 1,2,3.. <= N
                for (int j = 1; j * i < n+1 ; j++)
                {
                    // flip coin for each index
                    int index = i * j;
                    coins[index - 1].TurnOver();
                }
            }

            int tailCount = 0;
            for (int i = 0; i < n; i++)
            {
                if (coins[i].state == Coin.Side.Tail)
                    tailCount++;
            }

            return tailCount;
        }

        private class Coin
        {
            public Side state { get; private set; }

            public Coin()
            {
                state = Side.Head;
            }

            public void TurnOver()
            {
                if (state == Side.Tail)
                {
                    state = Side.Head;
                }
                else
                {
                    state = Side.Tail;
                }
            }

            public override string ToString()
            {
                return state.ToString();
            }

            public enum Side
            {
                Head,
                Tail
            }
        }
    }
}
