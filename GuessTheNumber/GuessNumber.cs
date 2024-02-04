namespace GuessTheNumber;

public enum GuessingPlayer
{
    Human,
    Machine
}
public class GuessNumber
{
    private readonly int max;
    private readonly int maxTries;
    private readonly GuessingPlayer guessingPlayer;

    public GuessNumber(int max = 100, int maxTries = 5, GuessingPlayer guessingPlayer = GuessingPlayer.Human)
    {
        this.max = max;
        this.maxTries = maxTries;
        this.guessingPlayer = guessingPlayer;
    }

    public void Start()
    {
        if (guessingPlayer == GuessingPlayer.Human)
        {
            HumanGuesses();
        }
        else
        {
            MachinGuesses();
        }
    }

    private void HumanGuesses()
    {
        int tries = 0;
        Random random = new Random();
        int randomNumber = random.Next(0, max);
        Console.WriteLine($"I guessed a number from 0 to {max}. Try to guess");
        bool NumberGuessed = false;
        int number;
        while (!NumberGuessed && tries != maxTries)
        {
            
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }

            if (number == randomNumber)
            {
                Console.WriteLine("Congratulations! You guessed the number");
                NumberGuessed = true;
            }
            else if (number > randomNumber)
            {
                tries++;
                Console.WriteLine($"The intended number is less than {number}");
            }
            else if (number < randomNumber)
            {
                tries++;
                Console.WriteLine($"The intended number is greater than {number}");
            }
        }

        if (!NumberGuessed)
        {
            Console.WriteLine("Your attempts are over. You failed to guess the number.");
        }
    }

    private void MachinGuesses()
    {
        int number;
        int tries = 0;
        int min = 0;
        int max = this.max;
        char answer;
        
        Console.WriteLine($"Think of a number from 0 to {max}");
        int guessedNumber;
        while (true)
        {
            try
            {
                guessedNumber = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }
        }

        while (true)
        {
            if (guessedNumber >= 0 || guessedNumber <= max)
            {
                break;
            }
            else if(guessedNumber < 0)
            {
                Console.WriteLine($"{guessedNumber} less than 0");
            }
            else
            {
                Console.WriteLine($"{guessedNumber} greater than {max}");
            }
        }
        
        bool NumberGuessed = false;
        
        while (!NumberGuessed && tries != maxTries)
        {
            number = (min + max) / 2;
            Console.WriteLine($"Did you guess the number {number}?");
            Console.WriteLine($"If yes, enter \"y\", if you number greater than {number}, enter \"g\", if less - enter \"l\"");
            try
            {
                answer = char.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }

            if (answer == 'y')
            {
                Console.WriteLine("I won.");
                NumberGuessed = true;
            }
            else if (answer == 'g')
            {
                min = number;
                tries++;
            }
            else
            {
                max = number;
                tries++;
            }
        }

        if (!NumberGuessed)
        {
            Console.WriteLine("I couldn't guess the number. You won");
        }
    }
}


