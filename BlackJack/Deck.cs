using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        private List<Card> deck;
        public Deck()
        {
            //スタンダード 52-カード デッキを作成する
            deck = new List<Card>(52);
            InitializeDeck();
            Shuffle();
        }

        
        public void InitializeDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
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
                int k = random.Next(0, n);
                Card cards = deck[k];
                deck[k] = cards;
                deck[n] = cards;
            }
        }
        
    }
}
