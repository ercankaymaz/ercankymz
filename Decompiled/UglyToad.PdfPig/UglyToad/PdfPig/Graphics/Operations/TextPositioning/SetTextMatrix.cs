using System;
using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.TextPositioning;

public class SetTextMatrix : IGraphicsStateOperation
{
	public const string Symbol = "Tm";

	public string Operator => "Tm";

	public double[] Value { get; }

	public SetTextMatrix(double[] value)
	{
		if (value.Length != 6)
		{
			throw new ArgumentException("Text matrix must provide 6 values. Instead got: " + value.Length);
		}
		Value = value;
	}

	public void Run(IOperationContext operationContext)
	{
		TransformationMatrix transformationMatrix = TransformationMatrix.FromArray(Value);
		operationContext.TextMatrices.TextMatrix = transformationMatrix;
		operationContext.TextMatrices.TextLineMatrix = transformationMatrix;
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(Value[0]);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Value[1]);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Value[2]);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Value[3]);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Value[4]);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Value[5]);
		stream.WriteWhiteSpace();
		stream.WriteText("Tm");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2} {3} {4} {5} {6}", Value[0], Value[1], Value[2], Value[3], Value[4], Value[5], "Tm");
	}
}
