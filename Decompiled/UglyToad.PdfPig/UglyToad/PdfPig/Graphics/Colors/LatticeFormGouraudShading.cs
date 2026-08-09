using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Functions;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class LatticeFormGouraudShading : Shading
{
	public int BitsPerCoordinate { get; }

	public int BitsPerComponent { get; }

	public int VerticesPerRow { get; }

	public double[] Decode { get; }

	public override PdfFunction[]? Functions { get; }

	public LatticeFormGouraudShading(bool antiAlias, StreamToken shadingStream, ColorSpaceDetails colorSpace, PdfRectangle? bbox, double[]? background, int bitsPerCoordinate, int bitsPerComponent, int verticesPerRow, double[] decode, PdfFunction[]? functions)
		: base(ShadingType.LatticeFormGouraud, antiAlias, shadingStream.StreamDictionary, colorSpace, bbox, background)
	{
		BitsPerCoordinate = bitsPerCoordinate;
		BitsPerComponent = bitsPerComponent;
		VerticesPerRow = verticesPerRow;
		Decode = decode;
		Functions = functions;
	}
}
