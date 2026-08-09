using System;
using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.InlineImages;

public class EndInlineImage : IGraphicsStateOperation
{
	public const string Symbol = "EI";

	public Memory<byte> ImageData { get; }

	public string Operator => "EI";

	public EndInlineImage(Memory<byte> imageData)
	{
		ImageData = imageData;
	}

	public EndInlineImage(byte[] imageData)
	{
		ImageData = imageData;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.EndInlineImage(ImageData);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("EI");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "EI";
	}
}
