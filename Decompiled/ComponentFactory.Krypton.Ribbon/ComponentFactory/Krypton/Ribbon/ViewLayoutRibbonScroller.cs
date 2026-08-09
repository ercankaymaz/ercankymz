#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonScroller : ViewComposite
{
	private static readonly int SCROLLER_LENGTH = 12;

	private static readonly int GAP_LENGTH = 2;

	private VisualOrientation _orientation;

	private ViewDrawRibbonScrollButton _button;

	private ViewLayoutRibbonSeparator _separator;

	private bool _insetForTabs;

	public VisualOrientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			_orientation = value;
			_button.Orientation = value;
		}
	}

	public event EventHandler Click;

	public ViewLayoutRibbonScroller(KryptonRibbon ribbon, VisualOrientation orientation, bool insetForTabs, NeedPaintHandler needPaintDelegate)
	{
		_orientation = orientation;
		_insetForTabs = insetForTabs;
		_button = new ViewDrawRibbonScrollButton(ribbon, orientation);
		_separator = new ViewLayoutRibbonSeparator(GAP_LENGTH, ignoreMouse: true);
		RepeatButtonController repeatButtonController = new RepeatButtonController(ribbon, _button, needPaintDelegate);
		repeatButtonController.Click += OnButtonClick;
		_button.MouseController = repeatButtonController;
		Add(_button);
		Add(_separator);
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonScroller:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return new Size(SCROLLER_LENGTH + GAP_LENGTH, SCROLLER_LENGTH + GAP_LENGTH);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		switch (Orientation)
		{
		case VisualOrientation.Top:
			context.DisplayRectangle = new Rectangle(ClientLocation.X, ClientRectangle.Bottom - GAP_LENGTH, ClientWidth, GAP_LENGTH);
			_separator.Layout(context);
			context.DisplayRectangle = new Rectangle(ClientLocation.X, ClientLocation.Y, ClientWidth, ClientHeight - GAP_LENGTH);
			_button.Layout(context);
			break;
		case VisualOrientation.Bottom:
			context.DisplayRectangle = new Rectangle(ClientLocation.X, ClientRectangle.Y, ClientWidth, GAP_LENGTH);
			_separator.Layout(context);
			context.DisplayRectangle = new Rectangle(ClientLocation.X, ClientLocation.Y + GAP_LENGTH, ClientWidth, ClientHeight - GAP_LENGTH);
			_button.Layout(context);
			break;
		case VisualOrientation.Left:
			if (_insetForTabs)
			{
				ClientRectangle = AdjustRectForTabs(ClientRectangle);
			}
			context.DisplayRectangle = new Rectangle(ClientRectangle.Right - GAP_LENGTH, ClientLocation.Y, GAP_LENGTH, ClientHeight);
			_separator.Layout(context);
			context.DisplayRectangle = new Rectangle(ClientLocation.X, ClientLocation.Y, ClientWidth - GAP_LENGTH, ClientHeight);
			_button.Layout(context);
			break;
		case VisualOrientation.Right:
			if (_insetForTabs)
			{
				ClientRectangle = AdjustRectForTabs(ClientRectangle);
			}
			context.DisplayRectangle = new Rectangle(ClientLocation.X, ClientLocation.Y, GAP_LENGTH, ClientHeight);
			_separator.Layout(context);
			context.DisplayRectangle = new Rectangle(ClientLocation.X + GAP_LENGTH, ClientLocation.Y, ClientWidth - GAP_LENGTH, ClientHeight);
			_button.Layout(context);
			break;
		}
		context.DisplayRectangle = ClientRectangle;
	}

	private Rectangle AdjustRectForTabs(Rectangle rect)
	{
		rect.Y++;
		rect.Height -= 3;
		return rect;
	}

	private void OnButtonClick(object sender, MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, EventArgs.Empty);
		}
	}
}
