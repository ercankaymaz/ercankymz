using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class RootFilter : PathFilter
{
	public static readonly RootFilter Instance = new RootFilter();

	private RootFilter()
	{
	}

	public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Newtonsoft_002EJson_002ENullable(2)] JsonSelectSettings settings)
	{
		return new JToken[1] { root };
	}
}
