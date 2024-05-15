
namespace BlackJack;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("☆ ★ ☆ ★ ☆ ★ ☆ ★  ブラックジャックへようこそ！ ☆ ★ ☆ ★ ☆ ★ ☆ ★");

        //ゲームのリプレイ変数を宣言する//
        bool continuePlaying = true;

        while (continuePlaying)
        {
            PlayGame playGame = new PlayGame();
            playGame.Play();

            Console.WriteLine("");
            Console.Write("遊び続けますか?　遊ぶ場合はYを、 遊ばない場合は任意のキーを入力してください\n");
            string input = Console.ReadLine();
            continuePlaying = (input.ToUpper() == "Y");
        }
        Console.WriteLine("------------------------------");
        Console.WriteLine("ブラックジャック終了！ありがとうございました★");

        Console.ReadKey();

    }

    //スリープ時間のメッソド//
    public static void Sleep(int miliseconds = 1000)
    {
        Thread.Sleep(miliseconds);
    }
}