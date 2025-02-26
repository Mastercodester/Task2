// See https://aka.ms/new-console-template for more information




Console.WriteLine("Whats your name?");
var name = Console.ReadLine();
bool roundsValid = false;


Console.WriteLine($"Hello {name} Do you want to play a CoinFlip Game?");
string? input = Console.ReadLine()?.Trim().ToLower();

if (input == "yes" || input == "y")
{
    Console.WriteLine("You selected Yes.");
}
else if (input == "no" || input == "n")
{
    Console.WriteLine("You selected No. Coward!!");
    Environment.Exit(0);
}
else
{
    Console.WriteLine($"Invalid input {name}. Please enter yes or no.");
}

Console.WriteLine($"How many rounds do you want to play {name}? Pick between 5 through 10.");

int rounds = int.Parse(Console.ReadLine());

while (!roundsValid)
{
    if (rounds <= 4 || rounds >= 11)
    {
        Console.WriteLine($"\nInvalid input {name}Try Again");
        roundsValid = false;
    }
    else
    {
        Console.WriteLine($"Great! {name}Lets Begin");
    }

    Random random = new Random();

    var flips = Enumerable.Range(0, rounds)
        .Select(_ => random.Next(0, 2))
        .ToList();

    int totalScore = 0; 

    

    
    for (int round = 0; round < rounds; round++)
    {
        
        Console.Write("Round " + (round + 1) + ": Pick Heads or Tails: ");
        string? userChoice = Console.ReadLine()?.Trim().ToLower();

        
        while (userChoice != "heads" && userChoice != "tails")
        {
            Console.WriteLine($"Invalid input {name}. Please enter 'Heads' or 'Tails'.");
            userChoice = Console.ReadLine()?.Trim().ToLower();
        }

        
        int flipResult = flips[round];
        string flipOutcome = flipResult == 1 ? "Tails" : "Heads";

        
        if ((userChoice == "tails" && flipResult == 1) || (userChoice == "heads" && flipResult == 0))
        {
            totalScore++; 
            Console.WriteLine("You guessed correctly! The result was " + flipOutcome + ".");
        }
        else
        {
            Console.WriteLine($"Sorry {name}, you guessed wrong. The result was " + flipOutcome + ".");
        }

        
        Console.WriteLine($"{name} total score: " + totalScore);
        Console.WriteLine(); 
    }
    
    Console.WriteLine($"Game Over! {name} Your final score is: " + totalScore);
Environment.Exit(0);
}