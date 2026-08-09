using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal.Interaction;

internal class SizeRelativeToAdornerDesiredWidth : IAdornerPlacement
{
	private DependencyObject _relativeTo;

	private double _factor;

	private double _offset;

	internal SizeRelativeToAdornerDesiredWidth(double factor, double offset, DependencyObject relativeTo)
	{
		_relativeTo = relativeTo;
		_factor = factor;
		_offset = offset;
	}

	public IEnumerable<AdornerPlacementValue> GetSizeTerms(AdornerCoordinateSpace space, UIElement adorner, ViewItem adornedElement, Vector zoom, Size adornedElementFinalSize)
	{
		DependencyObject relativeTo = _relativeTo;
		UIElement eAdorner = (UIElement)(object)((relativeTo is UIElement) ? relativeTo : null);
		double desiredWidth;
		if (eAdorner != null)
		{
			Size desiredSize = eAdorner.DesiredSize;
			desiredWidth = ((Size)(ref desiredSize)).Width;
		}
		else
		{
			Size desiredSize2 = adorner.DesiredSize;
			desiredWidth = ((Size)(ref desiredSize2)).Width;
		}
		Vector adornerSizeScale = ScaledSpace.GetAdornerSizeScale(adorner);
		double width = (_factor * desiredWidth + _offset) * ((Vector)(ref adornerSizeScale)).X;
		yield return new AdornerPlacementValue(AdornerPlacementDimension.Width, width);
	}

	public IEnumerable<AdornerPlacementValue> GetPositionTerms(AdornerCoordinateSpace space, UIElement adorner, ViewItem adornedElement, Vector zoom, Size computedAdornerSize)
	{
		yield break;
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
