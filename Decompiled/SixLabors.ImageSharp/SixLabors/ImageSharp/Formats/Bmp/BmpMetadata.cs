namespace SixLabors.ImageSharp.Formats.Bmp;

public class BmpMetadata : IDeepCloneable
{
	public BmpInfoHeaderType InfoHeaderType { get; set; }

	public BmpBitsPerPixel BitsPerPixel { get; set; } = BmpBitsPerPixel.Pixel24;

	public BmpMetadata()
	{
	}

	private BmpMetadata(BmpMetadata other)
	{
		BitsPerPixel = other.BitsPerPixel;
		InfoHeaderType = other.InfoHeaderType;
	}

	public IDeepCloneable DeepClone()
	{
		return new BmpMetadata(this);
	}
}
