using System;
using Antlr4.Runtime;

namespace Mlo.Examples.Antlr4.DemoApp01
{
    public class SqlLexerErrorListener : IAntlrErrorListener<int>
    {
        #region Member Variables
        private readonly Action<string> _onError;
        #endregion

        #region Constructor
        public SqlLexerErrorListener(Action<string> onError)
        {
            _onError = onError;
        }
        #endregion

        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            _onError?.Invoke(msg);
        }
    }
}
