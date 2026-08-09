using System.IO;
using UglyToad.PdfPig.Graphics.Core;

namespace UglyToad.PdfPig.Graphics.Operations.General;

public class SetLineDashPattern : IGraphicsStateOperation
{
	public const string Symbol = "d";

	public string Operator => "d";

	public LineDashPattern Pattern { get; }

	public SetLineDashPattern(double[] array, int phase)
	{
		Pattern = new LineDashPattern(phase, array);
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetLineDashPattern(Pattern);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("["u8);
		for (int i = 0; i < Pattern.Array.Count; i++)
		{
			double value = Pattern.Array[i];
			stream.WriteDouble(value);
			if (i < Pattern.Array.Count - 1)
			{
				stream.WriteWhiteSpace();
			}
		}
		stream.WriteText("]"u8);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Pattern.Phase);
		stream.WriteWhiteSpace();
		stream.WriteText("d");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2}", Pattern.Array, Pattern.Phase, "d");
	}
}
