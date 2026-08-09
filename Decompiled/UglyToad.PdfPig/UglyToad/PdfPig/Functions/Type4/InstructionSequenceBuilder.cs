using System.Collections.Generic;
using System.Globalization;

namespace UglyToad.PdfPig.Functions.Type4;

internal sealed class InstructionSequenceBuilder : Parser.AbstractSyntaxHandler
{
	private readonly InstructionSequence mainSequence = new InstructionSequence();

	private readonly Stack<InstructionSequence> seqStack = new Stack<InstructionSequence>();

	private InstructionSequenceBuilder()
	{
		seqStack.Push(mainSequence);
	}

	public InstructionSequence GetInstructionSequence()
	{
		return mainSequence;
	}

	public static InstructionSequence Parse(string text)
	{
		InstructionSequenceBuilder instructionSequenceBuilder = new InstructionSequenceBuilder();
		Parser.Parse(text, instructionSequenceBuilder);
		return instructionSequenceBuilder.GetInstructionSequence();
	}

	private InstructionSequence GetCurrentSequence()
	{
		return seqStack.Peek();
	}

	public void Token(char[] text)
	{
		string text2 = string.Concat(text);
		Token(text2);
	}

	public override void Token(string token)
	{
		int result;
		double result2;
		if ("{".Equals(token))
		{
			InstructionSequence instructionSequence = new InstructionSequence();
			GetCurrentSequence().AddProc(instructionSequence);
			seqStack.Push(instructionSequence);
		}
		else if ("}".Equals(token))
		{
			seqStack.Pop();
		}
		else if (int.TryParse(token, NumberStyles.Integer, CultureInfo.InvariantCulture, out result))
		{
			GetCurrentSequence().AddInteger(result);
		}
		else if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out result2))
		{
			GetCurrentSequence().AddReal(result2);
		}
		else
		{
			GetCurrentSequence().AddName(token);
		}
	}
}
