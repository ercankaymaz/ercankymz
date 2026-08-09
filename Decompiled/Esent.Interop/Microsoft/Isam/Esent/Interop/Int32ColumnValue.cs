using System;
using System.Diagnostics;

namespace Microsoft.Isam.Esent.Interop;

public class Int32ColumnValue : ColumnValueOfStruct<int>
{
	protected override int Size
	{
		[DebuggerStepThrough]
		get
		{
			return 4;
		}
	}

	internal unsafe override int SetColumns(JET_SESID sesid, JET_TABLEID tableid, ColumnValue[] columnValues, NATIVE_SETCOLUMN* nativeColumns, int i)
	{
		int valueOrDefault = base.Value.GetValueOrDefault();
		return SetColumns(sesid, tableid, columnValues, nativeColumns, i, &valueOrDefault, 4, base.Value.HasValue);
	}

	protected override void GetValueFromBytes(byte[] value, int startIndex, int count, int err)
	{
		if (1004 == err)
		{
			base.Value = null;
			return;
		}
		CheckDataCount(count);
		base.Value = BitConverter.ToInt32(value, startIndex);
	}
}
