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

        public PacketType Type { get; set; }

        

        public Packet() : this(0, PacketType.NULL_PACKET)
        {

        }

        public void Test()
        {

        }

        public Packet(int length, PacketType type)
        {
            this.RawData = new byte[length];
            this.Type = type;


        }

        protected Packet(byte[] rawData, PacketType packetType)
        {
            this.RawData = rawData;
            this.Type = packetType;
        }

        
    }
}
