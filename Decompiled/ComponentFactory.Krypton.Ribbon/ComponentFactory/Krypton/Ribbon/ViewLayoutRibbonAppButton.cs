#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonAppButton : ViewLayoutDocker
{
	private static readonly int APPBUTTON_WIDTH = 39;

	private static readonly int APPBUTTON_GAP = 4;

	private KryptonRibbon _ribbon;

	private KryptonForm _ownerForm;

	private ViewLayoutRibbonSeparator _separator;

	private ViewDrawRibbonAppButton _appButton;

	public KryptonForm OwnerForm
	{
		get
		{
			return _ownerForm;
		}
		set
		{
			_ownerForm = value;
		}
	}

	public override bool Visible
	{
		get
		{
			if (_ownerForm == null)
			{
				return base.Visible;
			}
			return _ribbon.Visible && base.Visible;
		}
		set
		{
			base.Visible = value;
		}
	}

	public ViewDrawRibbonAppButton AppButton => _appButton;

	public ViewLayoutRibbonAppButton(KryptonRibbon ribbon, bool bottomHalf)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_appButton = new ViewDrawRibbonAppButton(ribbon, bottomHalf);
		_separator = new ViewLayoutRibbonSeparator(APPBUTTON_GAP, ignoreMouse: true);
		Add(_appButton, bottomHalf ? ViewDockStyle.Top : ViewDockStyle.Bottom);
		Add(_separator, ViewDockStyle.Left);
		Add(new ViewLayoutRibbonSeparator(APPBUTTON_WIDTH, APPBUTTON_GAP, ignoreMouse: true), ViewDockStyle.Fill);
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonAppButton:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		UpdateSeparatorSize();
		return base.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		UpdateSeparatorSize();
		base.Layout(context);
	}

	private void UpdateSeparatorSize()
	{
		Size separatorSize = new Size(APPBUTTON_GAP, APPBUTTON_GAP);
		if (_ownerForm != null)
		{
			Padding realWindowBorders = _ownerForm.RealWindowBorders;
			separatorSize.Width += realWindowBorders.Left;
		}
		_separator.SeparatorSize = separatorSize;
	}
}
