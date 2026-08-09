using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.PathPainting;

public class FillPathNonZeroWindingAndStroke : IGraphicsStateOperation
{
	public const string Symbol = "B";

	public static readonly FillPathNonZeroWindingAndStroke Value = new FillPathNonZeroWindingAndStroke();

	public string Operator => "B";

	private FillPathNonZeroWindingAndStroke()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.FillStrokePath(FillingRule.NonZeroWinding, close: false);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("B");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "B";
	}
}
