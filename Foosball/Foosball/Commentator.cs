namespace Foosball
{
    class Player <T>
    {
        private T[] arr = new T[2];

        public T this[int i]
        {
            get => arr[i];
            set => arr[i] = value;
        }
    }
   
    class Commentator
    {
        private string _comment;

        public Commentator()
        {
           
        }

        public string introduction(Player<string> player)
        { 
            _comment = $"Welcome {player[0]} and {player[1]}!\n";

            return _comment;
        }
    }
}
