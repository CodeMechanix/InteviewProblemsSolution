using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Other.CheckPoint._3
{
    /*
     <div class="brinza-task-description">
<p>You are processing plane seat reservations. The plane has N rows of seats, numbered from 1 to N. There are ten seats in each row (labelled from A to K, with letter I omitted), as shown in the figure below:</p>
<p><img class="inline-description-image" src="https://codility-frontend-prod.s3.amazonaws.com/media/task_static/plane_seating_four_person/static/images/auto/54e7dd44d03c544425782f7cca0f9f90.png"></p>
<p><br>
</p>
<p>Some of the seats are already reserved. The list of reserved seats is given as a string S (of length M) containing seat numbers separated by single spaces: for example, <tt style="white-space:pre-wrap">"1A 3C 2B 40G 5A"</tt>. The reserved seats can be listed in S in any order.</p>
<p>Your task is to allocate seats for as many four-person families as possible. A four-person family occupies four seats in one row, that are next to each other − seats across an aisle (such as 2C and 2D) are not considered to be next to each other. It is permissible for the family to be separated by an aisle, but in this case exactly two people have to sit on each side of the aisle. Obviously, no seat can be allocated to more than one family.</p>
<p>Write a function:</p>
<blockquote><p style="font-family: monospace; font-size: 9pt; display: block; white-space: pre-wrap"><tt>class Solution { public int solution(int N, string S); }</tt></p></blockquote>
<p>that, given the number of rows N and a list of reserved seats as string S, returns the maximum number of four-person families that can be seated in the remaining unreserved seats.</p>
<p>For instance, given N = 2 and S = <tt style="white-space:pre-wrap">"1A 2F 1C"</tt>, your function should return 2. The following figure shows one possible way of seating two families in the remaining seats:</p>
<p><img class="inline-description-image" src="https://codility-frontend-prod.s3.amazonaws.com/media/task_static/plane_seating_four_person/static/images/auto/16df3cca26020fe7303043ae2ce3e0f2.png" alt="Figure explaining the first example"></p>
<p><br>
</p>
<p>Given N = 1 and S = <tt style="white-space:pre-wrap">""</tt> (empty string), your function should return 2, because we can seat at most two families in a single row of seats, as shown in the figure below:</p>
<p><img class="inline-description-image" src="https://codility-frontend-prod.s3.amazonaws.com/media/task_static/plane_seating_four_person/static/images/auto/34408b36b0dd00c76614d52b8e682950.png" alt="Figure explaining the second example"></p>
<p><br>
</p>
<p>Assume that:</p>
<blockquote><ul style="margin: 10px;padding: 0px;"><li>N is an integer within the range [<span class="number">1</span>..<span class="number">50</span>];</li>
<li>M is an integer within the range [<span class="number">0</span>..<span class="number">1,909</span>];</li>
<li>string S consists of valid seat names separated with single spaces;</li>
<li>every seat number appears in string S at most once.</li>
</ul>
</blockquote><p>In your solution, focus on <b><b>correctness</b></b>. The performance of your solution will not be the focus of the assessment.</p>
</div>
     */
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var N = 3;
            var S = "1A 2F 1C 3H";

            var solution = new Solution().solution(N, S);
        }

        class Solution
        {
            public int solution(int N, string S)
            {
                Dictionary<int, Line> dictionary = new Dictionary<int, Line>();

                var strings = S.Split(new []{' '});

                foreach (string s in strings)
                {
                    int line  =  s[0] - '0';
                    char col = s[1];

                    if (!dictionary.ContainsKey(line))
                    {
                        dictionary[line] = new Line();
                    }

                    dictionary[line].SetStatus(col);
                }

                int total = 0;
                foreach (var keyValuePair in dictionary)
                {
                    total += keyValuePair.Value.GetFamilyPlaces();
                }

                return total;
            }

            class Line
            {
                private string _left = "BC";
                private string _midLeft = "DE";
                private string _midRight = "FG";
                private string _right = "HJ";

                public bool Left { get; set; } = true;
                public bool Right { get; set; } = true;
                public bool Mid { get; set; } = true;

                public void SetStatus(char c)
                {
                    if (_left.Contains(c))
                    {
                        Left = false;
                    }
                    else if(_midLeft.Contains(c))
                    {
                        Left = false;
                        Mid = false;
                    }
                    else if(_midRight.Contains(c))
                    {
                        Mid = false;
                        Right = false;
                    }
                    else if(_right.Contains(c))
                    {
                        Right = false;
                    }
                }

                public int GetFamilyPlaces()
                {
                    int total = 0;

                    if ( Left)
                    {
                        total++;
                    }

                    if (Right)
                    {
                        total++;
                    }

                    if (Mid && !Left && !Right)
                    {
                        total++;
                    }

                    return total;
                }
            }
        }
    }
}
