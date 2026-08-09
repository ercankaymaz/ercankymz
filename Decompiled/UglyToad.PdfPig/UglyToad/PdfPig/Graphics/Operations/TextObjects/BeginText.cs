using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.TextObjects;

public class BeginText : IGraphicsStateOperation
{
	public const string Symbol = "BT";

	public static readonly BeginText Value = new BeginText();

	public string Operator => "BT";

	private BeginText()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.TextMatrices.TextMatrix = TransformationMatrix.Identity;
		operationContext.TextMatrices.TextLineMatrix = TransformationMatrix.Identity;
	}

	public void Write(Stream stream)
	{
		stream.WriteText("BT");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "BT";
	}
}
