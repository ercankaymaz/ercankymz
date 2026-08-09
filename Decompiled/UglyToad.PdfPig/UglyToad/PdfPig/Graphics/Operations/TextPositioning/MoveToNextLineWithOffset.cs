using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.TextPositioning;

public class MoveToNextLineWithOffset : IGraphicsStateOperation
{
	public const string Symbol = "Td";

	public string Operator => "Td";

	public double Tx { get; }

	public double Ty { get; }

	public MoveToNextLineWithOffset(double tx, double ty)
	{
		Tx = tx;
		Ty = ty;
	}

	public void Run(IOperationContext operationContext)
	{
		TransformationMatrix matrix = operationContext.TextMatrices.TextLineMatrix;
		TransformationMatrix transformationMatrix = TransformationMatrix.FromValues(1.0, 0.0, 0.0, 1.0, Tx, Ty).Multiply(in matrix);
		operationContext.TextMatrices.TextLineMatrix = transformationMatrix;
		operationContext.TextMatrices.TextMatrix = transformationMatrix;
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(Tx);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Ty);
		stream.WriteWhiteSpace();
		stream.WriteText("Td");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2}", Tx, Ty, "Td");
	}
}
