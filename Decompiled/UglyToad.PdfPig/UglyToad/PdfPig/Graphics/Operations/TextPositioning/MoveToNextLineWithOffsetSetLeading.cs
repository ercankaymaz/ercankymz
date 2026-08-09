using System.IO;
using UglyToad.PdfPig.Graphics.Operations.TextState;

namespace UglyToad.PdfPig.Graphics.Operations.TextPositioning;

public class MoveToNextLineWithOffsetSetLeading : IGraphicsStateOperation
{
	public const string Symbol = "TD";

	public string Operator => "TD";

	public double Tx { get; }

	public double Ty { get; }

	public MoveToNextLineWithOffsetSetLeading(double tx, double ty)
	{
		Tx = tx;
		Ty = ty;
	}

	public void Run(IOperationContext operationContext)
	{
		new SetTextLeading(0.0 - Ty).Run(operationContext);
		new MoveToNextLineWithOffset(Tx, Ty).Run(operationContext);
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(Tx);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Ty);
		stream.WriteWhiteSpace();
		stream.WriteText("TD");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2}", Tx, Ty, "TD");
	}
}
