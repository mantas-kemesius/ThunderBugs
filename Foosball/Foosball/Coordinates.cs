using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    class Coordinates //prepare this class for also and database 
    {
        private string x;
        private string y;

        public void writeToCsv(string x, string y)
        {
            var csv = new StringBuilder();
            //CSV
            var first = x;
            var second = y;
            //Suggestion made by KyleMit
            var newLine = string.Format("{0},{1}", first, second);
            csv.AppendLine(newLine);

            File.AppendAllText("C:/Users/Mantas/Desktop/Git/ThunderBugs/test.csv", csv.ToString());
        }

        public string getX()
        {
            return this.x;
        }

        public string getY()
        {
            return this.y;
        }
    }
}
