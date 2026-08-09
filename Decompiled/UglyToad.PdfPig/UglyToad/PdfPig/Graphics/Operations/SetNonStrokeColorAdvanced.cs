using System.Collections.Generic;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer;

namespace UglyToad.PdfPig.Graphics.Operations;

public class SetNonStrokeColorAdvanced : IGraphicsStateOperation
{
	private static readonly TokenWriter TokenWriter = new TokenWriter();

	public const string Symbol = "scn";

	public string Operator => "scn";

	public IReadOnlyList<double> Operands { get; }

	public NameToken? PatternName { get; }

	public SetNonStrokeColorAdvanced(IReadOnlyList<double> operands)
	{
		Operands = operands;
	}

	public SetNonStrokeColorAdvanced(IReadOnlyList<double> operands, NameToken patternName)
	{
		Operands = operands;
		PatternName = patternName;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.GetCurrentState().ColorSpaceContext.SetNonStrokingColor(Operands, PatternName);
	}

	public void Write(Stream stream)
	{
		foreach (double operand in Operands)
		{
			stream.WriteDouble(operand);
			stream.WriteWhiteSpace();
		}
		if (PatternName != null)
		{
			TokenWriter.WriteToken(PatternName, stream);
		}
		stream.WriteText("scn");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		string text = string.Join(" ", Operands.Select((double x) => x.ToString("N")));
		if (PatternName != null)
		{
			text += $" {PatternName}";
		}
		return text + " scn";
	}
}
