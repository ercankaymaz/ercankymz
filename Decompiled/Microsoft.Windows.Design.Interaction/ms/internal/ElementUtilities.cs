using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using MS.Internal.Transforms;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal;

internal static class ElementUtilities
{
	private sealed class DepthFirstFrameworkElementCollection : IEnumerable
	{
		private FrameworkElement root;

		public DepthFirstFrameworkElementCollection(FrameworkElement root)
		{
			this.root = root;
		}

		public IEnumerator GetEnumerator()
		{
			return new DepthFirstFrameworkElementEnumerator(root);
		}
	}

	private sealed class DepthFirstFrameworkElementEnumerator : IEnumerator
	{
		private FrameworkElement root;

		private bool isBeforeFirstElement = true;

		private Stack stack = new Stack();

		public FrameworkElement Current
		{
			get
			{
				//IL_0025: Unknown result type (might be due to invalid IL or missing references)
				//IL_002b: Expected O, but got Unknown
				IEnumerator enumerator = (IEnumerator)stack.Peek();
				if (enumerator == null)
				{
					throw new InvalidOperationException("ExceptionStringTable.ElementUtilitiesEnumeratorOutOfRangeError");
				}
				return (FrameworkElement)enumerator.Current;
			}
		}

		object IEnumerator.Current => Current;

		public DepthFirstFrameworkElementEnumerator(FrameworkElement root)
		{
			if (root == null)
			{
				throw new ArgumentNullException("root");
			}
			this.root = root;
		}

		public void Reset()
		{
			isBeforeFirstElement = true;
			stack.Clear();
		}

		public bool MoveNext()
		{
			bool result = false;
			if (isBeforeFirstElement)
			{
				isBeforeFirstElement = false;
				ArrayList arrayList = new ArrayList(1);
				arrayList.Add(root);
				IEnumerator enumerator = arrayList.GetEnumerator();
				enumerator.MoveNext();
				stack.Push(enumerator);
				result = true;
			}
			else
			{
				IEnumerator enumerator2 = (IEnumerator)stack.Peek();
				while (enumerator2 != null)
				{
					object current = enumerator2.Current;
					DependencyObject val = (DependencyObject)((current is DependencyObject) ? current : null);
					IEnumerator enumerator3 = ((val != null) ? LogicalTreeHelper.GetChildren(val).GetEnumerator() : null);
					if (enumerator3 != null && enumerator3.MoveNext())
					{
						stack.Push(enumerator3);
						enumerator2 = enumerator3;
					}
					else
					{
						while (enumerator2 != null && !enumerator2.MoveNext())
						{
							stack.Pop();
							enumerator2 = ((stack.Count > 0) ? ((IEnumerator)stack.Peek()) : null);
						}
					}
					if (enumerator2 != null && enumerator2.Current is FrameworkElement)
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}
	}

	private sealed class DepthFirstVisualCollection : IEnumerable
	{
		private Visual root;

		public DepthFirstVisualCollection(Visual root)
		{
			this.root = root;
		}

		public IEnumerator GetEnumerator()
		{
			return new DepthFirstVisualEnumerator(root);
		}
	}

	private sealed class DepthFirstVisualEnumerator : IEnumerator
	{
		private Visual root;

		private Stack stack = new Stack();

		public Visual Current
		{
			get
			{
				//IL_001c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0022: Expected O, but got Unknown
				Visual result = null;
				IEnumerator enumerator = (IEnumerator)stack.Peek();
				if (enumerator != null)
				{
					result = (Visual)enumerator.Current;
				}
				return result;
			}
		}

		object IEnumerator.Current => Current;

		public DepthFirstVisualEnumerator(Visual root)
		{
			if (root == null)
			{
				throw new ArgumentNullException("root");
			}
			this.root = root;
		}

		public void Reset()
		{
			stack.Clear();
		}

		public bool MoveNext()
		{
			bool flag = false;
			if (stack.Count < 1)
			{
				ArrayList arrayList = new ArrayList(1);
				arrayList.Add(root);
				IEnumerator enumerator = arrayList.GetEnumerator();
				flag = enumerator.MoveNext();
				stack.Push(enumerator);
			}
			else
			{
				IEnumerator enumerator2 = (IEnumerator)stack.Peek();
				object current = enumerator2.Current;
				Visual val = (Visual)((current is Visual) ? current : null);
				int childrenCount = VisualTreeHelper.GetChildrenCount((DependencyObject)(object)val);
				if (childrenCount > 0)
				{
					IList<Visual> list = new List<Visual>(childrenCount);
					for (int i = 0; i < childrenCount; i++)
					{
						DependencyObject child = VisualTreeHelper.GetChild((DependencyObject)(object)val, i);
						Visual val2 = (Visual)(object)((child is Visual) ? child : null);
						if (val2 != null)
						{
							list.Add(val2);
						}
					}
					IEnumerator enumerator3 = list.GetEnumerator();
					flag = enumerator3.MoveNext();
					stack.Push(enumerator3);
				}
				else if (enumerator2.MoveNext())
				{
					flag = true;
				}
				else
				{
					while (stack.Count > 1 && !flag)
					{
						stack.Pop();
						flag = ((IEnumerator)stack.Peek()).MoveNext();
					}
				}
			}
			return flag;
		}
	}

	public static IEnumerable GetElementTree(FrameworkElement rootElement)
	{
		return new DepthFirstFrameworkElementCollection(rootElement);
	}

	public static IEnumerable GetVisualTree(Visual rootVisual)
	{
		return new DepthFirstVisualCollection(rootVisual);
	}

	public static FrameworkElement FindElement(FrameworkElement element, string id)
	{
		DependencyObject obj = LogicalTreeHelper.FindLogicalNode((DependencyObject)(object)element, id);
		return (FrameworkElement)(object)((obj is FrameworkElement) ? obj : null);
	}

	public static FrameworkElement FindElementInVisualTree(Visual root, string id)
	{
		FrameworkElement val = (FrameworkElement)(object)((root is FrameworkElement) ? root : null);
		if (val != null && val.Name == id)
		{
			return val;
		}
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount((DependencyObject)(object)root); i++)
		{
			DependencyObject child = VisualTreeHelper.GetChild((DependencyObject)(object)root, i);
			Visual val2 = (Visual)(object)((child is Visual) ? child : null);
			if (val2 != null)
			{
				FrameworkElement val3 = FindElementInVisualTree(val2, id);
				if (val3 != null)
				{
					return val3;
				}
			}
		}
		return null;
	}

