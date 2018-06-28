using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool_Game_Server.Security
{
    interface IHashVerifier
    {
        // RAW Byte:
        bool VerifyMD5(byte[] message, byte[] hash);
        bool VerifySHA256(byte[] message, byte[] hash);
        bool Equals(byte[] hash1, byte[] hash2);
    }
}
