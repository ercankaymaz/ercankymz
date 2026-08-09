using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class NoThrowExpressionVisitor : ExpressionVisitor
{
	internal static readonly object ErrorResult = new object();

	protected override Expression VisitConditional(ConditionalExpression node)
	{
		if (node.IfFalse.NodeType == ExpressionType.Throw)
		{
			return Expression.Condition(node.Test, node.IfTrue, Expression.Constant(ErrorResult));
		}
		return base.VisitConditional(node);
	}
}
