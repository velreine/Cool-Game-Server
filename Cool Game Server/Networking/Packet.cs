using System;

namespace Cool_Game_Server
{
    public class Packet : IPacket
    {
        public byte[] RawData { get; set; }
    



        public int Length
        {
            get { return RawData.Length; }
            set
            {
                if (value > Length)
                {

                    byte[] oldRawData = new byte[Length];
                    Array.ConstrainedCopy(RawData, 0, oldRawData, 0, Length);
                    this.RawData = new byte[value];
                    Array.ConstrainedCopy(oldRawData, 0, this.RawData, 0, oldRawData.Length);

                }
            }
        }

        public Type PacketType { get; set; }

        public Packet() : this(0, Type.NULL_PACKET)
        {

        }

        public void Test()
        {

        }

        public Packet(int length, Packet.Type type)
        {
            this.RawData = new byte[length];
            this.PacketType = type;


        }

        protected Packet(byte[] rawData, Type packetType)
        {
            RawData = rawData;
            PacketType = packetType;
        }

        public enum Type
        {
            NULL_PACKET,
            CMSG_LOGIN_CONNECT,
            SMSG_LOGIN_REQUESTPROOF,
            CMSG_LOGIN_PROOF,
            SMSG_LOGIN_APPROVE,
        }
    }
}
