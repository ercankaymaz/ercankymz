using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public abstract class Shading
{
	public DictionaryToken ShadingDictionary { get; }

	public ShadingType ShadingType { get; }

	public ColorSpaceDetails ColorSpace { get; }

	public double[]? Background { get; }

	public PdfRectangle? BBox { get; }

	public bool AntiAlias { get; }

	public abstract PdfFunction[]? Functions { get; }

	protected internal Shading(ShadingType shadingType, bool antiAlias, DictionaryToken shadingDictionary, ColorSpaceDetails colorSpace, PdfRectangle? bbox, double[]? background)
	{
		ShadingType = shadingType;
		AntiAlias = antiAlias;
		ShadingDictionary = shadingDictionary;
		ColorSpace = colorSpace;
		BBox = bbox;
		Background = background;
	}

	public double[] Eval(params double[] input)
	{
		if (Functions == null || Functions.Length == 0)
		{
			return input;
		}
		if (Functions.Length == 1)
		{
			return Clamp(Functions[0].Eval(input));
		}
		double[] array = new double[Functions.Length];
		for (int i = 0; i < Functions.Length; i++)
		{
			double[] array2 = Functions[i].Eval(input);
			array[i] = array2[0];
		}
		return Clamp(array);
	}

	private static double[] Clamp(double[] input)
	{
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] < 0.0)
			{
				input[i] = 0.0;
			}
			else if (input[i] > 1.0)
			{
				input[i] = 1.0;
			}
		}
		return input;
	}
}
