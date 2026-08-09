using System;
using System.Collections;
using System.IO;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Functions;

internal sealed class PdfFunctionType0 : PdfFunction
{
	internal class RInterpol
	{
		private readonly double[] in_;

		private readonly int[] inPrev;

		private readonly int[] inNext;

		private readonly int numberOfInputValues;

		private readonly int numberOfOutputValues;

		private readonly ArrayToken size;

		private readonly int[][] samples;

		internal RInterpol(double[] input, int[] inputPrev, int[] inputNext, int numberOfOutputValues, ArrayToken size, int[][] samples)
		{
			in_ = input;
			inPrev = inputPrev;
			inNext = inputNext;
			numberOfInputValues = input.Length;
			this.numberOfOutputValues = numberOfOutputValues;
			this.size = size;
			this.samples = samples;
		}

		internal double[] RInterpolate()
		{
			return InternalRInterpol(new int[numberOfInputValues], 0);
		}

		private double[] InternalRInterpol(int[] coord, int step)
		{
			double[] array = new double[numberOfOutputValues];
			if (step == in_.Length - 1)
			{
				if (inPrev[step] == inNext[step])
				{
					coord[step] = inPrev[step];
					int[] array2 = samples[CalcSampleIndex(coord)];
					for (int i = 0; i < numberOfOutputValues; i++)
					{
						array[i] = array2[i];
					}
					return array;
				}
				coord[step] = inPrev[step];
				int[] array3 = samples[CalcSampleIndex(coord)];
				coord[step] = inNext[step];
				int[] array4 = samples[CalcSampleIndex(coord)];
				for (int j = 0; j < numberOfOutputValues; j++)
				{
					array[j] = PdfFunction.Interpolate(in_[step], inPrev[step], inNext[step], array3[j], array4[j]);
				}
				return array;
			}
			if (inPrev[step] == inNext[step])
			{
				coord[step] = inPrev[step];
				return InternalRInterpol(coord, step + 1);
			}
			coord[step] = inPrev[step];
			double[] array5 = InternalRInterpol(coord, step + 1);
			coord[step] = inNext[step];
			double[] array6 = InternalRInterpol(coord, step + 1);
			for (int k = 0; k < numberOfOutputValues; k++)
			{
				array[k] = PdfFunction.Interpolate(in_[step], inPrev[step], inNext[step], array5[k], array6[k]);
			}
			return array;
		}

		private int CalcSampleIndex(int[] vector)
		{
			double[] array = (from t in size.Data.OfType<NumericToken>()
				select t.Double).ToArray();
			int num = 0;
			int num2 = 1;
			int num3 = vector.Length;
			for (int num4 = num3 - 2; num4 >= 0; num4--)
			{
				num2 = (int)((double)num2 * array[num4]);
			}
			for (int num5 = num3 - 1; num5 >= 0; num5--)
			{
				num += num2 * vector[num5];
				if (num5 - 1 >= 0)
				{
					num2 = (int)((double)num2 / array[num5 - 1]);
				}
			}
			return num;
		}
	}

	private int[][]? samples;

	public override FunctionTypes FunctionType => FunctionTypes.Sampled;

	public ArrayToken Size { get; }

	public int BitsPerSample { get; }

	public int Order { get; }

	private ArrayToken EncodeValues { get; }

	private ArrayToken DecodeValues { get; }

	internal PdfFunctionType0(DictionaryToken function, ArrayToken domain, ArrayToken range, ArrayToken size, int bitsPerSample, int order, ArrayToken encode, ArrayToken decode)
		: base(function, domain, range)
	{
		Size = size;
		BitsPerSample = bitsPerSample;
		Order = order;
		EncodeValues = encode;
		DecodeValues = decode;
	}

	internal PdfFunctionType0(StreamToken function, ArrayToken domain, ArrayToken range, ArrayToken size, int bitsPerSample, int order, ArrayToken encode, ArrayToken decode)
		: base(function, domain, range)
	{
		Size = size;
		BitsPerSample = bitsPerSample;
		Order = order;
		EncodeValues = encode;
		DecodeValues = decode;
	}

