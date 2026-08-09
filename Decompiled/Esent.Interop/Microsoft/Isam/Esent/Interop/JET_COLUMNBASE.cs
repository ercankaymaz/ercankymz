using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public sealed class JET_COLUMNBASE : IEquatable<JET_COLUMNBASE>
{
	public JET_coltyp coltyp { get; internal set; }

	public JET_CP cp { get; internal set; }

	public int cbMax { get; internal set; }

	public ColumndefGrbit grbit { get; internal set; }

	public JET_COLUMNID columnid { get; internal set; }

	public string szBaseTableName { get; internal set; }

	public string szBaseColumnName { get; internal set; }

	internal JET_COLUMNBASE()
	{
	}

	internal JET_COLUMNBASE(NATIVE_COLUMNBASE value)
	{
		coltyp = (JET_coltyp)checked((int)value.coltyp);
		cp = (JET_CP)value.cp;
		cbMax = checked((int)value.cbMax);
		grbit = (ColumndefGrbit)checked((int)value.grbit);
		columnid = new JET_COLUMNID
		{
			Value = value.columnid
		};
		szBaseTableName = StringCache.TryToIntern(value.szBaseTableName);
		szBaseColumnName = StringCache.TryToIntern(value.szBaseColumnName);
	}

	internal JET_COLUMNBASE(NATIVE_COLUMNBASE_WIDE value)
	{
		coltyp = (JET_coltyp)checked((int)value.coltyp);
		cp = (JET_CP)value.cp;
		cbMax = checked((int)value.cbMax);
		grbit = (ColumndefGrbit)checked((int)value.grbit);
		columnid = new JET_COLUMNID
		{
			Value = value.columnid
		};
		szBaseTableName = StringCache.TryToIntern(value.szBaseTableName);
		szBaseColumnName = StringCache.TryToIntern(value.szBaseColumnName);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_COLUMNBASE({0},{1})", coltyp, grbit);
	}

	public override int GetHashCode()
	{
		return Util.CalculateHashCode(new int[7]
		{
			coltyp.GetHashCode(),
			cp.GetHashCode(),
			cbMax,
			grbit.GetHashCode(),
			columnid.GetHashCode(),
			szBaseTableName.GetHashCode(),
			szBaseColumnName.GetHashCode()
		});
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_COLUMNBASE)obj);
	}

	public bool Equals(JET_COLUMNBASE other)
	{
		if (other == null)
		{
			return false;
		}
		if (coltyp == other.coltyp && cp == other.cp && cbMax == other.cbMax && columnid == other.columnid && grbit == other.grbit && string.Equals(szBaseTableName, other.szBaseTableName, StringComparison.Ordinal))
		{
			return string.Equals(szBaseColumnName, other.szBaseColumnName, StringComparison.Ordinal);
		}
		return false;
	}
}
