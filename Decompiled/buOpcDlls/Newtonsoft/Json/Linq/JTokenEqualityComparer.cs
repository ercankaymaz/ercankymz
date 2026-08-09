using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq;

public class JTokenEqualityComparer : IEqualityComparer<JToken>
{
	[Newtonsoft_002EJson_002ENullableContext(2)]
	public bool Equals(JToken x, JToken y)
	{
		return JToken.DeepEquals(x, y);
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public int GetHashCode(JToken obj)
	{
		return obj?.GetDeepHashCode() ?? 0;
	}
}
