using System;
using System.Windows.Forms;

namespace Foosball
{
    public partial class frmNames : Form
    {
        private string team1;
        private string team2;

        public string Team1
        {
            get { return team1; }
            set { team1 = value; }
        }

        public string Team2
        {
            get { return team2; }
            set { team2 = value; }
        }

        public frmNames()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            team1 = textBox1.Text;
            team2 = textBox2.Text;
        }
    }
}