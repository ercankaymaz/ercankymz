using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public abstract class ColumnValue
{
	private RetrieveColumnGrbit grbit;

	public JET_COLUMNID Columnid { get; set; }

	public abstract object ValueAsObject { get; }

	public SetColumnGrbit SetGrbit { get; set; }

	public RetrieveColumnGrbit RetrieveGrbit
	{
		get
		{
			return grbit;
		}
		set
		{
			ValidateRetrieveGrbit(value);
			grbit = value;
		}
	}

	public int ItagSequence { get; set; }

	public JET_wrn Error { get; internal set; }

	public abstract int Length { get; }

	protected abstract int Size { get; }

	protected ColumnValue()
	{
		ItagSequence = 1;
	}

	public abstract override string ToString();

	internal unsafe static void RetrieveColumns(JET_SESID sesid, JET_TABLEID tableid, ColumnValue[] columnValues)
	{
		if (columnValues.Length > 1024)
		{
			throw new ArgumentOutOfRangeException("columnValues", columnValues.Length, "Too many column values");
		}
		byte[] data = null;
		NATIVE_RETRIEVECOLUMN* ptr = stackalloc NATIVE_RETRIEVECOLUMN[columnValues.Length];
		try
		{
			data = Caches.ColumnCache.Allocate();
			fixed (byte* ptr2 = data)
			{
				byte* ptr3 = ptr2;
				int num = columnValues.Length;
				checked
				{
					for (int i = 0; i < columnValues.Length; i++)
					{
						if (columnValues[i].Size != 0)
						{
							unchecked
							{
								columnValues[i].MakeNativeRetrieveColumn(ref *(NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))));
								((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->pvData = new IntPtr(ptr3);
								((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->cbData = checked((uint)columnValues[i].Size);
								ptr3 = (byte*)checked(unchecked((nuint)ptr3) + unchecked((nuint)((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->cbData));
							}
							num--;
						}
					}
					if (num > 0)
					{
						int num2 = (int)(ptr3 - ptr2);
						unchecked
						{
							int num3 = checked(data.Length - num2) / num;
							for (int j = 0; j < columnValues.Length; j = checked(j + 1))
							{
								if (columnValues[j].Size == 0)
								{
									columnValues[j].MakeNativeRetrieveColumn(ref *(NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)j) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))));
									((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)j) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->pvData = new IntPtr(ptr3);
									((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)j) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->cbData = checked((uint)num3);
									ptr3 = (byte*)checked(unchecked((nuint)ptr3) + unchecked((nuint)((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)j) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->cbData));
								}
							}
						}
					}
					Api.Check(Api.Impl.JetRetrieveColumns(sesid, tableid, ptr, columnValues.Length));
					for (int k = 0; k < columnValues.Length; k++)
					{
						unchecked
						{
							columnValues[k].Error = (JET_wrn)((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)k) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->err;
						}
						columnValues[k].ItagSequence = (int)unchecked((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)k) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->itagSequence;
					}
				}
				for (int l = 0; l < columnValues.Length; l = checked(l + 1))
				{
					if (((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)l) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->err != 1006)
					{
						byte* ptr4 = (byte*)(void*)((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)l) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->pvData;
						int startIndex = checked((int)(ptr4 - ptr2));
						columnValues[l].GetValueFromBytes(data, startIndex, checked((int)unchecked((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)l) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->cbActual), ((NATIVE_RETRIEVECOLUMN*)((byte*)ptr + checked(unchecked((nint)l) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->err);
					}
				}
			}
			RetrieveTruncatedBuffers(sesid, tableid, columnValues, ptr);
		}
		finally
		{
			if (data != null)
			{
				Caches.ColumnCache.Free(ref data);
			}
		}
	}

	internal unsafe abstract int SetColumns(JET_SESID sesid, JET_TABLEID tableid, ColumnValue[] columnValues, NATIVE_SETCOLUMN* nativeColumns, int i);

	internal unsafe int SetColumns(JET_SESID sesid, JET_TABLEID tableid, ColumnValue[] columnValues, NATIVE_SETCOLUMN* nativeColumns, int i, void* buffer, int bufferSize, bool hasValue)
	{
		MakeNativeSetColumn(ref *(NATIVE_SETCOLUMN*)((byte*)nativeColumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))));
		if (hasValue)
		{
			((NATIVE_SETCOLUMN*)((byte*)nativeColumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))))->cbData = checked((uint)bufferSize);
			((NATIVE_SETCOLUMN*)((byte*)nativeColumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))))->pvData = new IntPtr(buffer);
			if (bufferSize == 0)
			{
				((NATIVE_SETCOLUMN*)((byte*)nativeColumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))))->grbit |= 32u;
			}
		}
		int result = checked((i == columnValues.Length - 1) ? Api.Impl.JetSetColumns(sesid, tableid, nativeColumns, columnValues.Length) : columnValues[i + 1].SetColumns(sesid, tableid, columnValues, nativeColumns, i + 1));
		Error = (JET_wrn)checked((int)unchecked((NATIVE_SETCOLUMN*)((byte*)nativeColumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_SETCOLUMN)))))->err);
		return result;
	}

	protected abstract void GetValueFromBytes(byte[] value, int startIndex, int count, int err);

	protected virtual void ValidateRetrieveGrbit(RetrieveColumnGrbit grbit)
	{
		if ((grbit & (RetrieveColumnGrbit)131072) != RetrieveColumnGrbit.None)
		{
			throw new EsentInvalidGrbitException();
		}
	}

	private unsafe static void RetrieveTruncatedBuffers(JET_SESID sesid, JET_TABLEID tableid, ColumnValue[] columnValues, NATIVE_RETRIEVECOLUMN* nativeRetrievecolumns)
	{
		for (int i = 0; i < columnValues.Length; i = checked(i + 1))
		{
			if (((NATIVE_RETRIEVECOLUMN*)((byte*)nativeRetrievecolumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->err == 1006)
			{
				byte[] array = new byte[((NATIVE_RETRIEVECOLUMN*)((byte*)nativeRetrievecolumns + checked(unchecked((nint)i) * unchecked((nint)sizeof(NATIVE_RETRIEVECOLUMN)))))->cbActual];
				JET_RETINFO retinfo = new JET_RETINFO
				{
					itagSequence = columnValues[i].ItagSequence
				};
				int num;
				int actualDataSize;
				fixed (byte* value = array)
				{
					num = Api.Impl.JetRetrieveColumn(sesid, tableid, columnValues[i].Columnid, new IntPtr(value), array.Length, out actualDataSize, columnValues[i].RetrieveGrbit, retinfo);
				}
				if (1006 == num)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Column size changed from {0} to {1}. The record was probably updated by another thread.", array.Length, actualDataSize));
				}
				Api.Check(num);
				columnValues[i].Error = (JET_wrn)num;
				columnValues[i].GetValueFromBytes(array, 0, actualDataSize, num);
			}
		}
	}

	private void MakeNativeSetColumn(ref NATIVE_SETCOLUMN setcolumn)
	{
		setcolumn.columnid = Columnid.Value;
		checked
		{
			setcolumn.grbit = (uint)SetGrbit;
			setcolumn.itagSequence = (uint)ItagSequence;
		}
	}

	private void MakeNativeRetrieveColumn(ref NATIVE_RETRIEVECOLUMN retrievecolumn)
	{
		retrievecolumn.columnid = Columnid.Value;
		checked
		{
			retrievecolumn.grbit = (uint)RetrieveGrbit;
			retrievecolumn.itagSequence = (uint)ItagSequence;
		}
	}
}
