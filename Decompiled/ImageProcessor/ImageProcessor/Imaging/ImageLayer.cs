using System;
using System.Drawing;

namespace ImageProcessor.Imaging;

public class ImageLayer : IDisposable, IEquatable<ImageLayer>
{
	private bool isDisposed = false;

	public Image Image { get; set; }

	public Size Size { get; set; }

	public int Opacity { get; set; } = 100;

	public Point? Position { get; set; }

	public override bool Equals(object obj)
	{
		return obj is ImageLayer other && Equals(other);
	}

	public bool Equals(ImageLayer other)
	{
		return other != null && Image == other.Image && Size == other.Size && Opacity == other.Opacity && Position == other.Position;
	}

	public override int GetHashCode()
	{
		return (Image, Size, Opacity, Position).GetHashCode();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!isDisposed)
		{
			if (disposing)
			{
				Image?.Dispose();
			}
			isDisposed = true;
		}
	}
}
