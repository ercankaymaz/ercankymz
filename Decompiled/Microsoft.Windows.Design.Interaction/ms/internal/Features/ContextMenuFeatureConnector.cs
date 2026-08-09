using System.Collections.Generic;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;
using Microsoft.Windows.Design.Policies;
using Microsoft.Windows.Design.Services;

namespace MS.Internal.Features;

internal class ContextMenuFeatureConnector : PolicyDrivenFeatureConnector<ContextMenuProvider>
{
	public ContextMenuFeatureConnector(FeatureManager manager)
		: base(manager)
	{
		base.Context.Services.Publish(new ContextMenuService(this));
	}

	public IEnumerable<MenuBase> GetItems()
	{
		try
		{
			return MenuUtilities.MergeMenuGroups(EnumerateRootMenuItems);
		}
		catch
		{
			return new List<MenuBase>();
		}
	}

	private IEnumerable<MenuBase> EnumerateRootMenuItems()
	{
		List<ContextMenuProvider> contextMenuProviders = new List<ContextMenuProvider>();
		foreach (ItemFeatureProvider featureProvider in base.FeatureProviders)
		{
			featureProvider.FeatureProvider.Update(base.Context);
			contextMenuProviders.Add(featureProvider.FeatureProvider);
		}
		contextMenuProviders.Sort(MenuUtilities.CompareContextMenuProviders);
		foreach (ContextMenuProvider contextMenuProvider in contextMenuProviders)
		{
			foreach (MenuBase item in contextMenuProvider.Items)
			{
				yield return item;
			}
		}
	}

	protected override void FeatureProvidersAdded(ModelItem item, IEnumerable<ContextMenuProvider> featureProviders)
	{
	}

	protected override void FeatureProvidersRemoved(ModelItem item, IEnumerable<ContextMenuProvider> featureProviders)
	{
	}
}
