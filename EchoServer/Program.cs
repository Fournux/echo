using System;
using System.Threading;
using NetMQ.Sockets;
using NetMQ;
using MessagePack;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // using (var server = new ResponseSocket())
            // {
            //     server.Bind("tcp://*:5555");
            //     while (true)
            //     {
                    
            //         var message = server.ReceiveFrameString();
            //         Console.WriteLine("Received {0}", message);
            //         // processing the request
            //         Thread.Sleep(100);

            //         var item = new PacketDefinition.Server.LoginPacket {Login = "gui", Password = "test"};
            //         byte[] bytes = MessagePackSerializer.Typeless.Serialize(item);
            //         Console.WriteLine("Sending ExampleClass serialized");
            //         server.SendFrame(bytes);
            //     }
            // }

            using (var ctx = new DatabaseContext())
            {

            }
        }
    }
}
