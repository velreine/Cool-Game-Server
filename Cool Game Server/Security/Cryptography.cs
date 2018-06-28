using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cool_Game_Server.Security
{
    class Cryptography
    {
        private readonly RSACryptoServiceProvider _rsa = null;


        public CryptoKeys GenerateKeys()
        {
            var c = new CryptoKeys
            {
                Private = _rsa?.ToXmlString(true),
                Public = _rsa?.ToXmlString(false)
            };


            return c;

        }

        public Cryptography(int dwKeySize) : this(new RSACryptoServiceProvider(dwKeySize))
        {
            
        }

        public Cryptography() : this(new RSACryptoServiceProvider(512))
        {

        }

        private Cryptography(RSACryptoServiceProvider rsa)
        {
            _rsa = rsa;
        }


    }

    sealed class CryptoKeys
    {
        public string Private = "";
        public string Public = "";


    }



}
