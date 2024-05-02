using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public enum CardSuit
    {
        ハート, ダイヤ,スペード, グラブ 
    }
 /*   public enum CardFace
    {
        A, _2, _3, _4, _5, _6, _7, _8, _9, _10, J, Q, K
    }
    internal class Card
    {
        public CardFace Face { get; }
        public CardSuit Suit { get; }
        public int FaceValue { get; }

        public Card(CardSuit suit, CardFace face)
        {
            Face = face;
            Suit = suit;

            switch (Face)
            {
                case CardFace.A:
                    FaceValue = 1;
                    break;
                case CardFace._2:
                    FaceValue = 2;
                    break;
                case CardFace._3:
                    FaceValue = 2;
                    break;
                case CardFace._4:
                    FaceValue = 4;
                    break;
                case CardFace._5:
                    FaceValue = 5;
                    break;
                case CardFace._6:
                    FaceValue = 6;
                    break;
                case CardFace._7:
                    FaceValue = 7;
                    break;
                case CardFace._8:
                    FaceValue = 8;
                    break;
                case CardFace._9:
                    FaceValue = 9;
                    break;
                case CardFace._10:
                    FaceValue = 10;
                    break;
                case CardFace.J:
                    FaceValue = 10;
                    break;
                case CardFace.Q:
                    FaceValue = 10;
                    break;
                case CardFace.K:
                    FaceValue = 10;
                    break;
                default:
                    FaceValue = (int)face + 1;
                    break;
            }
        }

        public void PrintCard()
        {
            Console.WriteLine($"あなたの引いたカードは{Suit}の{Face}");
        }*/
    }
}
