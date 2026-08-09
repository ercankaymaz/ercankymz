using System;
using System.Collections.Generic;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Services;

namespace Microsoft.Windows.Design.Model;

public abstract class ModelEvent
{
	public abstract Type EventType { get; }

	public abstract ICollection<string> Handlers { get; }

	public abstract bool IsBrowsable { get; }

	public abstract string Name { get; }

	public abstract ModelItem Parent { get; }

	public abstract IEnumerable<object> GetAttributes(Type attributeType);

	public virtual IEnumerable<object> GetAttributes(TypeIdentifier attributeTypeIdentifier)
	{
		Type type = Parent.Context.Services.GetRequiredService<ModelService>().InvokeResolveType(attributeTypeIdentifier);
		if ((object)type != null)
		{
			return GetAttributes(type);
		}
		return new object[0];
	}

	public virtual bool IsEventOfType(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		return type.IsAssignableFrom(EventType);
	}

	public virtual bool IsEventOfType(TypeIdentifier typeIdentifier)
	{
		Type type = Parent.Context.Services.GetRequiredService<ModelService>().InvokeResolveType(typeIdentifier);
		if ((object)type != null)
		{
			return IsEventOfType(type);
		}
		return false;
	}
}
