using System.Diagnostics;
using OpenGL;
using devDept.Graphics;

internal class _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn : FrameBufferObjectBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzu9VCct9ALLUd35bBLg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected uint _0023_003DzOY6IA54_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected uint _0023_003DzWYqcuO4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected uint _0023_003Dzo_GnjiP0BLMg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected int _0023_003DzEmzoudE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected int _0023_003DzmJJBgEs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected int _0023_003DzmIquRfQ_003D;

	protected _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D)
	{
		_0023_003DzmJJBgEs_003D = _0023_003Dz7PIPnGI_003D;
		_0023_003DzmIquRfQ_003D = _0023_003DzkQAiKLA_003D;
	}

	public _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, bool _0023_003Dzhpb8QNg_003D, bool _0023_003DzaNkZ4Os_003D, bool _0023_003DzMnQWOgMjrI_0024Z)
		: this(_0023_003DzmNZD0Zs_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, _0023_003Dzhpb8QNg_003D, _0023_003DzaNkZ4Os_003D, _0023_003DzMnQWOgMjrI_0024Z, 0u, 0u)
	{
	}

	public _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, bool _0023_003Dzhpb8QNg_003D, bool _0023_003DzaNkZ4Os_003D, bool _0023_003DzMnQWOgMjrI_0024Z, uint _0023_003DzSKB7gPmCGwX8, uint _0023_003DzIgi4d_002476Dtqu)
		: this(_0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D)
	{
		_0023_003DzrloDkpQ_003D(_0023_003DzmNZD0Zs_003D, _0023_003Dzhpb8QNg_003D, _0023_003DzaNkZ4Os_003D, _0023_003DzMnQWOgMjrI_0024Z, _0023_003DzSKB7gPmCGwX8, _0023_003DzIgi4d_002476Dtqu, _0023_003DzM_TSCpNmLcyo: false);
	}

	public _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, bool _0023_003Dzhpb8QNg_003D, bool _0023_003DzaNkZ4Os_003D, bool _0023_003DzMnQWOgMjrI_0024Z, uint _0023_003DzSKB7gPmCGwX8, uint _0023_003DzIgi4d_002476Dtqu, bool _0023_003Dz6mcnErFZlQyn)
		: this(_0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D)
	{
		_0023_003DzrloDkpQ_003D(_0023_003DzmNZD0Zs_003D, _0023_003Dzhpb8QNg_003D, _0023_003DzaNkZ4Os_003D, _0023_003DzMnQWOgMjrI_0024Z, _0023_003DzSKB7gPmCGwX8, _0023_003DzIgi4d_002476Dtqu, _0023_003Dz6mcnErFZlQyn);
	}

	public void _0023_003Dzk8EBESw_003D(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzu9VCct9ALLUd35bBLg_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	public bool _0023_003DzhbVYZm0_003D()
	{
		return _0023_003Dzu9VCct9ALLUd35bBLg_003D_003D;
	}

	public int _0023_003Dz0hLnOJ4_003D()
	{
		return _0023_003DzEmzoudE_003D;
	}

	public int _0023_003Dzd3wwRAyZ0u7z()
	{
		return _0023_003DzmJJBgEs_003D;
	}

	public int _0023_003DzJndH3qzbRKM7()
	{
		return _0023_003DzmIquRfQ_003D;
	}

	public void _0023_003DzHF353qc_003D(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		Clear(_0023_003DzmNZD0Zs_003D);
	}

	public override void Clear(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003DzluJsUwU_003D(_0023_003DzmNZD0Zs_003D);
		gl.DeleteRenderbuffersEXT(_0023_003DzWYqcuO4_003D);
		gl.DeleteRenderbuffersEXT(_0023_003Dzo_GnjiP0BLMg);
		gl.DeleteFramebuffersEXT(_0023_003DzOY6IA54_003D);
		_0023_003DzOY6IA54_003D = (_0023_003DzWYqcuO4_003D = (_0023_003Dzo_GnjiP0BLMg = 0u));
	}

	private int _0023_003DzrloDkpQ_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, bool _0023_003Dzhpb8QNg_003D, bool _0023_003DzaNkZ4Os_003D, bool _0023_003DzMnQWOgMjrI_0024Z, uint _0023_003DzSKB7gPmCGwX8, uint _0023_003DzIgi4d_002476Dtqu, bool _0023_003DzM_TSCpNmLcyo)
	{
		_0023_003DzOY6IA54_003D = gl.GenFramebuffersEXT();
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzUEv4S5BpAiMt = ((OglRenderContext)_0023_003DzmNZD0Zs_003D)._0023_003DzUEv4S5BpAiMt;
		_0023_003Dzri_Jxos_003D(_0023_003DzmNZD0Zs_003D);
		if (_0023_003Dzhpb8QNg_003D && _0023_003DzSKB7gPmCGwX8 == 0)
		{
			_0023_003DzWYqcuO4_003D = gl.GenRenderbuffersEXT();
			gl.BindRenderbufferEXT(36161, _0023_003DzWYqcuO4_003D);
			gl.RenderbufferStorageEXT(36161, 6408, _0023_003Dzd3wwRAyZ0u7z(), _0023_003DzJndH3qzbRKM7());
			gl.FramebufferRenderbufferEXT(36160, 36064, 36161, _0023_003DzWYqcuO4_003D);
			gl.BindRenderbufferEXT(36161, 0u);
		}
		else
		{
			_0023_003DzWYqcuO4_003D = 0u;
		}
		if (_0023_003DzaNkZ4Os_003D && _0023_003DzIgi4d_002476Dtqu == 0)
		{
			_0023_003Dzo_GnjiP0BLMg = gl.GenRenderbuffersEXT();
			gl.BindRenderbufferEXT(36161, _0023_003Dzo_GnjiP0BLMg);
			if (_0023_003DzMnQWOgMjrI_0024Z && ((OglRenderContext)_0023_003DzmNZD0Zs_003D).gl.EXT_packed_depth_stencil)
			{
				gl.RenderbufferStorageEXT(36161, 34041, _0023_003Dzd3wwRAyZ0u7z(), _0023_003DzJndH3qzbRKM7());
				gl.FramebufferRenderbufferEXT(36160, 36096, 36161, _0023_003Dzo_GnjiP0BLMg);
				gl.FramebufferRenderbufferEXT(36160, 36128, 36161, _0023_003Dzo_GnjiP0BLMg);
			}
			else
			{
				gl.RenderbufferStorageEXT(36161, 6402, _0023_003Dzd3wwRAyZ0u7z(), _0023_003DzJndH3qzbRKM7());
				gl.FramebufferRenderbufferEXT(36160, 36096, 36161, _0023_003Dzo_GnjiP0BLMg);
			}
			gl.BindRenderbufferEXT(36161, 0u);
		}
		else
		{
			_0023_003Dzo_GnjiP0BLMg = 0u;
		}
		if (_0023_003DzSKB7gPmCGwX8 != 0)
		{
			gl.FramebufferTexture2DEXT(36160, 36064, 3553, _0023_003DzSKB7gPmCGwX8, 0);
		}
		if (_0023_003DzIgi4d_002476Dtqu != 0)
		{
			gl.FramebufferTexture2DEXT(36160, 36096, 3553, _0023_003DzIgi4d_002476Dtqu, 0);
			if (_0023_003DzM_TSCpNmLcyo)
			{
				gl.FramebufferTexture2DEXT(36160, 36128, 3553, _0023_003DzIgi4d_002476Dtqu, 0);
			}
			if (!_0023_003Dzhpb8QNg_003D && _0023_003DzSKB7gPmCGwX8 == 0)
			{
				gl.DrawBuffer(0);
				gl.ReadBuffer(0);
			}
		}
		_0023_003DzEmzoudE_003D = gl.CheckFramebufferStatusEXT(36160);
		_0023_003Dz59gJCnTN_Ki1(_0023_003Dz0hLnOJ4_003D());
		if (_0023_003DzUEv4S5BpAiMt != null)
		{
			_0023_003DzUEv4S5BpAiMt._0023_003Dzri_Jxos_003D(_0023_003DzmNZD0Zs_003D);
		}
		else
		{
			_0023_003DzluJsUwU_003D(_0023_003DzmNZD0Zs_003D);
		}
		return _0023_003Dz0hLnOJ4_003D();
	}

	public void _0023_003DzsMSlUQk_003D(int _0023_003DzGR08BY8_003D)
	{
		gl.BindFramebufferEXT(_0023_003DzGR08BY8_003D, _0023_003DzOY6IA54_003D);
	}

	public void _0023_003Dzk_MAMzJfw3uA(int _0023_003DzGR08BY8_003D)
	{
		gl.BindFramebufferEXT(_0023_003DzGR08BY8_003D, 0u);
	}

	internal static bool _0023_003Dz59gJCnTN_Ki1(int _0023_003DzySLsBjg_003D)
	{
		string value = string.Empty;
		switch (_0023_003DzySLsBjg_003D)
		{
		case 36054:
			value = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609196);
			break;
		case 36055:
			value = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609218);
			break;
		case 36057:
			value = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609264);
			break;
		case 36058:
			value = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609062);
			break;
		case 36059:
			value = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609119);
			break;
		case 36060:
			value = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609140);
			break;
		case 36061:
			value = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609449);
			break;
		}
		if (!string.IsNullOrEmpty(value))
		{
			RenderContextBase.GraphicalIssues.AppendLine(value);
		}
		return _0023_003DzySLsBjg_003D == 36053;
	}

	public void _0023_003Dzri_Jxos_003D(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003Dzk8EBESw_003D(_0023_003DzsLHxXyo_003D: true);
		_0023_003Dzri_Jxos_003D(_0023_003DzmNZD0Zs_003D, _0023_003DzOY6IA54_003D);
	}

	private void _0023_003Dzri_Jxos_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, uint _0023_003DzOY6IA54_003D)
	{
		((OglRenderContext)_0023_003DzmNZD0Zs_003D)._0023_003DzUEv4S5BpAiMt = this;
		gl.BindFramebufferEXT(36160, _0023_003DzOY6IA54_003D);
	}

	public static void _0023_003DzluJsUwU_003D(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		((OglRenderContext)_0023_003DzmNZD0Zs_003D)._0023_003DzUEv4S5BpAiMt = null;
		gl.BindFramebufferEXT(36160, 0u);
	}

	public void _0023_003DzuThhmMw_2WYe_HEAnQ_003D_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003DzVRNmFaMzLJ7E, _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003Dzh2PCgGI_003D)
	{
		_0023_003DzuThhmMw_2WYe_HEAnQ_003D_003D(_0023_003DzmNZD0Zs_003D, 0, 0, _0023_003Dzd3wwRAyZ0u7z(), _0023_003DzJndH3qzbRKM7(), 256, _0023_003Dzh2PCgGI_003D);
	}

	public void _0023_003DzuThhmMw_2WYe_HEAnQ_003D_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003DzGuW5l4E_003D, int _0023_003DzVDBzBJQ_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, int _0023_003DzVRNmFaMzLJ7E, _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003Dzh2PCgGI_003D)
	{
		_0023_003DzmNZD0Zs_003D.PushCurrentFBO();
		_0023_003DzsMSlUQk_003D(36008);
		if (_0023_003Dzh2PCgGI_003D != null)
		{
			_0023_003Dzh2PCgGI_003D._0023_003DzsMSlUQk_003D(36009);
		}
		else
		{
			gl.BindFramebufferEXT(36009, 0u);
		}
		_0023_003DzTjbQadAMQEq7(_0023_003DzmNZD0Zs_003D, _0023_003DzGuW5l4E_003D, _0023_003DzVDBzBJQ_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, _0023_003DzVRNmFaMzLJ7E);
		_0023_003DzmNZD0Zs_003D.RestoreFBO();
	}

	public void _0023_003DzDb1rZVnaLv5y9ik3qA_003D_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003DzVRNmFaMzLJ7E, _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003Dzy3yP9Nk_003D)
	{
		_0023_003DzDb1rZVnaLv5y9ik3qA_003D_003D(_0023_003DzmNZD0Zs_003D, 0, 0, _0023_003Dzd3wwRAyZ0u7z(), _0023_003DzJndH3qzbRKM7(), _0023_003DzVRNmFaMzLJ7E, _0023_003Dzy3yP9Nk_003D);
	}

	public void _0023_003DzDb1rZVnaLv5y9ik3qA_003D_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003DzGuW5l4E_003D, int _0023_003DzVDBzBJQ_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, int _0023_003DzVRNmFaMzLJ7E, _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003Dzy3yP9Nk_003D)
	{
		_0023_003DzmNZD0Zs_003D.PushCurrentFBO();
		_0023_003DzsMSlUQk_003D(36009);
		if (_0023_003Dzy3yP9Nk_003D != null)
		{
			_0023_003Dzy3yP9Nk_003D._0023_003DzsMSlUQk_003D(36008);
		}
		else
		{
			gl.BindFramebufferEXT(36008, 0u);
		}
		_0023_003DzTjbQadAMQEq7(_0023_003DzmNZD0Zs_003D, _0023_003DzGuW5l4E_003D, _0023_003DzVDBzBJQ_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, _0023_003DzVRNmFaMzLJ7E);
		_0023_003DzmNZD0Zs_003D.RestoreFBO();
	}

	private static void _0023_003DzTjbQadAMQEq7(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003DzGuW5l4E_003D, int _0023_003DzVDBzBJQ_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, int _0023_003DzVRNmFaMzLJ7E)
	{
		gl.BlitFramebufferEXT(_0023_003DzGuW5l4E_003D, _0023_003DzVDBzBJQ_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, _0023_003DzGuW5l4E_003D, _0023_003DzVDBzBJQ_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, _0023_003DzVRNmFaMzLJ7E, 9728);
		gl.BindFramebufferEXT(36008, 0u);
		gl.BindFramebufferEXT(36009, 0u);
	}
}
