using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JetPac.GameEngine
{
    static class TrueRnd
    {
        private const int BuffSize=256;
        private static RNGCryptoServiceProvider Rng = new RNGCryptoServiceProvider();
        private static byte[] RandomBuff = new byte[BuffSize];
        private static int BuffIndex = 0;

        static TrueRnd()
        {
            NewChunk();
        }

        /// <summary>Получить случайное число от 0 до max включительно</summary>
        public static int Next(int max)
        {
            IndexInc();
            return  (int)Math.Round((RandomBuff[BuffIndex] / 256.0f) *max);
        }

        
        //получить новую порцию данных
        private static void NewChunk()
        {
            BuffIndex = 0;
            Rng.GetBytes(RandomBuff);
        }

        //Увеличить индекс
        private static void IndexInc()
        {
            BuffIndex++;
            if(BuffIndex >= BuffSize)
            {
                NewChunk();
            }
        }

    }
}
