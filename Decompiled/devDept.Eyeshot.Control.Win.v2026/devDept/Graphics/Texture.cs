using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization;
using devDept.Geometry;

namespace devDept.Graphics;

[Serializable]
public abstract class Texture : TextureBase
{
	protected Texture()
	{
	}

	protected Texture(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal void _0023_003DzCT0ooac_003D(Image _0023_003DzoMb5r_0024o_003D, bool _0023_003DzYI_0024_E9M_003D)
	{
		Bitmap bitmap;
		if (_0023_003DzoMb5r_0024o_003D is Bitmap || _0023_003DzoMb5r_0024o_003D == null)
		{
			bitmap = (Bitmap)_0023_003DzoMb5r_0024o_003D;
		}
		else
		{
			bitmap = new Bitmap(_0023_003DzoMb5r_0024o_003D);
			_0023_003DzYI_0024_E9M_003D = true;
		}
		byte[] image = UtilityEx.ConvertImageToBytes(bitmap);
		SetImage(image);
		if (_0023_003DzYI_0024_E9M_003D)
		{
			bitmap.Dispose();
		}
	}

	public abstract void Load(RenderContextBase renderContext, Bitmap bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false);

	public override void Load(RenderContextBase renderContext, IDisposable bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		Load(renderContext, (Bitmap)bitmap, minFunc, magFunc, anisotropicFiltering, repeatX, repeatY, checkPowerOfTwo, enlargeIfSizeNotSupported);
	}

	private protected static void _0023_003DznHIA1IJaK16N(RenderContextBase _0023_003DzmNZD0Zs_003D, Bitmap _0023_003Dzi5Q_0024qQQ_003D, out Bitmap _0023_003DznZW1wLA_003D, bool _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D)
	{
		int dim = _0023_003Dzi5Q_0024qQQ_003D.Width;
		int dim2 = _0023_003Dzi5Q_0024qQQ_003D.Height;
		bool flag;
		bool flag2;
		if (_0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D)
		{
			flag = TextureBase.MakePowerOfTwoBigger(_0023_003DzmNZD0Zs_003D, ref dim);
			flag2 = TextureBase.MakePowerOfTwoBigger(_0023_003DzmNZD0Zs_003D, ref dim2);
		}
		else
		{
			flag = TextureBase.MakePowerOfTwoSmaller(_0023_003DzmNZD0Zs_003D, ref dim);
			flag2 = TextureBase.MakePowerOfTwoSmaller(_0023_003DzmNZD0Zs_003D, ref dim2);
		}
		if (flag || flag2)
		{
			try
			{
				if (_0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D)
				{
					_0023_003DznZW1wLA_003D = new Bitmap(dim, dim2, _0023_003Dzi5Q_0024qQQ_003D.PixelFormat);
					using System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(_0023_003DznZW1wLA_003D);
					graphics.DrawImage(_0023_003Dzi5Q_0024qQQ_003D, new Rectangle(0, 0, _0023_003Dzi5Q_0024qQQ_003D.Width, _0023_003Dzi5Q_0024qQQ_003D.Height));
					return;
				}
				_0023_003DznZW1wLA_003D = new Bitmap(_0023_003Dzi5Q_0024qQQ_003D, dim, dim2);
				return;
			}
			catch (Exception)
			{
			}
		}
		_0023_003DznZW1wLA_003D = _0023_003Dzi5Q_0024qQQ_003D;
	}

	public static byte[] BitmapFromColors(Color[] colorTable)
	{
		Bitmap bitmap = new Bitmap(colorTable.Length, 1, PixelFormat.Format32bppArgb);
		try
		{
			for (int i = 0; i < colorTable.Length; i++)
			{
				bitmap.SetPixel(i, 0, colorTable[i]);
			}
			return UtilityEx.ConvertImageToBytes(bitmap);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
	}

	public static Bitmap MakePowerOfTwo(RenderContextBase renderContext, Bitmap bitmap)
	{
		int num = renderContext.MaxTextureSize();
		if (!renderContext.TextureNonPowerOfTwo || bitmap.Width > num || bitmap.Height > num)
		{
			_0023_003DznHIA1IJaK16N(renderContext, bitmap, out var _0023_003DznZW1wLA_003D, _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D: false);
			return _0023_003DznZW1wLA_003D;
		}
		return bitmap;
	}
}
