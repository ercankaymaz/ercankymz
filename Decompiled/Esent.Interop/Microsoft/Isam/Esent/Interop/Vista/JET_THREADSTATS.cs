using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop.Vista;

[Serializable]
public struct JET_THREADSTATS : IEquatable<JET_THREADSTATS>
{
	internal static readonly int Size = Marshal.SizeOf(typeof(JET_THREADSTATS));

	private readonly int cbStruct;

	private int pagesReferenced;

	private int pagesRead;

	private int pagesPreread;

	private int pagesDirtied;

	private int pagesRedirtied;

	private int numLogRecords;

	private int loggedBytes;

	public int cPageReferenced
	{
		[DebuggerStepThrough]
		get
		{
			return pagesReferenced;
		}
		internal set
		{
			pagesReferenced = value;
		}
	}

	public int cPageRead
	{
		[DebuggerStepThrough]
		get
		{
			return pagesRead;
		}
		internal set
		{
			pagesRead = value;
		}
	}

	public int cPagePreread
	{
		[DebuggerStepThrough]
		get
		{
			return pagesPreread;
		}
		internal set
		{
			pagesPreread = value;
		}
	}

	public int cPageDirtied
	{
		[DebuggerStepThrough]
		get
		{
			return pagesDirtied;
		}
		internal set
		{
			pagesDirtied = value;
		}
	}

	public int cPageRedirtied
	{
		[DebuggerStepThrough]
		get
		{
			return pagesRedirtied;
		}
		internal set
		{
			pagesRedirtied = value;
		}
	}

	public int cLogRecord
	{
		[DebuggerStepThrough]
		get
		{
			return numLogRecords;
		}
		internal set
		{
			numLogRecords = value;
		}
	}

	public int cbLogRecord
	{
		[DebuggerStepThrough]
		get
		{
			return loggedBytes;
		}
		internal set
		{
			loggedBytes = value;
		}
	}

	public static JET_THREADSTATS Create(int cPageReferenced, int cPageRead, int cPagePreread, int cPageDirtied, int cPageRedirtied, int cLogRecord, int cbLogRecord)
	{
		return new JET_THREADSTATS
		{
			cPageReferenced = cPageReferenced,
			cPageRead = cPageRead,
			cPagePreread = cPagePreread,
			cPageDirtied = cPageDirtied,
			cPageRedirtied = cPageRedirtied,
			cLogRecord = cLogRecord,
			cbLogRecord = cbLogRecord
		};
	}

	public static JET_THREADSTATS Add(JET_THREADSTATS t1, JET_THREADSTATS t2)
	{
		return new JET_THREADSTATS
		{
			cPageReferenced = t1.cPageReferenced + t2.cPageReferenced,
			cPageRead = t1.cPageRead + t2.cPageRead,
			cPagePreread = t1.cPagePreread + t2.cPagePreread,
			cPageDirtied = t1.cPageDirtied + t2.cPageDirtied,
			cPageRedirtied = t1.cPageRedirtied + t2.cPageRedirtied,
			cLogRecord = t1.cLogRecord + t2.cLogRecord,
			cbLogRecord = t1.cbLogRecord + t2.cbLogRecord
		};
	}

	public static JET_THREADSTATS operator +(JET_THREADSTATS t1, JET_THREADSTATS t2)
	{
		return Add(t1, t2);
	}

	public static JET_THREADSTATS Subtract(JET_THREADSTATS t1, JET_THREADSTATS t2)
	{
		return new JET_THREADSTATS
		{
			cPageReferenced = t1.cPageReferenced - t2.cPageReferenced,
			cPageRead = t1.cPageRead - t2.cPageRead,
			cPagePreread = t1.cPagePreread - t2.cPagePreread,
			cPageDirtied = t1.cPageDirtied - t2.cPageDirtied,
			cPageRedirtied = t1.cPageRedirtied - t2.cPageRedirtied,
			cLogRecord = t1.cLogRecord - t2.cLogRecord,
			cbLogRecord = t1.cbLogRecord - t2.cbLogRecord
		};
	}

	public static JET_THREADSTATS operator -(JET_THREADSTATS t1, JET_THREADSTATS t2)
	{
		return Subtract(t1, t2);
	}

	public static bool operator ==(JET_THREADSTATS lhs, JET_THREADSTATS rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(JET_THREADSTATS lhs, JET_THREADSTATS rhs)
	{
		return !(lhs == rhs);
	}

	public override string ToString()
	{
		return cPageReferenced.ToString("N0", CultureInfo.InvariantCulture) + " page reference" + GetPluralS(cPageReferenced) + ", " + cPageRead.ToString("N0", CultureInfo.InvariantCulture) + " page" + GetPluralS(cPageRead) + " read, " + cPagePreread.ToString("N0", CultureInfo.InvariantCulture) + " page" + GetPluralS(cPagePreread) + " preread, " + cPageDirtied.ToString("N0", CultureInfo.InvariantCulture) + " page" + GetPluralS(cPageDirtied) + " dirtied, " + cPageRedirtied.ToString("N0", CultureInfo.InvariantCulture) + " page" + GetPluralS(cPageRedirtied) + " redirtied, " + cLogRecord.ToString("N0", CultureInfo.InvariantCulture) + " log record" + GetPluralS(cLogRecord) + ", " + cbLogRecord.ToString("N0", CultureInfo.InvariantCulture) + " byte" + GetPluralS(cbLogRecord) + " logged";
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_THREADSTATS)obj);
	}

	public override int GetHashCode()
	{
		return cPageReferenced ^ (cPageRead << 1) ^ (cPagePreread << 2) ^ (cPageDirtied << 3) ^ (cPageRedirtied << 4) ^ (cLogRecord << 5) ^ (cbLogRecord << 6);
	}

	public bool Equals(JET_THREADSTATS other)
	{
		if (cbLogRecord == other.cbLogRecord && cLogRecord == other.cLogRecord && cPageDirtied == other.cPageDirtied && cPagePreread == other.cPagePreread && cPageRead == other.cPageRead && cPageRedirtied == other.cPageRedirtied)
		{
			return cPageReferenced == other.cPageReferenced;
		}
		return false;
	}

	private static string GetPluralS(int n)
	{
		if (n != 1)
		{
			return "s";
		}
		return string.Empty;
	}
}
