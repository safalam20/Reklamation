using System;
using Reklamation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reklamation.Data
{
    public delegate void NewMessageDelegate(object sender, NewMessageChangeEventArgs args);

    public class NewMessageChangeEventArgs : EventArgs
    {
        public KTrkl_Message NewMessage { get; }
        public KTrkl_Message OldMessage { get; }

        public NewMessageChangeEventArgs(KTrkl_Message newNewMessage, KTrkl_Message oldNewMessage)
        {
            this.NewMessage = newNewMessage;
            this.OldMessage = oldNewMessage;
        }
    }

    public interface INewMessageService
    {
        public event NewMessageDelegate OnNewMessageChanged;
       
    }
}
