using System;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization.Scanner;

internal readonly struct PossibleStreamEndLocation
{
	public long Offset { get; }

	public OperatorToken Type { get; }

	public PossibleStreamEndLocation(long offset, OperatorToken type)
	{
		Offset = offset;
		Type = type ?? throw new ArgumentNullException("type");
	}

	public override string ToString()
	{
		return $"{Offset}: {Type}";
	}
}
