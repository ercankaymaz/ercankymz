using System.Collections.Generic;
using System.Text;

namespace CSUtilities.Text;

internal class TextEncoding : Encoding
{
	private string _name;

	private char[] _chars;

	private byte[] _bytes;

	private Dictionary<char, byte> m_relation;

	public override string BodyName => _name;

	public override string EncodingName => _name;

	public override string HeaderName => _name;

	public override string WebName => _name;

	public static Encoding GetListedEncoding(CodePage code)
	{
		if (code <= CSUtilities.Text.CodePage.Xcp20269)
		{
			switch (code)
			{
			case CSUtilities.Text.CodePage.Unknown:
				return Encoding.Default;
			case CSUtilities.Text.CodePage.Windows1252:
				return Windows1252();
			case CSUtilities.Text.CodePage.Usascii:
				return Encoding.ASCII;
			case CSUtilities.Text.CodePage.Ibm037:
			case CSUtilities.Text.CodePage.Ibm437:
			case CSUtilities.Text.CodePage.Asmo708:
			case CSUtilities.Text.CodePage.Dos720:
			case CSUtilities.Text.CodePage.Ibm737:
			case CSUtilities.Text.CodePage.Ibm775:
			case CSUtilities.Text.CodePage.Ibm850:
			case CSUtilities.Text.CodePage.Ibm852:
			case CSUtilities.Text.CodePage.Ibm855:
			case CSUtilities.Text.CodePage.Ibm857:
			case CSUtilities.Text.CodePage.Ibm860:
			case CSUtilities.Text.CodePage.Ibm861:
			case CSUtilities.Text.CodePage.Dos862:
			case CSUtilities.Text.CodePage.Ibm863:
			case CSUtilities.Text.CodePage.Ibm864:
			case CSUtilities.Text.CodePage.Ibm865:
			case CSUtilities.Text.CodePage.Cp866:
			case CSUtilities.Text.CodePage.Ibm869:
			case CSUtilities.Text.CodePage.Ibm870:
			case CSUtilities.Text.CodePage.Windows874:
			case CSUtilities.Text.CodePage.Cp875:
			case CSUtilities.Text.CodePage.Shift_jis:
			case CSUtilities.Text.CodePage.Gb2312:
			case CSUtilities.Text.CodePage.Ksc5601:
			case CSUtilities.Text.CodePage.big5:
			case CSUtilities.Text.CodePage.Ibm1026:
			case CSUtilities.Text.CodePage.Ibm01047:
			case CSUtilities.Text.CodePage.Ibm01140:
			case CSUtilities.Text.CodePage.Ibm01141:
			case CSUtilities.Text.CodePage.Ibm01142:
			case CSUtilities.Text.CodePage.Ibm01143:
			case CSUtilities.Text.CodePage.Ibm01144:
			case CSUtilities.Text.CodePage.Ibm01145:
			case CSUtilities.Text.CodePage.Ibm01146:
			case CSUtilities.Text.CodePage.Ibm01147:
			case CSUtilities.Text.CodePage.Ibm01148:
			case CSUtilities.Text.CodePage.Ibm01149:
			case CSUtilities.Text.CodePage.Utf16:
			case CSUtilities.Text.CodePage.UnicodeFFFE:
			case CSUtilities.Text.CodePage.Windows1250:
			case CSUtilities.Text.CodePage.Windows1251:
			case CSUtilities.Text.CodePage.Windows1253:
			case CSUtilities.Text.CodePage.Windows1254:
			case CSUtilities.Text.CodePage.Windows1255:
			case CSUtilities.Text.CodePage.Windows1256:
			case CSUtilities.Text.CodePage.Windows1257:
			case CSUtilities.Text.CodePage.Windows1258:
			case CSUtilities.Text.CodePage.Johab:
			case CSUtilities.Text.CodePage.Macintosh:
			case CSUtilities.Text.CodePage.Xmacjapanese:
			case CSUtilities.Text.CodePage.Xmacchinesetrad:
			case CSUtilities.Text.CodePage.Xmackorean:
			case CSUtilities.Text.CodePage.Xmacarabic:
			case CSUtilities.Text.CodePage.Xmachebrew:
			case CSUtilities.Text.CodePage.Xmacgreek:
			case CSUtilities.Text.CodePage.Xmaccyrillic:
			case CSUtilities.Text.CodePage.Xmacchinesesimp:
			case CSUtilities.Text.CodePage.Xmacromanian:
			case CSUtilities.Text.CodePage.Xmacukrainian:
			case CSUtilities.Text.CodePage.Xmacthai:
			case CSUtilities.Text.CodePage.Xmacce:
			case CSUtilities.Text.CodePage.Xmacicelandic:
			case CSUtilities.Text.CodePage.Xmacturkish:
			case CSUtilities.Text.CodePage.Xmaccroatian:
			case CSUtilities.Text.CodePage.Utf32:
			case CSUtilities.Text.CodePage.Utf32BE:
			case CSUtilities.Text.CodePage.XChineseCNS:
			case CSUtilities.Text.CodePage.Xcp20001:
			case CSUtilities.Text.CodePage.XChineseEten:
			case CSUtilities.Text.CodePage.Xcp20003:
			case CSUtilities.Text.CodePage.Xcp20004:
			case CSUtilities.Text.CodePage.Xcp20005:
			case CSUtilities.Text.CodePage.XIA5:
			case CSUtilities.Text.CodePage.XIA5German:
			case CSUtilities.Text.CodePage.XIA5Swedish:
			case CSUtilities.Text.CodePage.XIA5Norwegian:
			case CSUtilities.Text.CodePage.Xcp20261:
			case CSUtilities.Text.CodePage.Xcp20269:
				goto IL_05f0;
			}
		}
		else
		{
			switch (code)
			{
			case CSUtilities.Text.CodePage.Utf7:
				return Encoding.UTF7;
			case CSUtilities.Text.CodePage.Utf8:
				return Encoding.UTF8;
			case CSUtilities.Text.CodePage.Ibm273:
			case CSUtilities.Text.CodePage.Ibm277:
			case CSUtilities.Text.CodePage.Ibm278:
			case CSUtilities.Text.CodePage.Ibm280:
			case CSUtilities.Text.CodePage.Ibm284:
			case CSUtilities.Text.CodePage.Ibm285:
			case CSUtilities.Text.CodePage.Ibm290:
			case CSUtilities.Text.CodePage.Ibm297:
			case CSUtilities.Text.CodePage.Ibm420:
			case CSUtilities.Text.CodePage.Ibm423:
			case CSUtilities.Text.CodePage.Ibm424:
			case CSUtilities.Text.CodePage.XEBCDICKoreanExtended:
			case CSUtilities.Text.CodePage.IbmThai:
			case CSUtilities.Text.CodePage.Koi8r:
			case CSUtilities.Text.CodePage.Ibm871:
			case CSUtilities.Text.CodePage.Ibm880:
			case CSUtilities.Text.CodePage.Ibm905:
			case CSUtilities.Text.CodePage.Ibm00924:
			case CSUtilities.Text.CodePage.EUCJP:
			case CSUtilities.Text.CodePage.Xcp20936:
			case CSUtilities.Text.CodePage.Xcp20949:
			case CSUtilities.Text.CodePage.Cp1025:
			case CSUtilities.Text.CodePage.Koi8u:
			case CSUtilities.Text.CodePage.Iso88591:
			case CSUtilities.Text.CodePage.Iso88592:
			case CSUtilities.Text.CodePage.Iso88593:
			case CSUtilities.Text.CodePage.Iso88594:
			case CSUtilities.Text.CodePage.Iso88595:
			case CSUtilities.Text.CodePage.Iso88596:
			case CSUtilities.Text.CodePage.Iso88597:
			case CSUtilities.Text.CodePage.Iso88598:
			case CSUtilities.Text.CodePage.Iso88599:
			case CSUtilities.Text.CodePage.Iso885913:
			case CSUtilities.Text.CodePage.Iso885915:
			case CSUtilities.Text.CodePage.XEuropa:
			case CSUtilities.Text.CodePage.Iso88598i:
			case CSUtilities.Text.CodePage.Iso2022jp:
			case CSUtilities.Text.CodePage.CsISO2022JP:
			case CSUtilities.Text.CodePage.Iso2022jp_jis:
			case CSUtilities.Text.CodePage.Iso2022kr:
			case CSUtilities.Text.CodePage.Xcp50227:
			case CSUtilities.Text.CodePage.Eucjp:
			case CSUtilities.Text.CodePage.EUCCN:
			case CSUtilities.Text.CodePage.Euckr:
			case CSUtilities.Text.CodePage.Hzgb2312:
			case CSUtilities.Text.CodePage.Gb18030:
			case CSUtilities.Text.CodePage.Xisciide:
			case CSUtilities.Text.CodePage.Xisciibe:
			case CSUtilities.Text.CodePage.Xisciita:
			case CSUtilities.Text.CodePage.Xisciite:
			case CSUtilities.Text.CodePage.Xisciias:
			case CSUtilities.Text.CodePage.Xisciior:
			case CSUtilities.Text.CodePage.Xisciika:
			case CSUtilities.Text.CodePage.Xisciima:
			case CSUtilities.Text.CodePage.Xisciigu:
			case CSUtilities.Text.CodePage.Xisciipa:
				goto IL_05f0;
			}
		}
		return Encoding.Default;
		IL_05f0:
		return null;
	}

