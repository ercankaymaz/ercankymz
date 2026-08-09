using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using devDept.Diagnostic;
using devDept.Graphics;

internal sealed class _0023_003Dzdq3hE64XQd2A6GDydy6o0X11tgvwcetkHs3ypHUTm1DNghjtvg_003D_003D : SmoothUICompositingBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003Dz3IqBNZaqx1gK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzHDBC1tj7WAflu_0024SEQGhofaFYE4c6DybLFyKJZUA_470d _0023_003Dz1npm8I9s15gK;

	protected override bool InitTargets(Size _0023_003DzM_Gy4Ls_003D)
	{
		OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
		if (!oglRenderContext.HasFBMultisample())
		{
			return false;
		}
		int num = Math.Min(Enum.GetValues(typeof(antialiasingSamplesNumberType)).Cast<int>().Max(), oglRenderContext._0023_003Dzjdg_0024NvbNJYWQ());
		if (num < 2)
		{
			return false;
		}
		_resolveTex?.Dispose();
		_resolveTex = new OGLTexture(ParentRenderContext, (uint)_0023_003DzM_Gy4Ls_003D.Width, (uint)_0023_003DzM_Gy4Ls_003D.Height, depthTexture: false, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest);
		_0023_003Dz3IqBNZaqx1gK?._0023_003DzHF353qc_003D(oglRenderContext);
		_0023_003Dz1npm8I9s15gK?._0023_003DzHF353qc_003D(oglRenderContext);
		_0023_003Dz3IqBNZaqx1gK = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(oglRenderContext, _0023_003DzM_Gy4Ls_003D.Width, _0023_003DzM_Gy4Ls_003D.Height, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: false, _0023_003DzMnQWOgMjrI_0024Z: false, ((OGLTexture)_resolveTex).Name, 0u);
		int num2 = num;
		for (num2 = num; num2 >= 2; num2 /= 2)
		{
			_0023_003Dz1npm8I9s15gK = new _0023_003DzHDBC1tj7WAflu_0024SEQGhofaFYE4c6DybLFyKJZUA_470d(oglRenderContext, _0023_003DzM_Gy4Ls_003D.Width, _0023_003DzM_Gy4Ls_003D.Height, num2);
			if (oglRenderContext.IsGraphicsError())
			{
				_0023_003Dz1npm8I9s15gK._0023_003DzHF353qc_003D(oglRenderContext);
			}
			if (_0023_003Dz1npm8I9s15gK._0023_003Dz0hLnOJ4_003D() == 36053)
			{
				break;
			}
		}
		bool flag = _0023_003Dz1npm8I9s15gK._0023_003Dz0hLnOJ4_003D() == 36053;
		Logger.Instance.Trace(oglRenderContext.ControlData.InstanceId, GetType().ToString().Split('.').LastOrDefault() + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609481) + (flag ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609527) : _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609509)) + (flag ? string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609289), num2) : string.Empty));
		return flag;
	}

	protected override void FreeTargets()
	{
		_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzUEv4S5BpAiMt = ((OglRenderContext)ParentRenderContext)._0023_003DzUEv4S5BpAiMt;
		_0023_003Dz1npm8I9s15gK?._0023_003DzHF353qc_003D(ParentRenderContext);
		_0023_003Dz3IqBNZaqx1gK?._0023_003DzHF353qc_003D(ParentRenderContext);
		_0023_003DzUEv4S5BpAiMt?._0023_003Dzri_Jxos_003D(ParentRenderContext);
		base.FreeTargets();
	}

	protected override bool InitShaders()
	{
		return true;
	}

	protected internal override void Clear()
	{
		if (_0023_003Dz1npm8I9s15gK != null)
		{
			OglRenderContext oglRenderContext = (OglRenderContext)ParentRenderContext;
			oglRenderContext._0023_003DzQXov33mauSKJ(_0023_003Dz1npm8I9s15gK);
			oglRenderContext.ClearColor(SmoothUICompositingBase.ClearColor);
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

	protected override void ResolveMSTexture()
	{
		_0023_003Dz3IqBNZaqx1gK._0023_003DzDb1rZVnaLv5y9ik3qA_003D_003D((OglRenderContext)ParentRenderContext, 16384, _0023_003Dz1npm8I9s15gK);
	}

	protected internal override void SetMSTarget()
	{
		base.SetMSTarget();
		((OglRenderContext)ParentRenderContext)._0023_003DzQXov33mauSKJ(_0023_003Dz1npm8I9s15gK);
	}
}
