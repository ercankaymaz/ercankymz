#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewRibbonQATOverflowManager : ViewManager
{
	private KryptonRibbon _ribbon;

	private ViewLayoutRibbonQATContents _qatContents;

	private ViewBase _focusView;

	private bool _layingOut;

	public ViewLayoutRibbonQATContents QATContents => _qatContents;

	public ViewBase FocusView
	{
		get
		{
			return _focusView;
		}
		set
		{
			if (_focusView != value)
			{
				if (_focusView != null)
				{
					_focusView.LostFocus(base.Root.OwningControl);
				}
				_focusView = value;
				if (_focusView != null)
				{
					_focusView.GotFocus(base.Root.OwningControl);
				}
			}
		}
	}

	public ViewRibbonQATOverflowManager(KryptonRibbon ribbon, Control control, ViewLayoutRibbonQATContents qatContents, ViewBase root)
		: base(control, root)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(qatContents != null);
		_ribbon = ribbon;
		_qatContents = qatContents;
	}

	public override void Dispose()
	{
		FocusView = null;
		base.Dispose();
	}

	public override Size GetPreferredSize(IRenderer renderer, Size proposedSize)
	{
		_ribbon.CalculatedValues.Recalculate();
		return base.GetPreferredSize(renderer, proposedSize);
	}

	public override void Layout(ViewLayoutContext context)
	{
		if (!_layingOut)
		{
			_layingOut = true;
			_ribbon.CalculatedValues.Recalculate();
			base.Layout(context);
			_layingOut = false;
		}
	}

	public override void KeyDown(KeyEventArgs e)
	{
		if (FocusView != null)
		{
			FocusView.KeyDown(e);
		}
	}

	public override void KeyPress(KeyPressEventArgs e)
	{
		if (FocusView != null)
		{
			FocusView.KeyPress(e);
		}
	}

	public override void KeyUp(KeyEventArgs e)
	{
		if (FocusView != null)
		{
			base.MouseCaptured = FocusView.KeyUp(e);
		}
	}
}
