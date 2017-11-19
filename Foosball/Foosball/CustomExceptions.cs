using System;

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
