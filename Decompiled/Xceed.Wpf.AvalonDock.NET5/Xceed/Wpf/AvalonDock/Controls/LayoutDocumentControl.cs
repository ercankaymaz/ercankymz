using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutDocumentControl : Control
{
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

	static LayoutDocumentControl()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		ModelProperty = DependencyProperty.Register("Model", typeof(LayoutContent), typeof(LayoutDocumentControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnModelChanged)));
		LayoutItemPropertyKey = DependencyProperty.RegisterReadOnly("LayoutItem", typeof(LayoutItem), typeof(LayoutDocumentControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		LayoutItemProperty = LayoutItemPropertyKey.DependencyProperty;
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutDocumentControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LayoutDocumentControl)));
		UIElement.FocusableProperty.OverrideMetadata(typeof(LayoutDocumentControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
	}

	private static void OnModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutDocumentControl)(object)d).OnModelChanged(e);
	}

	protected virtual void OnModelChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			((LayoutContent)((DependencyPropertyChangedEventArgs)(ref e)).OldValue).PropertyChanged -= Model_PropertyChanged;
		}
		if (Model != null)
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
			if (!base.IsEnabled && Model.IsActive && Model.Parent != null && Model.Parent is LayoutDocumentPane)
			{
				((LayoutDocumentPane)Model.Parent).SetNextSelectedIndex();
			}
		}
	}

	protected void SetLayoutItem(LayoutItem value)
	{
		((DependencyObject)this).SetValue(LayoutItemPropertyKey, (object)value);
	}

	protected override void OnPreviewGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		if (e.NewFocus == null || e.OldFocus == null || !(e.OldFocus is LayoutFloatingWindowControl))
		{
			SetIsActive();
		}
		base.OnPreviewGotKeyboardFocus(e);
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		if (e.OriginalSource is Visual)
		{
			DockingManager obj = ((DependencyObject)(object)(Visual)e.OriginalSource).FindVisualAncestor<DockingManager>();
			if (Model != null && Model.Root != null && Model.Root.Manager != null && ((object)Model.Root.Manager).Equals((object?)obj))
			{
				SetIsActive();
			}
		}
		base.OnPreviewMouseLeftButtonDown(e);
	}

	protected override void OnPreviewMouseRightButtonDown(MouseButtonEventArgs e)
	{
		if (e.OriginalSource is Visual)
		{
			DockingManager obj = ((DependencyObject)(object)(Visual)e.OriginalSource).FindVisualAncestor<DockingManager>();
			if (Model != null && Model.Root != null && Model.Root.Manager != null && ((object)Model.Root.Manager).Equals((object?)obj))
			{
				SetIsActive();
			}
		}
		base.OnPreviewMouseRightButtonDown(e);
	}

	internal void SetResourcesFromObject(FrameworkElement current)
	{
		while (current != null)
		{
			if (current.Resources.Count > 0)
			{
				DictionaryEntry[] array = new DictionaryEntry[current.Resources.Count];
				current.Resources.CopyTo(array, 0);
				array.ForEach(delegate(DictionaryEntry x)
				{
					try
					{
						if (base.Resources[x.Key] == null)
						{
							base.Resources.Add(x.Key, x.Value);
						}
					}
					catch (Exception)
					{
					}
				});
			}
			current = current.Parent as FrameworkElement;
		}
	}

	private void SetIsActive()
	{
		if (Model != null)
		{
			Model.IsActive = true;
		}
	}
}
