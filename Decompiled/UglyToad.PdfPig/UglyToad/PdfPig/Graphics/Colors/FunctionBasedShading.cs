using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class FunctionBasedShading : Shading
{
	public double[] Domain { get; }

	public TransformationMatrix Matrix { get; }

	public override PdfFunction[] Functions { get; }

	public FunctionBasedShading(bool antiAlias, DictionaryToken shadingDictionary, ColorSpaceDetails colorSpace, PdfRectangle? bbox, double[]? background, double[] domain, TransformationMatrix matrix, PdfFunction[] functions)
		: base(ShadingType.FunctionBased, antiAlias, shadingDictionary, colorSpace, bbox, background)
	{
		Domain = domain;
		Matrix = matrix;
		Functions = functions;
	}
}
