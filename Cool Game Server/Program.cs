using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    }

    public interface IClient
    {
        string Username { get; set; }
        string Password { get; set; }

    }

    public interface IRawPacket
    {
        byte[] RawData { get; set; }
    }

    public class RawDataPacket : IRawPacket
    {
        public byte[] RawData { get; set; }
    }

    internal abstract class Packet : IRawPacket
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

    public class SessionState
    {
        public State Session_State;


        public enum State
        {
            Uninitialized,
            Initializing,
            Prooving,
            WaitingForApproval,
            Authorized
        }


    }


    public interface IPacketHandler
    {
        //void Handle(IRawPacket packet);
        IPacketHandlerResult Handle(IRawPacket packet);

    }

    public interface IPacketHandlerResult
    {

    }


    class Program
    {
        static void Main(string[] args)
        {


            //string name = "Nicky";


            CMSG_LOGIN_CONNECT cmsg = new CMSG_LOGIN_CONNECT("Nicky");

            Console.WriteLine($"Name of client is {cmsg.ClientName}");
            Console.WriteLine($"PacketType is: {cmsg.PacketType}");
            




        }
    }
}
