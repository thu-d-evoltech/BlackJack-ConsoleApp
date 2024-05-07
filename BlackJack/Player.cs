using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player
    {
        public string player {  get; set; }
        public List<Card> Hand { get; set; }

        public bool Turn { get; set; } = true;

        public Player()
        {
            //プレイヤーは最大5枚のカードを持る
            Hand = new List<Card>(5);
            ShowDealerCards();
            ShowPlayerCards();
        }

        //プレイヤーの持っているカードの合計
        public int GetTotal()
        {
            int total = 0;
            foreach (Card card in Hand)
            {
                total += card.FaceValue;
            }
            return total;
        }

        //現在のカードの合計
        public void ShowTotal()
        {
            Console.WriteLine($"あなたの現在の得点は{this.GetTotal()}です。");
        }

        public void ShowPlayerCards ()
        {
            foreach (var card in Hand)
            {
                card.PrintCard();
            }
            ShowTotal();
        }

        public void ShowDealerCards() 
        {
             Console.WriteLine($"ディーラーの引いたカードは{this.Hand[0].Suit}の{this.Hand[0].FaceName}です。");
             Console.WriteLine("ディーラーの2枚目のカードは分かりません");
        }

    }
}
