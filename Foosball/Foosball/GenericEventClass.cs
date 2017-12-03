using System;

namespace Foosball
{
    public class GenericEventClass : EventArgs
    {
        private string msg;

        public GenericEventClass(string messageData)
        {
            msg = messageData;
        }
        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }
    }
     
    public class HasEvent
    {
        public event EventHandler<GenericEventClass> SampleEvent;

        public void DemoEvent(string val)
        {
            SampleEvent?.Invoke(this, new GenericEventClass(val));
        }
    }
}
