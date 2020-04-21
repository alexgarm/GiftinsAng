using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Giftins.Core.Infrastructure
{
    public static class TypeMember<T>
    {
        private const string expressionCannotBeNullMessage = "The expression cannot be null.";
        private const string invalidExpressionMessage = "Invalid expression.";

        public static string GetPropertyName<TProp>(Expression<Func<T, TProp>> expression)
        {
            if (expression == null)
                throw new ArgumentException(expressionCannotBeNullMessage);

            // Reference type property or field
            if (expression.Body is MemberExpression memberExp)
                return memberExp.Member.Name;

            // Reference type method
            if (expression.Body is MethodCallExpression methodCallExp)
                return methodCallExp.Method.Name;

            // Property, field of method returning value type
            if (expression.Body is UnaryExpression unaryExp)
                return GetMemberName(unaryExp);

            throw new ArgumentException(invalidExpressionMessage);
        }

        private static string GetMemberName(UnaryExpression unaryExpression)
        {
            if (unaryExpression.Operand is MethodCallExpression methodExpression)
                return methodExpression.Method.Name;

            return ((MemberExpression)unaryExpression.Operand).Member.Name;
        }
    }
}
