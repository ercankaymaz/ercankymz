using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.Compatibility;

public class EndCompatibilitySection : IGraphicsStateOperation
{
	public const string Symbol = "EX";

	public static readonly EndCompatibilitySection Value = new EndCompatibilitySection();

	public string Operator => "EX";

	private EndCompatibilitySection()
	{
	}

	public void Run(IOperationContext operationContext)
	{
	}

	public void Write(Stream stream)
	{
		stream.WriteText("EX");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "EX";
	}
}
