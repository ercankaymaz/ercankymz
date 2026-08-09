using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq;

[Newtonsoft_002EJson_002ENullableContext(1)]
public interface IJEnumerable<[Newtonsoft_002EJson_002ENullable(0)] out T> : IEnumerable<T>, IEnumerable where T : JToken
{
	IJEnumerable<JToken> this[object key] { get; }
}
