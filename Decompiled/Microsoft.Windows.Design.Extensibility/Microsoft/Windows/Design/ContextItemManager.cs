using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Windows.Design;

public abstract class ContextItemManager : IEnumerable<ContextItem>, IEnumerable
{
	private interface ICallbackProxy
	{
		Delegate OriginalDelegate { get; }

		object OriginalTarget { get; }
	}

	private class SubscribeProxy<ContextItemType> : ICallbackProxy where ContextItemType : ContextItem
	{
		private SubscribeContextCallback<ContextItemType> _genericCallback;

		internal SubscribeContextCallback Callback => SubscribeContext;

		Delegate ICallbackProxy.OriginalDelegate => _genericCallback;

		object ICallbackProxy.OriginalTarget => _genericCallback.Target;

		internal SubscribeProxy(SubscribeContextCallback<ContextItemType> callback)
		{
			_genericCallback = callback;
		}

		private void SubscribeContext(ContextItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			_genericCallback((ContextItemType)item);
		}
	}

	public abstract bool Contains(Type itemType);

	public bool Contains<TItemType>() where TItemType : ContextItem
	{
		return Contains(typeof(TItemType));
	}

	public abstract IEnumerator<ContextItem> GetEnumerator();

	public abstract ContextItem GetValue(Type itemType);

	public TItemType GetValue<TItemType>() where TItemType : ContextItem
	{
		return (TItemType)GetValue(typeof(TItemType));
	}

	protected static void NotifyItemChanged(EditingContext context, ContextItem item, ContextItem previousItem)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (previousItem == null)
		{
			throw new ArgumentNullException("previousItem");
		}
		item.InvokeOnItemChanged(context, previousItem);
	}

	public abstract void SetValue(ContextItem value);

	public abstract void Subscribe(Type contextItemType, SubscribeContextCallback callback);

	public void Subscribe<TContextItemType>(SubscribeContextCallback<TContextItemType> callback) where TContextItemType : ContextItem
	{
		if (callback == null)
		{
			throw new ArgumentNullException("callback");
		}
		SubscribeProxy<TContextItemType> subscribeProxy = new SubscribeProxy<TContextItemType>(callback);
		Subscribe(typeof(TContextItemType), subscribeProxy.Callback);
	}

	public void Unsubscribe<TContextItemType>(SubscribeContextCallback<TContextItemType> callback) where TContextItemType : ContextItem
	{
		if (callback == null)
		{
			throw new ArgumentNullException("callback");
		}
		SubscribeProxy<TContextItemType> subscribeProxy = new SubscribeProxy<TContextItemType>(callback);
		Unsubscribe(typeof(TContextItemType), subscribeProxy.Callback);
	}

	public abstract void Unsubscribe(Type contextItemType, SubscribeContextCallback callback);

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
