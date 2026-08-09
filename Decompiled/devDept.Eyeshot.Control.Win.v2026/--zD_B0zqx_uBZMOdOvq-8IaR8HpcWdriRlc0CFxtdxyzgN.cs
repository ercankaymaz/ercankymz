using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using devDept.Graphics;

internal sealed class _0023_003DzD_B0zqx_uBZMOdOvq_00248IaR8HpcWdriRlc0CFxtdxyzgN : ProgDrawCompositingBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<progDrawFrameBuffer, _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn> _0023_003DzajhPw6wSUX_7;

	public override bool Init(RenderContextBase _0023_003DzSi_RY6HdcYCZ)
	{
		if (_0023_003DzSi_RY6HdcYCZ is OglRenderContext)
		{
			return base.Init(_0023_003DzSi_RY6HdcYCZ);
		}
		return false;
	}

	public override void DisposeTargets()
	{
		base.DisposeTargets();
		foreach (KeyValuePair<progDrawFrameBuffer, _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn> item in _0023_003DzajhPw6wSUX_7)
		{
			item.Value._0023_003DzHF353qc_003D((OglRenderContext)ParentRenderContext);
		}
		_0023_003DzajhPw6wSUX_7 = null;
	}

	protected override bool InitTargets()
	{
		Size controlSize = ParentRenderContext.ControlData.ControlSize;
		textures = new Dictionary<progDrawFrameBuffer, TextureBase[]>(4);
		textures.Add(progDrawFrameBuffer.ActivePolygons, new TextureBase[2]
		{
			new OGLTexture(ParentRenderContext, (uint)controlSize.Width, (uint)controlSize.Height, depthTexture: false, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest),
			new OGLTexture(ParentRenderContext, (uint)controlSize.Width, (uint)controlSize.Height, _0023_003DzIgi4d_002476Dtqu: true, _0023_003Dz6mcnErFZlQyn: true, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest)
		});
		textures.Add(progDrawFrameBuffer.ActiveWires, new TextureBase[2]
		{
			new OGLTexture(ParentRenderContext, (uint)controlSize.Width, (uint)controlSize.Height, depthTexture: false, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest),
			new OGLTexture(ParentRenderContext, (uint)controlSize.Width, (uint)controlSize.Height, _0023_003DzIgi4d_002476Dtqu: true, _0023_003Dz6mcnErFZlQyn: true, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest)
		});
		textures.Add(progDrawFrameBuffer.FrozenPolygons, new TextureBase[2]
		{
			new OGLTexture(ParentRenderContext, (uint)controlSize.Width, (uint)controlSize.Height, depthTexture: false, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest),
			new OGLTexture(ParentRenderContext, (uint)controlSize.Width, (uint)controlSize.Height, _0023_003DzIgi4d_002476Dtqu: true, _0023_003Dz6mcnErFZlQyn: true, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest)
		});
		textures.Add(progDrawFrameBuffer.FrozenWires, new TextureBase[2]
		{
			new OGLTexture(ParentRenderContext, (uint)controlSize.Width, (uint)controlSize.Height, depthTexture: false, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest),
			new OGLTexture(ParentRenderContext, (uint)controlSize.Width, (uint)controlSize.Height, _0023_003DzIgi4d_002476Dtqu: true, _0023_003Dz6mcnErFZlQyn: true, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest)
		});
		_0023_003DzajhPw6wSUX_7 = new Dictionary<progDrawFrameBuffer, _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn>(4);
		_0023_003DzajhPw6wSUX_7.Add(progDrawFrameBuffer.ActivePolygons, new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(ParentRenderContext, controlSize.Width, controlSize.Height, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: true, _0023_003DzMnQWOgMjrI_0024Z: true, ((OGLTexture)textures[progDrawFrameBuffer.ActivePolygons][0]).Name, ((OGLTexture)textures[progDrawFrameBuffer.ActivePolygons][1]).Name, _0023_003Dz6mcnErFZlQyn: true));
		int num = 1 & (_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003Dz59gJCnTN_Ki1(_0023_003DzajhPw6wSUX_7[progDrawFrameBuffer.ActivePolygons]._0023_003Dz0hLnOJ4_003D()) ? 1 : 0);
		_0023_003DzajhPw6wSUX_7.Add(progDrawFrameBuffer.ActiveWires, new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(ParentRenderContext, controlSize.Width, controlSize.Height, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: true, _0023_003DzMnQWOgMjrI_0024Z: true, ((OGLTexture)textures[progDrawFrameBuffer.ActiveWires][0]).Name, ((OGLTexture)textures[progDrawFrameBuffer.ActiveWires][1]).Name, _0023_003Dz6mcnErFZlQyn: true));
		int num2 = num & (_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003Dz59gJCnTN_Ki1(_0023_003DzajhPw6wSUX_7[progDrawFrameBuffer.ActiveWires]._0023_003Dz0hLnOJ4_003D()) ? 1 : 0);
		_0023_003DzajhPw6wSUX_7.Add(progDrawFrameBuffer.FrozenPolygons, new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(ParentRenderContext, controlSize.Width, controlSize.Height, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: true, _0023_003DzMnQWOgMjrI_0024Z: true, ((OGLTexture)textures[progDrawFrameBuffer.FrozenPolygons][0]).Name, ((OGLTexture)textures[progDrawFrameBuffer.FrozenPolygons][1]).Name, _0023_003Dz6mcnErFZlQyn: true));
		int num3 = num2 & (_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003Dz59gJCnTN_Ki1(_0023_003DzajhPw6wSUX_7[progDrawFrameBuffer.FrozenPolygons]._0023_003Dz0hLnOJ4_003D()) ? 1 : 0);
		_0023_003DzajhPw6wSUX_7.Add(progDrawFrameBuffer.FrozenWires, new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(ParentRenderContext, controlSize.Width, controlSize.Height, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: true, _0023_003DzMnQWOgMjrI_0024Z: true, ((OGLTexture)textures[progDrawFrameBuffer.FrozenWires][0]).Name, ((OGLTexture)textures[progDrawFrameBuffer.FrozenWires][1]).Name, _0023_003Dz6mcnErFZlQyn: true));
		int num4 = num3 & (_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003Dz59gJCnTN_Ki1(_0023_003DzajhPw6wSUX_7[progDrawFrameBuffer.FrozenWires]._0023_003Dz0hLnOJ4_003D()) ? 1 : 0);
		if (num4 == 0)
		{
			DisposeTargets();
		}
		return (byte)num4 != 0;
	}

	protected override void ClearBufferColor(progDrawFrameBuffer _0023_003Dzede4j5s_003D, Color _0023_003Dz8U9WRUs_003D)
	{
		if (_0023_003DzajhPw6wSUX_7 != null)
		{
			OglRenderContext obj = (OglRenderContext)ParentRenderContext;
			BindTarget(_0023_003Dzede4j5s_003D);
			obj.ClearColor(_0023_003Dz8U9WRUs_003D);
			RestoreBuffers();
		}
	}

	protected override void ClearBufferDepth(progDrawFrameBuffer _0023_003Dzede4j5s_003D)
	{
		if (_0023_003DzajhPw6wSUX_7 != null)
		{
			OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
			BindTarget(_0023_003Dzede4j5s_003D);
			int depthWriteEnableMask = GetDepthWriteEnableMask();
			bool num = ((int)oglRenderContext.CurrentDepthStencilState & depthWriteEnableMask) > 0;
			if (!num)
			{
				oglRenderContext.PushDepthStencilState();
				oglRenderContext.SetState(depthStencilStateType.DepthTestAlways);
			}
			oglRenderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: true, 0);
			if (!num)
			{
				oglRenderContext.PopDepthStencilState();
			}
			RestoreBuffers();
		}
	}

	public override void ClearAllBuffers(Color _0023_003Dz8U9WRUs_003D, bool _0023_003Dzhpb8QNg_003D = true, bool _0023_003DzaNkZ4Os_003D = true)
	{
		if (_0023_003DzajhPw6wSUX_7 != null)
		{
			base.ClearAllBuffers(_0023_003Dz8U9WRUs_003D, _0023_003Dzhpb8QNg_003D, _0023_003DzaNkZ4Os_003D);
		}
	}

	public override void CopyBackBufferTo(progDrawFrameBuffer _0023_003Dzh2PCgGI_003D, bool _0023_003Dzhpb8QNg_003D, bool _0023_003DzaNkZ4Os_003D)
	{
		if (_0023_003DzajhPw6wSUX_7 != null && _0023_003DzajhPw6wSUX_7.TryGetValue(_0023_003Dzh2PCgGI_003D, out var value))
		{
			OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
			int _0023_003DzVRNmFaMzLJ7E = (_0023_003Dzhpb8QNg_003D ? 16384 : 0) | (_0023_003DzaNkZ4Os_003D ? 1280 : 0);
			value._0023_003DzDb1rZVnaLv5y9ik3qA_003D_003D(oglRenderContext, _0023_003DzVRNmFaMzLJ7E, oglRenderContext._0023_003DzUEv4S5BpAiMt);
		}
	}

	public override void CopyToBackBuffer(progDrawFrameBuffer _0023_003Dzy78_0024Z10_003D, bool _0023_003Dzhpb8QNg_003D, bool _0023_003DzaNkZ4Os_003D)
	{
		if (_0023_003DzajhPw6wSUX_7 != null && _0023_003DzajhPw6wSUX_7.TryGetValue(_0023_003Dzy78_0024Z10_003D, out var value))
		{
			OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
			int _0023_003DzVRNmFaMzLJ7E = (_0023_003Dzhpb8QNg_003D ? 16384 : 0) | (_0023_003DzaNkZ4Os_003D ? 1280 : 0);
			value._0023_003DzuThhmMw_2WYe_HEAnQ_003D_003D(oglRenderContext, _0023_003DzVRNmFaMzLJ7E, oglRenderContext._0023_003DzUEv4S5BpAiMt);
		}
	}

	protected override bool InitShaders()
	{
		return true;
	}

	protected override void EnableShaderTechnique(compositingOperation _0023_003Dzn0pbsgKlei6lizfmx_0024sO_Ak_003D)
	{
		base.EnableShaderTechnique(_0023_003Dzn0pbsgKlei6lizfmx_0024sO_Ak_003D);
		((OglRenderContext)ParentRenderContext).CurrentShaderTechnique.SetParameters(new ShaderParameters(ParentRenderContext));
	}

	public override void BindTarget(progDrawFrameBuffer _0023_003DzOY6IA54_003D)
	{
		((OglRenderContext)ParentRenderContext)._0023_003DzQXov33mauSKJ(_0023_003DzajhPw6wSUX_7[_0023_003DzOY6IA54_003D]);
	}
}
