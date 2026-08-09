using System.Collections.Generic;
using System.Threading;

namespace System.ServiceModel;

internal abstract class TypedHeaderManager
{
	private class GenericAdapter<T> : TypedHeaderManager
	{
		protected override object Create(object content, bool mustUnderstand, bool relay, string actor)
		{
			MessageHeader<T> messageHeader = new MessageHeader<T>();
			messageHeader.Content = (T)content;
			messageHeader.MustUnderstand = mustUnderstand;
			messageHeader.Relay = relay;
			messageHeader.Actor = actor;
			return messageHeader;
		}

		protected override object GetContent(object typedHeaderInstance, out bool mustUnderstand, out bool relay, out string actor)
		{
			mustUnderstand = false;
			relay = false;
			actor = null;
			if (typedHeaderInstance == null)
			{
				return null;
			}
			if (!(typedHeaderInstance is MessageHeader<T> messageHeader))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException("typedHeaderInstance"));
			}
			mustUnderstand = messageHeader.MustUnderstand;
			relay = messageHeader.Relay;
			actor = messageHeader.Actor;
			return messageHeader.Content;
		}

		protected override Type GetMessageHeaderType()
		{
			return typeof(MessageHeader<T>);
		}
	}

	private static Dictionary<Type, TypedHeaderManager> s_cache = new Dictionary<Type, TypedHeaderManager>();

	private static ReaderWriterLockSlim s_cacheLock = new ReaderWriterLockSlim();

	private static Type s_GenericAdapterType = typeof(GenericAdapter<>);

	internal static object Create(Type t, object content, bool mustUnderstand, bool relay, string actor)
	{
		return GetTypedHeaderManager(t).Create(content, mustUnderstand, relay, actor);
	}

	internal static object GetContent(Type t, object typedHeaderInstance, out bool mustUnderstand, out bool relay, out string actor)
	{
		return GetTypedHeaderManager(t).GetContent(typedHeaderInstance, out mustUnderstand, out relay, out actor);
	}

	internal static Type GetMessageHeaderType(Type contentType)
	{
		return GetTypedHeaderManager(contentType).GetMessageHeaderType();
	}

	internal static Type GetHeaderType(Type headerParameterType)
	{
		if (headerParameterType.IsGenericType() && headerParameterType.GetGenericTypeDefinition() == typeof(MessageHeader<>))
		{
			return headerParameterType.GetGenericArguments()[0];
		}
		return headerParameterType;
	}

	private static TypedHeaderManager GetTypedHeaderManager(Type t)
	{
		TypedHeaderManager value = null;
		bool flag = false;
		bool flag2 = false;
		try
		{
			try
			{
			}
			finally
			{
				s_cacheLock.TryEnterUpgradeableReadLock(-1);
				flag = true;
			}
			if (!s_cache.TryGetValue(t, out value))
			{
				s_cacheLock.TryEnterWriteLock(-1);
				flag2 = true;
				if (!s_cache.TryGetValue(t, out value))
				{
					value = (TypedHeaderManager)Activator.CreateInstance(s_GenericAdapterType.MakeGenericType(t));
					s_cache.Add(t, value);
				}
			}
		}
		finally
		{
			if (flag2)
			{
				s_cacheLock.ExitWriteLock();
			}
			if (flag)
			{
				s_cacheLock.ExitUpgradeableReadLock();
			}
		}
		return value;
	}

	protected abstract object Create(object content, bool mustUnderstand, bool relay, string actor);

	protected abstract object GetContent(object typedHeaderInstance, out bool mustUnderstand, out bool relay, out string actor);

	protected abstract Type GetMessageHeaderType();
}
