#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonContextTitle : ViewLeaf, IPaletteRibbonBack, IContentValues
{
	private static readonly int TEXT_SIDE_GAP = 4;

	private static readonly int TEXT_SIDE_GAP_COMPOSITION = 2;

	private static readonly int TEXT_BOTTOM_GAP = 3;

	private KryptonRibbon _ribbon;

	private ContextTabSet _context;

	private IPaletteRibbonBack _inherit;

	private ContextToContent _contentProvider;

	private IDisposable _mementoBack;

	private IDisposable _mementoContentText;

	private IDisposable _mementoContentShadow1;

	private IDisposable _mementoContentShadow2;

	private Rectangle _textRect;

	public ContextTabSet ContextTabSet
	{
		get
		{
			return _context;
		}
		set
		{
			_context = value;
			if (_context != null)
			{
				Component = _context.Context;
			}
			else
			{
				Component = null;
			}
		}
	}

	public override bool Visible
	{
		get
		{
			return _ribbon.Visible && base.Visible;
		}
		set
		{
			base.Visible = value;
		}
	}

	private bool DrawOnComposition
	{
		get
		{
			if (_ribbon != null)
			{
				return _ribbon.CaptionArea.DrawCaptionOnComposition;
			}
			return false;
		}
	}

	public ViewDrawRibbonContextTitle(KryptonRibbon ribbon, IPaletteRibbonBack inherit)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(inherit != null);
		_inherit = inherit;
		_ribbon = ribbon;
		_contentProvider = new ContextToContent(ribbon.StateCommon.RibbonGeneral);
	}

	public override string ToString()
	{
		return "ViewDrawRibbonContextTitle:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_mementoBack != null)
			{
				_mementoBack.Dispose();
				_mementoBack = null;
			}
			if (_mementoContentText != null)
			{
				_mementoContentText.Dispose();
				_mementoContentText = null;
			}
			if (_mementoContentShadow1 != null)
			{
				_mementoContentShadow1.Dispose();
				_mementoContentShadow1 = null;
			}
			if (_mementoContentShadow2 != null)
			{
				_mementoContentShadow2.Dispose();
				_mementoContentShadow2 = null;
			}
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return Size.Empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		Rectangle clientRectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientWidth, ClientHeight + 1);
		Rectangle clientRectangle2 = base.Parent.ClientRectangle;
		if (clientRectangle.X < clientRectangle2.Right && clientRectangle.Right >= clientRectangle2.Right)
		{
			clientRectangle.Width = clientRectangle2.Right - clientRectangle.X;
		}
		if (clientRectangle.Right > clientRectangle2.X && clientRectangle.X < clientRectangle2.X)
		{
			clientRectangle.Width = clientRectangle.Right - clientRectangle2.X;
			clientRectangle.X = clientRectangle2.X;
		}
		ClientRectangle = clientRectangle;
		int drawFontHeight = _ribbon.CalculatedValues.DrawFontHeight;
		_textRect = new Rectangle(ClientLocation.X + TEXT_SIDE_GAP, ClientLocation.Y + (ClientHeight - drawFontHeight - TEXT_BOTTOM_GAP), ClientWidth - TEXT_SIDE_GAP * 2, drawFontHeight);
		if (_mementoContentText != null)
		{
			_mementoContentText.Dispose();
			_mementoContentText = null;
		}
		if (_mementoContentShadow1 != null)
		{
			_mementoContentShadow1.Dispose();
			_mementoContentShadow1 = null;
		}
		if (_mementoContentShadow2 != null)
		{
			_mementoContentShadow2.Dispose();
			_mementoContentShadow2 = null;
		}
		if (_ribbon.RibbonShape == PaletteRibbonShape.Office2010)
		{
			Rectangle availableRect = new Rectangle(_textRect.X - 1, _textRect.Y + 1, _textRect.Width, _textRect.Height);
			Rectangle availableRect2 = new Rectangle(_textRect.X + 1, _textRect.Y + 1, _textRect.Width, _textRect.Height);
			_contentProvider.OverrideTextColor = Color.FromArgb(128, ControlPaint.Dark(GetRibbonBackColor1(PaletteState.Normal)));
			if (DrawOnComposition)
			{
				_contentProvider.OverrideTextHint = PaletteTextHint.SingleBitPerPixelGridFit;
			}
			_mementoContentShadow1 = context.Renderer.RenderStandardContent.LayoutContent(context, availableRect, _contentProvider, this, VisualOrientation.Top, PaletteState.Normal, composition: false);
			_mementoContentShadow2 = context.Renderer.RenderStandardContent.LayoutContent(context, availableRect2, _contentProvider, this, VisualOrientation.Top, PaletteState.Normal, composition: false);
			_contentProvider.OverrideTextColor = Color.Empty;
		}
		_mementoContentText = context.Renderer.RenderStandardContent.LayoutContent(context, _textRect, _contentProvider, this, VisualOrientation.Top, PaletteState.Normal, composition: false);
		_contentProvider.OverrideTextHint = PaletteTextHint.Inherit;
	}

	public override void RenderBefore(RenderContext context)
	{
		if (_ribbon.RibbonShape == PaletteRibbonShape.Office2010 && _mementoContentShadow1 != null)
		{
			PaletteState state = ((!_ribbon.Enabled) ? PaletteState.Disabled : PaletteState.Normal);
			_mementoBack = context.Renderer.RenderRibbon.DrawRibbonTabContextTitle(_ribbon.RibbonShape, context, ClientRectangle, _ribbon.StateCommon.RibbonGeneral, this, _mementoBack);
			Rectangle displayRect = new Rectangle(_textRect.X - 1, _textRect.Y + 1, _textRect.Width, _textRect.Height);
			Rectangle rectangle = new Rectangle(_textRect.X + 1, _textRect.Y + 1, _textRect.Width, _textRect.Height);
			_contentProvider.OverrideTextColor = Color.FromArgb(128, ControlPaint.Dark(GetRibbonBackColor1(PaletteState.Normal)));
			if (DrawOnComposition)
			{
				_contentProvider.OverrideTextHint = PaletteTextHint.SingleBitPerPixelGridFit;
			}
			context.Renderer.RenderStandardContent.DrawContent(context, displayRect, _contentProvider, _mementoContentShadow1, VisualOrientation.Top, state, composition: false, allowFocusRect: true);
			context.Renderer.RenderStandardContent.DrawContent(context, displayRect, _contentProvider, _mementoContentShadow2, VisualOrientation.Top, state, composition: false, allowFocusRect: true);
			_contentProvider.OverrideTextColor = Color.Empty;
			if (_mementoContentText != null)
			{
				context.Renderer.RenderStandardContent.DrawContent(context, _textRect, _contentProvider, _mementoContentText, VisualOrientation.Top, state, composition: false, allowFocusRect: true);
			}
			_contentProvider.OverrideTextHint = PaletteTextHint.Inherit;
		}
		else if (DrawOnComposition)
		{
			RenderOnComposition(context);
		}
		else
		{
			PaletteState state2 = ((!_ribbon.Enabled) ? PaletteState.Disabled : PaletteState.Normal);
			_mementoBack = context.Renderer.RenderRibbon.DrawRibbonTabContextTitle(_ribbon.RibbonShape, context, ClientRectangle, _ribbon.StateCommon.RibbonGeneral, this, _mementoBack);
			if (_mementoContentText != null)
			{
				context.Renderer.RenderStandardContent.DrawContent(context, _textRect, _contentProvider, _mementoContentText, VisualOrientation.Top, state2, DrawOnComposition, allowFocusRect: true);
			}
		}
	}

	public PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteState state)
	{
		return PaletteRibbonColorStyle.RibbonGroupAreaBorder;
	}

	public Color GetRibbonBackColor1(PaletteState state)
	{
		Color color = _inherit.GetRibbonBackColor1(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		return color;
	}

	public Color GetRibbonBackColor2(PaletteState state)
	{
		Color color = _inherit.GetRibbonBackColor2(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		return color;
	}

	public Color GetRibbonBackColor3(PaletteState state)
	{
		Color color = _inherit.GetRibbonBackColor3(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		return color;
	}

	public Color GetRibbonBackColor4(PaletteState state)
	{
		Color color = _inherit.GetRibbonBackColor4(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		return color;
	}

	public Color GetRibbonBackColor5(PaletteState state)
	{
		Color color = _inherit.GetRibbonBackColor5(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		return color;
	}

	private void RenderOnComposition(RenderContext context)
	{
		RectangleF clipBounds = context.Graphics.ClipBounds;
		if (!new Rectangle((int)clipBounds.X, (int)clipBounds.Y, (int)clipBounds.Width, (int)clipBounds.Height).IntersectsWith(ClientRectangle))
		{
			return;
		}
		IntPtr hdc = context.Graphics.GetHdc();
		IntPtr intPtr = PI.CreateCompatibleDC(hdc);
		PI.BITMAPINFO bITMAPINFO = new PI.BITMAPINFO();
		bITMAPINFO.biSize = Marshal.SizeOf((object)bITMAPINFO);
		bITMAPINFO.biWidth = ClientWidth;
		bITMAPINFO.biHeight = -ClientHeight;
		bITMAPINFO.biCompression = 0;
		bITMAPINFO.biBitCount = 32;
		bITMAPINFO.biPlanes = 1;
		IntPtr hObject = PI.CreateDIBSection(hdc, bITMAPINFO, 0u, 0, IntPtr.Zero, 0u);
		PI.SelectObject(intPtr, hObject);
		using (Graphics graphics = Graphics.FromHdc(intPtr))
		{
			Rectangle rectangle = new Rectangle(0, 0, ClientWidth, ClientHeight);
			using RenderContext context2 = new RenderContext(context.Control, graphics, rectangle, context.Renderer);
			_mementoBack = context.Renderer.RenderRibbon.DrawRibbonTabContextTitle(_ribbon.RibbonShape, context2, rectangle, _ribbon.StateCommon.RibbonGeneral, this, _mementoBack);
		}
		IntPtr hObject2 = _contentProvider.GetContentShortTextFont(State).ToHfont();
		PI.SelectObject(intPtr, hObject2);
		VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(VisualStyleElement.Window.Caption.Active);
		PI.RECT pRect = new PI.RECT
		{
			left = TEXT_SIDE_GAP_COMPOSITION,
			top = 0,
			right = ClientWidth - TEXT_SIDE_GAP_COMPOSITION * 2,
			bottom = ClientHeight
		};
		PI.DTTOPTS pOptions = new PI.DTTOPTS
		{
			dwSize = Marshal.SizeOf(typeof(PI.DTTOPTS)),
			dwFlags = 10241,
			crText = ColorTranslator.ToWin32(SystemColors.ActiveCaptionText),
			iGlowSize = (_ribbon.Enabled ? 12 : 2)
		};
		TextFormatFlags dwFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter;
		PI.DrawThemeTextEx(visualStyleRenderer.Handle, intPtr, 0, 0, GetShortText(), -1, (int)dwFlags, ref pRect, ref pOptions);
		PI.BitBlt(hdc, ClientLocation.X, ClientLocation.Y, ClientWidth, ClientHeight, intPtr, 0, 0, 13369376);
		PI.DeleteObject(hObject2);
		PI.DeleteObject(hObject);
		PI.DeleteDC(intPtr);
		context.Graphics.ReleaseHdc(hdc);
	}

	private Color CheckForContextColor(PaletteState state)
	{
		if (_context != null)
		{
			return _context.ContextColor;
		}
		return Color.Empty;
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		if (_context != null && _context.ContextTitle != null)
		{
			return _context.ContextTitle;
		}
		return string.Empty;
	}

	public string GetLongText()
	{
		return string.Empty;
	}
}
