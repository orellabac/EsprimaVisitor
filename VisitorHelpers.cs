using System.Collections.Generic;
using Esprima.Ast;

namespace JavascriptProcessor
{
    public static class VisitorHelpers
    {
        public static Identifier AsId(this Expression expr)
        {
            return expr as Identifier;
        }

        public static IEnumerable<Expression> AccessParts(this MemberExpression member)
        {
            if (member.Object is Identifier)
                yield return member.Object;
            else if (member.Object is MemberExpression)
                foreach (var part in ((MemberExpression)member.Object).AccessParts())
                {
                    yield return part;
                }

            yield return member.Property;

        }
    }
}
