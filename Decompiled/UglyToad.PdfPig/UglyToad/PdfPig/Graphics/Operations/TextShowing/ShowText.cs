using System;
using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.TextShowing;

public class ShowText : IGraphicsStateOperation
{
	public const string Symbol = "Tj";

	public string Operator => "Tj";

	public string? Text { get; }

	public ReadOnlyMemory<byte> Bytes { get; }

	public ShowText(string text)
	{
		Text = text;
	}

	public ShowText(ReadOnlyMemory<byte> hexBytes)
	{
		Bytes = hexBytes;
	}

	public void Run(IOperationContext operationContext)
	{
		MemoryInputBytes bytes = new MemoryInputBytes((Text != null) ? ((ReadOnlyMemory<byte>)OtherEncodings.StringAsLatin1Bytes(Text)) : Bytes);
		operationContext.ShowText(bytes);
	}

	private string? EscapeText(string? text)
	{
		if (text == null)
		{
			return null;
		}
		text = text.Replace("\\", "\\\\");
		text = text.Replace("(", "\\(");
		text = text.Replace(")", "\\)");
		return text;
	}

	public void Write(Stream stream)
	{
		if (!Bytes.IsEmpty)
		{
			stream.WriteHex(Bytes.Span);
		}
		else
		{
			string text = EscapeText(Text);
			stream.WriteText("(" + text + ")");
		}
		stream.WriteWhiteSpace();
		stream.WriteText("Tj");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return Text + " Tj";
	}
}
