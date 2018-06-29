using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Cool_Game_Server.Networking
{
    class PacketBuilder
    {
        //Contains a mapping of required security levels for different packets.
        private static Dictionary<PacketType, PacketEncryptionLevel> _secLevels;
        private byte[] _data = null;
        private int _packetLength = 0;
        private int _builderPosition = 0; //TODO: TypeID should always be first 2 bytes, need some location checking.
        private PacketType _packetType;

        //TODO: Implement auto expand.
        public bool AutoExpand { get; set; } = false;
        public PacketType Type
        {
            get => _packetType;
            set => SetType(value);
        }

        public int PacketLength
        {
            get => _packetLength;
            set => SetPacketLength(value);
        }


        private void SetType(PacketType type)
        {
            // Cast the type to a 2bytes signed integer:
            var typeID = (short)type;

            var bytes = BitConverter.GetBytes(typeID);

            AppendData(bytes);

        }

        private void AppendData(byte[] more)
        {

            for (var i = 0; i < more.Length; i++)
            {

                if (_builderPosition >= _data.Length && !AutoExpand)
                {
                    throw new ArgumentOutOfRangeException(nameof(more),
                        "Tried to overfill packet beyond its capacity.");
                    return;
                }

                if (_builderPosition >= _data.Length && AutoExpand)
                {
                    //TODO: IMPLEMENT AUTOEXPANDING::
                }

                _data[_builderPosition] = more[i];



                _builderPosition++;
            }
        }

        #region add_overloads
        public void Add(string input)
        {

            AppendData(Encoding.ASCII.GetBytes(input));



        }

        public void Add(int input)
        {

            AppendData(BitConverter.GetBytes(input));


        }

        public void Add(char input)
        {

            AppendData(BitConverter.GetBytes(input));

        }
        #endregion

        private void SetPacketLength(int length)
        {

            // No need to allocate new byte-array if it's not larger than the current one.
            if (_data != null && _data.Length < length)
            {
                _data = new byte[length];
                _packetLength = length;
                return;
            }

            //If length is less than what is already allocated just tell API users the length is smaller.
            _packetLength = length;
        }

        public void HardClearData()
        {

            for (var i = 0; i < _data.Length; i++)
            {
                _data[i] = 0;
            }


        }

        public PacketBuilder() : this(256)
        {
            Initialize();


        }

        public PacketBuilder(int packetSize)
        {
            Initialize();

            this._data = new byte[packetSize];

        }

        public void Initialize()
        {
            if (_secLevels == null) InitializeDictionary();


        }

        private static void InitializeDictionary()
        {
            // This Dictionary will map a packet type to its necessary encryption-level needed.

            _secLevels = new Dictionary<PacketType, PacketEncryptionLevel>()
            {
                [PacketType.NULL_PACKET] = PacketEncryptionLevel.NO_SECURITY,
                [PacketType.CMSG_LOGIN_START_CONNECT] = PacketEncryptionLevel.NO_SECURITY,
                [PacketType.SMSG_LOGIN_REQUEST_PUBLIC_KEY] = PacketEncryptionLevel.NO_SECURITY,
                [PacketType.CMSG_LOGIN_REQUEST_PUBLIC_KEY] = PacketEncryptionLevel.NO_SECURITY,
                [PacketType.SMSG_LOGIN_READY_TO_AUTHENTICATE] = PacketEncryptionLevel.STRONG_ENCRYPTION,
                [PacketType.CMSG_LOGIN_AUTHENTICATION_DETAILS] = PacketEncryptionLevel.STRONG_ENCRYPTION,


            };



        }

        // Clears the builder of all packet-specific data,
        // So that the builder can be re-used.
        public void Clear()
        {
            this.Type = PacketType.NULL_PACKET;
            this._packetLength = 0;
            this._builderPosition = 0;

        }




    }
}

