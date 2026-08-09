using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.ServiceModel.Channels;

public class HttpMessageHandlerFactory
{
	private static readonly Type s_delegatingHandlerType = typeof(DelegatingHandler);

	private Type[] _httpMessageHandlers;

	private ConstructorInfo[] _handlerCtors;

	private Func<IEnumerable<DelegatingHandler>> _handlerFunc;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HttpMessageHandlerFactory(params Type[] handlers)
	{
		if (handlers == null)
		{
			throw FxTrace.Exception.ArgumentNull("handlers");
		}
		if (handlers.Length == 0)
		{
			throw FxTrace.Exception.Argument("handlers", System.SR.InputTypeListEmptyError);
		}
		_handlerCtors = new ConstructorInfo[handlers.Length];
		for (int i = 0; i < handlers.Length; i++)
		{
			Type type = handlers[i];
			if (type == null)
			{
				throw FxTrace.Exception.Argument(string.Format(CultureInfo.InvariantCulture, "handlers[<<{0}>>]", i), System.SR.Format(System.SR.HttpMessageHandlerTypeNotSupported, "null", s_delegatingHandlerType.Name));
			}
			if (!s_delegatingHandlerType.IsAssignableFrom(type) || type.IsAbstract())
			{
				throw FxTrace.Exception.Argument(string.Format(CultureInfo.InvariantCulture, "handlers[<<{0}>>]", i), System.SR.Format(System.SR.HttpMessageHandlerTypeNotSupported, type.Name, s_delegatingHandlerType.Name));
			}
			ConstructorInfo constructor = type.GetConstructor(Array.Empty<Type>());
			_handlerCtors[i] = constructor ?? throw FxTrace.Exception.Argument(string.Format(CultureInfo.InvariantCulture, "handlers[<<{0}>>]", i), System.SR.Format(System.SR.HttpMessageHandlerTypeNotSupported, type.Name, s_delegatingHandlerType.Name));
		}
		_httpMessageHandlers = handlers;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HttpMessageHandlerFactory(Func<IEnumerable<DelegatingHandler>> handlers)
	{
		_handlerFunc = handlers ?? throw FxTrace.Exception.ArgumentNull("handlers");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected HttpMessageHandlerFactory()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public HttpMessageHandler Create(HttpMessageHandler innerChannel)
	{
		if (innerChannel == null)
		{
			throw FxTrace.Exception.ArgumentNull("innerChannel");
		}
		return OnCreate(innerChannel);
	}

	protected virtual HttpMessageHandler OnCreate(HttpMessageHandler innerChannel)
	{
		if (innerChannel == null)
		{
			throw FxTrace.Exception.ArgumentNull("innerChannel");
		}
		IEnumerable<DelegatingHandler> enumerable = null;
		try
		{
			if (_handlerFunc != null)
			{
				enumerable = _handlerFunc();
				if (enumerable != null)
				{
					foreach (DelegatingHandler item in enumerable)
					{
						if (item == null)
						{
							throw FxTrace.Exception.Argument("handlers", System.SR.Format(System.SR.DelegatingHandlerArrayFromFuncContainsNullItem, s_delegatingHandlerType.Name, GetFuncDetails(_handlerFunc)));
						}
					}
				}
			}
			else if (_handlerCtors != null)
			{
				DelegatingHandler[] array = new DelegatingHandler[_handlerCtors.Length];
				for (int i = 0; i < _handlerCtors.Length; i++)
				{
					int num = i;
					ConstructorInfo obj = _handlerCtors[i];
					object[] parameters = Array.Empty<Type>();
					array[num] = (DelegatingHandler)obj.Invoke(parameters);
				}
				enumerable = array;
			}
		}
		catch (TargetInvocationException exception)
		{
			throw FxTrace.Exception.AsError(exception);
		}
		HttpMessageHandler httpMessageHandler = innerChannel;
		if (enumerable != null)
		{
			foreach (DelegatingHandler item2 in enumerable)
			{
				if (item2.InnerHandler != null)
				{
					throw FxTrace.Exception.Argument("handlers", System.SR.Format(System.SR.DelegatingHandlerArrayHasNonNullInnerHandler, s_delegatingHandlerType.Name, "InnerHandler", item2.GetType().Name));
				}
				item2.InnerHandler = httpMessageHandler;
				httpMessageHandler = item2;
			}
		}
		return httpMessageHandler;
	}

	private static string GetFuncDetails(Func<IEnumerable<DelegatingHandler>> func)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}
}
