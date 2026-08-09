using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.SpecialGraphicsState;

public class Pop : IGraphicsStateOperation
{
	public const string Symbol = "Q";

	public static readonly Pop Value = new Pop();

	public string Operator => "Q";

	private Pop()
	{
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.PopState();
	}

	public void Write(Stream stream)
	{
		stream.WriteText("Q");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "Q";
	}
}
