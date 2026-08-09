using System.Collections.Generic;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Metadata.Profiles.Cicp;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using SixLabors.ImageSharp.Metadata.Profiles.Icc;
using SixLabors.ImageSharp.Metadata.Profiles.Iptc;
using SixLabors.ImageSharp.Metadata.Profiles.Xmp;

namespace SixLabors.ImageSharp.Metadata;

public sealed class ImageFrameMetadata : IDeepCloneable<ImageFrameMetadata>
{
	private readonly Dictionary<IImageFormat, IDeepCloneable> formatMetadata = new Dictionary<IImageFormat, IDeepCloneable>();

	public ExifProfile? ExifProfile { get; set; }

	public XmpProfile? XmpProfile { get; set; }

	public IccProfile? IccProfile { get; set; }

	public IptcProfile? IptcProfile { get; set; }

	public CicpProfile? CicpProfile { get; set; }

	internal ImageFrameMetadata()
	{
	}

	internal ImageFrameMetadata(ImageFrameMetadata other)
	{
		foreach (KeyValuePair<IImageFormat, IDeepCloneable> formatMetadatum in other.formatMetadata)
		{
			formatMetadata.Add(formatMetadatum.Key, formatMetadatum.Value.DeepClone());
		}
		ExifProfile = other.ExifProfile?.DeepClone();
		IccProfile = other.IccProfile?.DeepClone();
		IptcProfile = other.IptcProfile?.DeepClone();
		XmpProfile = other.XmpProfile?.DeepClone();
		CicpProfile = other.CicpProfile?.DeepClone();
	}

	public ImageFrameMetadata DeepClone()
	{
		return new ImageFrameMetadata(this);
	}

	public TFormatFrameMetadata GetFormatMetadata<TFormatMetadata, TFormatFrameMetadata>(IImageFormat<TFormatMetadata, TFormatFrameMetadata> key) where TFormatMetadata : class where TFormatFrameMetadata : class, IDeepCloneable
	{
		if (formatMetadata.TryGetValue(key, out IDeepCloneable value))
		{
			return (TFormatFrameMetadata)value;
		}
		TFormatFrameMetadata val = key.CreateDefaultFormatFrameMetadata();
		formatMetadata[key] = val;
		return val;
	}

	public bool TryGetFormatMetadata<TFormatMetadata, TFormatFrameMetadata>(IImageFormat<TFormatMetadata, TFormatFrameMetadata> key, out TFormatFrameMetadata? metadata) where TFormatMetadata : class where TFormatFrameMetadata : class, IDeepCloneable
	{
		if (formatMetadata.TryGetValue(key, out IDeepCloneable value))
		{
			metadata = (TFormatFrameMetadata)value;
			return true;
		}
		metadata = null;
		return false;
	}
}
