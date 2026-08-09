using System;
using System.Collections.Generic;

namespace Microsoft.Windows.Design.Features;

public abstract class FeatureConnectorInformation
{
	public abstract Type FeatureConnectorType { get; }

	public abstract IEnumerable<Type> RequiredServices { get; }

	public abstract IEnumerable<Type> RequiredItems { get; }

	public abstract IEnumerable<Type> PendingServices { get; }

	public abstract IEnumerable<Type> PendingItems { get; }
}
