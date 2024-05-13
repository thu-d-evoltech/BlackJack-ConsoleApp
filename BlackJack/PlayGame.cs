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
            Console.WriteLine("");
            Console.WriteLine("ゲームを開始します！\n");
            Console.WriteLine("---------------------------------------");
            Program.Sleep();

            player.Hand.Add(deck.DrawCard());
            dealer.Hand.Add(deck.DrawCard());
            player.Hand.Add(deck.DrawCard());
            dealer.Hand.Add(deck.DrawCard());

            Console.Write("あなたのカード：");
            player.ShowCards();
            Console.WriteLine($"あなたの得点：{player.GetTotal()}");
            Console.WriteLine("---------------------------------------");
            dealer.ShowDealerCards();

            GetPlayerTurn();
            Program.Sleep();

            GetDealerTurn();
            Console.WriteLine("\nゲームが完了しました\n");

            Program.Sleep();
            Console.WriteLine("結果");
            Console.WriteLine("---------------------------------------");
            GetResuft();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ");

        }

        //プレイヤーのターン
        public void GetPlayerTurn()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("カードを引きますか？");
            Console.WriteLine("引く場合：Y | 引かない場合：N　を入力してください");


            while (true)
            {
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "Y")
                {
                    Card newCard = deck.DrawCard();
                    player.Hand.Add(newCard);

                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine($"引いたカード：{newCard.Suit}の{newCard.FaceName}");
                    Console.Write("あなたのカード：");
                    player.ShowCards();
                    Console.WriteLine($"あなたの得点：{player.GetTotal()}");
                    Console.WriteLine("---------------------------------------");

                    if (player.GetTotal() >= 21)
                    {
                        break;
                    } 
                    else
                    {
                        Console.WriteLine("引く場合：Y | 引かない場合：N　を入力してください");
                    }
                }
                else if (choice.ToUpper() == "N")
                {
                    Console.WriteLine("---------------------------------------");
                    break;
                }
            }
        }

        //ディーラーのターン
        public void GetDealerTurn()
        {
            Console.WriteLine("あなたの番が終了したのでディーラーの番になります");

            if (player.GetTotal() < 21)
            {
                Console.WriteLine("ディーラーは得点が17点以上になるまでカードを引きます\n");
            }
            else
            {
                Console.WriteLine("プレイヤーはバーストなので、ディーラーがカードを引きません\n");
            }
            Console.WriteLine($"裏向きの2枚目のカード：{dealer.Hand[1].Suit}の{dealer.Hand[1].FaceName}");
            Console.WriteLine($"ディーラーの得点：{dealer.GetTotal()}");

            while (true)
            {
                if (dealer.GetTotal() < 17 && player.GetTotal() < 21)
                {
                    Program.Sleep();
                    Card card = deck.DrawCard();
                    dealer.Hand.Add(card);
                    Console.WriteLine($"{card.Suit}の{card.FaceName}のカードを引きました");
                    Console.WriteLine($"ディーラーの得点：{dealer.GetTotal()}");
                } 
                else if (dealer.GetTotal() > 17)
                {
                    Console.WriteLine("17点以上になったため、ディーラーの番を終了します");
                    break;
                }
                else 
                {
                    break;
                }
            }

        }

        //結果の表示
        public void GetResuft()
        {
            Console.WriteLine("あなた");
            Console.Write("　カード："); player.ShowCards();
            Console.WriteLine($"　得点：{player.GetTotal()}");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("ディーラー");
            Console.Write("　カード："); dealer.ShowCards();
            Console.WriteLine($"　得点：{dealer.GetTotal()}");
            Console.WriteLine("---------------------------------------");

            if (player.GetTotal() > 21)
            {
                Console.WriteLine("勝敗 ： あなたの負けです！");
            }
            else if(dealer.GetTotal() > 21)
            {
                Console.WriteLine("勝敗 ： あなたの勝ちです！");
            }
            else if(player.GetTotal() > dealer.GetTotal())
            {
                Console.WriteLine("勝敗 ： あなたの勝ちです！");
            }
            else if(player.GetTotal() == dealer.GetTotal())
            {
                Console.WriteLine("勝敗 ： 引き分けでした！");
            }
            else
            {
                Console.WriteLine("勝敗 ： あなたの負けです！");
            }
        }
    }
}
