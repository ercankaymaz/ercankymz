using System;
using System.Collections.Generic;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Services;

public abstract class ModelService
{
	public abstract ModelItem Root { get; }

	public abstract event EventHandler<ModelChangedEventArgs> ModelChanged;

	public abstract ModelItem ConvertItem(ModelItem item);

	protected abstract ModelItem CreateItem(Type itemType, CreateOptions options, params object[] arguments);

	protected abstract ModelItem CreateItem(object item);

	protected abstract ModelItem CreateStaticMemberItem(Type type, string memberName);

	public abstract IEnumerable<ModelItem> Find(ModelItem startingItem, Type type);

	public abstract IEnumerable<ModelItem> Find(ModelItem startingItem, TypeIdentifier typeIdentifier);

	public abstract IEnumerable<ModelItem> Find(ModelItem startingItem, Predicate<Type> match);

	public ModelItem FromName(ModelItem scope, string name)
	{
		return FromName(scope, name, StringComparison.Ordinal);
	}

	public abstract ModelItem FromName(ModelItem scope, string name, StringComparison comparison);

	internal ModelItem InvokeCreateItem(Type itemType, CreateOptions options, params object[] arguments)
	{
		return CreateItem(itemType, options, arguments);
	}

	internal ModelItem InvokeCreateStaticMemberItem(Type type, string memberName)
	{
		return CreateStaticMemberItem(type, memberName);
	}

	internal ModelItem InvokeCreateItem(object item)
	{
		return CreateItem(item);
	}

	internal Type InvokeResolveType(TypeIdentifier typeIdentifier)
	{
		return ResolveType(typeIdentifier);
	}

	protected abstract Type ResolveType(TypeIdentifier typeIdentifier);
}
