using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization;

internal sealed class HexTokenizer : ITokenizer
{
	public bool ReadsNextByte { get; }

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token)
	{
		token = null;
		if (currentByte != 60)
		{
			return false;
		}
		using ArrayPoolBufferWriter<char> arrayPoolBufferWriter = new ArrayPoolBufferWriter<char>();
		while (inputBytes.MoveNext())
		{
			byte currentByte2 = inputBytes.CurrentByte;
			if (!ReadHelper.IsWhitespace(currentByte2))
			{
				if (currentByte2 == 62)
				{
					break;
				}
				if (!IsValidHexCharacter(currentByte2))
				{
					return false;
				}
				arrayPoolBufferWriter.Write((char)currentByte2);
			}
		}
		token = new HexToken(arrayPoolBufferWriter.WrittenSpan);
		return true;
	}

	private static bool IsValidHexCharacter(byte b)
	{
		if ((b < 48 || b > 57) && (b < 97 || b > 102))
		{
			if (b >= 65)
			{
				return b <= 70;
			}
			return false;
		}
		return true;
	}
}
