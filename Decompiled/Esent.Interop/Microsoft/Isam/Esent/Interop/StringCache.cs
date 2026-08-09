namespace Microsoft.Isam.Esent.Interop;

internal static class StringCache
{
	private const int MaxLengthToCache = 128;

	private const int NumCachedBoxedValues = 1031;

	private static readonly string[] CachedStrings = new string[1031];

	public static string TryToIntern(string s)
	{
		return string.IsInterned(s) ?? s;
	}

	public unsafe static string GetString(byte[] value, int startIndex, int count)
	{
		fixed (byte* ptr = value)
		{
			char* value2 = (char*)checked(unchecked((nuint)ptr) + unchecked((nuint)startIndex));
			return GetString(value2, 0, count / 2);
		}
	}

	private unsafe static string GetString(char* value, int startIndex, int count)
	{
		string text;
		if (count == 0)
		{
			text = string.Empty;
		}
		else if (count < 128)
		{
			int num = (int)(CalculateHash(value, startIndex, count) % 1031);
			text = CachedStrings[num];
			if (text == null || !AreEqual(text, value, startIndex, count))
			{
				text = CreateNewString(value, startIndex, count);
				CachedStrings[num] = text;
			}
		}
		else
		{
			text = CreateNewString(value, startIndex, count);
		}
		return text;
	}

	private unsafe static uint CalculateHash(char* value, int startIndex, int count)
	{
		uint num = 0u;
		for (int i = 0; i < count; i++)
		{
			num ^= value[startIndex + i];
			num *= 33;
		}
		return num;
	}

	private unsafe static bool AreEqual(string s, char* value, int startIndex, int count)
	{
		if (s.Length != count)
		{
			return false;
		}
		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] != value[startIndex + i])
			{
				return false;
			}
		}
		return true;
	}

	private unsafe static string CreateNewString(char* value, int startIndex, int count)
	{
		return new string(value, startIndex, count);
	}
}
