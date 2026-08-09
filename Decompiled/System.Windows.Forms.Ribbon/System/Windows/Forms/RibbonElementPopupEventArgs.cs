using System.Drawing;

namespace System.Windows.Forms;

public class RibbonElementPopupEventArgs : PopupEventArgs
{
	private readonly PopupEventArgs _args;

	public IRibbonElement AssociatedRibbonElement { get; }

	public new bool Cancel
	{
		get
		{
			if (_args != null)
			{
				return _args.Cancel;
			}
			return base.Cancel;
		}
		set
		{
			if (_args != null)
			{
				_args.Cancel = value;
			}
			base.Cancel = value;
		}
	}

	public RibbonElementPopupEventArgs(IRibbonElement item)
		: base(item.Owner, item.Owner, isBalloon: false, new Size(-1, -1))
	{
		AssociatedRibbonElement = item;
	}

	public RibbonElementPopupEventArgs(IRibbonElement item, PopupEventArgs args)
		: base(args.AssociatedWindow, args.AssociatedControl, args.IsBalloon, args.ToolTipSize)
	{
		AssociatedRibbonElement = item;
		_args = args;
	}
}
