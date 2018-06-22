namespace Cool_Game_Server
{
    public interface IPacket
    {
        byte[] RawData { get; set; }
        int Length { get; set; }


    }
}
