using System;
using System.Linq;

namespace TicTacToe;

class Program
{
    static void Main(string[] args)
    {
        TicTacToeGame game = new TicTacToeGame();
        game.Run();
    }
}

class Player
{
    public int GetMove()
    {
        while (true)
        {
            Console.WriteLine("Which square do you want to play in? (0 for exit)");
            int playerMove = Convert.ToInt32(Console.ReadLine());
            if (playerMove == 0) return 0;
            if (playerMove >= 1 && playerMove <= 9) return playerMove;
            else Console.WriteLine("Invalid square selected. Please try again.");
        }
    }

}

class Round
{
    private Player _player1;
    private Player _player2;
    private Player _currentPlayer;
    public bool IsOver { get; private set; }
    public string? Winner { get; private set; }
    public bool IsExited { get; private set; }
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

    public void PlayTurn()
    {
        string currentSymbol = (_moveCount % 2 == 0) ? "X" : "O";
        _currentPlayer = (_moveCount % 2 == 0) ? _player1 : _player2;

        int row, col;

        Display();

        while (true)
        {
            int currentMove = _currentPlayer.GetMove();
            if (currentMove == 0)
            {
                IsExited = true;
                IsOver = true;
                return;
            }

            row = (currentMove - 1) / 3;
            col = (currentMove - 1) % 3;

            if (Grid[row, col] == " ") break;

            Console.WriteLine("The square isn't empty. Try a different one.");
        }

        Grid[row, col] = currentSymbol;
        _moveCount++;

        string? winner = CheckWinner();
        if (winner != null)
        {
            Winner = winner;
            IsOver = true;
            Console.WriteLine($"{winner} won!");
            return;
        }
        if (CheckDraw())
        {
            IsOver = true;
            Console.WriteLine("DRAW!");
        }
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
    private int _xWins = 0;
    private int _oWins = 0;

    public void RecordWin(string symbol)
    {
        if (symbol == "X") _xWins++;
        else _oWins++;
    }

    public void Display()
    {
        Console.WriteLine($"Score — X: {_xWins}, O: {_oWins}");
    }
}

class TicTacToeGame
{
    public void Run()
    {
        Player player1 = new Player();
        Player player2 = new Player();
        Scoreboard scoreboard = new Scoreboard();

        while (true)
        {
            Round round = new Round(player1, player2);

            while (!round.IsOver)
            {
                round.PlayTurn();
            }

            if (round.IsExited) break;

            if (round.Winner != null) scoreboard.RecordWin(round.Winner);
            scoreboard.Display();

            Console.WriteLine("Play again? (y/n)");
            if (Console.ReadLine()?.ToLower() != "y") break;
        }

        Console.WriteLine("Thanks for playing!");
    }
}