
using System.Text;

namespace BlackJack
{
    internal class PlayGame
    {
        /// <summary>
        /// 山札
        /// </summary>
        private Deck Deck;

        /// <summary>
        /// プレイヤー
        /// </summary>
        private Player Player;

        /// <summary>
        /// ディーラー
        /// </summary>
        private Player Dealer;

        /// <summary>
        /// PlayGameクラスのコンストラクターを定義する
        /// </summary>
        public PlayGame()
        {
            /// <summary>
            /// 山札のインスタンス
            /// </summary>
            Deck = new Deck();

            /// <summary>
            /// プレイヤーのインスタンス
            /// </summary>
            Player = new Player();

            /// <summary>
            /// ディーラーのインスタンス
            /// </summary>
            Dealer = new Player();
        }

        /// <summary>
        /// すべてのゲームを実行する
        /// ゲームを開始してプレイヤーとディーラーのカードを配り、ターンを進行し、結果を表示する
        /// </summary>
        public void Play()
        {
            Console.WriteLine("\nゲームを開始します！\n");
            Console.WriteLine(Separators.Line);
            Program.SleepTime();

            // カードを配る
            Player.Hand.Add(Deck.DrawCard());
            Dealer.Hand.Add(Deck.DrawCard());
            Player.Hand.Add(Deck.DrawCard());
            Dealer.Hand.Add(Deck.DrawCard());
            
            // プレイヤーとディーラーのカードを表示する
            Console.WriteLine($"あなたのカード：{Player.ShowCards()}");
            Console.WriteLine($"あなたの得点：{Player.GetHandTotal()}");
            Console.WriteLine(Separators.Line);
            Dealer.ShowDealerCards();

            // プレイヤーのターンの開始
            PlayerTurn();
            Program.SleepTime();

            // ディーラーのターンの開始
            ShowPlayRule();
            DealerTurn();
            Console.WriteLine("\nゲームが完了しました\n");

            // ゲーム完了、勝敗を表示する
            Program.SleepTime();
            Console.WriteLine("結果");
            Console.WriteLine(Separators.Line);
            ShowResult();
            Console.WriteLine(Separators.Line);
            Console.WriteLine("☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ");
        }

        /// <summary>
        /// プレイヤーのターンを実行し、カードを引いて得点を表示する
        /// </summary>
        private void PlayerTurn()
        {
            string request = "引く場合：Y | 引かない場合：N　を入力してください";
            Console.WriteLine(Separators.Line);
            Console.WriteLine("カードを引きますか？");
            Console.WriteLine(request);

            // プレイヤーがカードを引くかどうかを選択するループ
            while (true)
            {
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "Y")
                {
                    Card newCard = Deck.DrawCard();
                    Player.Hand.Add(newCard);

                    Console.WriteLine(Separators.Line);
                    Console.WriteLine($"引いたカード：{newCard.Suit}の{newCard.FaceName}");
                    Console.WriteLine($"あなたのカード：{Player.ShowCards()}");
                    Console.WriteLine($"あなたの得点：{Player.GetHandTotal()}");
                    Console.WriteLine(Separators.Line);

                    if (Player.GetHandTotal() >= 21)
                    {
                        break;
                    } 
                    else
                    {
                        Console.WriteLine(request);
                    }
                }
                else if (choice.ToUpper() == "N")
                {
                    Console.WriteLine(Separators.Line);
                    break;
                }
            }
        }

        /// <summary>
        /// プレイヤーのターンが終了した後、ディーラーのターンを開始するルールを表示する
        /// </summary>
        private void ShowPlayRule()
        {
            StringBuilder mess = new StringBuilder();
            mess.AppendLine("あなたの番が終了したのでディーラーの番になります");
            if (Player.GetHandTotal() < 21)
            {
                mess.AppendLine("ディーラーは得点が17点以上になるまでカードを引きます\n");
            }
            else
            {
                mess.AppendLine("プレイヤーはバーストなので、ディーラーがカードを引きません\n");
            }
            mess.AppendLine($"裏向きの2枚目のカード：{Dealer.Hand[1].Suit}の{Dealer.Hand[1].FaceName}");
            mess.AppendLine($"ディーラーの得点：{Dealer.GetHandTotal()}");
            Console.WriteLine(mess.ToString());
        }

        /// <summary>
        /// ディーラーのターンを実行し、カードを引いて得点を表示する
        /// ディーラーの得点は17点を超えている場合、またはプレーヤーがバストされた場合、ディーラーはカードを引かない
        /// </summary>
        private void DealerTurn()
        {   
            while (true)
            {
                if (Dealer.GetHandTotal() < 17 && Player.GetHandTotal() < 21)
                {
                    Program.SleepTime();
                    Card card = Deck.DrawCard();
                    Dealer.Hand.Add(card);
                    Console.WriteLine($"{card.Suit}の{card.FaceName}のカードを引きました");
                    Console.WriteLine($"ディーラーの得点：{Dealer.GetHandTotal()}");
                } 
                else if (Dealer.GetHandTotal() > 17)
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

        /// <summary>
        /// ゲームの結果一覧を作る
        /// </summary>
        private enum GameResult
        {
            Win,　// 勝ち
            Lose,　// 負け
            Draw　　//引き分け
        }

        /// <summary>
        /// プレイヤーとディーラーの得点に基づいてゲームの結果を判定する
        /// </summary>
        private GameResult DetermineGameResult()
        {
            if (Player.GetHandTotal() > 21)
            {
                return GameResult.Lose;
            }
            else if (Dealer.GetHandTotal() > 21)
            {
                return GameResult.Win;
            }
            else if (Player.GetHandTotal() > Dealer.GetHandTotal())
            {
                return GameResult.Win;
            }
            else if (Player.GetHandTotal() == Dealer.GetHandTotal())
            {
                return GameResult.Draw;
            }
            else
            {
                return GameResult.Lose;
            }
        }

        /// <summary>
        /// プレイヤーまたはディーラーの情報（名前、カード、得点）を表示する
        /// </summary>
        /// <param name="name">プレイヤーまたはディーラーの名前</param>
        /// <param name="player">プレイヤーまたはディーラーのオブジェクト</param>
        private void DisplayPlayerInfo(string name, Player player)
        {
            StringBuilder mess = new StringBuilder();
            mess.AppendLine($"{name}");
            mess.AppendLine($"　カード：{player.ShowCards()}");
            mess.AppendLine($"　得点：{player.GetHandTotal()}");
            mess.AppendLine(Separators.Line);
            Console.WriteLine(mess.ToString());
        }

        /// <summary>
        /// コンソールに結果のメッセージを表示する
        /// </summary>
        private void ShowResult()
        {
            DisplayPlayerInfo("あなた", Player);
            DisplayPlayerInfo("ディーラー", Dealer);

            GameResult result = DetermineGameResult();
            if (result == GameResult.Win)
            {
                Console.WriteLine("勝敗 ： あなたの勝ちです！");
            }
            else if(result == GameResult.Lose)
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
