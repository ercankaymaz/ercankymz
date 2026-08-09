using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public struct JET_BKINFO : IEquatable<JET_BKINFO>, INullableJetStruct
{
	private JET_LGPOS logPosition;

	private JET_BKLOGTIME backupTime;

	private uint lowGeneration;

	private uint highGeneration;

	public JET_LGPOS lgposMark
	{
		[DebuggerStepThrough]
		get
		{
			return logPosition;
		}
		internal set
		{
			logPosition = value;
		}
	}

	public JET_BKLOGTIME bklogtimeMark
	{
		[DebuggerStepThrough]
		get
		{
			return backupTime;
		}
		internal set
		{
			backupTime = value;
		}
	}

	public int genLow
	{
		[DebuggerStepThrough]
		get
		{
			return checked((int)lowGeneration);
		}
		internal set
		{
			lowGeneration = checked((uint)value);
		}
	}

	public int genHigh
	{
		[DebuggerStepThrough]
		get
		{
			return checked((int)highGeneration);
		}
		set
		{
			highGeneration = checked((uint)value);
		}
	}

	public bool HasValue
	{
		get
		{
			if (lgposMark.HasValue && backupTime.HasValue && lowGeneration != 0)
			{
				return highGeneration != 0;
			}
			return false;
		}
	}

	public static bool operator ==(JET_BKINFO lhs, JET_BKINFO rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(JET_BKINFO lhs, JET_BKINFO rhs)
	{
		return !(lhs == rhs);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_BKINFO({0}-{1}:{2}:{3})", genLow, genHigh, lgposMark, bklogtimeMark);
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_BKINFO)obj);
	}

	public override int GetHashCode()
	{
		return (int)((uint)(logPosition.GetHashCode() ^ backupTime.GetHashCode()) ^ (lowGeneration << 16) ^ (uint)((int)lowGeneration >> 16) ^ highGeneration);
	}

	public bool Equals(JET_BKINFO other)
	{
		if (logPosition == other.logPosition && backupTime == other.backupTime && lowGeneration == other.lowGeneration)
		{
			return highGeneration == other.highGeneration;
		}
		return false;
	}
}
