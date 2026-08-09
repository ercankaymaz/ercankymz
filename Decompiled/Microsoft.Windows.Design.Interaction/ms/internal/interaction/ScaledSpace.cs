using System.Windows;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal.Interaction;

internal static class ScaledSpace
{
	internal static Vector GetTargetSizeScale(UIElement adorner, Vector scaleFactor)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		object obj = ((DependencyObject)adorner).ReadLocalValue(TransformAwareAdornerLayout.DesignerElementScalingFactorWithZoom);
		if (obj != DependencyProperty.UnsetValue)
		{
			return (Vector)obj;
		}
		Vector result = default(Vector);
		((Vector)(ref result))._002Ector(1.0, 1.0);
		if (adorner != null)
		{
			switch (AdornerPanel.GetHorizontalStretch(adorner))
			{
			case AdornerStretch.None:
				((Vector)(ref result)).X = 1.0;
				break;
			case AdornerStretch.Stretch:
				((Vector)(ref result)).X = 1.0 / ((Vector)(ref scaleFactor)).X;
				break;
			}
			switch (AdornerPanel.GetVerticalStretch(adorner))
			{
			case AdornerStretch.None:
				((Vector)(ref result)).Y = 1.0;
				break;
			case AdornerStretch.Stretch:
				((Vector)(ref result)).Y = 1.0 / ((Vector)(ref scaleFactor)).Y;
				break;
			}
		}
		return result;
	}

	internal static Vector GetTargetPositionScale(UIElement adorner)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		object obj = ((DependencyObject)adorner).ReadLocalValue(TransformAwareAdornerLayout.DesignerElementScalingFactorWithZoom);
		if (obj != DependencyProperty.UnsetValue)
		{
			return (Vector)obj;
		}
		return new Vector(1.0, 1.0);
	}

	internal static Vector GetAdornerSizeScale(UIElement adorner)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		return new Vector(1.0, 1.0);
	}

	internal static Vector GetAdornerPositionScale(UIElement adorner, Vector scaleFactor)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		object obj = ((DependencyObject)adorner).ReadLocalValue(TransformAwareAdornerLayout.DesignerElementScalingFactorWithZoom);
		if (obj != DependencyProperty.UnsetValue)
		{
			((Vector)(ref scaleFactor))._002Ector(1.0, 1.0);
		}
		Vector result = default(Vector);
		if (adorner != null)
		{
			switch (AdornerPanel.GetHorizontalStretch(adorner))
			{
			case AdornerStretch.None:
				((Vector)(ref result)).X = ((Vector)(ref scaleFactor)).X;
				break;
			case AdornerStretch.Stretch:
				((Vector)(ref result)).X = ((Vector)(ref scaleFactor)).X;
				break;
			}
			switch (AdornerPanel.GetVerticalStretch(adorner))
			{
			case AdornerStretch.None:
				((Vector)(ref result)).Y = ((Vector)(ref scaleFactor)).Y;
				break;
			case AdornerStretch.Stretch:
				((Vector)(ref result)).Y = ((Vector)(ref scaleFactor)).Y;
				break;
			}
		}
		return result;
	}
}
