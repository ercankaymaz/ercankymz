using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.TextObjects;

public class EndText : IGraphicsStateOperation
{
	public const string Symbol = "ET";

	public static readonly EndText Value = new EndText();

	public string Operator => "ET";

	private EndText()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.TextMatrices.TextMatrix = TransformationMatrix.Identity;
		operationContext.TextMatrices.TextLineMatrix = TransformationMatrix.Identity;
	}

	public void Write(Stream stream)
	{
		stream.WriteText("ET");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "ET";
	}
}
