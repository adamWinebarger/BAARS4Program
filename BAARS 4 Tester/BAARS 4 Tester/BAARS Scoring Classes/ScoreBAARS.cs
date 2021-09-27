using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAARS_4_Tester
{
    public class ScoreBAARS
    {
        protected int[] answers;

        public ScoreBAARS(int[] answers)
        {
            this.answers = answers;
        }

        protected int totalScore(int start, int end)
        {
            int total = 0;

            for (int i = start; i < end; i++)
            {
                total += answers[i];
            }

            return total;
        }

        //Remember Symptoms count only increments if the value of a symptom is 3 or 4
        protected int symptomCount(int start, int end)
        {
            int count = 0;

            for (int i = start; i < end; i++)
            {
                if (answers[i] >= 3)
                {
                    count++;
                }
            }

            return count;
        }

    }
}
