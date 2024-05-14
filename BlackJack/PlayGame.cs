using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class PlayGame
    {
        private Deck Deck;
        private Player Player;
        private Player Dealer;
        const string Line = "---------------------------------------";

        //PlayGameクラスのコンストラクターを定義する
        public PlayGame()
        {
            Deck = new Deck();
            Deck.Shuffle();

            Player = new Player();
            Dealer = new Player();
        }

        //ゲームの開始
        public void Play()
        {

            Console.WriteLine("\nゲームを開始します！\n");
            Console.WriteLine(Line);
            Program.Sleep();

            Player.Hand.Add(Deck.DrawCard());
            Dealer.Hand.Add(Deck.DrawCard());
            Player.Hand.Add(Deck.DrawCard());
            Dealer.Hand.Add(Deck.DrawCard());

            Console.Write("あなたのカード：");
            Player.ShowCards();
            Console.WriteLine($"あなたの得点：{Player.GetTotal()}");
            Console.WriteLine(Line);
            Dealer.ShowDealerCards();

            PlayerTurn();
            Program.Sleep();

            PlayRule();
            DealerTurn();
            Console.WriteLine("ゲームが完了しました\n");

            Program.Sleep();
            Console.WriteLine("結果");
            Console.WriteLine(Line);
            ShowResult();
            Console.WriteLine(Line);
            Console.WriteLine("☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ");

        }

        //プレイヤーのターン
        public void PlayerTurn()
        {
            Console.WriteLine(Line);
            Console.WriteLine("カードを引きますか？");
            Console.WriteLine("引く場合：Y | 引かない場合：N　を入力してください");


            while (true)
            {
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "Y")
                {
                    Card newCard = Deck.DrawCard();
                    Player.Hand.Add(newCard);

                    Console.WriteLine(Line);
                    Console.WriteLine($"引いたカード：{newCard.Suit}の{newCard.FaceName}");
                    Console.Write("あなたのカード：");
                    Player.ShowCards();
                    Console.WriteLine($"あなたの得点：{Player.GetTotal()}");
                    Console.WriteLine(Line);

                    if (Player.GetTotal() >= 21)
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
                    Console.WriteLine(Line);
                    break;
                }
            }
        }

        //ルールの説明
        public void PlayRule()
        {
            Console.WriteLine("あなたの番が終了したのでディーラーの番になります");
            if (Player.GetTotal() < 21)
            {
                Console.WriteLine("ディーラーは得点が17点以上になるまでカードを引きます\n");
            }
            else
            {
                Console.WriteLine("プレイヤーはバーストなので、ディーラーがカードを引きません\n");
            }
            Console.WriteLine($"裏向きの2枚目のカード：{Dealer.Hand[1].Suit}の{Dealer.Hand[1].FaceName}");
            Console.WriteLine($"ディーラーの得点：{Dealer.GetTotal()}");
        }

        //ディーラーのターン
        public void DealerTurn()
        {   
            while (true)
            {
                if (Dealer.GetTotal() < 17 && Player.GetTotal() < 21)
                {
                    Program.Sleep();
                    Card card = Deck.DrawCard();
                    Dealer.Hand.Add(card);
                    Console.WriteLine($"{card.Suit}の{card.FaceName}のカードを引きました");
                    Console.WriteLine($"ディーラーの得点：{Dealer.GetTotal()}");
                } 
                else if (Dealer.GetTotal() > 17)
                {
                    Console.WriteLine("17点以上になったため、ディーラーの番を終了します\n");
                    break;
                }
                else 
                {
                    break;
                }
            }

        }

        //勝敗を判断する
        public bool? Determine()
        {
            if (Player.GetTotal() > 21)
            {
                return false;
            }
            else if (Dealer.GetTotal() > 21)
            {
                return true;
            }
            else if (Player.GetTotal() > Dealer.GetTotal())
            {
                return true;
            }
            else if (Player.GetTotal() == Dealer.GetTotal())
            {
                return null ;
            }
            else
            {
                return false;
            }
        }

        //
        public void DisplayInfo(string name, Player player)
        {
            Console.WriteLine($"{name}");
            Console.Write("　カード：");
            player.ShowCards();
            Console.WriteLine($"　得点：{player.GetTotal()}");
            Console.WriteLine(Line);
        }

        //結果の表示
        public void ShowResult()
        {
            DisplayInfo("あなた", Player);
            DisplayInfo("ディーラー", Dealer);

            bool? messenger = Determine();
            if (messenger == true)
            {
                Console.WriteLine("勝敗 ： あなたの勝ちです！");
            }
            else if(messenger == false)
            {
                Console.WriteLine("勝敗 ： あなたの負けです！");
            }
            else
            {
                Console.WriteLine("勝敗 ： 引き分けでした！");
            }
        }
    }
}