	public TextEncoding(int code, string name, char[] chars, byte[] bytes)
		: base(code)
	{
		_name = name;
		_chars = chars;
		_bytes = bytes;
		m_relation = new Dictionary<char, byte>();
		for (int i = 0; i < 255; i++)
		{
			char c = chars[i];
			if (c > 'ÿ')
			{
				m_relation.Add(c, (byte)i);
			}
		}
	}

	public override int GetByteCount(char[] chars, int index, int count)
	{
		return count;
	}

	public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
	{
		int num = charIndex + charCount;
		while (charIndex < num)
		{
			char c = chars[charIndex];
			int num2 = c;
			byte value;
			if (num2 < 256)
			{
				value = _bytes[num2];
			}
			else if (!m_relation.TryGetValue(c, out value))
			{
				value = 63;
			}
			bytes[byteIndex] = value;
			charIndex++;
			byteIndex++;
		}
		return charCount;
	}

	public override int GetCharCount(byte[] bytes, int index, int count)
	{
		return count;
	}

	public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
	{
		int num = byteIndex + byteCount;
		while (byteIndex < num)
		{
			chars[charIndex] = _chars[bytes[byteIndex]];
			charIndex++;
			byteIndex++;
		}
		return byteCount;
	}

	public override int GetMaxByteCount(int charCount)
	{
		return charCount;
	}

