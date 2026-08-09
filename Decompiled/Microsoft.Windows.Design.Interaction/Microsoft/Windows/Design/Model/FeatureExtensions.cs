using System;
using System.Collections.Generic;
using Microsoft.Windows.Design.Features;

namespace Microsoft.Windows.Design.Model;

public static class FeatureExtensions
{
	public static IEnumerable<FeatureProvider> CreateFeatureProviders(this FeatureManager source, Type featureProviderType, ModelItem item)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if ((object)featureProviderType == null)
		{
			throw new ArgumentNullException("featureProviderType");
		}
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		return source.CreateFeatureProviders(featureProviderType, item.ItemType);
	}

	public static IEnumerable<FeatureProvider> CreateFeatureProviders(this FeatureManager source, Type featureProviderType, ModelItem item, Predicate<Type> match)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if ((object)featureProviderType == null)
		{
			throw new ArgumentNullException("featureProviderType");
		}
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		return source.CreateFeatureProviders(featureProviderType, item.ItemType, match);
	}
}
