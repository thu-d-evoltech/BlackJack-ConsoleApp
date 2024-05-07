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
            Console.WriteLine("ゲームを開始します。");

            player.Hand.Add(deck.DrawCard());
            dealer.Hand.Add(deck.DrawCard());
            player.Hand.Add(deck.DrawCard());
            dealer.Hand.Add(deck.DrawCard());

            player.ShowPlayerCards();
            dealer.ShowDealerCards();
            player.ShowTotal();

            GetPlayerTurn();
            
        }

        //プレイヤーのターン
        public void GetPlayerTurn()
        {
            while (true)
            {
                Console.WriteLine("カードを引きますか？ひく場合はYを、引かない場合はNを入力してください。");
                string choice = Console.ReadLine();

                if (choice == "Y")
                {
                    Card newCard = deck.DrawCard();
                    player.Hand.Add(newCard);

                    newCard.PrintCard();
                    player.ShowTotal();

                    if (player.GetTotal() >= 21)
                    {
                        break;
                    }
                }
                else if (choice == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Y又はNを入力してください。");
                }
            }
        }
    }
}
