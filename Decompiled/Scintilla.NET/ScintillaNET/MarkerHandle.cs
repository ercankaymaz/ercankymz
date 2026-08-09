using System;

namespace ScintillaNET;

public struct MarkerHandle
{
	internal nint Value;

	public static readonly MarkerHandle Zero;

	public override bool Equals(object obj)
	{
		if (obj is nint)
		{
			return Value == ((MarkerHandle)obj).Value;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)Value).GetHashCode();
	}

	public static bool operator ==(MarkerHandle a, MarkerHandle b)
	{
		return a.Value == b.Value;
	}

	public static bool operator !=(MarkerHandle a, MarkerHandle b)
	{
		return a.Value != b.Value;
	}
}
