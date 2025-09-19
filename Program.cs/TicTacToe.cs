namespace TicTacToe;

public class TicTacToe
{
    
Console.WriteLine("\nWelcome to Tic Tac Toe. Make your first move (enter 0 to exit).\n");

char[,] ticTacToe =
{
    { '1', '2', '3' },
    { '4', '5', '6' },
    { '7', '8', '9' }
};

PlayingField();

char currentPlayer = 'X';

bool isGameOver = false;


while (!isGameOver)
{
    Console.Write($"Player's turn {currentPlayer}: ");
    char playerMove = Console.ReadKey().KeyChar;

    if (playerMove == '0')
    {
        Console.WriteLine("\nYou ended the game early.");
        isGameOver = true;
    }

    if (playerMove >= '1' && playerMove <= '9')
    {
        bool isReplaced = false;

        for (int i = 0; i < ticTacToe.GetLength(0); i++)
        {
            for (int j = 0; j < ticTacToe.GetLength(1); j++)
            {
                if (ticTacToe[i, j] == playerMove)
                {
                    if (ticTacToe[i, j] != 'X' && ticTacToe[i, j] != 'O')
                    {
                        ticTacToe[i, j] = currentPlayer;
                        isReplaced = true;
                    }
                }
            }
        }

        if (isReplaced)
        {
            Console.Clear();
            PlayingField();

            if (CheckWinner(currentPlayer))
            {
                Console.WriteLine($"Congratulations! The player won {currentPlayer}!");
                isGameOver = true;
            }
            else if (IsDraw())
            {
                Console.WriteLine("Draw.");
                isGameOver = true;
            }
            else
            {
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }
        else
        {
            Console.Clear();

            Console.WriteLine("\nThis cell is already occupied. Try again.\n");

            PlayingField();
        }
    }
}

void PlayingField()
{
    for (int i = 0; i < ticTacToe.GetLength(0); i++)
    {
        for (int j = 0; j < ticTacToe.GetLength(1); j++)
        {
            char cell = ticTacToe[i, j];

            if (cell == 'X')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($" {cell} ");
                Console.ResetColor();
            }
            else if (cell == 'O')
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($" {cell} ");
                Console.ResetColor();
            }
            else
            {
                Console.Write($" {cell} ");
            }

            if (j < ticTacToe.GetLength(1) - 1)
                Console.Write("|");
        }

        Console.WriteLine();
        if (i < ticTacToe.GetLength(0) - 1)
            Console.WriteLine("---+---+---");
    }

    Console.WriteLine();
}

bool CheckWinner(char player)
{
    for (int i = 0; i < 3; i++)
    {
        if (ticTacToe[i, 0] == player && ticTacToe[i, 1] == player && ticTacToe[i, 2] == player)
            return true;
        if (ticTacToe[0, i] == player && ticTacToe[1, i] == player && ticTacToe[2, i] == player)
            return true;
    }

    if (ticTacToe[0, 0] == player && ticTacToe[1, 1] == player && ticTacToe[2, 2] == player)
        return true;
    if (ticTacToe[0, 2] == player && ticTacToe[1, 1] == player && ticTacToe[2, 0] == player)
        return true;

    return false;
}

bool IsDraw()
{
    foreach (char cell in ticTacToe)
    {
        if (cell != 'X' && cell != 'O')
            return false;
    }

    return true;
}
}