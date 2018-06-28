using System;
using System.CodeDom;
using System.Linq;
using System.Security.Cryptography;

namespace Cool_Game_Server.Security
{
    class HashVerifier : IHashVerifier
    {
        private readonly MD5CryptoServiceProvider _md5;
        private readonly SHA256CryptoServiceProvider _sha256;

        public HashVerifier() : this(new MD5CryptoServiceProvider(), new SHA256CryptoServiceProvider())
        {

        }

        public HashVerifier(MD5CryptoServiceProvider md5, SHA256CryptoServiceProvider sha256)
        {
            _md5 = md5;
            _sha256 = sha256;
        }



        public bool VerifyMD5(byte[] message, byte[] hash)
        {

            //Calculate hash of input:
            var hashInput = _md5.ComputeHash(message);


            //Equals method will compare byte-array value wise:
            return Equals(hashInput, hash);




        }

        public bool VerifySHA256(byte[] message, byte[] hash)
        {
            //Calculate hash of input:
            var hashInput = _sha256.ComputeHash(message);

            //Equals method will compare byte-array value wise:
            return Equals(hashInput, hash);


        }

        public bool Equals(byte[] hash1, byte[] hash2)
        {

            if (ReferenceEquals(hash1, hash2)) return true;

            //for (int i = 0; i < hash1.Length; i++)
            //{

            //    if (hash1[i] != hash2[i]) return false;


            //}

            //return true;

            return !hash1.Where((t, i) => t != hash2[i]).Any();
        }
    }
}