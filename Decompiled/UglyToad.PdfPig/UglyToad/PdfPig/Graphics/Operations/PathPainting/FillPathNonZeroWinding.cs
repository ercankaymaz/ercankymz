using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.PathPainting;

public class FillPathNonZeroWinding : IGraphicsStateOperation
{
	public const string Symbol = "f";

	public static readonly FillPathNonZeroWinding Value = new FillPathNonZeroWinding();

	public string Operator => "f";

	private FillPathNonZeroWinding()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.FillPath(FillingRule.NonZeroWinding, close: false);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("f");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "f";
	}
}
