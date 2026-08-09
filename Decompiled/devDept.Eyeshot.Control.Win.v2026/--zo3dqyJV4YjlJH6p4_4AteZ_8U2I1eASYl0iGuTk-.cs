using System;
using System.Diagnostics;
using System.Drawing;
using OpenGL;
using devDept;
using devDept.Graphics;

internal sealed class _0023_003Dzo3dqyJV4YjlJH6p4_4AteZ_8U2I1eASYl0iGuTk_003D : AOCompositingBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzxGr7ogwPpwX_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzGgJwOnbEMfis;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzkT87yEmW_0024lCL0BCvbQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003Dz5bcpK4sXCeJzysRXIA_003D_003D;

	public _0023_003Dzo3dqyJV4YjlJH6p4_4AteZ_8U2I1eASYl0iGuTk_003D(bool _0023_003DzUOFKio2ucC4D)
		: base(_0023_003DzUOFKio2ucC4D)
	{
	}

	protected override bool InitTargets(Size _0023_003DzM_Gy4Ls_003D)
	{
		OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
		if (!oglRenderContext.HasFBO() || !oglRenderContext.HasFBBlit())
		{
			return false;
		}
		_viewZTexture?.Dispose();
		_normalTexture?.Dispose();
		_aoRawTexture?.Dispose();
		_aoFilteredTexture?.Dispose();
		_0023_003DzxGr7ogwPpwX_0024?._0023_003DzHF353qc_003D(oglRenderContext);
		_0023_003DzGgJwOnbEMfis?._0023_003DzHF353qc_003D(oglRenderContext);
		_0023_003DzkT87yEmW_0024lCL0BCvbQ_003D_003D?._0023_003DzHF353qc_003D(oglRenderContext);
		_0023_003Dz5bcpK4sXCeJzysRXIA_003D_003D?._0023_003DzHF353qc_003D(oglRenderContext);
		Size size = new Size(_0023_003DzM_Gy4Ls_003D.Width / 2, _0023_003DzM_Gy4Ls_003D.Height / 2);
		Size size2 = _0023_003DzM_Gy4Ls_003D;
		_viewZTexture = new OGLTexture(oglRenderContext, (uint)size2.Width, (uint)size2.Height, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, 33326, 6403, 5126, IntPtr.Zero);
		_aoRawTexture = new OGLTexture(oglRenderContext, (uint)(_halfRes ? size : size2).Width, (uint)(_halfRes ? size : size2).Height, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, 33325, 6403, 5126, IntPtr.Zero);
		_aoFilteredTexture = new OGLTexture(oglRenderContext, (uint)(_halfRes ? size : size2).Width, (uint)(_halfRes ? size : size2).Height, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, 33325, 6403, 5126, IntPtr.Zero);
		_normalTexture = new OGLTexture(oglRenderContext, (uint)size2.Width, (uint)size2.Height, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, 34842, 6407, 5126, IntPtr.Zero);
		_0023_003DzxGr7ogwPpwX_0024 = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(oglRenderContext, size2.Width, size2.Height, _0023_003Dzhpb8QNg_003D: false, _0023_003DzaNkZ4Os_003D: false, _0023_003DzMnQWOgMjrI_0024Z: false, ((OGLTexture)_viewZTexture).Name, 0u, _0023_003Dz6mcnErFZlQyn: false);
		_0023_003DzGgJwOnbEMfis = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(oglRenderContext, size2.Width, size2.Height, _0023_003Dzhpb8QNg_003D: false, _0023_003DzaNkZ4Os_003D: false, _0023_003DzMnQWOgMjrI_0024Z: false, ((OGLTexture)_normalTexture).Name, 0u, _0023_003Dz6mcnErFZlQyn: false);
		_0023_003DzkT87yEmW_0024lCL0BCvbQ_003D_003D = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(oglRenderContext, (_halfRes ? size : size2).Width, (_halfRes ? size : size2).Height, _0023_003Dzhpb8QNg_003D: false, _0023_003DzaNkZ4Os_003D: false, _0023_003DzMnQWOgMjrI_0024Z: false, ((OGLTexture)_aoRawTexture).Name, 0u, _0023_003Dz6mcnErFZlQyn: false);
		_0023_003Dz5bcpK4sXCeJzysRXIA_003D_003D = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(oglRenderContext, (_halfRes ? size : size2).Width, (_halfRes ? size : size2).Height, _0023_003Dzhpb8QNg_003D: false, _0023_003DzaNkZ4Os_003D: false, _0023_003DzMnQWOgMjrI_0024Z: false, ((OGLTexture)_aoFilteredTexture).Name, 0u, _0023_003Dz6mcnErFZlQyn: false);
		return true;
	}

	protected override void FreeTargets()
	{
		base.FreeTargets();
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzUEv4S5BpAiMt = ((OglRenderContext)ParentRenderContext)._0023_003DzUEv4S5BpAiMt;
		_0023_003DzxGr7ogwPpwX_0024?._0023_003DzHF353qc_003D(ParentRenderContext);
		_0023_003DzxGr7ogwPpwX_0024 = null;
		_0023_003DzGgJwOnbEMfis?._0023_003DzHF353qc_003D(ParentRenderContext);
		_0023_003DzGgJwOnbEMfis = null;
		_0023_003DzkT87yEmW_0024lCL0BCvbQ_003D_003D?._0023_003DzHF353qc_003D(ParentRenderContext);
		_0023_003DzkT87yEmW_0024lCL0BCvbQ_003D_003D = null;
		_0023_003Dz5bcpK4sXCeJzysRXIA_003D_003D?._0023_003DzHF353qc_003D(ParentRenderContext);
		_0023_003Dz5bcpK4sXCeJzysRXIA_003D_003D = null;
		_0023_003DzUEv4S5BpAiMt?._0023_003Dzri_Jxos_003D(ParentRenderContext);
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
		_0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2 = new _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF(_halfRes);
		PreProcess_ViewZ = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.ViewZFromDepth);
		oglRenderContext.Shaders.Add(shaderType.ViewZFromDepth, PreProcess_ViewZ);
		PreProcess_Normal = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.NormalFromZ);
		oglRenderContext.Shaders.Add(shaderType.NormalFromZ, PreProcess_Normal);
		ComputeAO = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.ComputeSsao);
		oglRenderContext.Shaders.Add(shaderType.ComputeSsao, ComputeAO);
		BilateralFilterHor = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.BilateralHor);
		oglRenderContext.Shaders.Add(shaderType.BilateralHor, BilateralFilterHor);
		BilateralFilterVert = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.BilateralVert);
		oglRenderContext.Shaders.Add(shaderType.BilateralVert, BilateralFilterVert);
		return (byte)(1u & (PreProcess_ViewZ.Compile(oglRenderContext) ? 1u : 0u) & (PreProcess_Normal.Compile(oglRenderContext) ? 1u : 0u) & (ComputeAO.Compile(oglRenderContext) ? 1u : 0u) & (BilateralFilterHor.Compile(oglRenderContext) ? 1u : 0u) & (BilateralFilterVert.Compile(oglRenderContext) ? 1u : 0u)) != 0;
	}

	protected internal override void SetTarget(aoTargetType _0023_003DzGR08BY8_003D)
	{
		OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2 = null;
		oglRenderContext._0023_003DzQXov33mauSKJ(_0023_003DzGR08BY8_003D switch
		{
			aoTargetType.viewPos => _0023_003DzxGr7ogwPpwX_0024, 
			aoTargetType.viewNrm => _0023_003DzGgJwOnbEMfis, 
			aoTargetType.rawAo => _0023_003DzkT87yEmW_0024lCL0BCvbQ_003D_003D, 
			aoTargetType.filteredAo => _0023_003Dz5bcpK4sXCeJzysRXIA_003D_003D, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601797)), 
		});
	}

	protected override void GenMipMapsForPositions()
	{
		gl.BindTexture(3553, ((OGLTexture)_viewZTexture).Name);
		gl.GenerateMipmapEXT(3553);
		gl.BindTexture(3553, 0u);
	}
}