	public override int GetMaxCharCount(int byteCount)
	{
		return byteCount;
	}

	public static Encoding Windows1252()
	{
		return new TextEncoding(1252, "Windows-1252", new char[256]
		{
			'\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\a', '\b', '\t',
			'\n', '\v', '\f', '\r', '\u000e', '\u000f', '\u0010', '\u0011', '\u0012', '\u0013',
			'\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019', '\u001a', '\u001b', '\u001c', '\u001d',
			'\u001e', '\u001f', ' ', '!', '"', '#', '$', '%', '&', '\'',
			'(', ')', '*', '+', ',', '-', '.', '/', '0', '1',
			'2', '3', '4', '5', '6', '7', '8', '9', ':', ';',
			'<', '=', '>', '?', '@', 'A', 'B', 'C', 'D', 'E',
			'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
			'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
			'Z', '[', '\\', ']', '^', '_', '`', 'a', 'b', 'c',
			'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
			'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
			'x', 'y', 'z', '{', '|', '}', '~', '\u007f', '€', '\u0081',
			'‚', 'ƒ', '„', '…', '†', '‡', 'ˆ', '‰', 'Š', '‹',
			'Œ', '\u008d', 'Ž', '\u008f', '\u0090', '‘', '’', '“', '”', '•',
			'–', '—', '\u02dc', '™', 'š', '›', 'œ', '\u009d', 'ž', 'Ÿ',
			'\u00a0', '¡', '¢', '£', '¤', '¥', '¦', '§', '\u00a8', '©',
			'ª', '«', '¬', '\u00ad', '®', '\u00af', '°', '±', '²', '³',
			'\u00b4', 'µ', '¶', '·', '\u00b8', '¹', 'º', '»', '¼', '½',
			'¾', '¿', 'À', 'Á', 'Â', 'Ã', 'Ä', 'Å', 'Æ', 'Ç',
			'È', 'É', 'Ê', 'Ë', 'Ì', 'Í', 'Î', 'Ï', 'Ð', 'Ñ',
			'Ò', 'Ó', 'Ô', 'Õ', 'Ö', '×', 'Ø', 'Ù', 'Ú', 'Û',
			'Ü', 'Ý', 'Þ', 'ß', 'à', 'á', 'â', 'ã', 'ä', 'å',
			'æ', 'ç', 'è', 'é', 'ê', 'ë', 'ì', 'í', 'î', 'ï',
			'ð', 'ñ', 'ò', 'ó', 'ô', 'õ', 'ö', '÷', 'ø', 'ù',
			'ú', 'û', 'ü', 'ý', 'þ', 'ÿ'
		}, new byte[256]
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
			20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
			30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
			40, 41, 42, 43, 44, 45, 46, 47, 48, 49,
			50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
			60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
			70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
			80, 81, 82, 83, 84, 85, 86, 87, 88, 89,
			90, 91, 92, 93, 94, 95, 96, 97, 98, 99,
			100, 101, 102, 103, 104, 105, 106, 107, 108, 109,
			110, 111, 112, 113, 114, 115, 116, 117, 118, 119,
			120, 121, 122, 123, 124, 125, 126, 127, 63, 129,
			63, 63, 63, 63, 63, 63, 63, 63, 63, 63,
			63, 141, 63, 143, 144, 63, 63, 63, 63, 63,
			63, 63, 63, 63, 63, 63, 63, 157, 63, 63,
			160, 161, 162, 163, 164, 165, 166, 167, 168, 169,
			170, 171, 172, 173, 174, 175, 176, 177, 178, 179,
			180, 181, 182, 183, 184, 185, 186, 187, 188, 189,
			190, 191, 192, 193, 194, 195, 196, 197, 198, 199,
			200, 201, 202, 203, 204, 205, 206, 207, 208, 209,
			210, 211, 212, 213, 214, 215, 216, 217, 218, 219,
			220, 221, 222, 223, 224, 225, 226, 227, 228, 229,
			230, 231, 232, 233, 234, 235, 236, 237, 238, 239,
			240, 241, 242, 243, 244, 245, 246, 247, 248, 249,
			250, 251, 252, 253, 254, 255
		});
	}
}
