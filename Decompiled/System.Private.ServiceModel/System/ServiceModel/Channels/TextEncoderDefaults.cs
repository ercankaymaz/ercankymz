using System.Text;

namespace System.ServiceModel.Channels;

internal static class TextEncoderDefaults
{
	public class CharSetEncoding
	{
		public string CharSet;

		public Encoding Encoding;

		public CharSetEncoding(string charSet, Encoding enc)
		{
			CharSet = charSet;
			Encoding = enc;
		}
	}

	public static readonly Encoding Encoding = Encoding.GetEncoding("utf-8");

	public const string EncodingString = "utf-8";

	public static readonly Encoding[] SupportedEncodings = new Encoding[3]
	{
		Encoding.UTF8,
		Encoding.Unicode,
		Encoding.BigEndianUnicode
	};

	public const string MessageVersionString = "Soap12WSAddressing10";

	public static readonly CharSetEncoding[] CharSetEncodings = new CharSetEncoding[5]
	{
		new CharSetEncoding("utf-8", Encoding.UTF8),
		new CharSetEncoding("utf-16LE", Encoding.Unicode),
		new CharSetEncoding("utf-16BE", Encoding.BigEndianUnicode),
		new CharSetEncoding("utf-16", null),
		new CharSetEncoding(null, null)
	};

	public static void ValidateEncoding(Encoding encoding)
	{
		string webName = encoding.WebName;
		Encoding[] supportedEncodings = SupportedEncodings;
		for (int i = 0; i < supportedEncodings.Length; i++)
		{
			if (webName == supportedEncodings[i].WebName)
			{
				return;
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.MessageTextEncodingNotSupported, webName), "encoding"));
	}

	public static string EncodingToCharSet(Encoding encoding)
	{
		string webName = encoding.WebName;
		CharSetEncoding[] charSetEncodings = CharSetEncodings;
		for (int i = 0; i < charSetEncodings.Length; i++)
		{
			Encoding encoding2 = charSetEncodings[i].Encoding;
			if (encoding2 != null && encoding2.WebName == webName)
			{
				return charSetEncodings[i].CharSet;
			}
		}
		return null;
	}

	public static bool TryGetEncoding(string charSet, out Encoding encoding)
	{
		CharSetEncoding[] charSetEncodings = CharSetEncodings;
		for (int i = 0; i < charSetEncodings.Length; i++)
		{
			if (charSetEncodings[i].CharSet == charSet)
			{
				encoding = charSetEncodings[i].Encoding;
				return true;
			}
		}
		for (int j = 0; j < charSetEncodings.Length; j++)
		{
			string charSet2 = charSetEncodings[j].CharSet;
			if (charSet2 != null && charSet2.Equals(charSet, StringComparison.OrdinalIgnoreCase))
			{
				encoding = charSetEncodings[j].Encoding;
				return true;
			}
		}
		encoding = null;
		return false;
	}
}
