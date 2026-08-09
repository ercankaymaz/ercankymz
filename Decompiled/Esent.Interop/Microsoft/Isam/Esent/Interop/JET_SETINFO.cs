using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public class JET_SETINFO : IContentEquatable<JET_SETINFO>, IDeepCloneable<JET_SETINFO>
{
	private int longValueOffset;

	private int itag;

	public int ibLongValue
	{
		get
		{
			return longValueOffset;
		}
		set
		{
			longValueOffset = value;
		}
	}

	public int itagSequence
	{
		get
		{
			return itag;
		}
		set
		{
			itag = value;
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_SETINFO(ibLongValue={0},itagSequence={1})", ibLongValue, itagSequence);
	}

	public bool ContentEquals(JET_SETINFO other)
	{
		if (other == null)
		{
			return false;
		}
		if (ibLongValue == other.ibLongValue)
		{
			return itagSequence == other.itagSequence;
		}
		return false;
	}

	public JET_SETINFO DeepClone()
	{
		return (JET_SETINFO)MemberwiseClone();
	}

	internal NATIVE_SETINFO GetNativeSetinfo()
	{
		return checked(new NATIVE_SETINFO
		{
			cbStruct = (uint)NATIVE_SETINFO.Size,
			ibLongValue = (uint)ibLongValue,
			itagSequence = (uint)itagSequence
		});
	}
}
