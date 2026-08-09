using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop.Vista;

[Serializable]
[StructLayout(LayoutKind.Auto)]
public struct JET_RECSIZE : IEquatable<JET_RECSIZE>
{
	private long userData;

	private long userLongValueData;

	private long overhead;

	private long longValueOverhead;

	private long numNonTaggedColumns;

	private long numTaggedColumns;

	private long numLongValues;

	private long numMultiValues;

	private long numCompressedColumns;

	private long userDataAfterCompression;

	private long userLongValueDataCompressed;

	public long cbData
	{
		[DebuggerStepThrough]
		get
		{
			return userData;
		}
		internal set
		{
			userData = value;
		}
	}

	public long cbLongValueData
	{
		[DebuggerStepThrough]
		get
		{
			return userLongValueData;
		}
		internal set
		{
			userLongValueData = value;
		}
	}

	public long cbOverhead
	{
		[DebuggerStepThrough]
		get
		{
			return overhead;
		}
		internal set
		{
			overhead = value;
		}
	}

	public long cbLongValueOverhead
	{
		[DebuggerStepThrough]
		get
		{
			return longValueOverhead;
		}
		internal set
		{
			longValueOverhead = value;
		}
	}

	public long cNonTaggedColumns
	{
		[DebuggerStepThrough]
		get
		{
			return numNonTaggedColumns;
		}
		internal set
		{
			numNonTaggedColumns = value;
		}
	}

	public long cTaggedColumns
	{
		[DebuggerStepThrough]
		get
		{
			return numTaggedColumns;
		}
		internal set
		{
			numTaggedColumns = value;
		}
	}

	public long cLongValues
	{
		[DebuggerStepThrough]
		get
		{
			return numLongValues;
		}
		internal set
		{
			numLongValues = value;
		}
	}

	public long cMultiValues
	{
		[DebuggerStepThrough]
		get
		{
			return numMultiValues;
		}
		internal set
		{
			numMultiValues = value;
		}
	}

	public long cCompressedColumns
	{
		[DebuggerStepThrough]
		get
		{
			return numCompressedColumns;
		}
		internal set
		{
			numCompressedColumns = value;
		}
	}

	public long cbDataCompressed
	{
		[DebuggerStepThrough]
		get
		{
			return userDataAfterCompression;
		}
		internal set
		{
			userDataAfterCompression = value;
		}
	}

	public long cbLongValueDataCompressed
	{
		[DebuggerStepThrough]
		get
		{
			return userLongValueDataCompressed;
		}
		internal set
		{
			userLongValueDataCompressed = value;
		}
	}

	public static JET_RECSIZE Add(JET_RECSIZE s1, JET_RECSIZE s2)
	{
		return checked(new JET_RECSIZE
		{
			cbData = s1.cbData + s2.cbData,
			cbDataCompressed = s1.cbDataCompressed + s2.cbDataCompressed,
			cbLongValueData = s1.cbLongValueData + s2.cbLongValueData,
			cbLongValueDataCompressed = s1.cbLongValueDataCompressed + s2.cbLongValueDataCompressed,
			cbLongValueOverhead = s1.cbLongValueOverhead + s2.cbLongValueOverhead,
			cbOverhead = s1.cbOverhead + s2.cbOverhead,
			cCompressedColumns = s1.cCompressedColumns + s2.cCompressedColumns,
			cLongValues = s1.cLongValues + s2.cLongValues,
			cMultiValues = s1.cMultiValues + s2.cMultiValues,
			cNonTaggedColumns = s1.cNonTaggedColumns + s2.cNonTaggedColumns,
			cTaggedColumns = s1.cTaggedColumns + s2.cTaggedColumns
		});
	}

	public static JET_RECSIZE operator +(JET_RECSIZE left, JET_RECSIZE right)
	{
		return Add(left, right);
	}

	public static JET_RECSIZE Subtract(JET_RECSIZE s1, JET_RECSIZE s2)
	{
		return checked(new JET_RECSIZE
		{
			cbData = s1.cbData - s2.cbData,
			cbDataCompressed = s1.cbDataCompressed - s2.cbDataCompressed,
			cbLongValueData = s1.cbLongValueData - s2.cbLongValueData,
			cbLongValueDataCompressed = s1.cbLongValueDataCompressed - s2.cbLongValueDataCompressed,
			cbLongValueOverhead = s1.cbLongValueOverhead - s2.cbLongValueOverhead,
			cbOverhead = s1.cbOverhead - s2.cbOverhead,
			cCompressedColumns = s1.cCompressedColumns - s2.cCompressedColumns,
			cLongValues = s1.cLongValues - s2.cLongValues,
			cMultiValues = s1.cMultiValues - s2.cMultiValues,
			cNonTaggedColumns = s1.cNonTaggedColumns - s2.cNonTaggedColumns,
			cTaggedColumns = s1.cTaggedColumns - s2.cTaggedColumns
		});
	}

