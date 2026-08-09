using System.Drawing;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D11;
using devDept;
using devDept.Graphics;

internal sealed class _0023_003DzkrKg_i8aTwYrNyG1idttTI0ogqanZtrgyEXlzOc_003D : AOCompositingBase
{
	public _0023_003DzkrKg_i8aTwYrNyG1idttTI0ogqanZtrgyEXlzOc_003D(bool _0023_003DzUOFKio2ucC4D)
		: base(_0023_003DzUOFKio2ucC4D)
	{
	}

	protected override bool InitTargets(Size _0023_003DzM_Gy4Ls_003D)
	{
		_ = (D3DRenderContext)ParentRenderContext;
		if (ParentRenderContext.RendererVersion.Major < 11)
		{
			return false;
		}
		_viewZTexture?.Dispose();
		_normalTexture?.Dispose();
		_aoRawTexture?.Dispose();
		_aoFilteredTexture?.Dispose();
		_viewZTexture = new D3DTexture2D();
		_normalTexture = new D3DTexture2D();
		_aoRawTexture = new D3DTexture2D();
		_aoFilteredTexture = new D3DTexture2D();
		Size size = new Size(_0023_003DzM_Gy4Ls_003D.Width / 2, _0023_003DzM_Gy4Ls_003D.Height / 2);
		Size size2 = _0023_003DzM_Gy4Ls_003D;
		Texture2DDescription description = new Texture2DDescription
		{
			Width = size2.Width,
			Height = size2.Height,
			ArraySize = 1,
			MipLevels = 0,
			Format = Format.R32_Float,
			Usage = ResourceUsage.Default,
			OptionFlags = ResourceOptionFlags.GenerateMipMaps,
			CpuAccessFlags = CpuAccessFlags.None,
			SampleDescription = new SampleDescription(1, 0),
			BindFlags = (BindFlags.ShaderResource | BindFlags.RenderTarget)
		};
		_viewZTexture.Size = size2;
		((D3DTexture2D)_viewZTexture)._0023_003Dz_IfKSJY_003D = new Texture2D(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, description);
		((D3DTexture2D)_viewZTexture)._0023_003Dz59osH17qGO0V = new RenderTargetView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_viewZTexture)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)_viewZTexture)._0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_viewZTexture)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)_aoRawTexture)._0023_003Dzcp4fLOSZApya(ParentRenderContext, _halfRes ? size : size2, CpuAccessFlags.None, ResourceUsage.Default, Format.R16_Float, BindFlags.ShaderResource | BindFlags.RenderTarget, new SampleDescription(1, 0));
		((D3DTexture2D)_aoRawTexture)._0023_003Dz59osH17qGO0V = new RenderTargetView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_aoRawTexture)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)_aoRawTexture)._0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_aoRawTexture)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)_aoRawTexture)._0023_003Dzxc5GrhYq3y_0024E = ((D3DRenderContext)ParentRenderContext)._0023_003DzKjAPrkH_0024OGSs(Filter.MinMagLinearMipPoint, _0023_003DzDXSkCVA_003D: false, _0023_003DzLYY7OMQ_003D: false, ((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, 0f);
		((D3DTexture2D)_aoFilteredTexture)._0023_003Dzcp4fLOSZApya(ParentRenderContext, _halfRes ? size : size2, CpuAccessFlags.None, ResourceUsage.Default, Format.R16_Float, BindFlags.ShaderResource | BindFlags.RenderTarget, new SampleDescription(1, 0));
		((D3DTexture2D)_aoFilteredTexture)._0023_003Dz59osH17qGO0V = new RenderTargetView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_aoFilteredTexture)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)_aoFilteredTexture)._0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_aoFilteredTexture)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)_aoFilteredTexture)._0023_003Dzxc5GrhYq3y_0024E = ((D3DRenderContext)ParentRenderContext)._0023_003DzKjAPrkH_0024OGSs(Filter.MinMagLinearMipPoint, _0023_003DzDXSkCVA_003D: false, _0023_003DzLYY7OMQ_003D: false, ((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, 0f);
		((D3DTexture2D)_normalTexture)._0023_003Dzcp4fLOSZApya(ParentRenderContext, _0023_003DzM_Gy4Ls_003D, CpuAccessFlags.None, ResourceUsage.Default, Format.R16G16B16A16_Float, BindFlags.ShaderResource | BindFlags.RenderTarget, new SampleDescription(1, 0));
		((D3DTexture2D)_normalTexture)._0023_003Dz59osH17qGO0V = new RenderTargetView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_normalTexture)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)_normalTexture)._0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, ((D3DTexture2D)_normalTexture)._0023_003Dz_IfKSJY_003D);
		((D3DTexture2D)_aoFilteredTexture)._0023_003Dzxc5GrhYq3y_0024E = ((D3DRenderContext)ParentRenderContext)._0023_003DzKjAPrkH_0024OGSs(Filter.MinMagLinearMipPoint, _0023_003DzDXSkCVA_003D: false, _0023_003DzLYY7OMQ_003D: false, ((D3DRenderContext)ParentRenderContext)._0023_003DzTzFVZ_00240_003D, 0f);
		return true;
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
		PreProcess_ViewZ = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003DzGwPtu_Pa4eVsPpKjhlIOzI64mZP3>(d3DRenderContext._0023_003DzTzFVZ_00240_003D, d3DRenderContext._0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601372), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		PreProcess_Normal = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003DzGwPtu_Pa4eVsPpKjhlIOzI64mZP3>(d3DRenderContext._0023_003DzTzFVZ_00240_003D, d3DRenderContext._0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601432), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		ComputeAO = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003DzGwPtu_Pa4eVsPpKjhlIOzI64mZP3>(d3DRenderContext._0023_003DzTzFVZ_00240_003D, d3DRenderContext._0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601470), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		BilateralFilterHor = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003Dz7yxtDMjN_0024R0grLY3Ejh32Nz_0024Sfyy8MmIpo14K_0024w_003D>(d3DRenderContext._0023_003DzTzFVZ_00240_003D, d3DRenderContext._0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601735) + (_halfRes ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601764) : _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601748)), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		BilateralFilterVert = new _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D
		{
			Shader = new global::_0023_003DzHf7tEcKBzK3a0ItyLy4rLEmJCGYl<_0023_003DzXyLJ9Lv_0024L938U7ZRTzXTZc0n_AMJ, _0023_003Dz7yxtDMjN_0024R0grLY3Ejh32Nz_0024Sfyy8MmIpo14K_0024w_003D>(d3DRenderContext._0023_003DzTzFVZ_00240_003D, d3DRenderContext._0023_003DzGIPo6pY0ShMi, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601785) + (_halfRes ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601764) : _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601748)), new InputElement[3]
			{
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601379), 0, Format.R32G32B32_Float, 0, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601396), 0, Format.R32G32B32_Float, InputElement.AppendAligned, 0),
				new InputElement(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601415), 0, Format.R32G32_Float, InputElement.AppendAligned, 0)
			}, new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, -1), new _0023_003Dz9at_0024QszxW_RNJKlaNGVQQiTQcHG_(0, 1), _0023_003DzapxvrBPsjY3LNxiQHQ_003D_003D: false)
		};
		d3DRenderContext.Shaders.Add(shaderType.ViewZFromDepth, PreProcess_ViewZ);
		d3DRenderContext.Shaders.Add(shaderType.NormalFromZ, PreProcess_Normal);
		d3DRenderContext.Shaders.Add(shaderType.ComputeSsao, ComputeAO);
		d3DRenderContext.Shaders.Add(shaderType.BilateralHor, BilateralFilterHor);
		d3DRenderContext.Shaders.Add(shaderType.BilateralVert, BilateralFilterVert);
		return true;
	}

	protected internal override void UpdateAoData(double[] _0023_003DzmkflsmM_003D, float _0023_003DzNsXhzVoM2zWs, float _0023_003DztKWOcOeEKDUk, float _0023_003DzkPVFNGA_003D, float _0023_003DzP9ar0_00240_003D, int _0023_003Dz0lpxPEmp4iKm, float _0023_003Dz2t_v6DnM8indvXOkrg_003D_003D, float _0023_003DznCapsq3EyzM5, float _0023_003DzaoN0GUk_003D)
	{
		base.UpdateAoData(_0023_003DzmkflsmM_003D, _0023_003DzNsXhzVoM2zWs, _0023_003DztKWOcOeEKDUk, _0023_003DzkPVFNGA_003D, _0023_003DzP9ar0_00240_003D, _0023_003Dz0lpxPEmp4iKm, _0023_003Dz2t_v6DnM8indvXOkrg_003D_003D, _0023_003DznCapsq3EyzM5, _0023_003DzaoN0GUk_003D);
		((D3DRenderContext)ParentRenderContext)._0023_003DzNT32oUkqGeGp._0023_003Dz_XLU34E_003D = new _0023_003DzGwPtu_Pa4eVsPpKjhlIOzI64mZP3
		{
			_0023_003DzmkflsmM_003D = new Matrix(_aoParams.Projection),
			_0023_003DzTm8Nk0l4JebN = new Matrix(_aoParams.ProjectionInv),
			_0023_003DzQMKp0GBTVaQG = new Vector2((float)_aoParams.DepthRange.X, (float)_aoParams.DepthRange.Y),
			_0023_003Dzk8cSg_0024jB0LUa = new Vector2((float)_aoParams.NearFar.X, (float)_aoParams.NearFar.Y),
			_0023_003DznCapsq3EyzM5 = _aoParams.Radius,
			_0023_003DzEAGUR3PgEm9Pqtdh3EtjAzk_003D = new Vector2((float)_aoParams.UnprojectMult.X, (float)_aoParams.UnprojectMult.Y),
			_0023_003DzB9GlJr57V1cOMFqkug_003D_003D = new Vector2((float)_aoParams.UnprojectAdd.X, (float)_aoParams.UnprojectAdd.Y)
		};
		((D3DRenderContext)ParentRenderContext)._0023_003DzNT32oUkqGeGp._0023_003DzSQcL1HJvCFIk2E8pDQ_003D_003D = new _0023_003Dz7yxtDMjN_0024R0grLY3Ejh32Nz_0024Sfyy8MmIpo14K_0024w_003D
		{
			_0023_003Dzs0h4Xdc_003D = new Vector2((float)_aoParams.NearFar.X, (float)_aoParams.NearFar.Y),
			_0023_003Dz23J1VCk_003D = 1u,
			_0023_003DznCapsq3EyzM5 = (uint)_aoParams.FilterRadius,
			_0023_003DzszD88_1Kyf4VxJ8HlQ_003D_003D = _aoParams.FilterSmoothness,
			_0023_003Dz1CEjt3w_003D = _aoParams.FilterFactor
		};
	}

	protected internal override void SetTarget(aoTargetType _0023_003DzGR08BY8_003D)
	{
		D3DRenderContext d3DRenderContext = (D3DRenderContext)ParentRenderContext;
		RenderTargetView[] array = null;
		array = _0023_003DzGR08BY8_003D switch
		{
			aoTargetType.viewPos => new RenderTargetView[1] { ((D3DTexture2D)_viewZTexture)._0023_003Dz59osH17qGO0V }, 
			aoTargetType.viewNrm => new RenderTargetView[1] { ((D3DTexture2D)_normalTexture)._0023_003Dz59osH17qGO0V }, 
			aoTargetType.rawAo => new RenderTargetView[1] { ((D3DTexture2D)_aoRawTexture)._0023_003Dz59osH17qGO0V }, 
			aoTargetType.filteredAo => new RenderTargetView[1] { ((D3DTexture2D)_aoFilteredTexture)._0023_003Dz59osH17qGO0V }, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601797)), 
		};
		d3DRenderContext._0023_003DzElzSDDQsrPlQ();
		d3DRenderContext._0023_003Dzi6v0V6E_003D(new D3DRenderContext._0023_003DzB_00241i16ya3eUx(array[0], null));
	}

	protected override void GenMipMapsForPositions()
	{
		((D3DRenderContext)ParentRenderContext)._0023_003DzP7fhLh8_003D.GenerateMips(((D3DTexture2D)_viewZTexture)._0023_003DzV_0024hxxsU_0024ZCJW);
	}
}
