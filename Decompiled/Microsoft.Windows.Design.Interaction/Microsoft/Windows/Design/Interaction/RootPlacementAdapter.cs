using System;

namespace Microsoft.Windows.Design.Interaction;

public abstract class RootPlacementAdapter : PlacementAdapter
{
	public override Type AdapterType => typeof(RootPlacementAdapter);
}
