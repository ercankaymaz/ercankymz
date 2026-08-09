using System;
using System.Diagnostics;

namespace Microsoft.Isam.Esent.Interop;

public class GuidColumnValue : ColumnValueOfStruct<Guid>
{
	protected override int Size
	{
		[DebuggerStepThrough]
		get
		{
			return 16;
		}
	}

	internal unsafe override int SetColumns(JET_SESID sesid, JET_TABLEID tableid, ColumnValue[] columnValues, NATIVE_SETCOLUMN* nativeColumns, int i)
	{
		Guid valueOrDefault = base.Value.GetValueOrDefault();
		return SetColumns(sesid, tableid, columnValues, nativeColumns, i, &valueOrDefault, Size, base.Value.HasValue);
	}

	protected unsafe override void GetValueFromBytes(byte[] value, int startIndex, int count, int err)
	{
		if (1004 == err)
		{
			base.Value = null;
			return;
		}
		CheckDataCount(count);
		Guid value2 = default(Guid);
		void* ptr = &value2;
		byte* ptr2 = (byte*)ptr;
		checked
		{
			for (int i = 0; i < Size; i++)
			{
				ptr2[i] = value[startIndex + i];
			}
			base.Value = value2;
		}
	}
}
