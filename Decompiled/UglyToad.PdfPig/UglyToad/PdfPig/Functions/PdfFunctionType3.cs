using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Functions;

internal sealed class PdfFunctionType3 : PdfFunction
{
	private readonly double[] boundsValues;

	public override FunctionTypes FunctionType => FunctionTypes.Stitching;

	public IReadOnlyList<PdfFunction> FunctionsArray { get; }

	public ArrayToken Bounds { get; }

	public ArrayToken Encode { get; }

	internal PdfFunctionType3(DictionaryToken function, ArrayToken domain, ArrayToken? range, IReadOnlyList<PdfFunction> functionsArray, ArrayToken bounds, ArrayToken encode)
		: base(function, domain, range)
	{
		if (functionsArray == null || functionsArray.Count == 0)
		{
			throw new ArgumentNullException("functionsArray");
		}
		FunctionsArray = functionsArray;
		Bounds = bounds;
		Encode = encode;
		boundsValues = (from t in Bounds.Data.OfType<NumericToken>()
			select t.Double).ToArray();
	}

	internal PdfFunctionType3(StreamToken function, ArrayToken domain, ArrayToken range, IReadOnlyList<PdfFunction> functionsArray, ArrayToken bounds, ArrayToken encode)
		: base(function, domain, range)
	{
		if (functionsArray == null || functionsArray.Count == 0)
		{
			throw new ArgumentNullException("functionsArray");
		}
		FunctionsArray = functionsArray;
		Bounds = bounds;
		Encode = encode;
		boundsValues = (from t in Bounds.Data.OfType<NumericToken>()
			select t.Double).ToArray();
	}

	public override double[] Eval(params double[] input)
	{
		PdfFunction pdfFunction = null;
		double x = input[0];
		PdfRange domainForInput = GetDomainForInput(0);
		x = PdfFunction.ClipToRange(x, domainForInput.Min, domainForInput.Max);
		if (FunctionsArray.Count == 1)
		{
			pdfFunction = FunctionsArray[0];
			PdfRange encodeForParameter = GetEncodeForParameter(0);
			x = PdfFunction.Interpolate(x, domainForInput.Min, domainForInput.Max, encodeForParameter.Min, encodeForParameter.Max);
		}
		else
		{
			int num = boundsValues.Length;
			double[] array = new double[num + 2];
			int num2 = array.Length;
			array[0] = domainForInput.Min;
			array[num2 - 1] = domainForInput.Max;
			Array.Copy(boundsValues, 0, array, 1, num);
			for (int i = 0; i < num2 - 1; i++)
			{
				if (x >= array[i] && (x < array[i + 1] || (i == num2 - 2 && x == array[i + 1])))
				{
					pdfFunction = FunctionsArray[i];
					PdfRange encodeForParameter2 = GetEncodeForParameter(i);
					x = PdfFunction.Interpolate(x, array[i], array[i + 1], encodeForParameter2.Min, encodeForParameter2.Max);
					break;
				}
			}
		}
		if (pdfFunction == null)
		{
			throw new IOException("partition not found in type 3 function");
		}
		double[] input2 = new double[1] { x };
		double[] inputValues = pdfFunction.Eval(input2);
		return ClipToRange(inputValues);
	}

	private PdfRange GetEncodeForParameter(int n)
	{
		return new PdfRange(from t in Encode.Data.OfType<NumericToken>()
			select t.Double, n);
	}
}
