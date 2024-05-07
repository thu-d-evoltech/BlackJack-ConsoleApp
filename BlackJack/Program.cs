namespace BlackJack;
public class Program
{
    //コンソールで実効する
    public static void Main()
    {
        Console.WriteLine("☆ ★ ☆ ★ ☆ ★ ☆ ★  ブラックジャックへようこそ！ ☆ ★ ☆ ★ ☆ ★ ☆ ★");
        Console.WriteLine("");

        PlayGame playGame = new PlayGame();
        playGame.GetPlay();

        Console.WriteLine("------------------------------");
        Console.WriteLine("ブラックジャック終了！また遊んでね★");
    }
}