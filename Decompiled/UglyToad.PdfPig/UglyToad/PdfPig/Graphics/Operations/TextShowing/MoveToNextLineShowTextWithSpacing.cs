using System;
using System.IO;
using UglyToad.PdfPig.Graphics.Operations.TextPositioning;
using UglyToad.PdfPig.Graphics.Operations.TextState;

namespace UglyToad.PdfPig.Graphics.Operations.TextShowing;

public class MoveToNextLineShowTextWithSpacing : IGraphicsStateOperation
{
	public const string Symbol = "\"";

	public string Operator => "\"";

	public double WordSpacing { get; }

	public double CharacterSpacing { get; }

	public ReadOnlyMemory<byte> Bytes { get; }

	public string? Text { get; }

	public MoveToNextLineShowTextWithSpacing(double wordSpacing, double characterSpacing, string text)
	{
		WordSpacing = wordSpacing;
		CharacterSpacing = characterSpacing;
		Text = text;
	}

	public MoveToNextLineShowTextWithSpacing(double wordSpacing, double characterSpacing, ReadOnlyMemory<byte> hexBytes)
	{
		WordSpacing = wordSpacing;
		CharacterSpacing = characterSpacing;
		Bytes = hexBytes;
	}

	public void Run(IOperationContext operationContext)
	{
		SetWordSpacing setWordSpacing = new SetWordSpacing(WordSpacing);
		SetCharacterSpacing setCharacterSpacing = new SetCharacterSpacing(CharacterSpacing);
		MoveToNextLine value = MoveToNextLine.Value;
		ShowText obj = ((Text != null) ? new ShowText(Text) : new ShowText(Bytes));
		setWordSpacing.Run(operationContext);
		setCharacterSpacing.Run(operationContext);
		value.Run(operationContext);
		obj.Run(operationContext);
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(WordSpacing);
		stream.WriteWhiteSpace();
		stream.WriteDouble(CharacterSpacing);
		stream.WriteWhiteSpace();
		if (!Bytes.IsEmpty)
		{
			stream.WriteHex(Bytes.Span);
		}
		else
		{
			stream.WriteText("(" + Text + ")");
		}
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2} {3}", WordSpacing, CharacterSpacing, Text, "\"");
	}
}
