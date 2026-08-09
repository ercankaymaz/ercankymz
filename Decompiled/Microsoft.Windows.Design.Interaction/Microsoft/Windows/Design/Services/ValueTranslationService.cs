using System;
using System.Collections.Generic;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Services;

public abstract class ValueTranslationService
{
	public abstract event EventHandler<PropertyInvalidatedEventArgs> PropertyInvalidated;

	public abstract IEnumerable<PropertyIdentifier> GetProperties(Type itemType);

	public abstract bool HasValueTranslation(Type itemType, PropertyIdentifier identifier);

	public abstract object TranslatePropertyValue(Type itemType, ModelItem item, PropertyIdentifier identifier, object value);

	public abstract void InvalidateProperty(ModelItem item, PropertyIdentifier identifier);
}
