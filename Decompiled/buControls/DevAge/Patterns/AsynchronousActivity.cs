using System;

namespace DevAge.Patterns;

public class AsynchronousActivity : AsyncActivityBase
{
	private delegate void Delegate4();

	private Delegate4 delegate4_0;

	public AsynchronousActivity()
	{
		delegate4_0 = OnAsyncWork;
	}

	protected override void OnBeginWork(AsyncCallback callback)
	{
		delegate4_0.BeginInvoke(callback, new object());
	}

	protected virtual void OnAsyncWork()
	{
	}

	protected override void OnEndWork(IAsyncResult asyncResult)
	{
		delegate4_0.EndInvoke(asyncResult);
	}
}
