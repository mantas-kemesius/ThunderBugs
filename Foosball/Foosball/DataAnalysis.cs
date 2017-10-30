using System.IO;
using System.Text;

namespace Foosball
{
    class DataAnalysis 
    {
        private string _ofd;

        public void WriteToCsv(string x, string y)
        {
            var csv = new StringBuilder(); //greiciausiai pakaks stringo (nu man nelabai pakanka dabar dar. gal reik geriau paziuret)
            var newLine = string.Format("{0},{1}", x, y);
            csv.AppendLine(newLine);

            File.AppendAllText(Ofd, $"{x},{y}");
        }
        public string Ofd
        {
            get => _ofd;
            set => _ofd = value;
        }
    }
}
