namespace Mission_4;

    
public class SupportTools
{
    private int count = 0;
    public void PrintBoard(char[,] gameArray)
    {
        Console.WriteLine("Tic-Tac-Toe Board:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("  {0} | {1} | {2} ", gameArray[i, 0], gameArray[i, 1], gameArray[i, 2]);
            if (i < 2)
            {
                Console.WriteLine(" ---+---+---");
            }
        }
    }
    
    public bool CheckWinner(char[,] gameArray, char playerLetter)
    {
        bool gameover = false;
        
        if (count > 4 && !gameover)
        {
            //Check rows
            for (int i = 0; i < 3; i++)
            {
                if (gameArray[i, 0] == gameArray[i, 1] && gameArray[i, 1] == gameArray[i, 2] &&
                    gameArray[i, 2] == playerLetter)
                {
                    gameover = true;
                }
            }

            //Check columns
            for (int i = 0; i < 3; i++)
            {
                if (gameArray[0, i] == gameArray[1, i] && gameArray[1, i] == gameArray[2, i] &&
                    gameArray[2, i] == playerLetter)
                {
                    gameover = true;
                }
            }

            //Check diagonal
            for (int i = 0; i < 3; i++)
            {
                if (gameArray[0, 0] == gameArray[1, 1] && gameArray[1, 1] == gameArray[2, 2] &&
                    gameArray[2, 2] == playerLetter)
                {
                    gameover = true;
                }
            }

            //Check reverse-diagonal
            for (int i = 0; i < 3; i++)
            {
                if (gameArray[0, 2] == gameArray[1, 1] && gameArray[1, 1] == gameArray[2, 0] &&
                    gameArray[2, 0] == playerLetter)
                {
                    gameover = true;
                }
            }
        }

        count++;
        return gameover;
    }
}
