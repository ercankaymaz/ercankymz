using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Model;
using Microsoft.Windows.Design.Services;

namespace MS.Internal.Features;

internal class DesignModeValueProviderConnector : FeatureConnector<DesignModeValueProvider>
{
	internal class ValueTranslationServiceImpl : ValueTranslationService, IDisposable
	{
		private DesignModeValueProviderConnector _connector;

		private Dictionary<Type, List<DesignModeValueProvider>> _providers;

		private Dictionary<PropertyIdentifier, PropertyIdentifier> _seenPropertyPool;

		private bool _disposed;

		public override event EventHandler<PropertyInvalidatedEventArgs> PropertyInvalidated;

		internal ValueTranslationServiceImpl(DesignModeValueProviderConnector connector)
		{
			_connector = connector;
		}

		internal void Clear()
		{
			if (_providers != null)
			{
				_providers.Clear();
			}
		}

		void IDisposable.Dispose()
		{
			_disposed = true;
		}

		private IEnumerable<DesignModeValueProvider> GetFeatureProvidersInCallOrder(Type type)
		{
			if (_providers == null)
			{
				_providers = new Dictionary<Type, List<DesignModeValueProvider>>();
			}
			List<DesignModeValueProvider> value = null;
			if (!_providers.TryGetValue(type, out value))
			{
				foreach (DesignModeValueProvider item in _connector.CreateFeatureProviders(type))
				{
					if (value == null)
					{
						value = new List<DesignModeValueProvider>();
					}
					value.Add(item);
				}
				value?.Reverse();
				_providers.Add(type, value);
			}
			return value;
		}

		public override IEnumerable<PropertyIdentifier> GetProperties(Type itemType)
		{
			if ((object)itemType == null)
			{
				throw new ArgumentNullException("itemType");
			}
			IEnumerable<DesignModeValueProvider> providers = GetFeatureProvidersInCallOrder(itemType);
			if (providers == null)
			{
				yield break;
			}
			Dictionary<PropertyIdentifier, PropertyIdentifier> seenProperties = _seenPropertyPool;
			if (seenProperties == null)
			{
				seenProperties = new Dictionary<PropertyIdentifier, PropertyIdentifier>();
			}
			else
			{
				_seenPropertyPool = null;
			}
			foreach (DesignModeValueProvider filter in providers)
			{
				foreach (PropertyIdentifier id in filter.Properties)
				{
					if (!seenProperties.ContainsKey(id))
					{
						seenProperties.Add(id, id);
						yield return id;
					}
				}
			}
			seenProperties.Clear();
			_seenPropertyPool = seenProperties;
		}

		public override bool HasValueTranslation(Type itemType, PropertyIdentifier property)
		{
			if ((object)itemType == null)
			{
				throw new ArgumentNullException("itemType");
			}
			if (!_disposed)
			{
				IEnumerable<DesignModeValueProvider> featureProvidersInCallOrder = GetFeatureProvidersInCallOrder(itemType);
				if (featureProvidersInCallOrder != null)
				{
					foreach (DesignModeValueProvider item in featureProvidersInCallOrder)
					{
						foreach (PropertyIdentifier property2 in item.Properties)
						{
							if (IdentifiersMatch(property, property2))
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		private bool IdentifiersMatch(PropertyIdentifier targetId, PropertyIdentifier id)
		{
			Type type = targetId.DeclaringType ?? ModelFactory.ResolveType(_connector.Context, targetId.DeclaringTypeIdentifier);
			Type type2 = id.DeclaringType ?? ModelFactory.ResolveType(_connector.Context, id.DeclaringTypeIdentifier);
			if ((object)type2 != null && (object)type == type2)
			{
				return string.Equals(targetId.Name, id.Name, StringComparison.Ordinal);
			}
			return false;
		}

		public override object TranslatePropertyValue(Type itemType, ModelItem item, PropertyIdentifier property, object value)
		{
			if (!_disposed)
			{
				IEnumerable<DesignModeValueProvider> featureProvidersInCallOrder = GetFeatureProvidersInCallOrder(itemType);
				if (featureProvidersInCallOrder != null)
				{
					foreach (DesignModeValueProvider item2 in featureProvidersInCallOrder)
					{
						foreach (PropertyIdentifier property2 in item2.Properties)
						{
							if (IdentifiersMatch(property, property2))
							{
								value = item2.TranslatePropertyValue(item, property2, value);
								break;
							}
						}
					}
				}
			}
			return value;
		}

		public override void InvalidateProperty(ModelItem item, PropertyIdentifier property)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (!_disposed && PropertyInvalidated != null)
			{
				PropertyInvalidated(this, new PropertyInvalidatedEventArgs(item, property));
			}
		}
	}

	private ValueTranslationServiceImpl _service;

	public DesignModeValueProviderConnector(FeatureManager manager)
		: base(manager)
	{
		ServiceManager services = base.Context.Services;
		PublishServiceCallback<ValueTranslationService> callback = delegate
		{
			_service = new ValueTranslationServiceImpl(this);
			return _service;
		};
		services.Publish(callback);
		base.Context.Items.Subscribe<AssemblyReferences>(delegate
		{
			if (_service != null)
			{
				_service.Clear();
			}
		});
		TypeDescriptor.Refreshed += TypeDescriptor_Refreshed;
	}

	private void TypeDescriptor_Refreshed(RefreshEventArgs e)
	{
		if (_service != null)
		{
			_service.Clear();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			TypeDescriptor.Refreshed -= TypeDescriptor_Refreshed;
			if (_service != null)
			{
				_service.Clear();
				((IDisposable)_service).Dispose();
				_service = null;
			}
		}
		base.Dispose(disposing);
	}
}
