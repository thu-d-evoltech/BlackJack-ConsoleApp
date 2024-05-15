
namespace BlackJack
{
    internal class Deck
    {
        //リストの宣言
        private List<Card> Decks;
        public Deck()
        {
            //スタンダード 52-カード デッキを作成する
            Decks = new List<Card>();
            InitializeDeck();
            Shuffle();
        }

        //デッキの初期化
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

        //カードのシャッフル
        private void Shuffle()
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

        //カードを引く
        public Card DrawCard()
        {
            Card card = Decks[0];
            Decks.RemoveAt(0);
            return card;
        }
    }
}
