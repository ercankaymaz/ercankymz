using System;
using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization;

internal sealed class PlainTokenizer : ITokenizer
{
	public bool ReadsNextByte { get; } = true;

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token)
	{
		if (ReadHelper.IsWhitespace(currentByte))
		{
			token = null;
			return false;
		}
		Span<char> initialBuffer = stackalloc char[16];
		using ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
		valueStringBuilder.Append((char)currentByte);
		while (inputBytes.MoveNext() && !ReadHelper.IsWhitespace(inputBytes.CurrentByte))
		{
			bool flag;
			switch (inputBytes.CurrentByte)
			{
			case 40:
			case 41:
			case 47:
			case 60:
			case 62:
			case 91:
			case 93:
				flag = true;
				break;
			default:
				flag = false;
				break;
			}
			if (flag)
			{
				break;
			}
			valueStringBuilder.Append((char)inputBytes.CurrentByte);
		}
		ReadOnlySpan<char> readOnlySpan = valueStringBuilder.AsSpan();
		token = readOnlySpan switch
		{
			"true" => BooleanToken.True, 
			"false" => BooleanToken.False, 
			"null" => NullToken.Instance, 
			_ => OperatorToken.Create(readOnlySpan), 
		};
		return true;
	}
}
