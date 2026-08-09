using System;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Tokens;

public class ObjectToken : IDataToken<IToken>, IToken, IEquatable<IToken>
{
	public long Position { get; }

	public IndirectReference Number { get; }

	public IToken Data { get; }

	public ObjectToken(long position, IndirectReference number, IToken data)
	{
		Position = position;
		Number = number;
		Data = data ?? throw new ArgumentNullException("data");
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is ObjectToken objectToken))
		{
			return false;
		}
		if (Number.Equals(objectToken.Number))
		{
			return Data.Equals(objectToken.Data);
		}
		return false;
	}

	public override string ToString()
	{
		return $"Number: {Number}, Position: {Position}, Type: {Data.GetType().Name}";
	}
}
