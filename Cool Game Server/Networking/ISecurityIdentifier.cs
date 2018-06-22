using System;

namespace Cool_Game_Server
{
    public interface ISecurityIdentifier
    {
        Guid GUID { get; set; }
        string PublicKey { get; set; }
    }
}
