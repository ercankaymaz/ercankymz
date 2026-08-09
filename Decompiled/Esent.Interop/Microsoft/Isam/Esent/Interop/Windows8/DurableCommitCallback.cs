using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Isam.Esent.Interop.Implementation;

namespace Microsoft.Isam.Esent.Interop.Windows8;

public class DurableCommitCallback : EsentResource
{
	private static readonly TraceSwitch TraceSwitch = new TraceSwitch("ESENT DurableCommitCallback", "Wrapper around unmanaged ESENT durable commit callback");

	private JET_INSTANCE instance;

	private JET_PFNDURABLECOMMITCALLBACK wrappedCallback;

	private NATIVE_JET_PFNDURABLECOMMITCALLBACK wrapperCallback;

	public DurableCommitCallback(JET_INSTANCE instance, JET_PFNDURABLECOMMITCALLBACK wrappedCallback)
	{
		this.instance = instance;
		this.wrappedCallback = wrappedCallback;
		wrapperCallback = NativeDurableCommitCallback;
		if (this.wrappedCallback != null)
		{
			RuntimeHelpers.PrepareMethod(this.wrappedCallback.Method.MethodHandle);
		}
		RuntimeHelpers.PrepareMethod(typeof(DurableCommitCallback).GetMethod("NativeDurableCommitCallback", BindingFlags.Instance | BindingFlags.NonPublic).MethodHandle);
		new InstanceParameters(this.instance).SetDurableCommitCallback(wrapperCallback);
		ResourceWasAllocated();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "DurableCommitCallback({0})", instance.ToString());
	}

	public void End()
	{
		CheckObjectIsNotDisposed();
		ReleaseResource();
	}

	protected override void ReleaseResource()
	{
		instance = JET_INSTANCE.Nil;
		wrappedCallback = null;
		wrapperCallback = null;
		ResourceWasReleased();
	}

	private JET_err NativeDurableCommitCallback(IntPtr instance, ref NATIVE_COMMIT_ID commitIdSeen, uint grbit)
	{
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			JET_INSTANCE jET_INSTANCE = new JET_INSTANCE
			{
				Value = instance
			};
			if (this.instance != jET_INSTANCE)
			{
				return JET_err.CallbackFailed;
			}
			JET_COMMIT_ID pCommitIdSeen = new JET_COMMIT_ID(commitIdSeen);
			return wrappedCallback(jET_INSTANCE, pCommitIdSeen, (DurableCommitCallbackGrbit)checked((int)grbit));
		}
		catch (Exception exception)
		{
			JetApi.ReportUnhandledException(exception, "Unhandled exception during NativeDurableCommitCallback");
			return JET_err.CallbackFailed;
		}
	}
}
