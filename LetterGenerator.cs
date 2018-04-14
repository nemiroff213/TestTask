using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvendApp
{
    class LetterGenerator : IGenerator
    {
        Random rand = new Random();
        string[] randstring = new string[3];
        int[] illuminateindex = new int[0];
        public int[] GetIlluminateIndex
        {
            get { return illuminateindex; }
        }
        public string[] GetRandom
        {
            get { return randstring; }
        }
        public void StartRandom()
        {
            illuminateindex = new int[0];
            for (int i = 0; i < randstring.Length; i++)
            {
                randstring[i] = Convert.ToString((char)rand.Next('a', 'z' + 1)) + Convert.ToString((char)rand.Next('a', 'z' + 1)) + Convert.ToString((char)rand.Next('a', 'z' + 1));
            }
            int count = 0;
            for (int i = 0; i < randstring.Length; i++)
            {

                if (randstring[i][0].Equals(randstring[i][1]) || randstring[i][0].Equals(randstring[i][2]) || randstring[i][1].Equals(randstring[i][2]))
                {
                    Array.Resize(ref illuminateindex, illuminateindex.Length + 1);
                    illuminateindex[count] = i;
                    count++;
                }
            }
        }
    }
}