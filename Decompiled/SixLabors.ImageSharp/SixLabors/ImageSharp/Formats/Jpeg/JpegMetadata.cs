using System;

namespace SixLabors.ImageSharp.Formats.Jpeg;

public class JpegMetadata : IDeepCloneable
{
	internal int? LuminanceQuality { get; set; }

	internal int? ChrominanceQuality { get; set; }

	public int Quality
	{
		get
		{
			if (LuminanceQuality.HasValue)
			{
				if (ChrominanceQuality.HasValue)
				{
					return Math.Max(LuminanceQuality.Value, ChrominanceQuality.Value);
				}
				return LuminanceQuality.Value;
			}
			if (ChrominanceQuality.HasValue)
			{
				return ChrominanceQuality.Value;
			}
			return 75;
		}
	}

	public JpegEncodingColor? ColorType { get; internal set; }

	public bool? Interleaved { get; internal set; }

	public bool? Progressive { get; internal set; }

	public JpegMetadata()
	{
	}

	private JpegMetadata(JpegMetadata other)
	{
		ColorType = other.ColorType;
		LuminanceQuality = other.LuminanceQuality;
		ChrominanceQuality = other.ChrominanceQuality;
	}

	public IDeepCloneable DeepClone()
	{
		return new JpegMetadata(this);
	}
}
