namespace BlackJack;
public class Program
{
    //コンソールで実効する
    public static void Main()
    {
        Console.WriteLine("☆ ★ ☆ ★ ☆ ★ ☆ ★  ブラックジャックへようこそ！ ☆ ★ ☆ ★ ☆ ★ ☆ ★");
        Console.WriteLine("");

        //ゲームをリプレイ
        bool continuePlaying = true;

        while (continuePlaying)
        {
            PlayGame playGame = new PlayGame();
            playGame.GetPlay();

            Console.WriteLine("");
            Console.Write("遊び続けますか?　遊ぶ場合 : Y | 遊ばない場合 : N　を入力してください\n");
            string input = Console.ReadLine();
            if (input == "Y" || input == "v")
            {
                continuePlaying = true;
            }
            else if (input == "N" || input == "n")
            {
                continuePlaying = false;
                Console.WriteLine("------------------------------");
                Console.WriteLine("ブラックジャック終了！ありがとうございました★");
            }
            else
            {
                Console.WriteLine("Y又はNを入力してください");
            }
        }

        Console.ReadKey();

    }

    //スリープ時間
    public static void Sleep(int miliseconds = 1000)
    {
        Thread.Sleep(miliseconds);
    }
}