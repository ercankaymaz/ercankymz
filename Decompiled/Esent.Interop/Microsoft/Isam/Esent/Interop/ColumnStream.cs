using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Microsoft.Isam.Esent.Interop;

public class ColumnStream : Stream
{
	private const int MaxLongValueSize = int.MaxValue;

	private readonly JET_SESID sesid;

	private readonly JET_TABLEID tableid;

	private readonly JET_COLUMNID columnid;

	private int ibLongValue;

	public int Itag { get; set; }

	public override bool CanRead
	{
		[DebuggerStepThrough]
		get
		{
			return true;
		}
	}

	public override bool CanWrite
	{
		[DebuggerStepThrough]
		get
		{
			return true;
		}
	}

	public override bool CanSeek
	{
		[DebuggerStepThrough]
		get
		{
			return true;
		}
	}

	public override long Position
	{
		[DebuggerStepThrough]
		get
		{
			return ibLongValue;
		}
		set
		{
			if (value < 0 || value > int.MaxValue)
			{
				throw new ArgumentOutOfRangeException("value", value, "A long-value offset has to be between 0 and 0x7fffffff bytes");
			}
			ibLongValue = checked((int)value);
		}
	}

	public override long Length
	{
		get
		{
			JET_RETINFO retinfo = new JET_RETINFO
			{
				itagSequence = Itag,
				ibLongValue = 0
			};
			Api.JetRetrieveColumn(sesid, tableid, columnid, null, 0, out var actualDataSize, RetrieveGrbit, retinfo);
			return actualDataSize;
		}
	}

	private static RetrieveColumnGrbit RetrieveGrbit
	{
		[DebuggerStepThrough]
		get
		{
			return RetrieveColumnGrbit.RetrieveCopy;
		}
	}

	public ColumnStream(JET_SESID sesid, JET_TABLEID tableid, JET_COLUMNID columnid)
	{
		this.sesid = sesid;
		this.tableid = tableid;
		this.columnid = columnid;
		Itag = 1;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "ColumnStream(0x{0:x}:{1})", columnid.Value, Itag);
	}

	public override void Flush()
	{
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		CheckBufferArguments(buffer, offset, count);
		checked
		{
			int num = (int)Length;
			int num2 = ibLongValue + count;
			JET_SETINFO setinfo;
			if (ibLongValue > num)
			{
				setinfo = new JET_SETINFO
				{
					itagSequence = Itag
				};
				Api.JetSetColumn(sesid, tableid, columnid, null, ibLongValue, SetColumnGrbit.SizeLV, setinfo);
				num = ibLongValue;
			}
			SetColumnGrbit grbit = ((ibLongValue == num) ? SetColumnGrbit.AppendLV : ((num2 < num) ? SetColumnGrbit.OverwriteLV : (SetColumnGrbit.OverwriteLV | SetColumnGrbit.SizeLV)));
			setinfo = new JET_SETINFO
			{
				itagSequence = Itag,
				ibLongValue = ibLongValue
			};
			Api.JetSetColumn(sesid, tableid, columnid, buffer, count, offset, grbit, setinfo);
			ibLongValue += count;
		}
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		CheckBufferArguments(buffer, offset, count);
		if (ibLongValue >= Length)
		{
			return 0;
		}
		JET_RETINFO retinfo = new JET_RETINFO
		{
			itagSequence = Itag,
			ibLongValue = ibLongValue
		};
		Api.JetRetrieveColumn(sesid, tableid, columnid, buffer, count, offset, out var actualDataSize, RetrieveGrbit, retinfo);
		int num = Math.Min(actualDataSize, count);
		checked
		{
			ibLongValue += num;
			return num;
		}
	}

	public override void SetLength(long value)
	{
		if (value > int.MaxValue || value < 0)
		{
			throw new ArgumentOutOfRangeException("value", value, "A LongValueStream cannot be longer than 0x7FFFFFF or less than 0 bytes");
		}
		checked
		{
			if (value < Length && value > 0)
			{
				byte[] array = new byte[value];
				JET_RETINFO retinfo = new JET_RETINFO
				{
					itagSequence = Itag,
					ibLongValue = 0
				};
				Api.JetRetrieveColumn(sesid, tableid, columnid, array, array.Length, out var _, RetrieveGrbit, retinfo);
				JET_SETINFO setinfo = new JET_SETINFO
				{
					itagSequence = Itag
				};
				Api.JetSetColumn(sesid, tableid, columnid, array, array.Length, SetColumnGrbit.None, setinfo);
			}
			else
			{
				JET_SETINFO setinfo2 = new JET_SETINFO
				{
					itagSequence = Itag
				};
				SetColumnGrbit grbit = ((value == 0L) ? SetColumnGrbit.ZeroLength : SetColumnGrbit.SizeLV);
				Api.JetSetColumn(sesid, tableid, columnid, null, (int)value, grbit, setinfo2);
			}
			if (ibLongValue > value)
			{
				ibLongValue = (int)value;
			}
		}
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		checked
		{
			long num = origin switch
			{
				SeekOrigin.Begin => offset, 
				SeekOrigin.End => Length + offset, 
				SeekOrigin.Current => ibLongValue + offset, 
				_ => throw new ArgumentOutOfRangeException("origin", origin, "Unknown origin"), 
			};
			if (num < 0 || num > int.MaxValue)
			{
				throw new ArgumentOutOfRangeException("offset", offset, "invalid offset/origin combination");
			}
			ibLongValue = (int)num;
			return ibLongValue;
		}
	}

	private static void CheckBufferArguments(ICollection<byte> buffer, int offset, int count)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (offset < 0)
		{
			throw new ArgumentOutOfRangeException("offset", offset, "cannot be negative");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count", count, "cannot be negative");
		}
		if (checked(buffer.Count - offset) < count)
		{
			throw new ArgumentOutOfRangeException("count", count, "cannot be larger than the size of the buffer");
		}
	}
}
