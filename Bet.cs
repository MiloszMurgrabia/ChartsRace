using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyscig
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Amount == 0)
            {
                return Bettor.Name + " nie zawarł zakładu";
            }
            else
            {
                return Bettor.Name + " postawił " + Amount + " zł na psa numer " + Dog;
            }
        }

        public int PayOut(int Winner)
        {
            if (Dog == Winner)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }
    }
}
