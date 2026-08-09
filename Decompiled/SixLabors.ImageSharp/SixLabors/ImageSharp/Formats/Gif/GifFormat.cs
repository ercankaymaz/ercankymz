using System.Collections.Generic;

namespace SixLabors.ImageSharp.Formats.Gif;

public sealed class GifFormat : IImageFormat<GifMetadata, GifFrameMetadata>, IImageFormat<GifMetadata>, IImageFormat
{
	public static GifFormat Instance { get; } = new GifFormat();

	public string Name => "GIF";

	public string DefaultMimeType => "image/gif";

	public IEnumerable<string> MimeTypes => GifConstants.MimeTypes;

	public IEnumerable<string> FileExtensions => GifConstants.FileExtensions;

	private GifFormat()
	{
	}

	public GifMetadata CreateDefaultFormatMetadata()
	{
		return new GifMetadata();
	}

	public GifFrameMetadata CreateDefaultFormatFrameMetadata()
	{
		return new GifFrameMetadata();
	}
}
