using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace MS.Internal.Transforms;

internal static class TransformUtil
{
	public static CanonicalTransform GetCanonicalTransformToAncestor(DependencyObject childOrDescendant, Visual root)
	{
		if (root == null)
		{
			throw new ArgumentNullException("root");
		}
		if (childOrDescendant == null)
		{
			throw new ArgumentNullException("childOrDescendant");
		}
		Transform transformToAncestor = GetTransformToAncestor(childOrDescendant, root);
		return new CanonicalTransform(transformToAncestor);
	}

	internal static Transform GetTransformToAncestor(DependencyObject childOrDescendant, Visual ancestor)
	{
		if (ancestor == null)
		{
			throw new ArgumentNullException("ancestor");
		}
		if (childOrDescendant == null)
		{
			throw new ArgumentNullException("childOrDescendant");
		}
		Visual val = (Visual)(object)((childOrDescendant is Visual) ? childOrDescendant : null);
		if (val == null)
		{
			return Transform.Identity;
		}
		object obj;
		if (!ancestor.IsAncestorOf((DependencyObject)(object)val))
		{
			obj = null;
		}
		else
		{
			GeneralTransform obj2 = val.TransformToAncestor(ancestor);
			obj = ((obj2 is Transform) ? obj2 : null);
		}
		Transform val2 = (Transform)obj;
		if (val2 == null)
		{
			val2 = Transform.Identity;
		}
		return val2;
	}

	internal static Transform GetTransformToAncestor(ViewItem childOrDescendant, Visual ancestor)
	{
		if (ancestor == null)
		{
			throw new ArgumentNullException("ancestor");
		}
		if (childOrDescendant == null)
		{
			throw new ArgumentNullException("childOrDescendant");
		}
		object obj;
		if (!childOrDescendant.IsDescendantOf(ancestor))
		{
			obj = null;
		}
		else
		{
			GeneralTransform obj2 = childOrDescendant.TransformToVisual(ancestor);
			obj = ((obj2 is Transform) ? obj2 : null);
		}
		Transform val = (Transform)obj;
		if (val == null)
		{
			val = Transform.Identity;
		}
		return val;
	}

	internal static Transform GetTransformToAncestor(ViewItem childOrDescendant, ViewItem ancestor)
	{
		if (ancestor == null)
		{
			throw new ArgumentNullException("ancestor");
		}
		if (childOrDescendant == null)
		{
			throw new ArgumentNullException("childOrDescendant");
		}
		object obj;
		if (!childOrDescendant.IsDescendantOf(ancestor))
		{
			obj = null;
		}
		else
		{
			GeneralTransform obj2 = childOrDescendant.TransformToView(ancestor);
			obj = ((obj2 is Transform) ? obj2 : null);
		}
		Transform val = (Transform)obj;
		if (val == null)
		{
			val = Transform.Identity;
		}
		return val;
	}

	internal static Transform GetParentTransformToAncestor(ViewItem item, Visual ancestor)
	{
		if (ancestor == null)
		{
			throw new ArgumentNullException("ancestor");
		}
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		ViewItem visualParent = item.VisualParent;
		Transform val;
		if (visualParent == null)
		{
			GeneralTransform obj = item.TransformToVisual(ancestor);
			val = (Transform)(object)((obj is Transform) ? obj : null);
		}
		else
		{
			try
			{
				GeneralTransform obj2 = visualParent.TransformToVisual(ancestor);
				val = (Transform)(object)((obj2 is Transform) ? obj2 : null);
			}
			catch
			{
				val = null;
			}
		}
		if (val == null)
		{
			val = Transform.Identity;
		}
		return val;
	}

	public static Transform GetTransformToDescendant(Visual parentVisual, Visual toVisual)
	{
		if (parentVisual == null)
		{
			throw new ArgumentNullException("parentVisual");
		}
		if (toVisual == null)
		{
			throw new ArgumentNullException("toVisual");
		}
		object obj;
		if (!parentVisual.IsAncestorOf((DependencyObject)(object)toVisual))
		{
			obj = null;
		}
		else
		{
			GeneralTransform obj2 = parentVisual.TransformToDescendant(toVisual);
			obj = ((obj2 is Transform) ? obj2 : null);
		}
		Transform val = (Transform)obj;
		if (val == null)
		{
			val = Transform.Identity;
		}
		return val;
	}

