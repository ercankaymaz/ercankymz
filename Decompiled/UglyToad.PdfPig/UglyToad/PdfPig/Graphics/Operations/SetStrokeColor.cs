using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UglyToad.PdfPig.Graphics.Operations;

public class SetStrokeColor : IGraphicsStateOperation
{
	public const string Symbol = "SC";

	public string Operator => "SC";

	public IReadOnlyList<double> Operands { get; }

	public SetStrokeColor(double[] operands)
	{
		Operands = operands;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.GetCurrentState().ColorSpaceContext.SetStrokingColor(Operands);
	}

	public void Write(Stream stream)
	{
		foreach (double operand in Operands)
		{
			stream.WriteDouble(operand);
			stream.WriteWhiteSpace();
		}
		stream.WriteText("SC");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Join(" ", Operands.Select((double x) => x.ToString("N"))) + " SC";
	}
}
