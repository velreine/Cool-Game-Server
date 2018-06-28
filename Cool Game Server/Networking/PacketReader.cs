using System;

namespace Cool_Game_Server
{
    public class PacketReader : IPacketReader
    {
        private int Position { get; set; }
        private Packet _packet = null;


        /// <summary>
        /// Constructs a PacketReader without a reference to a packet,
        /// The PacketReader will still be initialized.
        /// </summary>
        public PacketReader()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the reader, by setting up default values.
        /// </summary>
        private void Initialize()
        {
            this.Position = 0;
        }

        /// <summary>
        /// Resets the readers position.
        /// </summary>
        public void Reset()
        {
            this.Position = 0;
        }

        /// <summary>
        /// Constructs a new Packet reader, which will hold a reference to the given Packet.
        /// </summary>
        /// <param name="packet">The packet to perform reading on</param>
        public PacketReader(Packet packet)
        {
            Initialize();
            this._packet = packet;
        }

        /// <summary>
        /// Sets the readers reference to a specified Packet.
        /// </summary>
        /// <param name="packet"></param>
        public void SetPacket(Packet packet)
        {
            this._packet = packet;
        }


        /// <summary>
        /// Returns the next byte of the Packet.
        /// NB: Advances reader position by 1 sizeof(byte).
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual byte ReadByte()
        {
            byte result = _packet.RawData[Position];
            Position++;
            return result;
        }

        /// <summary>
        /// Returns the next Int32 from the Packet.
        /// NB: Advances reader position by 4 sizeof(int).
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual int ReadInt()
        {
            int result = BitConverter.ToInt32(_packet.RawData, Position);
            Position += 4;
            return result;


        }

        /// <summary>
        /// Returns a packets raw data as a byte array..
        /// NB: Does not advance reader position.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual byte[] ReadBytes()
        {
            //Useless implementation?
            return _packet.RawData;
        }

        /// <summary>
        /// Returns a byte from the given index of a Packet.
        /// NB: Does not advance reader position.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual byte ReadByte(int index)
        {
            if (index <= _packet.Length - 1) return _packet.RawData[index];
            throw new ArgumentOutOfRangeException(nameof(index), "Attempted to read from ByteArray with invalid Index");


        }

        /// <summary>
        /// Returns a Int32 from the given index of a Packet.
        /// NB: Does not advance reader position.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual int ReadInt(int index)
        {
            return BitConverter.ToInt32(_packet.RawData, index);
        }

        /// <summary>
        /// Reads a specified amount of bytes, starting at index.
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public virtual byte[] ReadBytes(int startIndex, int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Peaks X amount of bytes ahead,
        /// will return true if reader can read X amounts ahead.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Peek(int amount)
        {
            // Check to see we're not going out of bounds.
            return ((Position + amount - 1) <= (_packet.Length - 1));
            //return false;
        }



    }

    // Obsolute/Not used.

    //public class ReadResult<T>
    //{
    //    public bool Success = false;
    //    public T Value { get; set; }

    //    public ReadResult()
    //    {

    //    }

    //    public ReadResult(T value)
    //    {
    //        this.Value = value;
    //    }
    //}

}
