using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal interface IJpegComponent
{
	byte Id { get; }

	int Index { get; }

	Size SizeInBlocks { get; }

	Size SamplingFactors { get; }

	int HorizontalSamplingFactor { get; }

	int VerticalSamplingFactor { get; }

	Size SubSamplingDivisors { get; }

	int QuantizationTableIndex { get; }

	Buffer2D<Block8x8> SpectralBlocks { get; }

	int DcPredictor { get; set; }

	int DcTableId { get; set; }

	int AcTableId { get; set; }

	void Init(int maxSubFactorH, int maxSubFactorV);

	void AllocateSpectral(bool fullScan);

	void Dispose();
}
