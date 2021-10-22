using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace BAARS_4_Tester
{
    class Tester
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string path { get; set;  }

        public Tester(string path)
        {
            this.path = path;

            if (File.Exists(path + "\\testerInfo.txt"))
            {
                
                string[] testerInfo = File.ReadAllLines((path + "\\testerInfo.txt"));

                lastName = testerInfo[0].Substring(testerInfo[0].IndexOf(":") + 1);
                firstName = testerInfo[1].Substring(testerInfo[1].IndexOf(":") + 1);
                middleName = testerInfo[2].Substring(testerInfo[2].IndexOf(":") + 1);
                age = Int32.Parse(testerInfo[3].Substring(testerInfo[3].IndexOf(":") + 1));
                gender = testerInfo[4].Substring(testerInfo[4].IndexOf(":") + 1);
            }
        }
    }
}
