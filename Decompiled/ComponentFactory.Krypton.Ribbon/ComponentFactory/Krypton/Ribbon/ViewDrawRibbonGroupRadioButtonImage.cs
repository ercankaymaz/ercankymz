#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupRadioButtonImage : ViewComposite
{
	private static readonly Size _smallSize = new Size(16, 16);

	private static readonly Size _largeSize = new Size(32, 32);

	private KryptonRibbonGroupRadioButton _ribbonRadioButton;

	private ViewDrawRadioButton _drawRadioButton;

	private bool _large;

	public override bool Enabled
	{
		get
		{
			return _drawRadioButton.Enabled;
		}
		set
		{
			_drawRadioButton.Enabled = value;
		}
	}

	public bool Checked
	{
		get
		{
			return _drawRadioButton.CheckState;
		}
		set
		{
			_drawRadioButton.CheckState = value;
		}
	}

	public bool Tracking
	{
		get
		{
			return _drawRadioButton.Tracking;
		}
		set
		{
			_drawRadioButton.Tracking = value;
		}
	}

	public bool Pressed
	{
		get
		{
			return _drawRadioButton.Pressed;
		}
		set
		{
			_drawRadioButton.Pressed = value;
		}
	}

	public ViewDrawRibbonGroupRadioButtonImage(KryptonRibbon ribbon, KryptonRibbonGroupRadioButton ribbonRadioButton, bool large)
	{
		Debug.Assert(ribbonRadioButton != null);
		_ribbonRadioButton = ribbonRadioButton;
		_large = large;
		PaletteRedirectRadioButton palette = new PaletteRedirectRadioButton(ribbon.GetRedirector(), ribbon.StateCommon.RibbonImages.RadioButton);
		_drawRadioButton = new ViewDrawRadioButton(palette);
		Add(_drawRadioButton);
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupRadioButtonImage:" + base.Id;
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
		Rectangle displayRectangle = new Rectangle(Point.Empty, _drawRadioButton.GetPreferredSize(context));
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
		_drawRadioButton.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}
}
