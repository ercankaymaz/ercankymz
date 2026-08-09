using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Primitives;

public class WindowContainer : Canvas
{
	private Brush _defaultBackgroundBrush;

	private bool _isModalBackgroundApplied;

	public static readonly DependencyProperty ModalBackgroundBrushProperty;

	public Brush ModalBackgroundBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ModalBackgroundBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ModalBackgroundBrushProperty, (object)value);
		}
	}

	static WindowContainer()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.Transparent);
		((Freezable)solidColorBrush).Freeze();
		ModalBackgroundBrushProperty = DependencyProperty.Register("ModalBackgroundBrush", typeof(Brush), typeof(WindowContainer), (PropertyMetadata)(object)new UIPropertyMetadata(solidColorBrush, new PropertyChangedCallback(OnModalBackgroundBrushChanged)));
	}

	public WindowContainer()
	{
		base.SizeChanged += WindowContainer_SizeChanged;
		base.LayoutUpdated += WindowContainer_LayoutUpdated;
		base.Loaded += WindowContainer_Loaded;
		base.ClipToBounds = true;
	}

	private void WindowContainer_Loaded(object sender, RoutedEventArgs e)
	{
		foreach (WindowControl child in base.Children)
		{
			child.SetIsActiveInternal(isActive: false);
		}
		SetNextActiveWindow(null);
	}

	private static void OnModalBackgroundBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((WindowContainer)(object)d)?.OnModalBackgroundBrushChanged((Brush)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (Brush)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected virtual void OnModalBackgroundBrushChanged(Brush oldValue, Brush newValue)
	{
		SetModalBackground();
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		Size result = base.MeasureOverride(constraint);
		if (base.Children.Count > 0)
		{
			double val = (double.IsNaN(base.Width) ? base.Children.OfType<WindowControl>().Max(delegate(WindowControl w)
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				double left = w.Left;
				Size desiredSize = w.DesiredSize;
				return left + ((Size)(ref desiredSize)).Width;
			}) : base.Width);
			double val2 = (double.IsNaN(base.Height) ? base.Children.OfType<WindowControl>().Max(delegate(WindowControl w)
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				double top = w.Top;
				Size desiredSize = w.DesiredSize;
				return top + ((Size)(ref desiredSize)).Height;
			}) : base.Height);
			return new Size(Math.Min(val, ((Size)(ref constraint)).Width), Math.Min(val2, ((Size)(ref constraint)).Height));
		}
		return result;
	}

	protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		base.OnVisualChildrenChanged(visualAdded, visualRemoved);
		if (visualAdded != null && !(visualAdded is WindowControl))
		{
			throw new InvalidOperationException("WindowContainer can only contain WindowControl types.");
		}
		if (visualRemoved != null)
		{
			WindowControl windowControl = (WindowControl)(object)visualRemoved;
			windowControl.LeftChanged -= Child_LeftChanged;
			windowControl.TopChanged -= Child_TopChanged;
			windowControl.PreviewMouseLeftButtonDown -= Child_PreviewMouseLeftButtonDown;
			windowControl.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(Child_IsVisibleChanged);
			windowControl.IsKeyboardFocusWithinChanged -= new DependencyPropertyChangedEventHandler(Child_IsKeyboardFocusWithinChanged);
			if (windowControl is ChildWindow)
			{
				((ChildWindow)windowControl).IsModalChanged -= Child_IsModalChanged;
			}
		}
		if (visualAdded != null)
		{
			WindowControl windowControl2 = (WindowControl)(object)visualAdded;
			windowControl2.LeftChanged += Child_LeftChanged;
			windowControl2.TopChanged += Child_TopChanged;
			windowControl2.PreviewMouseLeftButtonDown += Child_PreviewMouseLeftButtonDown;
			windowControl2.IsVisibleChanged += new DependencyPropertyChangedEventHandler(Child_IsVisibleChanged);
			windowControl2.IsKeyboardFocusWithinChanged += new DependencyPropertyChangedEventHandler(Child_IsKeyboardFocusWithinChanged);
			if (windowControl2 is ChildWindow)
			{
				((ChildWindow)windowControl2).IsModalChanged += Child_IsModalChanged;
			}
		}
	}

	private void Child_LeftChanged(object sender, EventArgs e)
	{
		WindowControl windowControl = (WindowControl)sender;
		if (windowControl != null)
		{
			windowControl.Left = GetRestrictedLeft(windowControl);
		}
		Canvas.SetLeft(windowControl, windowControl.Left);
	}

	private void Child_TopChanged(object sender, EventArgs e)
	{
		WindowControl windowControl = (WindowControl)sender;
		if (windowControl != null)
		{
			windowControl.Top = GetRestrictedTop(windowControl);
		}
		Canvas.SetTop(windowControl, windowControl.Top);
	}

	private void Child_PreviewMouseLeftButtonDown(object sender, RoutedEventArgs e)
	{
		WindowControl nextActiveWindow = (WindowControl)sender;
		if (GetModalWindow() == null)
		{
			SetNextActiveWindow(nextActiveWindow);
		}
	}

	private void Child_IsModalChanged(object sender, EventArgs e)
	{
		SetModalBackground();
	}

	private void Child_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		WindowControl windowControl = base.Children.OfType<WindowControl>().FirstOrDefault((WindowControl x) => x.Visibility == Visibility.Visible);
		base.IsHitTestVisible = windowControl != null;
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			WindowControl windowControl2 = (WindowControl)sender;
			SetChildPos(windowControl2);
			SetNextActiveWindow(windowControl2);
		}
		else
		{
			SetNextActiveWindow(null);
		}
		WindowControl modalWindow = GetModalWindow();
		if (modalWindow != null)
		{
			foreach (WindowControl item in base.Children.OfType<WindowControl>())
			{
				item.IsBlockMouseInputsPanelActive = !object.Equals(modalWindow, item);
			}
		}
		SetModalBackground();
	}

	private void Child_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		WindowControl nextActiveWindow = (WindowControl)sender;
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			SetNextActiveWindow(nextActiveWindow);
		}
	}

	private void WindowContainer_LayoutUpdated(object sender, EventArgs e)
	{
		foreach (WindowControl child in base.Children)
		{
			if (!child.IsStartupPositionInitialized && child.ActualWidth != 0.0 && child.ActualHeight != 0.0)
			{
				SetChildPos(child);
				child.IsStartupPositionInitialized = true;
			}
		}
	}

	private void WindowContainer_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		foreach (WindowControl child in base.Children)
		{
			child.Left = GetRestrictedLeft(child);
			child.Top = GetRestrictedTop(child);
		}
	}

	private void ExpandWindowControl(WindowControl windowControl)
	{
		if (windowControl != null)
		{
			windowControl.Left = 0.0;
			windowControl.Top = 0.0;
			windowControl.Width = Math.Min(base.ActualWidth, windowControl.MaxWidth);
			windowControl.Height = Math.Min(base.ActualHeight, windowControl.MaxHeight);
		}
	}

	private void SetChildPos(WindowControl windowControl)
	{
		if ((windowControl is MessageBox && windowControl.Left == 0.0 && windowControl.Top == 0.0) || (windowControl is ChildWindow && ((ChildWindow)windowControl).WindowStartupLocation == WindowStartupLocation.Center))
		{
			CenterChild(windowControl);
			return;
		}
		Canvas.SetLeft(windowControl, windowControl.Left);
		Canvas.SetTop(windowControl, windowControl.Top);
	}

	private void CenterChild(WindowControl windowControl)
	{
		windowControl.UpdateLayout();
		if (windowControl.ActualWidth != 0.0 && windowControl.ActualHeight != 0.0)
		{
			windowControl.Left = (base.ActualWidth - windowControl.ActualWidth) / 2.0;
			windowControl.Left += windowControl.Margin.Left - windowControl.Margin.Right;
			windowControl.Top = (base.ActualHeight - windowControl.ActualHeight) / 2.0;
			windowControl.Top += windowControl.Margin.Top - windowControl.Margin.Bottom;
		}
	}

	private void SetNextActiveWindow(WindowControl windowControl)
	{
		if (!base.IsLoaded)
		{
			return;
		}
		if (IsModalWindow(windowControl))
		{
			BringToFront(windowControl);
			return;
		}
		WindowControl modalWindow = GetModalWindow();
		if (modalWindow != null)
		{
			BringToFront(modalWindow);
			return;
		}
		if (windowControl != null)
		{
			BringToFront(windowControl);
			return;
		}
		BringToFront((from x in base.Children.OfType<WindowControl>()
			orderby Panel.GetZIndex(x) descending
			select x).FirstOrDefault((WindowControl x) => x.Visibility == Visibility.Visible));
	}

	private void BringToFront(WindowControl windowControl)
	{
		if (windowControl != null)
		{
			int num = base.Children.OfType<WindowControl>().Max((WindowControl x) => Panel.GetZIndex(x));
			Panel.SetZIndex(windowControl, num + 1);
			SetActiveWindow(windowControl);
		}
	}

	private void SetActiveWindow(WindowControl windowControl)
	{
		if (windowControl.IsActive)
		{
			return;
		}
		foreach (WindowControl child in base.Children)
		{
			child.SetIsActiveInternal(isActive: false);
		}
		windowControl.SetIsActiveInternal(isActive: true);
	}

	private bool IsModalWindow(WindowControl windowControl)
	{
		if (!(windowControl is MessageBox) || windowControl.Visibility != Visibility.Visible)
		{
			if (windowControl is ChildWindow && ((ChildWindow)windowControl).IsModal)
			{
				return ((ChildWindow)windowControl).WindowState == WindowState.Open;
			}
			return false;
		}
		return true;
	}

	private WindowControl GetModalWindow()
	{
		return (from x in base.Children.OfType<WindowControl>()
			orderby Panel.GetZIndex(x) descending
			select x).FirstOrDefault((WindowControl x) => IsModalWindow(x) && x.Visibility == Visibility.Visible);
	}

	private double GetRestrictedLeft(WindowControl windowControl)
	{
		if (windowControl.Left < 0.0)
		{
			return 0.0;
		}
		if (windowControl.Left + windowControl.ActualWidth > base.ActualWidth && base.ActualWidth != 0.0)
		{
			double num = base.ActualWidth - windowControl.ActualWidth;
			if (!(num < 0.0))
			{
				return num;
			}
			return 0.0;
		}
		return windowControl.Left;
	}

	private double GetRestrictedTop(WindowControl windowControl)
	{
		if (windowControl.Top < 0.0)
		{
			return 0.0;
		}
		if (windowControl.Top + windowControl.ActualHeight > base.ActualHeight && base.ActualHeight != 0.0)
		{
			double num = base.ActualHeight - windowControl.ActualHeight;
			if (!(num < 0.0))
			{
				return num;
			}
			return 0.0;
		}
		return windowControl.Top;
	}

	private void SetModalBackground()
	{
		if (GetModalWindow() != null && ModalBackgroundBrush != null)
		{
			if (!_isModalBackgroundApplied)
			{
				_defaultBackgroundBrush = base.Background;
				_isModalBackgroundApplied = true;
			}
			base.Background = ModalBackgroundBrush;
		}
		else if (_isModalBackgroundApplied)
		{
			base.Background = _defaultBackgroundBrush;
			_defaultBackgroundBrush = null;
			_isModalBackgroundApplied = false;
		}
	}
}
