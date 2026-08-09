using System.Collections.Generic;
using System.Windows;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;
using Microsoft.Windows.Design.Services;

namespace MS.Internal.Features;

[RequiresContextItem(typeof(CurrentDesignerView))]
[RequiresService(typeof(ViewService))]
internal class AdornerProviderFeatureConnector : PolicyDrivenToolFeatureConnector<AdornerProvider>
{
	private ICollection<UIElement> _adorners;

	private ViewService _viewService;

	private static DependencyProperty OwningProviderProperty = DependencyProperty.RegisterAttached("OwningProvider", typeof(AdornerProvider), typeof(AdornerProviderFeatureConnector));

	private ICollection<UIElement> Adorners
	{
		get
		{
			if (_adorners == null)
			{
				DesignerView view = base.Context.Items.GetValue<CurrentDesignerView>().View;
				_adorners = view.Adorners;
			}
			return _adorners;
		}
	}

	private ViewService ViewService
	{
		get
		{
			if (_viewService == null)
			{
				_viewService = base.Context.Services.GetRequiredService<ViewService>();
			}
			return _viewService;
		}
	}

	public AdornerProviderFeatureConnector(FeatureManager manager)
		: base(manager)
	{
	}

	protected override bool IsValidProvider(FeatureProvider featureProvider)
	{
		if (featureProvider is AdornerProvider adornerProvider && base.CurrentTool != null)
		{
			return adornerProvider.IsToolSupported(base.CurrentTool);
		}
		return false;
	}

	private bool IsItemDesignable(ModelItem item)
	{
		while (item != null && item != item.Root)
		{
			ModelProperty source = item.Source;
			if (source != null && source.Parent is ModelItemDictionary)
			{
				return false;
			}
			item = item.Parent;
		}
		return true;
	}

	protected override void FeatureProvidersAdded(ModelItem item, IEnumerable<AdornerProvider> extensions)
	{
		if (!(item.View != null) || !IsItemDesignable(item))
		{
			return;
		}
		ICollection<UIElement> adorners = Adorners;
		foreach (AdornerProvider extension in extensions)
		{
			RequirementValidator requirementValidator = new RequirementValidator(base.Manager, extension.GetType());
			if (!requirementValidator.MeetsRequirements)
			{
				continue;
			}
			extension.InvokeActivate(base.Context, item);
			foreach (UIElement adorner in extension.Adorners)
			{
				((DependencyObject)adorner).SetValue(OwningProviderProperty, (object)extension);
				if (extension.AdornersVisible && LogicalTreeHelper.GetParent((DependencyObject)(object)adorner) == null)
				{
					adorners.Add(adorner);
				}
			}
		}
	}

	protected override void FeatureProvidersRemoved(ModelItem item, IEnumerable<AdornerProvider> extensions)
	{
		ICollection<UIElement> adorners = Adorners;
		foreach (AdornerProvider extension in extensions)
		{
			foreach (UIElement adorner in extension.Adorners)
			{
				if (LogicalTreeHelper.GetParent((DependencyObject)(object)adorner) != null && ((DependencyObject)adorner).GetValue(OwningProviderProperty) == extension)
				{
					adorners.Remove(adorner);
				}
			}
			extension.InvokeDeactivate();
		}
	}
}
