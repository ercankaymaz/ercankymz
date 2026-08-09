using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.InlineImages;

public class BeginInlineImage : IGraphicsStateOperation
{
	public const string Symbol = "BI";

	public static readonly BeginInlineImage Value = new BeginInlineImage();

	public string Operator => "BI";

	private BeginInlineImage()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.BeginInlineImage();
	}

	public void Write(Stream stream)
	{
		stream.WriteText("BI");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "BI";
	}
}
