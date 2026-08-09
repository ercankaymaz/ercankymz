using System.IdentityModel.Selectors;
using System.Threading.Tasks;

namespace System.ServiceModel.Security;

internal abstract class CommunicationObjectSecurityTokenAuthenticator : SecurityTokenAuthenticator, ICommunicationObject, ISecurityCommunicationObject
{
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

	protected CommunicationObjectSecurityTokenAuthenticator()
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

	public IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return new OperationWithTimeoutAsyncResult(OnClose, timeout, callback, state);
	}

	public IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return new OperationWithTimeoutAsyncResult(OnOpen, timeout, callback, state);
	}

	public virtual void OnClose(TimeSpan timeout)
	{
	}

	public Task OnCloseAsync(TimeSpan timeout)
	{
		return Task.CompletedTask;
	}

	public virtual void OnClosed()
	{
	}

	public virtual void OnClosing()
	{
	}

	public void OnEndClose(IAsyncResult result)
	{
		OperationWithTimeoutAsyncResult.End(result);
	}

	public void OnEndOpen(IAsyncResult result)
	{
		OperationWithTimeoutAsyncResult.End(result);
	}

	public virtual void OnFaulted()
	{
		OnAbort();
	}

	public virtual void OnOpen(TimeSpan timeout)
	{
	}

	public Task OnOpenAsync(TimeSpan timeout)
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
