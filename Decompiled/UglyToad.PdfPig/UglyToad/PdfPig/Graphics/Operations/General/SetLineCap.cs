using System;
using System.IO;
using UglyToad.PdfPig.Graphics.Core;

namespace UglyToad.PdfPig.Graphics.Operations.General;

public class SetLineCap : IGraphicsStateOperation
{
	public const string Symbol = "J";

	public string Operator => "J";

	public LineCapStyle Cap { get; }

	public SetLineCap(int cap)
		: this((LineCapStyle)cap)
	{
	}

	public SetLineCap(LineCapStyle cap)
	{
		if (cap < LineCapStyle.Butt || cap > LineCapStyle.ProjectingSquare)
		{
			throw new ArgumentException("Invalid argument passed for line cap style. Should be 0, 1 or 2; instead got: " + cap);
		}
		Cap = cap;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetLineCap(Cap);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText((int)Cap, "J");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", (int)Cap, "J");
	}
}
