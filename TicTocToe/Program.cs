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
    public int GetMove()
    {
        while (true)
        {
            Console.WriteLine("Which square do you want to play in? (0 for exit)");
            int PlayerMove = Convert.ToInt32(Console.ReadLine());
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
        string currentSymbol = (_moveCount % 2 == 0) ? "X" : "O";
        _currentPlayer = (_moveCount % 2 == 0) ? _player1 : _player2;

        int row, col;

        Display();
        
        while (true)
        {
            int currentMove = _currentPlayer.GetMove();
            if (currentMove == 0) return;

            row = (currentMove - 1) / 3;
            col = (currentMove - 1) % 3;

            if (Grid[row, col] == " ") break;

            Console.WriteLine("The square isn't empty. Try a different one.");
        }

        Grid[row, col] = currentSymbol;
        _moveCount++;

        string? winner = CheckWinner();
        if (winner != null) { Console.WriteLine($"{winner} won!"); return; }
        if (CheckDraw()) Console.WriteLine("DRAW!");
    }


    private void Display()
    {
        string? displayedPlayer;

        if (_currentPlayer == _player1) displayedPlayer = "Player 1";
        else displayedPlayer = "Player 2";

        Console.WriteLine($" {displayedPlayer}'s turn:");
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