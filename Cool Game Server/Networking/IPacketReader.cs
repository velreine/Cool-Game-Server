using System;

namespace Cool_Game_Server
{
    public interface IPacketReader
    {
        //int Position { get; }

        byte ReadByte();
        int ReadInt();
        byte[] ReadBytes();

        byte ReadByte(int index);
        int ReadInt(int index);
        byte[] ReadBytes(int startIndex, int count);

        bool Peek(int amount);
    }


}
