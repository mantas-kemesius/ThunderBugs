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

        // TODO kimutis : thats an auto property
        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }
    }

    // TODO kimutis : not used?
    public class HasEvent
    {
        public event EventHandler<GenericEventClass> SampleEvent;

        public void DemoEvent(string val)
        {
            SampleEvent?.Invoke(this, new GenericEventClass(val));
        }
    }
}
