using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design;

public abstract class ServiceManager : IServiceProvider, IEnumerable<Type>, IEnumerable
{
	private class PublishProxy<TServiceType>
	{
		private PublishServiceCallback<TServiceType> _genericCallback;

		internal PublishServiceCallback Callback => PublishService;

		internal PublishProxy(PublishServiceCallback<TServiceType> callback)
		{
			_genericCallback = callback;
		}

		private object PublishService(Type serviceType)
		{
			if ((object)serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if ((object)serviceType != typeof(TServiceType))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.Error_IncorrectServiceType, new object[3]
				{
					typeof(ServiceManager).FullName,
					typeof(TServiceType).FullName,
					serviceType.FullName
				}));
			}
			object obj = _genericCallback();
			if (obj == null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.Error_NullService, new object[2]
				{
					_genericCallback.Method.DeclaringType.FullName,
					serviceType.FullName
				}));
			}
			if (!serviceType.IsInstanceOfType(obj))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.Error_IncorrectServiceType, new object[3]
				{
					_genericCallback.Method.DeclaringType.FullName,
					serviceType.FullName,
					obj.GetType().FullName
				}));
			}
			return obj;
		}
	}

	private interface ICallbackProxy
	{
		Delegate OriginalDelegate { get; }

		object OriginalTarget { get; }
	}

	private class SubscribeProxy<ServiceType> : ICallbackProxy
	{
		private SubscribeServiceCallback<ServiceType> _genericCallback;

		internal SubscribeServiceCallback Callback => SubscribeService;

		Delegate ICallbackProxy.OriginalDelegate => _genericCallback;

		object ICallbackProxy.OriginalTarget => _genericCallback.Target;

		internal SubscribeProxy(SubscribeServiceCallback<ServiceType> callback)
		{
			_genericCallback = callback;
		}

		private void SubscribeService(Type serviceType, object service)
		{
			if ((object)serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (!typeof(ServiceType).IsInstanceOfType(service))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.Error_IncorrectServiceType, new object[2]
				{
					typeof(ServiceType).FullName,
					serviceType.FullName
				}));
			}
			_genericCallback((ServiceType)service);
		}
	}

	public abstract bool Contains(Type serviceType);

	public bool Contains<TServiceType>()
	{
		return Contains(typeof(TServiceType));
	}

	public TServiceType GetRequiredService<TServiceType>()
	{
		TServiceType service = GetService<TServiceType>();
		if (service == null)
		{
			throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Resources.Error_RequiredService, new object[1] { typeof(TServiceType).FullName }));
		}
		return service;
	}

	public TServiceType GetService<TServiceType>()
	{
		object service = GetService(typeof(TServiceType));
		return (TServiceType)service;
	}

	public abstract object GetService(Type serviceType);

	public abstract IEnumerator<Type> GetEnumerator();

	public abstract void Subscribe(Type serviceType, SubscribeServiceCallback callback);

	public void Subscribe<TServiceType>(SubscribeServiceCallback<TServiceType> callback)
	{
		if (callback == null)
		{
			throw new ArgumentNullException("callback");
		}
		SubscribeProxy<TServiceType> subscribeProxy = new SubscribeProxy<TServiceType>(callback);
		Subscribe(typeof(TServiceType), subscribeProxy.Callback);
	}

	public abstract void Publish(Type serviceType, PublishServiceCallback callback);

	public abstract void Publish(Type serviceType, object serviceInstance);

	public void Publish<TServiceType>(PublishServiceCallback<TServiceType> callback)
	{
		if (callback == null)
		{
			throw new ArgumentNullException("callback");
		}
		PublishProxy<TServiceType> publishProxy = new PublishProxy<TServiceType>(callback);
		Publish(typeof(TServiceType), publishProxy.Callback);
	}

	public void Publish<TServiceType>(TServiceType serviceInstance)
	{
		if (serviceInstance == null)
		{
			throw new ArgumentNullException("serviceInstance");
		}
		Publish(typeof(TServiceType), serviceInstance);
	}

	public void Unsubscribe<TServiceType>(SubscribeServiceCallback<TServiceType> callback)
	{
		if (callback == null)
		{
			throw new ArgumentNullException("callback");
		}
		SubscribeProxy<TServiceType> subscribeProxy = new SubscribeProxy<TServiceType>(callback);
		Unsubscribe(typeof(TServiceType), subscribeProxy.Callback);
	}

	public abstract void Unsubscribe(Type serviceType, SubscribeServiceCallback callback);

	protected static object GetTarget(Delegate callback)
	{
		if ((object)callback == null)
		{
			throw new ArgumentNullException("callback");
		}
		if (callback.Target is ICallbackProxy callbackProxy)
		{
			return callbackProxy.OriginalTarget;
		}
		return callback.Target;
	}

	protected static Delegate RemoveCallback(Delegate existing, Delegate toRemove)
	{
		if ((object)existing == null)
		{
			return null;
		}
		if ((object)toRemove == null)
		{
			return existing;
		}
		if (!(toRemove.Target is ICallbackProxy callbackProxy))
		{
			return Delegate.Remove(existing, toRemove);
		}
		toRemove = callbackProxy.OriginalDelegate;
		Delegate[] invocationList = existing.GetInvocationList();
		bool flag = false;
		for (int i = 0; i < invocationList.Length; i++)
		{
			Delegate obj = invocationList[i];
			if (obj.Target is ICallbackProxy callbackProxy2)
			{
				obj = callbackProxy2.OriginalDelegate;
			}
			if (obj.Equals(toRemove))
			{
				invocationList[i] = null;
				flag = true;
			}
		}
		if (flag)
		{
			existing = null;
			Delegate[] array = invocationList;
			foreach (Delegate obj2 in array)
			{
				if ((object)obj2 != null)
				{
					existing = (((object)existing != null) ? Delegate.Combine(existing, obj2) : obj2);
				}
			}
		}
		return existing;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
