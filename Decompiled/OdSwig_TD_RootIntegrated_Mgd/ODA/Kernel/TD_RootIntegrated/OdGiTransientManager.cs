using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiTransientManager : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiTransientManager_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiTransientManager_1();

	public delegate void SwigDelegateOdGiTransientManager_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiTransientManager_3(IntPtr pDrawable, int mode, int subMode, IntPtr viewportIds);

	public delegate bool SwigDelegateOdGiTransientManager_4(IntPtr pDrawable, IntPtr viewportIds);

	public delegate bool SwigDelegateOdGiTransientManager_5(int mode, int subMode, IntPtr viewportIds);

	public delegate void SwigDelegateOdGiTransientManager_6(IntPtr pDrawable, IntPtr viewportIds);

	public delegate bool SwigDelegateOdGiTransientManager_7(IntPtr pDrawable, IntPtr pParent);

	public delegate bool SwigDelegateOdGiTransientManager_8(IntPtr pDrawable, IntPtr pParent);

	public delegate void SwigDelegateOdGiTransientManager_9(IntPtr pDrawable, IntPtr pParent);

	public delegate int SwigDelegateOdGiTransientManager_10(int mode, int subMode, IntPtr viewportIds);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiTransientManager_0 swigDelegate0;

	private SwigDelegateOdGiTransientManager_1 swigDelegate1;

	private SwigDelegateOdGiTransientManager_2 swigDelegate2;

	private SwigDelegateOdGiTransientManager_3 swigDelegate3;

	private SwigDelegateOdGiTransientManager_4 swigDelegate4;

	private SwigDelegateOdGiTransientManager_5 swigDelegate5;

	private SwigDelegateOdGiTransientManager_6 swigDelegate6;

	private SwigDelegateOdGiTransientManager_7 swigDelegate7;

	private SwigDelegateOdGiTransientManager_8 swigDelegate8;

	private SwigDelegateOdGiTransientManager_9 swigDelegate9;

	private SwigDelegateOdGiTransientManager_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdGiDrawable),
		typeof(OdGiTransientManager_OdGiTransientDrawingMode),
		typeof(int),
		typeof(OdUInt32Array)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdUInt32Array)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdGiTransientManager_OdGiTransientDrawingMode),
		typeof(int),
		typeof(OdUInt32Array)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdUInt32Array)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(OdGiTransientManager_OdGiTransientDrawingMode),
		typeof(int).MakeByRefType(),
		typeof(OdUInt32Array)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiTransientManager(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiTransientManager obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiTransientManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiTransientManager cast(OdRxObject pObj)
	{
		OdGiTransientManager rXObject = Helpers.GetRXObject<OdGiTransientManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_isASwigExplicitOdGiTransientManager(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_queryXSwigExplicitOdGiTransientManager(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiTransientManager createObject()
	{
		OdGiTransientManager rXObject = Helpers.GetRXObject<OdGiTransientManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool addTransient(OdGiDrawable pDrawable, OdGiTransientManager_OdGiTransientDrawingMode mode, int subMode, OdUInt32Array viewportIds)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_addTransient(swigCPtr, OdGiDrawable.getCPtr(pDrawable), (int)mode, subMode, OdUInt32Array.getCPtr(viewportIds).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool eraseTransient(OdGiDrawable pDrawable, OdUInt32Array viewportIds)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_eraseTransient(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdUInt32Array.getCPtr(viewportIds).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool eraseTransients(OdGiTransientManager_OdGiTransientDrawingMode mode, int subMode, OdUInt32Array viewportIds)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_eraseTransients(swigCPtr, (int)mode, subMode, OdUInt32Array.getCPtr(viewportIds).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void updateTransient(OdGiDrawable pDrawable, OdUInt32Array viewportIds)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_updateTransient(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdUInt32Array.getCPtr(viewportIds).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool addChildTransient(OdGiDrawable pDrawable, OdGiDrawable pParent)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_addChildTransient(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGiDrawable.getCPtr(pParent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool eraseChildTransient(OdGiDrawable pDrawable, OdGiDrawable pParent)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_eraseChildTransient(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGiDrawable.getCPtr(pParent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void updateChildTransient(OdGiDrawable pDrawable, OdGiDrawable pParent)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_updateChildTransient(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGiDrawable.getCPtr(pParent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int getFreeSubDrawingMode(OdGiTransientManager_OdGiTransientDrawingMode mode, out int subMode, OdUInt32Array viewportIds)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_getFreeSubDrawingMode(swigCPtr, (int)mode, out subMode, OdUInt32Array.getCPtr(viewportIds).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiTransientManager()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiTransientManager(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiTransientManager) != GetType();
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
		if (SwigDerivedClassHasMethod("addTransient", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodaddTransient;
		}
		if (SwigDerivedClassHasMethod("eraseTransient", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoderaseTransient;
		}
		if (SwigDerivedClassHasMethod("eraseTransients", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoderaseTransients;
		}
		if (SwigDerivedClassHasMethod("updateTransient", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodupdateTransient;
		}
		if (SwigDerivedClassHasMethod("addChildTransient", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodaddChildTransient;
		}
		if (SwigDerivedClassHasMethod("eraseChildTransient", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoderaseChildTransient;
		}
		if (SwigDerivedClassHasMethod("updateChildTransient", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodupdateChildTransient;
		}
		if (SwigDerivedClassHasMethod("getFreeSubDrawingMode", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetFreeSubDrawingMode;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiTransientManager_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiTransientManager));
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

	private bool SwigDirectorMethodaddTransient(IntPtr pDrawable, int mode, int subMode, IntPtr viewportIds)
	{
		return addTransient(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), (OdGiTransientManager_OdGiTransientDrawingMode)mode, subMode, new OdUInt32Array(viewportIds, cMemoryOwn: true));
	}

	private bool SwigDirectorMethoderaseTransient(IntPtr pDrawable, IntPtr viewportIds)
	{
		return eraseTransient(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), new OdUInt32Array(viewportIds, cMemoryOwn: true));
	}

	private bool SwigDirectorMethoderaseTransients(int mode, int subMode, IntPtr viewportIds)
	{
		return eraseTransients((OdGiTransientManager_OdGiTransientDrawingMode)mode, subMode, new OdUInt32Array(viewportIds, cMemoryOwn: true));
	}

	private void SwigDirectorMethodupdateTransient(IntPtr pDrawable, IntPtr viewportIds)
	{
		try
		{
			updateTransient(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), new OdUInt32Array(viewportIds, cMemoryOwn: true));
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

	private bool SwigDirectorMethodaddChildTransient(IntPtr pDrawable, IntPtr pParent)
	{
		return addChildTransient(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethoderaseChildTransient(IntPtr pDrawable, IntPtr pParent)
	{
		return eraseChildTransient(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodupdateChildTransient(IntPtr pDrawable, IntPtr pParent)
	{
		try
		{
			updateChildTransient(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodgetFreeSubDrawingMode(int mode, int subMode, IntPtr viewportIds)
	{
		return getFreeSubDrawingMode((OdGiTransientManager_OdGiTransientDrawingMode)mode, out subMode, new OdUInt32Array(viewportIds, cMemoryOwn: true));
	}
}
