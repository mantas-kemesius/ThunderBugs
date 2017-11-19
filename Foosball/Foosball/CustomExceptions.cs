using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foosball
{
    class EndOfVideoCaptureException : Exception
    {
        public EndOfVideoCaptureException() : base("End of video capture reached.")
        {
            this.HelpLink = "Restart the program to try again.";
        }

    }
}
