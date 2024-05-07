using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class PlayGame
    {
        private Deck deck;
        private Player player;
        private Player dealer;

        public PlayGame()
        {
            deck = new Deck();
            deck.Shuffle();

            player = new Player();
            dealer = new Player();
        }

        public void GetPlay()
        {
            player.Hand.Add(deck.DrawCard());
            dealer.Hand.Add(deck.DrawCard());
            player.Hand.Add(deck.DrawCard());
            dealer.Hand.Add(deck.DrawCard());

            player.ShowPlayerCards();
            dealer.ShowDealerCards();
            player.ShowTotal();

        }
    }
}
