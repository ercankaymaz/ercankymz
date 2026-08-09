using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Services;

namespace Microsoft.Windows.Design.Model;

public abstract class ModelItem : INotifyPropertyChanged
{
	public abstract ModelProperty Content { get; }

	public abstract EditingContext Context { get; }

	public abstract ModelEventCollection Events { get; }

	public abstract Type ItemType { get; }

	public abstract string Name { get; set; }

	public abstract ModelItem Parent { get; }

	public abstract ModelItem Root { get; }

	public abstract ModelPropertyCollection Properties { get; }

	public abstract ModelProperty Source { get; }

	public abstract ViewItem View { get; }

	public abstract event PropertyChangedEventHandler PropertyChanged;

	public abstract ModelEditingScope BeginEdit();

	public abstract ModelEditingScope BeginEdit(string description);

	public abstract IEnumerable<object> GetAttributes(Type attributeType);

	public virtual IEnumerable<object> GetAttributes(TypeIdentifier attributeTypeIdentifier)
	{
		Type type = Context.Services.GetRequiredService<ModelService>().InvokeResolveType(attributeTypeIdentifier);
		if ((object)type != null)
		{
			return GetAttributes(type);
		}
		return new object[0];
	}

	public abstract object GetCurrentValue();

	public virtual bool IsItemOfType(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		return type.IsAssignableFrom(ItemType);
	}

	public virtual bool IsItemOfType(TypeIdentifier typeIdentifier)
	{
		Type type = Context.Services.GetRequiredService<ModelService>().InvokeResolveType(typeIdentifier);
		if ((object)type != null)
		{
			return IsItemOfType(type);
		}
		return false;
	}
}
