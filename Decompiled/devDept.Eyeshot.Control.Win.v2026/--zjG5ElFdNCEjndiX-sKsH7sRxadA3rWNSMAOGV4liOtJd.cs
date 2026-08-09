using System.Diagnostics;
using System.Drawing;
using devDept.Geometry;
using devDept.Graphics;

internal sealed class _0023_003DzjG5ElFdNCEjndiX_0024sKsH7sRxadA3rWNSMAOGV4liOtJd : HaloSelectionCompositingBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzAYEBabIbN_0024oA;

	protected override bool InitTargets(Size _0023_003DzM_Gy4Ls_003D)
	{
		if (!((OglRenderContext)ParentRenderContext).HasFBO())
		{
			return false;
		}
		_texColor = new OGLTexture(ParentRenderContext, (uint)_0023_003DzM_Gy4Ls_003D.Width, (uint)_0023_003DzM_Gy4Ls_003D.Height, depthTexture: false, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest);
		_texDepth = new OGLTexture(ParentRenderContext, (uint)_0023_003DzM_Gy4Ls_003D.Width, (uint)_0023_003DzM_Gy4Ls_003D.Height, _0023_003DzIgi4d_002476Dtqu: true, _0023_003Dz6mcnErFZlQyn: true, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest);
		_0023_003DzAYEBabIbN_0024oA = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(ParentRenderContext, _0023_003DzM_Gy4Ls_003D.Width, _0023_003DzM_Gy4Ls_003D.Height, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: true, _0023_003DzMnQWOgMjrI_0024Z: true, ((OGLTexture)_texColor).Name, ((OGLTexture)_texDepth).Name, _0023_003Dz6mcnErFZlQyn: true);
		int num = 1 & (_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003Dz59gJCnTN_Ki1(_0023_003DzAYEBabIbN_0024oA._0023_003Dz0hLnOJ4_003D()) ? 1 : 0);
		if (num == 0)
		{
			FreeTargets();
		}
		base.InitTargets(_0023_003DzM_Gy4Ls_003D);
		return (byte)num != 0;
	}

	protected internal override void Update(Color _0023_003Dzqdeh6JlPW6Zl, Color _0023_003DzEhcHSlRoMnjZ, Color _0023_003Dzlp1TbciyP4m7, Color _0023_003DzU2hgkz1Dd9yM, int _0023_003DzXZNOUZLbVW41x33WzIBpC_0024Q_003D, int _0023_003DzUTEzux0UihD_0024gb_34A_003D_003D)
	{
		base.Update(_0023_003Dzqdeh6JlPW6Zl, _0023_003DzEhcHSlRoMnjZ, _0023_003Dzlp1TbciyP4m7, _0023_003DzU2hgkz1Dd9yM, _0023_003DzXZNOUZLbVW41x33WzIBpC_0024Q_003D, _0023_003DzUTEzux0UihD_0024gb_34A_003D_003D);
		OutlineShaderParameters parameters = new OutlineShaderParameters(ParentRenderContext, new Vector2D(_texColor.Size.Width, _texColor.Size.Height), _0023_003Dzqdeh6JlPW6Zl, _0023_003DzEhcHSlRoMnjZ, _0023_003Dzlp1TbciyP4m7, _0023_003DzU2hgkz1Dd9yM, HaloWidthPolygons, HaloWidthWires);
		Shader.SetParameters(parameters);
	}

	protected override bool InitShaders()
	{
		if (!(ParentRenderContext is OglRenderContext))
		{
			return false;
		}
		if (ParentRenderContext.RendererVersion.Major < 3)
		{
			return false;
		}
		if (((OglRenderContext)ParentRenderContext).ShadingLanguageVersion.Major <= 0)
		{
			return false;
		}
		if (ParentRenderContext.Shaders.ContainsKey(shaderType.Outline))
		{
			Shader = ParentRenderContext.Shaders[shaderType.Outline];
			return true;
		}
		_0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2 = new _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF();
		Shader = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Outline);
		((OglRenderContext)ParentRenderContext).Shaders.Add(shaderType.Outline, Shader);
		return Shader.Compile(ParentRenderContext);
	}

	protected override void FreeTargets()
	{
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzUEv4S5BpAiMt = ((OglRenderContext)ParentRenderContext)._0023_003DzUEv4S5BpAiMt;
		_0023_003DzAYEBabIbN_0024oA?._0023_003DzHF353qc_003D(ParentRenderContext);
		_0023_003DzUEv4S5BpAiMt?._0023_003Dzri_Jxos_003D(ParentRenderContext);
		base.FreeTargets();
	}

	protected override void ClearForInit()
	{
		if (_0023_003DzAYEBabIbN_0024oA != null)
		{
			OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
			oglRenderContext._0023_003DzQXov33mauSKJ(_0023_003DzAYEBabIbN_0024oA);
			oglRenderContext.ClearColor(HaloSelectionCompositingBase.ClearColor);
			int depthWriteEnableMask = GetDepthWriteEnableMask();
			bool num = ((int)oglRenderContext.CurrentDepthStencilState & depthWriteEnableMask) > 0;
			if (!num)
			{
				oglRenderContext.PushDepthStencilState();
				oglRenderContext.SetState(depthStencilStateType.DepthTestAlways);
			}
			oglRenderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
			if (!num)
			{
				oglRenderContext.PopDepthStencilState();
			}
			ResetTarget();
		}
	}

	protected internal override void SetTarget()
	{
		((OglRenderContext)ParentRenderContext)._0023_003DzQXov33mauSKJ(_0023_003DzAYEBabIbN_0024oA);
	}
}
