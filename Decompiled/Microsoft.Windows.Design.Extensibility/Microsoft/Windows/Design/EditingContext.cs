using System;
using System.Collections.Generic;
using System.Globalization;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design;

public class EditingContext : IDisposable
{
	private sealed class DefaultContextItemManager : ContextItemManager
	{
		private class DefaultContextLayer
		{
			private DefaultContextLayer _parentLayer;

			private Dictionary<Type, ContextItem> _items;

			private Dictionary<Type, ContextItem> _defaultItems;

			internal Dictionary<Type, ContextItem> DefaultItems
			{
				get
				{
					if (_defaultItems == null)
					{
						_defaultItems = new Dictionary<Type, ContextItem>();
					}
					return _defaultItems;
				}
			}

			internal Dictionary<Type, ContextItem> Items
			{
				get
				{
					if (_items == null)
					{
						_items = new Dictionary<Type, ContextItem>();
					}
					return _items;
				}
			}

			internal DefaultContextLayer ParentLayer => _parentLayer;

			internal DefaultContextLayer(DefaultContextLayer parentLayer)
			{
				_parentLayer = parentLayer;
			}
		}

		private EditingContext _context;

		private DefaultContextLayer _currentLayer;

		private Dictionary<Type, SubscribeContextCallback> _subscriptions;

		internal DefaultContextItemManager(EditingContext context)
		{
			_context = context;
			_currentLayer = new DefaultContextLayer(null);
		}

		public override void SetValue(ContextItem value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			ContextItem valueNull;
			ContextItem contextItem = (valueNull = GetValueNull(value.ItemType));
			if (contextItem == null)
			{
				contextItem = GetValue(value.ItemType);
			}
			bool flag = false;
			try
			{
				_currentLayer.Items[value.ItemType] = value;
				ContextItemManager.NotifyItemChanged(_context, value, contextItem);
				flag = true;
			}
			finally
			{
				if (flag)
				{
					OnItemChanged(value);
				}
				else
				{
					_currentLayer.Items.Remove(value.ItemType);
					if (valueNull != null)
					{
						SetValue(valueNull);
					}
				}
			}
		}

