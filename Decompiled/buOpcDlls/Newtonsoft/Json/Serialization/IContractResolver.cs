using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
public interface IContractResolver
{
	JsonContract ResolveContract(Type type);
}
