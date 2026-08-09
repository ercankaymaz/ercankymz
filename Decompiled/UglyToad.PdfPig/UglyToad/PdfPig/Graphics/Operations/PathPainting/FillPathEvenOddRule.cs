using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.PathPainting;

public class FillPathEvenOddRule : IGraphicsStateOperation
{
	public const string Symbol = "f*";

	public static readonly FillPathEvenOddRule Value = new FillPathEvenOddRule();

	public string Operator => "f*";

	private FillPathEvenOddRule()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.FillPath(FillingRule.EvenOdd, close: false);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("f*");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "f*";
	}
}
