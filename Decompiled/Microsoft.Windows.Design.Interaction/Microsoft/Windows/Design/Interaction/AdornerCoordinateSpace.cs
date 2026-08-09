using System.Windows;
using System.Windows.Media;

namespace Microsoft.Windows.Design.Interaction;

public abstract class AdornerCoordinateSpace
{
	internal AdornerCoordinateSpace()
	{
	}

	internal abstract Rect GetBoundingBox(ViewItem element);

	internal abstract FlowDirection GetFlowDirection(ViewItem element);

	internal abstract Transform GetLayoutTransform(ViewItem element);

	internal abstract Transform GetAncestorTransform(ViewItem element, UIElement ancestor);

	internal abstract Vector GetOrigin(ViewItem element);
}
