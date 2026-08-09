using System;
using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.SpecialGraphicsState;

public class ModifyCurrentTransformationMatrix : IGraphicsStateOperation
{
	public const string Symbol = "cm";

	public string Operator => "cm";

	public double[] Value { get; }

	public ModifyCurrentTransformationMatrix(double[] value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (value.Length != 6)
		{
			throw new ArgumentException("The cm operator must pass 6 numbers. Instead got: " + value.Length);
		}
		Value = value;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.ModifyCurrentTransformationMatrix(TransformationMatrix.FromArray(Value));
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
		stream.WriteText("cm");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2} {3} {4} {5} {6}", Value[0], Value[1], Value[2], Value[3], Value[4], Value[5], "cm");
	}
}
