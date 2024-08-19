using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.L12
{
    [TestClass]
    public class EuclideanAlgorithmTest
    {
        [TestMethod]
        public void TestMethod()
        {


            bool v = hasSamePrimeDivisors(2007835830, 1561650090);



        }

        public static int gcd(int a, int b)
        {
            if (a % b == 0) return b;
            return gcd(b, a % b);
        }

        public static bool hasSamePrimeDivisors(int a, int b)
        {
            int gcdValue = gcd(a, b);
            int gcdA;
            int gcdB;
            while (a != 1)
            {
                gcdA = gcd(a, gcdValue);
                if (gcdA == 1)
                    break;
                a = a / gcdA;
            }
            if (a != 1)
            {
                return false;
            }
            while (b != 1)
            {
                gcdB = gcd(b, gcdValue);
                if (gcdB == 1)
                    break;
                b = b / gcdB;
            }
            return b == 1;
        }

        //class Solution
        //{
        //    public int solution(int[] A, int[] B)
        //    {
        //        int total = 0;
        //        for (int i = 0; i < A.Length; i++)
        //        {

        //            var gcd = new Gcd(A[i], B[i]).Result();
        //            var aDevided = A[i] / gcd;
        //            var bDevided = B[i] / gcd;

        //            if (CanDevide(gcd, aDevided) && CanDevide(gcd, bDevided))
        //            {
        //                total++; 
        //            }
        //            else
        //            {

        //            }



        //        }

        //        return total;
        //    }

        //private bool CanDevide(int target, int devisor)
        //{
        //    int v = target % devisor;

        //    if (v == 0)
        //    {

        //        return true;
        //    }

        //    return false;
        //}
        //}

        //    class Solution
        //{
        //    bool[] primes;
        //    public int solution(int[] A, int[] B)
        //    {
        //        int limit = Math.Max(A.Max(), B.Max());
        //        primes = new SieveOfEratos(limit + 1).Result();

        //        // Implement your solution here
        //        int total = 0;
        //        for (int i = 0; i < A.Length; i++)
        //        {

        //            if (SamePrimeDevisors(A[i], B[i]))
        //            {
        //                total++; ;
        //            }



        //        }

        //        return total;
        //    }

        //    private bool SamePrimeDevisors(int a, int b)
        //    {
        //        int gcd = new Gcd(a, b).Result();

        //        bool same = false;
        //        int i = 2;
        //        while (i <= Math.Max(a, b))
        //        {
        //            same = true;
        //            if (primes[i])
        //            {
        //                if (Devide(a, i) != Devide(b, i))
        //                {
        //                    same = false;
        //                    break;
        //                }
        //            }
        //            i++;
        //        }

        //        return same;
        //    }

        //    private bool Devide(int target, int devisor)
        //    {
        //        int v = target % devisor;

        //        if (v == 0)
        //        {

        //            return true;
        //        }

        //        return false;
        //    }
        //}


    }
}
