using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal abstract class QueryExpression
{
	internal QueryOperator Operator;

	public QueryExpression(QueryOperator @operator)
	{
		Operator = @operator;
	}

	public bool IsMatch(JToken root, JToken t)
	{
		return IsMatch(root, t, null);
	}

	public abstract bool IsMatch(JToken root, JToken t, [Newtonsoft_002EJson_002ENullable(2)] JsonSelectSettings settings);
}
