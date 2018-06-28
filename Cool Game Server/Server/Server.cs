using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cool_Game_Server.Security;
using Cool_Game_Server.Logging;

namespace Cool_Game_Server
{
    class Server : IServer
    {
        private static CryptoKeys _cryptoKeys = null;
        private readonly ILogger _logger = null;
        private readonly IPacketHandler _packetHandler = null;
        public bool Initialized { get; private set; } = false;

        public void Initialize()
        {
            
            _logger?.Log("Initialization of server begun...", LOG_SEVERITY.INFO);



            _logger?.Log("Generating cryptographic keys for later use", LOG_SEVERITY.INFO);
            var crypto = new Cryptography();
            _cryptoKeys = crypto.GenerateKeys();
            _logger?.Log("Keys generated!", LOG_SEVERITY.INFO);


            _logger?.Log("Spawning listening thread to listen for clients...", LOG_SEVERITY.INFO);
            //TODO: Spawn listening thread...
            _logger?.Log("Initialization done, now ready to serve clients!", LOG_SEVERITY.INFO);




            Initialized = true;
        }

        

        public Server(ILogger logger, IPacketHandler packetHandler)
        {
            this._logger = logger;
            this._packetHandler = packetHandler;
        }

    }
}
