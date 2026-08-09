#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonTab : ViewComposite, IContentValues
{
	private static string _empty;

	private static Padding _preferredBorder2007;

	private static Padding _preferredBorder2010;

	private static Padding _layoutBorder2007;

	private static Padding _layoutBorder2010;

	private static Blend _contextBlend2007;

	private static Blend _contextBlend2010;

	private KryptonRibbon _ribbon;

	private KryptonRibbonTab _ribbonTab;

	private ViewLayoutRibbonTabs _layoutTabs;

	private PaletteRibbonGeneral _paletteGeneral;

	private PaletteRibbonDoubleInheritOverride _overrideStateNormal;

	private PaletteRibbonDoubleInheritOverride _overrideStateTracking;

	private PaletteRibbonDoubleInheritOverride _overrideStateCheckedNormal;

	private PaletteRibbonDoubleInheritOverride _overrideStateCheckedTracking;

	private PaletteRibbonDoubleInheritOverride _overrideStateContextTracking;

	private PaletteRibbonDoubleInheritOverride _overrideStateContextCheckedNormal;

	private PaletteRibbonDoubleInheritOverride _overrideStateContextCheckedTracking;

	private PaletteRibbonDoubleInheritOverride _overrideCurrent;

	private PaletteRibbonContextDouble _paletteContextCurrent;

	private RibbonTabToContent _contentProvider;

	private NeedPaintHandler _needPaint;

	private IDisposable[] _mementos;

	private bool _checked;

	private Size _preferredSize;

	private Rectangle _displayRect;

	private int _dirtyPaletteSize;

	private int _dirtyPaletteLayout;

	private PaletteState _cacheState;

	public IRibbonKeyTipTarget KeyTipTarget => SourceController as IRibbonKeyTipTarget;

	public ViewLayoutRibbonTabs ViewLayoutRibbonTabs => _layoutTabs;

	public bool HasFocus
	{
		get
		{
			return _overrideStateNormal.Apply;
		}
		set
		{
			_overrideStateNormal.Apply = value;
			_overrideStateTracking.Apply = value;
			_overrideStateCheckedNormal.Apply = value;
			_overrideStateCheckedTracking.Apply = value;
			_overrideStateContextTracking.Apply = value;
			_overrideStateContextCheckedNormal.Apply = value;
			_overrideStateContextCheckedTracking.Apply = value;
		}
	}

	public KryptonRibbon Ribbon => _ribbon;

	public KryptonRibbonTab RibbonTab
	{
		get
		{
			return _ribbonTab;
		}
		set
		{
			if (_ribbonTab != value)
			{
				if (_ribbonTab != null)
				{
					_ribbonTab.PropertyChanged -= OnTabPropertyChanged;
					_ribbonTab.TabView = null;
				}
				_ribbonTab = value;
				Component = _ribbonTab;
				if (_ribbonTab != null)
				{
					_ribbonTab.PropertyChanged += OnTabPropertyChanged;
					_ribbonTab.TabView = this;
				}
				_paletteContextCurrent.RibbonTab = value;
				MakeDirty();
			}
		}
	}

	public bool Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			_checked = value;
		}
	}

	public Padding PreferredBorder
	{
		get
		{
			PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
			PaletteRibbonShape paletteRibbonShape = ribbonShape;
			if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
			{
				return _preferredBorder2007;
			}
			return _preferredBorder2010;
		}
	}

	public Padding LayoutBorder
	{
		get
		{
			PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
			PaletteRibbonShape paletteRibbonShape = ribbonShape;
			if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
			{
				return _layoutBorder2007;
			}
			return _layoutBorder2010;
		}
	}

	static ViewDrawRibbonTab()
	{
		_empty = "<Empty>";
		_preferredBorder2007 = new Padding(12, 3, 12, 1);
		_preferredBorder2010 = new Padding(8, 4, 8, 3);
		_layoutBorder2007 = new Padding(4, 3, 4, 1);
		_layoutBorder2010 = new Padding(1, 4, 0, 3);
		_contextBlend2007 = new Blend();
		_contextBlend2007.Factors = new float[4] { 0f, 0f, 1f, 1f };
		_contextBlend2007.Positions = new float[4] { 0f, 0.41f, 0.7f, 1f };
		_contextBlend2010 = new Blend();
		_contextBlend2010.Factors = new float[3] { 0f, 1f, 1f };
		_contextBlend2010.Positions = new float[3] { 0f, 0.6f, 1f };
	}

	public ViewDrawRibbonTab(KryptonRibbon ribbon, ViewLayoutRibbonTabs layoutTabs, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(layoutTabs != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_layoutTabs = layoutTabs;
		_needPaint = needPaint;
		_paletteGeneral = ribbon.StateCommon.RibbonGeneral;
		_overrideStateNormal = new PaletteRibbonDoubleInheritOverride(_ribbon.OverrideFocus.RibbonTab, _ribbon.OverrideFocus.RibbonTab, _ribbon.StateNormal.RibbonTab, _ribbon.StateNormal.RibbonTab, PaletteState.FocusOverride);
		_overrideStateTracking = new PaletteRibbonDoubleInheritOverride(_ribbon.OverrideFocus.RibbonTab, _ribbon.OverrideFocus.RibbonTab, _ribbon.StateTracking.RibbonTab, _ribbon.StateTracking.RibbonTab, PaletteState.FocusOverride);
		_overrideStateCheckedNormal = new PaletteRibbonDoubleInheritOverride(_ribbon.OverrideFocus.RibbonTab, _ribbon.OverrideFocus.RibbonTab, _ribbon.StateCheckedNormal.RibbonTab, _ribbon.StateCheckedNormal.RibbonTab, PaletteState.FocusOverride);
		_overrideStateCheckedTracking = new PaletteRibbonDoubleInheritOverride(_ribbon.OverrideFocus.RibbonTab, _ribbon.OverrideFocus.RibbonTab, _ribbon.StateCheckedTracking.RibbonTab, _ribbon.StateCheckedTracking.RibbonTab, PaletteState.FocusOverride);
		_overrideStateContextTracking = new PaletteRibbonDoubleInheritOverride(_ribbon.OverrideFocus.RibbonTab, _ribbon.OverrideFocus.RibbonTab, _ribbon.StateContextTracking.RibbonTab, _ribbon.StateContextTracking.RibbonTab, PaletteState.FocusOverride);
		_overrideStateContextCheckedNormal = new PaletteRibbonDoubleInheritOverride(_ribbon.OverrideFocus.RibbonTab, _ribbon.OverrideFocus.RibbonTab, _ribbon.StateContextCheckedNormal.RibbonTab, _ribbon.StateContextCheckedNormal.RibbonTab, PaletteState.FocusOverride);
		_overrideStateContextCheckedTracking = new PaletteRibbonDoubleInheritOverride(_ribbon.OverrideFocus.RibbonTab, _ribbon.OverrideFocus.RibbonTab, _ribbon.StateContextCheckedTracking.RibbonTab, _ribbon.StateContextCheckedTracking.RibbonTab, PaletteState.FocusOverride);
		_overrideCurrent = _overrideStateNormal;
		_paletteContextCurrent = new PaletteRibbonContextDouble(_ribbon);
		_paletteContextCurrent.SetInherit(_overrideCurrent);
		_contentProvider = new RibbonTabToContent(_paletteGeneral, _paletteContextCurrent);
		RibbonTabController ribbonTabController = new RibbonTabController(_ribbon, this, _needPaint);
		ribbonTabController.Click += OnTabClicked;
		ribbonTabController.ContextClick += OnTabContextClicked;
		MouseController = ribbonTabController;
		SourceController = ribbonTabController;
		KeyController = ribbonTabController;
		Component = _ribbonTab;
		Add(new ViewDrawContent(_contentProvider, this, VisualOrientation.Top));
		_mementos = new IDisposable[Enum.GetValues(typeof(PaletteState)).Length];
	}

	public override string ToString()
	{
		return "ViewDrawRibbonTab:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_ribbonTab != null)
			{
				_ribbonTab.PropertyChanged -= OnTabPropertyChanged;
				_ribbonTab.TabView = null;
			}
			if (_mementos != null)
			{
				IDisposable[] mementos = _mementos;
				for (int i = 0; i < mementos.Length; i++)
				{
					mementos[i]?.Dispose();
				}
				_mementos = null;
			}
		}
		base.Dispose(disposing);
	}

	public void MakeDirty()
	{
		_dirtyPaletteSize = 0;
		_dirtyPaletteLayout = 0;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		CheckPaletteState(context);
		if (_cacheState != State)
		{
			MakeDirty();
			_cacheState = State;
		}
		if (_ribbon.DirtyPaletteCounter != _dirtyPaletteSize)
		{
			_preferredSize = base.GetPreferredSize(context);
			Padding preferredBorder = PreferredBorder;
			_preferredSize = new Size(_preferredSize.Width + preferredBorder.Horizontal, _preferredSize.Height + preferredBorder.Vertical);
			_dirtyPaletteSize = _ribbon.DirtyPaletteCounter;
		}
		return _preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		CheckPaletteState(context);
		ClientRectangle = context.DisplayRectangle;
		if (_cacheState != State)
		{
			MakeDirty();
			_cacheState = State;
		}
		if (_displayRect != ClientRectangle || _ribbon.DirtyPaletteCounter != _dirtyPaletteLayout)
		{
			Padding layoutBorder = LayoutBorder;
			context.DisplayRectangle = new Rectangle(ClientLocation.X + layoutBorder.Left, ClientLocation.Y + layoutBorder.Top, ClientWidth - layoutBorder.Horizontal, ClientHeight - layoutBorder.Vertical);
			base.Layout(context);
			context.DisplayRectangle = ClientRectangle;
			_displayRect = ClientRectangle;
			_dirtyPaletteLayout = _ribbon.DirtyPaletteCounter;
		}
	}

	public override void RenderBefore(RenderContext context)
	{
		CheckPaletteState(context);
		ContextTabSet contextTabSet = ViewLayoutRibbonTabs.ContextTabSets[RibbonTab.ContextName];
		PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
		PaletteRibbonShape paletteRibbonShape = ribbonShape;
		if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
		{
			if (contextTabSet != null)
			{
				RenderBefore2007ContextTab(context, contextTabSet);
			}
			_paletteContextCurrent.LightBackground = false;
		}
		else
		{
			if (contextTabSet != null)
			{
				RenderBefore2010ContextTab(context, contextTabSet);
			}
			_paletteContextCurrent.LightBackground = _ribbon.CaptionArea.DrawCaptionOnComposition;
		}
		int num = StateIndex(State);
		_mementos[num] = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, ClientRectangle, State, _paletteContextCurrent, VisualOrientation.Top, composition: false, _mementos[num]);
	}

	public override void RenderAfter(RenderContext context)
	{
		ContextTabSet contextTabSet = ViewLayoutRibbonTabs.ContextTabSets[RibbonTab.ContextName];
		if (contextTabSet != null)
		{
			PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
			PaletteRibbonShape paletteRibbonShape = ribbonShape;
			if (paletteRibbonShape == PaletteRibbonShape.Office2010)
			{
				RenderAfter2010ContextTab(context, contextTabSet);
			}
		}
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		if (_ribbonTab != null && _ribbonTab.Text.Length > 0)
		{
			return _ribbonTab.Text;
		}
		return _empty;
	}

	public string GetLongText()
	{
		return string.Empty;
	}

	private void RenderBefore2007ContextTab(RenderContext context, ContextTabSet cts)
	{
		if (!cts.IsFirstOrLastTab(this))
		{
			return;
		}
		Color ribbonTabSeparatorContextColor = _paletteGeneral.GetRibbonTabSeparatorContextColor(PaletteState.Normal);
		Rectangle clientRectangle = base.Parent.ClientRectangle;
		Rectangle rectangle = new Rectangle(ClientRectangle.X - 1, clientRectangle.Y, ClientRectangle.Width + 2, clientRectangle.Height);
		Rectangle rect = new Rectangle(ClientRectangle.X - 1, clientRectangle.Y - 1, ClientRectangle.Width + 2, clientRectangle.Height + 2);
		using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, ribbonTabSeparatorContextColor, Color.Transparent, 90f);
		linearGradientBrush.Blend = _contextBlend2007;
		using Pen pen = new Pen(linearGradientBrush);
		if (cts.IsFirstTab(this))
		{
			context.Graphics.DrawLine(pen, rectangle.X, rectangle.Y, rectangle.X, rectangle.Bottom - 1);
		}
		if (cts.IsLastTab(this))
		{
			context.Graphics.DrawLine(pen, rectangle.Right - 1, rectangle.Y, rectangle.Right - 1, rectangle.Bottom - 1);
		}
	}

	private void RenderBefore2010ContextTab(RenderContext context, ContextTabSet cts)
	{
		Color ribbonTabSeparatorContextColor = _paletteGeneral.GetRibbonTabSeparatorContextColor(PaletteState.Normal);
		Color contextColor = cts.ContextColor;
		Color baseColor = ControlPaint.Light(contextColor);
		Color color = CommonHelper.MergeColors(Color.Black, 0.1f, contextColor, 0.9f);
		Rectangle rect = new Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 2, ClientRectangle.Height + 1);
		Rectangle rect2 = new Rectangle(ClientRectangle.X - 2, ClientRectangle.Y - 1, ClientRectangle.Width + 4, ClientRectangle.Height);
		using LinearGradientBrush brush = new LinearGradientBrush(rect, ribbonTabSeparatorContextColor, Color.Transparent, 90f);
		using LinearGradientBrush brush2 = new LinearGradientBrush(rect, color, Color.Transparent, 90f);
		using LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.FromArgb(64, baseColor), Color.Transparent, 90f);
		linearGradientBrush.Blend = _contextBlend2010;
		using Pen pen = new Pen(brush);
		using Pen pen2 = new Pen(brush2);
		if (cts.IsFirstTab(this))
		{
			context.Graphics.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom - 2);
			context.Graphics.DrawLine(pen2, rect.X + 1, rect.Y, rect.X + 1, rect.Bottom - 2);
			rect2.X += 2;
			rect2.Width -= 2;
			if (cts.IsLastTab(this))
			{
				context.Graphics.DrawLine(pen, rect.Right - 1, rect.Y, rect.Right - 1, rect.Bottom - 2);
				context.Graphics.DrawLine(pen2, rect.Right - 2, rect.Y, rect.Right - 2, rect.Bottom - 2);
				rect2.Width -= 2;
			}
		}
		else if (cts.IsLastTab(this))
		{
			context.Graphics.DrawLine(pen, rect.Right - 1, rect.Y, rect.Right - 1, rect.Bottom - 2);
			context.Graphics.DrawLine(pen2, rect.Right - 2, rect.Y, rect.Right - 2, rect.Bottom - 2);
			rect2.Width -= 2;
		}
		context.Graphics.FillRectangle(linearGradientBrush, rect2);
	}

	private void RenderAfter2010ContextTab(RenderContext context, ContextTabSet cts)
	{
		switch (State)
		{
		}
	}

	private int StateIndex(PaletteState state)
	{
		Array values = Enum.GetValues(typeof(PaletteState));
		for (int i = 0; i < values.Length; i++)
		{
			if ((PaletteState)values.GetValue(i) == state)
			{
				return i;
			}
		}
		return 0;
	}

	private void CheckPaletteState(ViewContext context)
	{
		bool flag = (Enabled = IsFixed || context.Control.Enabled);
		if (Count > 0)
		{
			this[0].Enabled = flag;
		}
		if (!flag)
		{
			_paletteContextCurrent.SetInherit(_overrideStateNormal);
			return;
		}
		PaletteState paletteState = State;
		Checked = _ribbon.SelectedTab == RibbonTab;
		bool flag3 = !string.IsNullOrEmpty(RibbonTab.ContextName);
		if (!IsFixed)
		{
			if (Checked)
			{
				switch (paletteState)
				{
				case PaletteState.Normal:
				case PaletteState.CheckedNormal:
				case PaletteState.ContextCheckedNormal:
					paletteState = ((!flag3) ? PaletteState.CheckedNormal : PaletteState.ContextCheckedNormal);
					break;
				case PaletteState.Tracking:
				case PaletteState.CheckedTracking:
				case PaletteState.ContextCheckedTracking:
					paletteState = ((!flag3) ? PaletteState.CheckedTracking : PaletteState.ContextCheckedTracking);
					break;
				}
			}
			else
			{
				switch (paletteState)
				{
				case PaletteState.CheckedNormal:
				case PaletteState.ContextCheckedNormal:
					paletteState = PaletteState.Normal;
					break;
				case PaletteState.Tracking:
				case PaletteState.CheckedTracking:
				case PaletteState.ContextCheckedTracking:
					paletteState = ((!flag3) ? PaletteState.Tracking : PaletteState.ContextTracking);
					break;
				}
			}
		}
		switch (paletteState)
		{
		case PaletteState.Disabled:
		case PaletteState.Normal:
			_overrideCurrent = _overrideStateNormal;
			break;
		case PaletteState.Tracking:
			_overrideCurrent = _overrideStateTracking;
			break;
		case PaletteState.CheckedNormal:
			_overrideCurrent = _overrideStateCheckedNormal;
			break;
		case PaletteState.CheckedTracking:
			_overrideCurrent = _overrideStateCheckedTracking;
			break;
		case PaletteState.ContextTracking:
			_overrideCurrent = _overrideStateContextTracking;
			break;
		case PaletteState.ContextCheckedNormal:
			_overrideCurrent = _overrideStateContextCheckedNormal;
			break;
		case PaletteState.ContextCheckedTracking:
			_overrideCurrent = _overrideStateContextCheckedTracking;
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		ElementState = paletteState;
		if (Count > 0)
		{
			this[0].ElementState = paletteState;
		}
		_paletteContextCurrent.SetInherit(_overrideCurrent);
	}

	private void OnTabPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		MakeDirty();
	}

	private void OnTabClicked(object sender, MouseEventArgs e)
	{
		if (!Checked && RibbonTab != null)
		{
			_ribbon.SelectedTab = RibbonTab;
		}
	}

	private void OnTabContextClicked(object sender, MouseEventArgs e)
	{
		if (_ribbon.InDesignMode)
		{
			_ribbonTab.OnDesignTimeContextMenu(new MouseEventArgs(MouseButtons.Right, 1, e.X, e.Y, 0));
			return;
		}
		Point p = _ribbon.TabsArea.TabsContainerControl.ChildControl.PointToScreen(new Point(e.X, e.Y));
		Point point = _ribbon.PointToClient(p);
		_ribbon.DisplayRibbonContextMenu(new MouseEventArgs(e.Button, e.Clicks, point.X, point.Y, e.Delta));
	}
}
