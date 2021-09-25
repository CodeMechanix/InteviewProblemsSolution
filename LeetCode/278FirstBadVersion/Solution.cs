using System.Collections.Generic;

namespace LeetCode._278FirstBadVersion
{
    public class Solution : VersionControl
    {
        private Dictionary<int, bool> _dictionary = new Dictionary<int, bool>();

        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;

            if (IsBadVersion(1))
            {
                return 1;
            }


            while (left < right)
            {
                int middleIndex = (right - left) / 2 + left;

                var mid = IsBadVersion(middleIndex);

                if (mid)
                {
                    var prevIsBadVersion = IsBadVersion(middleIndex - 1);
                    if (!prevIsBadVersion)
                    {
                        return middleIndex;
                    }
                }
                else
                {
                    var nextIsBadVersion = IsBadVersion(middleIndex + 1);
                    if (nextIsBadVersion)
                    {
                        return middleIndex + 1;
                    }
                }

                if (mid)
                {
                    right = middleIndex - 1;
                }
                else
                {
                    left = middleIndex + 1;
                }
            }

            return -1;
        }

        private new bool IsBadVersion(int version)
        {
            if (!_dictionary.ContainsKey(version))
            {
                _dictionary[version] = base.IsBadVersion(version);
            }

            return _dictionary[version];
        }
    }
}