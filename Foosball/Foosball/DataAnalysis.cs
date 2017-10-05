using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    class DataAnalysis //prepare this class for also and database 
    {
        private string x;
        private string y;
        private string ofd;

        public void writeToCsv(string x, string y)
        {
            var csv = new StringBuilder();
            //CSV
            var first = x;
            var second = y;
            //Suggestion made by KyleMit
            var newLine = string.Format("{0},{1}", first, second);
            csv.AppendLine(newLine);

            File.AppendAllText(Ofd, csv.ToString());
        }

        public string X
        {
            get;
            set;
        }

        public string Y
        {
            get;
            set;
        }
        public string Ofd
        {
            get;
            set;
        }
    }
}
