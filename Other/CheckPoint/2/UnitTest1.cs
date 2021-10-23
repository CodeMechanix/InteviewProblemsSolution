using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Other.CheckPoint._2
{
    /*
    <div class="brinza-task-description">
<p>You are given a list of all the transactions on a bank account during the year 2020. The account was empty at the beginning of the year (the balance was 0).</p>
<p>Each transaction specifies the amount and the date it was executed. If the amount is negative (i.e. less than 0) then it was a card payment, otherwise it was an incoming transfer (amount at least 0). The date of each transaction is in YYYY−MM−DD format: for example, 2020−05−20 represents 20th May 2020.</p>
<p>Additionally, there is a fee for having a card (omitted in the given transaction list), which is 5 per month. This fee is deducted from the account balance at the end of each month unless there were at least three payments made by card for a total cost of at least 100 within that month.</p>
<p>Your task is to compute the final balance of the account at the end of the year 2020.</p>
<p>Write a function:</p>
<blockquote><p style="font-family: monospace; font-size: 9pt; display: block; white-space: pre-wrap"><tt>class Solution { public int solution(int[] A, string[] D); }</tt></p></blockquote>
<p>that, given an array A of N integers representing transaction amounts and an array D of N strings representing transaction dates, returns the final balance of the account at the end of the year 2020. Transaction number K (for K within the range [0..N-1]) was executed on the date represented by D[K] for amount A[K].</p>
<p><b>Examples:</b></p>
<p>1. Given A = [100, 100, 100, −10] and D = ["2020−12−31", "2020−12−22", "2020−12−03", "2020−12−29"], the function should return 230. Total income was equal to 100 + 100 + 100 − 10 = 290 and the fee was paid every month, so 290 - (5 * 12) = 230.</p>
<p>2. Given A = [180, -50, -25, -25] and D = ["2020−01−01", "2020−01−01", "2020−01−01", "2020−01−31"], the function should return 25. The income was equal to 180, the expenditure was equal to 100 and the fee was applied in every month except January: 180 - 100 - (5 * 11) = 25.</p>
<p>3. Given A = [1, -1, 0, -105, 1] and D = ["2020−12−31", "2020−04−04", "2020−04−04", "2020−04−14", "2020−07−12"], the function should return -164. The fee is paid every month. 1 - 1 + 0 - 105 + 1 - (5 * 12) = -164. Note that in April, even though the total cost of card payments was 106 (more than 100), there were only two payments made by card, so the fee was still applied. A transaction of value 0 is considered a positive, incoming transfer.</p>
<p>4. Given A = [100, 100, -10, -20, -30] and D =  ["2020−01−01", "2020−02−01", "2020−02−11", "2020−02−05", "2020−02−08"], the function should return 80.</p>
<p>Assume that:</p>
<blockquote><ul style="margin: 10px;padding: 0px;"><li>N is an integer within the range [<span class="number">1</span>..<span class="number">100</span>];</li>
<li>each element of array A is an integer within the range [<span class="number">−1,000</span>..<span class="number">1,000</span>];</li>
<li>D contains strings in YYYY−MM−DD format, representing dates in the range 2020−01−01 to 2020−12−31.</li>
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
            int[] A = { 180, -50, -25, -25 };
            string[] D = { "2020−01−01", "2020−01−01", "2020−01−01", "2020−01−31" };

            var solution = new Solution().solution(A, D);
        }

        class Solution
        {
            private Dictionary<int, Fee> _dictionary = new Dictionary<int, Fee>();
            private int _total = 0;
            
            public int solution(int[] A, string[] D)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    int transaction = A[i];
                    _total += transaction;


                    if (transaction < 0)
                    {
                        int monthId = GetMonthId(D[i]);

                        if (_dictionary.ContainsKey(monthId))
                        {
                            _dictionary[monthId].Total += transaction;
                            _dictionary[monthId].Payments++;
                        }
                        else
                        {
                            var fee = new Fee();
                            fee.Total = transaction;
                            fee.Payments++;
                            _dictionary[monthId] = fee;
                        }

                    }

                  

                }

                int totalFeeReturn = 0;
                foreach (KeyValuePair<int, Fee> keyValuePair in _dictionary)
                {
                    totalFeeReturn += keyValuePair.Value.CalcFeeReturn();
                }

                

                return _total - (12*5) + totalFeeReturn;
            }

            private int GetMonthId(string sdate)
            {
                string smonth = sdate.Split(new[] { '−' })[1];
               return Int32.Parse(smonth);
            }

            class Fee
            {
                public int Total { get; set; }

                public int Payments { get;  set; }
                public Fee()
                {
                }

                public int CalcFeeReturn()
                {
                    if (Payments >= 3 && Total <= -100)
                    {
                        return 5;
                    }

                    return 0;
                }

            }
        }
    }
}
