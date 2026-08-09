using System;
using System.IO;
using System.Threading;
using SixLabors.ImageSharp.IO;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Formats;

internal abstract class ImageDecoderCore
{
	public DecoderOptions Options { get; }

	public Size Dimensions { get; protected internal set; }

	protected ImageDecoderCore(DecoderOptions options)
	{
		Options = options;
	}

	public ImageInfo Identify(Configuration configuration, Stream stream, CancellationToken cancellationToken)
	{
		using BufferedReadStream stream2 = new BufferedReadStream(configuration, stream, cancellationToken);
		try
		{
			return Identify(stream2, cancellationToken);
		}
		catch (InvalidMemoryOperationException memoryException)
		{
			throw new InvalidImageContentException(Dimensions, memoryException);
		}
		catch (Exception)
		{
			throw;
		}
	}

	public Image<TPixel> Decode<TPixel>(Configuration configuration, Stream stream, CancellationToken cancellationToken) where TPixel : unmanaged, IPixel<TPixel>
	{
		BufferedReadStream bufferedReadStream = (stream as BufferedReadStream) ?? new BufferedReadStream(configuration, stream, cancellationToken);
		try
		{
			return Decode<TPixel>(bufferedReadStream, cancellationToken);
		}
		catch (InvalidMemoryOperationException memoryException)
		{
			throw new InvalidImageContentException(Dimensions, memoryException);
		}
		catch (Exception)
		{
			throw;
		}
		finally
		{
			if (bufferedReadStream != stream)
			{
				bufferedReadStream.Dispose();
			}
		}
	}

	protected abstract ImageInfo Identify(BufferedReadStream stream, CancellationToken cancellationToken);

	protected abstract Image<TPixel> Decode<TPixel>(BufferedReadStream stream, CancellationToken cancellationToken) where TPixel : unmanaged, IPixel<TPixel>;
}
