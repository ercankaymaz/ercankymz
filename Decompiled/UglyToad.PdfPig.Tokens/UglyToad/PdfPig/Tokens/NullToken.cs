using System;

namespace UglyToad.PdfPig.Tokens;

public class NullToken : IDataToken<object>, IToken, IEquatable<IToken>
{
	public static NullToken Instance { get; } = new NullToken();

	public object Data { get; }

	private NullToken()
	{
	}

	public override bool Equals(object obj)
	{
		return obj is NullToken;
	}

	protected bool Equals(NullToken other)
	{
		return object.Equals(Data, other.Data);
	}

	public bool Equals(IToken obj)
	{
		return obj is NullToken;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override string ToString()
	{
		return "null";
	}
}
