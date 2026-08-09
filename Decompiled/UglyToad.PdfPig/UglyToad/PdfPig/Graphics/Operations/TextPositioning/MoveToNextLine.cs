using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.TextPositioning;

public class MoveToNextLine : IGraphicsStateOperation
{
	public const string Symbol = "T*";

	public static readonly MoveToNextLine Value = new MoveToNextLine();

	public string Operator => "T*";

	private MoveToNextLine()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.MoveToNextLineWithOffset();
	}

	public void Write(Stream stream)
	{
		stream.WriteText("T*");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "T*";
	}
}
