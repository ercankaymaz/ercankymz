using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class DeviceNColorSpaceDetails : ColorSpaceDetails
{
	public readonly struct DeviceNColorSpaceAttributes
	{
		public NameToken Subtype { get; }

		public DictionaryToken? Colorants { get; }

		public DictionaryToken? Process { get; }

		public DictionaryToken? MixingHints { get; }

		public DeviceNColorSpaceAttributes()
		{
			Subtype = NameToken.Devicen;
			Colorants = null;
			Process = null;
			MixingHints = null;
		}

		public DeviceNColorSpaceAttributes(NameToken subtype, DictionaryToken? colorants, DictionaryToken? process, DictionaryToken? mixingHints)
		{
			Subtype = subtype;
			Colorants = colorants;
			Process = process;
			MixingHints = mixingHints;
		}
	}

	public override int NumberOfColorComponents { get; }

	public override int BaseNumberOfColorComponents => AlternateColorSpace.NumberOfColorComponents;

	public IReadOnlyList<NameToken> Names { get; }

	public ColorSpaceDetails AlternateColorSpace { get; }

	public DeviceNColorSpaceAttributes? Attributes { get; }

	public PdfFunction TintFunction { get; }

	public DeviceNColorSpaceDetails(IReadOnlyList<NameToken> names, ColorSpaceDetails alternateColorSpaceDetails, PdfFunction tintFunction, DeviceNColorSpaceAttributes? attributes = null)
		: base(ColorSpace.DeviceN)
	{
		Names = names;
		NumberOfColorComponents = Names.Count;
		AlternateColorSpace = alternateColorSpaceDetails;
		Attributes = attributes;
		TintFunction = tintFunction;
		base.BaseType = AlternateColorSpace.Type;
	}

	internal override double[] Process(params double[] values)
	{
		double[] values2 = TintFunction.Eval(values);
		return AlternateColorSpace.Process(values2);
	}

	public override IColor GetColor(params double[] values)
	{
		if (values == null || values.Length != NumberOfColorComponents)
		{
			throw new ArgumentException($"Invalid number of inputs, expecting {NumberOfColorComponents} but got {((values != null) ? values.Length : 0)}", "values");
		}
		double[] values2 = TintFunction.Eval(values);
		return AlternateColorSpace.GetColor(values2);
	}

	internal override Span<byte> Transform(Span<byte> decoded)
	{
		Dictionary<int, double[]> dictionary = new Dictionary<int, double[]>();
		List<byte> list = new List<byte>();
		for (int i = 0; i < decoded.Length; i += NumberOfColorComponents)
		{
			int num = 0;
			double[] array = new double[NumberOfColorComponents];
			for (int j = 0; j < NumberOfColorComponents; j++)
			{
				byte b = decoded[i + j];
				num = (num * 31) ^ b;
				array[j] = (double)(int)b / 255.0;
			}
			if (!dictionary.TryGetValue(num, out var value))
			{
				value = (dictionary[num] = Process(array));
			}
			for (int k = 0; k < value.Length; k++)
			{
				list.Add(ColorSpaceDetails.ConvertToByte(value[k]));
			}
		}
		return list.ToArray();
	}

	public override IColor GetInitializeColor()
	{
		return GetColor(Enumerable.Repeat(1.0, NumberOfColorComponents).ToArray());
	}
}
