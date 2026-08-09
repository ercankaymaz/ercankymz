using System.Runtime.CompilerServices;

namespace Newtonsoft.Json;

public abstract class JsonNameTable
{
	[Newtonsoft_002EJson_002ENullableContext(1)]
	[return: Newtonsoft_002EJson_002ENullable(2)]
	public abstract string Get(char[] key, int start, int length);
}
