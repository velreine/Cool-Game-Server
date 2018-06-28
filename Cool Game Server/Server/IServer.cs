using System.Dynamic;

namespace Cool_Game_Server
{
    public interface IServer
    {
        void Initialize();
        bool Initialized { get; }
    }
}