#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupCheckBoxImage : ViewComposite
{
	private static readonly Size _smallSize = new Size(16, 16);

	private static readonly Size _largeSize = new Size(32, 32);

	private KryptonRibbonGroupCheckBox _ribbonCheckBox;

	private ViewDrawCheckBox _drawCheckBox;

	private bool _large;

	public override bool Enabled
	{
		get
		{
			return _drawCheckBox.Enabled;
		}
		set
		{
			_drawCheckBox.Enabled = value;
		}
	}

	public CheckState CheckState
	{
		get
		{
			return _drawCheckBox.CheckState;
		}
		set
		{
			_drawCheckBox.CheckState = value;
		}
	}

	public bool Tracking
	{
		get
		{
			return _drawCheckBox.Tracking;
		}
		set
		{
			_drawCheckBox.Tracking = value;
		}
	}

	public bool Pressed
	{
		get
		{
			return _drawCheckBox.Pressed;
		}
		set
		{
			_drawCheckBox.Pressed = value;
		}
	}

	public ViewDrawRibbonGroupCheckBoxImage(KryptonRibbon ribbon, KryptonRibbonGroupCheckBox ribbonCheckBox, bool large)
	{
		Debug.Assert(ribbonCheckBox != null);
		_ribbonCheckBox = ribbonCheckBox;
		_large = large;
		PaletteRedirectCheckBox palette = new PaletteRedirectCheckBox(ribbon.GetRedirector(), ribbon.StateCommon.RibbonImages.CheckBox);
		_drawCheckBox = new ViewDrawCheckBox(palette);
		Add(_drawCheckBox);
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupCheckBoxImage:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		if (_large)
		{
			return _largeSize;
		}
		return _smallSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		ClientRectangle = context.DisplayRectangle;
		Rectangle displayRectangle = new Rectangle(Point.Empty, _drawCheckBox.GetPreferredSize(context));
		if (_large)
		{
			displayRectangle.X = ClientLocation.X + (ClientWidth - displayRectangle.Width) / 2;
			displayRectangle.Y = ClientRectangle.Bottom - displayRectangle.Height;
		}
		else
		{
			displayRectangle.X = ClientRectangle.Right - displayRectangle.Width;
			displayRectangle.Y = ClientLocation.Y + (ClientHeight - displayRectangle.Height) / 2;
		}
		context.DisplayRectangle = displayRectangle;
		_drawCheckBox.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}
}
