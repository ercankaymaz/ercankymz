using System.Collections;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

internal interface IWrappedDictionary : IDictionary, ICollection, IEnumerable
{
	[Newtonsoft_002EJson_002ENullable(1)]
	object UnderlyingDictionary
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get;
	}
}
