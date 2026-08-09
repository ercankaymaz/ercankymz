using System;

namespace Basler.Pylon;

public interface IRawParameter : IParameter
{
	void ReadRaw<T>(long address, ref T[] buffer, int startIndex, int length);

	void ReadRaw(long address, IntPtr pBuffer, long bufferSize);

	void WriteRaw<T>(long address, T[] buffer, int startIndex, int length);

	void WriteRaw(long address, IntPtr pBuffer, long bufferSize);
}
