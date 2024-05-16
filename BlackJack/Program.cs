
namespace BlackJack;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("☆ ★ ☆ ★ ☆ ★ ☆ ★  ブラックジャックへようこそ！ ☆ ★ ☆ ★ ☆ ★ ☆ ★");

        // ゲームのリプレイ変数を宣言する
        bool isContinuePlaying = true;

        while (isContinuePlaying)
        {
            PlayGame playGame = new PlayGame();
            playGame.Play();

            Console.WriteLine("");
            Console.Write("遊び続けますか?　遊ぶ場合はYを、 遊ばない場合は任意のキーを入力してください\n");
            string input = Console.ReadLine();
            isContinuePlaying = (input.ToUpper() == "Y");
        }
        Console.WriteLine("------------------------------");
        Console.WriteLine("ブラックジャック終了！ありがとうございました★");
        Console.ReadKey();
    }

    /// <summary>
    /// 指定されたミリ秒数だけ現在のスレッドを休止させる
    /// </summary>
    /// <param name="miliseconds">休止させるミリ秒数</param>
    public static void SleepTime(int miliseconds = 1000)
    {
        Thread.Sleep(miliseconds);
    }
}