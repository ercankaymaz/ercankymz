using System;
using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Functions.Type4;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Functions;

internal sealed class PdfFunctionType4 : PdfFunction
{
	private readonly Operators operators = new Operators();

	private readonly InstructionSequence instructions;

	public override FunctionTypes FunctionType => FunctionTypes.PostScript;

	internal PdfFunctionType4(StreamToken function, ArrayToken domain, ArrayToken range)
		: base(function, domain, range)
	{
		string text = OtherEncodings.Iso88591.GetString(base.FunctionStream.Data.Span);
		instructions = InstructionSequenceBuilder.Parse(text);
	}

	public override double[] Eval(params double[] input)
	{
		ExecutionContext executionContext = new ExecutionContext(operators);
		for (int i = 0; i < input.Length; i++)
		{
			PdfRange domainForInput = GetDomainForInput(i);
			double num = PdfFunction.ClipToRange(input[i], domainForInput.Min, domainForInput.Max);
			executionContext.Stack.Push(num);
		}
		instructions.Execute(executionContext);
		int numberOfOutputParameters = base.NumberOfOutputParameters;
		int count = executionContext.Stack.Count;
		if (count < numberOfOutputParameters)
		{
			throw new ArgumentOutOfRangeException("The type 4 function returned " + count + " values but the Range entry indicates that " + numberOfOutputParameters + " values be returned.");
		}
		double[] array = new double[numberOfOutputParameters];
		for (int num2 = numberOfOutputParameters - 1; num2 >= 0; num2--)
		{
			PdfRange rangeForOutput = GetRangeForOutput(num2);
			array[num2] = executionContext.PopReal();
			array[num2] = PdfFunction.ClipToRange(array[num2], rangeForOutput.Min, rangeForOutput.Max);
		}
		return array;
	}
}
