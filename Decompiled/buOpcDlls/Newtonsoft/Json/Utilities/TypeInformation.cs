using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class TypeInformation
{
	public Type Type { get; }

	public PrimitiveTypeCode TypeCode { get; }

	public TypeInformation(Type type, PrimitiveTypeCode typeCode)
	{
		Type = type;
		TypeCode = typeCode;
	}
}
