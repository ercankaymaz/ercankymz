using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using devDept;
using devDept.Graphics;

internal sealed class _0023_003Dzp268D_GjO8ad1p6OoVpWT6BywmGlJnsGuHeUpWpLEFhx : SilhoCompositingBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzOoRFfkLqvIKTnSyfiw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DztkFeheKdOMuAN5_Zug_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003Dz_sEOZB7QZ38mpycn6A_003D_003D;

	protected override bool InitTargets(Size _0023_003DzM_Gy4Ls_003D)
	{
		OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
		if (!oglRenderContext.HasFBO() || !oglRenderContext.HasFBBlit())
		{
			return false;
		}
		_cleanDepthTexture?.Dispose();
		_silhoColorTexture0?.Dispose();
		_silhoColorTexture1?.Dispose();
		_solidWhiteTexture?.Dispose();
		_0023_003DzOoRFfkLqvIKTnSyfiw_003D_003D?._0023_003DzHF353qc_003D(oglRenderContext);
		_0023_003DztkFeheKdOMuAN5_Zug_003D_003D?._0023_003DzHF353qc_003D(oglRenderContext);
		_0023_003Dz_sEOZB7QZ38mpycn6A_003D_003D?._0023_003DzHF353qc_003D(oglRenderContext);
		_cleanDepthTexture = new OGLTexture(oglRenderContext, (uint)_0023_003DzM_Gy4Ls_003D.Width, (uint)_0023_003DzM_Gy4Ls_003D.Height, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, 33326, 6403, 5126, IntPtr.Zero);
		_0023_003DzMN9kTAW_Xnk4aWx3mw_003D_003D(ref _silhoColorTexture0, _0023_003DzM_Gy4Ls_003D);
		_0023_003DzMN9kTAW_Xnk4aWx3mw_003D_003D(ref _silhoColorTexture1, _0023_003DzM_Gy4Ls_003D);
		_solidWhiteTexture = new OGLTexture(oglRenderContext, 2u, 2u, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, 32856, 6408, 5125, IntPtr.Zero);
		Bitmap bitmap = new Bitmap(2, 2, PixelFormat.Format32bppArgb);
		try
		{
			bitmap.SetPixel(0, 1, Color.White);
			bitmap.SetPixel(1, 1, Color.White);
			bitmap.SetPixel(0, 0, Color.White);
			bitmap.SetPixel(1, 0, Color.White);
			((OGLTexture)_solidWhiteTexture).Load(ParentRenderContext, bitmap, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, anisotropicFiltering: false, repeatX: false, repeatY: false, checkPowerOfTwo: false);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
		_0023_003DzOoRFfkLqvIKTnSyfiw_003D_003D = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(ParentRenderContext, _0023_003DzM_Gy4Ls_003D.Width, _0023_003DzM_Gy4Ls_003D.Height, _0023_003Dzhpb8QNg_003D: false, _0023_003DzaNkZ4Os_003D: false, _0023_003DzMnQWOgMjrI_0024Z: false, ((OGLTexture)_cleanDepthTexture).Name, 0u, _0023_003Dz6mcnErFZlQyn: false);
		_0023_003DztkFeheKdOMuAN5_Zug_003D_003D = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(ParentRenderContext, _0023_003DzM_Gy4Ls_003D.Width, _0023_003DzM_Gy4Ls_003D.Height, _0023_003Dzhpb8QNg_003D: false, _0023_003DzaNkZ4Os_003D: false, _0023_003DzMnQWOgMjrI_0024Z: false, ((OGLTexture)_silhoColorTexture0).Name, 0u, _0023_003Dz6mcnErFZlQyn: false);
		_0023_003Dz_sEOZB7QZ38mpycn6A_003D_003D = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(ParentRenderContext, _0023_003DzM_Gy4Ls_003D.Width, _0023_003DzM_Gy4Ls_003D.Height, _0023_003Dzhpb8QNg_003D: false, _0023_003DzaNkZ4Os_003D: false, _0023_003DzMnQWOgMjrI_0024Z: false, ((OGLTexture)_silhoColorTexture1).Name, 0u, _0023_003Dz6mcnErFZlQyn: false);
		int num = (int)(1u & (_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003Dz59gJCnTN_Ki1(_0023_003DzOoRFfkLqvIKTnSyfiw_003D_003D._0023_003Dz0hLnOJ4_003D()) ? 1u : 0u) & (_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003Dz59gJCnTN_Ki1(_0023_003DztkFeheKdOMuAN5_Zug_003D_003D._0023_003Dz0hLnOJ4_003D()) ? 1u : 0u)) & (_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003Dz59gJCnTN_Ki1(_0023_003Dz_sEOZB7QZ38mpycn6A_003D_003D._0023_003Dz0hLnOJ4_003D()) ? 1 : 0);
		if (num != 0)
		{
			_0023_003DzkRHNeNE_003D(oglRenderContext, _0023_003DzOoRFfkLqvIKTnSyfiw_003D_003D, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: true);
			_0023_003DzkRHNeNE_003D(oglRenderContext, _0023_003DztkFeheKdOMuAN5_Zug_003D_003D, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: true);
			_0023_003DzkRHNeNE_003D(oglRenderContext, _0023_003Dz_sEOZB7QZ38mpycn6A_003D_003D, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: true);
		}
		return (byte)num != 0;
	}

	private void _0023_003DzkRHNeNE_003D(OglRenderContext _0023_003DzmNZD0Zs_003D, _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzOY6IA54_003D, bool _0023_003Dzhpb8QNg_003D, bool _0023_003DzaNkZ4Os_003D)
	{
		_0023_003DzmNZD0Zs_003D._0023_003DzQXov33mauSKJ(_0023_003DzOY6IA54_003D);
		if (_0023_003Dzhpb8QNg_003D)
		{
			_0023_003DzmNZD0Zs_003D.ClearColor(Color.Empty);
		}
		if (_0023_003DzaNkZ4Os_003D)
		{
			_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		}
		_0023_003DzmNZD0Zs_003D.RestoreFBO();
	}

	protected override void FreeTargets()
	{
		base.FreeTargets();
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzUEv4S5BpAiMt = ((OglRenderContext)ParentRenderContext)._0023_003DzUEv4S5BpAiMt;
		_0023_003DzOoRFfkLqvIKTnSyfiw_003D_003D?._0023_003DzHF353qc_003D(ParentRenderContext);
		_0023_003DzOoRFfkLqvIKTnSyfiw_003D_003D = null;
		_0023_003DztkFeheKdOMuAN5_Zug_003D_003D?._0023_003DzHF353qc_003D(ParentRenderContext);
		_0023_003DztkFeheKdOMuAN5_Zug_003D_003D = null;
		_0023_003Dz_sEOZB7QZ38mpycn6A_003D_003D?._0023_003DzHF353qc_003D(ParentRenderContext);
		_0023_003Dz_sEOZB7QZ38mpycn6A_003D_003D = null;
		_0023_003DzUEv4S5BpAiMt?._0023_003Dzri_Jxos_003D(ParentRenderContext);
	}

	private void _0023_003DzMN9kTAW_Xnk4aWx3mw_003D_003D(ref TextureBase _0023_003DzEEim_9E_003D, Size _0023_003Dz0ERMHbg_003D)
	{
		_0023_003DzEEim_9E_003D = new OGLTexture(ParentRenderContext, (uint)_0023_003Dz0ERMHbg_003D.Width, (uint)_0023_003Dz0ERMHbg_003D.Height, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, 34842, 6408, 5126, IntPtr.Zero);
	}

	protected override bool InitShaders()
	{
		if (!(ParentRenderContext is OglRenderContext))
		{
			return false;
		}
		OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
		if (oglRenderContext.RendererVersion.Major < 3)
		{
			return false;
		}
		if (oglRenderContext.ShadingLanguageVersion.Major < 3 || oglRenderContext.ShadingLanguageVersion.Minor < 3)
		{
			return false;
		}
		_0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2 = new _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF();
		InflateSilho = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.InflateSilho);
		oglRenderContext.Shaders.Add(shaderType.InflateSilho, InflateSilho);
		ComputeSilho = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.ComputeSilho);
		oglRenderContext.Shaders.Add(shaderType.ComputeSilho, ComputeSilho);
		CleanDepth = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.CleanDepth);
		oglRenderContext.Shaders.Add(shaderType.CleanDepth, CleanDepth);
		FXAA = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.FXAA);
		oglRenderContext.Shaders.Add(shaderType.FXAA, FXAA);
		return (byte)(1u & (InflateSilho.Compile(oglRenderContext) ? 1u : 0u) & (ComputeSilho.Compile(oglRenderContext) ? 1u : 0u) & (CleanDepth.Compile(oglRenderContext) ? 1u : 0u) & (FXAA.Compile(oglRenderContext) ? 1u : 0u)) != 0;
	}

	protected internal override void SetTarget(silhoTargetType _0023_003DzGR08BY8_003D)
	{
		OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2 = null;
		oglRenderContext._0023_003DzQXov33mauSKJ(_0023_003DzGR08BY8_003D switch
		{
			silhoTargetType.cleanDepth => _0023_003DzOoRFfkLqvIKTnSyfiw_003D_003D, 
			silhoTargetType.silhoColor0 => _0023_003DztkFeheKdOMuAN5_Zug_003D_003D, 
			silhoTargetType.silhoColor1 => _0023_003Dz_sEOZB7QZ38mpycn6A_003D_003D, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601797)), 
		});
	}
}
