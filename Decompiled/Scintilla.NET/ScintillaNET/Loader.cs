using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ScintillaNET;

internal sealed class Loader : ILoader
{
	private readonly nint self;

	private readonly NativeMethods.ILoaderVTable32 loader32;

	private readonly NativeMethods.ILoaderVTable64 loader64;

	private readonly Encoding encoding;

	public unsafe bool AddData(char[] data, int length)
	{
		if (data != null)
		{
			length = Helpers.Clamp(length, 0, data.Length);
			byte[] bytes = Helpers.GetBytes(data, length, encoding, zeroTerminated: false);
			fixed (byte* data2 = bytes)
			{
				if (((IntPtr.Size == 4) ? loader32.AddData(self, data2, bytes.Length) : loader64.AddData(self, data2, bytes.Length)) != 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	public Document ConvertToDocument()
	{
		nint value = ((IntPtr.Size == 4) ? loader32.ConvertToDocument(self) : loader64.ConvertToDocument(self));
		return new Document
		{
			Value = value
		};
	}

	public int Release()
	{
		if (IntPtr.Size != 4)
		{
			return loader64.Release(self);
		}
		return loader32.Release(self);
	}

	public unsafe Loader(nint ptr, Encoding encoding)
	{
		self = ptr;
		this.encoding = encoding;
		nint ptr2 = *(nint*)ptr;
		if (IntPtr.Size == 4)
		{
			loader32 = (NativeMethods.ILoaderVTable32)Marshal.PtrToStructure(ptr2, typeof(NativeMethods.ILoaderVTable32));
		}
		else
		{
			loader64 = (NativeMethods.ILoaderVTable64)Marshal.PtrToStructure(ptr2, typeof(NativeMethods.ILoaderVTable64));
		}
	}
}
