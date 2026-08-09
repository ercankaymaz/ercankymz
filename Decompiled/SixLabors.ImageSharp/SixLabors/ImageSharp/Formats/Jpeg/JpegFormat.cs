using System.Collections.Generic;

namespace SixLabors.ImageSharp.Formats.Jpeg;

public sealed class JpegFormat : IImageFormat<JpegMetadata>, IImageFormat
{
	public static JpegFormat Instance { get; } = new JpegFormat();

	public string Name => "JPEG";

	public string DefaultMimeType => "image/jpeg";

	public IEnumerable<string> MimeTypes => JpegConstants.MimeTypes;

	public IEnumerable<string> FileExtensions => JpegConstants.FileExtensions;

	private JpegFormat()
	{
	}

	public JpegMetadata CreateDefaultFormatMetadata()
	{
		return new JpegMetadata();
	}
}
