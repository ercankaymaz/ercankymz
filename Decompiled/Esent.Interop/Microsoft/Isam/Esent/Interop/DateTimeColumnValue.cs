using System;
using System.Diagnostics;

namespace Microsoft.Isam.Esent.Interop;

public class DateTimeColumnValue : ColumnValueOfStruct<DateTime>
{
	protected override int Size
	{
		[DebuggerStepThrough]
		get
		{
			return 8;
		}
	}

	internal unsafe override int SetColumns(JET_SESID sesid, JET_TABLEID tableid, ColumnValue[] columnValues, NATIVE_SETCOLUMN* nativeColumns, int i)
	{
		double num = base.Value.GetValueOrDefault().ToOADate();
		return SetColumns(sesid, tableid, columnValues, nativeColumns, i, &num, 8, base.Value.HasValue);
	}

	protected override void GetValueFromBytes(byte[] value, int startIndex, int count, int err)
	{
		if (1004 == err)
		{
			base.Value = null;
			return;
		}
		CheckDataCount(count);
		double d = BitConverter.ToDouble(value, startIndex);
		base.Value = Conversions.ConvertDoubleToDateTime(d);
	}
}
