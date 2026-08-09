using System;
using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer;

namespace UglyToad.PdfPig.Graphics.Operations.InlineImages;

public class BeginInlineImageData : IGraphicsStateOperation
{
	public const string Symbol = "ID";

	public string Operator => "ID";

	public IReadOnlyDictionary<NameToken, IToken> Dictionary { get; }

	public BeginInlineImageData(IReadOnlyDictionary<NameToken, IToken> dictionary)
	{
		Dictionary = dictionary ?? throw new ArgumentNullException("dictionary");
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetInlineImageProperties(Dictionary);
	}

	public void Write(Stream stream)
	{
		TokenWriter instance = TokenWriter.Instance;
		foreach (KeyValuePair<NameToken, IToken> item in Dictionary)
		{
			NameToken key = item.Key;
			IToken value = item.Value;
			stream.WriteText($"{key} ");
			instance.WriteToken(value, stream);
			stream.WriteNewLine();
		}
		stream.WriteText("ID");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "ID";
	}
}
