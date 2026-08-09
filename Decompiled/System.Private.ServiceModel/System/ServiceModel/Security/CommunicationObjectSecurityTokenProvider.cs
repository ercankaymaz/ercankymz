using System.IdentityModel.Selectors;
using System.Runtime.Diagnostics;
using System.Threading.Tasks;

namespace System.ServiceModel.Security;

internal abstract class CommunicationObjectSecurityTokenProvider : SecurityTokenProvider, IAsyncCommunicationObject, ICommunicationObject, ISecurityCommunicationObject
{
	private EventTraceActivity _eventTraceActivity;

	internal EventTraceActivity EventTraceActivity
	{
		get
		{
			if (_eventTraceActivity == null)
			{
				_eventTraceActivity = EventTraceActivity.GetFromThreadOrCreate();
			}
			return _eventTraceActivity;
		}
	}

	protected WrapperSecurityCommunicationObject CommunicationObject { get; }

	public CommunicationState State => CommunicationObject.State;

	public virtual TimeSpan DefaultOpenTimeout => ServiceDefaults.OpenTimeout;

	public virtual TimeSpan DefaultCloseTimeout => ServiceDefaults.CloseTimeout;

	public event EventHandler Closed
	{
		add
		{
			CommunicationObject.Closed += value;
		}
		remove
		{
			CommunicationObject.Closed -= value;
		}
	}

	public event EventHandler Closing
	{
		add
		{
			CommunicationObject.Closing += value;
		}
		remove
		{
			CommunicationObject.Closing -= value;
		}
	}

	public event EventHandler Faulted
	{
		add
		{
			CommunicationObject.Faulted += value;
		}
		remove
		{
			CommunicationObject.Faulted -= value;
		}
	}

	public event EventHandler Opened
	{
		add
		{
			CommunicationObject.Opened += value;
		}
		remove
		{
			CommunicationObject.Opened -= value;
		}
	}

	public event EventHandler Opening
	{
		add
		{
			CommunicationObject.Opening += value;
		}
		remove
		{
			CommunicationObject.Opening -= value;
		}
	}

	protected CommunicationObjectSecurityTokenProvider()
	{
		CommunicationObject = new WrapperSecurityCommunicationObject(this);
	}

	public void Abort()
	{
		CommunicationObject.Abort();
	}

	public void Close()
	{
		CommunicationObject.Close();
	}

	public Task CloseAsync(TimeSpan timeout)
	{
		return ((IAsyncCommunicationObject)CommunicationObject).CloseAsync(timeout);
	}

	public void Close(TimeSpan timeout)
	{
		CommunicationObject.Close(timeout);
	}

	public IAsyncResult BeginClose(AsyncCallback callback, object state)
	{
		return CommunicationObject.BeginClose(callback, state);
	}

	public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CommunicationObject.BeginClose(timeout, callback, state);
	}

	public void EndClose(IAsyncResult result)
	{
		CommunicationObject.EndClose(result);
	}

	public void Open()
	{
		CommunicationObject.Open();
	}

	public Task OpenAsync(TimeSpan timeout)
	{
		return ((IAsyncCommunicationObject)CommunicationObject).OpenAsync(timeout);
	}

	public void Open(TimeSpan timeout)
	{
		CommunicationObject.Open(timeout);
	}

	public IAsyncResult BeginOpen(AsyncCallback callback, object state)
	{
		return CommunicationObject.BeginOpen(callback, state);
	}

	public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return CommunicationObject.BeginOpen(timeout, callback, state);
	}

	public void EndOpen(IAsyncResult result)
	{
		CommunicationObject.EndOpen(result);
	}

	public void Dispose()
	{
		Close();
	}

	public virtual void OnAbort()
	{
	}

	public virtual Task OnCloseAsync(TimeSpan timeout)
	{
		return Task.CompletedTask;
	}

	public virtual void OnClosed()
	{
	}

	public virtual void OnClosing()
	{
	}

	public virtual void OnFaulted()
	{
		OnAbort();
	}

	public virtual Task OnOpenAsync(TimeSpan timeout)
	{
		return Task.CompletedTask;
	}

	public virtual void OnOpened()
	{
	}

	public virtual void OnOpening()
	{
	}
}
