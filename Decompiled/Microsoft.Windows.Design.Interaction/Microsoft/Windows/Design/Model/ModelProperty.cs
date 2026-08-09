using System;
using System.Collections.Generic;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Services;

namespace Microsoft.Windows.Design.Model;

public abstract class ModelProperty
{
	public abstract ModelItemCollection Collection { get; }

	public abstract object ComputedValue { get; set; }

	public abstract Type AttachedOwnerType { get; }

	public abstract object DefaultValue { get; }

	public abstract ModelItemDictionary Dictionary { get; }

	public abstract bool IsBrowsable { get; }

	public abstract bool IsCollection { get; }

	public abstract bool IsDictionary { get; }

	public abstract bool IsReadOnly { get; }

	public abstract bool IsSet { get; }

	public abstract bool IsAttached { get; }

	public abstract ModelItem Value { get; }

	public abstract string Name { get; }

	public abstract ModelItem Parent { get; }

	public abstract Type PropertyType { get; }

	public abstract void ClearValue();

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

	public virtual bool IsPropertyOfType(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		return type.IsAssignableFrom(PropertyType);
	}

	public virtual bool IsPropertyOfType(TypeIdentifier typeIdentifier)
	{
		Type type = Parent.Context.Services.GetRequiredService<ModelService>().InvokeResolveType(typeIdentifier);
		if ((object)type != null)
		{
			return IsPropertyOfType(type);
		}
		return false;
	}

	public abstract ModelItem SetValue(object value);

	public static bool operator ==(ModelProperty first, ModelProperty second)
	{
		if (object.ReferenceEquals(first, second))
		{
			return true;
		}
		if (object.ReferenceEquals(first, null) || object.ReferenceEquals(second, null))
		{
			return false;
		}
		if (first.Parent == second.Parent)
		{
			return first.Name.Equals(second.Name);
		}
		return false;
	}

	public static bool operator !=(ModelProperty first, ModelProperty second)
	{
		if (object.ReferenceEquals(first, second))
		{
			return false;
		}
		if (object.ReferenceEquals(first, null) || object.ReferenceEquals(second, null))
		{
			return true;
		}
		if (first.Parent == second.Parent)
		{
			return !first.Name.Equals(second.Name);
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(obj, this))
		{
			return true;
		}
		ModelProperty modelProperty = obj as ModelProperty;
		if (object.ReferenceEquals(modelProperty, null))
		{
			return false;
		}
		if (modelProperty.Parent != Parent)
		{
			return false;
		}
		return modelProperty.Name.Equals(Name);
	}

	public override int GetHashCode()
	{
		return Parent.GetHashCode() ^ Name.GetHashCode();
	}
}
