using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyToad.PdfPig.Functions.Type4;

internal sealed class InstructionSequence
{
	private readonly List<object> instructions = new List<object>();

	public void AddName(string name)
	{
		instructions.Add(name);
	}

	public void AddInteger(int value)
	{
		instructions.Add(value);
	}

	public void AddReal(double value)
	{
		instructions.Add(value);
	}

	public void AddBoolean(bool value)
	{
		instructions.Add(value);
	}

	public void AddProc(InstructionSequence child)
	{
		instructions.Add(child);
	}

	public void Execute(ExecutionContext context)
	{
		foreach (object instruction in instructions)
		{
			if (instruction is string text)
			{
				Operator obj = context.GetOperators().GetOperator(text);
				if (obj == null)
				{
					throw new InvalidOperationException("Unknown operator or name: " + text);
				}
				obj.Execute(context);
			}
			else
			{
				context.Stack.Push(instruction);
			}
		}
		while (context.Stack.Any() && context.Stack.Peek() is InstructionSequence)
		{
			((InstructionSequence)context.Stack.Pop()).Execute(context);
		}
	}
}
