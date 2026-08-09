using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.PathPainting;

public class FillPathNonZeroWindingCompatibility : IGraphicsStateOperation
{
	public const string Symbol = "F";

	public static readonly FillPathNonZeroWindingCompatibility Value = new FillPathNonZeroWindingCompatibility();

	public string Operator => "F";

	private FillPathNonZeroWindingCompatibility()
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
		return "F";
	}
}
