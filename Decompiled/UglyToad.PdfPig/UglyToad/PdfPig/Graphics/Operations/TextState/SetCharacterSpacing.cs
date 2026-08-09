using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.TextState;

public class SetCharacterSpacing : IGraphicsStateOperation
{
	public const string Symbol = "Tc";

	public string Operator => "Tc";

	public double Spacing { get; }

	public SetCharacterSpacing(double spacing)
	{
		Spacing = spacing;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetCharacterSpacing(Spacing);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText(Spacing, "Tc");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Spacing, "Tc");
	}
}
