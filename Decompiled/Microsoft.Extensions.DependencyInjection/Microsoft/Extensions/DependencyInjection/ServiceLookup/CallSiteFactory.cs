using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Internal;

namespace Microsoft.Extensions.DependencyInjection.ServiceLookup;

internal class CallSiteFactory
{
	private struct ServiceDescriptorCacheItem
	{
		private ServiceDescriptor _item;

		private List<ServiceDescriptor> _items;

		public ServiceDescriptor Last
		{
			get
			{
				if (_items != null && _items.Count > 0)
				{
					return _items[_items.Count - 1];
				}
				return _item;
			}
		}

		public int Count
		{
			get
			{
				if (_item == null)
				{
					return 0;
				}
				return 1 + (_items?.Count ?? 0);
			}
		}

		public ServiceDescriptor this[int index]
		{
			get
			{
				if (index >= Count)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				if (index == 0)
				{
					return _item;
				}
				return _items[index - 1];
			}
		}

		public ServiceDescriptorCacheItem Add(ServiceDescriptor descriptor)
		{
			ServiceDescriptorCacheItem result = default(ServiceDescriptorCacheItem);
			if (_item == null)
			{
				result._item = descriptor;
			}
			else
			{
				result._item = _item;
				result._items = _items ?? new List<ServiceDescriptor>();
				result._items.Add(descriptor);
			}
			return result;
		}
	}

	private readonly List<ServiceDescriptor> _descriptors;

	private readonly Dictionary<Type, IServiceCallSite> _callSiteCache = new Dictionary<Type, IServiceCallSite>();

	private readonly Dictionary<Type, ServiceDescriptorCacheItem> _descriptorLookup = new Dictionary<Type, ServiceDescriptorCacheItem>();

	public CallSiteFactory(IEnumerable<ServiceDescriptor> descriptors)
	{
		_descriptors = descriptors.ToList();
		Populate(descriptors);
	}

	private void Populate(IEnumerable<ServiceDescriptor> descriptors)
	{
		foreach (ServiceDescriptor descriptor in descriptors)
		{
			if (descriptor.ServiceType.GetTypeInfo().IsGenericTypeDefinition)
			{
				TypeInfo typeInfo = descriptor.ImplementationType?.GetTypeInfo();
				if (typeInfo == null || !typeInfo.IsGenericTypeDefinition)
				{
					throw new ArgumentException(Resources.FormatOpenGenericServiceRequiresOpenGenericImplementation(descriptor.ServiceType), "descriptors");
				}
				if (typeInfo.IsAbstract || typeInfo.IsInterface)
				{
					throw new ArgumentException(Resources.FormatTypeCannotBeActivated(descriptor.ImplementationType, descriptor.ServiceType));
				}
			}
			else if (descriptor.ImplementationInstance == null && descriptor.ImplementationFactory == null)
			{
				TypeInfo typeInfo2 = descriptor.ImplementationType.GetTypeInfo();
				if (typeInfo2.IsGenericTypeDefinition || typeInfo2.IsAbstract || typeInfo2.IsInterface)
				{
					throw new ArgumentException(Resources.FormatTypeCannotBeActivated(descriptor.ImplementationType, descriptor.ServiceType));
				}
			}
			Type serviceType = descriptor.ServiceType;
			_descriptorLookup.TryGetValue(serviceType, out var value);
			_descriptorLookup[serviceType] = value.Add(descriptor);
		}
	}

	internal IServiceCallSite CreateCallSite(Type serviceType, CallSiteChain callSiteChain)
	{
		lock (_callSiteCache)
		{
			if (_callSiteCache.TryGetValue(serviceType, out var value))
			{
				return value;
			}
			IServiceCallSite serviceCallSite;
			try
			{
				callSiteChain.CheckCircularDependency(serviceType);
				serviceCallSite = TryCreateExact(serviceType, callSiteChain) ?? TryCreateOpenGeneric(serviceType, callSiteChain) ?? TryCreateEnumerable(serviceType, callSiteChain);
			}
			finally
			{
				callSiteChain.Remove(serviceType);
			}
			_callSiteCache[serviceType] = serviceCallSite;
			return serviceCallSite;
		}
	}

