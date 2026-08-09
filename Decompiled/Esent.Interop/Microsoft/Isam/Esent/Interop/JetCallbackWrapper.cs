using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Microsoft.Isam.Esent.Interop;

internal sealed class JetCallbackWrapper
{
	private static readonly TraceSwitch TraceSwitch;

	private readonly WeakReference wrappedCallback;

	private readonly NATIVE_CALLBACK nativeCallback;

	public bool IsAlive => wrappedCallback.IsAlive;

	public NATIVE_CALLBACK NativeCallback => nativeCallback;

	static JetCallbackWrapper()
	{
		TraceSwitch = new TraceSwitch("ESENT JetCallbackWrapper", "Wrapper around unmanaged ESENT callback");
		RuntimeHelpers.PrepareMethod(typeof(StatusCallbackWrapper).GetMethod("CallbackImpl", BindingFlags.Instance | BindingFlags.NonPublic).MethodHandle);
	}

	public JetCallbackWrapper(JET_CALLBACK callback)
	{
		wrappedCallback = new WeakReference(callback);
		nativeCallback = CallbackImpl;
	}

	public bool IsWrapping(JET_CALLBACK callback)
	{
		return callback.Equals(wrappedCallback.Target);
	}

	private JET_err CallbackImpl(IntPtr nativeSesid, uint nativeDbid, IntPtr nativeTableid, uint nativeCbtyp, IntPtr arg1, IntPtr arg2, IntPtr nativeContext, IntPtr unused)
	{
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			JET_SESID sesid = new JET_SESID
			{
				Value = nativeSesid
			};
			JET_DBID dbid = new JET_DBID
			{
				Value = nativeDbid
			};
			JET_TABLEID tableid = new JET_TABLEID
			{
				Value = nativeTableid
			};
			JET_cbtyp cbtyp = (JET_cbtyp)checked((int)nativeCbtyp);
			return ((JET_CALLBACK)wrappedCallback.Target)(sesid, dbid, tableid, cbtyp, null, null, nativeContext, IntPtr.Zero);
		}
		catch (Exception)
		{
			return JET_err.CallbackFailed;
		}
	}
}
