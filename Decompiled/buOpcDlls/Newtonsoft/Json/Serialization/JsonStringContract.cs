using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

public class JsonStringContract : JsonPrimitiveContract
{
	[Newtonsoft_002EJson_002ENullableContext(1)]
	public JsonStringContract(Type underlyingType)
		: base(underlyingType)
	{
		ContractType = JsonContractType.String;
	}
}
