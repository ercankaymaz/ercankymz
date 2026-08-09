using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using MS.Internal.Transforms;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace MS.Internal;

internal static class DesignerUtilities
{
	private const int DOUBLEPRECISION = 3;

	internal const int ROUNDINGPRECISION = 0;

	private static int _designerRoundingPrecision = 0;

	private static DateTime _toolboxTextDropTimeStamp = DateTime.Now;

	private static int s_dpi;

	internal static DateTime ToolboxTextDropTimeStamp
	{
		get
		{
			return _toolboxTextDropTimeStamp;
		}
		set
		{
			_toolboxTextDropTimeStamp = value;
		}
	}

	internal static int DesignerRoundingPrecision
	{
		get
		{
			return _designerRoundingPrecision;
		}
		set
		{
			_designerRoundingPrecision = value;
		}
	}

	public static int CapsDpi
	{
		get
		{
			if (s_dpi == 0)
			{
				IntPtr dC = SharedUnsafeNativeMethods.GetDC(IntPtr.Zero);
				s_dpi = SharedUnsafeNativeMethods.GetDeviceCaps(dC, 88);
			}
			return s_dpi;
		}
	}

	internal static void SetUseLayoutRounding(ModelItem selectedItem)
	{
		if (UseRounding(selectedItem, null))
		{
			DesignerRoundingPrecision = 0;
		}
		else
		{
			DesignerRoundingPrecision = 3;
		}
	}

	private static bool UseRounding(ModelItem selectedItem, Dictionary<ModelItem, bool> cache)
	{
		if (cache != null && cache.TryGetValue(selectedItem, out var value))
		{
			return value;
		}
		value = true;
		ModelProperty modelProperty = selectedItem.Properties.Find("UseLayoutRounding");
		while (modelProperty != null)
		{
			if (modelProperty.IsSet)
			{
				if (!(bool)modelProperty.ComputedValue)
				{
					value = false;
				}
				break;
			}
			cache?.Add(selectedItem, value);
			selectedItem = selectedItem.Parent;
			if (selectedItem != null && cache != null && cache.TryGetValue(selectedItem, out var value2))
			{
				return value2;
			}
			modelProperty = selectedItem?.Properties.Find("UseLayoutRounding");
		}
		return value;
	}

	internal static void SetUseLayoutRounding(IEnumerable<ModelItem> selectedItems)
	{
		bool flag = true;
		Dictionary<ModelItem, bool> cache = new Dictionary<ModelItem, bool>();
		foreach (ModelItem selectedItem in selectedItems)
		{
			flag = UseRounding(selectedItem, cache);
			if (!flag)
			{
				break;
			}
		}
		if (flag)
		{
			DesignerRoundingPrecision = 0;
		}
		else
		{
			DesignerRoundingPrecision = 3;
		}
	}

	internal static double GetInvertZoom(EditingContext context)
	{
		DesignerView dview = DesignerView.FromContext(context);
		return GetInvertZoom(dview);
	}

	internal static double GetInvertZoom(DesignerView dview)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		Transform zoomTransform = dview.GetZoomTransform();
		Vector scaleFromTransform = TransformUtil.GetScaleFromTransform(zoomTransform);
		if (((Vector)(ref scaleFromTransform)).X == 0.0)
		{
			return 0.0;
		}
		return 1.0 / ((Vector)(ref scaleFromTransform)).X;
	}

	internal static Vector GetZoomFactor(EditingContext context)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		DesignerView designerView = DesignerView.FromContext(context);
		if (designerView == null)
		{
			return new Vector(1.0, 1.0);
		}
		Transform zoomTransform = designerView.GetZoomTransform();
		return TransformUtil.GetScaleFromTransform(zoomTransform);
	}

	internal static Vector GetInvertZoomFactor(DesignerView dview)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		Transform zoomTransform = dview.GetZoomTransform();
		Vector scaleFromTransform = TransformUtil.GetScaleFromTransform(zoomTransform);
		return VectorUtilities.InvertScale(scaleFromTransform);
	}

	internal static Vector GetZoomRounding(EditingContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		DesignerView dview = DesignerView.FromContext(context);
		return GetZoomRounding(dview);
	}

	internal static double Round(double dimension)
	{
		return Math.Round(dimension, DesignerRoundingPrecision);
	}

	internal static Vector GetZoomRounding(DesignerView dview)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		Vector invertZoomFactor = GetInvertZoomFactor(dview);
		((Vector)(ref invertZoomFactor)).X = Math.Round(((Vector)(ref invertZoomFactor)).X, 3);
		((Vector)(ref invertZoomFactor)).Y = Math.Round(((Vector)(ref invertZoomFactor)).Y, 3);
		return invertZoomFactor;
	}

	public static Popup FindPopupRoot(DependencyObject element)
	{
		DependencyObject val = element;
		DependencyObject val2 = null;
		while (val != null)
		{
			val2 = val;
			FrameworkContentElement val3 = (FrameworkContentElement)(object)((val is FrameworkContentElement) ? val : null);
			val = ((val3 == null) ? ((!(val is Visual) && !(val is Visual3D)) ? null : VisualTreeHelper.GetParent(val)) : val3.Parent);
		}
		val = val2;
		if (val == null)
		{
			return null;
		}
		DependencyObject parent = LogicalTreeHelper.GetParent(val);
		return (Popup)(object)((parent is Popup) ? parent : null);
	}
}
