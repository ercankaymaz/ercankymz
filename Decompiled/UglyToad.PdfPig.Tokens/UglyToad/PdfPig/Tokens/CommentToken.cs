using System;

namespace UglyToad.PdfPig.Tokens;

public class CommentToken : IDataToken<string>, IToken, IEquatable<IToken>
{
	public string Data { get; }

	public CommentToken(string data)
	{
		Data = data ?? string.Empty;
	}

	public override string ToString()
	{
		return Data;
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is CommentToken commentToken))
		{
			return false;
		}
		return commentToken.Data == Data;
	}
}
