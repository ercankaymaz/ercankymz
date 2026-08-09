using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdRcsDataManager : IDisposable
{
	public delegate IntPtr SwigDelegateOdRcsDataManager_0();

	public delegate ulong SwigDelegateOdRcsDataManager_1();

	public delegate void SwigDelegateOdRcsDataManager_2(IntPtr viewport, ushort pointSize);

	public delegate void SwigDelegateOdRcsDataManager_3(IntPtr pExternalScheduler);

	public delegate void SwigDelegateOdRcsDataManager_4();

	public delegate IntPtr SwigDelegateOdRcsDataManager_5();

	public delegate IntPtr SwigDelegateOdRcsDataManager_6(ushort pointSize);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdRcsDataManager_0 swigDelegate0;

	private SwigDelegateOdRcsDataManager_1 swigDelegate1;

	private SwigDelegateOdRcsDataManager_2 swigDelegate2;

	private SwigDelegateOdRcsDataManager_3 swigDelegate3;

	private SwigDelegateOdRcsDataManager_4 swigDelegate4;

	private SwigDelegateOdRcsDataManager_5 swigDelegate5;

	private SwigDelegateOdRcsDataManager_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[2]
	{
		typeof(OdGiViewport),
		typeof(ushort)
	};

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiPointCloudScheduler) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(ushort) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRcsDataManager(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRcsDataManager obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRcsDataManager()
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
					RcsFileServices_GlobalsPINVOKE.delete_OdRcsDataManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual OdPointCloudScanDatabase getScanDb()
	{
		OdPointCloudScanDatabase result = Helpers.GetObject<OdPointCloudScanDatabase>(RcsFileServices_GlobalsPINVOKE.OdRcsDataManager_getScanDb(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong pointsCount()
	{
		ulong result = RcsFileServices_GlobalsPINVOKE.OdRcsDataManager_pointsCount(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void updateListOfVisibleVoxels(OdGiViewport viewport, ushort pointSize)
	{
		RcsFileServices_GlobalsPINVOKE.OdRcsDataManager_updateListOfVisibleVoxels(swigCPtr, OdGiViewport.getCPtr(viewport), pointSize);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void loadPointsForVisibleVoxels(OdGiPointCloudScheduler pExternalScheduler)
	{
		RcsFileServices_GlobalsPINVOKE.OdRcsDataManager_loadPointsForVisibleVoxels__SWIG_0(swigCPtr, OdGiPointCloudScheduler.getCPtr(pExternalScheduler));
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void loadPointsForVisibleVoxels()
	{
		RcsFileServices_GlobalsPINVOKE.OdRcsDataManager_loadPointsForVisibleVoxels__SWIG_1(swigCPtr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRcsVisibleVoxelsIterator newVisibleVoxelsIterator()
	{
		OdRcsVisibleVoxelsIterator result = Helpers.GetObject<OdRcsVisibleVoxelsIterator>(RcsFileServices_GlobalsPINVOKE.OdRcsDataManager_newVisibleVoxelsIterator(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiPointCloud newGiPointCloud(ushort pointSize)
	{
		OdGiPointCloud rXObject = Helpers.GetRXObject<OdGiPointCloud>(RcsFileServices_GlobalsPINVOKE.OdRcsDataManager_newGiPointCloud(swigCPtr, pointSize), bOwn: true, bTryAddToTransaction: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdRcsDataManager_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRcsDataManager()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdRcsDataManager(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRcsDataManager) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getScanDb", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetScanDb;
		}
		if (SwigDerivedClassHasMethod("pointsCount", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodpointsCount;
		}
		if (SwigDerivedClassHasMethod("updateListOfVisibleVoxels", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodupdateListOfVisibleVoxels;
		}
		if (SwigDerivedClassHasMethod("loadPointsForVisibleVoxels", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodloadPointsForVisibleVoxels__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("loadPointsForVisibleVoxels", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodloadPointsForVisibleVoxels__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("newVisibleVoxelsIterator", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodnewVisibleVoxelsIterator;
		}
		if (SwigDerivedClassHasMethod("newGiPointCloud", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodnewGiPointCloud;
		}
		RcsFileServices_GlobalsPINVOKE.OdRcsDataManager_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRcsDataManager));
	}

	private IntPtr SwigDirectorMethodgetScanDb()
	{
		return OdPointCloudScanDatabase.getCPtr(getScanDb()).Handle;
	}

	private ulong SwigDirectorMethodpointsCount()
	{
		return pointsCount();
	}

	private void SwigDirectorMethodupdateListOfVisibleVoxels(IntPtr viewport, ushort pointSize)
	{
		try
		{
			updateListOfVisibleVoxels(Helpers.GetRXObject<OdGiViewport>(viewport, bOwn: false, bTryAddToTransaction: false), pointSize);
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodloadPointsForVisibleVoxels__SWIG_0(IntPtr pExternalScheduler)
	{
		try
		{
			loadPointsForVisibleVoxels((pExternalScheduler == IntPtr.Zero) ? null : new OdGiPointCloudScheduler(pExternalScheduler, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodloadPointsForVisibleVoxels__SWIG_1()
	{
		try
		{
			loadPointsForVisibleVoxels();
		}
		catch (OdEdEmptyInput err)
		{
			RcsFileServices_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			RcsFileServices_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			RcsFileServices_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			RcsFileServices_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodnewVisibleVoxelsIterator()
	{
		return OdRcsVisibleVoxelsIterator.getCPtr(newVisibleVoxelsIterator()).Handle;
	}

	private IntPtr SwigDirectorMethodnewGiPointCloud(ushort pointSize)
	{
		return OdGiPointCloud.getCPtr(newGiPointCloud(pointSize)).Handle;
	}
}
