using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    //列挙型を定義する
    public enum CardSuit
    {
        ハート, ダイヤ,スペード, クラブ 
    }
    public enum CardFace
    {
        A, _2, _3, _4, _5, _6, _7, _8, _9, _10, J, Q, K
    }
    internal class Card
    {
        public CardFace Face { get; }
        public CardSuit Suit { get; }
        public string FaceName { get; }
        public int FaceValue { get; }

        //Cardクラスのコンストラクターを定義する
        public Card(CardSuit suit, CardFace face)
        {
            Face = face;
            Suit = suit;

            switch (Face)
            {
                case CardFace.J:
                    FaceValue = 10;
                    FaceName = "J";
                    break;
                case CardFace.Q:
                    FaceValue = 10;
                    FaceName = "Q";
                    break;
                case CardFace.K:
                    FaceValue = 10;
                    FaceName = "K";
                    break;
                default:
                    FaceValue = (int)face + 1;
                    FaceName = FaceValue.ToString();
                    break;
            }
        }
    }
}
