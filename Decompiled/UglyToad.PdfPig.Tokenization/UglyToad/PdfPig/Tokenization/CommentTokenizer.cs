using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization;

internal sealed class CommentTokenizer : ITokenizer
{
	public bool ReadsNextByte { get; } = true;

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token)
	{
		token = null;
		if (currentByte != 37)
		{
			return false;
		}
		using ValueStringBuilder valueStringBuilder = default(ValueStringBuilder);
		while (inputBytes.MoveNext() && !ReadHelper.IsEndOfLine(inputBytes.CurrentByte))
		{
			valueStringBuilder.Append((char)inputBytes.CurrentByte);
		}
		token = new CommentToken(valueStringBuilder.ToString());
		return true;
	}
}
