using System;
using Org.BouncyCastle.Utilities.Date;

namespace Org.BouncyCastle.Utilities;

internal static class Enums
{
	internal static TEnum GetEnumValue<TEnum>(string s) where TEnum : struct, Enum
	{
		if (s.Length > 0 && char.IsLetter(s[0]) && s.IndexOf(',') < 0)
		{
			s = s.Replace('-', '_');
			s = s.Replace('/', '_');
			return (TEnum)Enum.Parse(typeof(TEnum), s, ignoreCase: false);
		}
		throw new ArgumentException();
	}

	internal static TEnum[] GetEnumValues<TEnum>() where TEnum : struct, Enum
	{
		return (TEnum[])Enum.GetValues(typeof(TEnum));
	}

	internal static TEnum GetArbitraryValue<TEnum>() where TEnum : struct, Enum
	{
		TEnum[] enumValues = GetEnumValues<TEnum>();
		int num = (int)(DateTimeUtilities.CurrentUnixMs() & 0x7FFFFFFF) % enumValues.Length;
		return enumValues[num];
	}
}
