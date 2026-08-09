using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.PointCloud.RcsFileServices;

public class OdPointCloudDatabaseReceiver : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPointCloudDatabaseReceiver_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPointCloudDatabaseReceiver_1();

	public delegate void SwigDelegateOdPointCloudDatabaseReceiver_2(IntPtr pSource);

	public delegate void SwigDelegateOdPointCloudDatabaseReceiver_3(IntPtr pScanDb, bool dbIsOk);

	public delegate void SwigDelegateOdPointCloudDatabaseReceiver_4(IntPtr pScanDb);

	public delegate void SwigDelegateOdPointCloudDatabaseReceiver_5(IntPtr pProjDb, bool dbIsOk);

	public delegate void SwigDelegateOdPointCloudDatabaseReceiver_6(IntPtr pProjDb);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPointCloudDatabaseReceiver_0 swigDelegate0;

	private SwigDelegateOdPointCloudDatabaseReceiver_1 swigDelegate1;

	private SwigDelegateOdPointCloudDatabaseReceiver_2 swigDelegate2;

	private SwigDelegateOdPointCloudDatabaseReceiver_3 swigDelegate3;

	private SwigDelegateOdPointCloudDatabaseReceiver_4 swigDelegate4;

	private SwigDelegateOdPointCloudDatabaseReceiver_5 swigDelegate5;

	private SwigDelegateOdPointCloudDatabaseReceiver_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdPointCloudScanDatabase),
		typeof(bool)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdPointCloudScanDatabase) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdPointCloudProjectDatabase),
		typeof(bool)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdPointCloudProjectDatabase) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPointCloudDatabaseReceiver(IntPtr cPtr, bool cMemoryOwn)
		: base(RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPointCloudDatabaseReceiver obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					RcsFileServices_GlobalsPINVOKE.delete_OdPointCloudDatabaseReceiver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPointCloudDatabaseReceiver cast(OdRxObject pObj)
	{
		OdPointCloudDatabaseReceiver rXObject = Helpers.GetRXObject<OdPointCloudDatabaseReceiver>(RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_desc(), bOwn: false, bTryAddToTransaction: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_isASwigExplicitOdPointCloudDatabaseReceiver(swigCPtr) : RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_queryXSwigExplicitOdPointCloudDatabaseReceiver(swigCPtr, OdRxClass.getCPtr(protocolClass)) : RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPointCloudDatabaseReceiver createObject()
	{
		OdPointCloudDatabaseReceiver rXObject = Helpers.GetRXObject<OdPointCloudDatabaseReceiver>(RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void receiveIndividualScanDb(OdPointCloudScanDatabase pScanDb, bool dbIsOk)
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_receiveIndividualScanDb__SWIG_0(swigCPtr, OdPointCloudScanDatabase.getCPtr(pScanDb), dbIsOk);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void receiveIndividualScanDb(OdPointCloudScanDatabase pScanDb)
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_receiveIndividualScanDb__SWIG_1(swigCPtr, OdPointCloudScanDatabase.getCPtr(pScanDb));
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void receiveProjDb(OdPointCloudProjectDatabase pProjDb, bool dbIsOk)
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_receiveProjDb__SWIG_0(swigCPtr, OdPointCloudProjectDatabase.getCPtr(pProjDb), dbIsOk);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void receiveProjDb(OdPointCloudProjectDatabase pProjDb)
	{
		RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_receiveProjDb__SWIG_1(swigCPtr, OdPointCloudProjectDatabase.getCPtr(pProjDb));
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_getRealClassName(ptr);
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPointCloudDatabaseReceiver()
		: this(RcsFileServices_GlobalsPINVOKE.new_OdPointCloudDatabaseReceiver(), cMemoryOwn: true)
	{
		if (RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw RcsFileServices_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPointCloudDatabaseReceiver) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("receiveIndividualScanDb", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodreceiveIndividualScanDb__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("receiveIndividualScanDb", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodreceiveIndividualScanDb__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("receiveProjDb", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodreceiveProjDb__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("receiveProjDb", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodreceiveProjDb__SWIG_1;
		}
		RcsFileServices_GlobalsPINVOKE.OdPointCloudDatabaseReceiver_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPointCloudDatabaseReceiver));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodreceiveIndividualScanDb__SWIG_0(IntPtr pScanDb, bool dbIsOk)
	{
		try
		{
			receiveIndividualScanDb(Helpers.GetObject<OdPointCloudScanDatabase>(pScanDb, bOwn: true, bTryAddToTransaction: false), dbIsOk);
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

	private void SwigDirectorMethodreceiveIndividualScanDb__SWIG_1(IntPtr pScanDb)
	{
		try
		{
			receiveIndividualScanDb(Helpers.GetObject<OdPointCloudScanDatabase>(pScanDb, bOwn: true, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodreceiveProjDb__SWIG_0(IntPtr pProjDb, bool dbIsOk)
	{
		try
		{
			receiveProjDb(Helpers.GetObject<OdPointCloudProjectDatabase>(pProjDb, bOwn: true, bTryAddToTransaction: false), dbIsOk);
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

	private void SwigDirectorMethodreceiveProjDb__SWIG_1(IntPtr pProjDb)
	{
		try
		{
			receiveProjDb(Helpers.GetObject<OdPointCloudProjectDatabase>(pProjDb, bOwn: true, bTryAddToTransaction: false));
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
}
