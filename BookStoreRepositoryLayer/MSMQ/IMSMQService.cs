using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.MSMQ
{
    public interface IMSMQService
    {
        void AddToQueue(string email);
        void ReceiveFromQueue(object sender, ReceiveCompletedEventArgs e);
    }
}
