using ProtoBuf;
using System;
using System.Collections.Generic;

namespace Quasar.Common.Messages
{
    // ProtoContract|ProtoMember 这些注解序列化会用到
    [ProtoContract]
    public class GetSayHelloResponse : IMessage
    {
        [ProtoMember(1)]
        public List<string> msgs { get; set; }
    }
}
