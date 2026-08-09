using System;
using MS.Internal.Features;
using Microsoft.Windows.Design.Features;

namespace Microsoft.Windows.Design.Interaction;

[FeatureConnector(typeof(AdapterFeatureConnector))]
public abstract class Adapter : FeatureProvider
{
	public abstract Type AdapterType { get; }
}
