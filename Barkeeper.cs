using System;

namespace CodeCalisthenics
{
    internal class Barkeeper
    {
        private Action<string> _outputProvider;
        private Func<string> _inputProvider;

        public Barkeeper(Action<string> writeLine, Func<string> ouputProvider)
        {
            this._outputProvider = writeLine;
            this._inputProvider = ouputProvider;
        }
    }
}