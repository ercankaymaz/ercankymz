using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop.Windows8;

public class JET_COMMIT_ID : IComparable<JET_COMMIT_ID>, IEquatable<JET_COMMIT_ID>
{
	private readonly JET_SIGNATURE signLog;

	private readonly long commitId;

	internal JET_COMMIT_ID(NATIVE_COMMIT_ID native)
	{
		signLog = new JET_SIGNATURE(native.signLog);
		commitId = native.commitId;
	}

	public static bool operator <(JET_COMMIT_ID lhs, JET_COMMIT_ID rhs)
	{
		return lhs.CompareTo(rhs) < 0;
	}

	public static bool operator >(JET_COMMIT_ID lhs, JET_COMMIT_ID rhs)
	{
		return lhs.CompareTo(rhs) > 0;
	}

	public static bool operator <=(JET_COMMIT_ID lhs, JET_COMMIT_ID rhs)
	{
		return lhs.CompareTo(rhs) <= 0;
	}

	public static bool operator >=(JET_COMMIT_ID lhs, JET_COMMIT_ID rhs)
	{
		return lhs.CompareTo(rhs) >= 0;
	}

	public static bool operator ==(JET_COMMIT_ID lhs, JET_COMMIT_ID rhs)
	{
		return lhs.CompareTo(rhs) == 0;
	}

	public static bool operator !=(JET_COMMIT_ID lhs, JET_COMMIT_ID rhs)
	{
		return lhs.CompareTo(rhs) != 0;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_COMMIT_ID({0}:{1}", signLog, commitId);
	}

	public int CompareTo(JET_COMMIT_ID other)
	{
		if ((object)other == null)
		{
			if (commitId <= 0)
			{
				return 0;
			}
			return 1;
		}
		if (signLog != other.signLog)
		{
			throw new ArgumentException("The commit-ids belong to different log-streams");
		}
		long num = commitId;
		return num.CompareTo(other.commitId);
	}

	public bool Equals(JET_COMMIT_ID other)
	{
		return CompareTo(other) == 0;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return CompareTo((JET_COMMIT_ID)obj) == 0;
	}

	public override int GetHashCode()
	{
		long num = commitId;
		return num.GetHashCode() ^ signLog.GetHashCode();
	}

	internal NATIVE_COMMIT_ID GetNativeCommitId()
	{
		return new NATIVE_COMMIT_ID
		{
			signLog = signLog.GetNativeSignature(),
			commitId = commitId
		};
	}
}
