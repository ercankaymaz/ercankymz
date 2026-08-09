using System;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop.Implementation;

[StructLayout(LayoutKind.Auto)]
internal struct GCHandleCollection : IDisposable
{
	private GCHandle[] handles;

	private int count;

	public void Dispose()
	{
		if (handles != null)
		{
			for (int i = 0; i < count; i = checked(i + 1))
			{
				handles[i].Free();
			}
			handles = null;
		}
	}

	public IntPtr Add(object value)
	{
		if (value == null)
		{
			return IntPtr.Zero;
		}
		checked
		{
			if (handles == null)
			{
				handles = new GCHandle[4];
			}
			else if (count == handles.Length)
			{
				Array.Resize(ref handles, count * 2);
			}
			GCHandle gCHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
			handles[count++] = gCHandle;
			return gCHandle.AddrOfPinnedObject();
		}
	}

	public void SetCapacity(int capacity)
	{
		if (handles == null)
		{
			handles = new GCHandle[capacity];
		}
	}
}
