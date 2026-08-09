using System;
using System.Diagnostics;
using System.Drawing;
using SharpDX.DXGI;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;

namespace devDept.Graphics;

public class D3DTextureDepth : D3DTextureBase, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CLSCompliant(false)]
	internal DepthStencilView _0023_003Dz52pY7YIbaCdt;

	public D3DTextureDepth()
	{
	}

	private D3DTextureDepth(RenderContextBase _0023_003DzoC62DbA_003D, Texture2D _0023_003DzyQmY6T8_003D)
	{
		Texture2DDescription description = _0023_003DzyQmY6T8_003D.Description;
		description.BindFlags = BindFlags.None;
		description.CpuAccessFlags = CpuAccessFlags.Read;
		description.SampleDescription = new SampleDescription(1, 0);
		description.MipLevels = 1;
		description.Usage = ResourceUsage.Staging;
		base.AllocateMemory(_0023_003DzoC62DbA_003D, renderTarget: false, description.Width, description.Height, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, repeatS: false, repeatT: false, IntPtr.Zero, multisample: false);
		_0023_003Dz_IfKSJY_003D = new Texture2D(((D3DRenderContext)_0023_003DzoC62DbA_003D)._0023_003DzTzFVZ_00240_003D, description);
		SampleDescription sampleDescription = _0023_003DzyQmY6T8_003D.Description.SampleDescription;
		if (sampleDescription.Count != 1 || sampleDescription.Quality != 0)
		{
			((D3DRenderContext)_0023_003DzoC62DbA_003D)._0023_003DzP7fhLh8_003D.ResolveSubresource(_0023_003DzyQmY6T8_003D, 0, _0023_003Dz_IfKSJY_003D, 0, description.Format);
		}
		else
		{
			((D3DRenderContext)_0023_003DzoC62DbA_003D)._0023_003DzP7fhLh8_003D.CopyResource(_0023_003DzyQmY6T8_003D, _0023_003Dz_IfKSJY_003D);
		}
	}

	public override void FreeResources()
	{
		base.FreeResources();
		if (_0023_003Dz52pY7YIbaCdt != null)
		{
			_0023_003Dz52pY7YIbaCdt.Dispose();
			_0023_003Dz52pY7YIbaCdt = null;
		}
	}

	public override void Load(RenderContextBase renderContext, IDisposable[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		throw new NotImplementedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602902));
	}

	public override void UpdateRegion(RenderContextBase renderContext, byte[] bitmap, int xOffset, int yOffset)
	{
		throw new NotImplementedException();
	}

	public override void Load(RenderContextBase renderContext, byte[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		throw new NotImplementedException();
	}

	public override void Load(RenderContextBase renderContext, Bitmap bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		throw new NotImplementedException();
	}

	public override void Unbind()
	{
		throw new NotImplementedException();
	}

	public override void AllocateMemory(RenderContextBase context, bool renderTarget, int width, int height, textureFilteringFunctionType minFilter, textureFilteringFunctionType magFilter, bool repeatS, bool repeatT, IntPtr pixels, bool multisample)
	{
		base.AllocateMemory(context, renderTarget, width, height, minFilter, magFilter, repeatS, repeatT, pixels, multisample);
		SampleDescription _0023_003DzoZFDtSI_003D = ((D3DRenderContext)context)._0023_003DzoZFDtSI_003D;
		SampleDescription sampleDescription = new SampleDescription(1, 0);
		Texture2DDescription description = new Texture2DDescription
		{
			Width = width,
			Height = height,
			MipLevels = 1,
			ArraySize = 1,
			Format = Format.R24G8_Typeless,
			SampleDescription = (multisample ? _0023_003DzoZFDtSI_003D : sampleDescription),
			Usage = ResourceUsage.Default,
			BindFlags = (BindFlags.ShaderResource | BindFlags.DepthStencil),
			CpuAccessFlags = CpuAccessFlags.None,
			OptionFlags = ResourceOptionFlags.None
		};
		D3DRenderContext d3DRenderContext = (D3DRenderContext)context;
		_0023_003Dz_IfKSJY_003D = new Texture2D(d3DRenderContext._0023_003DzTzFVZ_00240_003D, description);
		DepthStencilViewDescription.Texture2DResource texture2D = new DepthStencilViewDescription.Texture2DResource
		{
			MipSlice = 0
		};
		DepthStencilViewDescription description2 = new DepthStencilViewDescription
		{
			Flags = DepthStencilViewFlags.None,
			Format = Format.D24_UNorm_S8_UInt,
			Dimension = ((multisample && _0023_003DzoZFDtSI_003D.Count > 1) ? DepthStencilViewDimension.Texture2DMultisampled : DepthStencilViewDimension.Texture2D),
			Texture2D = texture2D
		};
		_0023_003Dz52pY7YIbaCdt = new DepthStencilView(((D3DRenderContext)context)._0023_003DzTzFVZ_00240_003D, _0023_003Dz_IfKSJY_003D, description2);
		ShaderResourceViewDescription.Texture2DResource texture2D2 = new ShaderResourceViewDescription.Texture2DResource
		{
			MipLevels = description.MipLevels,
			MostDetailedMip = 0
		};
		ShaderResourceViewDescription description3 = new ShaderResourceViewDescription
		{
			Format = Format.R24_UNorm_X8_Typeless,
			Dimension = ((multisample && _0023_003DzoZFDtSI_003D.Count > 1) ? ShaderResourceViewDimension.Texture2DMultisampled : ShaderResourceViewDimension.Texture2D),
			Texture2D = texture2D2
		};
		_0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(((D3DRenderContext)context)._0023_003DzTzFVZ_00240_003D, _0023_003Dz_IfKSJY_003D, description3);
		_0023_003Dzxc5GrhYq3y_0024E = ((D3DRenderContext)context)._0023_003DzKjAPrkH_0024OGSs(D3DTexture._0023_003DzBum_5fBFid7F(minFilter, magFilter), repeatS, repeatT, ((D3DRenderContext)context)._0023_003DzTzFVZ_00240_003D, 0f);
	}

	public override void Check()
	{
		throw new NotImplementedException();
	}

	public short[] ReadDepths(Rectangle rect)
	{
		return D3DTexture2D._0023_003DzfaPKPFFTbIMY5EK3Vg_003D_003D(rect, (Texture2D)_0023_003Dz_IfKSJY_003D);
	}

	[CLSCompliant(false)]
	internal static byte[] _0023_003DzNqVBjksx5BGm9KUZ8g_003D_003D(RenderContextBase _0023_003DzoC62DbA_003D, Texture2D _0023_003DzyQmY6T8_003D, Rectangle _0023_003Dzols9v2M_003D)
	{
		D3DTextureDepth d3DTextureDepth = new D3DTextureDepth(_0023_003DzoC62DbA_003D, _0023_003DzyQmY6T8_003D);
		short[] array = D3DTexture2D._0023_003DzfaPKPFFTbIMY5EK3Vg_003D_003D(_0023_003Dzols9v2M_003D, (Texture2D)d3DTextureDepth._0023_003Dz_IfKSJY_003D);
		byte[] array2 = new byte[_0023_003Dzols9v2M_003D.Width * _0023_003Dzols9v2M_003D.Height * 4];
		double num = 0.007782219916379284;
		int width = ((Texture2D)d3DTextureDepth._0023_003Dz_IfKSJY_003D).Description.Width;
		int height = ((Texture2D)d3DTextureDepth._0023_003Dz_IfKSJY_003D).Description.Height;
		int num2 = width - _0023_003Dzols9v2M_003D.Width;
		int num3 = _0023_003Dzols9v2M_003D.Y * width + _0023_003Dzols9v2M_003D.X;
		int num4 = 0;
		for (int i = 0; i < _0023_003Dzols9v2M_003D.Height; i++)
		{
			num3 = (height - i - 1) * width;
			int num5 = 0;
			while (num5 < _0023_003Dzols9v2M_003D.Width)
			{
				double num6 = num * (double)array[num3];
				array2[num4++] = (byte)num6;
				array2[num4++] = (byte)num6;
				array2[num4++] = (byte)num6;
				array2[num4++] = byte.MaxValue;
				num5++;
				num3++;
			}
			num3 += num2;
		}
		d3DTextureDepth.Dispose();
		return array2;
	}
}
