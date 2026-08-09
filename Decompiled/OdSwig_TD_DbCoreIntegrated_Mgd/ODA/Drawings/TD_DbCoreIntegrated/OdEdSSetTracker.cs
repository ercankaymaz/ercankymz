using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdEdSSetTracker : OdSSetTracker
{
	public delegate IntPtr SwigDelegateOdEdSSetTracker_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdEdSSetTracker_1();

	public delegate void SwigDelegateOdEdSSetTracker_2(IntPtr pSource);

	public delegate int SwigDelegateOdEdSSetTracker_3(IntPtr pView);

	public delegate void SwigDelegateOdEdSSetTracker_4(IntPtr pView);

	public delegate bool SwigDelegateOdEdSSetTracker_5(IntPtr id, IntPtr pMethod);

	public delegate bool SwigDelegateOdEdSSetTracker_6(IntPtr id, IntPtr pMethod);

	public delegate bool SwigDelegateOdEdSSetTracker_7();

	public delegate bool SwigDelegateOdEdSSetTracker_8(IntPtr subEntPath, IntPtr pMethod);

	public delegate bool SwigDelegateOdEdSSetTracker_9(IntPtr subEntPath, IntPtr pMethod);

	public delegate bool SwigDelegateOdEdSSetTracker_10(IntPtr id, IntPtr pMethod);

	public delegate bool SwigDelegateOdEdSSetTracker_11(IntPtr id, IntPtr pMethod);

	public delegate bool SwigDelegateOdEdSSetTracker_12(IntPtr subEntPath, IntPtr pMethod);

	public delegate bool SwigDelegateOdEdSSetTracker_13(IntPtr subEntPath, IntPtr pMethod);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdEdSSetTracker_0 swigDelegate0;

	private SwigDelegateOdEdSSetTracker_1 swigDelegate1;

	private SwigDelegateOdEdSSetTracker_2 swigDelegate2;

	private SwigDelegateOdEdSSetTracker_3 swigDelegate3;

	private SwigDelegateOdEdSSetTracker_4 swigDelegate4;

	private SwigDelegateOdEdSSetTracker_5 swigDelegate5;

	private SwigDelegateOdEdSSetTracker_6 swigDelegate6;

	private SwigDelegateOdEdSSetTracker_7 swigDelegate7;

	private SwigDelegateOdEdSSetTracker_8 swigDelegate8;

	private SwigDelegateOdEdSSetTracker_9 swigDelegate9;

	private SwigDelegateOdEdSSetTracker_10 swigDelegate10;

	private SwigDelegateOdEdSSetTracker_11 swigDelegate11;

	private SwigDelegateOdEdSSetTracker_12 swigDelegate12;

	private SwigDelegateOdEdSSetTracker_13 swigDelegate13;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdDbSelectionMethod)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdDbSelectionMethod)
	};

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdDbBaseFullSubentPath),
		typeof(OdDbSelectionMethod)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdDbBaseFullSubentPath),
		typeof(OdDbSelectionMethod)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(OdDbSelectionMethod)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdDbObjectId),
		typeof(OdDbSelectionMethod)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdDbSelectionMethod)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdDbFullSubentPath),
		typeof(OdDbSelectionMethod)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEdSSetTracker(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEdSSetTracker obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdEdSSetTracker(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdEdSSetTracker cast(OdRxObject pObj)
	{
		OdEdSSetTracker rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdSSetTracker>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_isASwigExplicitOdEdSSetTracker(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_queryXSwigExplicitOdEdSSetTracker(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override int addDrawables(OdGsView pView)
	{
		int result = (SwigDerivedClassHasMethod("addDrawables", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_addDrawablesSwigExplicitOdEdSSetTracker(swigCPtr, OdGsView.getCPtr(pView)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_addDrawables(swigCPtr, OdGsView.getCPtr(pView)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void removeDrawables(OdGsView pView)
	{
		if (SwigDerivedClassHasMethod("removeDrawables", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_removeDrawablesSwigExplicitOdEdSSetTracker(swigCPtr, OdGsView.getCPtr(pView));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_removeDrawables(swigCPtr, OdGsView.getCPtr(pView));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool append(OdDbStub id, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("append", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_appendSwigExplicitOdEdSSetTracker__SWIG_0(swigCPtr, OdDbStub.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_append__SWIG_0(swigCPtr, OdDbStub.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool remove(OdDbStub id, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("remove", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_removeSwigExplicitOdEdSSetTracker__SWIG_0(swigCPtr, OdDbStub.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_remove__SWIG_0(swigCPtr, OdDbStub.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool append(OdDbBaseFullSubentPath subEntPath, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("append", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_appendSwigExplicitOdEdSSetTracker__SWIG_1(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_append__SWIG_1(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool remove(OdDbBaseFullSubentPath subEntPath, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("remove", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_removeSwigExplicitOdEdSSetTracker__SWIG_1(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_remove__SWIG_1(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool append(OdDbObjectId id, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("append", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_appendSwigExplicitOdEdSSetTracker__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_append__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool remove(OdDbObjectId id, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("remove", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_removeSwigExplicitOdEdSSetTracker__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_remove__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(id), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool append(OdDbFullSubentPath subEntPath, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("append", swigMethodTypes12) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_appendSwigExplicitOdEdSSetTracker__SWIG_3(swigCPtr, OdDbFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_append__SWIG_3(swigCPtr, OdDbFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool remove(OdDbFullSubentPath subEntPath, OdDbSelectionMethod pMethod)
	{
		bool result = (SwigDerivedClassHasMethod("remove", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_removeSwigExplicitOdEdSSetTracker__SWIG_3(swigCPtr, OdDbFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_remove__SWIG_3(swigCPtr, OdDbFullSubentPath.getCPtr(subEntPath), OdDbSelectionMethod.getCPtr(pMethod)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdEdSSetTracker createObject()
	{
		OdEdSSetTracker rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdSSetTracker>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdEdSSetTracker()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdEdSSetTracker(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdEdSSetTracker) != GetType();
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
		if (SwigDerivedClassHasMethod("addDrawables", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodaddDrawables;
		}
		if (SwigDerivedClassHasMethod("removeDrawables", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodremoveDrawables;
		}
		if (SwigDerivedClassHasMethod("append", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodappend__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("remove", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodremove__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("trackSubentities", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodtrackSubentities;
		}
		if (SwigDerivedClassHasMethod("append", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodappend__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("remove", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodremove__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("append", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodappend__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("remove", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodremove__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("append", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodappend__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("remove", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodremove__SWIG_3;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdEdSSetTracker_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdEdSSetTracker));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodaddDrawables(IntPtr pView)
	{
		return addDrawables(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodremoveDrawables(IntPtr pView)
	{
		try
		{
			removeDrawables(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodappend__SWIG_0(IntPtr id, IntPtr pMethod)
	{
		return append((id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodremove__SWIG_0(IntPtr id, IntPtr pMethod)
	{
		return remove((id == IntPtr.Zero) ? null : new OdDbStub(id, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodtrackSubentities()
	{
		return trackSubentities();
	}

	private bool SwigDirectorMethodappend__SWIG_1(IntPtr subEntPath, IntPtr pMethod)
	{
		return append(new OdDbBaseFullSubentPath(subEntPath, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodremove__SWIG_1(IntPtr subEntPath, IntPtr pMethod)
	{
		return remove(new OdDbBaseFullSubentPath(subEntPath, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodappend__SWIG_2(IntPtr id, IntPtr pMethod)
	{
		return append(new OdDbObjectId(id, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodremove__SWIG_2(IntPtr id, IntPtr pMethod)
	{
		return remove(new OdDbObjectId(id, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodappend__SWIG_3(IntPtr subEntPath, IntPtr pMethod)
	{
		return append(new OdDbFullSubentPath(subEntPath, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodremove__SWIG_3(IntPtr subEntPath, IntPtr pMethod)
	{
		return remove(new OdDbFullSubentPath(subEntPath, cMemoryOwn: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionMethod>(pMethod, bOwn: false, bTryAddToTransaction: false));
	}
}
