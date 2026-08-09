using System;

namespace ImageProcessor.Imaging;

public class RoundedCornerLayer : IEquatable<RoundedCornerLayer>
{
	public int Radius { get; set; }

	public bool TopLeft { get; set; }

	public bool TopRight { get; set; }

	public bool BottomLeft { get; set; }

	public bool BottomRight { get; set; }

	public RoundedCornerLayer(int radius, bool topLeft = true, bool topRight = true, bool bottomLeft = true, bool bottomRight = true)
	{
		Radius = radius;
		TopLeft = topLeft;
		TopRight = topRight;
		BottomLeft = bottomLeft;
		BottomRight = bottomRight;
	}

	public override bool Equals(object obj)
	{
		return obj is RoundedCornerLayer other && Equals(other);
	}

	public bool Equals(RoundedCornerLayer other)
	{
		return other != null && Radius == other.Radius && TopLeft == other.TopLeft && TopRight == other.TopRight && BottomLeft == other.BottomLeft && BottomRight == other.BottomRight;
	}

	public override int GetHashCode()
	{
		return (Radius, TopLeft, TopRight, BottomLeft, BottomRight).GetHashCode();
	}
}
