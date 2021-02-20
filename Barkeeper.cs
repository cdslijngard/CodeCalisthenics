using System;

namespace CodeCalisthenics
{
    internal class Barkeeper
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;
        private readonly RecipeBook _recipeBook;

        public Barkeeper(Func<string> inputProvider, Action<string> outputProvider, RecipeBook recipeBook)
        {
            this._inputProvider = inputProvider;
            this._outputProvider = outputProvider;
            _recipeBook = recipeBook;
        }

        public void AskForDrink()
        {
            _outputProvider($"What do you want to drink? {string.Join(", ", _recipeBook.GetAvailableDrinkNames())}");
            var drink = _inputProvider() ?? string.Empty;

            var recipe = _recipeBook.GetRecipe(drink);
            recipe();
        }
    }
}