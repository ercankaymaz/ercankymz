using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsStateBranchReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGsStateBranchReactor_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdGsStateBranchReactor_1();

	public delegate void SwigDelegateOdGsStateBranchReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdGsStateBranchReactor_3(IntPtr pStateBranch, IntPtr pStateBranchAdded);

	public delegate void SwigDelegateOdGsStateBranchReactor_4(IntPtr pStateBranch, IntPtr pStateBranchRemoved);

	public delegate void SwigDelegateOdGsStateBranchReactor_5(IntPtr pStateBranch, IntPtr gsMarker, IntPtr pData);

	public delegate void SwigDelegateOdGsStateBranchReactor_6(IntPtr pStateBranch, IntPtr gsMarker);

	public delegate void SwigDelegateOdGsStateBranchReactor_7(IntPtr pStateBranch, IntPtr gsMarker, IntPtr pPrevData, IntPtr pData);

	public delegate void SwigDelegateOdGsStateBranchReactor_8(IntPtr pStateBranch, IntPtr pPrevData, IntPtr pData);

	public delegate void SwigDelegateOdGsStateBranchReactor_9(IntPtr pGsNode, IntPtr pStateBranch, IntPtr extBefore, IntPtr extAfter);

	public delegate void SwigDelegateOdGsStateBranchReactor_10(IntPtr pGsNode, IntPtr pStateBranch);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsStateBranchReactor_0 swigDelegate0;

	private SwigDelegateOdGsStateBranchReactor_1 swigDelegate1;

	private SwigDelegateOdGsStateBranchReactor_2 swigDelegate2;

	private SwigDelegateOdGsStateBranchReactor_3 swigDelegate3;

	private SwigDelegateOdGsStateBranchReactor_4 swigDelegate4;

	private SwigDelegateOdGsStateBranchReactor_5 swigDelegate5;

	private SwigDelegateOdGsStateBranchReactor_6 swigDelegate6;

	private SwigDelegateOdGsStateBranchReactor_7 swigDelegate7;

	private SwigDelegateOdGsStateBranchReactor_8 swigDelegate8;

	private SwigDelegateOdGsStateBranchReactor_9 swigDelegate9;

	private SwigDelegateOdGsStateBranchReactor_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdGsStateBranch),
		typeof(OdGsStateBranch)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGsStateBranch),
		typeof(OdGsStateBranch)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdGsStateBranch),
		typeof(IntPtr),
		typeof(OdGsSimpleParam)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGsStateBranch),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes7 = new Type[4]
	{
		typeof(OdGsStateBranch),
		typeof(IntPtr),
		typeof(OdGsSimpleParam),
		typeof(OdGsSimpleParam)
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdGsStateBranch),
		typeof(OdGsSimpleParam),
		typeof(OdGsSimpleParam)
	};

	private static Type[] swigMethodTypes9 = new Type[4]
	{
		typeof(OdGsCache),
		typeof(OdGsStateBranch),
		typeof(OdGeExtents3d),
		typeof(OdGeExtents3d)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGsCache),
		typeof(OdGsStateBranch)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsStateBranchReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsStateBranchReactor obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsStateBranchReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual void onChildAdded(OdGsStateBranch pStateBranch, OdGsStateBranch pStateBranchAdded)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_onChildAdded(swigCPtr, OdGsStateBranch.getCPtr(pStateBranch), OdGsStateBranch.getCPtr(pStateBranchAdded));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onChildRemoved(OdGsStateBranch pStateBranch, OdGsStateBranch pStateBranchRemoved)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_onChildRemoved(swigCPtr, OdGsStateBranch.getCPtr(pStateBranch), OdGsStateBranch.getCPtr(pStateBranchRemoved));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onMarkerAdded(OdGsStateBranch pStateBranch, IntPtr gsMarker, OdGsSimpleParam pData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_onMarkerAdded(swigCPtr, OdGsStateBranch.getCPtr(pStateBranch), gsMarker, OdGsSimpleParam.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onMarkerRemoved(OdGsStateBranch pStateBranch, IntPtr gsMarker)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_onMarkerRemoved(swigCPtr, OdGsStateBranch.getCPtr(pStateBranch), gsMarker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onMarkerDataModified(OdGsStateBranch pStateBranch, IntPtr gsMarker, OdGsSimpleParam pPrevData, OdGsSimpleParam pData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_onMarkerDataModified(swigCPtr, OdGsStateBranch.getCPtr(pStateBranch), gsMarker, OdGsSimpleParam.getCPtr(pPrevData), OdGsSimpleParam.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onDataModified(OdGsStateBranch pStateBranch, OdGsSimpleParam pPrevData, OdGsSimpleParam pData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_onDataModified(swigCPtr, OdGsStateBranch.getCPtr(pStateBranch), OdGsSimpleParam.getCPtr(pPrevData), OdGsSimpleParam.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onExtentsChanged(OdGsCache pGsNode, OdGsStateBranch pStateBranch, OdGeExtents3d extBefore, OdGeExtents3d extAfter)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_onExtentsChanged(swigCPtr, OdGsCache.getCPtr(pGsNode), OdGsStateBranch.getCPtr(pStateBranch), OdGeExtents3d.getCPtr(extBefore), OdGeExtents3d.getCPtr(extAfter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onBranchDetach(OdGsCache pGsNode, OdGsStateBranch pStateBranch)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_onBranchDetach(swigCPtr, OdGsCache.getCPtr(pGsNode), OdGsStateBranch.getCPtr(pStateBranch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsStateBranchReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsStateBranchReactor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsStateBranchReactor) != GetType();
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
		if (SwigDerivedClassHasMethod("onChildAdded", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodonChildAdded;
		}
		if (SwigDerivedClassHasMethod("onChildRemoved", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodonChildRemoved;
		}
		if (SwigDerivedClassHasMethod("onMarkerAdded", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodonMarkerAdded;
		}
		if (SwigDerivedClassHasMethod("onMarkerRemoved", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodonMarkerRemoved;
		}
		if (SwigDerivedClassHasMethod("onMarkerDataModified", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodonMarkerDataModified;
		}
		if (SwigDerivedClassHasMethod("onDataModified", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodonDataModified;
		}
		if (SwigDerivedClassHasMethod("onExtentsChanged", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodonExtentsChanged;
		}
		if (SwigDerivedClassHasMethod("onBranchDetach", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodonBranchDetach;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranchReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsStateBranchReactor));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodonChildAdded(IntPtr pStateBranch, IntPtr pStateBranchAdded)
	{
		try
		{
			onChildAdded(Helpers.GetObject<OdGsStateBranch>(pStateBranch, bOwn: false, bTryAddToTransaction: false), Helpers.GetObject<OdGsStateBranch>(pStateBranchAdded, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodonChildRemoved(IntPtr pStateBranch, IntPtr pStateBranchRemoved)
	{
		try
		{
			onChildRemoved(Helpers.GetObject<OdGsStateBranch>(pStateBranch, bOwn: false, bTryAddToTransaction: false), Helpers.GetObject<OdGsStateBranch>(pStateBranchRemoved, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodonMarkerAdded(IntPtr pStateBranch, IntPtr gsMarker, IntPtr pData)
	{
		try
		{
			onMarkerAdded(Helpers.GetObject<OdGsStateBranch>(pStateBranch, bOwn: false, bTryAddToTransaction: false), gsMarker, Helpers.GetRXObject<OdGsSimpleParam>(pData, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodonMarkerRemoved(IntPtr pStateBranch, IntPtr gsMarker)
	{
		try
		{
			onMarkerRemoved(Helpers.GetObject<OdGsStateBranch>(pStateBranch, bOwn: false, bTryAddToTransaction: false), gsMarker);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodonMarkerDataModified(IntPtr pStateBranch, IntPtr gsMarker, IntPtr pPrevData, IntPtr pData)
	{
		try
		{
			onMarkerDataModified(Helpers.GetObject<OdGsStateBranch>(pStateBranch, bOwn: false, bTryAddToTransaction: false), gsMarker, Helpers.GetRXObject<OdGsSimpleParam>(pPrevData, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsSimpleParam>(pData, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodonDataModified(IntPtr pStateBranch, IntPtr pPrevData, IntPtr pData)
	{
		try
		{
			onDataModified(Helpers.GetObject<OdGsStateBranch>(pStateBranch, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsSimpleParam>(pPrevData, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsSimpleParam>(pData, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodonExtentsChanged(IntPtr pGsNode, IntPtr pStateBranch, IntPtr extBefore, IntPtr extAfter)
	{
		try
		{
			onExtentsChanged(Helpers.GetRXObject<OdGsCache>(pGsNode, bOwn: false, bTryAddToTransaction: false), Helpers.GetObject<OdGsStateBranch>(pStateBranch, bOwn: false, bTryAddToTransaction: false), new OdGeExtents3d(extBefore, cMemoryOwn: false), new OdGeExtents3d(extAfter, cMemoryOwn: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodonBranchDetach(IntPtr pGsNode, IntPtr pStateBranch)
	{
		try
		{
			onBranchDetach(Helpers.GetRXObject<OdGsCache>(pGsNode, bOwn: false, bTryAddToTransaction: false), Helpers.GetObject<OdGsStateBranch>(pStateBranch, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