	public static JET_RECSIZE operator -(JET_RECSIZE left, JET_RECSIZE right)
	{
		return Subtract(left, right);
	}

	public static bool operator ==(JET_RECSIZE lhs, JET_RECSIZE rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(JET_RECSIZE lhs, JET_RECSIZE rhs)
	{
		return !(lhs == rhs);
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_RECSIZE)obj);
	}

	public override int GetHashCode()
	{
		long num = cbData ^ (cbDataCompressed << 1) ^ (cbLongValueData << 2) ^ (cbDataCompressed << 3) ^ (cbLongValueDataCompressed << 4) ^ (cbOverhead << 5) ^ (cbLongValueOverhead << 6) ^ (cNonTaggedColumns << 7) ^ (cTaggedColumns << 8) ^ (cLongValues << 9) ^ (cMultiValues << 10) ^ (cCompressedColumns << 11);
		return checked((int)(num & 0xFFFFFFFFu) ^ (int)(num >> 32));
	}

	public bool Equals(JET_RECSIZE other)
	{
		if (cbData == other.cbData && cbLongValueData == other.cbLongValueData && cbOverhead == other.cbOverhead && cbLongValueOverhead == other.cbLongValueOverhead && cNonTaggedColumns == other.cNonTaggedColumns && cTaggedColumns == other.cTaggedColumns && cLongValues == other.cLongValues && cMultiValues == other.cMultiValues && cCompressedColumns == other.cCompressedColumns && cbDataCompressed == other.cbDataCompressed)
		{
			return cbLongValueDataCompressed == other.cbLongValueDataCompressed;
		}
		return false;
	}

	internal void SetFromNativeRecsize(NATIVE_RECSIZE value)
	{
		checked
		{
			cbData = (long)value.cbData;
			cbDataCompressed = (long)value.cbData;
			cbLongValueData = (long)value.cbLongValueData;
			cbLongValueDataCompressed = (long)value.cbLongValueData;
			cbLongValueOverhead = (long)value.cbLongValueOverhead;
			cbOverhead = (long)value.cbOverhead;
			cCompressedColumns = 0L;
			cLongValues = (long)value.cLongValues;
			cMultiValues = (long)value.cMultiValues;
			cNonTaggedColumns = (long)value.cNonTaggedColumns;
			cTaggedColumns = (long)value.cTaggedColumns;
		}
	}

	internal void SetFromNativeRecsize(NATIVE_RECSIZE2 value)
	{
		checked
		{
			cbData = (long)value.cbData;
			cbDataCompressed = (long)value.cbDataCompressed;
			cbLongValueData = (long)value.cbLongValueData;
			cbLongValueDataCompressed = (long)value.cbLongValueDataCompressed;
			cbLongValueOverhead = (long)value.cbLongValueOverhead;
			cbOverhead = (long)value.cbOverhead;
			cCompressedColumns = (long)value.cCompressedColumns;
			cLongValues = (long)value.cLongValues;
			cMultiValues = (long)value.cMultiValues;
			cNonTaggedColumns = (long)value.cNonTaggedColumns;
			cTaggedColumns = (long)value.cTaggedColumns;
		}
	}

	internal NATIVE_RECSIZE GetNativeRecsize()
	{
		return new NATIVE_RECSIZE
		{
			cbData = (ulong)cbData,
			cbLongValueData = (ulong)cbLongValueData,
			cbLongValueOverhead = (ulong)cbLongValueOverhead,
			cbOverhead = (ulong)cbOverhead,
			cLongValues = (ulong)cLongValues,
			cMultiValues = (ulong)cMultiValues,
			cNonTaggedColumns = (ulong)cNonTaggedColumns,
			cTaggedColumns = (ulong)cTaggedColumns
		};
	}

	internal NATIVE_RECSIZE2 GetNativeRecsize2()
	{
		return new NATIVE_RECSIZE2
		{
			cbData = (ulong)cbData,
			cbDataCompressed = (ulong)cbDataCompressed,
			cbLongValueData = (ulong)cbLongValueData,
			cbLongValueDataCompressed = (ulong)cbLongValueDataCompressed,
			cbLongValueOverhead = (ulong)cbLongValueOverhead,
			cbOverhead = (ulong)cbOverhead,
			cCompressedColumns = (ulong)cCompressedColumns,
			cLongValues = (ulong)cLongValues,
			cMultiValues = (ulong)cMultiValues,
			cNonTaggedColumns = (ulong)cNonTaggedColumns,
			cTaggedColumns = (ulong)cTaggedColumns
		};
	}
}
