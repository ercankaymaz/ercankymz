using Microsoft.Windows.Design.Features;

namespace Microsoft.Windows.Design.Model;

public abstract class DefaultInitializer : FeatureProvider
{
	public virtual void InitializeDefaults(ModelItem item)
	{
	}

	public virtual void InitializeDefaults(ModelItem item, EditingContext context)
	{
		InitializeDefaults(item);
	}
}
