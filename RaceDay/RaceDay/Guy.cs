using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaceDay
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyLabel.Text = MyBet.GetDescription();
            MyRadioButton.Text = this.Name + " has " + Cash + " $";
        }
        public void ClearBet()
        {
            MyBet = new Bet() { Amount = 0, Dog = 0, Bettor = this };
            UpdateLabels();
        }
        public bool PlaceBet(int Amount, int Dog)
        {         
            if (Cash - Amount >= 0)
            {
                MyBet = new Bet() { Amount = Amount, Dog = Dog, Bettor = this };
                return true;
            }
            else
            {
                ClearBet();
                return false;
            }        
        }
        public void Collect(int Winner)
        {
            Cash+=MyBet.PayOut(Winner);
            UpdateLabels();
        }
    }
}
