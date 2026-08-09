using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokenization;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Fonts.Type1.Parser;

public class Type1NameTokenizer : ITokenizer
{
	public bool ReadsNextByte { get; } = true;

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token)
	{
		token = null;
		if (currentByte != 47)
		{
			return false;
		}
		StringBuilder stringBuilder = new StringBuilder();
		while (inputBytes.MoveNext() && !ReadHelper.IsWhitespace(inputBytes.CurrentByte) && inputBytes.CurrentByte != 123 && inputBytes.CurrentByte != 60 && inputBytes.CurrentByte != 47 && inputBytes.CurrentByte != 91 && inputBytes.CurrentByte != 40)
		{
			stringBuilder.Append((char)inputBytes.CurrentByte);
		}
		token = NameToken.Create(stringBuilder.ToString());
		return true;
	}
}
