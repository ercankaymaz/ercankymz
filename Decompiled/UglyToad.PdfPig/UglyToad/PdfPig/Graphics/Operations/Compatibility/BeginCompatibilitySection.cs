using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.Compatibility;

public class BeginCompatibilitySection : IGraphicsStateOperation
{
	public const string Symbol = "BX";

	public static readonly BeginCompatibilitySection Value = new BeginCompatibilitySection();

	public string Operator => "BX";

	private BeginCompatibilitySection()
	{
	}

	public void Run(IOperationContext operationContext)
	{
	}

	public void Write(Stream stream)
	{
		stream.WriteText("BX");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "BX";
	}
}
