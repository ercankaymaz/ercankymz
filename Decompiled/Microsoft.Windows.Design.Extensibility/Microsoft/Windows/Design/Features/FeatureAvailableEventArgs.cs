using System;

namespace Microsoft.Windows.Design.Features;

public class FeatureAvailableEventArgs : EventArgs
{
	private Type _featureProviderType;

	public Type FeatureProviderType => _featureProviderType;

	public FeatureAvailableEventArgs(Type featureProviderType)
	{
		if ((object)featureProviderType == null)
		{
			throw new ArgumentNullException("featureProviderType");
		}
		_featureProviderType = featureProviderType;
	}
}
