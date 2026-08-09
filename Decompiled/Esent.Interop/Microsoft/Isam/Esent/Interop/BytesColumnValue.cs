using System;
using System.Diagnostics;

namespace Microsoft.Isam.Esent.Interop;

public class BytesColumnValue : ColumnValue
{
	private byte[] internalValue;

	public override object ValueAsObject
	{
		[DebuggerStepThrough]
		get
		{
			return Value;
		}
	}

	public byte[] Value
	{
		get
		{
			return internalValue;
		}
		set
		{
			internalValue = value;
			base.Error = ((value == null) ? JET_wrn.ColumnNull : JET_wrn.Success);
		}
	}

	public override int Length
	{
		get
		{
			if (Value == null)
			{
				return 0;
			}
			return Value.Length;
		}
	}

	protected override int Size
	{
		[DebuggerStepThrough]
		get
		{
			return 0;
		}
	}

	public override string ToString()
	{
		if (Value == null)
		{
			return string.Empty;
		}
		return BitConverter.ToString(Value, 0, Math.Min(Value.Length, 16));
	}

	internal unsafe override int SetColumns(JET_SESID sesid, JET_TABLEID tableid, ColumnValue[] columnValues, NATIVE_SETCOLUMN* nativeColumns, int i)
	{
		if (Value != null)
		{
			fixed (byte* value = Value)
			{
				void* buffer = value;
				return SetColumns(sesid, tableid, columnValues, nativeColumns, i, buffer, Value.Length, hasValue: true);
			}
		}
		return SetColumns(sesid, tableid, columnValues, nativeColumns, i, null, 0, hasValue: false);
	}

	protected override void GetValueFromBytes(byte[] value, int startIndex, int count, int err)
	{
		if (1004 == err)
		{
			Value = null;
			return;
		}
		byte[] array = new byte[count];
		Buffer.BlockCopy(value, startIndex, array, 0, count);
		Value = array;
	}
}
