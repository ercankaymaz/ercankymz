using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public sealed class JET_UNICODEINDEX : IContentEquatable<JET_UNICODEINDEX>, IDeepCloneable<JET_UNICODEINDEX>
{
	private int localeId;

	private string localeName;

	private uint mapStringFlags;

	private static readonly Dictionary<int, string> LcidToLocales;

	public int lcid
	{
		[DebuggerStepThrough]
		get
		{
			return localeId;
		}
		set
		{
			localeId = value;
		}
	}

	public string szLocaleName
	{
		[DebuggerStepThrough]
		get
		{
			return localeName;
		}
		set
		{
			localeName = value;
		}
	}

	[CLSCompliant(false)]
	public uint dwMapFlags
	{
		[DebuggerStepThrough]
		get
		{
			return mapStringFlags;
		}
		set
		{
			mapStringFlags = value;
		}
	}

	public JET_UNICODEINDEX DeepClone()
	{
		return (JET_UNICODEINDEX)MemberwiseClone();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_UNICODEINDEX({0}:{1}:0x{2:X})", localeId, localeName, mapStringFlags);
	}

	public bool ContentEquals(JET_UNICODEINDEX other)
	{
		if (other == null)
		{
			return false;
		}
		if (localeId == other.localeId && mapStringFlags == other.mapStringFlags)
		{
			return string.Compare(localeName, other.localeName, StringComparison.OrdinalIgnoreCase) == 0;
		}
		return false;
	}

	internal NATIVE_UNICODEINDEX GetNativeUnicodeIndex()
	{
		if (!string.IsNullOrEmpty(localeName))
		{
			throw new ArgumentException("localeName was specified, but this version of the API does not accept locale names. Use LCIDs or a different API.");
		}
		return new NATIVE_UNICODEINDEX
		{
			lcid = checked((uint)lcid),
			dwMapFlags = dwMapFlags
		};
	}

	static JET_UNICODEINDEX()
	{
		LcidToLocales = new Dictionary<int, string>(10);
		LcidToLocales.Add(127, string.Empty);
		LcidToLocales.Add(1033, "en-us");
		LcidToLocales.Add(1046, "pt-br");
		LcidToLocales.Add(3084, "fr-ca");
	}

	public JET_UNICODEINDEX()
	{
	}

	internal JET_UNICODEINDEX(ref NATIVE_UNICODEINDEX2 native)
	{
		szLocaleName = Marshal.PtrToStringUni(native.szLocaleName);
		dwMapFlags = native.dwMapFlags;
	}

	public string GetEffectiveLocaleName()
	{
		if (szLocaleName != null)
		{
			return szLocaleName;
		}
		return LimitedLcidToLocaleNameMapping(lcid);
	}

	internal static string LimitedLcidToLocaleNameMapping(int lcid)
	{
		LcidToLocales.TryGetValue(lcid, out var value);
		return value;
	}

	internal NATIVE_UNICODEINDEX2 GetNativeUnicodeIndex2()
	{
		if (lcid != 0 && !LcidToLocales.ContainsKey(lcid))
		{
			throw new ArgumentException("lcid was specified, but this version of the API does not accept LCIDs. Use a locale name or a different API.");
		}
		return new NATIVE_UNICODEINDEX2
		{
			dwMapFlags = dwMapFlags
		};
	}
}
