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
        public List<Card> Hand;

        public Player()
        {
            //プレイヤーは最大5枚のカードを持る
            Hand = new List<Card>();
            
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

        //プレイヤーのカードを表示
        public void ShowCards()
        {
            string result = "";
            foreach (var card in Hand)
            {
                result += card.Suit + "の"  + card.FaceName + "、";
            }
            result = result.TrimEnd('、');
            Console.WriteLine(result);

        }

        //ディーラーのカードを表示
        public void ShowDealerCards() 
        {
             Console.WriteLine($"ディーラーのカード：{this.Hand[0].Suit}の{this.Hand[0].FaceName}");
             Console.WriteLine("ディーラーの2枚目は裏向きです");
        }
    }
}
