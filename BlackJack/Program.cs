namespace BlackJack;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("ブラックジャックへようこそ！");

        PlayGame playGame = new PlayGame();
        playGame.GetPlay();
    }
}