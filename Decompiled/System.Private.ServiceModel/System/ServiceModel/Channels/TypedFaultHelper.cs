using System.Collections.Generic;
using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class TypedFaultHelper<TState> : FaultHelper
{
	private InterruptibleWaitObject _closeHandle;

	private TimeSpan _defaultCloseTimeout;

	private TimeSpan _defaultSendTimeout;

	private Dictionary<IReliableChannelBinder, TState> _faultList = new Dictionary<IReliableChannelBinder, TState>();

	protected TypedFaultHelper(TimeSpan defaultSendTimeout, TimeSpan defaultCloseTimeout)
	{
		_defaultSendTimeout = defaultSendTimeout;
		_defaultCloseTimeout = defaultCloseTimeout;
	}

	public override void Abort()
	{
		Dictionary<IReliableChannelBinder, TState> faultList;
		InterruptibleWaitObject closeHandle;
		lock (base.ThisLock)
		{
			faultList = _faultList;
			_faultList = null;
			closeHandle = _closeHandle;
		}
		if (faultList == null || faultList.Count == 0)
		{
			closeHandle?.Set();
			return;
		}
		foreach (KeyValuePair<IReliableChannelBinder, TState> item in faultList)
		{
			AbortState(item.Value, isOnAbortThread: true);
			item.Key.Abort();
		}
		closeHandle?.Set();
	}

	private void AbortBinder(IReliableChannelBinder binder)
	{
		try
		{
			binder.Abort();
		}
		finally
		{
			RemoveBinder(binder);
		}
	}

	private async Task AsyncCloseBinder(IReliableChannelBinder binder)
	{
		try
		{
			try
			{
				await binder.CloseAsync(_defaultCloseTimeout);
			}
			finally
			{
				RemoveBinder(binder);
			}
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			binder.HandleException(ex);
		}
	}

	protected abstract void AbortState(TState state, bool isOnAbortThread);

	private void AfterClose()
	{
		Abort();
	}

	private bool BeforeClose()
	{
		lock (base.ThisLock)
		{
			if (_faultList == null || _faultList.Count == 0)
			{
				return true;
			}
			_closeHandle = new InterruptibleWaitObject(signaled: false, throwTimeoutByDefault: false);
		}
		return false;
	}

	public override async Task CloseAsync(TimeSpan timeout)
	{
		if (!BeforeClose())
		{
			await _closeHandle.WaitAsync(timeout);
			AfterClose();
		}
	}

	protected abstract Task SendFaultAsync(IReliableChannelBinder binder, TState state, TimeSpan timeout);

	protected abstract TState GetState(RequestContext requestContext, Message faultMessage);

	protected void RemoveBinder(IReliableChannelBinder binder)
	{
		InterruptibleWaitObject closeHandle;
		lock (base.ThisLock)
		{
			if (_faultList == null)
			{
				return;
			}
			_faultList.Remove(binder);
			if (_closeHandle == null || _faultList.Count > 0)
			{
				return;
			}
			_faultList = null;
			closeHandle = _closeHandle;
		}
		closeHandle.Set();
	}

	protected async Task SendFaultAsync(IReliableChannelBinder binder, TState state)
	{
		bool throwing = true;
		try
		{
			await SendFaultAsync(binder, state, _defaultSendTimeout);
			await AsyncCloseBinder(binder);
			throwing = false;
		}
		finally
		{
			if (throwing)
			{
				AbortState(state, isOnAbortThread: false);
				AbortBinder(binder);
			}
		}
	}

	public override async Task SendFaultAsync(IReliableChannelBinder binder, RequestContext requestContext, Message faultMessage)
	{
		_ = 1;
		try
		{
			bool flag = true;
			TState state = GetState(requestContext, faultMessage);
			lock (base.ThisLock)
			{
				if (_faultList != null)
				{
					flag = false;
					_faultList.Add(binder, state);
				}
			}
			if (flag)
			{
				AbortState(state, isOnAbortThread: false);
				binder.Abort();
			}
			await TaskHelpers.EnsureDefaultTaskScheduler();
			await SendFaultAsync(binder, state);
		}
		catch (Exception ex)
		{
			if (Fx.IsFatal(ex))
			{
				throw;
			}
			binder.HandleException(ex);
		}
	}
}
