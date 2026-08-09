using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal.Interaction;

internal class PositionRelativeToContentWidth : IAdornerPlacement
{
	private ViewItem _relativeTo;

	private double _factor;

	private double _offset;

	internal PositionRelativeToContentWidth(double factor, double offset, ViewItem relativeTo)
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
		double width = 0.0;
		ViewItem element = ((!(_relativeTo == null)) ? _relativeTo : adornedElement);
		if (element != null)
		{
			Rect boundingBox = space.GetBoundingBox(element);
			width = ((Rect)(ref boundingBox)).Width;
		}
		Vector targetPositionScale = ScaledSpace.GetTargetPositionScale(adorner);
		double left = (_factor * width + _offset) * ((Vector)(ref targetPositionScale)).X;
		yield return new AdornerPlacementValue(AdornerPlacementDimension.Left, left);
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
