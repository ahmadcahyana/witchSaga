using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace witchSaga.Models
{
    public class Witch
    {
        public int Year { get; set; }

        public Witch ()
        {

        }

        public int Kill()
        {
            int kill = 1;
            for (int i = 0; i < Year; i++)
            {
                kill += i;
            }
            return kill;
        }
    }
}