	private IServiceCallSite TryCreateExact(Type serviceType, CallSiteChain callSiteChain)
	{
		if (_descriptorLookup.TryGetValue(serviceType, out var value))
		{
			return TryCreateExact(value.Last, serviceType, callSiteChain);
		}
		return null;
	}

	private IServiceCallSite TryCreateOpenGeneric(Type serviceType, CallSiteChain callSiteChain)
	{
		if (serviceType.IsConstructedGenericType && _descriptorLookup.TryGetValue(serviceType.GetGenericTypeDefinition(), out var value))
		{
			return TryCreateOpenGeneric(value.Last, serviceType, callSiteChain);
		}
		return null;
	}

	private IServiceCallSite TryCreateEnumerable(Type serviceType, CallSiteChain callSiteChain)
	{
		if (serviceType.IsConstructedGenericType && serviceType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
		{
			Type type = serviceType.GenericTypeArguments.Single();
			callSiteChain.Add(serviceType);
			List<IServiceCallSite> list = new List<IServiceCallSite>();
			if (!type.IsConstructedGenericType && _descriptorLookup.TryGetValue(type, out var value))
			{
				for (int i = 0; i < value.Count; i++)
				{
					ServiceDescriptor descriptor = value[i];
					IServiceCallSite item = TryCreateExact(descriptor, type, callSiteChain);
					list.Add(item);
				}
			}
			else
			{
				foreach (ServiceDescriptor descriptor2 in _descriptors)
				{
					IServiceCallSite serviceCallSite = TryCreateExact(descriptor2, type, callSiteChain) ?? TryCreateOpenGeneric(descriptor2, type, callSiteChain);
					if (serviceCallSite != null)
					{
						list.Add(serviceCallSite);
					}
				}
			}
			return new IEnumerableCallSite(type, list.ToArray());
		}
		return null;
	}

	private IServiceCallSite TryCreateExact(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain)
	{
		if (serviceType == descriptor.ServiceType)
		{
			IServiceCallSite serviceCallSite;
			if (descriptor.ImplementationInstance != null)
			{
				serviceCallSite = new ConstantCallSite(descriptor.ServiceType, descriptor.ImplementationInstance);
			}
			else if (descriptor.ImplementationFactory != null)
			{
				serviceCallSite = new FactoryCallSite(descriptor.ServiceType, descriptor.ImplementationFactory);
			}
			else
			{
				if (!(descriptor.ImplementationType != null))
				{
					throw new InvalidOperationException("Invalid service descriptor");
				}
				serviceCallSite = CreateConstructorCallSite(descriptor.ServiceType, descriptor.ImplementationType, callSiteChain);
			}
			return ApplyLifetime(serviceCallSite, descriptor, descriptor.Lifetime);
		}
		return null;
	}

	private IServiceCallSite TryCreateOpenGeneric(ServiceDescriptor descriptor, Type serviceType, CallSiteChain callSiteChain)
	{
		if (serviceType.IsConstructedGenericType && serviceType.GetGenericTypeDefinition() == descriptor.ServiceType)
		{
			Type implementationType = descriptor.ImplementationType.MakeGenericType(serviceType.GenericTypeArguments);
			IServiceCallSite serviceCallSite = CreateConstructorCallSite(serviceType, implementationType, callSiteChain);
			return ApplyLifetime(serviceCallSite, Tuple.Create(descriptor, serviceType), descriptor.Lifetime);
		}
		return null;
	}

	private IServiceCallSite ApplyLifetime(IServiceCallSite serviceCallSite, object cacheKey, ServiceLifetime descriptorLifetime)
	{
		if (serviceCallSite is ConstantCallSite)
		{
			return serviceCallSite;
		}
		return descriptorLifetime switch
		{
			ServiceLifetime.Transient => new TransientCallSite(serviceCallSite), 
			ServiceLifetime.Scoped => new ScopedCallSite(serviceCallSite, cacheKey), 
			ServiceLifetime.Singleton => new SingletonCallSite(serviceCallSite, cacheKey), 
			_ => throw new ArgumentOutOfRangeException("descriptorLifetime"), 
		};
	}

	private IServiceCallSite CreateConstructorCallSite(Type serviceType, Type implementationType, CallSiteChain callSiteChain)
	{
		callSiteChain.Add(serviceType, implementationType);
		ConstructorInfo[] array = implementationType.GetTypeInfo().DeclaredConstructors.Where((ConstructorInfo constructor) => constructor.IsPublic).ToArray();
		IServiceCallSite[] array2 = null;
		if (array.Length == 0)
		{
			throw new InvalidOperationException(Resources.FormatNoConstructorMatch(implementationType));
		}
		if (array.Length == 1)
		{
			ConstructorInfo constructorInfo = array[0];
			ParameterInfo[] parameters = constructorInfo.GetParameters();
			if (parameters.Length == 0)
			{
				return new CreateInstanceCallSite(serviceType, implementationType);
			}
			array2 = CreateArgumentCallSites(serviceType, implementationType, callSiteChain, parameters, throwIfCallSiteNotFound: true);
			return new ConstructorCallSite(serviceType, constructorInfo, array2);
		}
		Array.Sort(array, (ConstructorInfo a, ConstructorInfo b) => b.GetParameters().Length.CompareTo(a.GetParameters().Length));
		ConstructorInfo constructorInfo2 = null;
		HashSet<Type> hashSet = null;
		for (int num = 0; num < array.Length; num++)
		{
			ParameterInfo[] parameters2 = array[num].GetParameters();
			IServiceCallSite[] array3 = CreateArgumentCallSites(serviceType, implementationType, callSiteChain, parameters2, throwIfCallSiteNotFound: false);
			if (array3 == null)
			{
				continue;
			}
			if (constructorInfo2 == null)
			{
				constructorInfo2 = array[num];
				array2 = array3;
				continue;
			}
			if (hashSet == null)
			{
				hashSet = new HashSet<Type>(from p in constructorInfo2.GetParameters()
					select p.ParameterType);
			}
			if (!hashSet.IsSupersetOf(parameters2.Select((ParameterInfo p) => p.ParameterType)))
			{
				throw new InvalidOperationException(string.Join(Environment.NewLine, Resources.FormatAmbiguousConstructorException(implementationType), constructorInfo2, array[num]));
			}
		}
		if (constructorInfo2 == null)
		{
			throw new InvalidOperationException(Resources.FormatUnableToActivateTypeException(implementationType));
		}
		if (array2.Length != 0)
		{
			return new ConstructorCallSite(serviceType, constructorInfo2, array2);
		}
		return new CreateInstanceCallSite(serviceType, implementationType);
	}

	private IServiceCallSite[] CreateArgumentCallSites(Type serviceType, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, bool throwIfCallSiteNotFound)
	{
		IServiceCallSite[] array = new IServiceCallSite[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			IServiceCallSite serviceCallSite = CreateCallSite(parameters[i].ParameterType, callSiteChain);
			if (serviceCallSite == null && Microsoft.Extensions.Internal.ParameterDefaultValue.TryGetDefaultValue(parameters[i], out var defaultValue))
			{
				serviceCallSite = new ConstantCallSite(serviceType, defaultValue);
			}
			if (serviceCallSite == null)
			{
				if (throwIfCallSiteNotFound)
				{
					throw new InvalidOperationException(Resources.FormatCannotResolveService(parameters[i].ParameterType, implementationType));
				}
				return null;
			}
			array[i] = serviceCallSite;
		}
		return array;
	}

	public void Add(Type type, IServiceCallSite serviceCallSite)
	{
		_callSiteCache[type] = serviceCallSite;
	}
}
