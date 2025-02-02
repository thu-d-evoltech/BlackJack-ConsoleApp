﻿
namespace BlackJack
{
    internal class Player
    {
        /// <summary>
        /// 持っているカードのリスト
        /// </summary>
        public List<Card> Hand;

        /// <summary>
        /// Playerクラスのコンストラクターを定義する
        /// </summary>
        public Player()
        {
            // 持っているカードのリストのインスタンス
            Hand = new List<Card>();
        }

        /// <summary>
        /// プレイヤーの持っているカードの合計を計算する
        /// </summary>
        public int GetHandTotal()
        {
            int total = 0;
            foreach (Card card in Hand)
            {
                total += card.FaceValue;
            }
            return total;
        }

        /// <summary>
        /// プレイヤーとディーラーの持っているカードを表示する
        /// </summary>
        public string ShowCards()
        {
            string result = "";
            foreach (var card in Hand)
            {
                result += card.Suit + "の"  + card.FaceName + "、";
            }
            result = result.TrimEnd('、');
            return result;
        }

        /// <summary>
        /// ディーラーのカードを表示する
        /// </summary>
        public void ShowDealerCards() 
        {
             Console.WriteLine($"ディーラーのカード：{this.Hand[0].Suit}の{this.Hand[0].FaceName}");
             Console.WriteLine("ディーラーの2枚目は裏向きです");
        }
    }
}
