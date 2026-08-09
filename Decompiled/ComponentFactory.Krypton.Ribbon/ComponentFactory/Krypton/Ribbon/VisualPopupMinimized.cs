#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class VisualPopupMinimized : VisualPopup
{
	private static readonly int MINIMUM_WIDTH = 100;

	private static readonly int BOTTOMRIGHT_GAP = 4;

	private KryptonRibbon _ribbon;

	private ViewDrawRibbonCaptionArea _captionArea;

	public ViewRibbonMinimizedManager ViewRibbonManager => base.ViewManager as ViewRibbonMinimizedManager;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.Style |= 33554432;
			return createParams;
		}
	}

	public VisualPopupMinimized(KryptonRibbon ribbon, ViewManager viewManager, ViewDrawRibbonCaptionArea captionArea, IRenderer renderer)
		: base(viewManager, renderer, shadow: true)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(captionArea != null);
		_ribbon = ribbon;
		_captionArea = captionArea;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			ViewRibbonManager.MouseLeave(EventArgs.Empty);
			if (_ribbon.InKeyboardMode && _ribbon.KeyTipMode == KeyTipMode.PopupMinimized)
			{
				_ribbon.KeyTipMode = KeyTipMode.Root;
				_ribbon.SetKeyTips(_ribbon.GenerateKeyTipsAtTopLevel(), KeyTipMode.Root);
			}
			if (base.ViewManager != null)
			{
				base.ViewManager.ActiveView = null;
				base.ViewManager.Root = new ViewLayoutNull();
			}
			for (int num = base.Controls.Count - 1; num >= 0; num--)
			{
				base.Controls.RemoveAt(0);
			}
		}
		base.Dispose(disposing);
	}

	public void SetFirstFocusItem()
	{
		ViewBase firstFocusItem = _ribbon.GroupsArea.ViewGroups.GetFirstFocusItem();
		if (firstFocusItem != null)
		{
			ViewRibbonManager.FocusView = firstFocusItem;
			PerformNeedPaint(needLayout: false);
		}
	}

	public void SetLastFocusItem()
	{
		ViewBase lastFocusItem = _ribbon.GroupsArea.ViewGroups.GetLastFocusItem();
		if (lastFocusItem != null)
		{
			ViewRibbonManager.FocusView = lastFocusItem;
			PerformNeedPaint(needLayout: false);
		}
	}

	public void SetNextFocusItem()
	{
		ViewBase nextFocusItem = _ribbon.GroupsArea.ViewGroups.GetNextFocusItem(ViewRibbonManager.FocusView);
		if (nextFocusItem == null)
		{
			SetFirstFocusItem();
			return;
		}
		ViewRibbonManager.FocusView = nextFocusItem;
		PerformNeedPaint(needLayout: false);
	}

	public void SetPreviousFocusItem()
	{
		ViewBase previousFocusItem = _ribbon.GroupsArea.ViewGroups.GetPreviousFocusItem(ViewRibbonManager.FocusView);
		if (previousFocusItem == null)
		{
			SetLastFocusItem();
			return;
		}
		ViewRibbonManager.FocusView = previousFocusItem;
		PerformNeedPaint(needLayout: false);
	}

	public override bool DoesCurrentMouseDownEndAllTracking(Message m, Point pt)
	{
		Point point = PointToScreen(pt);
		Point pt2 = _ribbon.PointToClient(point);
		return base.DoesCurrentMouseDownEndAllTracking(m, pt) && !_ribbon.ClientRectangleWithoutComposition.Contains(pt2) && _captionArea.DoesCurrentMouseDownEndAllTracking(point);
	}

	public override bool AllowMouseMove(Message m, Point pt)
	{
		Point pt2 = _ribbon.PointToClient(pt);
		if (this == VisualPopupManager.Singleton.CurrentPopup && _ribbon.ClientRectangle.Contains(pt2))
		{
			return true;
		}
		return base.AllowMouseMove(m, pt);
	}

	public void Show(ViewLayoutRibbonTabsArea tabsArea, ViewDrawPanel drawMinimizedPanel)
	{
		Show(CalculatePopupRect(tabsArea, drawMinimizedPanel));
	}

	public void UpdatePosition(ViewLayoutRibbonTabsArea tabsArea, ViewDrawPanel drawMinimizedPanel)
	{
		Rectangle rectangle = CalculatePopupRect(tabsArea, drawMinimizedPanel);
		SetBounds(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		if (_ribbon.InKeyboardMode && _ribbon.InKeyTipsMode)
		{
			_ribbon.AppendKeyTipPress(char.ToUpper(e.KeyChar));
		}
		base.OnKeyPress(e);
	}

	private Rectangle CalculatePopupRect(ViewLayoutRibbonTabsArea tabsArea, ViewDrawPanel drawMinimizedPanel)
	{
		Size preferredSize;
		using (ViewLayoutContext context = new ViewLayoutContext(_ribbon, base.Renderer))
		{
			preferredSize = drawMinimizedPanel.GetPreferredSize(context);
		}
		preferredSize.Width = _ribbon.Width;
		Rectangle rectangle = _ribbon.RectangleToScreen(_ribbon.ClientRectangle);
		Rectangle rectangle2 = _ribbon.RectangleToScreen(tabsArea.ClientRectangle);
		Rectangle result = new Rectangle(rectangle.X, rectangle2.Bottom - 1, preferredSize.Width, preferredSize.Height);
		ViewDrawRibbonTab viewForRibbonTab = tabsArea.LayoutTabs.GetViewForRibbonTab(_ribbon.SelectedTab);
		Rectangle rect = _ribbon.RectangleToScreen(viewForRibbonTab.ClientRectangle);
		Screen screen = Screen.FromRectangle(rect);
		Rectangle workingArea = screen.WorkingArea;
		workingArea.Width -= BOTTOMRIGHT_GAP;
		workingArea.Height -= BOTTOMRIGHT_GAP;
		if (result.Right > workingArea.Right)
		{
			result.Width -= result.Right - workingArea.Right;
			if (result.Width < MINIMUM_WIDTH)
			{
				result.X -= MINIMUM_WIDTH - result.Width;
				result.Width = MINIMUM_WIDTH;
			}
		}
		else if (result.Left < workingArea.Left)
		{
			int num = workingArea.Left - result.Left;
			result.Width -= num;
			result.X += num;
			if (result.Width < MINIMUM_WIDTH)
			{
				result.Width = MINIMUM_WIDTH;
			}
		}
		if (result.Bottom > workingArea.Bottom)
		{
			if (rectangle2.Top - result.Height >= workingArea.Top)
			{
				result.Y = rectangle2.Top - preferredSize.Height;
			}
			else
			{
				int num2 = rectangle2.Top - workingArea.Top;
				int num3 = workingArea.Bottom - rectangle2.Bottom;
				if (num2 > num3)
				{
					result.Y = workingArea.Top;
				}
				else
				{
					result.Y = rectangle2.Bottom;
				}
			}
		}
		return result;
	}
}
