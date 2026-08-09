using System;
using System.Drawing;

namespace devDept.Graphics;

public abstract class TextureMosaicBase : IDisposable
{
	public TextureBase texture;

	public RectangleF[] textureCoordsRect;

	public SizeF[] imagesSize;

	public void Dispose()
	{
		if (texture != null)
		{
			texture.Dispose();
		}
		texture = null;
	}

	public void Draw(RenderContextBase context, int[] imagesToDraw, ref PointF position, bool drawBuffered)
	{
		foreach (int num in imagesToDraw)
		{
			RectangleF rectangleF = textureCoordsRect[num];
			SizeF size = imagesSize[num];
			context.DrawQuadWithTextures(texture, new float[8]
			{
				rectangleF.X,
				rectangleF.Y,
				rectangleF.X + rectangleF.Width,
				rectangleF.Y,
				rectangleF.X + rectangleF.Width,
				rectangleF.Y + rectangleF.Height,
				rectangleF.X,
				rectangleF.Y + rectangleF.Height
			}, byte.MaxValue, new RectangleF(position, size), 0f, drawBuffered);
			position.X += size.Width;
		}
	}
}
