using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player
    {
        public List<Card> Hand { get; set; }

        public bool Turn { get; set; } = true;

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
                Console.WriteLine($"あなたの現在の得点は{total}です。");
            }
            return total;

        }
    }
}
