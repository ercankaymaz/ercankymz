using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.SpecialGraphicsState;

public class Push : IGraphicsStateOperation
{
	public const string Symbol = "q";

	public static readonly Push Value = new Push();

	public string Operator => "q";

	private Push()
	{
	}

	public void Run(IOperationContext context)
	{
		context.PushState();
	}

	public void Write(Stream stream)
	{
		stream.WriteText("q");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return "q";
	}
}
