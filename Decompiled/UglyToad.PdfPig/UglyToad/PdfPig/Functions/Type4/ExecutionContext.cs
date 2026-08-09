using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyToad.PdfPig.Functions.Type4;

internal sealed class ExecutionContext
{
	private readonly Operators operators;

	public Stack<object> Stack { get; private set; } = new Stack<object>();

	public ExecutionContext(Operators operatorSet)
	{
		operators = operatorSet;
	}

	internal void AddAllToStack(IEnumerable<object> values)
	{
		List<object> list = values.ToList();
		list.AddRange(Stack);
		list.Reverse();
		Stack = new Stack<object>(list);
	}

	public Operators GetOperators()
	{
		return operators;
	}

	public object PopNumber()
	{
		object obj = Stack.Pop();
		if (obj is int || obj is double || obj is float)
		{
			return obj;
		}
		throw new InvalidCastException("The object popped is neither an integer or a real.");
	}

	public int PopInt()
	{
		object obj = Stack.Pop();
		if (obj is int)
		{
			return (int)obj;
		}
		throw new InvalidCastException("PopInt cannot be done as the value is not integer");
	}

	public double PopReal()
	{
		return Convert.ToDouble(Stack.Pop());
	}
}
