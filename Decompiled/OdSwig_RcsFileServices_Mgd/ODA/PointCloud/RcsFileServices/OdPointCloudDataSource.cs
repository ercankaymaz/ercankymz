using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdPointCloudDataSource : IDisposable
{
	public delegate ulong SwigDelegateOdPointCloudDataSource_0();

	public delegate int SwigDelegateOdPointCloudDataSource_1();

	public delegate IntPtr SwigDelegateOdPointCloudDataSource_2();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdPointCloudDataSource_0 swigDelegate0;

	private SwigDelegateOdPointCloudDataSource_1 swigDelegate1;

	private SwigDelegateOdPointCloudDataSource_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPointCloudDataSource(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPointCloudDataSource obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPointCloudDataSource()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdPointCloudDataSource(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual ulong pointsCount()
	{
		ulong result = RcsFileServices_GlobalsPINVOKE.OdPointCloudDataSource_pointsCount(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdPointCloudDataSource_Units getUnits()
	{
		int result = RcsFileServices_GlobalsPINVOKE.OdPointCloudDataSource_getUnits(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdPointCloudDataSource_Units)result;
	}

	public virtual OdSourcePointIterator newSourcePointIterator()
	{
		OdSourcePointIterator result = Helpers.GetObject<OdSourcePointIterator>(RcsFileServices_GlobalsPINVOKE.OdPointCloudDataSource_newSourcePointIterator(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudDataSource_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPointCloudDataSource()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdPointCloudDataSource(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPointCloudDataSource) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("pointsCount", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodpointsCount;
		}
		if (SwigDerivedClassHasMethod("getUnits", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetUnits;
		}
		if (SwigDerivedClassHasMethod("newSourcePointIterator", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodnewSourcePointIterator;
		}
		RcsFileServices_GlobalsPINVOKE.OdPointCloudDataSource_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPointCloudDataSource));
	}

	private ulong SwigDirectorMethodpointsCount()
	{
		return pointsCount();
	}

	private int SwigDirectorMethodgetUnits()
	{
		return (int)getUnits();
	}

	private IntPtr SwigDirectorMethodnewSourcePointIterator()
	{
		return OdSourcePointIterator.getCPtr(newSourcePointIterator()).Handle;
	}
}
