using System.Drawing;
using System.Linq;
using SharpDX.DXGI;
using SharpDX.Direct3D11;
using devDept.Diagnostic;
using devDept.Graphics;

internal sealed class _0023_003DzGN6L4iqA40fnK_jNmDrzBhNVvUE3NT1lJFshoGLOjlNngLRVZQ_003D_003D : SmoothUICompositingBase
{
	protected override bool InitTargets(Size _0023_003DzM_Gy4Ls_003D)
	{
		D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
		_msTexColor?.Dispose();
		_msTexDepth?.Dispose();
		_resolveTex?.Dispose();
		Texture2DDescription texture2DDescription = d3DRenderContext._0023_003Dz44KfZ5g_003D(_0023_003DzM_Gy4Ls_003D.Width, _0023_003DzM_Gy4Ls_003D.Height);
		SampleDescription _0023_003DzCEGI0ngjOjCn = new SampleDescription(1, 0);
		Texture2DDescription description = new Texture2DDescription
		{
			Width = _0023_003DzM_Gy4Ls_003D.Width,
			Height = _0023_003DzM_Gy4Ls_003D.Height,
			ArraySize = 1,
			BindFlags = BindFlags.DepthStencil,
			CpuAccessFlags = CpuAccessFlags.None,
			Format = Format.D24_UNorm_S8_UInt,
			MipLevels = 1,
			OptionFlags = ResourceOptionFlags.None,
			SampleDescription = _0023_003DzCEGI0ngjOjCn,
			Usage = ResourceUsage.Default
		};
		Logger.Instance.Trace(d3DRenderContext.ControlData.InstanceId, GetType().ToString().Split('.').LastOrDefault() + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605717));
		if (!d3DRenderContext._0023_003DzENoa3feOVaqa(texture2DDescription.Format, antialiasingSamplesNumberType.x16, ref _0023_003DzCEGI0ngjOjCn))
		{
			return false;
		}
		Logger.Instance.Trace(d3DRenderContext.ControlData.InstanceId, GetType().ToString().Split('.').LastOrDefault() + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605761));
		int count = _0023_003DzCEGI0ngjOjCn.Count;
		d3DRenderContext._0023_003DzENoa3feOVaqa(description.Format, antialiasingSamplesNumberType.x16, ref _0023_003DzCEGI0ngjOjCn);
		if (_0023_003DzCEGI0ngjOjCn.Count != count)
		{
			return false;
		}
		description.SampleDescription = _0023_003DzCEGI0ngjOjCn;
		texture2DDescription.SampleDescription = _0023_003DzCEGI0ngjOjCn;
		texture2DDescription.MipLevels = 1;
		_msTexColor = new D3DTexture2D();
		((D3DTexture2D)_msTexColor)._0023_003Dzcp4fLOSZApya(d3DRenderContext, _0023_003DzM_Gy4Ls_003D, CpuAccessFlags.None, ResourceUsage.Default, texture2DDescription.Format, BindFlags.RenderTarget, _0023_003DzCEGI0ngjOjCn);
		((D3DTexture2D)_msTexColor)._0023_003Dz59osH17qGO0V = new RenderTargetView(d3DRenderContext._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_msTexColor)._0023_003Dz_IfKSJY_003D);
		_msTexDepth = new D3DTextureDepth();
		((D3DTextureDepth)_msTexDepth)._0023_003Dz_IfKSJY_003D = new Texture2D(d3DRenderContext._0023_003DzTzFVZ_00240_003D, description);
		_msTexDepth.Size = _0023_003DzM_Gy4Ls_003D;
		((D3DTextureDepth)_msTexDepth)._0023_003Dz52pY7YIbaCdt = new DepthStencilView(d3DRenderContext._0023_003DzTzFVZ_00240_003D, ((D3DTextureDepth)_msTexDepth)._0023_003Dz_IfKSJY_003D);
		_resolveTex = new D3DTexture2D();
		((D3DTexture2D)_resolveTex)._0023_003Dzcp4fLOSZApya(d3DRenderContext, _0023_003DzM_Gy4Ls_003D, CpuAccessFlags.None, ResourceUsage.Default, texture2DDescription.Format, BindFlags.ShaderResource, new SampleDescription(1, 0));
		((D3DTexture2D)_resolveTex)._0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(d3DRenderContext._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_resolveTex)._0023_003Dz_IfKSJY_003D);
		return true;
	}

	protected override bool InitShaders()
	{
		return true;
	}

	protected internal override void Clear()
	{
		if (_msTexColor != null && _msTexDepth != null && _resolveTex != null)
		{
			D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
			if (_msTexColor is D3DTexture2D d3DTexture2D)
			{
				d3DRenderContext._0023_003DzP7fhLh8_003D.ClearRenderTargetView(d3DTexture2D._0023_003Dz59osH17qGO0V, ((D3DRenderContext)ParentRenderContext)._0023_003DzlMzzj_6flRUL(SmoothUICompositingBase.ClearColor));
			}
			if (_msTexDepth is D3DTextureDepth d3DTextureDepth)
			{
				d3DRenderContext._0023_003DzP7fhLh8_003D.ClearDepthStencilView(d3DTextureDepth._0023_003Dz52pY7YIbaCdt, DepthStencilClearFlags.Depth, 1f, 0);
			}
		}
	}

	protected override void ResolveMSTexture()
	{
		D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
		d3DRenderContext._0023_003DzP7fhLh8_003D.ResolveSubresource(((D3DTexture2D)_msTexColor)._0023_003Dz_IfKSJY_003D, 0, ((D3DTexture2D)_resolveTex)._0023_003Dz_IfKSJY_003D, 0, d3DRenderContext._0023_003Dz44KfZ5g_003D(1, 1).Format);
	}

	protected internal override void SetMSTarget()
	{
		base.SetMSTarget();
		D3DRenderContext obj = (D3DRenderContext)ParentRenderContext;
		obj._0023_003DzElzSDDQsrPlQ();
		obj._0023_003Dzi6v0V6E_003D(new D3DRenderContext._0023_003DzB_00241i16ya3eUx(((D3DTexture2D)_msTexColor)._0023_003Dz59osH17qGO0V, ((D3DTextureDepth)_msTexDepth)._0023_003Dz52pY7YIbaCdt));
	}
}
