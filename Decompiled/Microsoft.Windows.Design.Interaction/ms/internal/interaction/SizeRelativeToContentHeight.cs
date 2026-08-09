using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal.Interaction;

internal class SizeRelativeToContentHeight : IAdornerPlacement
{
	private ViewItem _relativeTo;

	private double _factor;

	private double _offset;

	internal SizeRelativeToContentHeight(double factor, double offset, ViewItem relativeTo)
	{
		_relativeTo = relativeTo;
		_factor = factor;
		_offset = offset;
	}

	public IEnumerable<AdornerPlacementValue> GetSizeTerms(AdornerCoordinateSpace space, UIElement adorner, ViewItem adornedElement, Vector zoom, Size adornedElementFinalSize)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		double height = 0.0;
		ViewItem element = ((!(_relativeTo == null)) ? _relativeTo : adornedElement);
		if (element != null)
		{
			Rect boundingBox = space.GetBoundingBox(element);
			height = ((Rect)(ref boundingBox)).Height;
		}
		Vector targetSizeScale = ScaledSpace.GetTargetSizeScale(adorner, zoom);
		height = (_factor * height + _offset) * ((Vector)(ref targetSizeScale)).Y;
		yield return new AdornerPlacementValue(AdornerPlacementDimension.Height, height);
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
