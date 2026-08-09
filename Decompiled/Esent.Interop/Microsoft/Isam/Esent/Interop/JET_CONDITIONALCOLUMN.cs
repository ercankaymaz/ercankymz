using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class JET_CONDITIONALCOLUMN : IContentEquatable<JET_CONDITIONALCOLUMN>, IDeepCloneable<JET_CONDITIONALCOLUMN>
{
	private string columnName;

	private ConditionalColumnGrbit option;

	public string szColumnName
	{
		[DebuggerStepThrough]
		get
		{
			return columnName;
		}
		set
		{
			columnName = value;
		}
	}

	public ConditionalColumnGrbit grbit
	{
		[DebuggerStepThrough]
		get
		{
			return option;
		}
		set
		{
			option = value;
		}
	}

	public JET_CONDITIONALCOLUMN()
	{
	}

	internal JET_CONDITIONALCOLUMN(ref NATIVE_CONDITIONALCOLUMN native)
	{
		szColumnName = Marshal.PtrToStringUni(native.szColumnName);
		grbit = (ConditionalColumnGrbit)checked((int)native.grbit);
	}

	public JET_CONDITIONALCOLUMN DeepClone()
	{
		return (JET_CONDITIONALCOLUMN)MemberwiseClone();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_CONDITIONALCOLUMN({0}:{1})", columnName, option);
	}

	public bool ContentEquals(JET_CONDITIONALCOLUMN other)
	{
		if (other == null)
		{
			return false;
		}
		if (columnName == other.columnName)
		{
			return option == other.option;
		}
		return false;
	}

	internal NATIVE_CONDITIONALCOLUMN GetNativeConditionalColumn()
	{
		return checked(new NATIVE_CONDITIONALCOLUMN
		{
			cbStruct = (uint)Marshal.SizeOf(typeof(NATIVE_CONDITIONALCOLUMN)),
			grbit = (uint)grbit
		});
	}
}
