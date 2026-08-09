using System;
using System.IO;
using UglyToad.PdfPig.Graphics.Core;

namespace UglyToad.PdfPig.Graphics.Operations.General;

public class SetLineJoin : IGraphicsStateOperation
{
	public const string Symbol = "j";

	public string Operator => "j";

	public LineJoinStyle Join { get; }

	public SetLineJoin(int join)
		: this((LineJoinStyle)join)
	{
	}

	public SetLineJoin(LineJoinStyle join)
	{
		if (join < LineJoinStyle.Miter || join > LineJoinStyle.Bevel)
		{
			throw new ArgumentException("Invalid argument passed for line join style. Should be 0, 1 or 2; instead got: " + join);
		}
		Join = join;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetLineJoin(Join);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText((int)Join, "j");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", (int)Join, "j");
	}
}
