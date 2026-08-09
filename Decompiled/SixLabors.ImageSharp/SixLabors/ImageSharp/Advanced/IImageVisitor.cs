using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Advanced;

public interface IImageVisitor
{
	void Visit<TPixel>(Image<TPixel> image) where TPixel : unmanaged, IPixel<TPixel>;
}
