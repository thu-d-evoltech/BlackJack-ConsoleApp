
namespace BlackJack
{
    internal class Deck
    {
        /// <summary>
        /// 山札の宣言
        /// </summary>
        private List<Card> Decks;

        /// <summary>
        /// Deckクラスのコンストラクターを定義する
        /// </summary>
        public Deck()
        {
            Decks = new List<Card>();
            InitializeDeck();
            ShuffleCard();
        }

        /// <summary>
        /// デッキの初期化する
        /// </summary>
        private void InitializeDeck()
        {
            for (int i = 0; i < Enum.GetValues(typeof(CardSuit)).Length ; i++)
            {
                for(int j = 0; j < Enum.GetValues(typeof(CardFace)).Length; j++)
                {
                    Decks.Add(new Card((CardSuit)i, (CardFace)j));
                }
            }
        }

        /// <summary>
        /// カードをシャッフルする
        /// </summary>
        private void ShuffleCard()
        {
            Random random = new Random();
            int n = Decks.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card cards = Decks[k];
                Decks[k] = Decks[n];
                Decks[n] = cards;
            }
        }

        /// <summary>
        /// カードの配る機能と引く機能を実行する
        /// </summary>
        public Card DrawCard()
        {
            Card card = Decks[0];
            Decks.RemoveAt(0);
            return card;
        }
    }
}
