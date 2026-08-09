using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutDocumentTabItem : Control
{
	private static double MinDragBuffer;

	private static double MaxDragBuffer;

	private List<Rect> _otherTabsScreenArea;

	private List<TabItem> _otherTabs;

	private Rect _parentDocumentTabPanelScreenArea;

	private Panel _parentTabPanel;

	private bool _isMouseDown;

	private Point _mouseDownPoint;

	private double _mouseLastChangePositionX;

	private double _dragBuffer = MinDragBuffer;

	public static readonly DependencyProperty ModelProperty;

	private static readonly DependencyPropertyKey LayoutItemPropertyKey;

	public static readonly DependencyProperty LayoutItemProperty;

	public LayoutContent Model
	{
		get
		{
			return (LayoutContent)((DependencyObject)this).GetValue(ModelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ModelProperty, (object)value);
		}
	}

	public LayoutItem LayoutItem => (LayoutItem)((DependencyObject)this).GetValue(LayoutItemProperty);

	static LayoutDocumentTabItem()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		MinDragBuffer = 5.0;
		MaxDragBuffer = 50.0;
		ModelProperty = DependencyProperty.Register("Model", typeof(LayoutContent), typeof(LayoutDocumentTabItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnModelChanged)));
		LayoutItemPropertyKey = DependencyProperty.RegisterReadOnly("LayoutItem", typeof(LayoutItem), typeof(LayoutDocumentTabItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		LayoutItemProperty = LayoutItemPropertyKey.DependencyProperty;
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutDocumentTabItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LayoutDocumentTabItem)));
	}

	private static void OnModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutDocumentTabItem)(object)d).OnModelChanged(e);
	}

	protected virtual void OnModelChanged(DependencyPropertyChangedEventArgs e)
	{
		if (Model != null && Model.Root != null && Model.Root.Manager != null)
		{
			SetLayoutItem(Model.Root.Manager.GetLayoutItemFromModel(Model));
		}
		else
		{
			SetLayoutItem(null);
		}
	}

	protected void SetLayoutItem(LayoutItem value)
	{
		((DependencyObject)this).SetValue(LayoutItemPropertyKey, (object)value);
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		base.OnMouseLeftButtonDown(e);
		Model.IsActive = true;
		if (!(Model is LayoutDocument { CanMove: false }) && e.ClickCount == 1)
		{
			_mouseDownPoint = e.GetPosition(this);
			_isMouseDown = true;
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		base.OnMouseMove(e);
		Point position = e.GetPosition(this);
		if (_isMouseDown && (Math.Abs(((Point)(ref position)).X - ((Point)(ref _mouseDownPoint)).X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(((Point)(ref position)).Y - ((Point)(ref _mouseDownPoint)).Y) > SystemParameters.MinimumVerticalDragDistance))
		{
			UpdateDragDetails();
			CaptureMouse();
			_isMouseDown = false;
		}
		if (!base.IsMouseCaptured)
		{
			return;
		}
		Point mousePosInScreenCoord = this.PointToScreenDPI(position);
		if (!((Rect)(ref _parentDocumentTabPanelScreenArea)).Contains(mousePosInScreenCoord))
		{
			StartDraggingFloatingWindowForContent();
			return;
		}
		int num = _otherTabsScreenArea.FindIndex((Rect r) => ((Rect)(ref r)).Contains(mousePosInScreenCoord));
		if (num < 0)
		{
			return;
		}
		LayoutContent layoutContent = _otherTabs[num].Content as LayoutContent;
		ILayoutContainer parent = Model.Parent;
		ILayoutPane layoutPane = Model.Parent as ILayoutPane;
		Rect screenArea = ((DependencyObject)(object)this).FindLogicalAncestor<TabItem>().GetScreenArea();
		if (layoutContent == Model)
		{
			_mouseLastChangePositionX = ((Rect)(ref screenArea)).Left + ((Rect)(ref screenArea)).Width / 2.0;
		}
		if ((!(layoutPane is LayoutDocumentPane) || ((LayoutDocumentPane)layoutPane).CanRepositionItems) && (layoutPane.Parent == null || !(layoutPane.Parent is LayoutDocumentPaneGroup) || ((LayoutDocumentPaneGroup)layoutPane.Parent).CanRepositionItems))
		{
			List<ILayoutElement> list = parent.Children.ToList();
			int num2 = list.IndexOf(Model);
			int num3 = list.IndexOf(layoutContent);
			if (num2 != num3 && ((((Point)(ref mousePosInScreenCoord)).X < ((Rect)(ref screenArea)).Left && ((Point)(ref mousePosInScreenCoord)).X < _mouseLastChangePositionX) || (((Point)(ref mousePosInScreenCoord)).X > ((Rect)(ref screenArea)).Left + ((Rect)(ref screenArea)).Width && ((Point)(ref mousePosInScreenCoord)).X > _mouseLastChangePositionX)))
			{
				layoutPane.MoveChild(num2, num3);
				_dragBuffer = MaxDragBuffer;
				Model.IsActive = true;
				_parentTabPanel.UpdateLayout();
				UpdateDragDetails();
				_mouseLastChangePositionX = ((Point)(ref mousePosInScreenCoord)).X;
			}
		}
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (base.IsMouseCaptured)
		{
			ReleaseMouseCapture();
		}
		_isMouseDown = false;
		_dragBuffer = MinDragBuffer;
		base.OnMouseLeftButtonUp(e);
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		base.OnMouseLeave(e);
		_isMouseDown = false;
	}

	protected override void OnMouseEnter(MouseEventArgs e)
	{
		base.OnMouseEnter(e);
		_isMouseDown = false;
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Middle && LayoutItem.CloseCommand.CanExecute(null))
		{
			LayoutItem.CloseCommand.Execute(null);
		}
		base.OnMouseDown(e);
	}

	private void UpdateDragDetails()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		_parentTabPanel = ((DependencyObject)(object)this).FindLogicalAncestor<DocumentPaneTabPanel>();
		if (_parentTabPanel == null)
		{
			_parentTabPanel = GetParentPanel();
		}
		if (_parentTabPanel != null)
		{
			_parentDocumentTabPanelScreenArea = _parentTabPanel.GetScreenArea();
			((Rect)(ref _parentDocumentTabPanelScreenArea)).Inflate(0.0, _dragBuffer);
			_otherTabs = (from TabItem ch in _parentTabPanel.Children
				where ch.Visibility != Visibility.Collapsed
				select ch).ToList();
			((DependencyObject)(object)this).FindLogicalAncestor<TabItem>().GetScreenArea();
			_otherTabsScreenArea = _otherTabs.Select(delegate(TabItem ti)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_0040: Unknown result type (might be due to invalid IL or missing references)
				Rect screenArea = ti.GetScreenArea();
				Rect result = default(Rect);
				((Rect)(ref result))._002Ector(((Rect)(ref screenArea)).Left, ((Rect)(ref screenArea)).Top, ((Rect)(ref screenArea)).Width, ((Rect)(ref screenArea)).Height);
				((Rect)(ref result)).Inflate(0.0, _dragBuffer);
				return result;
			}).ToList();
		}
	}

	private Panel GetParentPanel()
	{
		foreach (DependencyObject item in ((DependencyObject)(object)this).FindLogicalAncestorsAndSelf())
		{
			if (item is Panel panel && panel.Children[0] is TabItem)
			{
				return panel;
			}
		}
		return null;
	}

	private void StartDraggingFloatingWindowForContent()
	{
		ReleaseMouseCapture();
		if (Model is LayoutAnchorable)
		{
			((LayoutAnchorable)Model).ResetCanCloseInternal();
		}
		Model.Root.Manager.StartDraggingFloatingWindowForContent(Model);
	}
}
