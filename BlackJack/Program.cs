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
            Console.Write("遊び続けますか? 遊ぶ場合はYを、遊ばない場合はNを入力してください。\n");
            string input = Console.ReadLine();
            continuePlaying = (input.ToUpper() == "Y");
        }

        Console.WriteLine("------------------------------");
        Console.WriteLine("ブラックジャック終了！ありがとうございました★");

        Console.ReadKey();

    }

    //スリープ時間
    public static void Sleep(int miliseconds = 1000)
    {
        Thread.Sleep(miliseconds);
    }
}