using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
public sealed class JsonArrayAttribute : JsonContainerAttribute
{
	private bool _allowNullItems;

	public bool AllowNullItems
	{
		get
		{
			return _allowNullItems;
		}
		set
		{
			_allowNullItems = value;
		}
	}

	public JsonArrayAttribute()
	{
	}

	public JsonArrayAttribute(bool allowNullItems)
	{
		_allowNullItems = allowNullItems;
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public JsonArrayAttribute(string id)
		: base(id)
	{
	}
}
