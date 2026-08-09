using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.Features;

public class FeatureManager : IDisposable
{
	private class FeatureConnectorEntry : FeatureConnectorInformation
	{
		private Type _featureConnectorType;

		private FeatureManager _manager;

		private IDisposable _featureConnector;

		private RequirementValidator _requirements;

		public override Type FeatureConnectorType => _featureConnectorType;

		internal bool IsActivated => _featureConnector != null;

		public override IEnumerable<Type> RequiredServices
		{
			get
			{
				foreach (RequirementAttribute requirement in _requirements.Requirements)
				{
					if (requirement is RequiresServiceAttribute attr)
					{
						yield return attr.ServiceType;
					}
				}
			}
		}

		public override IEnumerable<Type> RequiredItems
		{
			get
			{
				foreach (RequirementAttribute requirement in _requirements.Requirements)
				{
					if (requirement is RequiresContextItemAttribute attr)
					{
						yield return attr.ContextItemType;
					}
				}
			}
		}

		public override IEnumerable<Type> PendingServices
		{
			get
			{
				foreach (RequirementAttribute requirement in _requirements.PendingRequirements)
				{
					if (requirement is RequiresServiceAttribute attr)
					{
						yield return attr.ServiceType;
					}
				}
			}
		}

		public override IEnumerable<Type> PendingItems
		{
			get
			{
				foreach (RequirementAttribute requirement in _requirements.PendingRequirements)
				{
					if (requirement is RequiresContextItemAttribute attr)
					{
						yield return attr.ContextItemType;
					}
				}
			}
		}

		internal FeatureConnectorEntry(Type featureConnectorType, FeatureManager manager)
		{
			_featureConnectorType = featureConnectorType;
			_manager = manager;
		}

		internal void AttemptActivate()
		{
			bool flag = false;
			if (_requirements == null)
			{
				_requirements = new RequirementValidator(_manager, _featureConnectorType);
				flag = true;
			}
			if (_requirements.MeetsRequirements)
			{
				_requirements.RequirementsChanged -= OnRequirementsChanged;
				_featureConnector = Activator.CreateInstance(_featureConnectorType, _manager) as IDisposable;
			}
			else if (flag)
			{
				_requirements.RequirementsChanged += OnRequirementsChanged;
			}
		}

		internal void Dispose()
		{
			if (_featureConnector != null)
			{
				_featureConnector.Dispose();
				_featureConnector = null;
			}
			else
			{
				_requirements.RequirementsChanged -= OnRequirementsChanged;
			}
		}

		private void OnRequirementsChanged(object sender, EventArgs e)
		{
			AttemptActivate();
		}
	}

	private EditingContext _context;

	private Dictionary<Type, FeatureConnectorEntry> _featureConnectors;

	private HashSet<Type> _knownFeatureProviders;

	private Predicate<Type> _defaultFilter;

	private MetadataProviderCallback _metadataProvider;

	private Dictionary<Type, IEnumerable<object>> _featureAttributeCache;

	private Dictionary<Type, IEnumerable<object>> _featureConnectorAttributeCache;

	private HashSet<Type> _initializedTypes;

	private static readonly BindingFlags _createBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance;

	public EditingContext Context => _context;

	public MetadataProviderCallback MetadataProvider
	{
		get
		{
			if (_metadataProvider == null)
			{
				_metadataProvider = GetCustomAttributesDefault;
			}
			return _metadataProvider;
		}
		set
		{
			_metadataProvider = value;
			ClearCaches();
			if (_featureConnectorAttributeCache != null)
			{
				_featureConnectorAttributeCache.Clear();
			}
		}
	}

	public IEnumerable<FeatureConnectorInformation> PendingConnectors
	{
		get
		{
			foreach (FeatureConnectorEntry entry in _featureConnectors.Values)
			{
				if (!entry.IsActivated)
				{
					yield return entry;
				}
			}
		}
	}

	public IEnumerable<FeatureConnectorInformation> RunningConnectors
	{
		get
		{
			foreach (FeatureConnectorEntry entry in _featureConnectors.Values)
			{
				if (entry.IsActivated)
				{
					yield return entry;
				}
			}
		}
	}

	public event EventHandler<FeatureAvailableEventArgs> FeatureAvailable;

	public FeatureManager(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		_context = context;
		_featureConnectors = new Dictionary<Type, FeatureConnectorEntry>();
		_defaultFilter = OnDefaultCallbackFilter;
		_context.Items.Subscribe<AssemblyReferences>(delegate
		{
			ClearCaches();
		});
	}

	~FeatureManager()
	{
		Dispose(disposing: false);
	}

	private void ClearCaches()
	{
		if (_featureAttributeCache != null)
		{
			_featureAttributeCache.Clear();
		}
		if (_initializedTypes != null)
		{
			_initializedTypes.Clear();
		}
	}

	public IEnumerable<FeatureProvider> CreateFeatureProviders(Type featureProviderType)
	{
		return CreateFeatureProviders(featureProviderType, _defaultFilter);
	}

