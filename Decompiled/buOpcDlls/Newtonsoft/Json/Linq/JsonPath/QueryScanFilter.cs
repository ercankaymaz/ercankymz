using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class QueryScanFilter : PathFilter
{
	internal QueryExpression Expression;

	public QueryScanFilter(QueryExpression expression)
	{
		Expression = expression;
	}

	public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Newtonsoft_002EJson_002ENullable(2)] JsonSelectSettings settings)
	{
		foreach (JToken item in current)
		{
			if (item is JContainer jContainer)
			{
				foreach (JToken item2 in jContainer.DescendantsAndSelf())
				{
					if (Expression.IsMatch(root, item2, settings))
					{
						yield return item2;
					}
				}
			}
			else if (Expression.IsMatch(root, item, settings))
			{
				yield return item;
			}
		}
	}
}
