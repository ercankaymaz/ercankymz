using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.TextState;

public class SetHorizontalScaling : IGraphicsStateOperation
{
	public const string Symbol = "Tz";

	public string Operator => "Tz";

	public double Scale { get; }

	public SetHorizontalScaling(double scale)
	{
		Scale = scale;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetHorizontalScaling(Scale);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText(Scale, "Tz");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Scale, "Tz");
	}
}
