using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.PathPainting;

public class CloseAndStrokePath : IGraphicsStateOperation
{
	public const string Symbol = "s";

	public static readonly CloseAndStrokePath Value = new CloseAndStrokePath();

	public string Operator => "s";

	private CloseAndStrokePath()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.StrokePath(close: true);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("s");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "s";
	}
}
