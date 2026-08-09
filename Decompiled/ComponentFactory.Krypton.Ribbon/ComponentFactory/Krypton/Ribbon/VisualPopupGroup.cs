#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class VisualPopupGroup : VisualPopup
{
	private static readonly int BOTTOMRIGHT_GAP = 4;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroup _ribbonGroup;

	private ViewDrawRibbonGroupsBorder _viewBackground;

	private ViewDrawRibbonGroup _viewGroup;

	private bool _restorePreviousFocus;

	private Button _hiddenFocusTarget;

	public ViewDrawRibbonGroup ViewGroup => _viewGroup;

	public bool RestorePreviousFocus
	{
		get
		{
			return _restorePreviousFocus;
		}
		set
		{
			_restorePreviousFocus = value;
		}
	}

	protected ViewRibbonPopupGroupManager ViewPopupManager => base.ViewManager as ViewRibbonPopupGroupManager;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.Style |= 33554432;
			return createParams;
		}
	}

	public VisualPopupGroup(KryptonRibbon ribbon, KryptonRibbonGroup ribbonGroup, IRenderer renderer)
		: base(renderer, shadow: true)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonGroup != null);
		_ribbon = ribbon;
		_ribbonGroup = ribbonGroup;
		_viewGroup = new ViewDrawRibbonGroup(ribbon, ribbonGroup, base.NeedPaintDelegate);
		_viewGroup.Collapsed = false;
		_viewBackground = new ViewDrawRibbonGroupsBorder(ribbon, borderOutside: true, base.NeedPaintDelegate);
		_viewBackground.Add(_viewGroup);
		base.ViewManager = new ViewRibbonPopupGroupManager(this, ribbon, _viewBackground, _viewGroup, base.NeedPaintDelegate);
		_hiddenFocusTarget = new Button();
		_hiddenFocusTarget.TabStop = false;
		_hiddenFocusTarget.Location = new Point(-_hiddenFocusTarget.Width, -_hiddenFocusTarget.Height);
		CommonHelper.AddControlToParent(this, _hiddenFocusTarget);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			base.ViewManager.MouseLeave(EventArgs.Empty);
			if (_restorePreviousFocus)
			{
				_ribbon.RestorePreviousFocus();
			}
			_ribbonGroup.ShowingAsPopup = false;
			for (int num = base.Controls.Count - 1; num >= 0; num--)
			{
				base.Controls.RemoveAt(0);
			}
			if (_ribbon.InKeyboardMode && _ribbon.KeyTipMode == KeyTipMode.PopupGroup)
			{
				KeyTipMode keyTipMode = ((!_ribbon.RealMinimizedMode) ? KeyTipMode.SelectedGroups : KeyTipMode.PopupMinimized);
				_ribbon.KeyTipMode = keyTipMode;
				_ribbon.SetKeyTips(_ribbon.GenerateKeyTipsForSelectedTab(), keyTipMode);
			}
		}
		base.Dispose(disposing);
	}

	public void SetFirstFocusItem()
	{
		ViewPopupManager.FocusView = _viewGroup.GetFirstFocusItem();
		PerformNeedPaint(needLayout: false);
	}

	public void SetLastFocusItem()
	{
		ViewPopupManager.FocusView = _viewGroup.GetLastFocusItem();
		PerformNeedPaint(needLayout: false);
	}

	public void SetNextFocusItem()
	{
		bool matched = false;
		ViewBase nextFocusItem = _viewGroup.GetNextFocusItem(ViewPopupManager.FocusView, ref matched);
		if (nextFocusItem == null)
		{
			SetFirstFocusItem();
			return;
		}
		ViewPopupManager.FocusView = nextFocusItem;
		PerformNeedPaint(needLayout: false);
	}

	public void SetPreviousFocusItem()
	{
		bool matched = false;
		ViewBase previousFocusItem = _viewGroup.GetPreviousFocusItem(ViewPopupManager.FocusView, ref matched);
		if (previousFocusItem == null)
		{
			SetLastFocusItem();
			return;
		}
		ViewPopupManager.FocusView = previousFocusItem;
		PerformNeedPaint(needLayout: false);
	}

	public void ShowCalculatingSize(ViewDrawRibbonGroup parentGroup, Rectangle parentScreenRect)
	{
		_ribbon.SuspendLayout();
		SuspendLayout();
		try
		{
			Size preferredSize;
			using (ViewLayoutContext context = new ViewLayoutContext(this, base.Renderer))
			{
				preferredSize = _viewGroup.GetPreferredSize(context);
			}
			preferredSize.Height = _ribbon.CalculatedValues.GroupHeight;
			_ribbonGroup.ShowingAsPopup = true;
			Show(CalculateBelowPopupRect(parentScreenRect, preferredSize));
		}
		finally
		{
			_ribbon.ResumeLayout();
			ResumeLayout();
		}
	}

	public void HideFocus()
	{
		_hiddenFocusTarget.Focus();
	}

	private Rectangle CalculateBelowPopupRect(Rectangle parentScreenRect, Size popupSize)
	{
		Screen screen = Screen.FromRectangle(parentScreenRect);
		Rectangle workingArea = screen.WorkingArea;
		workingArea.Width -= BOTTOMRIGHT_GAP;
		workingArea.Height -= BOTTOMRIGHT_GAP;
		Point location = new Point(parentScreenRect.X, parentScreenRect.Bottom);
		if (parentScreenRect.Bottom + popupSize.Height <= workingArea.Bottom)
		{
			location.Y = parentScreenRect.Bottom;
		}
		else if (parentScreenRect.Top - popupSize.Height >= workingArea.Top)
		{
			location.Y = parentScreenRect.Top - popupSize.Height;
		}
		else
		{
			int num = parentScreenRect.Top - workingArea.Top;
			int num2 = workingArea.Bottom - parentScreenRect.Bottom;
			if (num > num2)
			{
				location.Y = workingArea.Top;
			}
			else
			{
				location.Y = parentScreenRect.Bottom;
			}
		}
		if (location.X < workingArea.Left)
		{
			location.X = workingArea.Left;
		}
		if (location.X + popupSize.Width > workingArea.Right)
		{
			location.X = workingArea.Right - popupSize.Width;
		}
		return new Rectangle(location, popupSize);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		base.OnLayout(levent);
		PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
		PaletteRibbonShape paletteRibbonShape = ribbonShape;
		int rounding = ((paletteRibbonShape != PaletteRibbonShape.Office2007 && paletteRibbonShape == PaletteRibbonShape.Office2010) ? 1 : 2);
		using GraphicsPath path = CommonHelper.RoundedRectanglePath(base.ClientRectangle, rounding);
		base.Region = new Region(path);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		if (_ribbon.InKeyboardMode && _ribbon.InKeyTipsMode)
		{
			_ribbon.AppendKeyTipPress(char.ToUpper(e.KeyChar));
		}
		base.OnKeyPress(e);
	}

	protected override bool ProcessDialogKey(Keys keyData)
	{
		Control controllerControl = _ribbon.GetControllerControl(this);
		ViewBase focusView = ((ViewRibbonPopupGroupManager)GetViewManager()).FocusView;
		if (focusView != null)
		{
			switch (keyData)
			{
			case Keys.Tab:
			case Keys.Return:
			case Keys.Space:
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
			case Keys.Down:
			case Keys.Tab | Keys.Shift:
				_ribbon.KillKeyboardKeyTips();
				focusView.KeyDown(new KeyEventArgs(keyData));
				return true;
			}
		}
		return base.ProcessDialogKey(keyData);
	}
}