	public static Transform GetTransformToImmediateParent(DependencyObject child)
	{
		if (child == null)
		{
			throw new ArgumentNullException("child");
		}
		Visual val = (Visual)(object)((child is Visual) ? child : null);
		if (val == null)
		{
			return Transform.Identity;
		}
		Transform transform = VisualTreeHelper.GetTransform(val);
		if (transform == null)
		{
			return Transform.Identity;
		}
		return transform;
	}

	public static Transform GetTransformToImmediateParent(ViewItem child)
	{
		if (child == null)
		{
			throw new ArgumentNullException("child");
		}
		Transform transform = child.Transform;
		if (transform == null)
		{
			return Transform.Identity;
		}
		return transform;
	}

	public static CanonicalTransform GetCanonicalTransformToImmediateParent(DependencyObject child)
	{
		if (child == null)
		{
			throw new ArgumentNullException("child");
		}
		return new CanonicalTransform(GetTransformToImmediateParent(child));
	}

	public static Vector GetScaleFromTransform(Transform transform)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		if (transform == null)
		{
			throw new ArgumentNullException("transform");
		}
		Matrix value = transform.Value;
		if (((Matrix)(ref value)).M12 == 0.0 && ((Matrix)(ref value)).M21 == 0.0)
		{
			return new Vector(((Matrix)(ref value)).M11, ((Matrix)(ref value)).M22);
		}
		return new CanonicalTransform(value).Scale;
	}

	public static Vector GetScaleFromMatrix(Matrix transformMatrix)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (((Matrix)(ref transformMatrix)).M12 == 0.0 && ((Matrix)(ref transformMatrix)).M21 == 0.0)
		{
			return new Vector(((Matrix)(ref transformMatrix)).M11, ((Matrix)(ref transformMatrix)).M22);
		}
		return new CanonicalTransform(transformMatrix).Scale;
	}

	internal static Transform GetTransformToChild(Visual root, DependencyObject childOrDescendant)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		if (root == null)
		{
			throw new ArgumentNullException("root");
		}
		if (childOrDescendant == null)
		{
			throw new ArgumentNullException("childOrDescendant");
		}
		Visual val = (Visual)(object)((childOrDescendant is Visual) ? childOrDescendant : null);
		if (val == null)
		{
			return Transform.Identity;
		}
		object obj;
		if (!root.IsAncestorOf((DependencyObject)(object)val))
		{
			obj = null;
		}
		else
		{
			GeneralTransform obj2 = root.TransformToDescendant(val);
			obj = ((obj2 is Transform) ? obj2 : null);
		}
		Transform val2 = (Transform)obj;
		if (val2 == null)
		{
			val2 = (Transform)new MatrixTransform(Matrix.Identity);
		}
		return val2;
	}

	internal static Transform GetTransformToChild(Visual root, ViewItem childOrDescendant)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		if (root == null)
		{
			throw new ArgumentNullException("root");
		}
		if (childOrDescendant == null)
		{
			throw new ArgumentNullException("childOrDescendant");
		}
		GeneralTransform obj = childOrDescendant.TransformFromVisual(root);
		Transform val = (Transform)(object)((obj is Transform) ? obj : null);
		if (val == null)
		{
			val = (Transform)new MatrixTransform(Matrix.Identity);
		}
		return val;
	}

	internal static Transform GetRenderSizeTransformToDesignerView(DependencyObject itemView)
	{
		if (itemView == null)
		{
			throw new ArgumentNullException("itemView");
		}
		Visual val = (Visual)(object)((itemView is Visual) ? itemView : null);
		if (val == null)
		{
			return Transform.Identity;
		}
		DesignerView designerView = GetDesignerView((DependencyObject)(object)val);
		if (designerView == null)
		{
			return Transform.Identity;
		}
		return GetTransformToAncestor((DependencyObject)(object)val, (Visual)(object)designerView);
	}

	internal static Transform GetRenderSizeTransformToDesignerView(ModelItem item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		DesignerView designerView = GetDesignerView(item);
		if (designerView == null)
		{
			return Transform.Identity;
		}
		return GetTransformToAncestor(item.View, (Visual)(object)designerView);
	}

	internal static DesignerView GetDesignerView(ModelItem item)
	{
		EditingContext context = item.Context;
		DesignerView result = null;
		if (context != null)
		{
			result = DesignerView.FromContext(context);
		}
		return result;
	}

	internal static DesignerView GetDesignerView(DependencyObject visual)
	{
		DesignerView designerView = DesignerView.GetDesignerView(visual);
		while (designerView == null && visual != null)
		{
			visual = VisualTreeHelper.GetParent(visual);
			if (visual != null)
			{
				designerView = DesignerView.GetDesignerView(visual);
			}
		}
		return designerView;
	}

	internal static Transform GetTransformFromDesignerView(DependencyObject visualObject)
	{
		if (visualObject == null)
		{
			throw new ArgumentNullException("visualObject");
		}
		Visual val = (Visual)(object)((visualObject is Visual) ? visualObject : null);
		if (val == null)
		{
			return Transform.Identity;
		}
		DesignerView designerView = GetDesignerView((DependencyObject)(object)val);
		if (designerView == null)
		{
			return Transform.Identity;
		}
		return GetTransformToChild((Visual)(object)designerView, (DependencyObject)(object)val);
	}

	internal static Transform GetTransformFromDesignerView(ModelItem item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		DesignerView designerView = GetDesignerView(item);
		if (designerView == null)
		{
			return Transform.Identity;
		}
		return GetTransformToChild((Visual)(object)designerView, item.View);
	}

	public static Transform SafeInvert(Transform transform)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		return (Transform)new MatrixTransform(SafeInvert(transform.Value));
	}

	public static Matrix SafeInvert(Matrix m)
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		if (!((Matrix)(ref m)).HasInverse)
		{
			Vector val = new Vector(1.0, 0.0) * m;
			Vector val2 = new Vector(0.0, 1.0) * m;
			bool flag = ((Vector)(ref val)).LengthSquared > ((Vector)(ref val2)).LengthSquared;
			Vector val3 = (flag ? val : val2);
			if (((Vector)(ref val3)).LengthSquared < FloatingPointArithmetic.DistanceTolerance)
			{
				((Vector)(ref val3))._002Ector(1.0, 0.0);
			}
			Vector val4 = default(Vector);
			((Vector)(ref val4))._002Ector(0.0 - ((Vector)(ref val3)).Y, ((Vector)(ref val3)).X);
			val4 /= ((Vector)(ref val4)).Length;
			if (flag)
			{
				((Matrix)(ref m))._002Ector(((Vector)(ref val3)).X, ((Vector)(ref val3)).Y, ((Vector)(ref val4)).X, ((Vector)(ref val4)).Y, ((Matrix)(ref m)).OffsetX, ((Matrix)(ref m)).OffsetY);
			}
			else
			{
				((Matrix)(ref m))._002Ector(((Vector)(ref val4)).X, ((Vector)(ref val4)).Y, ((Vector)(ref val3)).X, ((Vector)(ref val3)).Y, ((Matrix)(ref m)).OffsetX, ((Matrix)(ref m)).OffsetY);
			}
		}
		((Matrix)(ref m)).Invert();
		return m;
	}

	public static Vector TranslateDesignerViewDelta(DependencyObject itemView, Vector delta)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (itemView == null)
		{
			throw new ArgumentNullException("itemView");
		}
		Transform renderSizeTransformToDesignerView = GetRenderSizeTransformToDesignerView(itemView);
		Transform val = SafeInvert(renderSizeTransformToDesignerView);
		Vector val2 = (Vector)((GeneralTransform)val).Transform((Point)delta);
		Vector val3 = (Vector)((GeneralTransform)val).Transform(default(Point));
		return val2 - val3;
	}

	public static Vector TranslateDesignerViewDelta(ModelItem item, Vector delta)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		Transform renderSizeTransformToDesignerView = GetRenderSizeTransformToDesignerView(item);
		Transform val = SafeInvert(renderSizeTransformToDesignerView);
		Vector val2 = (Vector)((GeneralTransform)val).Transform((Point)delta);
		Vector val3 = (Vector)((GeneralTransform)val).Transform(default(Point));
		return val2 - val3;
	}

	internal static CanonicalTransform GetCanonicalTransformToDesignerView(Visual visual)
	{
		if (visual == null)
		{
			throw new ArgumentNullException("visual");
		}
		DesignerView designerView = GetDesignerView((DependencyObject)(object)visual);
		if (designerView == null)
		{
			return new CanonicalTransform(Transform.Identity);
		}
		return new CanonicalTransform(GetTransformToAncestor((DependencyObject)(object)visual, (Visual)(object)designerView));
	}

	internal static CanonicalTransform GetCanonicalTransformToDesignerView(EditingContext context, ViewItem view)
	{
		if (view == null)
		{
			throw new ArgumentNullException("view");
		}
		DesignerView designerView = DesignerView.FromContext(context);
		if (designerView == null)
		{
			return new CanonicalTransform(Transform.Identity);
		}
		return new CanonicalTransform(GetTransformToAncestor(view, (Visual)(object)designerView));
	}

	internal static Transform GetSelectionFrameTransformToDesignerView(DependencyObject view)
	{
		DesignerView designerView = GetDesignerView(view);
		if (designerView == null)
		{
			return Transform.Identity;
		}
		return GetSelectionFrameTransformToParentVisual(view, (Visual)(object)designerView);
	}

	internal static Transform GetSelectionFrameTransformToDesignerView(EditingContext context, ViewItem view)
	{
		DesignerView designerView = DesignerView.FromContext(context);
		if (designerView == null)
		{
			return Transform.Identity;
		}
		return GetSelectionFrameTransformToParentVisual(view, (Visual)(object)designerView);
	}

	internal static Transform GetSelectionFrameTransformToParentVisual(DependencyObject view, Visual ancestorView)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		FrameworkElement val = (FrameworkElement)(object)((view is FrameworkElement) ? view : null);
		if (val != null && (val.LayoutTransform == null || val.LayoutTransform == Transform.Identity))
		{
			Transform transformToImmediateParent = GetTransformToImmediateParent(view);
			DependencyObject parent = VisualTreeHelper.GetParent(view);
			Rect selectionFrameBounds = ElementUtilities.GetSelectionFrameBounds(view);
			Vector val2 = default(Vector);
			((Vector)(ref val2))._002Ector(((Rect)(ref selectionFrameBounds)).X, ((Rect)(ref selectionFrameBounds)).Y);
			Matrix value = transformToImmediateParent.Value;
			((Matrix)(ref value)).Translate(((Vector)(ref val2)).X, ((Vector)(ref val2)).Y);
			if ((object)parent != ancestorView)
			{
				Transform transformToAncestor = GetTransformToAncestor(parent, ancestorView);
				Matrix val3 = value * transformToAncestor.Value;
				return (Transform)new MatrixTransform(val3);
			}
		}
		return GetTransformToAncestor(view, ancestorView);
	}

	internal static Transform GetSelectionFrameTransformToParentView(ViewItem view, ViewItem ancestorView)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		if (view.LayoutTransform == null || view.LayoutTransform == Transform.Identity)
		{
			Transform transformToImmediateParent = GetTransformToImmediateParent(view);
			ViewItem visualParent = view.VisualParent;
			if (visualParent != null)
			{
				Rect selectionFrameBounds = view.SelectionFrameBounds;
				Vector val = default(Vector);
				((Vector)(ref val))._002Ector(((Rect)(ref selectionFrameBounds)).X, ((Rect)(ref selectionFrameBounds)).Y);
				Matrix value = transformToImmediateParent.Value;
				((Matrix)(ref value)).Translate(((Vector)(ref val)).X, ((Vector)(ref val)).Y);
				if (ancestorView != visualParent)
				{
					Transform transformToAncestor = GetTransformToAncestor(visualParent, ancestorView);
					Matrix val2 = value * transformToAncestor.Value;
					return (Transform)new MatrixTransform(val2);
				}
				return (Transform)new MatrixTransform(value);
			}
		}
		return GetTransformToAncestor(view, ancestorView);
	}

	internal static Transform GetSelectionFrameTransformToParentVisual(ViewItem view, Visual ancestorView)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		if (view != null && (view.LayoutTransform == null || view.LayoutTransform == Transform.Identity))
		{
			Transform transformToImmediateParent = GetTransformToImmediateParent(view);
			Rect selectionFrameBounds = view.SelectionFrameBounds;
			Vector val = default(Vector);
			((Vector)(ref val))._002Ector(((Rect)(ref selectionFrameBounds)).X, ((Rect)(ref selectionFrameBounds)).Y);
			Matrix value = transformToImmediateParent.Value;
			((Matrix)(ref value)).Translate(((Vector)(ref val)).X, ((Vector)(ref val)).Y);
			object obj = ((view.VisualParent == null) ? DesignerView.GetDesignerView((DependencyObject)(object)ancestorView) : view.VisualParent.PlatformObject);
			if (obj != ancestorView)
			{
				Transform parentTransformToAncestor = GetParentTransformToAncestor(view, ancestorView);
				Matrix val2 = value * parentTransformToAncestor.Value;
				return (Transform)new MatrixTransform(val2);
			}
		}
		return GetTransformToAncestor(view, ancestorView);
	}

	internal static bool IsNotRotateSkew(Transform transform)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		if (transform == null || transform == Transform.Identity)
		{
			return true;
		}
		Matrix value = transform.Value;
		return ((Matrix)(ref value)).M12 == 0.0 && ((Matrix)(ref value)).M21 == 0.0;
	}
}
