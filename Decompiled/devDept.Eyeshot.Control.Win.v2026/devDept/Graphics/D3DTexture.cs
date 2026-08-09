using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using devDept.Geometry;

namespace devDept.Graphics;

public abstract class D3DTexture : D3DTextureBase, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CLSCompliant(false)]
	internal RenderTargetView _0023_003Dz59osH17qGO0V;

	protected D3DTexture()
	{
	}

	protected D3DTexture(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public override void UpdateRegion(RenderContextBase renderContext, byte[] bitmap, int xOffset, int yOffset)
	{
		if (_0023_003Dz_IfKSJY_003D == null)
		{
			return;
		}
		using Bitmap bitmap2 = UtilityEx.ConvertBytesToImage(bitmap);
		if (xOffset + bitmap2.Width > base.Size.Width)
		{
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603021));
		}
		if (yOffset + bitmap2.Height > base.Size.Height)
		{
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603021));
		}
		int right = xOffset + bitmap2.Width;
		int bottom = yOffset + bitmap2.Height;
		BitmapData bitmapData = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		((D3DRenderContext)renderContext)._0023_003DzP7fhLh8_003D.UpdateSubresource(_0023_003Dz_IfKSJY_003D, 0, new ResourceRegion(xOffset, yOffset, 0, right, bottom, 1), bitmapData.Scan0, bitmapData.Stride, 0);
		bitmap2.UnlockBits(bitmapData);
		if (MipMapping)
		{
			((D3DRenderContext)renderContext)._0023_003DzP7fhLh8_003D.GenerateMips(_0023_003DzV_0024hxxsU_0024ZCJW);
		}
	}

	public override void Load(RenderContextBase renderContext, byte[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		throw new NotImplementedException();
	}

	public override void Load(RenderContextBase renderContext, Bitmap bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		throw new NotImplementedException();
	}

	protected void CheckTextureSize(D3DRenderContext context, Size size)
	{
		int num = ((context._0023_003DzGIPo6pY0ShMi < FeatureLevel.Level_11_0) ? 8192 : 16384);
		if (size.Width > num || size.Height > num)
		{
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603045) + size.Width + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603073) + size.Height + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603097) + context._0023_003DzGIPo6pY0ShMi.ToString() + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602881) + num + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620810));
		}
	}

	public override void FreeResources()
	{
		base.FreeResources();
		if (_0023_003Dz59osH17qGO0V != null)
		{
			_0023_003Dz59osH17qGO0V.Dispose();
			_0023_003Dz59osH17qGO0V = null;
		}
	}

	internal static Filter _0023_003DzBum_5fBFid7F(textureFilteringFunctionType _0023_003DzoYJjnU0_003D, textureFilteringFunctionType _0023_003DzxOGXf6I_003D)
	{
		Filter result = Filter.MinMagLinearMipPoint;
		switch (_0023_003DzoYJjnU0_003D)
		{
		case textureFilteringFunctionType.Nearest:
			switch (_0023_003DzxOGXf6I_003D)
			{
			case textureFilteringFunctionType.Nearest:
				result = Filter.MinMagMipPoint;
				break;
			case textureFilteringFunctionType.Linear:
				result = Filter.MinPointMagLinearMipPoint;
				break;
			case textureFilteringFunctionType.NearestMipmapNearest:
				result = Filter.MinMagMipPoint;
				break;
			case textureFilteringFunctionType.LinearMipmapNearest:
				result = Filter.MinPointMagLinearMipPoint;
				break;
			case textureFilteringFunctionType.NearestMipmapLinear:
				result = Filter.MinMagPointMipLinear;
				break;
			case textureFilteringFunctionType.LinearMipmapLinear:
				result = Filter.MinPointMagMipLinear;
				break;
			}
			break;
		case textureFilteringFunctionType.Linear:
			switch (_0023_003DzxOGXf6I_003D)
			{
			case textureFilteringFunctionType.Nearest:
				result = Filter.MinLinearMagMipPoint;
				break;
			case textureFilteringFunctionType.Linear:
				result = Filter.MinMagLinearMipPoint;
				break;
			case textureFilteringFunctionType.NearestMipmapNearest:
				result = Filter.MinLinearMagMipPoint;
				break;
			case textureFilteringFunctionType.LinearMipmapNearest:
				result = Filter.MinMagLinearMipPoint;
				break;
			case textureFilteringFunctionType.NearestMipmapLinear:
				result = Filter.MinMagLinearMipPoint;
				break;
			case textureFilteringFunctionType.LinearMipmapLinear:
				result = Filter.MinMagMipLinear;
				break;
			}
			break;
		case textureFilteringFunctionType.NearestMipmapNearest:
			switch (_0023_003DzxOGXf6I_003D)
			{
			case textureFilteringFunctionType.Nearest:
				result = Filter.MinMagMipPoint;
				break;
			case textureFilteringFunctionType.Linear:
				result = Filter.MinPointMagLinearMipPoint;
				break;
			case textureFilteringFunctionType.NearestMipmapNearest:
				result = Filter.MinMagMipPoint;
				break;
			case textureFilteringFunctionType.LinearMipmapNearest:
				result = Filter.MinPointMagLinearMipPoint;
				break;
			case textureFilteringFunctionType.NearestMipmapLinear:
				result = Filter.MinMagMipPoint;
				break;
			case textureFilteringFunctionType.LinearMipmapLinear:
				result = Filter.MinMagLinearMipPoint;
				break;
			}
			break;
		case textureFilteringFunctionType.LinearMipmapNearest:
			switch (_0023_003DzxOGXf6I_003D)
			{
			case textureFilteringFunctionType.Nearest:
				result = Filter.MinLinearMagMipPoint;
				break;
			case textureFilteringFunctionType.Linear:
				result = Filter.MinMagLinearMipPoint;
				break;
			case textureFilteringFunctionType.NearestMipmapNearest:
				result = Filter.MinLinearMagMipPoint;
				break;
			case textureFilteringFunctionType.LinearMipmapNearest:
				result = Filter.MinMagLinearMipPoint;
				break;
			case textureFilteringFunctionType.NearestMipmapLinear:
				result = Filter.MinLinearMagMipPoint;
				break;
			case textureFilteringFunctionType.LinearMipmapLinear:
				result = Filter.MinMagLinearMipPoint;
				break;
			}
			break;
		case textureFilteringFunctionType.NearestMipmapLinear:
			switch (_0023_003DzxOGXf6I_003D)
			{
			case textureFilteringFunctionType.Nearest:
				result = Filter.MinMagPointMipLinear;
				break;
			case textureFilteringFunctionType.Linear:
				result = Filter.MinPointMagMipLinear;
				break;
			case textureFilteringFunctionType.NearestMipmapNearest:
				result = Filter.MinMagPointMipLinear;
				break;
			case textureFilteringFunctionType.LinearMipmapNearest:
				result = Filter.MinPointMagMipLinear;
				break;
			case textureFilteringFunctionType.NearestMipmapLinear:
				result = Filter.MinMagPointMipLinear;
				break;
			case textureFilteringFunctionType.LinearMipmapLinear:
				result = Filter.MinPointMagMipLinear;
				break;
			}
			break;
		case textureFilteringFunctionType.LinearMipmapLinear:
			switch (_0023_003DzxOGXf6I_003D)
			{
			case textureFilteringFunctionType.Nearest:
				result = Filter.MinLinearMagPointMipLinear;
				break;
			case textureFilteringFunctionType.Linear:
				result = Filter.MinMagMipLinear;
				break;
			case textureFilteringFunctionType.NearestMipmapNearest:
				result = Filter.MinLinearMagPointMipLinear;
				break;
			case textureFilteringFunctionType.LinearMipmapNearest:
				result = Filter.MinMagMipLinear;
				break;
			case textureFilteringFunctionType.NearestMipmapLinear:
				result = Filter.MinLinearMagPointMipLinear;
				break;
			case textureFilteringFunctionType.LinearMipmapLinear:
				result = Filter.MinMagMipLinear;
				break;
			}
			break;
		}
		return result;
	}

	public override void Unbind()
	{
	}

	public override void Check()
	{
	}
}
