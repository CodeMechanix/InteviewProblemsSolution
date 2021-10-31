using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.CodeDom;

namespace Other.CheckPoint._1
{
    /*
     <div class="brinza-task-description">
<p>You are given strings S and C. String S represents a table in CSV (comma−separated values) format, where rows are separated by new line characters ('\n') and each row consists of one or more fields separated by commas (',').</p>
<p>The first row contains the names of the columns. The following rows contain values.</p>
<p>For example, the table below is presented by the following string: S = "id,name,age,act.,room,dep.\n1,Jack,68,T,13,8\n17,Betty,28,F,15,7".</p>
<tt style="white-space:pre-wrap"> +----+-------+-----+------+------+------+
 | id |  name | age | act. | room | dep. |
 +----+-------+-----+------+------+------+
 |  1 |  Jack |  68 |    T |   13 |    8 |
 | 17 | Betty |  28 |    F |   15 |    7 |
 +----+-------+-----+------+------+------+</tt>
<p>String C is the name of a column in the table described by S that contains only integers. Your task is to find the maximum value in that column. In the example above, for C = "age", the maximum value is 68.</p>
<p>Write a function:</p>
<blockquote><p style="font-family: monospace; font-size: 9pt; display: block; white-space: pre-wrap"><tt>class Solution { public int solution(string S, string C); }</tt></p></blockquote>
<p>which, given two strings S and C consisting of N and M characters, respectively, returns the maximum value in column C of the table described by S.</p>
<p>Examples:</p>
<p>1. Given S = "id,name,age,act.,room,dep.\n1,Jack,68,T,13,8\n17,Betty,28,F,15,7" and C = "age", your function should return 68 since 68 is the maximum of 68 and 28.</p>
<tt style="white-space:pre-wrap"> +----+-------+-----+------+------+------+
 | id |  name | age | act. | room | dep. |
 +----+-------+-----+------+------+------+
 |  1 |  Jack |  68 |    T |   13 |    8 |
 | 17 | Betty |  28 |    F |   15 |    7 |
 +----+-------+-----+------+------+------+</tt>
<p>2. Given S = "area,land\n3722,CN\n6612,RU\n3855,CA\n3797,USA" and C = "area",</p>
<tt style="white-space:pre-wrap"> +------+------+
 | area | land |
 +------+------+
 | 3722 |   CN |
 | 6612 |   RU |
 | 3855 |   CA |
 | 3797 |  USA |
 +------+------+</tt>
<p>your function should return 6612.</p>
<p>3. Given S = "city,temp2,temp\nParis,7,−3\nDubai,4,−4\nPorto,−1,−2" and C = "temp",</p>
<tt style="white-space:pre-wrap"> +-------+-------+------+
 | city  | temp2 | temp |
 +-------+-------+------+
 | Paris |     7 |   -3 |
 | Dubai |     4 |   -4 |
 | Porto |    -1 |   -2 |
 +-------+-------+------+</tt>
<p>your function should return −2.</p>
<p>Assume that:</p>
<blockquote><ul style="margin: 10px;padding: 0px;"><li>S is a string of length N in CSV format;</li>
<li>N is an integer within the range [<span class="number">3</span>..<span class="number">100,000</span>];</li>
<li>M is an integer within the range [<span class="number">1</span>..<span class="number">5</span>];</li>
<li>there are at least two rows;</li>
<li>each row has the same,                positive number of cells;</li>
<li>each cell is of length [1..5] and consists only of                    letters, digits and/or special characters: '. -';</li>
<li>C is the name of a unique column in the table,                    whose values are integers within the range [−9999..9999];                    there are no erroneous values in this column;</li>
<li>there is no new line at the end of string S.</li>
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
//            var S = "id,name,age,act.,room,dep.\n1,Jack,68,T,13,8\n17,Betty,28,F,15,7";
            var S = "area,land\n3722,CN\n6612,RU\n3855,CA\n3797,USA";
            var C = "area";
            var solution = new Solution().solution(S,C);
        }
        class Solution
        {
            public int solution(string S, string C)
            {
                string[] lines = S.Split(new []{ '\n' });


                string[] conNames = lines[0].Split(new []{','});

                int conNum = 0;
                for (int i = 0; i < conNames.Length; i++)
                {
                    if (conNames[i].Equals(C))
                    {
                        conNum = i;
                        break;
                    }
                }

                int max = int.MinValue;

                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var cellString = line.Split(new []{','})[conNum];
                    var cellNum = Int32.Parse(cellString);

                    if (cellNum > max)
                    {
                        max = cellNum;
                    }
                }





                return max;
            }
        }
    }
}
