using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace MS.Internal.Features;

internal class ParentAdapterFeatureConnector : FeatureConnector<ParentAdapter>
{
	public ParentAdapterFeatureConnector(FeatureManager manager)
		: base(manager)
	{
		ModelParent.GetImplementation(base.Context).FeatureManager = base.Manager;
	}
}
