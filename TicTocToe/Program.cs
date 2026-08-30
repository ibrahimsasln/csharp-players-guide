using System;

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

}

class Round
{
    private Player _player1;
    private Player _player2;
    private Player _currentPlayer;

    public Round(Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;
        _currentPlayer = player1; //start with player1

    }
    public string[,] Grid { get; } = new string[,]
    {
        {" ", " ", " "},
        {" ", " ", " "},
        {" ", " ", " "}
    };
    public void Display()
    {
        Console.WriteLine($"It is {_currentPlayer}'s turn.");
        Console.WriteLine($" {Grid[0,0]} | {Grid[0,1]} | {Grid[0,2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Grid[1,0]} | {Grid[1,1]} | {Grid[1,2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Grid[2,0]} | {Grid[2,1]} | {Grid[2,2]} ");
        Console.WriteLine("Which square do you want to play in? (0 for exit)");
    }

    public void CheckWinner()
    {
        
    }
}

class Scoreboard
{
    
}

class TicTocToeGame
{
    
}