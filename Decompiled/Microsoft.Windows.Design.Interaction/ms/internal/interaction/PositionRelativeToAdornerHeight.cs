using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal.Interaction;

internal class PositionRelativeToAdornerHeight : IAdornerPlacement
{
	private DependencyObject _relativeTo;

	private double _factor;

	private double _offset;

	internal PositionRelativeToAdornerHeight(double factor, double offset, DependencyObject relativeTo)
	{
		_relativeTo = relativeTo;
		_factor = factor;
		_offset = offset;
	}

	public IEnumerable<AdornerPlacementValue> GetSizeTerms(AdornerCoordinateSpace space, UIElement adorner, ViewItem adornedElement, Vector zoom, Size adornedElementFinalSize)
	{
		yield break;
	}

	public IEnumerable<AdornerPlacementValue> GetPositionTerms(AdornerCoordinateSpace space, UIElement adorner, ViewItem adornedElement, Vector zoom, Size computedAdornerSize)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		DependencyObject relativeTo = _relativeTo;
		UIElement element = (UIElement)(object)((relativeTo is UIElement) ? relativeTo : null);
		if (element != null)
		{
			computedAdornerSize = element.DesiredSize;
		}
		Vector adornerSizeScale = ScaledSpace.GetAdornerPositionScale(adorner, zoom);
		double top = _factor * ((Size)(ref computedAdornerSize)).Height * ((Vector)(ref adornerSizeScale)).Y + _offset;
		yield return new AdornerPlacementValue(AdornerPlacementDimension.Top, top);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.AdornerPlacement_ToString, new object[3]
		{
			GetType().Name,
			_factor,
			_offset
		});
	}
}
