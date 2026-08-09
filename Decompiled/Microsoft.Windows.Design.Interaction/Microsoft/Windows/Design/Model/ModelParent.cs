using System;
using System.Collections.Generic;
using System.Globalization;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Interaction;

namespace Microsoft.Windows.Design.Model;

public static class ModelParent
{
	internal class ItemParentImplementationService
	{
		private FeatureManager _featureManager;

		internal FeatureManager FeatureManager
		{
			set
			{
				_featureManager = value;
			}
		}

		internal ItemParentImplementationService()
		{
		}

		internal bool CanParent(ModelItem parent, Type childType, ModelItem childItem, out ModelItem redirectedParent)
		{
			redirectedParent = null;
			if (_featureManager == null)
			{
				return false;
			}
			using (IEnumerator<FeatureProvider> enumerator = _featureManager.CreateFeatureProviders(typeof(ParentAdapter), parent).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ParentAdapter parentAdapter = (ParentAdapter)enumerator.Current;
					redirectedParent = parentAdapter.RedirectParent(parent, childType);
					if (redirectedParent == null)
					{
						throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_InvalidRedirectParent, new object[1] { parentAdapter.GetType().Name }));
					}
					if (redirectedParent.Equals(childItem))
					{
						return false;
					}
					ModelItem modelItem = redirectedParent;
					ViewItem logicalParent = GetLogicalParent(modelItem);
					if (childItem != null)
					{
						while (logicalParent != null)
						{
							if (logicalParent.Equals(childItem.View))
							{
								return false;
							}
							modelItem = modelItem.Parent;
							logicalParent = GetLogicalParent(modelItem);
						}
					}
					if (childItem != null && parentAdapter.IsParent(redirectedParent, childItem))
					{
						return true;
					}
					if (redirectedParent != parent)
					{
						parent = redirectedParent;
						return CanParent(parent, childType, childItem, out redirectedParent);
					}
					return parentAdapter.CanParent(parent, childType);
				}
			}
			return false;
		}

		internal ModelItem FindParent(Type childType, ModelItem startingItem, ModelItem childItem)
		{
			if (_featureManager == null)
			{
				return null;
			}
			for (ModelItem modelItem = startingItem; modelItem != null; modelItem = modelItem.Parent)
			{
				if (CanParent(modelItem, childType, childItem, out var redirectedParent))
				{
					return redirectedParent;
				}
			}
			return null;
		}

		private static ViewItem GetLogicalParent(ModelItem item)
		{
			if (item == null)
			{
				return null;
			}
			if (item.View == null)
			{
				return null;
			}
			return item.View.LogicalParent;
		}

		internal void Parent(ModelItem parent, ModelItem child)
		{
			if (_featureManager == null)
			{
				throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ParentNotSupported, new object[2]
				{
					parent.ItemType.Name,
					child.ItemType.Name
				}));
			}
			ParentAdapter parentAdapter = null;
			using (IEnumerator<FeatureProvider> enumerator = _featureManager.CreateFeatureProviders(typeof(ParentAdapter), parent).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ParentAdapter parentAdapter2 = (ParentAdapter)enumerator.Current;
					ModelItem modelItem = parentAdapter2.RedirectParent(parent, child.ItemType);
					if (modelItem == null)
					{
						throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_InvalidRedirectParent, new object[1] { parentAdapter2.GetType().Name }));
					}
					if (modelItem != parent)
					{
						Parent(modelItem, child);
						return;
					}
					parentAdapter = parentAdapter2;
				}
			}
			if (parentAdapter == null || !parentAdapter.CanParent(parent, child.ItemType))
			{
				throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ParentNotSupported, new object[2]
				{
					parent.ItemType.Name,
					child.ItemType.Name
				}));
			}
			ModelItem parent2 = child.Parent;
			if (parent2 == parent)
			{
				return;
			}
			if (parent2 != null)
			{
				using IEnumerator<FeatureProvider> enumerator2 = _featureManager.CreateFeatureProviders(typeof(ParentAdapter), parent2).GetEnumerator();
				if (enumerator2.MoveNext())
				{
					ParentAdapter parentAdapter3 = (ParentAdapter)enumerator2.Current;
					parentAdapter3.RemoveParent(parent2, parent, child);
				}
			}
			parentAdapter.Parent(parent, child);
		}
	}

	public static bool CanParent(EditingContext context, ModelItem parent, Type childType)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (parent == null)
		{
			throw new ArgumentNullException("parent");
		}
		if ((object)childType == null)
		{
			throw new ArgumentNullException("childType");
		}
		ModelItem redirectedParent;
		return GetImplementation(context).CanParent(parent, childType, null, out redirectedParent);
	}

	public static ModelItem FindParent(EditingContext context, ModelItem childItem, ModelItem startingItem)
	{
		if (childItem == null)
		{
			throw new ArgumentNullException("childItem");
		}
		return FindParent(context, childItem.ItemType, startingItem, childItem);
	}

	public static ModelItem FindParent(EditingContext context, Type childType, ModelItem startingItem)
	{
		return FindParent(context, childType, startingItem, null);
	}

	internal static ModelItem FindParent(EditingContext context, Type childType, ModelItem startingItem, ModelItem childItem)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if ((object)childType == null)
		{
			throw new ArgumentNullException("childType");
		}
		if (startingItem == null)
		{
			throw new ArgumentNullException("startingItem");
		}
		return GetImplementation(context).FindParent(childType, startingItem, childItem);
	}

	public static ModelItem FindParent(Type childType, GestureData gestureData)
	{
		if (gestureData == null)
		{
			throw new ArgumentNullException("gestureData");
		}
		ModelItem targetModel = gestureData.TargetModel;
		if (targetModel == null)
		{
			return null;
		}
		return FindParent(gestureData.Context, childType, targetModel);
	}

	internal static ItemParentImplementationService GetImplementation(EditingContext context)
	{
		ItemParentImplementationService itemParentImplementationService = context.Services.GetService<ItemParentImplementationService>();
		if (itemParentImplementationService == null)
		{
			itemParentImplementationService = new ItemParentImplementationService();
			context.Services.Publish(itemParentImplementationService);
		}
		return itemParentImplementationService;
	}

	public static void Parent(EditingContext context, ModelItem parentItem, ModelItem childItem)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (parentItem == null)
		{
			throw new ArgumentNullException("parentItem");
		}
		if (childItem == null)
		{
			throw new ArgumentNullException("childItem");
		}
		GetImplementation(context).Parent(parentItem, childItem);
	}
}
