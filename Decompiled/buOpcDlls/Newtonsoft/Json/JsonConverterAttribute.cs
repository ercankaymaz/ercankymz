using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Parameter, AllowMultiple = false)]
public sealed class JsonConverterAttribute : Attribute
{
	private readonly Type _converterType;

	public Type ConverterType => _converterType;

	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
	[field: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
	public object[] ConverterParameters
	{
		[return: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
		get;
	}

	public JsonConverterAttribute(Type converterType)
	{
		if (converterType == null)
		{
			throw new ArgumentNullException("converterType");
		}
		_converterType = converterType;
	}

	public JsonConverterAttribute(Type converterType, params object[] converterParameters)
		: this(converterType)
	{
		ConverterParameters = converterParameters;
	}
}
