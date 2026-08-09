using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.TextState;

public class SetTextLeading : IGraphicsStateOperation
{
	public const string Symbol = "TL";

	public string Operator => "TL";

	public double Leading { get; }

	public SetTextLeading(double leading)
	{
		Leading = leading;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetTextLeading(Leading);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText(Leading, "TL");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Leading, "TL");
	}
}
