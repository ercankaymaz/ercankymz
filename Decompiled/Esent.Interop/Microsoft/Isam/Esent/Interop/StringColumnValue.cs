using System.Diagnostics;

namespace Microsoft.Isam.Esent.Interop;

public class StringColumnValue : ColumnValue
{
	private string internalValue;

	public override object ValueAsObject
	{
		[DebuggerStepThrough]
		get
		{
			return Value;
		}
	}

	public string Value
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
			return checked(Value.Length * 2);
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
		return Value;
	}

	internal unsafe override int SetColumns(JET_SESID sesid, JET_TABLEID tableid, ColumnValue[] columnValues, NATIVE_SETCOLUMN* nativeColumns, int i)
	{
		if (Value != null)
		{
			fixed (void* value = Value)
			{
				return SetColumns(sesid, tableid, columnValues, nativeColumns, i, value, checked(Value.Length * 2), hasValue: true);
			}
		}
		return SetColumns(sesid, tableid, columnValues, nativeColumns, i, null, 0, hasValue: false);
	}

	protected override void GetValueFromBytes(byte[] value, int startIndex, int count, int err)
	{
		if (1004 == err)
		{
			Value = null;
		}
		else
		{
			Value = StringCache.GetString(value, startIndex, count);
		}
	}
}
