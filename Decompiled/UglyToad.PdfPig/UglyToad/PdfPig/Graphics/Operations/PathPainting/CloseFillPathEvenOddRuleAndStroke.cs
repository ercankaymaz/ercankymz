using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.PathPainting;

public class CloseFillPathEvenOddRuleAndStroke : IGraphicsStateOperation
{
	public const string Symbol = "b*";

	public static readonly CloseFillPathEvenOddRuleAndStroke Value = new CloseFillPathEvenOddRuleAndStroke();

	public string Operator => "b*";

	private CloseFillPathEvenOddRuleAndStroke()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.FillStrokePath(FillingRule.EvenOdd, close: true);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("b*");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "b*";
	}
}
