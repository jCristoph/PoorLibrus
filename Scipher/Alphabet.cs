using System;

namespace Alphabet
{
    public class Alphabet
    { 
        //private static int charsNumber = 27;    
        private static int charsNumber = 67;
        private readonly char[] alphabet;

        public Alphabet()
        {
            //alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_".ToCharArray();
            alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_0123456789., -".ToCharArray();
        }
        public char getLetter(int index)
        {
            index %= charsNumber;
            return alphabet[index];
        }
        public int getIndex(char letter)
        {
            for(int i = 0; i < charsNumber; i++)
            {
                if (alphabet[i] == letter)
                    return i;
            }
            return -1;
        }
    }
}