		public override bool Contains(Type itemType)
		{
			if ((object)itemType == null)
			{
				throw new ArgumentNullException("itemType");
			}
			if (!typeof(ContextItem).IsAssignableFrom(itemType))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_ArgIncorrectType, new object[2]
				{
					"itemType",
					typeof(ContextItem).FullName
				}));
			}
			return _currentLayer.Items.ContainsKey(itemType);
		}

		public override ContextItem GetValue(Type itemType)
		{
			ContextItem value = GetValueNull(itemType);
			if (value == null && !_currentLayer.DefaultItems.TryGetValue(itemType, out value))
			{
				value = (ContextItem)Activator.CreateInstance(itemType);
				if ((object)value.ItemType != itemType)
				{
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_DerivedContextItem, new object[2]
					{
						itemType.FullName,
						value.ItemType.FullName
					}));
				}
				_currentLayer.DefaultItems.Add(value.ItemType, value);
			}
			return value;
		}

		private ContextItem GetValueNull(Type itemType)
		{
			if ((object)itemType == null)
			{
				throw new ArgumentNullException("itemType");
			}
			if (!typeof(ContextItem).IsAssignableFrom(itemType))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_ArgIncorrectType, new object[2]
				{
					"itemType",
					typeof(ContextItem).FullName
				}));
			}
			ContextItem value = null;
			DefaultContextLayer defaultContextLayer = _currentLayer;
			while (defaultContextLayer != null && !defaultContextLayer.Items.TryGetValue(itemType, out value))
			{
				defaultContextLayer = defaultContextLayer.ParentLayer;
			}
			return value;
		}

		public override IEnumerator<ContextItem> GetEnumerator()
		{
			return _currentLayer.Items.Values.GetEnumerator();
		}

		private void OnItemChanged(ContextItem item)
		{
			if (_subscriptions != null && _subscriptions.TryGetValue(item.ItemType, out var value))
			{
				value(item);
			}
		}

		public override void Subscribe(Type contextItemType, SubscribeContextCallback callback)
		{
			if ((object)contextItemType == null)
			{
				throw new ArgumentNullException("contextItemType");
			}
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			if (!typeof(ContextItem).IsAssignableFrom(contextItemType))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_ArgIncorrectType, new object[2]
				{
					"contextItemType",
					typeof(ContextItem).FullName
				}));
			}
			if (_subscriptions == null)
			{
				_subscriptions = new Dictionary<Type, SubscribeContextCallback>();
			}
			SubscribeContextCallback value = null;
			_subscriptions.TryGetValue(contextItemType, out value);
			value = (SubscribeContextCallback)Delegate.Combine(value, callback);
			_subscriptions[contextItemType] = value;
			ContextItem valueNull = GetValueNull(contextItemType);
			if (valueNull != null)
			{
				callback(valueNull);
			}
		}

		public override void Unsubscribe(Type contextItemType, SubscribeContextCallback callback)
		{
			if ((object)contextItemType == null)
			{
				throw new ArgumentNullException("contextItemType");
			}
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			if (!typeof(ContextItem).IsAssignableFrom(contextItemType))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_ArgIncorrectType, new object[2]
				{
					"contextItemType",
					typeof(ContextItem).FullName
				}));
			}
			if (_subscriptions != null && _subscriptions.TryGetValue(contextItemType, out var value))
			{
				value = (SubscribeContextCallback)ContextItemManager.RemoveCallback(value, callback);
				if (value == null)
				{
					_subscriptions.Remove(contextItemType);
				}
				else
				{
					_subscriptions[contextItemType] = value;
				}
			}
		}
	}

	private sealed class DefaultServiceManager : ServiceManager, IDisposable
	{
		private Dictionary<Type, object> _services;

		private Dictionary<Type, SubscribeServiceCallback> _subscriptions;

		private static readonly object _recursionSentinel = new object();

		internal DefaultServiceManager()
		{
		}

		public override bool Contains(Type serviceType)
		{
			if ((object)serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (_services != null)
			{
				return _services.ContainsKey(serviceType);
			}
			return false;
		}

		public override object GetService(Type serviceType)
		{
			object value = null;
			if ((object)serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (_services != null && _services.TryGetValue(serviceType, out value))
			{
				if (value == _recursionSentinel)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.Error_RecursionResolvingService, new object[1] { serviceType.FullName }));
				}
				if (value is PublishServiceCallback publishServiceCallback)
				{
					_services[serviceType] = _recursionSentinel;
					try
					{
						value = publishServiceCallback(serviceType);
						if (value == null)
						{
							throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.Error_NullService, new object[2]
							{
								publishServiceCallback.Method.DeclaringType.FullName,
								serviceType.FullName
							}));
						}
						if (!serviceType.IsInstanceOfType(value))
						{
							throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.Error_IncorrectServiceType, new object[3]
							{
								publishServiceCallback.Method.DeclaringType.FullName,
								serviceType.FullName,
								value.GetType().FullName
							}));
						}
					}
					finally
					{
						_services[serviceType] = value;
					}
				}
			}
			return value;
		}

		public override IEnumerator<Type> GetEnumerator()
		{
			if (_services == null)
			{
				_services = new Dictionary<Type, object>();
			}
			return _services.Keys.GetEnumerator();
		}

		public override void Subscribe(Type serviceType, SubscribeServiceCallback callback)
		{
			if ((object)serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			object service = GetService(serviceType);
			if (service != null)
			{
				callback(serviceType, service);
				return;
			}
			if (_subscriptions == null)
			{
				_subscriptions = new Dictionary<Type, SubscribeServiceCallback>();
			}
			SubscribeServiceCallback value = null;
			_subscriptions.TryGetValue(serviceType, out value);
			value = (SubscribeServiceCallback)Delegate.Combine(value, callback);
			_subscriptions[serviceType] = value;
		}

		public override void Publish(Type serviceType, PublishServiceCallback callback)
		{
			if ((object)serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			Publish(serviceType, (object)callback);
		}

		public override void Publish(Type serviceType, object serviceInstance)
		{
			if ((object)serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (serviceInstance == null)
			{
				throw new ArgumentNullException("serviceInstance");
			}
			if (!(serviceInstance is PublishServiceCallback) && !serviceType.IsInstanceOfType(serviceInstance))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_IncorrectServiceType, new object[3]
				{
					typeof(ServiceManager).Name,
					serviceType.FullName,
					serviceInstance.GetType().FullName
				}));
			}
			if (_services == null)
			{
				_services = new Dictionary<Type, object>();
			}
			try
			{
				_services.Add(serviceType, serviceInstance);
			}
			catch (ArgumentException innerException)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_DuplicateService, new object[1] { serviceType.FullName }), innerException);
			}
			if (_subscriptions != null && _subscriptions.TryGetValue(serviceType, out var value))
			{
				value(serviceType, GetService(serviceType));
				_subscriptions.Remove(serviceType);
			}
		}

		public override void Unsubscribe(Type serviceType, SubscribeServiceCallback callback)
		{
			if ((object)serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			if (_subscriptions != null && _subscriptions.TryGetValue(serviceType, out var value))
			{
				value = (SubscribeServiceCallback)ServiceManager.RemoveCallback(value, callback);
				if (value == null)
				{
					_subscriptions.Remove(serviceType);
				}
				else
				{
					_subscriptions[serviceType] = value;
				}
			}
		}

		void IDisposable.Dispose()
		{
			if (_services == null)
			{
				return;
			}
			Dictionary<Type, object> services = _services;
			try
			{
				foreach (object value in services.Values)
				{
					if (value is IDisposable disposable)
					{
						disposable.Dispose();
					}
				}
			}
			finally
			{
				_services = null;
			}
		}
	}

	private ContextItemManager _contextItems;

	private ServiceManager _services;

	public ContextItemManager Items
	{
		get
		{
			if (_contextItems == null)
			{
				_contextItems = CreateContextItemManager();
				if (_contextItems == null)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.Error_NullImplementation, new object[1] { "CreateContextItemManager" }));
				}
			}
			return _contextItems;
		}
	}

	public ServiceManager Services
	{
		get
		{
			if (_services == null)
			{
				_services = CreateServiceManager();
				if (_services == null)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.Error_NullImplementation, new object[1] { "CreateServiceManager" }));
				}
			}
			return _services;
		}
	}

	public event EventHandler Disposing;

	~EditingContext()
	{
		Dispose(disposing: false);
	}

	protected virtual ContextItemManager CreateContextItemManager()
	{
		return new DefaultContextItemManager(this);
	}

	protected virtual ServiceManager CreateServiceManager()
	{
		return new DefaultServiceManager();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (this.Disposing != null)
			{
				this.Disposing(this, EventArgs.Empty);
			}
			if (_services is IDisposable disposable)
			{
				disposable.Dispose();
			}
			if (_contextItems is IDisposable disposable2)
			{
				disposable2.Dispose();
			}
		}
	}
}
