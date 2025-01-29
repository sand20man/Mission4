using System.Runtime.InteropServices;
using Mission_4;

// Variable setup
SupportTools st = new Mission_4.SupportTools();
bool isXTurn = true;
bool validInput = false;
bool gameFinished = false;
string userAnswer = "";

// Create game board
char[,] gameArray = new char[3,3]{
    {'1', '2', '3'},
    {'4', '5', '6'},
    {'7', '8', '9'}
};

// Update gameArray function
bool CheckGuess(char guess)
{
// For each row in the array
    bool positionFound = false;
    for (int i = 0; i < gameArray.GetLength(0); i++)
    {
        // For each col in the array
        for (int j = 0; j < gameArray.GetLength(1); j++)
        {
            // If the position given matches then update it with the appropriate letter
            if (gameArray[i, j] == guess)
            {
                positionFound = true;
                gameArray[i, j] = isXTurn ? 'X' : 'O';
            }
        }
    }

    return positionFound;
}

bool BoardFull()
{
    bool boardFull = true;
    for (int i = 0; i < gameArray.GetLength(0); i++)
    {
        // For each col in the array
        for (int j = 0; j < gameArray.GetLength(1); j++)
        {
            // If the position given matches then update it with the appropriate letter
            if (Char.IsDigit(gameArray[i, j]))
            {
                return false;
            }
        }
    }

    return boardFull;
}

// Welcome user to game
Console.WriteLine("Welcome to TicTacToe!");

// Display game board

st.PrintBoard(gameArray);

// Ask user for input
// Console.WriteLine("Please choose a numbered position to place your letter:");

// Make sure answer is 1-9
// Makes sure not multiple chars
// userAnswer = Console.ReadLine();
while (!gameFinished)
{
    Console.WriteLine("Please choose a numbered position to place your letter:");
    userAnswer = Console.ReadLine();
    
    if (userAnswer.Length != 1)
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
    else if (Char.IsDigit(userAnswer[0]) && userAnswer[0] != '0')
    {
        Console.WriteLine("Valid input. Adding it to the board...");
        Console.WriteLine(userAnswer[0]);
        validInput = CheckGuess(userAnswer[0]);
        gameFinished = st.CheckWinner(gameArray, isXTurn ? 'X' : 'O') || BoardFull();
        if (validInput) isXTurn = !isXTurn;
    }
    else
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
    
    st.PrintBoard(gameArray);
}

// Congratulate Winner
if (st.CheckWinner(gameArray, 'X'))
{
    // Congratulate X for winning
    Console.WriteLine("X wins!");
}
else if (st.CheckWinner(gameArray, 'O'))
{
    // Congratulate O for winning
    Console.WriteLine("O wins!");
}
else
{
    Console.WriteLine("Cat! Play again.");
}

