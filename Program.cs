using System;

namespace CodeCalisthenics
{
    class Program
    {
        static void Main(string[] args)
        {
            var recipeBook = new RecipeBook(Console.ReadLine, Console.WriteLine);
            var barkeeper = new Barkeeper(Console.ReadLine, Console.WriteLine, recipeBook);
            while (true)
            {
                barkeeper.AskForDrink();
            }
        }
    }
}