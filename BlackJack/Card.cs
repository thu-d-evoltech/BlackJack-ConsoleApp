
namespace BlackJack
{
    /// <summary>
    /// カードのスートを表す列挙型
    /// </summary>
    public enum CardSuit
    {
        ハート, ダイヤ,スペード, クラブ 
    }

    /// <summary>
    /// カードのフェースを表す列挙型
    /// </summary>
    public enum CardFace
    {
        A, _2, _3, _4, _5, _6, _7, _8, _9, _10, J, Q, K
    }
    internal class Card
    {
        /// <summary>
        /// カードのフェースのプロパティ
        /// </summary>
        public CardFace Face { get; }

        /// <summary>
        /// カードのスートのプロパティ
        /// </summary>
        public CardSuit Suit { get; }

        /// <summary>
        /// カードのフェース名のプロパティ
        /// </summary>
        public string FaceName { get; }

        /// <summary>
        /// カードのフェース値（数値カードの場合はその数値、絵札の場合は10）のプロパティ
        /// </summary>
        public int FaceValue { get; }

        /// <summary>
        /// Cardクラスのコンストラクターを定義する
        /// カードを初期化する
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
