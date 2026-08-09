namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal interface IJpegScanDecoder
{
	int ResetInterval { set; }

	int SpectralStart { get; set; }

	int SpectralEnd { get; set; }

	int SuccessiveHigh { get; set; }

	int SuccessiveLow { get; set; }

	void ParseEntropyCodedData(int scanComponentCount);

	void InjectFrameData(JpegFrame frame, IRawJpegData jpegData);
}
