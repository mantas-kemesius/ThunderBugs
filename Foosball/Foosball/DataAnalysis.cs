using System.IO;
using System.Text;

namespace Foosball
{
    // TODO kimutis : what data does this class analyze?
    class DataAnalysis 
    {
        // TODO kimutis : what is this?
        private string _ofd;

        public void WriteToCsv(string x, string y)
        {
            var csv = new StringBuilder();
            var newLine = string.Format("{0},{1}", x, y);
            csv.AppendLine(newLine);
            // TODO kimutis : we do things with csv, and then write x and y to another thing?
            File.AppendAllText(Ofd, $"{x},{y}");
        }

        // TODO kimutis : what is this?
        public string Ofd
        {
            get => _ofd;
            set => _ofd = value;
        }
    }
}
