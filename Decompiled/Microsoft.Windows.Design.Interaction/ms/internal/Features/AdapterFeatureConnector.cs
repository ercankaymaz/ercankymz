using System;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Services;

namespace MS.Internal.Features;

internal class AdapterFeatureConnector : FeatureConnector<Adapter>
{
	private class AdapterServiceImpl : AdapterService
	{
		private AdapterFeatureConnector _server;

		internal AdapterServiceImpl(AdapterFeatureConnector server)
		{
			_server = server;
		}

		private bool FilterExtension(Type extensionType)
		{
			RequirementValidator requirementValidator = new RequirementValidator(_server.Manager, extensionType);
			return requirementValidator.MeetsRequirements;
		}

		public override Adapter GetAdapter(Type adapterType, Type itemType)
		{
			foreach (Adapter item in _server.Manager.CreateFeatureProviders(adapterType, itemType, FilterExtension))
			{
				if ((object)item.AdapterType == adapterType)
				{
					return item;
				}
			}
			return null;
		}
	}

	public AdapterFeatureConnector(FeatureManager manager)
		: base(manager)
	{
		ServiceManager services = base.Context.Services;
		PublishServiceCallback<AdapterService> callback = () => new AdapterServiceImpl(this);
		services.Publish(callback);
	}
}
