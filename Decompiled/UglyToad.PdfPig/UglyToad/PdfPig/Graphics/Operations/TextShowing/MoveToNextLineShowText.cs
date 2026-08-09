using System;
using System.IO;
using UglyToad.PdfPig.Graphics.Operations.TextPositioning;

namespace UglyToad.PdfPig.Graphics.Operations.TextShowing;

public class MoveToNextLineShowText : IGraphicsStateOperation
{
	public const string Symbol = "'";

	public string Operator => "'";

	public string? Text { get; }

	public ReadOnlyMemory<byte> Bytes { get; }

	public MoveToNextLineShowText(string text)
	{
		Text = text;
	}

	public MoveToNextLineShowText(ReadOnlyMemory<byte> hexBytes)
	{
		Bytes = hexBytes;
	}

	public void Run(IOperationContext operationContext)
	{
		MoveToNextLine value = MoveToNextLine.Value;
		ShowText obj = ((Text != null) ? new ShowText(Text) : new ShowText(Bytes));
		value.Run(operationContext);
		obj.Run(operationContext);
	}

	public void Write(Stream stream)
	{
		if (Bytes.IsEmpty)
		{
			stream.WriteText("(" + Text + ") '");
			stream.WriteNewLine();
			return;
		}
		stream.WriteHex(Bytes.Span);
		stream.WriteWhiteSpace();
		stream.WriteText("'");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return Text + " '";
	}
}
