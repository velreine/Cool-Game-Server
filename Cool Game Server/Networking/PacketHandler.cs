using System;
using System.Collections.Generic;

namespace Cool_Game_Server
{
    //TODO: This class might be expensive to construct consider singleton,
    //OR provide is as a singleton through Dependency Injection.
    public class PacketHandler : IPacketHandler
    {
        private readonly Dictionary<PacketType, Action<IPacket>> _handlers = null;//new Dictionary<PacketType, Action<IPacket>>();
        private readonly IServer _server;

        public IPacketHandlerResult Handle(IPacket packet)
        {
            IPacketHandlerResult phr = new PacketHandlerResult();

            phr.Result = "Unknown";

            if (_handlers.ContainsKey(packet.Type))
            {
                //Does this work?
                _handlers?[packet.Type](packet);

                phr.Result = "Success";
            }
            else
            {
                phr.Result = "Fail, unknown packet type received?";

                //TODO: Logging?
                //Log("Fail, unknown packet type received, LOGLEVEL_WARNING);


            }
            
            return phr;


        }

        public PacketHandler(IServer server)
        {
            this._server = server;

            _handlers = new Dictionary<PacketType, Action<IPacket>>()
            {

                [PacketType.CMSG_LOGIN_AUTHENTICATION_DETAILS] = (IPacket p) =>
                {
                    
                },

                [PacketType.CMSG_LOGIN_REQUEST_PUBLIC_KEY] = (IPacket p) =>
                {
                    //Client has requested our public key, 

                    
                    if (!this._server.Initialized) return;

                    // TODO:
                    //Build a packet which holds the public key. 
                    // 
                    // 

                },

                [PacketType.SMSG_LOGIN_REQUEST_PUBLIC_KEY] = (IPacket p) =>
                {
                    /*We are the server, we can only 'receive' client messages!*/
                },

                [PacketType.CMSG_LOGIN_START_CONNECT] = (IPacket p) =>
                {
                    
                },

                [PacketType.SMSG_LOGIN_READY_TO_AUTHENTICATE] = (IPacket p) =>
                {
                    /*We are the server, we can only 'receive' client messages!*/
                }



            };









        }




    }
}
