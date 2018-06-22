namespace Cool_Game_Server
{
    public interface IPacketHandler
    {
        //void Handle(IRawPacket packet);
        IPacketHandlerResult Handle(IPacket packet);

    }
}
