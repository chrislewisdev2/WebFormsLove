using System;

namespace WebFormsLove.Core.Messages
{
    public class SimpleMessage<TContent> where TContent : class
    {
        public TContent Item { get; set; }

        public SimpleMessage(TContent item)
        {
            if (item == null) throw new ArgumentNullException("item");
            Item = item;
        }
    }
}
