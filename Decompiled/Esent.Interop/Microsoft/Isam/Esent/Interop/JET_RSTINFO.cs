using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public class JET_RSTINFO : IContentEquatable<JET_RSTINFO>, IDeepCloneable<JET_RSTINFO>
{
	public JET_RSTMAP[] rgrstmap { get; set; }

	public int crstmap { get; set; }

	public JET_LGPOS lgposStop { get; set; }

	public JET_LOGTIME logtimeStop { get; set; }

	public JET_PFNSTATUS pfnStatus { get; set; }

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_RSTINFO(crstmap={0})", crstmap);
	}

	public bool ContentEquals(JET_RSTINFO other)
	{
		if (other == null)
		{
			return false;
		}
		CheckMembersAreValid();
		other.CheckMembersAreValid();
		if (crstmap == other.crstmap && lgposStop == other.lgposStop && logtimeStop == other.logtimeStop && pfnStatus == other.pfnStatus)
		{
			return Util.ArrayObjectContentEquals(rgrstmap, other.rgrstmap, crstmap);
		}
		return false;
	}

	public JET_RSTINFO DeepClone()
	{
		JET_RSTINFO obj = (JET_RSTINFO)MemberwiseClone();
		obj.rgrstmap = Util.DeepCloneArray(rgrstmap);
		return obj;
	}

	internal void CheckMembersAreValid()
	{
		if (crstmap < 0)
		{
			throw new ArgumentOutOfRangeException("crstmap", crstmap, "cannot be negative");
		}
		if (rgrstmap == null && crstmap > 0)
		{
			throw new ArgumentOutOfRangeException("crstmap", crstmap, "must be zero");
		}
		if (rgrstmap != null && crstmap > rgrstmap.Length)
		{
			throw new ArgumentOutOfRangeException("crstmap", crstmap, "cannot be greater than the length of rgrstmap");
		}
	}

	internal NATIVE_RSTINFO GetNativeRstinfo()
	{
		CheckMembersAreValid();
		return checked(new NATIVE_RSTINFO
		{
			cbStruct = (uint)NATIVE_RSTINFO.SizeOfRstinfo,
			crstmap = (uint)crstmap,
			lgposStop = lgposStop,
			logtimeStop = logtimeStop
		});
	}
}
