using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cool_Game_Server;

namespace Cool_Game_Server
{


    class Program
    {
        static void Main(string[] args)
        {


            //string name = "Nicky";


            //CMSG_LOGIN_CONNECT cmsg = new CMSG_LOGIN_CONNECT("Nicky");

            //Console.WriteLine($"Name of client is {cmsg.ClientName}");
            //Console.WriteLine($"PacketType is: {cmsg.PacketType}");


            //Client nicky = new Client
            //{
            //    GUID = Guid.NewGuid(),
            //    PublicKey = "",
            //    Username = "Velreine",
            //    Password = "1234567"
            //};

            //Console.WriteLine(nicky);
            //Console.WriteLine($"Current session state is: {nicky.Session.State}");


            //nicky.Session.State = Session.SessionState.Initializing;

            //Console.WriteLine($"Current session state is: {nicky.Session.State}");

            ///* Simulate epic code */
            //System.Threading.Thread.Sleep(399);
            //nicky.Session.State = Session.SessionState.Prooving;
            //Console.WriteLine($"Current session state is: {nicky.Session.State}");

            ///* Simulate epic code */
            //System.Threading.Thread.Sleep(299);
            //nicky.Session.State = Session.SessionState.WaitingForApproval;
            //Console.WriteLine($"Current session state is: {nicky.Session.State}");

            ///* Simulate epic code */
            //System.Threading.Thread.Sleep(177);
            //nicky.Session.State = Session.SessionState.Authorized;
            //Console.WriteLine($"Current session state is: {nicky.Session.State}");


            var packet = new Packet(12, Packet.Type.CMSG_LOGIN_CONNECT);


            int x = int.MaxValue;

            byte[] ba = BitConverter.GetBytes(x);
            byte[] ba2 = BitConverter.GetBytes(x);
            byte[] ba3 = BitConverter.GetBytes(x);
            

            packet.RawData = new[]
            {
                ba[0],ba[1],ba[2],ba[3],
                ba2[0], ba2[1], ba2[2], ba2[3],
                ba3[0],ba3[1],ba3[2],ba3[3]
            };
            // Should be int.MaxValue:



            PacketReader pr = new PacketReader(packet);

            Console.WriteLine($"pr.ReadInt: {pr.ReadInt()}");
            Console.WriteLine($"int.MaxValue: {int.MaxValue}");

            while (pr.Peek(1))
            {
                Console.WriteLine($"I read this: {pr.ReadByte()}");
            }

            if (pr.Peek(sizeof(int)))
            {
                Console.WriteLine($"I read this: {pr.ReadInt()}");
            }


            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();

        }
    }
}
