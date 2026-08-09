using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.General;

public class SetMiterLimit : IGraphicsStateOperation
{
	public const string Symbol = "M";

	public string Operator => "M";

	public double Limit { get; }

	public SetMiterLimit(double limit)
	{
		Limit = limit;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetMiterLimit(Limit);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText(Limit, "M");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Limit, "M");
	}
}
