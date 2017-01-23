using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Mlo.Examples.Parsers;

namespace Mlo.Examples.Antlr4.DemoApp01
{
    public class Visitor : SqlParserBaseVisitor<Summary>
    {
        #region Base Class Overrides
        public override Summary VisitIdentifier([NotNull] SqlParser.IdentifierContext context)
        {
            return new Summary(identifiers: new List<string> {context.GetText()});
        }

        public override Summary VisitSelect_list([NotNull] SqlParser.Select_listContext context)
        {
            // call the base implementation so that the Identifier nodes get traversed
            return new Summary(selectList: context.GetText())+base.VisitSelect_list(context);
        }

        public override Summary VisitFrom_clause([NotNull] SqlParser.From_clauseContext context)
        {
            return new Summary(fromClause: context.GetText())+base.VisitFrom_clause(context);
        }

        public override Summary VisitWhere_clause([NotNull] SqlParser.Where_clauseContext context)
        {
            return new Summary(whereClause: context.GetText())+base.VisitWhere_clause(context);
        }

        protected override Summary AggregateResult(Summary aggregate, Summary nextResult)
        {
            return aggregate+nextResult;
        }
        #endregion
    }
}
