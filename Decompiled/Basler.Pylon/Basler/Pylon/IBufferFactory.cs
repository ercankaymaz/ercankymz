using System;

namespace Basler.Pylon;

public interface IBufferFactory
{
	void AllocateBuffer(long bufferSize, ref object createdPinnedObject, ref IntPtr createdPinnedBuffer, ref object bufferUserData);

	void FreeBuffer(object createdPinnedObject, IntPtr createdPinnedBuffer, object bufferUserData);
}
