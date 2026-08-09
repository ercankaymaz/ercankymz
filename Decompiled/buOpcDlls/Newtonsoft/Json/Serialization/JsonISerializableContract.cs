using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

public class JsonISerializableContract : JsonContainerContract
{
	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
	[field: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
	public ObjectConstructor<object> ISerializableCreator
	{
		[return: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
		get;
		[param: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })]
		set;
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public JsonISerializableContract(Type underlyingType)
		: base(underlyingType)
	{
		ContractType = JsonContractType.Serializable;
	}
}
