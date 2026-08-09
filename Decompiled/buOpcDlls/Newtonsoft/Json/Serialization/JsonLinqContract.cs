using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

public class JsonLinqContract : JsonContract
{
	[Newtonsoft_002EJson_002ENullableContext(1)]
	public JsonLinqContract(Type underlyingType)
		: base(underlyingType)
	{
		ContractType = JsonContractType.Linq;
	}
}
