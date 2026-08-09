using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class JET_COLUMNDEF : IContentEquatable<JET_COLUMNDEF>, IDeepCloneable<JET_COLUMNDEF>
{
	private JET_coltyp columnType;

	private JET_CP codePage;

	private int maxSize;

	[NonSerialized]
	private JET_COLUMNID id;

	private ColumndefGrbit options;

	public JET_coltyp coltyp
	{
		[DebuggerStepThrough]
		get
		{
			return columnType;
		}
		set
		{
			columnType = value;
		}
	}

	public JET_CP cp
	{
		[DebuggerStepThrough]
		get
		{
			return codePage;
		}
		set
		{
			codePage = value;
		}
	}

	public int cbMax
	{
		[DebuggerStepThrough]
		get
		{
			return maxSize;
		}
		set
		{
			maxSize = value;
		}
	}

	public ColumndefGrbit grbit
	{
		[DebuggerStepThrough]
		get
		{
			return options;
		}
		set
		{
			options = value;
		}
	}

	public JET_COLUMNID columnid
	{
		[DebuggerStepThrough]
		get
		{
			return id;
		}
		internal set
		{
			id = value;
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_COLUMNDEF({0},{1})", columnType, options);
	}

	public bool ContentEquals(JET_COLUMNDEF other)
	{
		if (other == null)
		{
			return false;
		}
		if (columnType == other.columnType && codePage == other.codePage && maxSize == other.maxSize && id == other.id)
		{
			return options == other.options;
		}
		return false;
	}

	public JET_COLUMNDEF DeepClone()
	{
		return (JET_COLUMNDEF)MemberwiseClone();
	}

	internal NATIVE_COLUMNDEF GetNativeColumndef()
	{
		return checked(new NATIVE_COLUMNDEF
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_COLUMNDEF)),
			cp = (ushort)cp,
			cbMax = (uint)cbMax,
			grbit = (uint)grbit,
			coltyp = (uint)coltyp
		});
	}

	internal void SetFromNativeColumndef(NATIVE_COLUMNDEF value)
	{
		coltyp = (JET_coltyp)checked((int)value.coltyp);
		cp = (JET_CP)value.cp;
		cbMax = checked((int)value.cbMax);
		grbit = (ColumndefGrbit)checked((int)value.grbit);
		columnid = new JET_COLUMNID
		{
			Value = value.columnid
		};
	}
}
