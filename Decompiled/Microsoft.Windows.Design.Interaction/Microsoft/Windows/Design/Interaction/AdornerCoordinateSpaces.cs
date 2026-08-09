using System;
using System.Windows;
using System.Windows.Media;
using MS.Internal;

namespace Microsoft.Windows.Design.Interaction;

public static class AdornerCoordinateSpaces
{
	private class RenderCoordinateSpace : AdornerCoordinateSpace
	{
		internal override Rect GetBoundingBox(ViewItem element)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return ElementUtilities.GetRenderSizeBounds(element);
		}

		protected virtual ViewItem GetLayoutView(ViewItem element)
		{
			return element;
		}

		internal override FlowDirection GetFlowDirection(ViewItem element)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			ViewItem layoutView = GetLayoutView(element);
			if (layoutView != null)
			{
				return layoutView.FlowDirection;
			}
			return (FlowDirection)0;
		}

		internal override Transform GetLayoutTransform(ViewItem element)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Invalid comparison between Unknown and I4
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			ViewItem layoutView = GetLayoutView(element);
			Transform result = LTR;
			if (layoutView != null && (int)layoutView.FlowDirection == 1)
			{
				result = RTL;
			}
			return result;
		}

		internal override Transform GetAncestorTransform(ViewItem element, UIElement ancestor)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (ancestor == null)
			{
				throw new ArgumentNullException("ancestor");
			}
			GeneralTransform obj = element.TransformToVisual((Visual)(object)ancestor);
			Transform val = (Transform)(object)((obj is Transform) ? obj : null);
			if (val == null)
			{
				val = Transform.Identity;
			}
			return val;
		}

		internal override Vector GetOrigin(ViewItem element)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return default(Vector);
		}

		public override string ToString()
		{
			return "Render";
		}
	}

	private class TransformAwareCoordinateSpace : RenderCoordinateSpace
	{
		internal override Rect GetBoundingBox(ViewItem element)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return ElementUtilities.GetSelectionFrameBounds(element);
		}

		public override string ToString()
		{
			return "TransformAware";
		}
	}

	private static AdornerCoordinateSpace _transform;

	[ThreadStatic]
	private static Transform _ltr;

	[ThreadStatic]
	private static Transform _rtl;

	private static Transform LTR
	{
		get
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			if (_ltr == null)
			{
				_ltr = (Transform)new ScaleTransform(1.0, 1.0);
			}
			return _ltr;
		}
	}

	public static AdornerCoordinateSpace Default
	{
		get
		{
			if (_transform == null)
			{
				_transform = new TransformAwareCoordinateSpace();
			}
			return _transform;
		}
	}

	private static Transform RTL
	{
		get
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			if (_rtl == null)
			{
				_rtl = (Transform)new ScaleTransform(-1.0, 1.0);
			}
			return _rtl;
		}
	}
}
