using System.Collections.Generic;
using System.Windows;

namespace Microsoft.Windows.Design.Interaction;

public interface IAdornerPlacement
{
	IEnumerable<AdornerPlacementValue> GetSizeTerms(AdornerCoordinateSpace space, UIElement adorner, ViewItem view, Vector zoom, Size viewFinalSize);

	IEnumerable<AdornerPlacementValue> GetPositionTerms(AdornerCoordinateSpace space, UIElement adorner, ViewItem view, Vector zoom, Size computedAdornerSize);
}
