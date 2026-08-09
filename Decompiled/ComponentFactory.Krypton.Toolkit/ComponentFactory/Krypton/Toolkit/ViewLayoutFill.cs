#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutFill : ViewLayoutNull
{
	private Control _control;

	private Rectangle _fillRect;

	private Padding _displayPadding;

	public Padding DisplayPadding
	{
		get
		{
			return _displayPadding;
		}
		set
		{
			_displayPadding = value;
		}
	}

	public Rectangle FillRect => _fillRect;

	public ViewLayoutFill()
		: this(null)
	{
		_displayPadding = Padding.Empty;
	}

	public ViewLayoutFill(Control control)
	{
		_control = control;
	}

	public override string ToString()
	{
		return "ViewLayoutFill:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size size = ((_control != null) ? _control.GetPreferredSize(context.DisplayRectangle.Size) : Size.Empty);
		return new Size(size.Width + DisplayPadding.Horizontal, size.Height + DisplayPadding.Vertical);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		_fillRect = ClientRectangle;
		_fillRect = CommonHelper.ApplyPadding(Orientation.Horizontal, _fillRect, DisplayPadding);
	}
}
