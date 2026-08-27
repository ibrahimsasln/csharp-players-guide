using System;
using System.Threading;
namespace TheLockedDoor;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class Door
{
    public string Passcode { get; private set;}
    public DoorState CurrentState { get; private set;} = DoorState.Locked;
    public Door(string passcode)
    {
        Passcode = passcode;
    }

    public void DoorAction(string action)
    {
        if(CurrentState == DoorState.Locked)
        {
            Console.Write("Enter your passcode: ");
            string? passcodeInput = Console.ReadLine();
            if(passcodeInput == Passcode) CurrentState = DoorState.Closed;
            else
            {
                Console.WriteLine("Your passward is wrong");
                return;
            } 
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
    Unlock,
    Open,
    Close
}