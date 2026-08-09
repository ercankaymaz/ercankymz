using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Media;
using MS.Internal.Transforms;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal.Interaction;

internal class TransformAwareAdornerLayout : BaseAdornerLayout
{
	private class RTLAdornerTransformGroup
	{
		private static string AutomationID = typeof(RTLAdornerTransformGroup).AssemblyQualifiedName;

		private static Matrix _rtlTransformStub = new Matrix(-1.0, 0.0, 0.0, 1.0, 0.0, 0.0);

		public static Transform Create(UIElement element, double widthOfControl)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			Transform val = Unwrap(element);
			TransformGroup val2 = new TransformGroup();
			AutomationProperties.SetAutomationId((DependencyObject)(object)val2, AutomationID);
			if (val != null)
			{
				val2.Children.Add(val);
			}
			Matrix rtlTransformStub = _rtlTransformStub;
			((Matrix)(ref rtlTransformStub)).OffsetX = widthOfControl;
			val2.Children.Add((Transform)new MatrixTransform(TransformUtil.SafeInvert(rtlTransformStub)));
			return (Transform)(object)val2;
		}

		public static Transform Unwrap(UIElement element)
		{
			Transform renderTransform = element.RenderTransform;
			TransformGroup val = (TransformGroup)(object)((renderTransform is TransformGroup) ? renderTransform : null);
			if (val != null && val.Children.Count > 0 && AutomationProperties.GetAutomationId((DependencyObject)(object)val) == AutomationID)
			{
				return val.Children[0];
			}
			return element.RenderTransform;
		}
	}

	internal static TransformAwareAdornerLayout Instance = new TransformAwareAdornerLayout();

	internal static readonly DependencyProperty DesignerElementScalingFactorWithZoom = DependencyProperty.RegisterAttached("ScaleToRoot", typeof(Vector), typeof(TransformAwareAdornerLayout), new PropertyMetadata((object)new Vector(1.0, 1.0), (PropertyChangedCallback)null, new CoerceValueCallback(MakeZoomPositive)));

	internal static object MakeZoomPositive(DependencyObject d, object baseValue)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (baseValue != null)
		{
			Vector currentScale = (Vector)baseValue;
			return VectorUtilities.RemoveMirror(currentScale);
		}
		return baseValue;
	}

	private void SetupTransform(UIElement adorner)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		LayoutCache cache = BaseAdornerLayout.GetCache((DependencyObject)(object)adorner);
		CanonicalTransform canonicalTransform = new CanonicalTransform(cache.ElementToDesignerViewTransformMatrix);
		CanonicalTransform canonicalTransform2 = new CanonicalTransform(cache.DesignerViewToViewportMatrix);
		Vector val = VectorUtilities.Scale(canonicalTransform.Scale, canonicalTransform2.Scale);
		((DependencyObject)adorner).SetValue(DesignerElementScalingFactorWithZoom, (object)val);
		CanonicalTransform canonicalTransform3 = new CanonicalTransform(canonicalTransform);
		canonicalTransform3.Scale = VectorUtilities.Unscale(new Vector((double)Math.Sign(((Vector)(ref val)).X), (double)Math.Sign(((Vector)(ref val)).Y)), canonicalTransform2.Scale);
		if (adorner is AdornerPanel adornerPanel)
		{
			if (!adornerPanel.UseMirrorTransform)
			{
				canonicalTransform3.Scale = VectorUtilities.Unscale(new Vector(1.0, 1.0), canonicalTransform2.Scale);
			}
			else
			{
				adornerPanel.IsMirroredTransform = ((Vector)(ref val)).X < 0.0;
			}
		}
		Transform renderTransform = AdornerProperties.GetRenderTransform((DependencyObject)(object)adorner);
		Transform val2 = (Transform)(object)canonicalTransform3.ToTransform();
		if (renderTransform != null)
		{
			TransformGroup val3 = new TransformGroup();
			val3.Children.Add(val2);
			val3.Children.Add(renderTransform);
			val2 = (Transform)(object)val3;
		}
		adorner.RenderTransform = val2;
	}

	public override void Arrange(UIElement adorner)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		LayoutCache cache = BaseAdornerLayout.GetCache((DependencyObject)(object)adorner);
		Matrix elementToDesignerViewTransformMatrix = cache.ElementToDesignerViewTransformMatrix;
		Matrix designerViewToViewportMatrix = cache.DesignerViewToViewportMatrix;
		if (!MathUtilities.AreClose(elementToDesignerViewTransformMatrix, cache.ElementToDesignerViewTransformMatrix) || !MathUtilities.AreClose(designerViewToViewportMatrix, cache.DesignerViewToViewportMatrix))
		{
			SetupTransform(adorner);
		}
		Vector scale = (Vector)((DependencyObject)adorner).GetValue(DesignerElementScalingFactorWithZoom);
		ViewItem view = AdornerProperties.GetView((DependencyObject)(object)adorner);
		SetAdornerBounds(adorner, view, new Point(0.0, 0.0), scale);
		if (view != null && cache.PlatformObjectHashCode != 0 && cache.PlatformObjectHashCode != view.PlatformObject.GetHashCode())
		{
			cache.View = view;
			cache.RenderSize = view.RenderSize;
			cache.PlatformObjectHashCode = view.PlatformObject.GetHashCode();
		}
	}

	public override Size ArrangeChildren(FrameworkElement parent, UIElementCollection internalChildren, Size finalSize)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		if (!(parent is AdornerPanel { Model: var model } adornerPanel))
		{
			return finalSize;
		}
		ViewItem adornedElement = model?.View;
		Vector val = (Vector)((DependencyObject)parent).GetValue(DesignerElementScalingFactorWithZoom);
		Rect val3 = default(Rect);
		foreach (UIElement internalChild in internalChildren)
		{
			UIElement val2 = internalChild;
			((DependencyObject)val2).SetValue(DesignerElementScalingFactorWithZoom, (object)val);
			AdornerPlacementCollection currentPlacements = AdornerPanel.GetCurrentPlacements(val2);
			currentPlacements.ComputePlacement(AdornerCoordinateSpaces.Default, val2, adornedElement, new Vector(1.0, 1.0), finalSize);
			((Rect)(ref val3))._002Ector((Point)currentPlacements.TopLeft, (Size)currentPlacements.Size);
			double width = ((Rect)(ref val3)).Width;
			Size renderSize = val2.RenderSize;
			((Rect)(ref val3)).Width = BaseAdornerLayout.ValidateDouble(width, ((Size)(ref renderSize)).Width);
			double height = ((Rect)(ref val3)).Height;
			Size renderSize2 = val2.RenderSize;
			((Rect)(ref val3)).Height = BaseAdornerLayout.ValidateDouble(height, ((Size)(ref renderSize2)).Height);
			val2.Arrange(val3);
			if (val2 is FrameworkElement)
			{
				if (adornerPanel.IsMirroredTransform)
				{
					((DependencyObject)val2).SetValue(FrameworkElement.FlowDirectionProperty, (object)(FlowDirection)1);
					val2.RenderTransform = RTLAdornerTransformGroup.Create(val2, ((Rect)(ref val3)).Width);
				}
				else
				{
					val2.RenderTransform = RTLAdornerTransformGroup.Unwrap(val2);
					((DependencyObject)val2).SetValue(FrameworkElement.FlowDirectionProperty, (object)(FlowDirection)0);
				}
			}
		}
		return finalSize;
	}

	public override bool EvaluateLayout(DesignerView view, UIElement adorner)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		LayoutCache cache = BaseAdornerLayout.GetCache((DependencyObject)(object)adorner);
		Matrix elementToDesignerViewTransformMatrix = cache.ElementToDesignerViewTransformMatrix;
		Matrix designerViewToViewportMatrix = cache.DesignerViewToViewportMatrix;
		bool result = base.EvaluateLayout(view, adorner);
		if (!MathUtilities.AreClose(elementToDesignerViewTransformMatrix, cache.ElementToDesignerViewTransformMatrix) || !MathUtilities.AreClose(designerViewToViewportMatrix, cache.DesignerViewToViewportMatrix))
		{
			SetupTransform(adorner);
		}
		return result;
	}

	private void SetAdornerBounds(UIElement childAdorner, ViewItem adornedElement, Point location, Vector scale)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		AdornerCoordinateSpace adornerCoordinateSpace = AdornerCoordinateSpaces.Default;
		Rect val;
		if (adornedElement != null)
		{
			val = adornerCoordinateSpace.GetBoundingBox(adornedElement);
		}
		else
		{
			Size desiredSize = childAdorner.DesiredSize;
			val = default(Rect);
			((Rect)(ref val)).Width = ((Size)(ref desiredSize)).Width;
			((Rect)(ref val)).Height = ((Size)(ref desiredSize)).Height;
		}
		((Rect)(ref val)).X = ((Point)(ref location)).X;
		((Rect)(ref val)).Y = ((Point)(ref location)).Y;
		((Rect)(ref val)).Width = ((Rect)(ref val)).Width * Math.Abs(((Vector)(ref scale)).X);
		((Rect)(ref val)).Height = ((Rect)(ref val)).Height * Math.Abs(((Vector)(ref scale)).Y);
		childAdorner.Arrange(val);
	}
}
