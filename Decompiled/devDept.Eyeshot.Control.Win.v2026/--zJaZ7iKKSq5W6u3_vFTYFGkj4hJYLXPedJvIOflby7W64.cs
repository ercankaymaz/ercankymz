using System;
using System.Drawing;
using System.Drawing.Imaging;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D11;
using devDept;
using devDept.Graphics;

internal sealed class _0023_003DzJaZ7iKKSq5W6u3_vFTYFGkj4hJYLXPedJvIOflby7W64 : SilhoCompositingBase
{
	protected override bool InitTargets(Size _0023_003DzM_Gy4Ls_003D)
	{
		_ = (D3DRenderContext)ParentRenderContext;
		_cleanDepthTexture?.Dispose();
		_silhoColorTexture0?.Dispose();
		_silhoColorTexture1?.Dispose();
		_solidWhiteTexture?.Dispose();
		_cleanDepthTexture = new D3DTexture2D();
		_silhoColorTexture0 = new D3DTexture2D();
		_silhoColorTexture1 = new D3DTexture2D();
		_solidWhiteTexture = new D3DTexture2D();
		((D3DTexture2D)_cleanDepthTexture)._0023_003Dzcp4fLOSZApya(ParentRenderContext, _0023_003DzM_Gy4Ls_003D, CpuAccessFlags.None, ResourceUsage.Default, Format.R32_Float, BindFlags.ShaderResource | BindFlags.RenderTarget, new SampleDescription(1, 0));
		((D3DTexture2D)_cleanDepthTexture)._0023_003Dz59osH17qGO0V = new RenderTargetView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_cleanDepthTexture)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)_cleanDepthTexture)._0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_cleanDepthTexture)._0023_003Dz_IfKSJY_003D);
		_0023_003DzMN9kTAW_Xnk4aWx3mw_003D_003D((D3DTexture2D)_silhoColorTexture0, _0023_003DzM_Gy4Ls_003D);
		_0023_003DzMN9kTAW_Xnk4aWx3mw_003D_003D((D3DTexture2D)_silhoColorTexture1, _0023_003DzM_Gy4Ls_003D);
		((D3DTexture2D)_solidWhiteTexture)._0023_003Dzcp4fLOSZApya(ParentRenderContext, new Size(2, 2), CpuAccessFlags.None, ResourceUsage.Default, Format.B8G8R8A8_UNorm, BindFlags.ShaderResource, new SampleDescription(1, 0));
		((D3DTexture2D)_solidWhiteTexture)._0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_solidWhiteTexture)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)_solidWhiteTexture)._0023_003Dzxc5GrhYq3y_0024E = ((D3DRenderContext)ParentRenderContext)._0023_003DzKjAPrkH_0024OGSs(Filter.MinMagLinearMipPoint, _0023_003DzDXSkCVA_003D: false, _0023_003DzLYY7OMQ_003D: false, ((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, 0f);
		Bitmap bitmap = new Bitmap(2, 2, PixelFormat.Format32bppArgb);
		try
		{
			bitmap.SetPixel(0, 1, System.Drawing.Color.White);
			bitmap.SetPixel(1, 1, System.Drawing.Color.White);
			bitmap.SetPixel(0, 0, System.Drawing.Color.White);
			bitmap.SetPixel(1, 0, System.Drawing.Color.White);
			((D3DTexture2D)_solidWhiteTexture).Load(ParentRenderContext, bitmap, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, anisotropicFiltering: false, repeatX: false, repeatY: false, checkPowerOfTwo: false);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
		return true;
	}

	private void _0023_003DzMN9kTAW_Xnk4aWx3mw_003D_003D(D3DTexture2D _0023_003DzEEim_9E_003D, Size _0023_003Dz0ERMHbg_003D)
	{
		_0023_003DzEEim_9E_003D._0023_003Dzcp4fLOSZApya(ParentRenderContext, _0023_003Dz0ERMHbg_003D, CpuAccessFlags.None, ResourceUsage.Default, Format.R16G16B16A16_Float, BindFlags.ShaderResource | BindFlags.RenderTarget, new SampleDescription(1, 0));
		_0023_003DzEEim_9E_003D._0023_003Dz59osH17qGO0V = new RenderTargetView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, _0023_003DzEEim_9E_003D._0023_003Dz_IfKSJY_003D);
		_0023_003DzEEim_9E_003D._0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, _0023_003DzEEim_9E_003D._0023_003Dz_IfKSJY_003D);
		_0023_003DzEEim_9E_003D._0023_003Dzxc5GrhYq3y_0024E = ((D3DRenderContext)ParentRenderContext)._0023_003DzKjAPrkH_0024OGSs(Filter.MinMagLinearMipPoint, _0023_003DzDXSkCVA_003D: false, _0023_003DzLYY7OMQ_003D: false, ((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, 0f);
	}

	protected override bool InitShaders()
	{
		if (!(ParentRenderContext is D3DRenderContext))
		{
			return false;
		}
		if (ParentRenderContext.RendererVersion.Major < 11)
		{
			return false;
		}
		D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
		CleanDepth = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003DzQusP5X6k0YDE_L4IZSi73sV2mg11Iblsqg_003D_003D>(d3DRenderContext._0023_003DzTzFVZ_00240_003D, d3DRenderContext._0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605917), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		ComputeSilho = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003DzQusP5X6k0YDE_L4IZSi73sV2mg11Iblsqg_003D_003D>(d3DRenderContext._0023_003DzTzFVZ_00240_003D, d3DRenderContext._0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605932), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		InflateSilho = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003DzQusP5X6k0YDE_L4IZSi73sV2mg11Iblsqg_003D_003D>(d3DRenderContext._0023_003DzTzFVZ_00240_003D, d3DRenderContext._0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605945), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		FXAA = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003DzGwPtu_Pa4eVsPpKjhlIOzI64mZP3>(d3DRenderContext._0023_003DzTzFVZ_00240_003D, d3DRenderContext._0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605702), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		d3DRenderContext.Shaders.Add(shaderType.CleanDepth, CleanDepth);
		d3DRenderContext.Shaders.Add(shaderType.ComputeSilho, ComputeSilho);
		d3DRenderContext.Shaders.Add(shaderType.InflateSilho, InflateSilho);
		d3DRenderContext.Shaders.Add(shaderType.FXAA, FXAA);
		return true;
	}

	protected internal override void UpdateSilhoData(int _0023_003DzS0fnu_0024nZ8YzY, System.Drawing.Color _0023_003DzOYiMVKUIIseY, double[] _0023_003DzmkflsmM_003D, float _0023_003DzNsXhzVoM2zWs, float _0023_003DztKWOcOeEKDUk, float _0023_003DzkPVFNGA_003D, float _0023_003DzP9ar0_00240_003D)
	{
		base.UpdateSilhoData(_0023_003DzS0fnu_0024nZ8YzY, _0023_003DzOYiMVKUIIseY, _0023_003DzmkflsmM_003D, _0023_003DzNsXhzVoM2zWs, _0023_003DztKWOcOeEKDUk, _0023_003DzkPVFNGA_003D, _0023_003DzP9ar0_00240_003D);
		((D3DRenderContext)ParentRenderContext)._0023_003DzNT32oUkqGeGp._0023_003DzLmTHH5_Q8vG_ = new _0023_003DzQusP5X6k0YDE_L4IZSi73sV2mg11Iblsqg_003D_003D
		{
			_0023_003DzmkflsmM_003D = new Matrix(_silhoShaderParams.Projection),
			_0023_003DzQMKp0GBTVaQG = new Vector2((float)_silhoShaderParams.DepthRange.X, (float)_silhoShaderParams.DepthRange.Y),
			_0023_003Dzk8cSg_0024jB0LUa = new Vector2((float)_silhoShaderParams.NearFar.X, (float)_silhoShaderParams.NearFar.Y)
		};
	}

	protected internal override void SetTarget(silhoTargetType _0023_003DzGR08BY8_003D)
	{
		D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
		RenderTargetView[] array = null;
		array = _0023_003DzGR08BY8_003D switch
		{
			silhoTargetType.cleanDepth => new RenderTargetView[1] { ((D3DTexture2D)_cleanDepthTexture)._0023_003Dz59osH17qGO0V }, 
			silhoTargetType.silhoColor0 => new RenderTargetView[1] { ((D3DTexture2D)_silhoColorTexture0)._0023_003Dz59osH17qGO0V }, 
			silhoTargetType.silhoColor1 => new RenderTargetView[1] { ((D3DTexture2D)_silhoColorTexture1)._0023_003Dz59osH17qGO0V }, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601797)), 
		};
		d3DRenderContext._0023_003DzElzSDDQsrPlQ();
		d3DRenderContext._0023_003Dzi6v0V6E_003D(new D3DRenderContext._0023_003DzB_00241i16ya3eUx(array[0], null));
	}
}
