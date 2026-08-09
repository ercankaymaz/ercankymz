using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class TensorProductPatchMeshesShading : Shading
{
	public int BitsPerCoordinate { get; }

	public int BitsPerComponent { get; }

	public int BitsPerFlag { get; }

	public double[] Decode { get; }

	public override PdfFunction[]? Functions { get; }

	public TensorProductPatchMeshesShading(bool antiAlias, StreamToken shadingStream, ColorSpaceDetails colorSpace, PdfRectangle? bbox, double[]? background, int bitsPerCoordinate, int bitsPerComponent, int bitsPerFlag, double[] decode, PdfFunction[]? functions)
		: base(ShadingType.TensorProductPatch, antiAlias, shadingStream.StreamDictionary, colorSpace, bbox, background)
	{
		BitsPerCoordinate = bitsPerCoordinate;
		BitsPerComponent = bitsPerComponent;
		BitsPerFlag = bitsPerFlag;
		Decode = decode;
		Functions = functions;
	}
}
