using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.PathPainting;

public class FillPathEvenOddRuleAndStroke : IGraphicsStateOperation
{
	public const string Symbol = "B*";

	public static readonly FillPathEvenOddRuleAndStroke Value = new FillPathEvenOddRuleAndStroke();

	public string Operator => "B*";

	private FillPathEvenOddRuleAndStroke()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.FillStrokePath(FillingRule.EvenOdd, close: false);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("B*");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "B*";
	}
}
