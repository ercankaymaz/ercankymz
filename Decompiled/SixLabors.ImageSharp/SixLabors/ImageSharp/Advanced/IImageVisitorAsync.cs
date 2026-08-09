using System.Threading;
using System.Threading.Tasks;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Advanced;

public interface IImageVisitorAsync
{
	Task VisitAsync<TPixel>(Image<TPixel> image, CancellationToken cancellationToken) where TPixel : unmanaged, IPixel<TPixel>;
}
