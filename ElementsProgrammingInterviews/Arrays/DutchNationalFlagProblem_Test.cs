using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsProgrammingInterviews.Arrays
{
    [TestClass]
    public class DutchNationalFlagProblem_Test
    {
        [TestMethod]
        public void Main()
        {
            new DutchNationalFlagProblem()
                .Sort([1, 2, 3, 1, 2, 3, 1, 2, 3], 1);
        }
    }

    class DutchNationalFlagProblem 
    { 

      
        public void Sort(int[] numbers, int pivotIndex)
        {
            int smallIndex = -1;
            int highIndex = numbers.Length;
            int currentIndex = 0;
            int pivot = numbers[pivotIndex];
            int pivotCounter = 0;
           
            while (currentIndex < highIndex)
            {
                var current = numbers[currentIndex];

                if (current < pivot)
                {
                    smallIndex++;
                    numbers[smallIndex] = numbers[currentIndex];
                }
                else if (current == pivot)
                {
                    pivotCounter++;
                }
                else
                {
                    highIndex--;
                    int tmp = numbers[highIndex];
                    numbers[highIndex] = numbers[currentIndex];
                    numbers[currentIndex] = tmp;
                    continue;
                }

                currentIndex++;
            }

            while (pivotCounter > 0) 
            {
                smallIndex++;
                numbers[smallIndex] = pivot;
                pivotCounter--;
            }
        }
    
    
    }

}
