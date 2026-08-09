using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ScintillaNET;

internal sealed class NativeMemoryStream : Stream
{
	private int capacity;

	private int position;

	private int length;

	public override bool CanRead
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public override bool CanSeek => true;

	public override bool CanWrite => true;

	public bool FreeOnDispose { get; set; }

	public override long Length => length;

	public nint Pointer { get; private set; }

	public override long Position
	{
		get
		{
			return position;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (FreeOnDispose && Pointer != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(Pointer);
			Pointer = IntPtr.Zero;
		}
		base.Dispose(disposing);
	}

	public override void Flush()
	{
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotImplementedException();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		if (origin == SeekOrigin.Begin)
		{
			position = (int)offset;
			return position;
		}
		throw new NotImplementedException();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (position + count > capacity)
		{
			int num = position + count;
			int num2 = capacity * 2;
			if (num2 < num)
			{
				num2 = num;
			}
			nint num3 = Marshal.AllocHGlobal(num2);
			NativeMethods.MoveMemory(num3, Pointer, length);
			Marshal.FreeHGlobal(Pointer);
			Pointer = num3;
			capacity = num2;
		}
		Marshal.Copy(buffer, offset, (nint)((long)Pointer + (long)position), count);
		position += count;
		length = Math.Max(length, position);
	}

	public NativeMemoryStream(int capacity)
	{
		if (capacity < 4)
		{
			capacity = 4;
		}
		this.capacity = capacity;
		Pointer = Marshal.AllocHGlobal(capacity);
		FreeOnDispose = true;
	}
}
