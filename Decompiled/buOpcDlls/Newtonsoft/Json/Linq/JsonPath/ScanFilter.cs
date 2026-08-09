using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq.JsonPath;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class ScanFilter : PathFilter
{
	internal string Name;

	public ScanFilter(string name)
	{
		Name = name;
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, [Newtonsoft_002EJson_002ENullable(2)] JsonSelectSettings settings)
	{
		foreach (JToken c in current)
		{
			if (Name == null)
			{
				yield return c;
			}
			JToken value = c;
			while (true)
			{
				JContainer container = value as JContainer;
				value = PathFilter.GetNextScanValue(c, container, value);
				if (value == null)
				{
					break;
				}
				if (value is JProperty jProperty)
				{
					if (jProperty.Name == Name)
					{
						yield return jProperty.Value;
					}
				}
				else if (Name == null)
				{
					yield return value;
				}
			}
		}
	}
}
