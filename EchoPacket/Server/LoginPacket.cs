using MessagePack;

namespace EchoPacket.Server 
{
    [MessagePackObject]
    public class LoginPacket : Packet
    {
        [Key(0)]
        public string Login { get; set; }

        [Key(1)]
        public string Password { get; set; }

    }

}