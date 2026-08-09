namespace SixLabors.ImageSharp.Formats.Jpeg;

public sealed class JpegDecoderOptions : ISpecializedDecoderOptions
{
	public DecoderOptions GeneralOptions { get; init; } = new DecoderOptions();

	public JpegDecoderResizeMode ResizeMode { get; init; }
}
