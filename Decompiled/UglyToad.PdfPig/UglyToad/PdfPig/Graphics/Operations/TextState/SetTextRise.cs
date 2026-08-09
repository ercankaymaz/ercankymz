using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.TextState;

public class SetTextRise : IGraphicsStateOperation
{
	public const string Symbol = "Ts";

	public string Operator => "Ts";

	public double Rise { get; }

	public SetTextRise(double rise)
	{
		Rise = rise;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetTextRise(Rise);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText(Rise, "Ts");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Rise, "Ts");
	}
}
