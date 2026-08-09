using System.Windows;
using System.Windows.Media;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal;

internal static class HitTestHelper
{
	internal static ViewHitTestResult HitTest(ViewItem reference, Point point, ViewHitTestFilterCallback filterCallback)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		return reference.HitTest(filterCallback, null, (HitTestParameters)new PointHitTestParameters(point));
	}

	internal static HitTestResult HitTest(Visual reference, Point point, bool ignoreDisabled, HitTestFilterCallback filterCallback)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		return HitTest(reference, (HitTestParameters)new PointHitTestParameters(point), ignoreDisabled, filterCallback);
	}

	public static HitTestResult HitTest(Visual reference, HitTestParameters hitTestParameters, bool ignoreDisabled, HitTestFilterCallback filterCallback)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		HitTestResult hitTestResult = null;
		HitTestResultCallback val = (HitTestResultCallback)delegate(HitTestResult hitItemsResult)
		{
			hitTestResult = hitItemsResult;
			return (HitTestResultBehavior)0;
		};
		HitTestFilterCallback val2 = (HitTestFilterCallback)delegate(DependencyObject hit)
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			UIElement val3 = (UIElement)(object)((hit is UIElement) ? hit : null);
			if (val3 != null)
			{
				if (!val3.IsVisible || !val3.IsHitTestVisible)
				{
					return (HitTestFilterBehavior)0;
				}
				if (ignoreDisabled && !val3.IsEnabled)
				{
					return (HitTestFilterBehavior)0;
				}
			}
			HitTestFilterBehavior result = (HitTestFilterBehavior)6;
			if (filterCallback != null)
			{
				result = filterCallback.Invoke(hit);
			}
			return result;
		};
		VisualTreeHelper.HitTest(reference, val2, val, hitTestParameters);
		return hitTestResult;
	}
}
