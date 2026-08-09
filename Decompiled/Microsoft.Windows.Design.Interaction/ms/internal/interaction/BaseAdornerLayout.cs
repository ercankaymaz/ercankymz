using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using MS.Internal.Transforms;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;
using Microsoft.Windows.Design.Services;

namespace MS.Internal.Interaction;

internal abstract class BaseAdornerLayout : AdornerLayout
{
	protected class LayoutCache
	{
		internal Size RenderSize;

		internal Matrix ElementToDesignerViewTransformMatrix;

		internal Matrix DesignerViewToViewportMatrix;

		internal ModelItem Model;

		internal ViewItem View;

		internal DesignerView DesignerView;

		internal int PlatformObjectHashCode;

		internal Vector CalculateZoom()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return TransformUtil.GetScaleFromMatrix(DesignerViewToViewportMatrix);
		}
	}

	private static readonly DependencyProperty CachedVisibilityProperty = DependencyProperty.RegisterAttached("CachedVisibility", typeof(Visibility), typeof(BaseAdornerLayout));

	private static readonly DependencyProperty OriginalVisibilityProperty = DependencyProperty.RegisterAttached("OriginalVisibility", typeof(Visibility), typeof(BaseAdornerLayout));

	private static readonly string RenderTransformProperty = "RenderTransform";

	protected static readonly DependencyProperty CacheProperty = DependencyProperty.RegisterAttached("Cache", typeof(LayoutCache), typeof(BaseAdornerLayout));

	public override void AdornerPropertyChanged(DependencyObject adorner, DependencyPropertyChangedEventArgs args)
	{
		if (((DependencyPropertyChangedEventArgs)(ref args)).Property == AdornerProperties.ModelProperty)
		{
			LayoutCache cache = GetCache(adorner);
			if (cache.DesignerView != null)
			{
				EnsureActualValues(adorner);
			}
		}
	}

	public override bool EvaluateLayout(DesignerView view, UIElement adorner)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		if (view == null)
		{
			throw new ArgumentNullException("view");
		}
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		GetCache((DependencyObject)(object)adorner).DesignerView = view;
		EnsureActualValues((DependencyObject)(object)adorner);
		ViewItem viewItem = AdornerProperties.GetView((DependencyObject)(object)adorner);
		if (IsAdornableElement(view, viewItem))
		{
			object obj = ((DependencyObject)adorner).ReadLocalValue(OriginalVisibilityProperty);
			if (obj != DependencyProperty.UnsetValue)
			{
				((DependencyObject)adorner).SetValue(UIElement.VisibilityProperty, obj);
				((DependencyObject)adorner).ClearValue(OriginalVisibilityProperty);
			}
		}
		else
		{
			if (viewItem != null)
			{
				if (((DependencyObject)adorner).ReadLocalValue(OriginalVisibilityProperty) == DependencyProperty.UnsetValue)
				{
					((DependencyObject)adorner).SetValue(OriginalVisibilityProperty, (object)adorner.Visibility);
				}
				if (adorner.IsVisible)
				{
					adorner.Visibility = (Visibility)2;
				}
			}
			viewItem = null;
		}
		CheckAndInvalidateAdorner(view, viewItem, adorner);
		return true;
	}

	private static void CheckAndInvalidateAdorner(DesignerView view, ViewItem element, UIElement adorner)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Invalid comparison between Unknown and I4
		if (view.Context == null)
		{
			return;
		}
		Matrix value = TransformUtil.GetTransformToImmediateParent((DependencyObject)(object)view).Value;
		Matrix val;
		Size val2;
		if (element != null)
		{
			val = TransformUtil.GetSelectionFrameTransformToDesignerView(view.Context, element).Value;
			val2 = element.RenderSize;
		}
		else
		{
			val = Matrix.Identity;
			val2 = Size.Empty;
		}
		LayoutCache cache = GetCache((DependencyObject)(object)adorner);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (element != null && !MathUtilities.AreClose(val2, cache.RenderSize))
		{
			flag = true;
		}
		if (element != null && !MathUtilities.AreClose(val, cache.ElementToDesignerViewTransformMatrix))
		{
			flag = true;
			flag2 = true;
		}
		if (!MathUtilities.AreClose(value, cache.DesignerViewToViewportMatrix))
		{
			flag = true;
			flag2 = true;
		}
		if (element != null && !element.IsVisible)
		{
			ViewItem view2 = view.Context.Services.GetRequiredService<ModelService>().Root.View;
			ViewItem viewItem = element;
			while (viewItem != view2 && viewItem != null)
			{
				if ((int)viewItem.Visibility == 2)
				{
					flag3 = true;
					break;
				}
				viewItem = viewItem.VisualParent;
			}
		}
		if (flag3)
		{
			object obj = ((DependencyObject)adorner).ReadLocalValue(UIElement.VisibilityProperty);
			object obj2 = ((DependencyObject)adorner).ReadLocalValue(CachedVisibilityProperty);
			if (obj2 == DependencyProperty.UnsetValue)
			{
				if (obj != DependencyProperty.UnsetValue)
				{
					((DependencyObject)adorner).SetValue(CachedVisibilityProperty, obj);
				}
				else
				{
					((DependencyObject)adorner).SetValue(CachedVisibilityProperty, (object)(Visibility)0);
				}
				adorner.Visibility = (Visibility)2;
			}
		}
		else
		{
			object obj3 = ((DependencyObject)adorner).ReadLocalValue(CachedVisibilityProperty);
			if (obj3 != DependencyProperty.UnsetValue)
			{
				((DependencyObject)adorner).SetValue(UIElement.VisibilityProperty, obj3);
			}
			((DependencyObject)adorner).ClearValue(CachedVisibilityProperty);
		}
		if (!flag && !flag2)
		{
			return;
		}
		if (element != null)
		{
			cache.RenderSize = val2;
			cache.ElementToDesignerViewTransformMatrix = val;
			cache.PlatformObjectHashCode = element.PlatformObject.GetHashCode();
		}
		cache.DesignerViewToViewportMatrix = value;
		cache.DesignerView = view;
		DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)(object)adorner);
		UIElement val3 = (UIElement)(object)((parent is UIElement) ? parent : null);
		if (flag)
		{
			adorner.InvalidateMeasure();
			if (val3 != null)
			{
				val3.InvalidateMeasure();
			}
		}
		if (flag2)
		{
			adorner.InvalidateVisual();
			if (val3 != null)
			{
				val3.InvalidateVisual();
			}
		}
	}

	protected static LayoutCache GetCache(DependencyObject element)
	{
		LayoutCache layoutCache = (LayoutCache)element.GetValue(CacheProperty);
		if (layoutCache == null)
		{
			layoutCache = new LayoutCache();
			element.SetValue(CacheProperty, (object)layoutCache);
		}
		return layoutCache;
	}

	private static bool IsAdornableElement(DesignerView view, ViewItem element)
	{
		if (element != null && element.IsVisible)
		{
			return element.IsDescendantOf((Visual)(object)view);
		}
		return false;
	}

	public override void Measure(UIElement adorner, Size constraint)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		Size val = default(Size);
		((Size)(ref val))._002Ector(double.PositiveInfinity, double.PositiveInfinity);
		adorner.Measure(val);
	}

	public override bool IsAssociated(UIElement adorner, ModelItem item)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (AdornerProperties.GetModel((DependencyObject)(object)adorner) == item)
		{
			return true;
		}
		return false;
	}

	private static void EnsureActualValues(DependencyObject adorner)
	{
		ViewItem view = AdornerProperties.GetView(adorner);
		ModelItem model = AdornerProperties.GetModel(adorner);
		LayoutCache cache = GetCache(adorner);
		if (cache.Model != model || cache.View != view)
		{
			if (cache.Model != null)
			{
				cache.Model.PropertyChanged -= OnModelItemPropertyChanged;
			}
			cache.Model = model;
			cache.View = view;
			if (model != null)
			{
				model.PropertyChanged += OnModelItemPropertyChanged;
			}
		}
	}

	private static void OnModelItemPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == RenderTransformProperty && sender is ModelItem modelItem && modelItem.View != null)
		{
			DesignerView designerView = DesignerView.FromContext(modelItem.Context);
			if (designerView != null)
			{
				((UIElement)designerView).InvalidateArrange();
			}
		}
	}

	internal static double ValidateDouble(double requested, double fallback)
	{
		if (double.IsNaN(requested) || double.IsInfinity(requested))
		{
			return fallback;
		}
		return requested;
	}
}
