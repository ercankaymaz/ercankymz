using System;
using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer;

namespace UglyToad.PdfPig.Graphics.Operations.TextShowing;

public class ShowTextsWithPositioning : IGraphicsStateOperation
{
	private static readonly TokenWriter TokenWriter = new TokenWriter();

	public const string Symbol = "TJ";

	public string Operator => "TJ";

	public IReadOnlyList<IToken> Array { get; }

	public ShowTextsWithPositioning(IReadOnlyList<IToken> array)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		for (int i = 0; i < array.Count; i++)
		{
			IToken token = array[i];
			if (!(token is StringToken) && !(token is NumericToken) && !(token is HexToken))
			{
				throw new ArgumentException($"Found invalid token for showing texts with position: {token}");
			}
		}
		Array = array;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.ShowPositionedText(Array);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("["u8);
		for (int i = 0; i < Array.Count; i++)
		{
			TokenWriter.WriteToken(Array[i], stream);
			if (i < Array.Count - 1)
			{
				stream.WriteWhiteSpace();
			}
		}
		stream.WriteText("]"u8);
		stream.WriteWhiteSpace();
		stream.WriteText("TJ");
		stream.WriteNewLine();
	}
}
