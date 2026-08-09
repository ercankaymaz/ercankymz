namespace Basler.Pylon;

public struct CompressionInfo
{
	public bool HasCompressedImage;

	public CompressionStatus CompressionStatus;

	public bool Lossy;

	public PixelType PixelType;

	public int Width;

	public int Height;

	public int OffsetX;

	public int OffsetY;

	public int PaddingX;

	public int PaddingY;

	public int DecompressedImageSize;

	public int DecompressedPayloadSize;
}
