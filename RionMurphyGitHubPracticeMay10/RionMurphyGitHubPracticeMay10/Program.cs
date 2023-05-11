// See https://aka.ms/new-console-template for more information
Console.WriteLine("Greetings Creator. It is a pleasure to meet you in this world of github.");
Console.WriteLine("We will be making use of examples to show how github commits work.");

int userEntry = 0, i = 0;

do
{
    i++;
    Console.WriteLine($"Iteration #{i}");
    Console.Write("\nPlease enter 1 to continue and 0 to exit");
    userEntry = int.Parse( Console.ReadLine() );
} while (userEntry != 0)