using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.PathConstruction;

public class CloseSubpath : IGraphicsStateOperation
{
	public const string Symbol = "h";

	public static readonly CloseSubpath Value = new CloseSubpath();

	public string Operator => "h";

	private CloseSubpath()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		PdfPoint? pdfPoint = operationContext.CloseSubpath();
		if (pdfPoint.HasValue)
		{
			operationContext.CurrentPosition = pdfPoint.Value;
		}
	}

	public void Write(Stream stream)
	{
		stream.WriteText("h");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "h";
	}
}
