using System;

class Program
{
    public const int MaxCityHealth = 15;
    public const int MaxManticoreHealth = 10;
    static void Main()
    {
        Console.Clear();

        int manticoreHealth = MaxManticoreHealth;
        int cityHealth = MaxCityHealth;
        int round = 1;
        
        // ask player one to manticore distance (0 to 100) then clear the screen
        Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore? ");
        int manticoreDistance = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Player 2, it is your turn.");

        // run until either manticore's or city's health reaches 0
        // before the second player's turn, display round number, cannon damage, healths and tell the user if they overshot, fell short, or hit
        while(cityHealth > 0 && manticoreHealth > 0)
        {
            int cannonDamage = CalculateCannonDamage(round);
            int cannonRange = DisplayStatusAndGetRange(round, cityHealth, manticoreHealth, cannonDamage);
            manticoreHealth = ApplyCannonShot(cannonRange, manticoreDistance, manticoreHealth, cannonDamage);
            
            // if manticore alive, reduce the city's health by 1 every turn
            if (manticoreHealth > 0) cityHealth -= 1;
            round += 1;
        }
        if (manticoreHealth <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The city of Consolas has been destroyed! The Manticore has conquered the city!");
            Console.ForegroundColor = ConsoleColor.White;
        } 

    }
    static int DisplayStatusAndGetRange(int round, int cityHealth, int manticoreHealth, int cannonDamage)
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("STATUS: Round: " + round + " City: " + cityHealth + "/" + MaxCityHealth + " Manticore: " + manticoreHealth + "/" + MaxManticoreHealth);
        Console.WriteLine("The cannon is expected to deal " + cannonDamage + " damage this round.");
        Console.Write("Enter desired cannon range: ");
        int cannonRange = Convert.ToInt32(Console.ReadLine());
        return cannonRange;
    }
    
    static int ApplyCannonShot(int cannonRange, int manticoreDistance, int manticoreHealth, int cannonDamage)
    {
        if (cannonRange > manticoreDistance) Console.WriteLine("That round OVERSHOT the target.");
        else if (cannonRange < manticoreDistance) Console.WriteLine("That round FELL SHORT of the target.");
        else
        {
            Console.WriteLine("That round was a DIRECT HIT!");
            manticoreHealth -= cannonDamage;
        }
        return manticoreHealth;
    }

    static int CalculateCannonDamage(int round)
    {
        if (round % 3 == 0 && round % 5 == 0) return 10;
        if (round % 3 == 0 || round % 5 == 0) return 3;
        return 1;
    }
}