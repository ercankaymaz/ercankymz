using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutAnchorableControl : Control
{
	public static readonly DependencyProperty ModelProperty;

	private static readonly DependencyPropertyKey LayoutItemPropertyKey;

	public static readonly DependencyProperty LayoutItemProperty;

	public LayoutAnchorable Model
	{
		get
		{
			return (LayoutAnchorable)((DependencyObject)this).GetValue(ModelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ModelProperty, (object)value);
		}
	}

	public LayoutItem LayoutItem => (LayoutItem)((DependencyObject)this).GetValue(LayoutItemProperty);

	static LayoutAnchorableControl()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		ModelProperty = DependencyProperty.Register("Model", typeof(LayoutAnchorable), typeof(LayoutAnchorableControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnModelChanged)));
		LayoutItemPropertyKey = DependencyProperty.RegisterReadOnly("LayoutItem", typeof(LayoutItem), typeof(LayoutAnchorableControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		LayoutItemProperty = LayoutItemPropertyKey.DependencyProperty;
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutAnchorableControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LayoutAnchorableControl)));
		UIElement.FocusableProperty.OverrideMetadata(typeof(LayoutAnchorableControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
	}

	private static void OnModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutAnchorableControl)(object)d).OnModelChanged(e);
	}

	protected virtual void OnModelChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			((LayoutContent)((DependencyPropertyChangedEventArgs)(ref e)).OldValue).PropertyChanged -= Model_PropertyChanged;
		}
		if (Model != null && Model.Root != null && Model.Root.Manager != null)
		{
			Model.PropertyChanged += Model_PropertyChanged;
			SetLayoutItem(Model.Root.Manager.GetLayoutItemFromModel(Model));
		}
		else
		{
			SetLayoutItem(null);
		}
	}

	private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsEnabled" && Model != null)
		{
			base.IsEnabled = Model.IsEnabled;
			if (!base.IsEnabled && Model.IsActive && Model.Parent != null && Model.Parent is LayoutAnchorablePane)
			{
				((LayoutAnchorablePane)Model.Parent).SetNextSelectedIndex();
			}
		}
	}

	protected void SetLayoutItem(LayoutItem value)
	{
		((DependencyObject)this).SetValue(LayoutItemPropertyKey, (object)value);
	}

	protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		if ((e.NewFocus == null || e.OldFocus == null || !(e.OldFocus is LayoutFloatingWindowControl)) && Model != null)
		{
			Model.IsActive = true;
		}
		base.OnGotKeyboardFocus(e);
	}
}
