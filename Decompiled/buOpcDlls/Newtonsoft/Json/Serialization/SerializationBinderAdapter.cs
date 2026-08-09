using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class SerializationBinderAdapter : ISerializationBinder
{
	public readonly SerializationBinder SerializationBinder;

	public SerializationBinderAdapter(SerializationBinder serializationBinder)
	{
		SerializationBinder = serializationBinder;
	}

	public Type BindToType([Newtonsoft_002EJson_002ENullable(2)] string assemblyName, string typeName)
	{
		return SerializationBinder.BindToType(assemblyName, typeName);
	}

	[Newtonsoft_002EJson_002ENullableContext(2)]
	public void BindToName([Newtonsoft_002EJson_002ENullable(1)] Type serializedType, out string assemblyName, out string typeName)
	{
		SerializationBinder.BindToName(serializedType, out assemblyName, out typeName);
	}
}
