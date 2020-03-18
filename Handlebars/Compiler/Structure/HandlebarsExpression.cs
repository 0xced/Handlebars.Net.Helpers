using System.Linq.Expressions;
using System.Collections.Generic;

namespace HandlebarsDotNet.Compiler
{
    internal enum HandlebarsExpressionType
    {
        StaticExpression = 6000,
        StatementExpression = 6001,
        BlockExpression = 6002,
        HelperExpression = 6003,
        PathExpression = 6004,
        IteratorExpression = 6005,
        DeferredSection = 6006,
        PartialExpression = 6007,
        BoolishExpression = 6008,
        SubExpression = 6009,
        HashParameterAssignmentExpression = 6010,
        HashParametersExpression = 6011,
        CommentExpression = 6012
    }

    internal abstract class HandlebarsExpression : Expression
    {
        public static HelperExpression Helper(string helperName, IEnumerable<Expression> arguments, bool isRaw = false)
        {
            return new HelperExpression(helperName, arguments, isRaw);
        }

        public static HelperExpression Helper(string helperName, bool isRaw = false)
        {
            return new HelperExpression(helperName, isRaw);
        }

        public static BlockHelperExpression BlockHelper(
            string helperName,
            IEnumerable<Expression> arguments,
            Expression body,
            Expression inversion,
            bool isRaw = false)
        {
            return new BlockHelperExpression(helperName, arguments, body, inversion, isRaw);
        }

        public static PathExpression Path(string path)
        {
            return new PathExpression(path);
        }

        public static StaticExpression Static(string value)
        {
            return new StaticExpression(value);
        }

        public static StatementExpression Statement(Expression body, bool isEscaped, bool trimBefore, bool trimAfter)
        {
            return new StatementExpression(body, isEscaped, trimBefore, trimAfter);
        }

        public static IteratorExpression Iterator(
            Expression sequence,
            Expression template)
        {
            return new IteratorExpression(sequence, template);
        }

        public static IteratorExpression Iterator(
            Expression sequence,
            Expression template,
            Expression ifEmpty)
        {
            return new IteratorExpression(sequence, template, ifEmpty);
        }

        public static DeferredSectionExpression DeferredSection(
            PathExpression path,
            BlockExpression body,
            BlockExpression inversion)
        {
            return new DeferredSectionExpression(path, body, inversion);
        }

        public static PartialExpression Partial(Expression partialName)
        {
            return Partial(partialName, null);
        }

        public static PartialExpression Partial(Expression partialName, Expression argument)
        {
            return new PartialExpression(partialName, argument, null);
        }

        public static PartialExpression Partial(Expression partialName, Expression argument, Expression fallback)
        {
            return new PartialExpression(partialName, argument, fallback);
        }

        public static BoolishExpression Boolish(Expression condition)
        {
            return new BoolishExpression(condition);
        }

        public static SubExpressionExpression SubExpression(Expression expression)
        {
            return new SubExpressionExpression(expression);
        }

        public static HashParameterAssignmentExpression HashParameterAssignmentExpression(string name)
        {
            return new HashParameterAssignmentExpression(name);
        }

        public static HashParametersExpression HashParametersExpression(Dictionary<string, Expression> parameters)
        {
            return new HashParametersExpression(parameters);
        }

        public static CommentExpression Comment(string value)
        {
            return new CommentExpression(value);
        }
    }
}

