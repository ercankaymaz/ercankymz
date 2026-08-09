using System;

namespace DevAge.Patterns;

public abstract class AsyncActivityBase : ActivityBase
{
	private IAsyncResult iasyncResult_0 = null;

	protected override void ResetRunningStatus()
	{
		base.ResetRunningStatus();
		iasyncResult_0 = null;
	}

	protected abstract void OnBeginWork(AsyncCallback callback);

	protected abstract void OnEndWork(IAsyncResult asyncResult);

	private void method_0(IAsyncResult iasyncResult_1)
	{
		iasyncResult_0 = iasyncResult_1;
		if (iasyncResult_0 == null)
		{
			throw new DevAgeApplicationException("Invalid async activity, IAsyncResult is null");
		}
		DoWork();
	}

	protected override void OnWork()
	{
		OnEndWork(iasyncResult_0);
	}

	protected override void StartActivity()
	{
		OnBeginWork(method_0);
	}
}
