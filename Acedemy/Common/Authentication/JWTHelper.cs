using Jose;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Authentication
{
    public static class JWTHelper
    {
        private static byte[] GetByteSecret(string secret)
        {
            return Encoding.ASCII.GetBytes(secret);
        }

        public static string CreateSignedToken(Dictionary<string,object> payload, string secretKey)
        {
            var secretBytes = GetByteSecret(secretKey);

            return JWT.Encode(payload, secretBytes, JwsAlgorithm.ES512);
        }

        public static string DecodeSignedToken(string signedToken, string secretKey)
        {
            var secretBytes = GetByteSecret(secretKey);

            return JWT.Decode(signedToken, secretBytes);
        }
    }
}
