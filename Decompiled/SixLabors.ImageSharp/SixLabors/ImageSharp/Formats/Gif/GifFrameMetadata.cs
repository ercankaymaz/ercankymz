using System;
using System.Numerics;

namespace SixLabors.ImageSharp.Formats.Gif;

public class GifFrameMetadata : IDeepCloneable
{
	public GifColorTableMode ColorTableMode { get; set; }

	public ReadOnlyMemory<Color>? LocalColorTable { get; set; }

	public bool HasTransparency { get; set; }

	public byte TransparencyIndex { get; set; }

	public int FrameDelay { get; set; }

	public GifDisposalMethod DisposalMethod { get; set; }

	public GifFrameMetadata()
	{
	}

	private GifFrameMetadata(GifFrameMetadata other)
	{
		ColorTableMode = other.ColorTableMode;
		FrameDelay = other.FrameDelay;
		DisposalMethod = other.DisposalMethod;
		ReadOnlyMemory<Color>? localColorTable = other.LocalColorTable;
		if (localColorTable.HasValue && localColorTable.GetValueOrDefault().Length > 0)
		{
			LocalColorTable = other.LocalColorTable.Value.ToArray();
		}
		HasTransparency = other.HasTransparency;
		TransparencyIndex = other.TransparencyIndex;
	}

	public IDeepCloneable DeepClone()
	{
		return new GifFrameMetadata(this);
	}

	internal static GifFrameMetadata FromAnimatedMetadata(AnimatedImageFrameMetadata metadata)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		int num = -1;
		float num2 = 1f;
		if (metadata.ColorTable.HasValue)
		{
			ReadOnlySpan<Color> span = metadata.ColorTable.Value.Span;
			for (int i = 0; i < span.Length; i++)
			{
				if (((Vector4)span[i]).W < num2)
				{
					num = i;
				}
			}
		}
		bool flag = num >= 0;
		return new GifFrameMetadata
		{
			LocalColorTable = metadata.ColorTable,
			ColorTableMode = ((metadata.ColorTableMode != FrameColorTableMode.Global) ? GifColorTableMode.Local : GifColorTableMode.Global),
			FrameDelay = (int)Math.Round(metadata.Duration.TotalMilliseconds / 10.0),
			DisposalMethod = GetMode(metadata.DisposalMode),
			HasTransparency = flag,
			TransparencyIndex = (byte)(flag ? ((byte)num) : 0)
		};
	}

	private static GifDisposalMethod GetMode(FrameDisposalMode mode)
	{
		return mode switch
		{
			FrameDisposalMode.DoNotDispose => GifDisposalMethod.NotDispose, 
			FrameDisposalMode.RestoreToBackground => GifDisposalMethod.RestoreToBackground, 
			FrameDisposalMode.RestoreToPrevious => GifDisposalMethod.RestoreToPrevious, 
			_ => GifDisposalMethod.Unspecified, 
		};
	}
}
