namespace Foosball
{
    class EventClass
    {
        public delegate void MyDelegate(string message);
        public event MyDelegate MyEvent;

        public void RaiseEvent(string message)
        {
            if (MyEvent != null)
                MyEvent(message);
        }
    }
}
