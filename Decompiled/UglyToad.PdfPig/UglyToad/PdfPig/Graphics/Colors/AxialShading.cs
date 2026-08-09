using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class AxialShading : Shading
{
	public double[] Coords { get; }

	public double[] Domain { get; }

	public override PdfFunction[] Functions { get; }

	public bool[] Extend { get; }

	public AxialShading(bool antiAlias, DictionaryToken shadingDictionary, ColorSpaceDetails colorSpace, PdfRectangle? bbox, double[]? background, double[] coords, double[] domain, PdfFunction[] functions, bool[] extend)
		: base(ShadingType.Axial, antiAlias, shadingDictionary, colorSpace, bbox, background)
	{
		Coords = coords;
		Domain = domain;
		Functions = functions;
		Extend = extend;
	}
}
