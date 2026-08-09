using System;
using MS.Internal.Features;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Services;

namespace Microsoft.Windows.Design.Model;

[FeatureConnector(typeof(DesignModeValueProviderConnector))]
public class DesignModeValueProvider : FeatureProvider
{
	private PropertyIdentifierCollection _properties;

	public PropertyIdentifierCollection Properties
	{
		get
		{
			if (_properties == null)
			{
				_properties = new PropertyIdentifierCollection();
			}
			return _properties;
		}
	}

	public virtual object TranslatePropertyValue(ModelItem item, PropertyIdentifier identifier, object value)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (identifier.IsEmpty)
		{
			throw new ArgumentNullException("identifier");
		}
		return value;
	}

	protected void InvalidateProperty(ModelItem item, PropertyIdentifier property)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		ValueTranslationService requiredService = item.Context.Services.GetRequiredService<ValueTranslationService>();
		requiredService.InvalidateProperty(item, property);
	}
}
