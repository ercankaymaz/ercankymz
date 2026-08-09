using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.ClippingPaths;

public class ModifyClippingByNonZeroWindingIntersect : IGraphicsStateOperation
{
	public const string Symbol = "W";

	public static readonly ModifyClippingByNonZeroWindingIntersect Value = new ModifyClippingByNonZeroWindingIntersect();

	public string Operator => "W";

	private ModifyClippingByNonZeroWindingIntersect()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.ModifyClippingIntersect(FillingRule.NonZeroWinding);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("W");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "W";
	}
}
