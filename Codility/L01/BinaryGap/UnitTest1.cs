using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.CompilerServices;

namespace Codility.L1.BinaryGap
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(32);
        }
    }

    class Solution
    {
        private IState State { get; set; }
        private int Max { get; set; }
        public Solution()
        {
            State = new InitialSate(this);
        }

        public int solution(int N)
        {
            string binary = IntToBinary(N);

            foreach (char c in binary)
            {
                State.Handle(c);
            }

            return Max;
        }

        private string IntToBinary(int num)
        {
            return Convert.ToString(num, 2);
        }


         interface IState
        {
            void Handle(char num);
        }

        class InitialSate : IState
        {
            private readonly Solution _context;

            public InitialSate(Solution context)
            {
                _context = context;
            }
            public void Handle(char num)
            {
                if (num == '1')
                {
                    _context.State = new CountState(_context);
                }
            }
        }

        class CountState : IState
        {
            private readonly Solution _context;
            private int _currentCounter;
            public CountState(Solution context)
            {
                _context = context;
            }

            public void Handle(char num)
            {
                if (num == '0')
                {
                    _currentCounter++;
                }
                else
                {
                    if (_context.Max < _currentCounter)
                    {
                        _context.Max = _currentCounter;
                    }

                    _currentCounter = 0;
                }
            }
        }

        
    }
}