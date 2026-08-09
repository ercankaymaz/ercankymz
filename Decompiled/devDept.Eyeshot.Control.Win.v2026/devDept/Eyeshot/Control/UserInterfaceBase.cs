using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

public abstract class UserInterfaceBase : DisposableBase, IUserInterfaceElement, IUserInterfaceElementBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Viewport _0023_003DzHANCcRtcNDGc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzUpGT4pbI_0024iyRAvjQgjRowNM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzqi9Eg8ZFIKz8_00242uTWKw97DI_003D;

	protected internal virtual Viewport ParentViewport
	{
		get
		{
			return _0023_003DzHANCcRtcNDGc;
		}
		set
		{
			_0023_003DzHANCcRtcNDGc = value;
		}
	}

	protected bool CustomViewport
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzUpGT4pbI_0024iyRAvjQgjRowNM_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzUpGT4pbI_0024iyRAvjQgjRowNM_003D = value;
		}
	}

	protected bool LocationAtOrigin
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzqi9Eg8ZFIKz8_00242uTWKw97DI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzqi9Eg8ZFIKz8_00242uTWKw97DI_003D = value;
		}
	}

	public virtual void ScaleForDPI()
	{
	}

	internal bool _0023_003DzW2xdm0h0L74_0024(bool _0023_003DzIhX7TrgN6rtt, bool _0023_003DznwIKlITwQSgi)
	{
		return _0023_003DzIhX7TrgN6rtt || _0023_003DznwIKlITwQSgi;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (!(this is ProgressBar))
		{
			ParentViewport = null;
		}
	}

	protected internal string GetDefaultLayerName(Workspace ws = null)
	{
		string defaultLayerName = Layer.DefaultLayerName;
		if (ParentViewport != null && ParentViewport._0023_003Dz0TvaYNo_003D != null)
		{
			defaultLayerName = ParentViewport._0023_003Dz0TvaYNo_003D.Layers.GetDefaultLayerName();
		}
		else if (ws != null)
		{
			defaultLayerName = ws.Layers.GetDefaultLayerName();
		}
		return defaultLayerName;
	}

	public virtual Image GetThumbnail(Viewport viewport, Size size, Color backgroundColor)
	{
		Size _0023_003Dz0_0024_0024VbFw_003D = default(Size);
		bool flag = backgroundColor == Color.Empty;
		Rectangle bounds = GetBounds(viewport);
		if (size.Width > 512 || size.Height > 512)
		{
			size = Workspace._0023_003DzTRjGTao_003D(size, 512);
		}
		if (bounds.Width > viewport.Size.Width)
		{
			bounds.Width = viewport.Size.Width;
		}
		if (bounds.Height > viewport.Size.Height)
		{
			bounds.Height = viewport.Size.Height;
		}
		if (bounds.X < viewport.Location.X)
		{
			bounds.X = viewport.Location.X;
		}
		if (bounds.Y < viewport.Location.Y)
		{
			bounds.Y = viewport.Location.Y;
		}
		if (bounds.X + bounds.Width > viewport.Location.X + viewport.Size.Width)
		{
			bounds.Width = viewport.Size.Width - bounds.X;
		}
		if (bounds.Y + bounds.Height > viewport.Location.Y + viewport.Size.Height)
		{
			bounds.Height = viewport.Size.Height - bounds.Y;
		}
		if (bounds.Width <= 0)
		{
			bounds.Width = 1;
		}
		if (bounds.Height <= 0)
		{
			bounds.Height = 1;
		}
		if (CustomViewport)
		{
			LocationAtOrigin = true;
			if (!flag)
			{
				_0023_003Dz0_0024_0024VbFw_003D = new Size(bounds.Width, bounds.Height);
			}
		}
		Rectangle _0023_003DzLCFtN0k_003D = ((!CustomViewport || flag) ? bounds : new Rectangle(viewport.Location.X, viewport.Location.Y, bounds.Width, bounds.Height));
		Image result = _0023_003DzxxnnHBbC5r2U(this, viewport, _0023_003Dz0_0024_0024VbFw_003D, _0023_003DzLCFtN0k_003D, size, backgroundColor, DrawForBitmap);
		if (CustomViewport)
		{
			LocationAtOrigin = false;
		}
		return result;
	}

	internal static Image _0023_003DzxxnnHBbC5r2U(IUserInterfaceElement _0023_003DzDkQ3_10_003D, Viewport _0023_003DzYzWi5Yw_003D, Size _0023_003Dz0_0024_0024VbFw_003D, Rectangle _0023_003DzLCFtN0k_003D, Size _0023_003Dz9UoBAvg_003D, Color _0023_003DzNLGcq5k_003D, RenderContextBase.drawSceneFuncDelegate _0023_003DzU8oXN7UFEIoq)
	{
		_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
		bool flag = _0023_003DzNLGcq5k_003D == Color.Empty;
		RenderContextBase.drawSceneFuncDelegate _0023_003DzHdL9CKamSnvn = ((!flag) ? _0023_003DzU8oXN7UFEIoq : new RenderContextBase.drawSceneFuncDelegate(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003Dz6LfbgRAYOjvE));
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
			_0023_003Dz0W4nCS2oJwWK = true,
			_0023_003DzRbeRKfvgcnrLx5MxrA_003D_003D = (flag || _0023_003DzDkQ3_10_003D is Legend || _0023_003DzDkQ3_10_003D is Viewport),
			_0023_003DzmAezgho6pU2i = true,
			_0023_003Dz_0024wNiWEC_IG_0024k = _0023_003DzDkQ3_10_003D,
			_0023_003DzHdL9CKamSnvn = _0023_003DzHdL9CKamSnvn
		}, _0023_003Dz9UoBAvg_003D);
	}

	internal static void _0023_003DzKCqq1iC8575l(object _0023_003DzYlID8Dd4_lxM)
	{
		DrawSceneParams drawSceneParams = (DrawSceneParams)_0023_003DzYlID8Dd4_lxM;
		Workspace workspace = (Workspace)drawSceneParams.Workspace;
		Viewport viewport = (Viewport)drawSceneParams.Viewport;
		drawSceneParams.RenderContext.ClearColor(workspace._0023_003DzU7yFFKcRyseX());
		drawSceneParams.RenderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		drawSceneParams.RenderContext.FrontFaceCW = false;
		drawSceneParams.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		viewport._0023_003DzdzRS8TI_003D();
		viewport._0023_003Dz191ozMVp28cu(drawSceneParams.RenderContext, viewport._0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy(), RectangleF.Empty, _0023_003DzPHqp5dQ_003D: false, 0f, workspace._0023_003DzU7yFFKcRyseX(), _0023_003DzIHwNrERoZxEh: false);
		drawSceneParams.RenderContext.SetState(depthStencilStateType.DepthTestLess);
	}

	protected virtual void DrawForBitmap(object drawSceneParams)
	{
		_0023_003DzKCqq1iC8575l(drawSceneParams);
	}

	public abstract Rectangle GetBounds(Viewport viewport);

	public abstract void Update(IUserInterfaceElement another);
}
