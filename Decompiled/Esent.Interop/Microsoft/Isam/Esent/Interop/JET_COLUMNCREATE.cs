using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class JET_COLUMNCREATE : IContentEquatable<JET_COLUMNCREATE>, IDeepCloneable<JET_COLUMNCREATE>
{
	private string name;

	private JET_coltyp columnType;

	private int maxSize;

	private ColumndefGrbit options;

	private byte[] defaultValue;

	private int defaultValueSize;

	private JET_CP codePage;

	[NonSerialized]
	private JET_COLUMNID id;

	private JET_err errorCode;

	public string szColumnName
	{
		[DebuggerStepThrough]
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

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

	public byte[] pvDefault
	{
		get
		{
			return defaultValue;
		}
		set
		{
			defaultValue = value;
		}
	}

	public int cbDefault
	{
		get
		{
			return defaultValueSize;
		}
		set
		{
			defaultValueSize = value;
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

	public JET_err err
	{
		[DebuggerStepThrough]
		get
		{
			return errorCode;
		}
		set
		{
			errorCode = value;
		}
	}

	public bool ContentEquals(JET_COLUMNCREATE other)
	{
		if (other == null)
		{
			return false;
		}
		CheckMembersAreValid();
		other.CheckMembersAreValid();
		if (err == other.err && szColumnName == other.szColumnName && coltyp == other.coltyp && cbMax == other.cbMax && grbit == other.grbit && cbDefault == other.cbDefault && cp == other.cp && columnid == other.columnid)
		{
			return Util.ArrayEqual(pvDefault, other.pvDefault, 0, other.cbDefault);
		}
		return false;
	}

	public JET_COLUMNCREATE DeepClone()
	{
		JET_COLUMNCREATE jET_COLUMNCREATE = (JET_COLUMNCREATE)MemberwiseClone();
		if (pvDefault != null)
		{
			jET_COLUMNCREATE.pvDefault = new byte[pvDefault.Length];
			Array.Copy(pvDefault, jET_COLUMNCREATE.pvDefault, pvDefault.Length);
		}
		return jET_COLUMNCREATE;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_COLUMNCREATE({0},{1},{2})", szColumnName, coltyp, grbit);
	}

	internal void CheckMembersAreValid()
	{
		if (szColumnName == null)
		{
			throw new ArgumentNullException("szColumnName");
		}
		if (cbDefault < 0)
		{
			throw new ArgumentOutOfRangeException("cbDefault", cbDefault, "cannot be negative");
		}
		if (pvDefault == null && cbDefault != 0)
		{
			throw new ArgumentOutOfRangeException("cbDefault", cbDefault, "must be 0");
		}
		if (pvDefault != null && cbDefault > pvDefault.Length)
		{
			throw new ArgumentOutOfRangeException("cbDefault", cbDefault, "can't be greater than pvDefault.Length");
		}
	}

	internal NATIVE_COLUMNCREATE GetNativeColumnCreate()
	{
		return checked(new NATIVE_COLUMNCREATE
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_COLUMNCREATE)),
			szColumnName = IntPtr.Zero,
			coltyp = (uint)coltyp,
			cbMax = (uint)cbMax,
			grbit = (uint)grbit,
			pvDefault = IntPtr.Zero,
			cbDefault = (uint)cbDefault,
			cp = (uint)cp
		});
	}

	internal void SetFromNativeColumnCreate(ref NATIVE_COLUMNCREATE value)
	{
		columnid = new JET_COLUMNID
		{
			Value = value.columnid
		};
		err = (JET_err)value.err;
	}
}
