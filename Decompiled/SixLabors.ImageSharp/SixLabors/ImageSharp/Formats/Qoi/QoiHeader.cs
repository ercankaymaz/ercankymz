using System.Text;

namespace SixLabors.ImageSharp.Formats.Qoi;

internal readonly struct QoiHeader(uint width, uint height, QoiChannels channels, QoiColorSpace colorSpace)
{
	public byte[] Magic { get; } = Encoding.UTF8.GetBytes("qoif");

	public uint Width { get; } = width;

	public uint Height { get; } = height;

	public QoiChannels Channels { get; } = channels;

	public QoiColorSpace ColorSpace { get; } = colorSpace;
}
