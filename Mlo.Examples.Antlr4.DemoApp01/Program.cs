using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Mlo.Examples.Parsers;

namespace Mlo.Examples.Antlr4.DemoApp01
{
    public class Program
    {
        private void Run(string sql)
        {
            SqlLexer lexer = new SqlLexer(new AntlrInputStream(sql));

            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new SqlLexerErrorListener(msg => OnError("Lexer", msg)));

            CommonTokenStream tokens = new CommonTokenStream(lexer);
            SqlParser parser = new SqlParser(tokens);

            parser.RemoveErrorListeners();
            parser.AddErrorListener(new SqlParserErrorListener(msg => OnError("Parser", msg)));

            IParseTree tree = parser.sql();

            Console.WriteLine(
                parser.NumberOfSyntaxErrors == 0
                    ? new Visitor().Visit(tree).ToString()
                    : tree.ToStringTree(parser));
        }

        private void OnError(string source, string message)
        {
            Console.WriteLine($"{source} - {message}");
        }

        static void Main()
        {
            new Program().Run("SELECT car AS Ford FROM Example WHERE foo = 'bar';");

            Console.Write("Press ENTER to continue:");
            Console.ReadLine();
        }
    }
}
