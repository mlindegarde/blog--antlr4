using System;
using Antlr4.Runtime;

namespace Mlo.Examples.Antlr4.DemoApp01
{
   public class SqlParserErrorListener : IAntlrErrorListener<IToken>
    {
        #region Member Variables
        private readonly Action<string> _onError;
        #endregion

        #region Constructor
        public SqlParserErrorListener(Action<string> onError)
        {
            _onError = onError;
        }
        #endregion

        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            _onError?.Invoke(msg);
        }
    }
}
