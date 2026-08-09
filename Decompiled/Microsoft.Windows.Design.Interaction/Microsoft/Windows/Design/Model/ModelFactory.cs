using System;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Services;

namespace Microsoft.Windows.Design.Model;

public static class ModelFactory
{
	public static ModelItem CreateItem(EditingContext context, Type itemType, params object[] arguments)
	{
		return CreateItem(context, itemType, CreateOptions.None, arguments);
	}

	public static ModelItem CreateItem(EditingContext context, Type itemType, CreateOptions options, params object[] arguments)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if ((object)itemType == null)
		{
			throw new ArgumentNullException("itemType");
		}
		if (!EnumValidator.IsValid(options))
		{
			throw new ArgumentOutOfRangeException("options");
		}
		ModelService requiredService = context.Services.GetRequiredService<ModelService>();
		return requiredService.InvokeCreateItem(itemType, options, arguments);
	}

	public static ModelItem CreateItem(EditingContext context, object item)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		ModelService requiredService = context.Services.GetRequiredService<ModelService>();
		return requiredService.InvokeCreateItem(item);
	}

	public static ModelItem CreateStaticMemberItem(EditingContext context, Type type, string memberName)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (memberName == null)
		{
			throw new ArgumentNullException("memberName");
		}
		ModelService requiredService = context.Services.GetRequiredService<ModelService>();
		return requiredService.InvokeCreateStaticMemberItem(type, memberName);
	}

	public static ModelItem CreateItem(EditingContext context, TypeIdentifier typeIdentifier, params object[] arguments)
	{
		return CreateItem(context, typeIdentifier, CreateOptions.None, arguments);
	}

	public static ModelItem CreateItem(EditingContext context, TypeIdentifier typeIdentifier, CreateOptions options, params object[] arguments)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Type type = context.Services.GetRequiredService<ModelService>().InvokeResolveType(typeIdentifier);
		if ((object)type != null)
		{
			ModelService requiredService = context.Services.GetRequiredService<ModelService>();
			return requiredService.InvokeCreateItem(type, options, arguments);
		}
		return null;
	}

	public static ModelItem CreateStaticMemberItem(EditingContext context, TypeIdentifier typeIdentifier, string memberName)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (memberName == null)
		{
			throw new ArgumentNullException("memberName");
		}
		Type type = context.Services.GetRequiredService<ModelService>().InvokeResolveType(typeIdentifier);
		if ((object)type != null)
		{
			ModelService requiredService = context.Services.GetRequiredService<ModelService>();
			return requiredService.InvokeCreateStaticMemberItem(type, memberName);
		}
		return null;
	}

	public static Type ResolveType(EditingContext context, TypeIdentifier typeIdentifier)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		return context.Services.GetRequiredService<ModelService>().InvokeResolveType(typeIdentifier);
	}
}
