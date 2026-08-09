using System;
using System.Windows;
using System.Windows.Media;
using MS.Internal.Interaction;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

public static class AdornerProperties
{
	public static readonly DependencyProperty LayoutProperty = DependencyProperty.RegisterAttached("Layout", typeof(AdornerLayout), typeof(AdornerProperties), (PropertyMetadata)new FrameworkPropertyMetadata((object)TransformAwareAdornerLayout.Instance, (FrameworkPropertyMetadataOptions)8, new PropertyChangedCallback(OnPropertyChanged)), new ValidateValueCallback(OnValidateNonNull));

	public static readonly DependencyProperty ModelProperty = DependencyProperty.RegisterAttached("Model", typeof(ModelItem), typeof(AdornerProperties), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)40, new PropertyChangedCallback(OnModelChanged)));

	public static readonly DependencyProperty OrderProperty = DependencyProperty.RegisterAttached("Order", typeof(AdornerOrder), typeof(AdornerProperties), new PropertyMetadata((object)AdornerOrder.Content, new PropertyChangedCallback(OnOrderChanged)), new ValidateValueCallback(OnValidateNonNull));

	public static readonly DependencyProperty RenderTransformProperty = DependencyProperty.RegisterAttached("RenderTransform", typeof(Transform), typeof(AdornerProperties), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)8, (PropertyChangedCallback)null));

	public static readonly DependencyProperty TaskProperty = DependencyProperty.RegisterAttached("Task", typeof(Task), typeof(AdornerProperties), new PropertyMetadata((object)null, new PropertyChangedCallback(OnPropertyChanged)));

	public static AdornerLayout GetLayout(DependencyObject adorner)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		return (AdornerLayout)adorner.GetValue(LayoutProperty);
	}

	public static void SetLayout(DependencyObject adorner, AdornerLayout value)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		adorner.SetValue(LayoutProperty, (object)value);
	}

	public static ModelItem GetModel(DependencyObject adorner)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		return (ModelItem)adorner.GetValue(ModelProperty);
	}

	public static void SetModel(DependencyObject adorner, ModelItem value)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		adorner.SetValue(ModelProperty, (object)value);
	}

	public static AdornerOrder GetOrder(DependencyObject adorner)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		return (AdornerOrder)adorner.GetValue(OrderProperty);
	}

	public static void SetOrder(DependencyObject adorner, AdornerOrder value)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		adorner.SetValue(OrderProperty, (object)value);
	}

	public static Task GetTask(DependencyObject adorner)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		return (Task)adorner.GetValue(TaskProperty);
	}

	public static void SetTask(DependencyObject adorner, Task value)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		adorner.SetValue(TaskProperty, (object)value);
	}

	public static ViewItem GetView(DependencyObject adorner)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		return GetModel(adorner)?.View;
	}

	public static Transform GetRenderTransform(DependencyObject adorner)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		return (Transform)adorner.GetValue(RenderTransformProperty);
	}

	public static void SetRenderTransform(DependencyObject adorner, Transform value)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		adorner.SetValue(RenderTransformProperty, (object)value);
	}

	private static void OnOrderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		UIElement val = (UIElement)(object)((sender is UIElement) ? sender : null);
		if (val != null && VisualTreeHelper.GetParent((DependencyObject)(object)val) is AdornerLayer adornerLayer)
		{
			adornerLayer.OnOrderChanged(val);
		}
		GetLayout(sender).AdornerPropertyChanged(sender, args);
	}

	private static void OnModelChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		GetLayout(sender).AdornerPropertyChanged(sender, args);
	}

	private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (((DependencyPropertyChangedEventArgs)(ref args)).Property == LayoutProperty)
		{
			((AdornerLayout)((DependencyPropertyChangedEventArgs)(ref args)).OldValue).AdornerPropertyChanged(sender, args);
			((AdornerLayout)((DependencyPropertyChangedEventArgs)(ref args)).NewValue).AdornerPropertyChanged(sender, args);
			UIElement val = (UIElement)(object)((sender is UIElement) ? sender : null);
			if (val != null && VisualTreeHelper.GetParent((DependencyObject)(object)val) is AdornerLayer adornerLayer)
			{
				adornerLayer.OnLayoutChanged(val);
			}
		}
		else
		{
			GetLayout(sender).AdornerPropertyChanged(sender, args);
		}
	}

	private static bool OnValidateNonNull(object value)
	{
		return value != null;
	}
}
