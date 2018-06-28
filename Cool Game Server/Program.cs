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
using Cool_Game_Server.Security;

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


            //var packet = new Packet(12, Packet.Type.CMSG_LOGIN_CONNECT);


            //int x = int.MaxValue;

            //byte[] ba = BitConverter.GetBytes(x);
            //byte[] ba2 = BitConverter.GetBytes(x);
            //byte[] ba3 = BitConverter.GetBytes(x);


            //packet.RawData = new[]
            //{
            //    ba[0],ba[1],ba[2],ba[3],
            //    ba2[0], ba2[1], ba2[2], ba2[3],
            //    ba3[0],ba3[1],ba3[2],ba3[3]
            //};
            //// Should be int.MaxValue:



            //PacketReader pr = new PacketReader(packet);

            //Console.WriteLine($"pr.ReadInt: {pr.ReadInt()}");
            //Console.WriteLine($"int.MaxValue: {int.MaxValue}");

            //while (pr.Peek(1))
            //{
            //    Console.WriteLine($"I read this: {pr.ReadByte()}");
            //}

            //if (pr.Peek(sizeof(int)))
            //{
            //    Console.WriteLine($"I read this: {pr.ReadInt()}");
            //}


            //Console.ReadLine();
            //Console.ReadLine();
            //Console.ReadLine();
            //Console.ReadLine();


            //HashVerifier hv = new HashVerifier();
            //HashVerifier hv2 = new HashVerifier(new MD5CryptoServiceProvider(), new SHA256CryptoServiceProvider());

            //byte[] a = new[] { (byte)255, (byte)255, (byte)255 };
            //byte[] b = new[] { (byte)255, (byte)255, (byte)255 };
            //byte[] c = new[] { (byte)255, (byte)255, (byte)254 };

            ////Reference equality.
            //if (a == b) Console.WriteLine("TRUE");
            //Console.WriteLine();


            //Random rnd = new Random(DateTime.Now.Millisecond);


            //byte[] hashme = new[]
            //{
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next()

            //    ,(byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(),
            //    (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next(), (byte) rnd.Next()

            //    ,(byte) rnd.Next()
            //    ,(byte) rnd.Next()
            //    ,(byte) rnd.Next()
            //    ,(byte) rnd.Next()
            //    ,(byte) rnd.Next()
            //    ,(byte) rnd.Next()
            //    ,(byte) rnd.Next()
            //    ,(byte) rnd.Next()
            //    ,(byte) rnd.Next()
            //    ,(byte) rnd.Next()


            //};

            //MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();


            //Console.WriteLine(Encoding.ASCII.GetString(md5.ComputeHash(hashme)));
            //Console.WriteLine($"Length is {md5.ComputeHash(hashme).Length}");

            //Console.WriteLine(Encoding.ASCII.GetString(sha256.ComputeHash(hashme)));
            //Console.WriteLine($"Length is {sha256.ComputeHash(hashme).Length}");




            var crypto = new Cryptography();
            var keys = crypto.GenerateKeys();



            int m = 25;




            // Need a client to connect to:
            //IP: 192.168.10.13
            //User: nicky
            //Password: 1q2w3e4r5t
            TcpClient tcp = new TcpClient("192.168.10.13", 1337);
            NetworkStream ns = tcp.GetStream();

            Random rnd = new Random();


            // Inspect in WireShark:

            for (int i = 0; i < 100; i++)
            {
                                        //1500 > should be a Jumbo frame....
                                        //1460 is TCP max for 1 packet.
                byte[] buffer = new byte[1600];//Encoding.ASCII.GetBytes(rnd.Next().ToString());
                ns.Write(buffer, 0, buffer.Length);

                int x = 25;
            }

            //kahoot...




            string hi = "hey";
            Console.WriteLine("hi");







        }
    }
}
