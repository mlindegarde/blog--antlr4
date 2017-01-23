using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mlo.Examples.Antlr4.DemoApp01
{
    public class Summary
    {
        #region Properties
        public string SelectList {get; private set;}
        public string FromClause {get; private set;}
        public string WhereClause {get; private set;}
        public IEnumerable<string> Identifiers {get; private set;}
        #endregion

        #region Constructor
        public Summary(string selectList = null, string fromClause = null, string whereClause = null, IEnumerable<string> identifiers = null)
        {
            SelectList = selectList;
            FromClause = fromClause;
            WhereClause = whereClause;
            Identifiers = identifiers ?? new List<string>();
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return new StringBuilder()
                .Append($"SQL Statement Summary{Environment.NewLine}")
                .Append($"-----------------------------{Environment.NewLine}")
                .Append($"SELECT List: {SelectList}{Environment.NewLine}")
                .Append($"FROM Clause: {FromClause}{Environment.NewLine}")
                .Append($"WHERE Clause: {WhereClause}{Environment.NewLine}")
                .Append($"-----------------------------{Environment.NewLine}")
                .Append($"Identifiers: {String.Join(", ", Identifiers)}{Environment.NewLine}")
                .ToString();
        }
        #endregion

        #region Operators
        public static Summary operator + (Summary summaryA, Summary summaryB)
        {
            Summary a = summaryA ?? new Summary();
            Summary b = summaryB ?? new Summary();

            return new Summary
            {
                SelectList = a.SelectList ?? b.SelectList,
                FromClause = a.FromClause ?? b.FromClause,
                WhereClause = a.WhereClause ?? b.WhereClause,
                Identifiers = a.Identifiers.Concat(b.Identifiers)
            };
        }
        #endregion
    }
}
