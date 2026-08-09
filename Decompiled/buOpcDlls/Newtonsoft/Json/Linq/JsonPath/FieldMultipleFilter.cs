using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq.JsonPath;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class FieldMultipleFilter : PathFilter
{
	internal List<string> Names;

	public FieldMultipleFilter(List<string> names)
	{
		Names = names;
	}

	public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Newtonsoft_002EJson_002ENullable(2)] JsonSelectSettings settings)
	{
		foreach (JToken item in current)
		{
			if (item is JObject o)
			{
				foreach (string name in Names)
				{
					JToken jToken = o[name];
					if (jToken != null)
					{
						yield return jToken;
					}
					if (settings?.ErrorWhenNoMatch ?? false)
					{
						throw new JsonException("Property '{0}' does not exist on JObject.".FormatWith(CultureInfo.InvariantCulture, name));
					}
				}
			}
			else if (settings?.ErrorWhenNoMatch ?? false)
			{
				throw new JsonException("Properties {0} not valid on {1}.".FormatWith(CultureInfo.InvariantCulture, string.Join(", ", Names.Select([Newtonsoft_002EJson_002ENullableContext(0)] (string n) => "'" + n + "'")), item.GetType().Name));
			}
		}
	}
}
