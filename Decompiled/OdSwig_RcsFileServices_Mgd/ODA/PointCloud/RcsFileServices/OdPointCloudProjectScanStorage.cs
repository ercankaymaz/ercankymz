using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdPointCloudProjectScanStorage : IDisposable
{
	public delegate IntPtr SwigDelegateOdPointCloudProjectScanStorage_0([MarshalAs(UnmanagedType.LPWStr)] string path);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdPointCloudProjectScanStorage_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(string) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPointCloudProjectScanStorage(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPointCloudProjectScanStorage obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPointCloudProjectScanStorage()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					RcsFileServices_GlobalsPINVOKE.delete_OdPointCloudProjectScanStorage(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual OdStreamBuf getScanStreamByPath(string path)
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectScanStorage_getScanStreamByPath(swigCPtr, path), bOwn: true, bTryAddToTransaction: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPointCloudProjectScanStorage()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdPointCloudProjectScanStorage(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPointCloudProjectScanStorage) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getScanStreamByPath", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetScanStreamByPath;
		}
		RcsFileServices_GlobalsPINVOKE.OdPointCloudProjectScanStorage_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPointCloudProjectScanStorage));
	}

	private IntPtr SwigDirectorMethodgetScanStreamByPath([MarshalAs(UnmanagedType.LPWStr)] string path)
	{
		return OdStreamBuf.getCPtr(getScanStreamByPath(path)).Handle;
	}
}
