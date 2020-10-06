using System;
using System.Buffers;
using MessagePack;

namespace EchoPacket 
{
    public abstract class Packet
    {
        private static MessagePackSerializerOptions lz4Options = MessagePackSerializerOptions
                                                                .Standard
                                                                .WithCompression(MessagePackCompression.Lz4BlockArray)
                                                                .WithSecurity(MessagePackSecurity.UntrustedData);

        public byte[] ToBytes()
        {
            return MessagePackSerializer.Typeless.Serialize(this, lz4Options);
        }

        public static Packet FromBytes(ReadOnlySequence<byte> buffer)
        {
            try
            {
                return MessagePackSerializer.Typeless.Deserialize(buffer, lz4Options) as Packet;
            }
            catch
            {
                return null;
            }
        }


    }

}