using System;
using System.Drawing;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D11;
using devDept.Graphics;

internal sealed class _0023_003DzMS7jTyevb1TJ75swRGke4rxLgN7jxySy_IDWV7zbYiRr : HaloSelectionCompositingBase
{
	protected override bool InitTargets(Size _0023_003DzM_Gy4Ls_003D)
	{
		_ = (D3DRenderContext)ParentRenderContext;
		_texColor?.Dispose();
		_texDepth?.Dispose();
		_texColor = new D3DTexture2D();
		_texDepth = new D3DTextureDepth();
		_texColor.AllocateMemory(ParentRenderContext, renderTarget: true, _0023_003DzM_Gy4Ls_003D.Width, _0023_003DzM_Gy4Ls_003D.Height, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, repeatS: false, repeatT: false, IntPtr.Zero, multisample: false);
		_texDepth.AllocateMemory(ParentRenderContext, renderTarget: true, _0023_003DzM_Gy4Ls_003D.Width, _0023_003DzM_Gy4Ls_003D.Height, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, repeatS: false, repeatT: false, IntPtr.Zero, multisample: false);
		base.InitTargets(_0023_003DzM_Gy4Ls_003D);
		return true;
	}

	protected override bool InitShaders()
	{
		if (!(ParentRenderContext is D3DRenderContext))
		{
			return false;
		}
		if (ParentRenderContext.RendererVersion.Major < 10)
		{
			return false;
		}
		if (ParentRenderContext.Shaders.ContainsKey(shaderType.Outline))
		{
			Shader = ParentRenderContext.Shaders[shaderType.Outline];
			return true;
		}
		D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
		Shader = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003DzGIlo6jT1J5yXKOS746hxfodt7rnz>(d3DRenderContext._0023_003DzTzFVZ_00240_003D, d3DRenderContext._0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601608), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(-1, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		d3DRenderContext.Shaders.Add(shaderType.Outline, Shader);
		return true;
	}

	protected internal override void Update(System.Drawing.Color _0023_003Dzqdeh6JlPW6Zl, System.Drawing.Color _0023_003DzEhcHSlRoMnjZ, System.Drawing.Color _0023_003Dzlp1TbciyP4m7, System.Drawing.Color _0023_003DzU2hgkz1Dd9yM, int _0023_003DzXZNOUZLbVW41x33WzIBpC_0024Q_003D, int _0023_003DzUTEzux0UihD_0024gb_34A_003D_003D)
	{
		base.Update(_0023_003Dzqdeh6JlPW6Zl, _0023_003DzEhcHSlRoMnjZ, _0023_003Dzlp1TbciyP4m7, _0023_003DzU2hgkz1Dd9yM, _0023_003DzXZNOUZLbVW41x33WzIBpC_0024Q_003D, _0023_003DzUTEzux0UihD_0024gb_34A_003D_003D);
		_0023_003DzGIlo6jT1J5yXKOS746hxfodt7rnz _0023_003DzCAYiSntwkyBK8cn_YQ_003D_003D = new _0023_003DzGIlo6jT1J5yXKOS746hxfodt7rnz
		{
			_0023_003DzVRidGfe9qyR2AaEoTA_003D_003D = HaloWidthPolygons,
			_0023_003DzItLxKCgcQZoU = HaloWidthWires,
			_0023_003Dzqi43Drs_003D = new Vector2(_texColor.Size.Width, _texColor.Size.Height),
			_0023_003DzaHFc4kfuVX_00248 = new Vector2(1f / (float)_texColor.Size.Width, 1f / (float)_texColor.Size.Height),
			_0023_003DzzKaVH5s_003D = new Vector4((float)(int)HaloInnerColor.R / 255f, (float)(int)HaloInnerColor.G / 255f, (float)(int)HaloInnerColor.B / 255f, (float)(int)HaloInnerColor.A / 255f),
			_0023_003DzO0c79rg_003D = new Vector4((float)(int)HaloOuterColor.R / 255f, (float)(int)HaloOuterColor.G / 255f, (float)(int)HaloOuterColor.B / 255f, (float)(int)HaloOuterColor.A / 255f),
			_0023_003Dzwe4ESL0AkNZX = new Vector4((float)(int)FillColorFront.R / 255f, (float)(int)FillColorFront.G / 255f, (float)(int)FillColorFront.B / 255f, (float)(int)FillColorFront.A / 255f),
			_0023_003DzgW0AfBm3lQ4D = new Vector4((float)(int)FillColorBack.R / 255f, (float)(int)FillColorBack.G / 255f, (float)(int)FillColorBack.B / 255f, (float)(int)FillColorBack.A / 255f)
		};
		((RenderContext)ParentRenderContext)._0023_003DzNT32oUkqGeGp._0023_003DzCAYiSntwkyBK8cn_YQ_003D_003D = _0023_003DzCAYiSntwkyBK8cn_YQ_003D_003D;
	}

	protected override void ClearForInit()
	{
		if (_texColor != null && _texDepth != null)
		{
			D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
			if (_texColor is D3DTexture2D d3DTexture2D)
			{
				d3DRenderContext._0023_003DzP7fhLh8_003D.ClearRenderTargetView(d3DTexture2D._0023_003Dz59osH17qGO0V, ((D3DRenderContext)ParentRenderContext)._0023_003DzlMzzj_6flRUL(HaloSelectionCompositingBase.ClearColor));
			}
			if (_texDepth is D3DTextureDepth d3DTextureDepth)
			{
				d3DRenderContext._0023_003DzP7fhLh8_003D.ClearDepthStencilView(d3DTextureDepth._0023_003Dz52pY7YIbaCdt, DepthStencilClearFlags.Depth, 1f, 0);
			}
		}
	}

	protected internal override void SetTarget()
	{
		D3DRenderContext obj = (D3DRenderContext)ParentRenderContext;
		obj._0023_003DzElzSDDQsrPlQ();
		obj._0023_003Dzi6v0V6E_003D(new D3DRenderContext._0023_003DzB_00241i16ya3eUx(((D3DTexture2D)_texColor)._0023_003Dz59osH17qGO0V, ((D3DTextureDepth)_texDepth)._0023_003Dz52pY7YIbaCdt));
	}
}
