using System;
using System.Threading;
namespace TheLockedDoor;

class Program
{
    static void Main(string[] args)
    {
        Door door1 = new Door("12345");
        door1.DoorAction(Action.Open);
    }
}

class Door
{
    public string Passcode { get; private set; }
    public DoorState CurrentState { get; private set; } = DoorState.Locked;
    public Door(string passcode)
    {
        Passcode = passcode;
    }

    public void DoorAction(Action action)
    {
        while (true)
        {
            if (CurrentState == DoorState.Locked)
            {
                Console.Write("Enter your passcode: ");
                string? passcodeInput = Console.ReadLine();
                if (passcodeInput == Passcode)
                {
                    CurrentState = DoorState.Closed;
                    Console.WriteLine($"Unlocked. Now, door is {CurrentState}.");
                }
                else
                {
                    Console.WriteLine("Your passward is wrong");
                    continue;
                }
            }

            Console.WriteLine($"Door is {CurrentState} Next move? (Open, Lock, Close)");
            string? nextMove = Console.ReadLine();

            if (nextMove != "Open" && nextMove != "Close" && nextMove != "Lock")
            {
                Console.WriteLine("Unexpected input. Try again.");
                continue;
            }

            action = nextMove switch
            {
                "Open" => Action.Open,
                "Lock" => Action.Lock,
                "Close" => Action.Close,
                _ => Action.Lock
            };

            CurrentState = (CurrentState, action) switch
            {
                (DoorState.Closed, Action.Open) => DoorState.Open,
                (DoorState.Closed, Action.Lock) => DoorState.Locked,
                (DoorState.Open, Action.Close) => DoorState.Closed,
                _ => CurrentState
            };
            Console.WriteLine($"Door is {CurrentState}");
        }

    }
}

enum DoorState
{
    Locked,
    Open,
    Closed
}

enum Action
{
    Lock,
    Open,
    Close
}