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
        public List<Card> Hand { get; set; }

        public Player()
        {
            //プレイヤーは最大5枚のカードを持る
            Hand = new List<Card>(5);
            
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

        //合計の表示
        public void ShowTotal()
        {
            Console.WriteLine($"あなたの現在の得点は{this.GetTotal()}です。");
        }

        //プレイヤーのカードを表示
        public void ShowPlayerCards()
        {
            foreach (var card in this.Hand)
            {
                card.PrintCard();
            }
        }

        //ディーラーのカードを表示
        public void ShowDealerCards() 
        {
             Console.WriteLine($"ディーラーの引いたカードは{this.Hand[0].Suit}の{this.Hand[0].FaceName}です。");
             Console.WriteLine("ディーラーの2枚目のカードは分かりません");
        }

    }
}
