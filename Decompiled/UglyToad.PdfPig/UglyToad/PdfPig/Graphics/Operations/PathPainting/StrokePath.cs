using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.PathPainting;

public class StrokePath : IGraphicsStateOperation
{
	public const string Symbol = "S";

	public static readonly StrokePath Value = new StrokePath();

	public string Operator => "S";

	private StrokePath()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.StrokePath(close: false);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("S");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "S";
	}
}
