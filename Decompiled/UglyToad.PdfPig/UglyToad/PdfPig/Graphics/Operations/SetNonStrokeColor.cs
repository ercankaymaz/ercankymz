using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UglyToad.PdfPig.Graphics.Operations;

public class SetNonStrokeColor : IGraphicsStateOperation
{
	public const string Symbol = "sc";

	public string Operator => "sc";

	public IReadOnlyList<double> Operands { get; }

	public SetNonStrokeColor(double[] operands)
	{
		Operands = operands;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.GetCurrentState().ColorSpaceContext.SetNonStrokingColor(Operands);
	}

	public void Write(Stream stream)
	{
		foreach (double operand in Operands)
		{
			stream.WriteDouble(operand);
			stream.WriteWhiteSpace();
		}
		stream.WriteText("sc");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Join(" ", Operands.Select((double x) => x.ToString("N"))) + " sc";
	}
}
