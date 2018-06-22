using System;

namespace Cool_Game_Server
{
    public class Client : ISecurityIdentifier, IClient
    {
        public Guid GUID { get; set; }
        public string PublicKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Session Session { get; }

        public Client()
        {
            this.Session = new Session();


        }

        public override string ToString()
        {
            return $"{nameof(GUID)}: {GUID}, {nameof(PublicKey)}: {PublicKey}, {nameof(Username)}: {Username}, {nameof(Password)}: {Password}, {nameof(Session)}: {Session.State}";
        }
    }
}
