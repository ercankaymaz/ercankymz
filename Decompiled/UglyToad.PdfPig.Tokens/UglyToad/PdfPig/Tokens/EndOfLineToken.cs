using System;

namespace UglyToad.PdfPig.Tokens;

public class EndOfLineToken : IToken, IEquatable<IToken>
{
	public static EndOfLineToken Token { get; } = new EndOfLineToken();

	private EndOfLineToken()
	{
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		return obj is EndOfLineToken;
	}
}
