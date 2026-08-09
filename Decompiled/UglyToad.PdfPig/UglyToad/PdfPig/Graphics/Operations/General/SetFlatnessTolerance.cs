using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.General;

public class SetFlatnessTolerance : IGraphicsStateOperation
{
	public const string Symbol = "i";

	public string Operator => "i";

	public double Tolerance { get; }

	public SetFlatnessTolerance(double tolerance)
	{
		Tolerance = tolerance;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetFlatnessTolerance(Tolerance);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText(Tolerance, "i");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Tolerance, "i");
	}
}
