#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonScrollPort : ViewComposite
{
	public class RibbonViewControl : ViewControl
	{
		private KryptonRibbon _ribbon;

		private Button _hiddenFocusTarget;

		public RibbonViewControl(KryptonRibbon ribbon)
			: base(ribbon)
		{
			Debug.Assert(ribbon != null);
			_ribbon = ribbon;
			_hiddenFocusTarget = new Button();
			_hiddenFocusTarget.TabStop = false;
			_hiddenFocusTarget.Location = new Point(-_hiddenFocusTarget.Width, -_hiddenFocusTarget.Height);
			CommonHelper.AddControlToParent(this, _hiddenFocusTarget);
		}

		public void HideFocus()
		{
			_hiddenFocusTarget.Focus();
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			Control controllerControl = _ribbon.GetControllerControl(this);
			ViewBase viewBase = null;
			if (controllerControl is VisualPopupGroup)
			{
				ViewRibbonPopupGroupManager viewRibbonPopupGroupManager = (ViewRibbonPopupGroupManager)((VisualPopupGroup)controllerControl).GetViewManager();
				viewBase = viewRibbonPopupGroupManager.FocusView;
			}
			else if (controllerControl is VisualPopupMinimized)
			{
				ViewRibbonMinimizedManager viewRibbonMinimizedManager = (ViewRibbonMinimizedManager)((VisualPopupMinimized)controllerControl).GetViewManager();
				viewBase = viewRibbonMinimizedManager.FocusView;
			}
			if (viewBase != null)
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
					viewBase.KeyDown(new KeyEventArgs(keyData));
					return true;
				}
			}
			return base.ProcessDialogKey(keyData);
		}
	}

	private static int SCROLL_GAP = 8;

	private KryptonRibbon _ribbon;

	private NeedPaintHandler _needPaintDelegate;

	private Orientation _orientation;

	private ViewBase _viewFiller;

	private ViewLayoutControl _viewControl;

	private ViewLayoutRibbonScroller _nearScroller;

	private ViewLayoutRibbonScroller _farScroller;

	private ViewLayoutRibbonTabs _ribbonTabs;

	private RibbonViewControl _viewControlContent;

	private Rectangle _viewClipRect;

	private int _scrollOffset;

	private int _scrollSpeed;

	public NeedPaintHandler ViewControlPaintDelegate => _viewControl.ChildPaintDelegate;

	public bool TransparentBackground
	{
		get
		{
			return _viewControl.ChildTransparentBackground;
		}
		set
		{
			_viewControl.ChildTransparentBackground = value;
		}
	}

	public ViewLayoutControl ViewLayoutControl => _viewControl;

	public override bool Visible
	{
		get
		{
			return base.Visible;
		}
		set
		{
			if (base.Visible != value)
			{
				base.Visible = value;
				_viewControl.Visible = value;
			}
		}
	}

	public override bool Enabled
	{
		get
		{
			return base.Enabled;
		}
		set
		{
			if (base.Enabled != value)
			{
				base.Enabled = value;
				_viewControl.Enabled = value;
			}
		}
	}

	public Orientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			_orientation = value;
			_nearScroller.Orientation = NearOrientation;
			_farScroller.Orientation = FarOrientation;
		}
	}

	private VisualOrientation NearOrientation
	{
		get
		{
			switch (Orientation)
			{
			case Orientation.Horizontal:
				return VisualOrientation.Left;
			case Orientation.Vertical:
				return VisualOrientation.Top;
			default:
				Debug.Assert(condition: false);
				return VisualOrientation.Left;
			}
		}
	}

	private VisualOrientation FarOrientation
	{
		get
		{
			switch (Orientation)
			{
			case Orientation.Horizontal:
				return VisualOrientation.Right;
			case Orientation.Vertical:
				return VisualOrientation.Bottom;
			default:
				Debug.Assert(condition: false);
				return VisualOrientation.Right;
			}
		}
	}

	public event PaintEventHandler PaintBackground;

	public ViewLayoutRibbonScrollPort(KryptonRibbon ribbon, Orientation orientation, ViewBase viewFiller, bool insetForTabs, int scrollSpeed, NeedPaintHandler needPaintDelegate)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(viewFiller != null);
		Debug.Assert(needPaintDelegate != null);
		_ribbon = ribbon;
		_orientation = orientation;
		_viewFiller = viewFiller;
		_needPaintDelegate = needPaintDelegate;
		_scrollSpeed = scrollSpeed;
		_ribbonTabs = viewFiller as ViewLayoutRibbonTabs;
		_scrollOffset = 0;
		_viewControlContent = new RibbonViewControl(ribbon);
		_viewControlContent.PaintBackground += OnViewControlPaintBackground;
		_viewControl = new ViewLayoutControl(_viewControlContent, ribbon, _viewFiller);
		if (_ribbonTabs != null)
		{
			_viewControl.ChildControl.WndProcHitTest += OnChildWndProcHitTest;
		}
		_nearScroller = new ViewLayoutRibbonScroller(ribbon, NearOrientation, insetForTabs, needPaintDelegate);
		_farScroller = new ViewLayoutRibbonScroller(ribbon, FarOrientation, insetForTabs, needPaintDelegate);
		_nearScroller.Click += OnNearClick;
		_farScroller.Click += OnFarClick;
		Add(_viewControl);
		Add(_nearScroller);
		Add(_farScroller);
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonScrollPort:" + base.Id;
	}

	public KeyTipInfo[] GetGroupKeyTips()
	{
		if (_viewFiller is ViewLayoutRibbonGroups viewLayoutRibbonGroups)
		{
			KeyTipInfoList keyTipInfoList = new KeyTipInfoList();
			keyTipInfoList.AddRange(viewLayoutRibbonGroups.GetGroupKeyTips());
			for (int i = 0; i < keyTipInfoList.Count; i++)
			{
				if (!_viewClipRect.Contains(keyTipInfoList[i].ClientRect))
				{
					keyTipInfoList[i].Visible = false;
				}
			}
			return keyTipInfoList.ToArray();
		}
		return new KeyTipInfo[0];
	}

	public ViewBase GetFirstFocusItem()
	{
		ViewBase viewBase = null;
		if (_viewFiller is ViewLayoutRibbonGroups viewLayoutRibbonGroups)
		{
			viewBase = viewLayoutRibbonGroups.GetFirstFocusItem();
			if (viewBase != null)
			{
				ScrollIntoView(viewBase.ClientRectangle, paint: true);
			}
		}
		return viewBase;
	}

	public ViewBase GetLastFocusItem()
	{
		ViewBase viewBase = null;
		if (_viewFiller is ViewLayoutRibbonGroups viewLayoutRibbonGroups)
		{
			viewBase = viewLayoutRibbonGroups.GetLastFocusItem();
			if (viewBase != null)
			{
				ScrollIntoView(viewBase.ClientRectangle, paint: true);
			}
		}
		return viewBase;
	}

	public ViewBase GetNextFocusItem(ViewBase current)
	{
		ViewBase viewBase = null;
		if (_viewFiller is ViewLayoutRibbonGroups viewLayoutRibbonGroups)
		{
			viewBase = viewLayoutRibbonGroups.GetNextFocusItem(current);
			if (viewBase != null)
			{
				ScrollIntoView(viewBase.ClientRectangle, paint: true);
			}
		}
		return viewBase;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current)
	{
		ViewBase viewBase = null;
		if (_viewFiller is ViewLayoutRibbonGroups viewLayoutRibbonGroups)
		{
			viewBase = viewLayoutRibbonGroups.GetPreviousFocusItem(current);
			if (viewBase != null)
			{
				ScrollIntoView(viewBase.ClientRectangle, paint: true);
			}
		}
		return viewBase;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		return _viewControl.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Enabled = _ribbon.Enabled;
		ClientRectangle = context.DisplayRectangle;
		Rectangle clientRectangle = ClientRectangle;
		Rectangle viewClipRect = new Rectangle(Point.Empty, ClientSize);
		_viewControl.LayoutOffset = Point.Empty;
		_ribbon.GetViewManager().DoNotLayoutControls = true;
		_viewControl.GetPreferredSize(context);
		if (_viewControl.ChildControl != null && !_viewControl.ChildControl.IsDisposed)
		{
			using (new CorrectContextControl(context, _viewControl.ChildControl))
			{
				_viewFiller.Layout(context);
			}
		}
		_ribbon.GetViewManager().DoNotLayoutControls = false;
		Size clientSize = _viewFiller.ClientSize;
		_scrollOffset = Math.Max(_scrollOffset, 0);
		if ((Orientation == Orientation.Horizontal && clientSize.Width <= ClientWidth) || (Orientation == Orientation.Vertical && clientSize.Height <= ClientHeight))
		{
			_viewClipRect = viewClipRect;
			_scrollOffset = 0;
			_nearScroller.Visible = false;
			_farScroller.Visible = false;
			_viewControl.Layout(context);
		}
		else
		{
			if (_scrollOffset > 0)
			{
				_nearScroller.Visible = true;
				Size preferredSize = _nearScroller.GetPreferredSize(context);
				if (Orientation == Orientation.Horizontal)
				{
					context.DisplayRectangle = new Rectangle(clientRectangle.X, clientRectangle.Y, preferredSize.Width, clientRectangle.Height);
					clientRectangle.Width -= preferredSize.Width;
					clientRectangle.X += preferredSize.Width;
					viewClipRect.Width -= preferredSize.Width;
					viewClipRect.X += preferredSize.Width;
				}
				else
				{
					context.DisplayRectangle = new Rectangle(clientRectangle.X, clientRectangle.Y, clientRectangle.Width, preferredSize.Height);
					clientRectangle.Height -= preferredSize.Height;
					clientRectangle.Y += preferredSize.Height;
					viewClipRect.Height -= preferredSize.Height;
					viewClipRect.Y += preferredSize.Height;
				}
				_nearScroller.Layout(context);
			}
			else
			{
				_nearScroller.Visible = false;
			}
			int num = 0;
			num = ((Orientation != Orientation.Horizontal) ? (clientSize.Height - clientRectangle.Height) : (clientSize.Width - clientRectangle.Width));
			if (_scrollOffset < num)
			{
				_farScroller.Visible = true;
				Size preferredSize2 = _nearScroller.GetPreferredSize(context);
				if (Orientation == Orientation.Horizontal)
				{
					context.DisplayRectangle = new Rectangle(clientRectangle.Right - preferredSize2.Width, clientRectangle.Y, preferredSize2.Width, clientRectangle.Height);
					clientRectangle.Width -= preferredSize2.Width;
					viewClipRect.Width -= preferredSize2.Width;
				}
				else
				{
					context.DisplayRectangle = new Rectangle(clientRectangle.X, clientRectangle.Bottom - preferredSize2.Height, clientRectangle.Width, preferredSize2.Height);
					clientRectangle.Height -= preferredSize2.Height;
					viewClipRect.Height -= preferredSize2.Height;
				}
				_farScroller.Layout(context);
			}
			else
			{
				_farScroller.Visible = false;
			}
			_scrollOffset = Math.Min(val2: (Orientation != Orientation.Horizontal) ? (clientSize.Height - clientRectangle.Height) : (clientSize.Width - clientRectangle.Width), val1: _scrollOffset);
			_viewClipRect = viewClipRect;
			if (Orientation == Orientation.Horizontal)
			{
				_viewControl.LayoutOffset = new Point(-_scrollOffset, 0);
			}
			else
			{
				_viewControl.LayoutOffset = new Point(0, -_scrollOffset);
			}
			context.DisplayRectangle = clientRectangle;
			_viewControl.GetPreferredSize(context);
			_viewControl.Layout(context);
		}
		context.DisplayRectangle = ClientRectangle;
		if (!_ribbon.InKeyboardMode || !(_viewFiller is ViewLayoutRibbonTabs))
		{
			return;
		}
		ViewLayoutRibbonTabs viewLayoutRibbonTabs = (ViewLayoutRibbonTabs)_viewFiller;
		if (_ribbon.SelectedTab != null)
		{
			ViewBase viewForRibbonTab = viewLayoutRibbonTabs.GetViewForRibbonTab(_ribbon.SelectedTab);
			if (ScrollIntoView(viewForRibbonTab.ClientRectangle, paint: false))
			{
				Layout(context);
			}
		}
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			if (!current.Visible)
			{
				continue;
			}
			if (current == _viewFiller)
			{
				using Region region = new Region(_viewClipRect);
				Region region2 = context.Graphics.Clip.Clone();
				region.Intersect(region2);
				context.Graphics.Clip = region;
				current.Render(context);
				context.Graphics.Clip = region2;
			}
			else
			{
				current.Render(context);
			}
		}
	}

	private void OnChildWndProcHitTest(object sender, ViewControlHitTestArgs e)
	{
		if (_ribbonTabs != null && _ribbonTabs.GetViewForSpare != null && _ribbonTabs.GetViewForSpare.ClientRectangle.Contains(e.Point))
		{
			e.Cancel = false;
			e.Result = (IntPtr)(-1);
		}
	}

	private bool ScrollIntoView(Rectangle rect, bool paint)
	{
		if (rect.Right > _viewClipRect.Right || rect.Left < _viewClipRect.Left)
		{
			if (rect.Right > _viewClipRect.Right)
			{
				_scrollOffset += rect.Right - _viewClipRect.Right + SCROLL_GAP * 2;
			}
			if (rect.Left < _viewClipRect.Left)
			{
				_scrollOffset -= _viewClipRect.Left - rect.Left + SCROLL_GAP;
			}
			if (paint)
			{
				_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
			}
			return true;
		}
		return false;
	}

	private void OnNearClick(object sender, EventArgs e)
	{
		_scrollOffset -= _scrollSpeed;
		_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
	}

	private void OnFarClick(object sender, EventArgs e)
	{
		_scrollOffset += _scrollSpeed;
		_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout: true));
	}

	private void OnViewControlPaintBackground(object sender, PaintEventArgs e)
	{
		if (this.PaintBackground != null)
		{
			this.PaintBackground(sender, e);
		}
	}
}
