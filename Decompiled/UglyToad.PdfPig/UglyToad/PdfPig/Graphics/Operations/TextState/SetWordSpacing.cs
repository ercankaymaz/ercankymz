using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.TextState;

public class SetWordSpacing : IGraphicsStateOperation
{
	public const string Symbol = "Tw";

	public string Operator => "Tw";

	public double Spacing { get; }

	public SetWordSpacing(double spacing)
	{
		Spacing = spacing;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetWordSpacing(Spacing);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText(Spacing, "Tw");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Spacing, "Tw");
	}
}
