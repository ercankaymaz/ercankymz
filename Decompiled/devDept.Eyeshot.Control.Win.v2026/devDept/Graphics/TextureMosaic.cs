using System.Drawing;

namespace devDept.Graphics;

public class TextureMosaic : TextureMosaicBase
{
	public TextureMosaic(RenderContextBase context, int nRows, int nColumns, Bitmap[] images)
	{
		texture = context.CreateTexture2D();
		int[] array = new int[nRows];
		int[] array2 = new int[nRows];
		int num = 0;
		for (int i = 0; i < images.Length; i++)
		{
			if (i > 0 && i % nColumns == 0)
			{
				num++;
			}
			array[num] += images[i].Width;
			if (images[i].Height > array2[num])
			{
				array2[num] = images[i].Height;
			}
		}
		int num2 = array[0];
		int num3 = array2[0];
		for (int j = 1; j < nRows; j++)
		{
			if (array[j] > num2)
			{
				num2 = array[j];
			}
			num3 += array2[j];
		}
		Size size = new Size(num2, num3);
		Size size2 = size;
		Size size3 = size2;
		if (!context.TextureNonPowerOfTwo)
		{
			int dim = size.Width;
			int dim2 = size.Height;
			TextureBase.MakePowerOfTwoBigger(context, ref dim);
			TextureBase.MakePowerOfTwoBigger(context, ref dim2);
			size3 = new Size(dim, dim2);
		}
		Bitmap bitmap = new Bitmap(size3.Width, size3.Height, images[0].PixelFormat);
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		num5 = 0;
		textureCoordsRect = new RectangleF[images.Length];
		imagesSize = new SizeF[images.Length];
		using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
		{
			for (int k = 0; k < nRows; k++)
			{
				num4 = 0;
				int num7 = 0;
				while (num7 < nColumns && num6 < images.Length)
				{
					Bitmap bitmap2 = images[num6];
					graphics.DrawImage(bitmap2, new PointF(num4, num5));
					textureCoordsRect[num6] = new RectangleF((float)num4 / (float)size3.Width, (float)num5 / (float)size3.Height, (float)bitmap2.Width / (float)size3.Width, (float)bitmap2.Height / (float)size3.Height);
					imagesSize[num6] = new SizeF(bitmap2.Size.Width, bitmap2.Size.Height);
					num4 += bitmap2.Width;
					bitmap2.Dispose();
					num7++;
					num6++;
				}
				num5 += array2[0];
			}
		}
		((Texture)texture).Load(context, bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false);
		texture.Size = size2;
		bitmap.Dispose();
	}
}
