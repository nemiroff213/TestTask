using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvendApp
{
    class NumberGenerator : IGenerator
    {
        Random rand = new Random();
        int[] randint = new int[3];
        int illuminateindex;
        public int[] GetRandom
        {
            get { return randint; }
        }
        public int GetIlluminateIndex
        {
            get { return illuminateindex; }
        }
        public void StartRandom()
        {
            int count = 0;
            while (count < randint.Length)
            {
                int a = rand.Next(255);
                if (!randint.Contains(a))
                {
                    randint[count] = a;
                    count++;
                }
            }
            int temporary = 0;
            for (int i = 0; i < randint.Length; i++)
            {
                temporary = randint[i] > temporary ? randint[i] : temporary;
            }
            illuminateindex = Array.IndexOf(randint, temporary);
        }
    }
}