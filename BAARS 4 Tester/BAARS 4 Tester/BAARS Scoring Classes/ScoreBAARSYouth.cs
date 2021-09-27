using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAARS_4_Tester
{
    public class ScoreBAARSYouth : ScoreBAARS
    {
        private int total1, symptom1, total2, symptom2;

        private int sumTotals, sumSymptoms;

        public ScoreBAARSYouth(int[] answers) : base(answers)
        {
            total1 = totalScore(0, 9);
            symptom1 = symptomCount(0, 9);
            total2 = totalScore(9, 18);
            symptom2 = symptomCount(9, 18);

            sumTotals = total1 + total2;
            sumSymptoms = symptom2 + symptom1;
        }

        public int getValue(string which)
        {
            switch (which)
            {
                case "total1": return total1;
                case "total2": return total2;
                case "symptom1": return symptom1;
                case "symptom2": return symptom2;
                case "sumTotal": return sumTotals;
                case "sumSymptoms": return sumSymptoms;
                default: return -999;
            }
        }
    }
}
