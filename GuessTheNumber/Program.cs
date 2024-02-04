namespace GuessTheNumber;

class Program
{
    static void Main(string[] args)
    {
        GuessNumber game = new GuessNumber(maxTries: 10, guessingPlayer: GuessingPlayer.Machine);
        
        game.Start();
    }
}



