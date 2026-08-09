using System;
using System.Collections.Generic;

namespace SixLabors.ImageSharp.Formats.Gif;

public class GifMetadata : IDeepCloneable
{
	public ushort RepeatCount { get; set; } = 1;

	public GifColorTableMode ColorTableMode { get; set; }

	public ReadOnlyMemory<Color>? GlobalColorTable { get; set; }

	public byte BackgroundColorIndex { get; set; }

	public IList<string> Comments { get; set; } = new List<string>();

	public GifMetadata()
	{
	}

	private GifMetadata(GifMetadata other)
	{
		RepeatCount = other.RepeatCount;
		ColorTableMode = other.ColorTableMode;
		BackgroundColorIndex = other.BackgroundColorIndex;
		ReadOnlyMemory<Color>? globalColorTable = other.GlobalColorTable;
		if (globalColorTable.HasValue && globalColorTable.GetValueOrDefault().Length > 0)
		{
			GlobalColorTable = other.GlobalColorTable.Value.ToArray();
		}
		for (int i = 0; i < other.Comments.Count; i++)
		{
			Comments.Add(other.Comments[i]);
		}
	}

	public IDeepCloneable DeepClone()
	{
		return new GifMetadata(this);
	}

	internal static GifMetadata FromAnimatedMetadata(AnimatedImageMetadata metadata)
	{
		int value = 0;
		Color backgroundColor = metadata.BackgroundColor;
		if (metadata.ColorTable.HasValue)
		{
			ReadOnlySpan<Color> span = metadata.ColorTable.Value.Span;
			for (int i = 0; i < span.Length; i++)
			{
				if (backgroundColor == span[i])
				{
					value = i;
					break;
				}
			}
		}
		return new GifMetadata
		{
			GlobalColorTable = metadata.ColorTable,
			ColorTableMode = ((metadata.ColorTableMode != FrameColorTableMode.Global) ? GifColorTableMode.Local : GifColorTableMode.Global),
			RepeatCount = metadata.RepeatCount,
			BackgroundColorIndex = (byte)Numerics.Clamp(value, 0, 255)
		};
	}
}
