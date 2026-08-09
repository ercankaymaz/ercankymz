using System;

namespace Basler.Pylon;

public interface IArrayParameter : IParameter
{
	void ReadRaw(IntPtr pBuffer, long bufferSize);

	void Read<T>(ref T[] buffer);

	void WriteRaw(IntPtr pBuffer, long bufferSize);

	void Write<T>(T[] buffer);

	long GetLength();
}
