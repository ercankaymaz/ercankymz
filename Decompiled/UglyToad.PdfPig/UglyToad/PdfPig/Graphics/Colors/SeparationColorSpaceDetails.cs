using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class SeparationColorSpaceDetails : ColorSpaceDetails
{
	private readonly ConcurrentDictionary<double, IColor> cache = new ConcurrentDictionary<double, IColor>();

	public override int NumberOfColorComponents => 1;

	public override int BaseNumberOfColorComponents => AlternateColorSpace.NumberOfColorComponents;

	public NameToken Name { get; }

	public ColorSpaceDetails AlternateColorSpace { get; }

	public PdfFunction TintFunction { get; }

	public SeparationColorSpaceDetails(NameToken name, ColorSpaceDetails alternateColorSpaceDetails, PdfFunction tintFunction)
		: base(ColorSpace.Separation)
	{
		Name = name;
		AlternateColorSpace = alternateColorSpaceDetails;
		TintFunction = tintFunction;
	}

	internal override double[] Process(params double[] values)
	{
		double[] values2 = TintFunction.Eval(values[0]);
		return AlternateColorSpace.Process(values2);
	}

	public override IColor GetColor(params double[] values)
	{
		if (values == null || values.Length != NumberOfColorComponents)
		{
			throw new ArgumentException($"Invalid number of inputs, expecting {NumberOfColorComponents} but got {((values != null) ? values.Length : 0)}", "values");
		}
		return cache.GetOrAdd(values[0], delegate(double v)
		{
			double[] values2 = TintFunction.Eval(v);
			return AlternateColorSpace.GetColor(values2);
		});
	}

	internal override Span<byte> Transform(Span<byte> values)
	{
		Dictionary<int, double[]> dictionary = new Dictionary<int, double[]>(values.Length);
		List<byte> list = new List<byte>(values.Length);
		for (int i = 0; i < values.Length; i++)
		{
			byte b = values[i];
			if (!dictionary.TryGetValue(b, out var value))
			{
				value = (dictionary[b] = Process((double)(int)b / 255.0));
			}
			for (int j = 0; j < value.Length; j++)
			{
				list.Add(ColorSpaceDetails.ConvertToByte(value[j]));
			}
		}
		return list.ToArray();
	}

	public override IColor GetInitializeColor()
	{
		return GetColor(1.0);
	}
}
