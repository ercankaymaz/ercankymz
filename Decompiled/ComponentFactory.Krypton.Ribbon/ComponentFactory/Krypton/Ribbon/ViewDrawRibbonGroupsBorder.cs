#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupsBorder : ViewComposite, IPaletteRibbonBack
{
	private static readonly Padding _borderPadding2007 = new Padding(3, 3, 3, 2);

	private static readonly Padding _borderPadding2010 = new Padding(1, 1, 1, 3);

	private KryptonRibbon _ribbon;

	private NeedPaintHandler _needPaintDelegate;

	private IPaletteRibbonBack _inherit;

	private IDisposable _memento;

	private bool _borderOutside;

	public Padding BorderPadding
	{
		get
		{
			if (_ribbon == null)
			{
				return Padding.Empty;
			}
			PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
			PaletteRibbonShape paletteRibbonShape = ribbonShape;
			if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
			{
				return _borderPadding2007;
			}
			return _borderPadding2010;
		}
	}

	protected KryptonRibbon Ribbon => _ribbon;

	protected NeedPaintHandler NeedPaintDelegate => _needPaintDelegate;

	public ViewDrawRibbonGroupsBorder(KryptonRibbon ribbon, bool borderOutside, NeedPaintHandler needPaintDelegate)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(needPaintDelegate != null);
		_ribbon = ribbon;
		_needPaintDelegate = needPaintDelegate;
		_borderOutside = borderOutside;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupsBorder:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _memento != null)
		{
			_memento.Dispose();
			_memento = null;
		}
		base.Dispose(disposing);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size size = base.GetPreferredSize(context);
		if (!_borderOutside)
		{
			size = CommonHelper.ApplyPadding(Orientation.Horizontal, size, BorderPadding);
		}
		size.Height = Ribbon.CalculatedValues.GroupsHeight;
		return size;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		if (!_borderOutside)
		{
			context.DisplayRectangle = CommonHelper.ApplyPadding(Orientation.Horizontal, context.DisplayRectangle, BorderPadding);
		}
		base.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		if (Ribbon.SelectedTab != null && !string.IsNullOrEmpty(Ribbon.SelectedTab.ContextName))
		{
			_inherit = _ribbon.StateContextCheckedNormal.RibbonGroupArea;
			ElementState = PaletteState.ContextCheckedNormal;
		}
		else
		{
			_inherit = _ribbon.StateCheckedNormal.RibbonGroupArea;
			ElementState = PaletteState.CheckedNormal;
		}
		Rectangle clientRectangle = ClientRectangle;
		if (_borderOutside)
		{
			Padding borderPadding = BorderPadding;
			clientRectangle.X -= borderPadding.Left;
			clientRectangle.Y -= borderPadding.Top;
			clientRectangle.Width += borderPadding.Horizontal;
			clientRectangle.Height += borderPadding.Vertical;
		}
		else if (_ribbon.CaptionArea.DrawCaptionOnComposition && _ribbon.RibbonShape == PaletteRibbonShape.Office2010)
		{
			clientRectangle.X--;
			clientRectangle.Width += 2;
		}
		_memento = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, clientRectangle, State, this, VisualOrientation.Top, composition: false, _memento);
	}

	public PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteState state)
	{
		return _inherit.GetRibbonBackColorStyle(state);
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

	private Color CheckForContextColor(PaletteState state)
	{
		if (Ribbon.SelectedTab != null && !string.IsNullOrEmpty(Ribbon.SelectedTab.ContextName))
		{
			KryptonRibbonContext kryptonRibbonContext = Ribbon.RibbonContexts[Ribbon.SelectedTab.ContextName];
			if (kryptonRibbonContext != null)
			{
				return kryptonRibbonContext.ContextColor;
			}
		}
		return Color.Empty;
	}
}
