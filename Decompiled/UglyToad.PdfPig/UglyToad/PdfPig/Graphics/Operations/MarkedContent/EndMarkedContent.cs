using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.MarkedContent;

public class EndMarkedContent : IGraphicsStateOperation
{
	public const string Symbol = "EMC";

	public static readonly EndMarkedContent Value = new EndMarkedContent();

	public string Operator => "EMC";

	private EndMarkedContent()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.EndMarkedContent();
	}

	public void Write(Stream stream)
	{
		stream.WriteText("EMC");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "EMC";
	}
}