	public virtual IEnumerable<FeatureProvider> CreateFeatureProviders(Type featureProviderType, Predicate<Type> match)
	{
		if ((object)featureProviderType == null)
		{
			throw new ArgumentNullException("featureProviderType");
		}
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		if (!typeof(FeatureProvider).IsAssignableFrom(featureProviderType))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_IncorrectTypePassed, new object[1] { typeof(FeatureProvider).Name }));
		}
		if (_knownFeatureProviders == null)
		{
			yield break;
		}
		foreach (Type key in _knownFeatureProviders)
		{
			if (featureProviderType.IsAssignableFrom(key) && match(key))
			{
				FeatureProvider featureProvider = CreateFeatureProvider(key);
				if (featureProvider != null)
				{
					yield return featureProvider;
				}
			}
		}
	}

	public IEnumerable<FeatureProvider> CreateFeatureProviders(Type featureProviderType, Type type)
	{
		return CreateFeatureProviders(featureProviderType, type, _defaultFilter);
	}

	public virtual IEnumerable<FeatureProvider> CreateFeatureProviders(Type featureProviderType, Type type, Predicate<Type> match)
	{
		if ((object)featureProviderType == null)
		{
			throw new ArgumentNullException("featureProviderType");
		}
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		if (!typeof(FeatureProvider).IsAssignableFrom(featureProviderType))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_IncorrectTypePassed, new object[1] { typeof(FeatureProvider).Name }));
		}
		IEnumerable<object> attrs = GetFeatureAttributesForType(type);
		foreach (FeatureProvider item in CreateFeatureProviders(featureProviderType, attrs, match))
		{
			yield return item;
		}
	}

	private static FeatureProvider CreateFeatureProvider(Type featureProviderType)
	{
		ConstructorInfo constructor = featureProviderType.GetConstructor(_createBindingFlags, null, Type.EmptyTypes, null);
		if ((object)constructor != null)
		{
			return constructor.Invoke(null) as FeatureProvider;
		}
		return null;
	}

	private static IEnumerable<FeatureProvider> CreateFeatureProviders(Type featureProviderType, IEnumerable<object> attrs, Predicate<Type> match)
	{
		foreach (Attribute attrib in attrs)
		{
			if (attrib is FeatureAttribute { FeatureProviderType: var fType } && featureProviderType.IsAssignableFrom(fType) && match(fType))
			{
				FeatureProvider featureProvider = CreateFeatureProvider(fType);
				if (featureProvider != null)
				{
					yield return featureProvider;
				}
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}
		foreach (FeatureConnectorEntry value in _featureConnectors.Values)
		{
			value.Dispose();
		}
		_featureConnectors.Clear();
	}

	public IEnumerable<object> GetCustomAttributes(Type type, Type attributeType)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if ((object)attributeType == null)
		{
			throw new ArgumentNullException("attributeType");
		}
		return MetadataProvider(type, attributeType);
	}

	private IEnumerable<object> GetCustomAttributesDefault(Type type, Type attributeType)
	{
		return type.GetCustomAttributes(attributeType, inherit: true);
	}

	private IEnumerable<object> GetFeatureAttributesForType(Type type)
	{
		if (_featureAttributeCache == null)
		{
			_featureAttributeCache = new Dictionary<Type, IEnumerable<object>>();
		}
		if (!_featureAttributeCache.TryGetValue(type, out var value))
		{
			value = GetCustomAttributes(type, typeof(FeatureAttribute));
			value = value.ToArray();
			_featureAttributeCache[type] = value;
		}
		return value;
	}

	private IEnumerable<object> GetFeatureConnectorAttributesForType(Type type)
	{
		if (_featureConnectorAttributeCache == null)
		{
			_featureConnectorAttributeCache = new Dictionary<Type, IEnumerable<object>>();
		}
		if (!_featureConnectorAttributeCache.TryGetValue(type, out var value))
		{
			value = GetCustomAttributesDefault(type, typeof(FeatureConnectorAttribute));
			_featureConnectorAttributeCache[type] = value;
		}
		return value;
	}

	public void InitializeFeatures(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type.IsPrimitive || (object)type == typeof(string))
		{
			return;
		}
		if (_initializedTypes == null)
		{
			_initializedTypes = new HashSet<Type>();
		}
		if (_initializedTypes.Contains(type))
		{
			return;
		}
		_initializedTypes.Add(type);
		IEnumerable<object> featureAttributesForType = GetFeatureAttributesForType(type);
		foreach (Attribute item in featureAttributesForType)
		{
			if (!(item is FeatureAttribute { FeatureProviderType: var featureProviderType }))
			{
				continue;
			}
			if (!_initializedTypes.Contains(featureProviderType))
			{
				_initializedTypes.Add(featureProviderType);
				foreach (Attribute item2 in GetFeatureConnectorAttributesForType(featureProviderType))
				{
					if (item2 is FeatureConnectorAttribute { FeatureConnectorType: var featureConnectorType } && !_featureConnectors.ContainsKey(featureConnectorType))
					{
						FeatureConnectorEntry featureConnectorEntry = new FeatureConnectorEntry(featureConnectorType, this);
						_featureConnectors.Add(featureConnectorType, featureConnectorEntry);
						featureConnectorEntry.AttemptActivate();
					}
				}
			}
			if (_knownFeatureProviders == null)
			{
				_knownFeatureProviders = new HashSet<Type>();
			}
			if (!_knownFeatureProviders.Contains(featureProviderType))
			{
				_knownFeatureProviders.Add(featureProviderType);
				if (this.FeatureAvailable != null)
				{
					OnFeatureAvailable(new FeatureAvailableEventArgs(featureProviderType));
				}
			}
		}
	}

	private bool OnDefaultCallbackFilter(Type featureProviderType)
	{
		RequirementValidator requirementValidator = new RequirementValidator(this, featureProviderType);
		return requirementValidator.MeetsRequirements;
	}

	protected virtual void OnFeatureAvailable(FeatureAvailableEventArgs e)
	{
		if (this.FeatureAvailable != null)
		{
			this.FeatureAvailable(this, e);
		}
	}
}
