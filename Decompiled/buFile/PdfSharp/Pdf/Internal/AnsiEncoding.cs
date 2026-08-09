using System.Text;

namespace PdfSharp.Pdf.Internal;

public sealed class AnsiEncoding : Encoding
{
	private static readonly char[] AnsiToUnicode = new char[256]
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
	};

	public override int GetByteCount(char[] chars, int index, int count)
	{
		return count;
	}

	public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
	{
		int result = charCount;
		while (charCount > 0)
		{
			bytes[byteIndex] = (byte)UnicodeToAnsi(chars[charIndex]);
			byteIndex++;
			charIndex++;
			charCount--;
		}
		return result;
	}

	public override int GetCharCount(byte[] bytes, int index, int count)
	{
		return count;
	}

	public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
	{
		for (int num = byteCount; num > 0; num--)
		{
			chars[charIndex] = AnsiToUnicode[bytes[byteIndex]];
			byteIndex++;
			charIndex++;
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

	public static bool IsAnsi1252Char(char ch)
	{
		if (ch < '\u0080' || (ch >= '\u00a0' && ch <= 'ÿ'))
		{
			return true;
		}
		switch (ch)
		{
		case '\u0081':
		case '\u008d':
		case '\u008f':
		case '\u0090':
		case '\u009d':
		case 'Œ':
		case 'œ':
		case 'Š':
		case 'š':
		case 'Ÿ':
		case 'Ž':
		case 'ž':
		case 'ƒ':
		case 'ˆ':
		case '\u02dc':
		case '–':
		case '—':
		case '‘':
		case '’':
		case '‚':
		case '“':
		case '”':
		case '„':
		case '†':
		case '‡':
		case '•':
		case '…':
		case '‰':
		case '‹':
		case '›':
		case '€':
		case '™':
			return true;
		default:
			return false;
		}
	}

	public static char UnicodeToAnsi(char ch)
	{
		if (ch < '\u0080' || (ch >= '\u00a0' && ch <= 'ÿ'))
		{
			return ch;
		}
		return ch switch
		{
			'€' => '\u0080', 
			'\u0081' => '\u0081', 
			'‚' => '\u0082', 
			'ƒ' => '\u0083', 
			'„' => '\u0084', 
			'…' => '\u0085', 
			'†' => '\u0086', 
			'‡' => '\u0087', 
			'ˆ' => '\u0088', 
			'‰' => '\u0089', 
			'Š' => '\u008a', 
			'‹' => '\u008b', 
			'Œ' => '\u008c', 
			'\u008d' => '\u008d', 
			'Ž' => '\u008e', 
			'\u008f' => '\u008f', 
			'\u0090' => '\u0090', 
			'‘' => '\u0091', 
			'’' => '\u0092', 
			'“' => '\u0093', 
			'”' => '\u0094', 
			'•' => '\u0095', 
			'–' => '\u0096', 
			'—' => '\u0097', 
			'\u02dc' => '\u0098', 
			'™' => '\u0099', 
			'š' => '\u009a', 
			'›' => '\u009b', 
			'œ' => '\u009c', 
			'\u009d' => '\u009d', 
			'ž' => '\u009e', 
			'Ÿ' => '\u009f', 
			_ => '¤', 
		};
	}
}
