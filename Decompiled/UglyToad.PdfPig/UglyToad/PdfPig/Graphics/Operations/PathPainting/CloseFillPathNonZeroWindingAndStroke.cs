using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.PathPainting;

public class CloseFillPathNonZeroWindingAndStroke : IGraphicsStateOperation
{
	public const string Symbol = "b";

	public static readonly CloseFillPathNonZeroWindingAndStroke Value = new CloseFillPathNonZeroWindingAndStroke();

	public string Operator => "b";

	private CloseFillPathNonZeroWindingAndStroke()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.FillStrokePath(FillingRule.NonZeroWinding, close: true);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("b");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "b";
	}
}
