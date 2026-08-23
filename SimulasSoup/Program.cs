
var menuChoice1 = (name: "Sweet Chicken Gumbo", food: FoodType.Gumbo, ingredient: MainIngredient.Chicken, season: Seasoning.Sweet); 
var menuChoice2 = (name: "Spicy Mushroom Soup", food: FoodType.Soup, ingredient: MainIngredient.Mushrooms, season: Seasoning.Spicy);
var menuChoice3 = (name: "Salty Carrot Stew", food: FoodType.Stew, ingredient: MainIngredient.Carrots, season: Seasoning.Salty);

while (true)
{
    Console.WriteLine("Would you look at the menu(1) or I can help to choose your taste(2)");
    int userInput = Convert.ToInt32(Console.ReadLine());
    if(userInput == 1)
    {
        Console.WriteLine("--------------MENU--------------");
        Console.WriteLine("(1) " + menuChoice1.name);
        Console.WriteLine("(2) " +menuChoice2.name);
        Console.WriteLine("(3) " +menuChoice3.name);
        Console.WriteLine("Have you decided what you're going to order? (1, 2, 3)");
        int userMenuChoice = Convert.ToInt16(Console.ReadLine());

        if(userMenuChoice == 1)
        {
            Console.WriteLine("Your " + menuChoice1.name + " is coming right up.");
            break;
        } 
        else if(userMenuChoice == 2)
        {
            Console.WriteLine("Your " + menuChoice2.name + " is coming right up.");
            break;
        } 
        else if(userMenuChoice == 3)
        {
            Console.WriteLine("Your " + menuChoice3.name + " is coming right up.");
            break;
        }
        else
        {
            Console.WriteLine("I guess you want to order different thing");
            continue;
        }

    }
    else if(userInput == 2)
    {
        Console.WriteLine("Would you like to soup, stew or gumbo?");
        string? customChoice1 = Console.ReadLine();
        if(customChoice1 == "soup" || customChoice1 == "stew" || customChoice1 == "gumbo")
        {
            Console.WriteLine("Okay, what about main ingredient? (mushroom, chicken, carrots, potatoes)");
            string? customChoice2 = Console.ReadLine();
            if(customChoice2 == "mushroom" || customChoice2 == "chicken" || customChoice2 == "carrots" || customChoice2 == "potatoes")
            {
                Console.WriteLine("Sounds great! and lastly seasoning? (spicy, salty, sweet)");
                string? customChoice3 = Console.ReadLine();
                if(customChoice3 == "spicy" || customChoice3 == "salty" || customChoice3 == "sweet")
                {
                    var customChoices = (customChoice1, customChoice2, customChoice3);

                    Console.WriteLine("Excellent choice! Your "
                     + customChoices.customChoice3 + " " + customChoices.customChoice2 + " " + customChoices.customChoice1 
                    + " is coming right up.");
                    break;
                }
                else
                {
                    Console.WriteLine("I didn't get it");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("I didn't get it");
                continue;
            }
        }
        else
        {
            Console.WriteLine("I didn't get it");
            continue;
        }
    }
    else
    {
        Console.WriteLine("I didn't get it");
        continue;
    }
    }

enum FoodType
{
    Soup,
    Stew,
    Gumbo
}

enum MainIngredient
{
    Mushrooms,
    Chicken,
    Carrots,
    Potatoes
}

enum Seasoning
{
    Spicy,
    Salty,
    Sweet
}