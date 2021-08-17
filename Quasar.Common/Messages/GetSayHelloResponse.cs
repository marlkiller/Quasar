using ProtoBuf;
using System;
using System.Collections.Generic;

namespace Quasar.Common.Messages
{
    [ProtoContract]
    public class GetSayHelloResponse : IMessage
    {
        [ProtoMember(1)]
        public List<Tuple<string, string>> msgs { get; set; }
    }
}
