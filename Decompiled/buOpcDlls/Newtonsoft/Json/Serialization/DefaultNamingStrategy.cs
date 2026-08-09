using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

public class DefaultNamingStrategy : NamingStrategy
{
	[Newtonsoft_002EJson_002ENullableContext(1)]
	protected override string ResolvePropertyName(string name)
	{
		return name;
	}
}
