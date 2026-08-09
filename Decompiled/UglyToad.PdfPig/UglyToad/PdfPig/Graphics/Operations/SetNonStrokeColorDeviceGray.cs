using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations;

public class SetNonStrokeColorDeviceGray : IGraphicsStateOperation
{
	public const string Symbol = "g";

	public string Operator => "g";

	public double Gray { get; }

	public SetNonStrokeColorDeviceGray(double gray)
	{
		Gray = gray;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.GetCurrentState().ColorSpaceContext.SetNonStrokingColorGray(Gray);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText(Gray, "g");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Gray, "g");
	}
}
