using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.PathPainting;

public class EndPath : IGraphicsStateOperation
{
	public const string Symbol = "n";

	public static readonly EndPath Value = new EndPath();

	public string Operator => "n";

	private EndPath()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.EndPath();
	}

	public void Write(Stream stream)
	{
		stream.WriteText("n");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "n";
	}
}
