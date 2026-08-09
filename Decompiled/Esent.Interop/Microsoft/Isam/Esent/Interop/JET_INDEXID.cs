using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct JET_INDEXID : IEquatable<JET_INDEXID>
{
	internal uint CbStruct;

	internal IntPtr IndexId1;

	internal uint IndexId2;

	internal uint IndexId3;

	private static readonly uint TheSizeOfIndexId = checked((uint)Marshal.SizeOf(typeof(JET_INDEXID)));

	internal static uint SizeOfIndexId
	{
		[DebuggerStepThrough]
		get
		{
			return TheSizeOfIndexId;
		}
	}

	public static bool operator ==(JET_INDEXID lhs, JET_INDEXID rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(JET_INDEXID lhs, JET_INDEXID rhs)
	{
		return !(lhs == rhs);
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_INDEXID)obj);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_INDEXID(0x{0:x}:0x{1:x}:0x{2:x})", IndexId1, IndexId2, IndexId3);
	}

	public override int GetHashCode()
	{
		return CbStruct.GetHashCode() ^ IndexId1.GetHashCode() ^ IndexId2.GetHashCode() ^ IndexId3.GetHashCode();
	}

	public bool Equals(JET_INDEXID other)
	{
		if (CbStruct == other.CbStruct && IndexId1 == other.IndexId1 && IndexId2 == other.IndexId2)
		{
			return IndexId3 == other.IndexId3;
		}
		return false;
	}
}
