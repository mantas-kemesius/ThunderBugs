using System.IO;
using System.Text;

namespace Foosball
{
    class DataAnalysis 
    {
        private string _x;
        private string _y;
        private string _ofd;

        public void writeToCsv(string x, string y)
        {
            var csv = new StringBuilder();
            var first = x;
            var second = y;
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
            get => _ofd;
            set => _ofd = value;
        }
    }
}
