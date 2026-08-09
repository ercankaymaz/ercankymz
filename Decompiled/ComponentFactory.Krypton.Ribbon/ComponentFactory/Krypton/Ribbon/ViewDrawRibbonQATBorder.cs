#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonQATBorder : ViewComposite
{
	private static readonly Padding _minibarBorderPaddingOverlap = new Padding(8, 2, 11, 2);

	private static readonly Padding _minibarBorderPaddingNoOverlap = new Padding(17, 2, 11, 2);

	private static readonly Padding _fullbarBorderPadding_2007 = new Padding(1, 3, 2, 2);

	private static readonly Padding _fullbarBorderPadding_2010 = new Padding(2);

	private static readonly Padding _noBorderPadding = new Padding(1, 0, 1, 0);

	private static readonly int QAT_BUTTON_WIDTH = 22;

	private static readonly int QAT_HEIGHT_MINI = 26;

	private static readonly int QAT_HEIGHT_FULL = 27;

	private static readonly int QAT_MINIBAR_LEFT = 6;

	private KryptonRibbon _ribbon;

	private NeedPaintHandler _needPaintDelegate;

	private KryptonForm _kryptonForm;

	private IDisposable _memento;

	private bool _minibar;

	private bool _overlapAppButton;

	public KryptonForm OwnerForm
	{
		get
		{
			return _kryptonForm;
		}
		set
		{
			_kryptonForm = value;
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

	public bool OverlapAppButton
	{
		get
		{
			return _overlapAppButton;
		}
		set
		{
			_overlapAppButton = value;
		}
	}

	private bool Active
	{
		get
		{
			if (OwnerForm != null)
			{
				return OwnerForm.WindowActive;
			}
			return true;
		}
	}

	private Padding BarPadding
	{
		get
		{
			if (_minibar)
			{
				if (_ribbon.RibbonShape == PaletteRibbonShape.Office2010)
				{
					return _noBorderPadding;
				}
				if (OverlapAppButton)
				{
					return _minibarBorderPaddingOverlap;
				}
				return _minibarBorderPaddingNoOverlap;
			}
			if (_ribbon.RibbonShape == PaletteRibbonShape.Office2010)
			{
				return _fullbarBorderPadding_2010;
			}
			return _fullbarBorderPadding_2007;
		}
	}

	private int BarHeight
	{
		get
		{
			if (_minibar)
			{
				return QAT_HEIGHT_MINI;
			}
			return QAT_HEIGHT_FULL;
		}
	}

	public ViewDrawRibbonQATBorder(KryptonRibbon ribbon, NeedPaintHandler needPaintDelegate, bool minibar)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(needPaintDelegate != null);
		_ribbon = ribbon;
		_needPaintDelegate = needPaintDelegate;
		_minibar = minibar;
		_overlapAppButton = true;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonQATBorder:" + base.Id;
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
		Size preferredSize = base.GetPreferredSize(context);
		preferredSize = CommonHelper.ApplyPadding(Orientation.Horizontal, preferredSize, BarPadding);
		preferredSize.Height = Math.Max(preferredSize.Height, BarHeight);
		if (OwnerForm != null)
		{
			int num = (OwnerForm.Width - 100) / 3 * 2;
			int num2 = (num - BarPadding.Horizontal) / QAT_BUTTON_WIDTH;
			num = num2 * QAT_BUTTON_WIDTH + BarPadding.Horizontal;
			preferredSize.Width = Math.Min(num, preferredSize.Width);
		}
		return preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Rectangle displayRectangle = context.DisplayRectangle;
		if (_minibar)
		{
			displayRectangle.Y = displayRectangle.Bottom - 1 - QAT_HEIGHT_MINI;
			displayRectangle.Height = QAT_HEIGHT_MINI;
		}
		ClientRectangle = displayRectangle;
		context.DisplayRectangle = CommonHelper.ApplyPadding(Orientation.Horizontal, ClientRectangle, BarPadding);
		base.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		if (_minibar && _ribbon.RibbonShape == PaletteRibbonShape.Office2010)
		{
			return;
		}
		PaletteState state = PaletteState.Normal;
		Rectangle clientRectangle = ClientRectangle;
		IPaletteRibbonBack palette;
		if (_minibar)
		{
			if (Active)
			{
				palette = _ribbon.StateCommon.RibbonQATMinibarActive;
				if (!OverlapAppButton)
				{
					state = PaletteState.CheckedNormal;
				}
			}
			else
			{
				palette = _ribbon.StateCommon.RibbonQATMinibarInactive;
				state = PaletteState.Disabled;
			}
			if (OverlapAppButton)
			{
				clientRectangle.X -= QAT_MINIBAR_LEFT;
				clientRectangle.Width += QAT_MINIBAR_LEFT;
			}
			else
			{
				clientRectangle.X += QAT_MINIBAR_LEFT;
				clientRectangle.Width -= QAT_MINIBAR_LEFT;
			}
		}
		else
		{
			palette = _ribbon.StateCommon.RibbonQATFullbar;
		}
		bool composition = OwnerForm != null && OwnerForm.ApplyComposition && OwnerForm.ApplyCustomChrome;
		_memento = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, clientRectangle, state, palette, VisualOrientation.Top, composition, _memento);
	}
}
