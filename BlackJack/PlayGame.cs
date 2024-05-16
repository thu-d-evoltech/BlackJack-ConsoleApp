
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
            Deck = new Deck();
            Player = new Player();
            Dealer = new Player();
        }

        /// <summary>
        /// すべてのゲームを実行するメソッド
        /// ゲームを開始してプレイヤーとディーラーのカードを配り、ターンを進行し、結果を表示する
        /// </summary>
        public void Play()
        {
            Console.WriteLine("\nゲームを開始します！\n");
            Console.WriteLine(Line);
            Program.Sleep();

            // カードを配る
            Player.Hand.Add(Deck.DrawCard());
            Dealer.Hand.Add(Deck.DrawCard());
            Player.Hand.Add(Deck.DrawCard());
            Dealer.Hand.Add(Deck.DrawCard());
            
            // プレイヤーとディーラーのカードを表示する
            Console.WriteLine($"あなたのカード：{Player.ShowCards()}");
            Console.WriteLine($"あなたの得点：{Player.GetTotal()}");
            Console.WriteLine(Line);
            Dealer.ShowDealerCards();

            // プレイヤーのターンの開始
            PlayerTurn();
            Program.Sleep();

            // ディーラーのターンの開始
            PlayRule();
            DealerTurn();
            Console.WriteLine("\nゲームが完了しました\n");

            // ゲーム完了、勝敗を表示する
            Program.Sleep();
            Console.WriteLine("結果");
            Console.WriteLine(Line);
            ShowResult();
            Console.WriteLine(Line);
            Console.WriteLine("☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ☆ ★ ");
        }

        /// <summary>
        /// プレイヤーのターンを実行し、カードを引いて得点を表示するメソッド
        /// </summary>
        private void PlayerTurn()
        {
            string request = "引く場合：Y | 引かない場合：N　を入力してください";
            Console.WriteLine(Line);
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

                    Console.WriteLine(Line);
                    Console.WriteLine($"引いたカード：{newCard.Suit}の{newCard.FaceName}");
                    Console.WriteLine($"あなたのカード：{Player.ShowCards()}");
                    Console.WriteLine($"あなたの得点：{Player.GetTotal()}");
                    Console.WriteLine(Line);

                    if (Player.GetTotal() >= 21)
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
                    Console.WriteLine(Line);
                    break;
                }
            }
        }

        /// <summary>
        /// プレイヤーのターンが終了した後、ディーラーのターンを開始するルールを表示するメソッド
        /// </summary>
        private void PlayRule()
        {
            StringBuilder mess = new StringBuilder();
            mess.AppendLine("あなたの番が終了したのでディーラーの番になります");
            if (Player.GetTotal() < 21)
            {
                mess.AppendLine("ディーラーは得点が17点以上になるまでカードを引きます\n");
            }
            else
            {
                mess.AppendLine("プレイヤーはバーストなので、ディーラーがカードを引きません\n");
            }
            mess.AppendLine($"裏向きの2枚目のカード：{Dealer.Hand[1].Suit}の{Dealer.Hand[1].FaceName}");
            mess.AppendLine($"ディーラーの得点：{Dealer.GetTotal()}");
            Console.WriteLine(mess.ToString());
        }

        /// <summary>
        /// ディーラーのターンを実行し、カードを引いて得点を表示するメソッド
        /// ディーラーの得点は17点を超えている場合、またはプレーヤーがバストされた場合、ディーラーはカードを引かない
        /// </summary>
        private void DealerTurn()
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
        /// プレイヤーとディーラーの得点に基づいてゲームの結果を判定するメソッド。
        /// </summary>
        private GameResult Determine()
        {
            if (Player.GetTotal() > 21)
            {
                return GameResult.Lose;
            }
            else if (Dealer.GetTotal() > 21)
            {
                return GameResult.Win;
            }
            else if (Player.GetTotal() > Dealer.GetTotal())
            {
                return GameResult.Win;
            }
            else if (Player.GetTotal() == Dealer.GetTotal())
            {
                return GameResult.Draw;
            }
            else
            {
                return GameResult.Lose;
            }
        }

        /// <summary>
        /// プレイヤーまたはディーラーの情報（名前、カード、得点）を表示するメソッド。
        /// </summary>
        /// <param name="name">プレイヤーまたはディーラーの名前</param>
        /// <param name="player">プレイヤーまたはディーラーのオブジェクト</param>
        private void DisplayInfo(string name, Player player)
        {
            StringBuilder mess = new StringBuilder();
            mess.AppendLine($"{name}");
            mess.AppendLine($"　カード：{player.ShowCards()}");
            mess.AppendLine($"　得点：{player.GetTotal()}");
            mess.AppendLine(Line);
            Console.WriteLine(mess.ToString());
        }

        /// <summary>
        /// コンソールに結果のメッセージを表示するメソッド。
        /// </summary>
        private void ShowResult()
        {
            DisplayInfo("あなた", Player);
            DisplayInfo("ディーラー", Dealer);

            GameResult result = Determine();
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
