using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UglyToad.PdfPig.PdfFonts;

internal class CharStringStack
{
	private readonly List<double> stack = new List<double>();

	public int Length => stack.Count;

	public bool CanPop => stack.Count > 0;

	public double PopTop()
	{
		if (stack.Count == 0)
		{
			throw new InvalidOperationException("Cannot pop from the top of an empty stack, invalid charstring parsed.");
		}
		double result = stack[stack.Count - 1];
		stack.RemoveAt(stack.Count - 1);
		return result;
	}

	public double PopBottom()
	{
		if (stack.Count == 0)
		{
			throw new InvalidOperationException("Cannot pop from the bottom of an empty stack, invalid charstring parsed.");
		}
		double result = stack[0];
		stack.RemoveAt(0);
		return result;
	}

	public void Push(double value)
	{
		stack.Add(value);
	}

	public double CopyElementAt(int index)
	{
		if (index < 0)
		{
			return stack[stack.Count - 1];
		}
		return stack[index];
	}

	public void Clear()
	{
		stack.Clear();
	}

	public override string ToString()
	{
		return string.Join(" ", stack.Select((double x) => x.ToString(CultureInfo.InvariantCulture)));
	}
}
