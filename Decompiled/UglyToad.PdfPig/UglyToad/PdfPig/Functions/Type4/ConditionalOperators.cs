using System;

namespace UglyToad.PdfPig.Functions.Type4;

internal sealed class ConditionalOperators
{
	internal sealed class If : Operator
	{
		public void Execute(ExecutionContext context)
		{
			InstructionSequence instructionSequence = (InstructionSequence)context.Stack.Pop();
			if ((bool)context.Stack.Pop())
			{
				instructionSequence.Execute(context);
			}
		}
	}

	internal sealed class IfElse : Operator
	{
		public void Execute(ExecutionContext context)
		{
			InstructionSequence instructionSequence = (InstructionSequence)context.Stack.Pop();
			InstructionSequence instructionSequence2 = (InstructionSequence)context.Stack.Pop();
			if (Convert.ToBoolean(context.Stack.Pop()))
			{
				instructionSequence2.Execute(context);
			}
			else
			{
				instructionSequence.Execute(context);
			}
		}
	}

	private ConditionalOperators()
	{
	}
}
