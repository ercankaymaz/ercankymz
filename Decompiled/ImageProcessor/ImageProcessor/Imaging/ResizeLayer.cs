using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ImageProcessor.Imaging;

public class ResizeLayer : IEquatable<ResizeLayer>
{
	public Size Size { get; set; }

	public Size? MaxSize { get; set; }

	public List<Size> RestrictedSizes { get; set; }

	public ResizeMode ResizeMode { get; set; }

	public AnchorPosition AnchorPosition { get; set; }

	public bool Upscale { get; set; }

	[Obsolete("Use the Center property instead.")]
	public float[] CenterCoordinates
	{
		get
		{
			PointF? center = Center;
			object result;
			if (center.HasValue)
			{
				PointF valueOrDefault = center.GetValueOrDefault();
				result = new float[2] { valueOrDefault.Y, valueOrDefault.X };
			}
			else
			{
				result = null;
			}
			return (float[])result;
		}
		set
		{
			if (value != null && value.Length == 2)
			{
				Center = new PointF(value[1], value[0]);
			}
			else
			{
				Center = null;
			}
		}
	}

	public PointF? Center { get; set; }

	public Point? AnchorPoint { get; set; }

	public ResizeLayer(Size size, ResizeMode resizeMode = ResizeMode.Pad, AnchorPosition anchorPosition = AnchorPosition.Center, bool upscale = true, float[] centerCoordinates = null, Size? maxSize = null, List<Size> restrictedSizes = null, Point? anchorPoint = null)
	{
		Size = size;
		Upscale = upscale;
		ResizeMode = resizeMode;
		AnchorPosition = anchorPosition;
		if (centerCoordinates != null && centerCoordinates.Length == 2)
		{
			Center = new PointF(centerCoordinates[1], centerCoordinates[0]);
		}
		MaxSize = maxSize;
		RestrictedSizes = restrictedSizes;
		AnchorPoint = anchorPoint;
	}

	public override bool Equals(object obj)
	{
		return obj is ResizeLayer other && Equals(other);
	}

	public bool Equals(ResizeLayer other)
	{
		int result;
		if (other != null && Size == other.Size)
		{
			Size? maxSize = MaxSize;
			Size? maxSize2 = other.MaxSize;
			if (maxSize.HasValue == maxSize2.HasValue && (!maxSize.HasValue || maxSize.GetValueOrDefault() == maxSize2.GetValueOrDefault()) && ((RestrictedSizes == null || other.RestrictedSizes == null) ? (RestrictedSizes == other.RestrictedSizes) : RestrictedSizes.SequenceEqual(other.RestrictedSizes)) && ResizeMode == other.ResizeMode && AnchorPosition == other.AnchorPosition && Upscale == other.Upscale && Center == other.Center)
			{
				result = ((AnchorPoint == other.AnchorPoint) ? 1 : 0);
				goto IL_0151;
			}
		}
		result = 0;
		goto IL_0151;
		IL_0151:
		return (byte)result != 0;
	}

	public override int GetHashCode()
	{
		return (Size, MaxSize, ResizeMode, AnchorPosition, Upscale, Center, AnchorPoint).GetHashCode();
	}
}
