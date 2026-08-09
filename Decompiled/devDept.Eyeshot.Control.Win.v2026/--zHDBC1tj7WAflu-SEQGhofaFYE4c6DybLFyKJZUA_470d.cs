using OpenGL;
using devDept.Graphics;

internal sealed class _0023_003DzHDBC1tj7WAflu_0024SEQGhofaFYE4c6DybLFyKJZUA_470d : _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn
{
	public _0023_003DzHDBC1tj7WAflu_0024SEQGhofaFYE4c6DybLFyKJZUA_470d(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, int _0023_003Dzeujkxyxl7VBg)
		: base(_0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D)
	{
		_0023_003DzrloDkpQ_003D(_0023_003DzmNZD0Zs_003D, _0023_003Dzeujkxyxl7VBg);
	}

	private int _0023_003DzrloDkpQ_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, int _0023_003Dzeujkxyxl7VBg)
	{
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzUEv4S5BpAiMt = ((OglRenderContext)_0023_003DzmNZD0Zs_003D)._0023_003DzUEv4S5BpAiMt;
		_0023_003DzWYqcuO4_003D = gl.GenRenderbuffersEXT();
		gl.BindRenderbufferEXT(36161, _0023_003DzWYqcuO4_003D);
		gl.RenderbufferStorageMultisampleEXT(36161, _0023_003Dzeujkxyxl7VBg, 6408, _0023_003Dzd3wwRAyZ0u7z(), _0023_003DzJndH3qzbRKM7());
		_0023_003Dzo_GnjiP0BLMg = gl.GenRenderbuffersEXT();
		gl.BindRenderbufferEXT(36161, _0023_003Dzo_GnjiP0BLMg);
		bool flag = false;
		if (((OglRenderContext)_0023_003DzmNZD0Zs_003D).gl.EXT_packed_depth_stencil)
		{
			flag = true;
			gl.RenderbufferStorageMultisampleEXT(36161, _0023_003Dzeujkxyxl7VBg, 34041, _0023_003Dzd3wwRAyZ0u7z(), _0023_003DzJndH3qzbRKM7());
		}
		else
		{
			gl.RenderbufferStorageMultisampleEXT(36161, _0023_003Dzeujkxyxl7VBg, 6402, _0023_003Dzd3wwRAyZ0u7z(), _0023_003DzJndH3qzbRKM7());
		}
		_0023_003DzOY6IA54_003D = gl.GenFramebuffersEXT();
		_0023_003Dzri_Jxos_003D(_0023_003DzmNZD0Zs_003D);
		gl.FramebufferRenderbufferEXT(36160, 36064, 36161, _0023_003DzWYqcuO4_003D);
		gl.FramebufferRenderbufferEXT(36160, 36096, 36161, _0023_003Dzo_GnjiP0BLMg);
		if (flag)
		{
			gl.FramebufferRenderbufferEXT(36160, 36128, 36161, _0023_003Dzo_GnjiP0BLMg);
		}
		_0023_003DzEmzoudE_003D = gl.CheckFramebufferStatusEXT(36160);
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003Dz59gJCnTN_Ki1(_0023_003Dz0hLnOJ4_003D());
		if (_0023_003DzUEv4S5BpAiMt != null)
		{
			_0023_003DzUEv4S5BpAiMt._0023_003Dzri_Jxos_003D(_0023_003DzmNZD0Zs_003D);
		}
		else
		{
			_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003DzluJsUwU_003D(_0023_003DzmNZD0Zs_003D);
		}
		return _0023_003Dz0hLnOJ4_003D();
	}
}
