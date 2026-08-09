using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using OpenGL;
using devDept.Geometry;

namespace devDept.Graphics;

[Serializable]
public abstract class OGLTextureBase : Texture
{
	internal enum _0023_003DzJAg2NQo_003D
	{

	}

	[CLSCompliant(false)]
	public uint Name;

	protected OGLTextureBase(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public OGLTextureBase()
	{
	}

	public override bool IsValid()
	{
		return Name != 0;
	}

	protected void LoadBitmap(RenderContextBase renderContextBase, Bitmap[] bitmaps, bool checkPowerOfTwo, bool enlargeIfSizeNotSupported = false)
	{
		OglRenderContext oglRenderContext = (OglRenderContext)renderContextBase;
		int num = oglRenderContext.MaxTextureSize();
		bool flag = false;
		if (bitmaps == null || bitmaps.Length == 0)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608585));
		}
		Bitmap[] array = new Bitmap[bitmaps.Length];
		if (checkPowerOfTwo && (!oglRenderContext.gl.ARB_texture_non_power_of_two || bitmaps[0].Width > num || bitmaps[0].Height > num))
		{
			for (int i = 0; i < bitmaps.Length; i++)
			{
				Texture._0023_003DznHIA1IJaK16N(oglRenderContext, bitmaps[i], out array[i], enlargeIfSizeNotSupported);
				flag = flag || bitmaps != array;
			}
		}
		else
		{
			array = bitmaps;
		}
		if (array == null)
		{
			return;
		}
		base.Size = array[0].Size;
		int internalFormat = 0;
		int format = 0;
		int type = 5121;
		int num2 = 4;
		int num3 = base.Size.Width * base.Size.Height * num2;
		byte[] array2 = new byte[num3 * array.Length];
		for (int j = 0; j < array.Length; j++)
		{
			Bitmap bitmap = array[j];
			BitmapData bitmapData = LockBitmapBits(bitmap, out internalFormat, out format);
			int stride = bitmapData.Stride;
			IntPtr scan = bitmapData.Scan0;
			for (int k = 0; k < base.Size.Height; k++)
			{
				int offset = k * stride;
				int startIndex = j * num3 + k * base.Size.Width * num2;
				Marshal.Copy(IntPtr.Add(scan, offset), array2, startIndex, base.Size.Width * num2);
			}
			bitmap.UnlockBits(bitmapData);
		}
		if (targetMode == TargetType.Texture3D)
		{
			gl.TexImage3D(32879, 0, internalFormat, base.Size.Width, base.Size.Height, array.Length, 0, format, type, array2);
			if (flag)
			{
				Bitmap[] array3 = array;
				for (int l = 0; l < array3.Length; l++)
				{
					array3[l].Dispose();
				}
			}
			return;
		}
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608636));
	}

	protected void LoadBitmap(RenderContextBase renderContextBase, Bitmap bitmap, bool checkPowerOfTwo, bool enlargeIfSizeNotSupported = false)
	{
		OglRenderContext oglRenderContext = (OglRenderContext)renderContextBase;
		int num = oglRenderContext.MaxTextureSize();
		bool flag = false;
		Bitmap _0023_003DznZW1wLA_003D;
		if (checkPowerOfTwo && (!oglRenderContext.gl.ARB_texture_non_power_of_two || bitmap.Width > num || bitmap.Height > num))
		{
			Texture._0023_003DznHIA1IJaK16N(oglRenderContext, bitmap, out _0023_003DznZW1wLA_003D, enlargeIfSizeNotSupported);
			if (bitmap != _0023_003DznZW1wLA_003D)
			{
				flag = true;
			}
		}
		else
		{
			_0023_003DznZW1wLA_003D = bitmap;
		}
		if (_0023_003DznZW1wLA_003D == null)
		{
			return;
		}
		base.Size = _0023_003DznZW1wLA_003D.Size;
		int type = 5121;
		int internalFormat;
		int format;
		BitmapData bitmapData = LockBitmapBits(_0023_003DznZW1wLA_003D, out internalFormat, out format);
		if (targetMode == TargetType.Texture2D)
		{
			gl.TexImage2D(3553, 0, internalFormat, bitmapData.Width, bitmapData.Height, 0, format, type, bitmapData.Scan0);
		}
		else
		{
			if (targetMode != TargetType.Texture1D)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608636));
			}
			gl.TexImage1D(3552, 0, internalFormat, bitmapData.Width, 0, format, type, bitmapData.Scan0);
		}
		_0023_003DznZW1wLA_003D.UnlockBits(bitmapData);
		if (flag)
		{
			_0023_003DznZW1wLA_003D.Dispose();
		}
	}

	protected BitmapData LockBitmapBits(Bitmap bmp, out int internalFormat, out int format)
	{
		internalFormat = 32856;
		format = 32993;
		PixelFormat format2 = PixelFormat.Format32bppArgb;
		switch (bmp.PixelFormat)
		{
		case PixelFormat.Format24bppRgb:
			format2 = PixelFormat.Format24bppRgb;
			format = 32992;
			internalFormat = 6407;
			break;
		case PixelFormat.Format32bppRgb:
		case PixelFormat.Format32bppPArgb:
		case PixelFormat.Format32bppArgb:
			format2 = PixelFormat.Format32bppArgb;
			break;
		default:
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608947));
		case PixelFormat.Format1bppIndexed:
		case PixelFormat.Format4bppIndexed:
		case PixelFormat.Format8bppIndexed:
			break;
		}
		return bmp.LockBits(new Rectangle(0, 0, bmp.Size.Width, bmp.Size.Height), ImageLockMode.ReadOnly, format2);
	}

	public override void FreeResources()
	{
		OglRenderContext.DelTexture(ref Name);
	}

	internal static int _0023_003DzBum_5fBFid7F(textureFilteringFunctionType _0023_003DzIooYK_0024E_003D)
	{
		int result = 9729;
		switch (_0023_003DzIooYK_0024E_003D)
		{
		case textureFilteringFunctionType.Nearest:
			result = 9728;
			break;
		case textureFilteringFunctionType.Linear:
			result = 9729;
			break;
		case textureFilteringFunctionType.NearestMipmapNearest:
			result = 9984;
			break;
		case textureFilteringFunctionType.LinearMipmapNearest:
			result = 9985;
			break;
		case textureFilteringFunctionType.NearestMipmapLinear:
			result = 9986;
			break;
		case textureFilteringFunctionType.LinearMipmapLinear:
			result = 9987;
			break;
		}
		return result;
	}

	public override void Check()
	{
	}

	public override void UpdateRegion(RenderContextBase renderContext, byte[] bitmap, int xOffset, int yOffset)
	{
		using Bitmap bitmap2 = UtilityEx.ConvertBytesToImage(bitmap);
		if (Name != 0)
		{
			if (xOffset + bitmap2.Width > base.Size.Width)
			{
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603021));
			}
			if (yOffset + bitmap2.Height > base.Size.Height)
			{
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603021));
			}
			renderContext.MakeCurrent();
			int num = 0;
			num = targetMode switch
			{
				TargetType.Texture2D => 3553, 
				TargetType.Texture1D => 3552, 
				_ => throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608977)), 
			};
			gl.BindTexture(num, Name);
			int internalFormat;
			int format;
			BitmapData bitmapData = LockBitmapBits(bitmap2, out internalFormat, out format);
			if (MipMapping)
			{
				gl.TexParameteri(3553, 33169, 1);
			}
			gl.TexSubImage2D(num, 0, xOffset, yOffset, bitmap2.Width, bitmap2.Height, format, 5121, bitmapData.Scan0);
			if (MipMapping)
			{
				gl.TexParameteri(3553, 33169, 0);
			}
			gl.BindTexture(num, 0u);
			bitmap2.UnlockBits(bitmapData);
		}
	}
}
