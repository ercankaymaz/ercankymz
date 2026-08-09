using System.Collections.Generic;
using System.Reflection;
using System.Runtime;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal class ImmutableClientRuntime
{
	internal class DisplayInitializationUIAsyncResult : AsyncResult
	{
		private ServiceChannel _channel;

		private int _index = -1;

		private IInteractiveChannelInitializer[] _initializers;

		private IClientChannel _proxy;

		private static AsyncCallback s_callback = Fx.ThunkCallback(Callback);

		internal DisplayInitializationUIAsyncResult(ServiceChannel channel, IInteractiveChannelInitializer[] initializers, AsyncCallback callback, object state)
			: base(callback, state)
		{
			_channel = channel;
			_initializers = initializers;
			_proxy = ServiceChannelFactory.GetServiceChannel(channel.Proxy);
			CallBegin(completedSynchronously: true);
		}

		private void CallBegin(bool completedSynchronously)
		{
			while (++_index < _initializers.Length)
			{
				IAsyncResult asyncResult = null;
				Exception exception = null;
				try
				{
					asyncResult = _initializers[_index].BeginDisplayInitializationUI(_proxy, s_callback, this);
				}
				catch (Exception ex)
				{
					if (Fx.IsFatal(ex))
					{
						throw;
					}
					exception = ex;
				}
				if (exception == null)
				{
					if (!asyncResult.CompletedSynchronously)
					{
						return;
					}
					CallEnd(asyncResult, out exception);
				}
				if (exception != null)
				{
					CallComplete(completedSynchronously, exception);
					return;
				}
			}
			CallComplete(completedSynchronously, null);
		}

		private static void Callback(IAsyncResult result)
		{
			if (!result.CompletedSynchronously)
			{
				DisplayInitializationUIAsyncResult displayInitializationUIAsyncResult = (DisplayInitializationUIAsyncResult)result.AsyncState;
				Exception exception = null;
				displayInitializationUIAsyncResult.CallEnd(result, out exception);
				if (exception != null)
				{
					displayInitializationUIAsyncResult.CallComplete(completedSynchronously: false, exception);
				}
				else
				{
					displayInitializationUIAsyncResult.CallBegin(completedSynchronously: false);
				}
			}
		}

		private void CallEnd(IAsyncResult result, out Exception exception)
		{
			try
			{
				_initializers[_index].EndDisplayInitializationUI(result);
				exception = null;
			}
			catch (Exception ex)
			{
				if (Fx.IsFatal(ex))
				{
					throw;
				}
				exception = ex;
			}
		}

		private void CallComplete(bool completedSynchronously, Exception exception)
		{
			Complete(completedSynchronously, exception);
		}

		internal static void End(IAsyncResult result)
		{
			AsyncResult.End<DisplayInitializationUIAsyncResult>(result);
		}
	}

	private bool _addTransactionFlowProperties;

	private IInteractiveChannelInitializer[] _interactiveChannelInitializers;

	private IChannelInitializer[] _channelInitializers;

	private IClientMessageInspector[] _messageInspectors;

	private Dictionary<string, ProxyOperationRuntime> _operations;

	private bool _validateMustUnderstand;

	internal int MessageInspectorCorrelationOffset => 0;

	internal int ParameterInspectorCorrelationOffset => _messageInspectors.Length;

	internal int CorrelationCount { get; }

	internal IClientOperationSelector OperationSelector { get; }

	internal ProxyOperationRuntime UnhandledProxyOperation { get; }

	internal bool UseSynchronizationContext { get; }

	internal bool ValidateMustUnderstand
	{
		get
		{
			return _validateMustUnderstand;
		}
		set
		{
			_validateMustUnderstand = value;
		}
	}

	internal ImmutableClientRuntime(ClientRuntime behavior)
	{
		_channelInitializers = EmptyArray<IChannelInitializer>.ToArray(behavior.ChannelInitializers);
		_interactiveChannelInitializers = EmptyArray<IInteractiveChannelInitializer>.ToArray(behavior.InteractiveChannelInitializers);
		_messageInspectors = EmptyArray<IClientMessageInspector>.ToArray(behavior.MessageInspectors);
		OperationSelector = behavior.OperationSelector;
		UseSynchronizationContext = behavior.UseSynchronizationContext;
		_validateMustUnderstand = behavior.ValidateMustUnderstand;
		UnhandledProxyOperation = new ProxyOperationRuntime(behavior.UnhandledClientOperation, this);
		_addTransactionFlowProperties = behavior.AddTransactionFlowProperties;
		_operations = new Dictionary<string, ProxyOperationRuntime>();
		for (int i = 0; i < behavior.Operations.Count; i++)
		{
			ClientOperation clientOperation = behavior.Operations[i];
			ProxyOperationRuntime value = new ProxyOperationRuntime(clientOperation, this);
			_operations.Add(clientOperation.Name, value);
		}
		CorrelationCount = _messageInspectors.Length + behavior.MaxParameterInspectors;
	}

	internal void AfterReceiveReply(ref ProxyRpc rpc)
	{
		int messageInspectorCorrelationOffset = MessageInspectorCorrelationOffset;
		try
		{
			for (int i = 0; i < _messageInspectors.Length; i++)
			{
				_messageInspectors[i].AfterReceiveReply(ref rpc.Reply, rpc.Correlation[messageInspectorCorrelationOffset + i]);
				if (WcfEventSource.Instance.ClientMessageInspectorAfterReceiveInvokedIsEnabled())
				{
					WcfEventSource.Instance.ClientMessageInspectorAfterReceiveInvoked(rpc.EventTraceActivity, _messageInspectors[i].GetType().FullName);
				}
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (ErrorBehavior.ShouldRethrowClientSideExceptionAsIs(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	internal void BeforeSendRequest(ref ProxyRpc rpc)
	{
		int messageInspectorCorrelationOffset = MessageInspectorCorrelationOffset;
		try
		{
			for (int i = 0; i < _messageInspectors.Length; i++)
			{
				ServiceChannel serviceChannel = ServiceChannelFactory.GetServiceChannel(rpc.Channel.Proxy);
				rpc.Correlation[messageInspectorCorrelationOffset + i] = _messageInspectors[i].BeforeSendRequest(ref rpc.Request, serviceChannel);
				if (WcfEventSource.Instance.ClientMessageInspectorBeforeSendInvokedIsEnabled())
				{
					WcfEventSource.Instance.ClientMessageInspectorBeforeSendInvoked(rpc.EventTraceActivity, _messageInspectors[i].GetType().FullName);
				}
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (ErrorBehavior.ShouldRethrowClientSideExceptionAsIs(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	internal void DisplayInitializationUI(ServiceChannel channel)
	{
		EndDisplayInitializationUI(BeginDisplayInitializationUI(channel, null, null));
	}

	internal IAsyncResult BeginDisplayInitializationUI(ServiceChannel channel, AsyncCallback callback, object state)
	{
		return new DisplayInitializationUIAsyncResult(channel, _interactiveChannelInitializers, callback, state);
	}

	internal void EndDisplayInitializationUI(IAsyncResult result)
	{
		DisplayInitializationUIAsyncResult.End(result);
	}

	internal void InitializeChannel(IClientChannel channel)
	{
		try
		{
			for (int i = 0; i < _channelInitializers.Length; i++)
			{
				_channelInitializers[i].Initialize(channel);
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (ErrorBehavior.ShouldRethrowClientSideExceptionAsIs(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	internal ProxyOperationRuntime GetOperation(MethodBase methodBase, object[] args, out bool canCacheResult)
	{
		if (OperationSelector == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.SFxNeedProxyBehaviorOperationSelector2, methodBase.Name, methodBase.DeclaringType.Name)));
		}
		try
		{
			if (OperationSelector.AreParametersRequiredForSelection)
			{
				canCacheResult = false;
			}
			else
			{
				args = null;
				canCacheResult = true;
			}
			string text = OperationSelector.SelectOperation(methodBase, args);
			if (text != null && _operations.TryGetValue(text, out var value))
			{
				return value;
			}
			return null;
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			if (ErrorBehavior.ShouldRethrowClientSideExceptionAsIs(ex))
			{
				throw;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperCallback(ex);
		}
	}

	internal ProxyOperationRuntime GetOperationByName(string operationName)
	{
		ProxyOperationRuntime value = null;
		if (_operations.TryGetValue(operationName, out value))
		{
			return value;
		}
		return null;
	}
}
