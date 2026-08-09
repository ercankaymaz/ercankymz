using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
public sealed class JsonDictionaryAttribute : JsonContainerAttribute
{
	public JsonDictionaryAttribute()
	{
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public JsonDictionaryAttribute(string id)
		: base(id)
	{
	}
}
