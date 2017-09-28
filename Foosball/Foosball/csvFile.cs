using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    class csvFile
    {

        public void write(string x, string y)
        {
            var csv = new StringBuilder();
            //CSV
            var first = x;
            var second = y;
            //Suggestion made by KyleMit
            var newLine = string.Format("{0},{1}", first, second);
            csv.AppendLine(newLine);
        }
    }
}
