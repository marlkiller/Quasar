using ProtoBuf;

namespace Quasar.Common.Messages
{
    [ProtoContract]
    public class GetSayHello : IMessage
    {
        [ProtoMember(1)]
        public string msg { get; set; }

    }
}
