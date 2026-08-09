using System.Runtime.CompilerServices;

namespace Newtonsoft.Json;

[Newtonsoft_002EJson_002ENullableContext(1)]
public interface IArrayPool<[Newtonsoft_002EJson_002ENullable(2)] T>
{
	T[] Rent(int minimumLength);

	void Return([Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1 })] T[] array);
}
