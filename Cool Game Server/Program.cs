using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cool_Game_Server
{


    public interface ISecurityIdentifier
    {
        Guid GUID { get; set; }
        string PublicKey { get; set; }
    }

    public class Client : ISecurityIdentifier, IClient
    {
        public Guid GUID { get; set; }
        public string PublicKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Session Session { get; }

        public Client()
        {
            this.Session = new Session();


        }

        public override string ToString()
        {
            return $"{nameof(GUID)}: {GUID}, {nameof(PublicKey)}: {PublicKey}, {nameof(Username)}: {Username}, {nameof(Password)}: {Password}, {nameof(Session)}: {Session.State}";
        }
    }


    public interface IClient
    {
        string Username { get; set; }
        string Password { get; set; }

    }

    public interface IPacket
    {
        byte[] RawData { get; set; }
    }

    public class DataPacket : IPacket
    {
        public byte[] RawData { get; set; }
    }

    internal abstract class Packet : IPacket
    {
        public byte[] RawData { get; set; }
        public Type PacketType { get; set; }

        protected Packet(byte[] rawData, Type packetType)
        {
            RawData = rawData;
            PacketType = packetType;
        }

        public enum Type
        {
            CMSG_LOGIN_CONNECT,
            SMSG_LOGIN_REQUESTPROOF,
            CMSG_LOGIN_PROOF,
            SMSG_LOGIN_APPROVE,
        }
    }

    internal class CMSG_LOGIN_CONNECT : Packet
    {
        public string ClientName
        { // TODO: Boundary checks?
            get { return Encoding.ASCII.GetString(this.RawData); }

        }


        // Construct the base:
        public CMSG_LOGIN_CONNECT(byte[] rawData) : base(rawData, Type.CMSG_LOGIN_CONNECT)
        {

        }

        public CMSG_LOGIN_CONNECT(string clientName) : base(null, Type.CMSG_LOGIN_CONNECT)
        {
            this.RawData = Encoding.ASCII.GetBytes(clientName);


        }



    }

    public class Session
    {
        public SessionState State;

        public enum SessionState
        {
            Uninitialized,
            Initializing,
            Prooving,
            WaitingForApproval,
            Authorized
        }

        public Session()
        {
            this.State = SessionState.Uninitialized;
        }



    }


    public class PacketHandlerResult : IPacketHandlerResult
    {
        public string Result { get; set; }
    }

    public class PacketHandler : IPacketHandler
    {
        public IPacketHandlerResult Handle(IPacket packet)
        {
            IPacketHandlerResult phr = new PacketHandlerResult();

            /* epic handling logic here */

            phr.Result = "Success";

            return phr;


        }
    }


    public interface IPacketHandler
    {
        //void Handle(IRawPacket packet);
        IPacketHandlerResult Handle(IPacket packet);

    }

    public interface IPacketHandlerResult
    {
        string Result { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {


            //string name = "Nicky";


            CMSG_LOGIN_CONNECT cmsg = new CMSG_LOGIN_CONNECT("Nicky");

            Console.WriteLine($"Name of client is {cmsg.ClientName}");
            Console.WriteLine($"PacketType is: {cmsg.PacketType}");


            Client nicky = new Client
            {
                GUID = Guid.NewGuid(),
                PublicKey = "",
                Username = "Velreine",
                Password = "1234567"
            };

            Console.WriteLine(nicky);
            Console.WriteLine($"Current session state is: {nicky.Session.State}");

            
            nicky.Session.State = Session.SessionState.Initializing;

            Console.WriteLine($"Current session state is: {nicky.Session.State}");

            /* Simulate epic code */
            System.Threading.Thread.Sleep(399);
            nicky.Session.State = Session.SessionState.Prooving;
            Console.WriteLine($"Current session state is: {nicky.Session.State}");

            /* Simulate epic code */
            System.Threading.Thread.Sleep(299);
            nicky.Session.State = Session.SessionState.WaitingForApproval;
            Console.WriteLine($"Current session state is: {nicky.Session.State}");

            /* Simulate epic code */
            System.Threading.Thread.Sleep(177);
            nicky.Session.State = Session.SessionState.Authorized;
            Console.WriteLine($"Current session state is: {nicky.Session.State}");
        }
    }
}
