using System;

class Program
{
    static void Main()
    {
        Console.Clear();
        // set manticore health to 10 and city to 15 then game starts at round 1
        int manticoreHealth = 10;
        int cityHealth = 15;
        int round = 1;
        int cannonDamage;
        int cannonRange;
        
        // ask player one to manticore distance (0 to 100) then clear the screen
        Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore? ");
        int manticoreDistance = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Player 2, it is your turn.");

        // run until either manticore's or city's health reaches 0
        // before the second player's turn, display round number, cannon damage, healths and tell the user if they overshot, fell short, or hit
        while(cityHealth > 0 && manticoreHealth > 0)
        {
            // cannon damage: 10 if round number is a multiple of both 3 and 5 like 15, 3 if it is a multiple 3 or 5 not both and 1 otherwise
            if(round % 3 == 0 && round % 5 == 0) cannonDamage = 10;
            else if(round % 3 == 0 || round % 5 == 0) cannonDamage = 3;
            else cannonDamage = 1;

            cannonRange = TakeCannonRange(round, cityHealth, manticoreHealth, cannonDamage);
            manticoreHealth = CheckCannonRange(cannonRange, manticoreDistance, manticoreHealth, cannonDamage);
            
            // if manticore alive, reduce the city's health by 1 every turn
            if (manticoreHealth > 0) cityHealth -= 1;
            round += 1;
        }
        if (manticoreHealth <= 0) Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        else Console.WriteLine("The city of Consolas has been destroyed! The Manticore has conquered the city!");

    }
    static int TakeCannonRange(int round, int cityHealth, int manticoreHealth, int cannonDamage)
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("STATUS: Round: " + round + " City: " + cityHealth + "/15" + " Manticore: " + manticoreHealth + "/10");
        Console.WriteLine("The cannon is expected to deal " + cannonDamage + " damage this round.");
        Console.Write("Enter desired cannon range: ");
       int cannonRange = Convert.ToInt32(Console.ReadLine());
       return cannonRange;
    }
    
    static int CheckCannonRange(int cannonRange, int manticoreDistance, int manticoreHealth, int cannonDamage)
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
}