using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyToad.PdfPig.Graphics.Core;

public readonly struct LineDashPattern
{
	public int Phase { get; }

	public IReadOnlyList<double> Array { get; }

	public static LineDashPattern Solid { get; } = new LineDashPattern(0, new double[0]);

	public LineDashPattern(int phase, IReadOnlyList<double> array)
	{
		Phase = phase;
		Array = array ?? throw new ArgumentNullException("array");
	}

	public override string ToString()
	{
		string arg = string.Join(" ", Array.Select((double x) => x.ToString("N")));
		return $"[{arg}] {Phase}.";
	}
}
