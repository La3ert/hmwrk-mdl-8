namespace TicTacToe;

class Program
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    static int Main()
    {
        int playerTurn = 1;
        int flag = 0;
        while (flag != 1 && flag != -1)
        {
            Console.Clear(); 
            Console.WriteLine("Player - " + (playerTurn % 2 == 0 ? "O" : "X"));
            Console.WriteLine("\n");
            Board();
            
            bool validInput = false;
            int choice = 0;
            while (!validInput)
            {
                while (true)
                {
                    Console.Write("Enter cell number: ");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        continue;
                    }
                }
                if (choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O') 
                    validInput = true;
                else 
                    Console.WriteLine("The cell is already occupied! Try again.");
            }

            if (playerTurn % 2 == 0)
            {
                board[choice - 1] = 'O';
            }
            else
            {
                board[choice - 1] = 'X';
            }
            flag = CheckWin();
            playerTurn++;
        }
        Console.Clear();
        Board();
        if (flag == 1)
        {
            Console.WriteLine("Player " + (playerTurn % 2 + 1) + " win!");
        }
        else
        {
            Console.WriteLine("Draw!");
        }
        return 0;
    }

    static void Board()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}");
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}");
        Console.WriteLine("     |     |      ");
    }

    static int CheckWin()
    {
        if (board[0] == board[1] && board[1] == board[2])
            return 1;
        else if (board[3] == board[4] && board[4] == board[5])
            return 1;
        else if (board[6] == board[7] && board[7] == board[8])
            return 1;
        else if (board[0] == board[3] && board[3] == board[6])
            return 1;
        else if (board[1] == board[4] && board[4] == board[7])
            return 1;
        else if (board[2] == board[5] && board[5] == board[8])
            return 1;
        else if (board[0] == board[4] && board[4] == board[8])
            return 1;
        else if (board[2] == board[4] && board[4] == board[6])
            return 1;
        else if (board[0] != '1' && board[1] != '2' && board[2] != '3' && board[3] != '4' && board[4] != '5' && board[5] != '6' && board[6] != '7' && board[7] != '8' && board[8] != '9')
            return -1;
        else
            return 0;
    }
}

