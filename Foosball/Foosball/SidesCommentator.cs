namespace Foosball
{
    class SidesCommentator
    {
        private string _comment;

        public SidesCommentator()
        {

        }

        public string commentsSide(int x)
        {

            if (x >= 289)
            {
                _comment = "Ball is in the blue team area";
            }
            else
            {
                _comment = "Ball is in the red team area";
            }
            return _comment;
        }

        public string Comment
        {
            get => _comment;
        }
    }
}