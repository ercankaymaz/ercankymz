using System;
using System.Diagnostics;

namespace Microsoft.Isam.Esent.Interop;

public class BoolColumnValue : ColumnValueOfStruct<bool>
{
	private static readonly object BoxedTrue = true;

	private static readonly object BoxedFalse = false;

	public override object ValueAsObject
	{
		get
		{
			if (!base.Value.HasValue)
			{
				return null;
			}
			if (!base.Value.Value)
			{
				return BoxedFalse;
			}
			return BoxedTrue;
		}
	}

	protected override int Size
	{
		[DebuggerStepThrough]
		get
		{
			return 1;
		}
	}

	internal unsafe override int SetColumns(JET_SESID sesid, JET_TABLEID tableid, ColumnValue[] columnValues, NATIVE_SETCOLUMN* nativeColumns, int i)
	{
		byte b = (byte)((base.Value == true) ? byte.MaxValue : 0);
		return SetColumns(sesid, tableid, columnValues, nativeColumns, i, &b, 1, base.Value.HasValue);
	}

	protected override void GetValueFromBytes(byte[] value, int startIndex, int count, int err)
	{
		if (1004 == err)
		{
			base.Value = null;
			return;
		}
		CheckDataCount(count);
		base.Value = BitConverter.ToBoolean(value, startIndex);
	}
}
