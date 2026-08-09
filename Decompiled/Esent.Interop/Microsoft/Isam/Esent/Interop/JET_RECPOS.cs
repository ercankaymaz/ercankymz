using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class JET_RECPOS : IContentEquatable<JET_RECPOS>, IDeepCloneable<JET_RECPOS>
{
	private long entriesBeforeKey;

	private long totalEntries;

	public long centriesLT
	{
		[DebuggerStepThrough]
		get
		{
			return entriesBeforeKey;
		}
		set
		{
			entriesBeforeKey = value;
		}
	}

	public long centriesTotal
	{
		[DebuggerStepThrough]
		get
		{
			return totalEntries;
		}
		set
		{
			totalEntries = value;
		}
	}

	public JET_RECPOS DeepClone()
	{
		return (JET_RECPOS)MemberwiseClone();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_RECPOS({0}/{1})", entriesBeforeKey, totalEntries);
	}

	public bool ContentEquals(JET_RECPOS other)
	{
		if (other == null)
		{
			return false;
		}
		if (entriesBeforeKey == other.entriesBeforeKey)
		{
			return totalEntries == other.totalEntries;
		}
		return false;
	}

	internal NATIVE_RECPOS GetNativeRecpos()
	{
		return checked(new NATIVE_RECPOS
		{
			cbStruct = (uint)NATIVE_RECPOS.Size,
			centriesLT = (uint)centriesLT,
			centriesTotal = (uint)centriesTotal
		});
	}

	internal void SetFromNativeRecpos(NATIVE_RECPOS value)
	{
		checked
		{
			centriesLT = (int)value.centriesLT;
			centriesTotal = (int)value.centriesTotal;
		}
	}
}
