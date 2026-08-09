using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[Serializable]
public abstract class BarBase : UserInterfaceBase
{
	[CompilerGenerated]
	private bool _003CTemporaryDisableButtons_003Ek__BackingField;

	internal Workspace._0023_003DzVFaPvPVltPa6 cursorManager = new Workspace._0023_003DzVFaPvPVltPa6();

	public BarBase()
	{
		_0023_003Dzcohknzm9R4bwv_M69A_003D_003D(_0023_003DzsLHxXyo_003D: false);
	}

	internal bool _0023_003DzzL5IpUnrTwJugl0U9w_003D_003D()
	{
		return _003CTemporaryDisableButtons_003Ek__BackingField;
	}

	internal void _0023_003Dzcohknzm9R4bwv_M69A_003D_003D(bool _0023_003DzsLHxXyo_003D)
	{
		_003CTemporaryDisableButtons_003Ek__BackingField = _0023_003DzsLHxXyo_003D;
	}

	internal void _0023_003DzPHOrvtU_uKZw0eZiJQ_003D_003D(Workspace _0023_003DzU0f5_qE_003D)
	{
		ViewCubeIcon viewCubeIcon = _0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp().ViewCubeIcon;
		if (_0023_003DzU0f5_qE_003D._0023_003Dz1h04P8XycEellhFbXA_003D_003D() || (viewCubeIcon != null && viewCubeIcon.Dragging))
		{
			_0023_003Dzcohknzm9R4bwv_M69A_003D_003D(_0023_003DzsLHxXyo_003D: true);
		}
		else
		{
			_0023_003Dzcohknzm9R4bwv_M69A_003D_003D(_0023_003DzsLHxXyo_003D: false);
		}
	}

	protected static void Repaint(Workspace workspace)
	{
		if (workspace._0023_003DzMBy_0024512q0kfX())
		{
			workspace.Invalidate();
			return;
		}
		workspace.PaintBackBuffer();
		workspace.SwapBuffers();
	}

	protected void Hover(Workspace workspace, ToolBarButton button)
	{
		if (button != null)
		{
			button._0023_003Dz7M7UaJs_003D(_0023_003DzYvunAdQ_003D: true);
			workspace._0023_003DzPpGh50u0FkyM(button.ToolTipText);
		}
	}

	public virtual bool Contains(Point mousePos)
	{
		return false;
	}

	protected void OnMouseDown(Workspace workspace, MouseEventArgs mouseEventArgs)
	{
		_0023_003DzPHOrvtU_uKZw0eZiJQ_003D_003D(workspace);
	}

	internal abstract void _0023_003Dz8WTvZ9I_003D(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D);

	internal virtual void _0023_003DzU4mOaJbofwdL(Workspace _0023_003DzU0f5_qE_003D, Size _0023_003Dz0_0024_0024VbFw_003D)
	{
	}

	public new virtual Image GetThumbnail(Viewport viewport, Size size, Color backgroundColor)
	{
		Rectangle bounds = GetBounds(viewport);
		Workspace _0023_003Dz0TvaYNo_003D = viewport._0023_003Dz0TvaYNo_003D;
		if (bounds.Size.IsEmpty)
		{
			_0023_003Dz8WTvZ9I_003D(_0023_003Dz0TvaYNo_003D, viewport);
			bounds = GetBounds(viewport);
		}
		return _0023_003DzxxnnHBbC5r2U(this, viewport, default(Size), bounds, size, backgroundColor);
	}

	internal Image _0023_003DzxxnnHBbC5r2U(IUserInterfaceElement _0023_003DzDkQ3_10_003D, Viewport _0023_003DzYzWi5Yw_003D, Size _0023_003Dz0_0024_0024VbFw_003D, Rectangle _0023_003DzLCFtN0k_003D, Size _0023_003Dz9UoBAvg_003D, Color _0023_003DzNLGcq5k_003D)
	{
		_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
		bool flag = _0023_003DzNLGcq5k_003D == Color.Empty;
		RenderContextBase.drawSceneFuncDelegate _0023_003DzHdL9CKamSnvn = ((!flag) ? new RenderContextBase.drawSceneFuncDelegate(DrawForBitmap) : new RenderContextBase.drawSceneFuncDelegate(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003Dz6LfbgRAYOjvE));
		return _0023_003DzYzWi5Yw_003D._0023_003DzNZ5R7KqLKF7E(new Viewport._0023_003Dz7XrVzbNXMo8q
		{
			_0023_003DzshGHYXMIRfsi = flag,
			_0023_003DzNLGcq5k_003D = _0023_003DzNLGcq5k_003D,
			_0023_003Dzy4MPItw_003D = _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D,
			_0023_003DzxFNeIFWItLae = _0023_003Dz0_0024_0024VbFw_003D,
			_0023_003DzLCFtN0k_003D = _0023_003DzLCFtN0k_003D,
			_0023_003DzCs_ZxbN2mZ30 = 1f,
			_0023_003DzbUBvby4V64DY = flag,
			_0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D = false,
			_0023_003Dz0W4nCS2oJwWK = false,
			_0023_003DzRbeRKfvgcnrLx5MxrA_003D_003D = false,
			_0023_003DzmAezgho6pU2i = true,
			_0023_003DzHdL9CKamSnvn = _0023_003DzHdL9CKamSnvn
		}, _0023_003Dz9UoBAvg_003D);
	}

	protected override void DrawForBitmap(object drawSceneParams)
	{
		DrawSceneParams drawSceneParams2 = (DrawSceneParams)drawSceneParams;
		RenderContextBase renderContext = drawSceneParams2.RenderContext;
		Workspace workspace = (Workspace)drawSceneParams2.Workspace;
		Viewport obj = (Viewport)drawSceneParams2.Viewport;
		renderContext.ClearColor(workspace._0023_003DzU7yFFKcRyseX());
		renderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		renderContext.FrontFaceCW = false;
		renderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		obj._0023_003Dz191ozMVp28cu(renderContext, workspace._0023_003DzNwtRJ3cLTrAy(), drawSceneParams2.ZoomRect, _0023_003DzPHqp5dQ_003D: false, 0f, workspace._0023_003DzU7yFFKcRyseX(), _0023_003DzIHwNrERoZxEh: false);
		renderContext.SetState(depthStencilStateType.DepthTestLess);
		renderContext.PushBlendState();
		renderContext.SetState(blendStateType.Blend);
		Draw(drawSceneParams2);
		renderContext.PopBlendState();
	}

	protected internal abstract void Draw(DrawSceneParams myParams);

	internal abstract bool _0023_003DzMhJnK2KPd8YE(Workspace _0023_003DzU0f5_qE_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D);
}
