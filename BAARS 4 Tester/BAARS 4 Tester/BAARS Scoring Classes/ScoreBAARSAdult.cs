using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAARS_4_Tester
{
    public class ScoreBAARSAdult : ScoreBAARS
    {
        private int section1Total, section1Symptoms, section2Total, section2Symptoms, 
            section3Total, section3Symptoms, section4Total, section4Symptoms;

        private int sumTotal1thru3, sumSymptoms2and3, sumSymptoms1thru3;

        public ScoreBAARSAdult(int[] answers) : base(answers)
        {
            section1Total = totalScore(0, 9);
            section1Symptoms = symptomCount(0, 9);
            section2Total = totalScore(9, 14);
            section2Symptoms = symptomCount(0, 14);
            section3Total = totalScore(14, 18);
            section3Symptoms = symptomCount(14, 18);
            section4Total = totalScore(18, 27);
            section4Symptoms = symptomCount(18, 27);

            sumTotal1thru3 = section1Total + section2Total + section3Total;
            sumSymptoms2and3 = section2Symptoms + section3Symptoms;
            sumSymptoms1thru3 = section1Symptoms + section2Symptoms + section3Symptoms;
        }

        public int getSectiontotal(int which)
        {
            switch (which)
            {
                case 1:
                    return section1Total;
                case 2:
                    return section2Total;
                case 3:
                    return section3Total;
                case 4:
                    return section4Total;
                default:
                    return -999;
            }
        }

        public int getSymptomTotal(int which)
        {
            switch (which)
            {
                case 1:
                    return section1Symptoms;
                case 2:
                    return section2Symptoms;
                case 3:
                    return section3Symptoms;
                case 4:
                    return section4Symptoms;
                default:
                    return -999;
            }
        }

        public int getOther(string which)
        {
            switch (which)
            {
                case "total1thru3":
                    return sumTotal1thru3;
                case "symptom23":
                    return sumSymptoms2and3;
                case "symptom13":
                    return sumSymptoms1thru3;
                default:
                    return -999;
            }
        }
    }
}