	public static bool HasAncestorOfType(FrameworkElement rootElement, FrameworkElement element, Type type)
	{
		FrameworkElement ancestorOfType = GetAncestorOfType(rootElement, element, type);
		return ancestorOfType != null;
	}

	internal static FrameworkElement GetAncestorOfType(FrameworkElement rootElement, FrameworkElement element, Type type)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (type.IsInstanceOfType(element))
		{
			return element;
		}
		if (rootElement == element)
		{
			return null;
		}
		FrameworkElement result = null;
		FrameworkElement val = ((rootElement == null) ? ((FrameworkElement)null) : ((FrameworkElement)rootElement.Parent));
		DependencyObject parent = element.Parent;
		element = (FrameworkElement)(object)((parent is FrameworkElement) ? parent : null);
		while (element != null && element != val)
		{
			if (type.IsInstanceOfType(element))
			{
				result = element;
				break;
			}
			DependencyObject parent2 = element.Parent;
			element = (FrameworkElement)(object)((parent2 is FrameworkElement) ? parent2 : null);
		}
		return result;
	}

	public static bool HasAncestorOfTypeInVisualTree(ViewItem rootElement, ViewItem element, Type type)
	{
		ViewItem ancestorOfTypeInVisualTree = GetAncestorOfTypeInVisualTree(rootElement, element, type);
		return ancestorOfTypeInVisualTree != null;
	}

	internal static ViewItem GetAncestorOfTypeInVisualTree(ViewItem rootElement, ViewItem element, Type type)
	{
		if (type.IsAssignableFrom(element.ItemType))
		{
			return element;
		}
		if (rootElement == element)
		{
			return null;
		}
		ViewItem result = null;
		ViewItem viewItem = ((rootElement != null) ? rootElement.LogicalParent : null);
		element = element.LogicalParent;
		while (element != null && element != viewItem)
		{
			if (type.IsAssignableFrom(element.ItemType))
			{
				result = element;
				break;
			}
			element = element.VisualParent;
		}
		return result;
	}

