namespace Cool_Game_Server
{
    //// TODO: Maybe just have a packet builder do this kind of stuff.
    //internal class CMSG_LOGIN_CONNECT : Packet
    //{
    //    public string ClientName
    //    { // TODO: Boundary checks?
    //        get { return Encoding.ASCII.GetString(this.RawData); }

    //    }


    //    // Construct the base:
    //    public CMSG_LOGIN_CONNECT(byte[] rawData) : base(rawData, Type.CMSG_LOGIN_CONNECT)
    //    {

    //    }

    //    public CMSG_LOGIN_CONNECT(string clientName) : base(null, Type.CMSG_LOGIN_CONNECT)
    //    {
    //        this.RawData = Encoding.ASCII.GetBytes(clientName);


    //    }



    //}

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
}
