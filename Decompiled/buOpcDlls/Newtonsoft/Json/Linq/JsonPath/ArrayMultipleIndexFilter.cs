using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class ArrayMultipleIndexFilter : PathFilter
{
	internal List<int> Indexes;

	public ArrayMultipleIndexFilter(List<int> indexes)
	{
		Indexes = indexes;
	}

	public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Newtonsoft_002EJson_002ENullable(2)] JsonSelectSettings settings)
	{
		foreach (JToken t in current)
		{
			foreach (int index in Indexes)
			{
				JToken tokenIndex = PathFilter.GetTokenIndex(t, settings, index);
				if (tokenIndex != null)
				{
					yield return tokenIndex;
				}
			}
		}
	}
}
