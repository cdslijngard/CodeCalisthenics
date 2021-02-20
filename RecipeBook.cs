
using System;
using System.Collections.Generic;

namespace CodeCalisthenics
{
    public class RecipeBook
    {
        private readonly Dictionary<string, Action> _recipes;
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        public RecipeBook(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;

            _recipes = new Dictionary<string, Action>
            {
                {"beer", ServeBeer},
                {"juice", ServeJuice}
            };
        }

        public IEnumerable<string> GetAvailableDrinkNames()
        {
            return _recipes.Keys;
        }

        private void UnavailableDrink()
        {
            _outputProvider("We don't serve that beverage here.");
        }

        internal Action GetRecipe(string drink)
        {
            if (!_recipes.ContainsKey(drink))
            {
                _outputProvider("I do not know of this drink you speak of");
                throw new ArgumentException();
            }

            _recipes.TryGetValue(drink, out Action value);
            return value;
        }

        private void ServeJuice()
        {
            _outputProvider("Here you go a fresh juice.");
        }

        private void ServeBeer()
        {
            _outputProvider("Not so fast cowboy");
            if (!Int32.TryParse(_inputProvider(), out var age))
            {
                HandleInvalidAge();
                return;
            }

            HandleBeerAgeCheck(age);
        }

        private void HandleBeerAgeCheck(int age)
        {
            if (age >= 18)
            {
                _outputProvider("Here you go a cold beer!");
                return;
            }

            _outputProvider("Sorry you are not old enough yet.");
        }

        private void HandleInvalidAge()
        {
            _outputProvider("Could not parse your age soz");
        }

    }
}