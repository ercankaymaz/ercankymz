using System;

namespace ScintillaNET;

public struct Document
{
	internal nint Value;

	public static readonly Document Empty;

	public override bool Equals(object obj)
	{
		if (obj is nint)
		{
			return Value == ((Document)obj).Value;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)Value).GetHashCode();
	}

	public static bool operator ==(Document a, Document b)
	{
		return a.Value == b.Value;
	}

	public static bool operator !=(Document a, Document b)
	{
		return a.Value != b.Value;
	}
}
