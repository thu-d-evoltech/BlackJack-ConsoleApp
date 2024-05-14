using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        //リストの宣言
        private List<Card> deck;
        public Deck()
        {
            //スタンダード 52-カード デッキを作成する
            deck = new List<Card>(52);
            InitializeDeck();
            Shuffle();
        }

        //デッキの初期化
        public void InitializeDeck()
        {
            for (int i = 0; i < Enum.GetValues(typeof(CardSuit)).Length ; i++)
            {
                for(int j = 0; j < Enum.GetValues(typeof(CardFace)).Length; j++)
                {
                    deck.Add(new Card((CardSuit)i, (CardFace)j));
                }
            }
        }

        //カードのシャッフル
        public void Shuffle()
        {
            Random random = new Random();
            int n = deck.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card cards = deck[k];
                deck[k] = deck[n];
                deck[n] = cards;
            }
        }

        //カードを引く
        public Card DrawCard()
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            return card;
        }
    }
}
