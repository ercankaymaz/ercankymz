using System;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Functions;

internal sealed class PdfFunctionType2 : PdfFunction
{
	public override FunctionTypes FunctionType => FunctionTypes.Exponential;

	public ArrayToken C0 { get; }

	public ArrayToken C1 { get; }

	public double N { get; }

	internal PdfFunctionType2(DictionaryToken function, ArrayToken domain, ArrayToken? range, ArrayToken c0, ArrayToken c1, double n)
		: base(function, domain, range)
	{
		C0 = c0;
		C1 = c1;
		N = n;
	}

	internal PdfFunctionType2(StreamToken function, ArrayToken domain, ArrayToken? range, ArrayToken c0, ArrayToken c1, double n)
		: base(function, domain, range)
	{
		C0 = c0;
		C1 = c1;
		N = n;
	}

	public override double[] Eval(params double[] input)
	{
		double num = Math.Pow(input[0], N);
		double[] array = new double[Math.Min(C0.Length, C1.Length)];
		for (int i = 0; i < array.Length; i++)
		{
			double num2 = ((NumericToken)C0[i]).Double;
			double num3 = ((NumericToken)C1[i]).Double;
			array[i] = num2 + num * (num3 - num2);
		}
		return ClipToRange(array);
	}

	public override string ToString()
	{
		return "FunctionType2{C0: " + C0?.ToString() + " C1: " + C1?.ToString() + " N: " + N + "}";
	}
}
