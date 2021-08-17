using Quasar.Common.Messages;
using Quasar.Common.Networking;
using Quasar.Server.Networking;
using System;
using System.Collections.Generic;

namespace Quasar.Server.Messages
{

    public class SayHelloHandler : MessageProcessorBase<List<string>>
    {
    
        private readonly Client _client;

 
        public SayHelloHandler(Client client) : base(true)
        {
            _client = client;
        }

        public override bool CanExecute(IMessage message) => message is GetSayHelloResponse;

        public override bool CanExecuteFrom(ISender client) => _client.Equals(client);

        public override void Execute(ISender sender, IMessage message)
        {
            switch (message)
            {
                case GetSayHelloResponse info:
                    Execute(sender, info);
                    break;
            }
        }

        public void RefreshSystemInformation(string inputMsg)
        {
            if (string.IsNullOrEmpty(inputMsg))
            {
                inputMsg = "msg == null";
            }
            GetSayHello sayHello = new GetSayHello();
            sayHello.msg = inputMsg;
            _client.Send(sayHello);
        }

        private void Execute(ISender client, GetSayHelloResponse message)
        {
            OnReport(message.msgs);
        }
    }
}
