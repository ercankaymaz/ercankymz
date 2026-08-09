using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public class JET_SNPROG : IEquatable<JET_SNPROG>
{
	private int completedUnits;

	private int totalUnits;

	public int cunitDone
	{
		[DebuggerStepThrough]
		get
		{
			return completedUnits;
		}
		internal set
		{
			completedUnits = value;
		}
	}

	public int cunitTotal
	{
		[DebuggerStepThrough]
		get
		{
			return totalUnits;
		}
		internal set
		{
			totalUnits = value;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_SNPROG)obj);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_SNPROG({0}/{1})", cunitDone, cunitTotal);
	}

	public override int GetHashCode()
	{
		return (cunitDone * 31) ^ cunitTotal;
	}

	public bool Equals(JET_SNPROG other)
	{
		if (other == null)
		{
			return false;
		}
		if (cunitDone == other.cunitDone)
		{
			return cunitTotal == other.cunitTotal;
		}
		return false;
	}

	internal void SetFromNative(NATIVE_SNPROG native)
	{
		checked
		{
			cunitDone = (int)native.cunitDone;
			cunitTotal = (int)native.cunitTotal;
		}
	}
}
