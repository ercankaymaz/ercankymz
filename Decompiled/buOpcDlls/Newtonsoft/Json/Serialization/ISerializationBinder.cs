using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
public interface ISerializationBinder
{
	Type BindToType([Newtonsoft_002EJson_002ENullable(2)] string assemblyName, string typeName);

	[Newtonsoft_002EJson_002ENullableContext(2)]
	void BindToName([Newtonsoft_002EJson_002ENullable(1)] Type serializedType, out string assemblyName, out string typeName);
}
