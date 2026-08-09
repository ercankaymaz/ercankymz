using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public class ArrayBufferFactory<T> : IBufferFactory
{
	public virtual void AllocateBuffer(long bufferSize, ref object createdPinnedObject, ref IntPtr createdPinnedBuffer, ref object bufferUserData)
	{
		long num = (uint)System.Runtime.CompilerServices.Unsafe.SizeOf<T>();
		GCHandle gCHandle = GCHandle.Alloc(createdPinnedObject = new T[(int)((num + bufferSize - 1) / num)], GCHandleType.Pinned);
		IntPtr intPtr = gCHandle.AddrOfPinnedObject();
		createdPinnedBuffer = intPtr;
		bufferUserData = gCHandle;
	}

	public virtual void FreeBuffer(object createdPinnedObject, IntPtr createdPinnedBuffer, object bufferUserData)
	{
		if (null != bufferUserData)
		{
			ValueType valueType = (ValueType)((bufferUserData is GCHandle) ? bufferUserData : null);
			if (null != valueType)
			{
				((GCHandle)valueType).Free();
			}
		}
	}
}
