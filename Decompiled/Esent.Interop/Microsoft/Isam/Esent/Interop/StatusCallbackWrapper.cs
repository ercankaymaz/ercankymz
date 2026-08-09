using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Microsoft.Isam.Esent.Interop;

internal sealed class StatusCallbackWrapper
{
	private static readonly TraceSwitch TraceSwitch;

	private readonly JET_PFNSTATUS wrappedCallback;

	private readonly NATIVE_PFNSTATUS nativeCallback;

	public NATIVE_PFNSTATUS NativeCallback => nativeCallback;

	private Exception SavedException { get; set; }

	private bool ThreadWasAborted { get; set; }

	static StatusCallbackWrapper()
	{
		TraceSwitch = new TraceSwitch("ESENT StatusCallbackWrapper", "Wrapper around unmanaged ESENT status callback");
		RuntimeHelpers.PrepareMethod(typeof(StatusCallbackWrapper).GetMethod("CallbackImpl", BindingFlags.Instance | BindingFlags.NonPublic).MethodHandle);
	}

	public StatusCallbackWrapper(JET_PFNSTATUS wrappedCallback)
	{
		this.wrappedCallback = wrappedCallback;
		nativeCallback = ((wrappedCallback != null) ? new NATIVE_PFNSTATUS(CallbackImpl) : null);
	}

	public void ThrowSavedException()
	{
		if (ThreadWasAborted)
		{
			Thread.CurrentThread.Abort();
		}
		if (SavedException != null)
		{
			throw SavedException;
		}
	}

	private JET_err CallbackImpl(IntPtr nativeSesid, uint nativeSnp, uint nativeSnt, IntPtr nativeData)
	{
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			JET_SESID sesid = new JET_SESID
			{
				Value = nativeSesid
			};
			JET_SNP snp = (JET_SNP)checked((int)nativeSnp);
			JET_SNT snt = (JET_SNT)checked((int)nativeSnt);
			object managedData = CallbackDataConverter.GetManagedData(nativeData, snp, snt);
			return wrappedCallback(sesid, snp, snt, managedData);
		}
		catch (ThreadAbortException)
		{
			ThreadWasAborted = true;
			LibraryHelpers.ThreadResetAbort();
			return JET_err.CallbackFailed;
		}
		catch (Exception savedException)
		{
			SavedException = savedException;
			return JET_err.CallbackFailed;
		}
	}
}