	public static bool IsDescendant(DependencyObject parent, DependencyObject descendant)
	{
		if (parent == null)
		{
			return false;
		}
		while (descendant != null)
		{
			if (descendant == parent)
			{
				return true;
			}
			descendant = LogicalTreeHelper.GetParent(descendant);
		}
		return false;
	}

	public static bool IsDescendant(ViewItem parent, ViewItem descendant)
	{
		if (parent == null)
		{
			return false;
		}
		while (descendant != null)
		{
			if (descendant == parent)
			{
				return true;
			}
			descendant = descendant.LogicalParent;
		}
		return false;
	}

	public static DependencyObject GetLeastCommonAncestor(DependencyObject firstDescendant, DependencyObject secondDescendant, DependencyObject root)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		DependencyObject val = firstDescendant;
		ArrayList arrayList = new ArrayList();
		while (val != null && LogicalTreeHelper.GetParent(val) != null)
		{
			arrayList.Add(val);
			val = LogicalTreeHelper.GetParent(val);
		}
		val = secondDescendant;
		ArrayList arrayList2 = new ArrayList();
		while (val != null && LogicalTreeHelper.GetParent(val) != null)
		{
			arrayList2.Add(val);
			val = LogicalTreeHelper.GetParent(val);
		}
		DependencyObject result = root;
		while (arrayList.Count > 0 && arrayList2.Count > 0 && arrayList[arrayList.Count - 1] == arrayList2[arrayList2.Count - 1])
		{
			result = (DependencyObject)arrayList[arrayList.Count - 1];
			arrayList.RemoveAt(arrayList.Count - 1);
			arrayList2.RemoveAt(arrayList2.Count - 1);
		}
		return result;
	}

	public static Rect GetTransformedBounds(Visual visual, Visual ancestor)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		FrameworkElement val = (FrameworkElement)(object)((visual is FrameworkElement) ? visual : null);
		Rect val2 = default(Rect);
		if (val != null)
		{
			val2 = GetActualBoundsCore(val, inParent: false);
		}
		else
		{
			UIElement val3 = (UIElement)(object)((visual is UIElement) ? visual : null);
			if (val3 != null)
			{
				((Rect)(ref val2)).Size = val3.RenderSize;
			}
			else
			{
				val2 = VisualTreeHelper.GetContentBounds(visual);
			}
		}
		Transform transformToAncestor = TransformUtil.GetTransformToAncestor((DependencyObject)(object)visual, ancestor);
		return ((GeneralTransform)transformToAncestor).TransformBounds(val2);
	}

	public static Rect GetLayoutRect(DependencyObject element)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		FrameworkElement val = (FrameworkElement)(object)((element is FrameworkElement) ? element : null);
		if (val != null)
		{
			return LayoutInformation.GetLayoutSlot(val);
		}
		Rect renderSizeBounds = GetRenderSizeBounds(element);
		((Rect)(ref renderSizeBounds)).Location = default(Point);
		return renderSizeBounds;
	}

	public static Rect GetElementRelativeSelectionFrameBounds(DependencyObject element)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		FrameworkElement val = (FrameworkElement)(object)((element is FrameworkElement) ? element : null);
		if (val != null)
		{
			return GetActualBoundsCore(val, inParent: false);
		}
		Rect renderSizeBounds = GetRenderSizeBounds(element);
		((Rect)(ref renderSizeBounds)).Location = default(Point);
		return renderSizeBounds;
	}

	public static Rect GetActualBounds(FrameworkElement element)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return GetActualBoundsCore(element, inParent: false);
	}

	private static Rect GetActualBoundsInParent(FrameworkElement element)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return GetActualBoundsCore(element, inParent: true);
	}

	private static Rect GetActualBoundsCore(FrameworkElement element, bool inParent)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Invalid comparison between Unknown and I4
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected I4, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected I4, but got Unknown
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		Rect layoutSlot = LayoutInformation.GetLayoutSlot(element);
		HorizontalAlignment horizontalAlignment = element.HorizontalAlignment;
		VerticalAlignment verticalAlignment = element.VerticalAlignment;
		Thickness margin = element.Margin;
		Point val = default(Point);
		Point val2 = default(Point);
		Size renderSize = ((UIElement)element).RenderSize;
		double num = ((Size)(ref renderSize)).Width;
		Size renderSize2 = ((UIElement)element).RenderSize;
		double num2 = ((Size)(ref renderSize2)).Height;
		double num3 = element.Width;
		double num4 = element.Height;
		if (double.IsNaN(num3))
		{
			num3 = (((int)horizontalAlignment == 3) ? Math.Max(0.0, ((Rect)(ref layoutSlot)).Width - ((Thickness)(ref margin)).Left - ((Thickness)(ref margin)).Right) : num);
		}
		if (double.IsNaN(num4))
		{
			num4 = (((int)verticalAlignment == 3) ? Math.Max(0.0, ((Rect)(ref layoutSlot)).Height - ((Thickness)(ref margin)).Top - ((Thickness)(ref margin)).Bottom) : num2);
		}
		if (!double.IsNaN(element.MinWidth))
		{
			num = Math.Max(num, element.MinWidth);
			num3 = Math.Max(num3, element.MinWidth);
		}
		if (!double.IsNaN(element.MaxWidth))
		{
			num = Math.Min(num, element.MaxWidth);
			num3 = Math.Min(num3, element.MaxWidth);
		}
		if (!double.IsNaN(element.MinHeight))
		{
			num2 = Math.Max(num2, element.MinHeight);
			num4 = Math.Max(num4, element.MinHeight);
		}
		if (!double.IsNaN(element.MaxHeight))
		{
			num2 = Math.Min(num2, element.MaxHeight);
			num4 = Math.Min(num4, element.MaxHeight);
		}
		HorizontalAlignment val3 = horizontalAlignment;
		switch ((int)val3)
		{
		case 0:
			((Point)(ref val)).X = ((Rect)(ref layoutSlot)).Left + ((Thickness)(ref margin)).Left;
			((Point)(ref val2)).X = ((Rect)(ref layoutSlot)).Left + ((Thickness)(ref margin)).Left;
			break;
		case 1:
			((Point)(ref val)).X = (((Rect)(ref layoutSlot)).Left + ((Thickness)(ref margin)).Left + ((Rect)(ref layoutSlot)).Right - ((Thickness)(ref margin)).Right) / 2.0 - num3 / 2.0;
			((Point)(ref val2)).X = (((Rect)(ref layoutSlot)).Left + ((Thickness)(ref margin)).Left + ((Rect)(ref layoutSlot)).Right - ((Thickness)(ref margin)).Right) / 2.0 - num3 / 2.0;
			break;
		case 2:
			((Point)(ref val)).X = ((Rect)(ref layoutSlot)).Right - ((Thickness)(ref margin)).Right - num;
			((Point)(ref val2)).X = ((Rect)(ref layoutSlot)).Right - ((Thickness)(ref margin)).Right - num3;
			break;
		case 3:
			((Point)(ref val)).X = Math.Max(((Rect)(ref layoutSlot)).Left + ((Thickness)(ref margin)).Left, (((Rect)(ref layoutSlot)).Left + ((Thickness)(ref margin)).Left + ((Rect)(ref layoutSlot)).Right - ((Thickness)(ref margin)).Right) / 2.0 - num / 2.0);
			((Point)(ref val2)).X = Math.Max(((Rect)(ref layoutSlot)).Left + ((Thickness)(ref margin)).Left, (((Rect)(ref layoutSlot)).Left + ((Thickness)(ref margin)).Left + ((Rect)(ref layoutSlot)).Right - ((Thickness)(ref margin)).Right) / 2.0 - num3 / 2.0);
			break;
		}
		VerticalAlignment val4 = verticalAlignment;
		switch ((int)val4)
		{
		case 0:
			((Point)(ref val)).Y = ((Rect)(ref layoutSlot)).Top + ((Thickness)(ref margin)).Top;
			((Point)(ref val2)).Y = ((Rect)(ref layoutSlot)).Top + ((Thickness)(ref margin)).Top;
			break;
		case 1:
			((Point)(ref val)).Y = (((Rect)(ref layoutSlot)).Top + ((Thickness)(ref margin)).Top + ((Rect)(ref layoutSlot)).Bottom - ((Thickness)(ref margin)).Bottom) / 2.0 - num4 / 2.0;
			((Point)(ref val2)).Y = (((Rect)(ref layoutSlot)).Top + ((Thickness)(ref margin)).Top + ((Rect)(ref layoutSlot)).Bottom - ((Thickness)(ref margin)).Bottom) / 2.0 - num4 / 2.0;
			break;
		case 2:
			((Point)(ref val)).Y = ((Rect)(ref layoutSlot)).Bottom - ((Thickness)(ref margin)).Bottom - num2;
			((Point)(ref val2)).Y = ((Rect)(ref layoutSlot)).Bottom - ((Thickness)(ref margin)).Bottom - num4;
			break;
		case 3:
			((Point)(ref val)).Y = Math.Max(((Rect)(ref layoutSlot)).Top + ((Thickness)(ref margin)).Top, (((Rect)(ref layoutSlot)).Top + ((Thickness)(ref margin)).Top + ((Rect)(ref layoutSlot)).Bottom - ((Thickness)(ref margin)).Bottom) / 2.0 - num2 / 2.0);
			((Point)(ref val2)).Y = Math.Max(((Rect)(ref layoutSlot)).Top + ((Thickness)(ref margin)).Top, (((Rect)(ref layoutSlot)).Top + ((Thickness)(ref margin)).Top + ((Rect)(ref layoutSlot)).Bottom - ((Thickness)(ref margin)).Bottom) / 2.0 - num4 / 2.0);
			break;
		}
		if (inParent)
		{
			return new Rect(((Point)(ref val2)).X, ((Point)(ref val2)).Y, num3, num4);
		}
		return new Rect(((Point)(ref val2)).X - ((Point)(ref val)).X, ((Point)(ref val2)).Y - ((Point)(ref val)).Y, num3, num4);
	}

	public static Rect GetRenderSizeBounds(DependencyObject element)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		Rect result = default(Rect);
		Visual val = (Visual)(object)((element is Visual) ? element : null);
		if (val == null)
		{
			return result;
		}
		((Rect)(ref result)).Location = (Point)VisualTreeHelper.GetOffset(val);
		UIElement val2 = (UIElement)(object)((val is UIElement) ? val : null);
		if (val2 == null)
		{
			Rect contentBounds = VisualTreeHelper.GetContentBounds(val);
			Size size = ((Rect)(ref contentBounds)).Size;
			if (((Size)(ref size)).Width <= 0.0 && ((Size)(ref size)).Height <= 0.0)
			{
				DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)(object)val);
				Visual val3 = (Visual)(object)((parent is Visual) ? parent : null);
				if (val3 != null)
				{
					Transform transformToDescendant = TransformUtil.GetTransformToDescendant(val3, val);
					Rect selectionFrameBounds = GetSelectionFrameBounds((DependencyObject)(object)val3);
					Rect val4 = ((GeneralTransform)transformToDescendant).TransformBounds(selectionFrameBounds);
					size = ((Rect)(ref val4)).Size;
				}
			}
			((Rect)(ref result)).Size = size;
		}
		else
		{
			((Rect)(ref result)).Size = val2.RenderSize;
		}
		return result;
	}

	public static Rect GetRenderSizeBounds(ViewItem view)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return view.RenderSizeBounds;
	}

	public static Rect GetSelectionFrameBounds(DependencyObject element)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		FrameworkElement val = (FrameworkElement)(object)((element is FrameworkElement) ? element : null);
		if (val != null && (val.LayoutTransform == null || val.LayoutTransform == Transform.Identity))
		{
			return GetActualBoundsInParent(val);
		}
		return GetRenderSizeBounds(element);
	}

	public static Rect GetSelectionFrameBounds(ViewItem view)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (view == null)
		{
			return default(Rect);
		}
		return view.SelectionFrameBounds;
	}

	public static Vector ComputePositionDeltaInTarget(DesignerView dview, ViewItem target, Point startPosition, Point currentPosition)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		GeneralTransform val = target.TransformFromVisual((Visual)(object)dview);
		Point val2 = val.Transform(startPosition);
		Point val3 = val.Transform(currentPosition);
		return val3 - val2;
	}
}
