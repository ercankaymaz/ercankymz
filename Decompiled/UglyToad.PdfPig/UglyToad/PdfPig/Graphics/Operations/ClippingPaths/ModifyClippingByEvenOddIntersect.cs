using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.ClippingPaths;

public class ModifyClippingByEvenOddIntersect : IGraphicsStateOperation
{
	public const string Symbol = "W*";

	public static readonly ModifyClippingByEvenOddIntersect Value = new ModifyClippingByEvenOddIntersect();

	public string Operator => "W*";

	private ModifyClippingByEvenOddIntersect()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.ModifyClippingIntersect(FillingRule.EvenOdd);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("W*");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "W*";
	}
}
