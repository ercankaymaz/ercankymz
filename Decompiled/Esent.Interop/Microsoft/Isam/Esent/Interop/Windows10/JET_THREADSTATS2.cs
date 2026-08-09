using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop.Windows10;

[Serializable]
public struct JET_THREADSTATS2 : IEquatable<JET_THREADSTATS2>
{
	internal static readonly int Size = Marshal.SizeOf(typeof(JET_THREADSTATS2));

	private readonly int cbStruct;

	private int pagesReferenced;

	private int pagesRead;

	private int pagesPreread;

	private int pagesDirtied;

	private int pagesRedirtied;

	private int numLogRecords;

	private int loggedBytes;

	private long usecsCacheMisses;

	private int pagesCacheMisses;

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

	public long cusecPageCacheMiss
	{
		[DebuggerStepThrough]
		get
		{
			return usecsCacheMisses;
		}
		internal set
		{
			usecsCacheMisses = value;
		}
	}

	public int cPageCacheMiss
	{
		[DebuggerStepThrough]
		get
		{
			return pagesCacheMisses;
		}
		internal set
		{
			pagesCacheMisses = value;
		}
	}

	public static JET_THREADSTATS2 Create(int cPageReferenced, int cPageRead, int cPagePreread, int cPageDirtied, int cPageRedirtied, int cLogRecord, int cbLogRecord, long cusecPageCacheMiss, int cPageCacheMiss)
	{
		return new JET_THREADSTATS2
		{
			cPageReferenced = cPageReferenced,
			cPageRead = cPageRead,
			cPagePreread = cPagePreread,
			cPageDirtied = cPageDirtied,
			cPageRedirtied = cPageRedirtied,
			cLogRecord = cLogRecord,
			cbLogRecord = cbLogRecord,
			cusecPageCacheMiss = cusecPageCacheMiss,
			cPageCacheMiss = cPageCacheMiss
		};
	}

	public static JET_THREADSTATS2 Add(JET_THREADSTATS2 t1, JET_THREADSTATS2 t2)
	{
		return new JET_THREADSTATS2
		{
			cPageReferenced = t1.cPageReferenced + t2.cPageReferenced,
			cPageRead = t1.cPageRead + t2.cPageRead,
			cPagePreread = t1.cPagePreread + t2.cPagePreread,
			cPageDirtied = t1.cPageDirtied + t2.cPageDirtied,
			cPageRedirtied = t1.cPageRedirtied + t2.cPageRedirtied,
			cLogRecord = t1.cLogRecord + t2.cLogRecord,
			cbLogRecord = t1.cbLogRecord + t2.cbLogRecord,
			cusecPageCacheMiss = t1.cusecPageCacheMiss + t2.cusecPageCacheMiss,
			cPageCacheMiss = t1.cPageCacheMiss + t2.cPageCacheMiss
		};
	}

	public static JET_THREADSTATS2 operator +(JET_THREADSTATS2 t1, JET_THREADSTATS2 t2)
	{
		return Add(t1, t2);
	}

	public static JET_THREADSTATS2 Subtract(JET_THREADSTATS2 t1, JET_THREADSTATS2 t2)
	{
		return new JET_THREADSTATS2
		{
			cPageReferenced = t1.cPageReferenced - t2.cPageReferenced,
			cPageRead = t1.cPageRead - t2.cPageRead,
			cPagePreread = t1.cPagePreread - t2.cPagePreread,
			cPageDirtied = t1.cPageDirtied - t2.cPageDirtied,
			cPageRedirtied = t1.cPageRedirtied - t2.cPageRedirtied,
			cLogRecord = t1.cLogRecord - t2.cLogRecord,
			cbLogRecord = t1.cbLogRecord - t2.cbLogRecord,
			cusecPageCacheMiss = t1.cusecPageCacheMiss - t2.cusecPageCacheMiss,
			cPageCacheMiss = t1.cPageCacheMiss - t2.cPageCacheMiss
		};
	}

	public static JET_THREADSTATS2 operator -(JET_THREADSTATS2 t1, JET_THREADSTATS2 t2)
	{
		return Subtract(t1, t2);
	}

	public static bool operator ==(JET_THREADSTATS2 lhs, JET_THREADSTATS2 rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(JET_THREADSTATS2 lhs, JET_THREADSTATS2 rhs)
	{
		return !(lhs == rhs);
	}

	public override string ToString()
	{
		return cPageReferenced.ToString("N0", CultureInfo.InvariantCulture) + " page reference" + GetPluralS(cPageReferenced) + ", " + cPageRead.ToString("N0", CultureInfo.InvariantCulture) + " page" + GetPluralS(cPageRead) + " read, " + cPagePreread.ToString("N0", CultureInfo.InvariantCulture) + " page" + GetPluralS(cPagePreread) + " preread, " + cPageDirtied.ToString("N0", CultureInfo.InvariantCulture) + " page" + GetPluralS(cPageDirtied) + " dirtied, " + cPageRedirtied.ToString("N0", CultureInfo.InvariantCulture) + " page" + GetPluralS(cPageRedirtied) + " redirtied, " + cLogRecord.ToString("N0", CultureInfo.InvariantCulture) + " log record" + GetPluralS(cLogRecord) + ", " + cbLogRecord.ToString("N0", CultureInfo.InvariantCulture) + " byte" + GetPluralS(cbLogRecord) + " logged" + ", " + cusecPageCacheMiss.ToString("N0", CultureInfo.InvariantCulture) + " page cache miss latency (us)" + ", " + cPageCacheMiss.ToString("N0", CultureInfo.InvariantCulture) + " page cache miss count";
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_THREADSTATS2)obj);
	}

	public override int GetHashCode()
	{
		return cPageReferenced ^ (cPageRead << 1) ^ (cPagePreread << 2) ^ (cPageDirtied << 3) ^ (cPageRedirtied << 4) ^ (cLogRecord << 5) ^ (cbLogRecord << 6) ^ (cusecPageCacheMiss.GetHashCode() << 7) ^ (cPageCacheMiss << 8);
	}

	public bool Equals(JET_THREADSTATS2 other)
	{
		if (cPageCacheMiss == other.cPageCacheMiss && cusecPageCacheMiss == other.cusecPageCacheMiss && cbLogRecord == other.cbLogRecord && cLogRecord == other.cLogRecord && cPageDirtied == other.cPageDirtied && cPagePreread == other.cPagePreread && cPageRead == other.cPageRead && cPageRedirtied == other.cPageRedirtied)
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
