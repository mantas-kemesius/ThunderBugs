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

        public string Introduction(Player<string> player)
        { 
            return $"Welcome {player[0]} and {player[1]}!\n";
        }
    }
}
