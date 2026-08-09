using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public struct JET_LOGTIME : IEquatable<JET_LOGTIME>, IJET_LOGTIME, INullableJetStruct
{
	private readonly byte bSeconds;

	private readonly byte bMinutes;

	private readonly byte bHours;

	private readonly byte bDays;

	private readonly byte bMonth;

	private readonly byte bYear;

	private readonly byte bFiller1;

	private readonly byte bFiller2;

	public bool HasValue
	{
		get
		{
			if (bMonth != 0)
			{
				return bDays != 0;
			}
			return false;
		}
	}

	public bool fTimeIsUTC => (bFiller1 & 1) != 0;

	internal JET_LOGTIME(DateTime time)
	{
		checked
		{
			bSeconds = (byte)time.Second;
			bMinutes = (byte)time.Minute;
			bHours = (byte)time.Hour;
			bDays = (byte)time.Day;
			bMonth = (byte)time.Month;
			bYear = (byte)(time.Year - 1900);
			bFiller1 = ((time.Kind == DateTimeKind.Utc) ? ((byte)1) : ((byte)0));
			bFiller1 |= (byte)((time.Millisecond & 0x7F) << 1);
			bFiller2 = (byte)((time.Millisecond & 0x380) >> 6);
		}
	}

	public static bool operator ==(JET_LOGTIME lhs, JET_LOGTIME rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(JET_LOGTIME lhs, JET_LOGTIME rhs)
	{
		return !(lhs == rhs);
	}

	public DateTime? ToDateTime()
	{
		if (!HasValue)
		{
			return null;
		}
		checked
		{
			return new DateTime(bYear + 1900, bMonth, bDays, bHours, bMinutes, bSeconds, (int)unchecked((uint)(((bFiller2 & 0xE) << 6) | ((bFiller1 & 0xFE) >>> 1))), fTimeIsUTC ? DateTimeKind.Utc : DateTimeKind.Local);
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_LOGTIME({0}:{1}:{2}:{3}:{4}:{5}:0x{6:x}:0x{7:x})", bSeconds, bMinutes, bHours, bDays, bMonth, bYear, bFiller1, bFiller2);
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_LOGTIME)obj);
	}

	public override int GetHashCode()
	{
		byte b = bSeconds;
		return b.GetHashCode() ^ (bMinutes << 6) ^ (bHours << 12) ^ (bDays << 17) ^ (bMonth << 22) ^ (bYear << 24) ^ bFiller1 ^ (bFiller2 << 8);
	}

	public bool Equals(JET_LOGTIME other)
	{
		if (bSeconds == other.bSeconds && bMinutes == other.bMinutes && bHours == other.bHours && bDays == other.bDays && bMonth == other.bMonth && bYear == other.bYear && bFiller1 == other.bFiller1)
		{
			return bFiller2 == other.bFiller2;
		}
		return false;
	}
}
