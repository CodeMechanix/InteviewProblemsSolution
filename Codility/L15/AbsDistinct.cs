using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.L15
{
    [TestClass]
    public class L15Test
    {
        [TestMethod]
        public void Test()
        {
            new Solution().solution(new int[] { -2147483648, 0 });
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {

            if (A.Length == 1){return 1;}

            int conutDistinct = 0 ;
            Caterpillar caterpillar = new Caterpillar(A);
            long prewLeft = 0;
            long prewRight = 0;

            while (caterpillar.CanMove())
            {               
                if (caterpillar.LeftValue == caterpillar.RightValue)
                {
                    prewLeft = caterpillar.LeftValue;
                    MoveLeft(caterpillar);
                    prewRight = caterpillar.RightValue;
                    MoveRight(caterpillar);
                    conutDistinct++;
                }
                else if (caterpillar.LeftValue > caterpillar.RightValue)
                {
                    prewLeft = caterpillar.LeftValue;
                    MoveLeft(caterpillar);
                    conutDistinct++;
                }
                else
                {
                    prewRight = caterpillar.RightValue;
                    MoveRight(caterpillar);
                    conutDistinct++;
                }
            }

            if (prewLeft != prewRight)
            {
                conutDistinct++;
            }

            return conutDistinct;
        }

        private static void MoveRight(Caterpillar caterpillar)
        {
            var start = caterpillar.RightValue;
            while (caterpillar.CanMove() && caterpillar.RightValue == start)
            {
                caterpillar.MoveRightSide();
            }
        }

        private static void MoveLeft(Caterpillar caterpillar)
        {
            var start = caterpillar.LeftValue;
            while (caterpillar.CanMove() && start == caterpillar.LeftValue)
            {
                caterpillar.MoveLeftSide();
            }
        }
    }

    class Caterpillar
    {
        private readonly int[] values;
        private int _leftPosition;
        private int _rightPosition;
        private int _duplicatesCount;

        public Caterpillar(int[] values)
        {
            this.values = values;
            _leftPosition = 0;
            _rightPosition = values.Length - 1;
        }

        public bool CanMove()
        {
            return _leftPosition < _rightPosition && 
                _leftPosition < values.Length-1 &&
                _rightPosition >0;
        }

        public long LeftValue => Math.Abs((long)values[_leftPosition]);
        public void MoveLeftSide()
        {
            _leftPosition++;
        }

        public long RightValue => Math.Abs((long)values[_rightPosition]);

        public void MoveRightSide()
        {
            _rightPosition--;
        }
    }

}
