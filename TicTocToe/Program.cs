using System;
using System.Linq;

namespace TicTocToe;

class Program
{
    static void Main(string[] args)
    {

    }
}

class Player
{
    public int PlayerMove { get; set; }

    public int GetMove()
    {
        while (true)
        {
            Console.WriteLine("Which square do you want to play in? (0 for exit)");
            PlayerMove = Convert.ToInt32(Console.ReadLine());
            if (PlayerMove == 0) return 0;
            if (PlayerMove >= 1 && PlayerMove <= 9) return PlayerMove;
            else Console.WriteLine("Invalid square selected. Please try again.");
        }
    }

}

class Round
{
    private Player _player1;
    private Player _player2;
    private Player _currentPlayer;
    private int _moveCount = 0;

    public Round(Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;
        _currentPlayer = _player1; //start with player1
        

    }

    private string[,] Grid { get; } = new string[,]
    {
        {" ", " ", " "},
        {" ", " ", " "},
        {" ", " ", " "}
    };

    private void PlayTurn()
    {
        string currentSymbol;

        Display();

        int currentMove = _currentPlayer.GetMove();
        if(currentMove == 0) return;

        while (true)
        {
            if (_moveCount % 2 == 1) _currentPlayer = _player2;
            else _currentPlayer = _player1;

            if (_currentPlayer == _player1) currentSymbol = "X";
            else currentSymbol = "O";

            if (CheckWinner() != null)
            {
                Console.WriteLine($"{currentSymbol} is won");
            }

            if (CheckDraw())
            {
                Console.WriteLine("DRAW!");
                _moveCount++;
                return;
            }

            int row = (currentMove - 1) / 3;
            int col = (currentMove - 1) % 3;

            if (Grid[row, col] == " ")
            {
                Grid[row, col] = currentSymbol;
                _moveCount++;
                return;
            }
            else
            {
                Console.WriteLine("The square isn't empty. Try different one.");
                currentMove = _currentPlayer.GetMove();
            }
        }
    }

    private void Display()
    {
        Console.WriteLine($" {_currentPlayer.ToString}'s turn:");
        Console.WriteLine($" {Grid[0, 0]} | {Grid[0, 1]} | {Grid[0, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Grid[1, 0]} | {Grid[1, 1]} | {Grid[1, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Grid[2, 0]} | {Grid[2, 1]} | {Grid[2, 2]} ");
    }

    private bool CheckDraw()
    {
        bool isDraw = Grid.Cast<string>().Contains(" ");
        return !isDraw;
    }

    private string? CheckWinner()
    {
        // rows
        if (IsWinningLine(Grid[0, 0], Grid[0, 1], Grid[0, 2])) return Grid[0, 0];
        if (IsWinningLine(Grid[1, 0], Grid[1, 1], Grid[1, 2])) return Grid[1, 0];
        if (IsWinningLine(Grid[2, 0], Grid[2, 1], Grid[2, 2])) return Grid[2, 0];

        // columns
        if (IsWinningLine(Grid[0, 0], Grid[1, 0], Grid[2, 0])) return Grid[0, 0];
        if (IsWinningLine(Grid[0, 1], Grid[1, 1], Grid[2, 1])) return Grid[0, 1];
        if (IsWinningLine(Grid[0, 2], Grid[1, 2], Grid[2, 2])) return Grid[0, 2];

        // diagonals
        if (IsWinningLine(Grid[0, 0], Grid[1, 1], Grid[2, 2])) return Grid[0, 0];
        if (IsWinningLine(Grid[0, 2], Grid[1, 1], Grid[2, 0])) return Grid[0, 2];

        return null;
    }

    private bool IsWinningLine(string a, string b, string c)
    {
        return a != " " && a == b && b == c;
    }
}

class Scoreboard
{

}

class TicTocToeGame
{

}