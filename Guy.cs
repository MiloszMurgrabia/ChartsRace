using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wyscig
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " ma " + Cash + " zł";
            MyLabel.Text = MyBet.GetDescription();
        }


        public void ClearBet()
        {
            PlaceBet(0, 0);
        }
        public bool PlaceBet(int Amount, int DogToWin)
        {
            
            if (Amount <= Cash)
            {
                MyBet = new Bet();
                MyBet.Amount = Amount;
                MyBet.Dog = DogToWin-1;
                MyBet.Bettor = this;
                UpdateLabels();
                return true;
            }
            else
            {
                return false;
            }
            
            
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
           
        }
    }
}
