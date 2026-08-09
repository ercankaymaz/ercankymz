using System.Runtime.InteropServices;

namespace Opc.Ua.Test;

[ComVisible(true)]
public interface IRandomSource
{
	void NextBytes(byte[] bytes, int offset, int count);

	int NextInt32(int max);
}