	public PdfRange? GetEncodeForParameter(int paramNum)
	{
		ArrayToken encodeValues = EncodeValues;
		if (encodeValues != null && encodeValues.Length >= paramNum * 2 + 1)
		{
			return new PdfRange(from t in encodeValues.Data.OfType<NumericToken>()
				select t.Double, paramNum);
		}
		return null;
	}

	public PdfRange? GetDecodeForParameter(int paramNum)
	{
		ArrayToken decodeValues = DecodeValues;
		if (decodeValues != null && decodeValues.Length >= paramNum * 2 + 1)
		{
			return new PdfRange(from t in decodeValues.Data.OfType<NumericToken>()
				select t.Double, paramNum);
		}
		return null;
	}

	private int[][] GetSamples()
	{
		if (samples == null)
		{
			int num = 1;
			int numberOfInputParameters = base.NumberOfInputParameters;
			int numberOfOutputParameters = base.NumberOfOutputParameters;
			ArrayToken size = Size;
			for (int i = 0; i < numberOfInputParameters; i++)
			{
				num *= ((NumericToken)size[i]).Int;
			}
			samples = new int[num][];
			int bitsPerSample = BitsPerSample;
			BitArray bitArray = new BitArray(base.FunctionStream.Data.ToArray());
			for (int j = 0; j < num; j++)
			{
				samples[j] = new int[numberOfOutputParameters];
				for (int k = 0; k < numberOfOutputParameters; k++)
				{
					long num2 = 0L;
					for (int num3 = bitsPerSample - 1; num3 >= 0; num3--)
					{
						num2 <<= 1;
						num2 |= (bitArray[j * numberOfOutputParameters * bitsPerSample + k * bitsPerSample + num3] ? 1L : 0L);
					}
					samples[j][k] = (int)num2;
				}
			}
		}
		return samples;
	}

	public override double[] Eval(params double[] input)
	{
		double[] array = (from t in Size.Data.OfType<NumericToken>()
			select t.Double).ToArray();
		int bitsPerSample = BitsPerSample;
		double xRangeMax = Math.Pow(2.0, bitsPerSample) - 1.0;
		int num = input.Length;
		int numberOfOutputParameters = base.NumberOfOutputParameters;
		int[] array2 = new int[num];
		int[] array3 = new int[num];
		input = input.ToArray();
		for (int num2 = 0; num2 < num; num2++)
		{
			PdfRange domainForInput = GetDomainForInput(num2);
			PdfRange value = GetEncodeForParameter(num2).Value;
			input[num2] = PdfFunction.ClipToRange(input[num2], domainForInput.Min, domainForInput.Max);
			input[num2] = PdfFunction.Interpolate(input[num2], domainForInput.Min, domainForInput.Max, value.Min, value.Max);
			input[num2] = PdfFunction.ClipToRange(input[num2], 0.0, array[num2] - 1.0);
			array2[num2] = (int)Math.Floor(input[num2]);
			array3[num2] = (int)Math.Ceiling(input[num2]);
		}
		double[] array4 = new RInterpol(input, array2, array3, numberOfOutputParameters, Size, GetSamples()).RInterpolate();
		for (int num3 = 0; num3 < numberOfOutputParameters; num3++)
		{
			PdfRange rangeForOutput = GetRangeForOutput(num3);
			PdfRange? decodeForParameter = GetDecodeForParameter(num3);
			if (!decodeForParameter.HasValue)
			{
				throw new IOException("Range missing in function /Decode entry");
			}
			array4[num3] = PdfFunction.Interpolate(array4[num3], 0.0, xRangeMax, decodeForParameter.Value.Min, decodeForParameter.Value.Max);
			array4[num3] = PdfFunction.ClipToRange(array4[num3], rangeForOutput.Min, rangeForOutput.Max);
		}
		return array4;
	}
}
