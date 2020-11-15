using Alphabet;
using System;
using System.IO;
using System.Text;

namespace Encryption
{
    public class Encrypter
    {
        private Alphabet.Alphabet alphabet;
        private char[] key;
        private char[] line;
        private char[] encryptedLine;

        public Encrypter(string key)
        {
            alphabet = new Alphabet.Alphabet();
            this.key = key.ToCharArray();
        }

        public string start(string lineToEncrypt)
        {
            line = lineToEncrypt.ToCharArray();
            encrypt();
            return new string(encryptedLine);
        }

        private void encrypt()
        {
            char[] temp = new char[line.Length];
            int j = 0;
            for(int i = 0; i < line.Length; i++)
            {
                if(j < key.Length)
                {
                    temp[i] = key[j];
                    j++;
                }
                else
                {
                    i--;
                    j = 0;
                }
            }

            encryptedLine = new char[line.Length];
            
            for (int i = 0; i < line.Length; i++)
            {
                encryptedLine[i] = alphabet.getLetter(alphabet.getIndex(temp[i]) + alphabet.getIndex(line[i]));
            }
        }
    }
}
