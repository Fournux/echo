using MessagePack;

namespace EchoPacket.Client 
{
    [MessagePackObject]
    public class LoginPacket : Packet
    {
        [Key(0)]
        public int ResultCode { get; set; }

    }

}