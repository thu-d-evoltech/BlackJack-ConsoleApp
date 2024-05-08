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

        //PlayGameクラスのコンストラクターを定義する
        public PlayGame()
        {
            deck = new Deck();
            deck.Shuffle();

            player = new Player();
            dealer = new Player();
        }

        //ゲームの開始
        public void GetPlay()
        {
            Console.WriteLine("ゲームを開始します。");
            Console.WriteLine("------------------------------");
            Program.Sleep();

            player.Hand.Add(deck.DrawCard());
            dealer.Hand.Add(deck.DrawCard());
            player.Hand.Add(deck.DrawCard());
            dealer.Hand.Add(deck.DrawCard());

            player.ShowPlayerCards();
            dealer.ShowDealerCards();
            player.ShowTotal();

            GetPlayerTurn();
            Program.Sleep(550);
            GetDealerTurn();
            Console.WriteLine("");

            GetResuft();
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

        //ディーラーのターン
        public void GetDealerTurn()
        {
            Console.WriteLine($"ディーラーの2枚目のカードは{dealer.Hand[1].Suit}の{dealer.Hand[1].FaceName}です。");
            Console.WriteLine($"ディーラーの現在の得点は{dealer.GetTotal()}です。");
            while (dealer.GetTotal() < 17)
            {
                Card newcard = deck.DrawCard();
                dealer.Hand.Add(newcard);
                Console.WriteLine($"ディーラーの引いたカードは{newcard.Suit}の{newcard.FaceName}です。");
            }
        }

        //結果の表示
        public void GetResuft()
        {
            Console.WriteLine($"あなたの得点は{player.GetTotal()}です。");
            Console.WriteLine($"ディーラーの得点は{dealer.GetTotal()}です。");
            if (player.GetTotal() > 21)
            {
                Console.WriteLine("あなたの負けです！");
            }
            else if(dealer.GetTotal() > 21)
            {
                Console.WriteLine("あなたの勝ちです！");
            }
            else if(player.GetTotal() > dealer.GetTotal())
            {
                Console.WriteLine("あなたの勝ちです！");
            }
            else if(player.GetTotal() == dealer.GetTotal())
            {
                Console.WriteLine("引き分けでした！");
            }
            else
            {
                Console.WriteLine("あなたの負けです！");
            }
        }
    }
}
