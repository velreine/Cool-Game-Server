namespace Cool_Game_Server
{
    public interface IPacket
    {
        byte[] RawData { get; set; }
        int Length { get; set; }
        PacketType Type { get; set; }
        

    }


   
    public enum PacketType
    {

        NULL_PACKET,

        //Connect me to server at X.X.X.X
        CMSG_LOGIN_START_CONNECT,

        //OK. Here is my public key for you to encrypt data.
        SMSG_LOGIN_REQUEST_PUBLIC_KEY,

        //OK. Here is my public key for you to encrypt data.
        CMSG_LOGIN_REQUEST_PUBLIC_KEY,

        //I'm now ready to authenticate you, send me username and password.
        SMSG_LOGIN_READY_TO_AUTHENTICATE,

        //Here is my username & password.
        CMSG_LOGIN_AUTHENTICATION_DETAILS,

       

        


    }

    public enum PacketEncryptionLevel
    {
        NO_SECURITY,
        WEAK_ENCRYPTION,
        MEDIUM_ENCRYPTION,
        STRONG_ENCRYPTION,
        ULTRA_ENCRYPTION
    }



}
