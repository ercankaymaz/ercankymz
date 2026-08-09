#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class VisualPopupToolTip : VisualPopup
{
	private static readonly int VERT_OFFSET = 22;

	private static readonly int HORZ_OFFSET = 8;

	private PaletteTripleMetricRedirect _palette;

	private ViewDrawDocker _drawDocker;

	private ViewDrawContent _drawContent;

	private IContentValues _contentValues;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public override bool KeyboardInert => true;

	public VisualPopupToolTip(PaletteRedirect redirector, IContentValues contentValues, IRenderer renderer)
		: this(redirector, contentValues, renderer, PaletteBackStyle.ControlToolTip, PaletteBorderStyle.ControlToolTip, PaletteContentStyle.LabelToolTip)
	{
	}

	public VisualPopupToolTip(PaletteRedirect redirector, IContentValues contentValues, IRenderer renderer, PaletteBackStyle backStyle, PaletteBorderStyle borderStyle, PaletteContentStyle contentStyle)
		: base(renderer, shadow: true)
	{
		Debug.Assert(contentValues != null);
		_contentValues = contentValues;
		_palette = new PaletteTripleMetricRedirect(redirector, backStyle, borderStyle, contentStyle, base.NeedPaintDelegate);
		_drawDocker = new ViewDrawDocker(_palette.Back, _palette.Border, null);
		_drawContent = new ViewDrawContent(_palette.Content, _contentValues, VisualOrientation.Top);
		_drawDocker.Add(_drawContent, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDocker);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	public override bool AllowMouseMove(Message m, Point pt)
	{
		return true;
	}

	public void ShowCalculatingSize(Point screenPt)
	{
		Size preferredSize = base.ViewManager.GetPreferredSize(base.Renderer, Size.Empty);
		Rectangle parentScreenRect = new Rectangle(screenPt.X + HORZ_OFFSET - preferredSize.Width / 2, screenPt.Y - VERT_OFFSET, 1, VERT_OFFSET * 2);
		Show(parentScreenRect, preferredSize);
	}

	public void ShowCalculatingSize(Rectangle screenRect)
	{
		Size preferredSize = base.ViewManager.GetPreferredSize(base.Renderer, Size.Empty);
		screenRect = new Rectangle(screenRect.X, screenRect.Y - VERT_OFFSET, screenRect.Width, screenRect.Height + VERT_OFFSET * 2);
		Show(screenRect, preferredSize);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		base.OnLayout(levent);
		using RenderContext context = new RenderContext(this, null, base.ClientRectangle, base.Renderer);
		Rectangle clientRectangle = base.ClientRectangle;
		GraphicsPath outsideBorderPath = base.Renderer.RenderStandardBorder.GetOutsideBorderPath(context, clientRectangle, _palette.Border, VisualOrientation.Top, PaletteState.Normal);
		clientRectangle.Inflate(-1, -1);
		GraphicsPath outsideBorderPath2 = base.Renderer.RenderStandardBorder.GetOutsideBorderPath(context, clientRectangle, _palette.Border, VisualOrientation.Top, PaletteState.Normal);
		clientRectangle.Inflate(-1, -1);
		GraphicsPath outsideBorderPath3 = base.Renderer.RenderStandardBorder.GetOutsideBorderPath(context, clientRectangle, _palette.Border, VisualOrientation.Top, PaletteState.Normal);
		base.Region = new Region(outsideBorderPath);
		DefineShadowPaths(outsideBorderPath, outsideBorderPath2, outsideBorderPath3);
	}
}
