using System.Collections;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

internal interface IWrappedCollection : IList, ICollection, IEnumerable
{
	[Newtonsoft_002EJson_002ENullable(1)]
	object UnderlyingCollection
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get;
	}
}
