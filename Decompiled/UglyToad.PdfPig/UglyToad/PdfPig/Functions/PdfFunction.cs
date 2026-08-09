using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Functions;

public abstract class PdfFunction
{
	private int numberOfInputValues = -1;

	private int numberOfOutputValues = -1;

	public DictionaryToken? FunctionDictionary { get; }

	public StreamToken? FunctionStream { get; }

	public abstract FunctionTypes FunctionType { get; }

	public int NumberOfOutputParameters
	{
		get
		{
			if (numberOfOutputValues == -1)
			{
				if (RangeValues == null)
				{
					numberOfOutputValues = 0;
				}
				else
				{
					numberOfOutputValues = RangeValues.Length / 2;
				}
			}
			return numberOfOutputValues;
		}
	}

	public int NumberOfInputParameters
	{
		get
		{
			if (numberOfInputValues == -1)
			{
				ArrayToken domainValues = DomainValues;
				numberOfInputValues = domainValues.Length / 2;
			}
			return numberOfInputValues;
		}
	}

	protected ArrayToken? RangeValues { get; }

	private ArrayToken DomainValues { get; }

	public PdfFunction(DictionaryToken function, ArrayToken domain, ArrayToken? range)
	{
		FunctionDictionary = function;
		DomainValues = domain;
		RangeValues = range;
	}

	public PdfFunction(StreamToken function, ArrayToken domain, ArrayToken? range)
	{
		FunctionStream = function;
		DomainValues = domain;
		RangeValues = range;
	}

	public DictionaryToken? GetDictionary()
	{
		if (FunctionStream != null)
		{
			return FunctionStream.StreamDictionary;
		}
		return FunctionDictionary;
	}

	public PdfRange GetRangeForOutput(int n)
	{
		return new PdfRange(from t in RangeValues.Data.OfType<NumericToken>()
			select t.Double, n);
	}

	public PdfRange GetDomainForInput(int n)
	{
		return new PdfRange(from t in DomainValues.Data.OfType<NumericToken>()
			select t.Double, n);
	}

	public abstract double[] Eval(params double[] input);

	protected double[] ClipToRange(double[] inputValues)
	{
		ArrayToken rangeValues = RangeValues;
		double[] array2;
		if (rangeValues != null && rangeValues.Length > 0)
		{
			double[] array = (from t in rangeValues.Data.OfType<NumericToken>()
				select t.Double).ToArray();
			int num = array.Length / 2;
			array2 = new double[num];
			for (int num2 = 0; num2 < num; num2++)
			{
				int num3 = num2 << 1;
				array2[num2] = ClipToRange(inputValues[num2], array[num3], array[num3 + 1]);
			}
		}
		else
		{
			array2 = inputValues;
		}
		return array2;
	}

	public static double ClipToRange(double x, double rangeMin, double rangeMax)
	{
		if (x < rangeMin)
		{
			return rangeMin;
		}
		if (x > rangeMax)
		{
			return rangeMax;
		}
		return x;
	}

	protected static double Interpolate(double x, double xRangeMin, double xRangeMax, double yRangeMin, double yRangeMax)
	{
		return yRangeMin + (x - xRangeMin) * (yRangeMax - yRangeMin) / (xRangeMax - xRangeMin);
	}
}
