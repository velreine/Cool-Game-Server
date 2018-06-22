namespace Cool_Game_Server
{
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
}
