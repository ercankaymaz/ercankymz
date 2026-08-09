using System;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Tokens;

public class IndirectReferenceToken : IDataToken<IndirectReference>, IToken, IEquatable<IToken>
{
	public IndirectReference Data { get; }

	public IndirectReferenceToken(IndirectReference data)
	{
		Data = data;
	}

	public bool Equals(IToken obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is IndirectReferenceToken indirectReferenceToken))
		{
			return false;
		}
		return Data.Equals(indirectReferenceToken.Data);
	}

	public override string ToString()
	{
		return $"{Data}";
	}
}
