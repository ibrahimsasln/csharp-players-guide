using System;

namespace TheLockedDoor;

class Program
{
    static void Main(string[] args)
    {
        Door door = new Door("12345");
        RunDoor(door);
    }

    static void RunDoor(Door door)
    {
        while (true)
        {
            if (door.CurrentState == DoorState.Locked)
            {
                Console.Write("Enter your passcode: ");
                string? passcodeInput = Console.ReadLine();

                if (door.TryUnlock(passcodeInput))
                {
                    Console.WriteLine($"Unlocked. Now, door is {door.CurrentState}.");
                }
                else
                {
                    Console.WriteLine("Your password is wrong.");
                }
                continue;
            }

            Console.Write($"Door is {door.CurrentState}. Next move? (Open, Lock, Close) ");
            string? nextMove = Console.ReadLine();

            DoorCommand? command = nextMove switch
            {
                "Open" => DoorCommand.Open,
                "Lock" => DoorCommand.Lock,
                "Close" => DoorCommand.Close,
                _ => null
            };

            if (command is null)
            {
                Console.WriteLine("Unexpected input. Try again.");
                continue;
            }

            bool moved = door.DoorAction(command.Value);
            if (moved)
            {
                Console.WriteLine($"Door is {door.CurrentState}.");
            }
            else
            {
                Console.WriteLine($"You can't {nextMove!.ToLower()} the door right now.");
            }
        }
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

    public bool TryUnlock(string? passcodeInput)
    {
        if (CurrentState != DoorState.Locked || passcodeInput != Passcode)
        {
            return false;
        }

        CurrentState = DoorState.Closed;
        return true;
    }

    public bool DoorAction(DoorCommand command)
    {
        DoorState newState = (CurrentState, command) switch
        {
            (DoorState.Closed, DoorCommand.Open) => DoorState.Open,
            (DoorState.Closed, DoorCommand.Lock) => DoorState.Locked,
            (DoorState.Open, DoorCommand.Close) => DoorState.Closed,
            _ => CurrentState
        };

        bool changed = newState != CurrentState;
        CurrentState = newState;
        return changed;
    }
}

enum DoorState
{
    Locked,
    Open,
    Closed
}

enum DoorCommand
{
    Lock,
    Open,
    Close
}