using System.Diagnostics;
using OpenGL;
using devDept.Graphics;

internal sealed class _0023_003Dz3XAtVbL8Q_0024fPexkeqipThta7RDPc : ShadowMapData
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal FrameBufferObjectBase _0023_003DzAYEBabIbN_0024oA;

	protected override double[] biasMatrix => new double[16]
	{
		0.5, 0.0, 0.0, 0.0, 0.0, 0.5, 0.0, 0.0, 0.0, 0.0,
		0.5, 0.0, 0.5, 0.5, 0.5, 1.0
	};

	protected internal override bool IsValidFBO()
	{
		return _0023_003DzAYEBabIbN_0024oA != null;
	}

	protected override bool UseFBO()
	{
		return _0023_003DzAYEBabIbN_0024oA != null;
	}

	protected override void ClearTextures(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		if (_0023_003DzAYEBabIbN_0024oA != null)
		{
			_0023_003DzAYEBabIbN_0024oA.Clear(_0023_003DzmNZD0Zs_003D);
			_0023_003DzAYEBabIbN_0024oA = null;
		}
		base.ClearTextures(_0023_003DzmNZD0Zs_003D);
	}

	public override void Disable(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003DzmNZD0Zs_003D.CloseTexture(TextureBase.textureUnitType.ShadowMap);
	}

	protected internal override bool InitFBO(RenderContextBase _0023_003DzoC62DbA_003D, int _0023_003DzF_0024p8gpsgTcK4, uint _0023_003Dz7PIPnGI_003D, uint _0023_003DzkQAiKLA_003D)
	{
		bool flag = base.InitFBO(_0023_003DzoC62DbA_003D, _0023_003DzF_0024p8gpsgTcK4, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D);
		if (flag)
		{
			_0023_003DzAYEBabIbN_0024oA = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(_0023_003DzoC62DbA_003D, (int)_0023_003Dz7PIPnGI_003D, (int)_0023_003DzkQAiKLA_003D, _0023_003Dzhpb8QNg_003D: false, _0023_003DzaNkZ4Os_003D: true, _0023_003DzMnQWOgMjrI_0024Z: false, 0u, ((OGLTexture)_texture[0]).Name);
			flag &= _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003Dz59gJCnTN_Ki1(((_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn)_0023_003DzAYEBabIbN_0024oA)._0023_003Dz0hLnOJ4_003D());
		}
		return flag;
	}

	protected override void ReadTexture(RenderContextBase _0023_003DzmNZD0Zs_003D, TextureBase _0023_003Dz_IfKSJY_003D, uint _0023_003Dz8GBMuoM_003D, uint _0023_003DzJU0R6e0_003D, uint _0023_003Dz67k_0024ZBFITSz8, uint _0023_003DzAFYRgLK1F6eH)
	{
		_0023_003DzmNZD0Zs_003D.SetTexture(_0023_003Dz_IfKSJY_003D);
		gl.CopyTexSubImage2D(3553, 0, (int)_0023_003Dz8GBMuoM_003D, (int)_0023_003DzJU0R6e0_003D, (int)_0023_003Dz8GBMuoM_003D, (int)_0023_003DzJU0R6e0_003D, (int)_0023_003Dz67k_0024ZBFITSz8, (int)_0023_003DzAFYRgLK1F6eH);
	}

	protected internal override void SetDepthFBO(RenderContextBase _0023_003DzoC62DbA_003D, TextureBase _0023_003Dz_IfKSJY_003D)
	{
		gl.FramebufferTexture2DEXT(36160, 36096, 3553, ((OGLTexture)_0023_003Dz_IfKSJY_003D).Name, 0);
	}

	protected internal override bool EnableFBO(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		OglRenderContext oglRenderContext = (OglRenderContext)_0023_003DzoC62DbA_003D;
		if (oglRenderContext._0023_003DzUEv4S5BpAiMt != null || _0023_003DzAYEBabIbN_0024oA != null)
		{
			oglRenderContext._0023_003DzQXov33mauSKJ(_0023_003DzAYEBabIbN_0024oA);
			return true;
		}
		return false;
	}
}
