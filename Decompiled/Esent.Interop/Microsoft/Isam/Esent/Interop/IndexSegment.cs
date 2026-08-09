using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public class IndexSegment : IEquatable<IndexSegment>
{
	private readonly string columnName;

	private readonly JET_coltyp coltyp;

	private readonly bool isAscending;

	private readonly bool isASCII;

	public string ColumnName
	{
		[DebuggerStepThrough]
		get
		{
			return columnName;
		}
	}

	public JET_coltyp Coltyp
	{
		[DebuggerStepThrough]
		get
		{
			return coltyp;
		}
	}

	public bool IsAscending
	{
		[DebuggerStepThrough]
		get
		{
			return isAscending;
		}
	}

	public bool IsASCII
	{
		[DebuggerStepThrough]
		get
		{
			return isASCII;
		}
	}

	internal IndexSegment(string name, JET_coltyp coltyp, bool isAscending, bool isASCII)
	{
		columnName = name;
		this.coltyp = coltyp;
		this.isAscending = isAscending;
		this.isASCII = isASCII;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((IndexSegment)obj);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0}{1}({2})", isAscending ? "+" : "-", columnName, coltyp);
	}

	public override int GetHashCode()
	{
		checked
		{
			return columnName.GetHashCode() ^ (unchecked((int)coltyp) * 31) ^ (isAscending ? 65536 : 131072) ^ (isASCII ? 262144 : 524288);
		}
	}

	public bool Equals(IndexSegment other)
	{
		if (other == null)
		{
			return false;
		}
		if (columnName.Equals(other.columnName, StringComparison.OrdinalIgnoreCase) && coltyp == other.coltyp && isAscending == other.isAscending)
		{
			return isASCII == other.isASCII;
		}
		return false;
	}
}
