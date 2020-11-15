using System;
using System.IO;
using System.Text;

namespace Decryption
{
    public class Decrypter
    {
        private char[] key;
        private char[] line;
        private char[] decryptedLine;
        private Alphabet.Alphabet alphabet;

        public Decrypter(string key)
        {
            alphabet = new Alphabet.Alphabet();
            this.key = key.ToCharArray();
        }

        public string start(string lineToDecrypt)
        {
            line = lineToDecrypt.ToCharArray();
            decrypt();
            return new string(decryptedLine);
        }

        private void decrypt()
        {
            char[] temp = new char[line.Length];
            int j = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (j < key.Length)
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

            decryptedLine = new char[line.Length];

            for (int i = 0; i < line.Length; i++)
            {
                if(alphabet.getIndex(line[i]) > alphabet.getIndex(temp[i]))
                    decryptedLine[i] = alphabet.getLetter(alphabet.getIndex(line[i]) - alphabet.getIndex(temp[i]));
                else
                    decryptedLine[i] = alphabet.getLetter(67 - Math.Abs(alphabet.getIndex(line[i]) - alphabet.getIndex(temp[i])));
            }
        }
    }
}
