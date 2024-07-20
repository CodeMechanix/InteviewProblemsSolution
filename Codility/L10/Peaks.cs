using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Codility.L10
{
    [TestClass]
    public class Peaks
    {

        [TestMethod]
        public void Test()
        {
            var a = new int[] { 1, 2, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 };
            //var a = new int[] { 0, 1, 0, 0, 1, 0, 0, 1, 0 };

            var peakBlocks = new PeakBlocks(a);
            var max = peakBlocks.MaxBlocks();
            //bool v = peakBlocks.CanBeDevidedToBlocks(1);
            // v = peakBlocks.CanBeDevidedToBlocks(2);
            // v = peakBlocks.CanBeDevidedToBlocks(3);
            // v = peakBlocks.CanBeDevidedToBlocks(4);
            // v = peakBlocks.CanBeDevidedToBlocks(5);
        }

        private class PeakBlocks
        {
            private readonly bool[] _peakArray;
            private readonly DevisorList _devisorPairList;
            public PeakBlocks(int[] altitudes)
            {
                _peakArray = new PeaksArray(altitudes).Result();
                _devisorPairList = new DevisorList(altitudes.Length);
                _devisorPairList.GenerateDevisors();
            }

            public int MaxBlocks()
            {
                int maxBlocks = 0;

                var orderedEnumerable = _devisorPairList
                    .SelectMany(pair => new int[] { pair.Item1, pair.Item2 })
                    .Distinct()
                    .OrderByDescending(i => i)
                    .Reverse()
                    .ToArray();

                for (int i = 0; i < orderedEnumerable.Length; i++)
                {
                    if (CanBeDevidedToBlocks(orderedEnumerable[i]))
                    {
                        maxBlocks= orderedEnumerable[i];
                    }
                }

                return maxBlocks;
            }

            public bool CanBeDevidedToBlocks(int numOfBlocks)
            {
                if (_peakArray.Length < numOfBlocks)
                {
                    return false;
                }

                var blockLength = _peakArray.Length / numOfBlocks;
                var index = 0;
                while (index < _peakArray.Length)
                {
                    if (BlockContainsPeak(blockLength, index))
                    {
                        index += blockLength;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }


            private bool BlockContainsPeak(int blockLength, int startIndex)
            {
                int index = startIndex;
                while (index < _peakArray.Length && index < startIndex + blockLength)
                {
                    if (_peakArray[index])
                    {
                        return true;
                    }
                    index++;
                }
                return false;
            }
        }
        private class PeaksArray
        {
            private readonly int[] _array;

            public PeaksArray(int[] array)
            {
                _array = array;
            }

            public bool[] Result()
            {
                var peaks = new bool[_array.Length];

                for (int i = 1; i < _array.Length - 1; i++)
                {
                    if (_array[i - 1] < _array[i] && _array[i] > _array[i + 1])
                    {
                        peaks[i] = true;
                    }
                }
                return peaks;
            }
        }
    }


}
