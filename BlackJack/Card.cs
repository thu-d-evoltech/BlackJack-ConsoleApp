
namespace BlackJack
{
    /// <summary>
    /// カードのスートを表す列挙型です。
    /// </summary>
    public enum CardSuit
    {
        ハート, ダイヤ,スペード, クラブ 
    }

    /// <summary>
    /// カードのフェースを表す列挙型です。
    /// </summary>
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

        //// <summary>
        /// カードを初期化するコンストラクターです。
        /// </summary>
        /// <param name="suit">カードのスート</param>
        /// <param name="face">カードのフェース</param>
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
