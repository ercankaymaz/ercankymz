using System;

namespace UglyToad.PdfPig.Tokens;

public sealed class BooleanToken : IDataToken<bool>, IToken, IEquatable<IToken>
{
	public static BooleanToken True { get; } = new BooleanToken(data: true);

	public static BooleanToken False { get; } = new BooleanToken(data: false);

	public bool Data { get; }

	private BooleanToken(bool data)
	{
		Data = data;
	}

	public override int GetHashCode()
	{
		return Data.GetHashCode();
	}

	public override string ToString()
	{
		return Data.ToString();
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is BooleanToken booleanToken))
		{
			return false;
		}
		return booleanToken.Data == Data;
	}
}
