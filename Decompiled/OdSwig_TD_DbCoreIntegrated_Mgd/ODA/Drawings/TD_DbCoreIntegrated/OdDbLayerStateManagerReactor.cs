using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbLayerStateManagerReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbLayerStateManagerReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbLayerStateManagerReactor_1();

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_3([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_4([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_5([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_6([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_7([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_8([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_9([MarshalAs(UnmanagedType.LPWStr)] string layerStateName);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_10([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_11([MarshalAs(UnmanagedType.LPWStr)] string oldLayerStateName, [MarshalAs(UnmanagedType.LPWStr)] string newLayerStateName);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_12([MarshalAs(UnmanagedType.LPWStr)] string oldLayerStateName, [MarshalAs(UnmanagedType.LPWStr)] string newLayerStateName);

	public delegate void SwigDelegateOdDbLayerStateManagerReactor_13([MarshalAs(UnmanagedType.LPWStr)] string oldLayerStateName, [MarshalAs(UnmanagedType.LPWStr)] string newLayerStateName);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbLayerStateManagerReactor_0 swigDelegate0;

	private SwigDelegateOdDbLayerStateManagerReactor_1 swigDelegate1;

	private SwigDelegateOdDbLayerStateManagerReactor_2 swigDelegate2;

	private SwigDelegateOdDbLayerStateManagerReactor_3 swigDelegate3;

	private SwigDelegateOdDbLayerStateManagerReactor_4 swigDelegate4;

	private SwigDelegateOdDbLayerStateManagerReactor_5 swigDelegate5;

	private SwigDelegateOdDbLayerStateManagerReactor_6 swigDelegate6;

	private SwigDelegateOdDbLayerStateManagerReactor_7 swigDelegate7;

	private SwigDelegateOdDbLayerStateManagerReactor_8 swigDelegate8;

	private SwigDelegateOdDbLayerStateManagerReactor_9 swigDelegate9;

	private SwigDelegateOdDbLayerStateManagerReactor_10 swigDelegate10;

	private SwigDelegateOdDbLayerStateManagerReactor_11 swigDelegate11;

	private SwigDelegateOdDbLayerStateManagerReactor_12 swigDelegate12;

	private SwigDelegateOdDbLayerStateManagerReactor_13 swigDelegate13;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLayerStateManagerReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLayerStateManagerReactor obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbLayerStateManagerReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbLayerStateManagerReactor cast(OdRxObject pObj)
	{
		OdDbLayerStateManagerReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayerStateManagerReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_isASwigExplicitOdDbLayerStateManagerReactor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_queryXSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void layerStateCreated(string layerStateName, OdDbObjectId layerStateId)
	{
		if (SwigDerivedClassHasMethod("layerStateCreated", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateCreatedSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateCreated(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layerStateCompareFailed(string layerStateName, OdDbObjectId layerStateId)
	{
		if (SwigDerivedClassHasMethod("layerStateCompareFailed", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateCompareFailedSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateCompareFailed(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layerStateToBeRestored(string layerStateName, OdDbObjectId layerStateId)
	{
		if (SwigDerivedClassHasMethod("layerStateToBeRestored", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateToBeRestoredSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateToBeRestored(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layerStateRestored(string layerStateName, OdDbObjectId layerStateId)
	{
		if (SwigDerivedClassHasMethod("layerStateRestored", swigMethodTypes6))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateRestoredSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateRestored(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortLayerStateRestore(string layerStateName, OdDbObjectId layerStateId)
	{
		if (SwigDerivedClassHasMethod("abortLayerStateRestore", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_abortLayerStateRestoreSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_abortLayerStateRestore(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layerStateToBeDeleted(string layerStateName, OdDbObjectId layerStateId)
	{
		if (SwigDerivedClassHasMethod("layerStateToBeDeleted", swigMethodTypes8))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateToBeDeletedSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateToBeDeleted(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layerStateDeleted(string layerStateName)
	{
		if (SwigDerivedClassHasMethod("layerStateDeleted", swigMethodTypes9))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateDeletedSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, layerStateName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateDeleted(swigCPtr, layerStateName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortLayerStateDelete(string layerStateName, OdDbObjectId layerStateId)
	{
		if (SwigDerivedClassHasMethod("abortLayerStateDelete", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_abortLayerStateDeleteSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_abortLayerStateDelete(swigCPtr, layerStateName, OdDbObjectId.getCPtr(layerStateId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layerStateToBeRenamed(string oldLayerStateName, string newLayerStateName)
	{
		if (SwigDerivedClassHasMethod("layerStateToBeRenamed", swigMethodTypes11))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateToBeRenamedSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, oldLayerStateName, newLayerStateName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateToBeRenamed(swigCPtr, oldLayerStateName, newLayerStateName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layerStateRenamed(string oldLayerStateName, string newLayerStateName)
	{
		if (SwigDerivedClassHasMethod("layerStateRenamed", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateRenamedSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, oldLayerStateName, newLayerStateName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_layerStateRenamed(swigCPtr, oldLayerStateName, newLayerStateName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortLayerStateRename(string oldLayerStateName, string newLayerStateName)
	{
		if (SwigDerivedClassHasMethod("abortLayerStateRename", swigMethodTypes13))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_abortLayerStateRenameSwigExplicitOdDbLayerStateManagerReactor(swigCPtr, oldLayerStateName, newLayerStateName);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_abortLayerStateRename(swigCPtr, oldLayerStateName, newLayerStateName);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbLayerStateManagerReactor createObject()
	{
		OdDbLayerStateManagerReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayerStateManagerReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbLayerStateManagerReactor()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbLayerStateManagerReactor(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbLayerStateManagerReactor) != GetType();
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
		if (SwigDerivedClassHasMethod("layerStateCreated", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodlayerStateCreated;
		}
		if (SwigDerivedClassHasMethod("layerStateCompareFailed", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodlayerStateCompareFailed;
		}
		if (SwigDerivedClassHasMethod("layerStateToBeRestored", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodlayerStateToBeRestored;
		}
		if (SwigDerivedClassHasMethod("layerStateRestored", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodlayerStateRestored;
		}
		if (SwigDerivedClassHasMethod("abortLayerStateRestore", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodabortLayerStateRestore;
		}
		if (SwigDerivedClassHasMethod("layerStateToBeDeleted", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodlayerStateToBeDeleted;
		}
		if (SwigDerivedClassHasMethod("layerStateDeleted", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodlayerStateDeleted;
		}
		if (SwigDerivedClassHasMethod("abortLayerStateDelete", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodabortLayerStateDelete;
		}
		if (SwigDerivedClassHasMethod("layerStateToBeRenamed", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodlayerStateToBeRenamed;
		}
		if (SwigDerivedClassHasMethod("layerStateRenamed", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodlayerStateRenamed;
		}
		if (SwigDerivedClassHasMethod("abortLayerStateRename", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodabortLayerStateRename;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManagerReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbLayerStateManagerReactor));
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

	private void SwigDirectorMethodlayerStateCreated([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId)
	{
		try
		{
			layerStateCreated(layerStateName, new OdDbObjectId(layerStateId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayerStateCompareFailed([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId)
	{
		try
		{
			layerStateCompareFailed(layerStateName, new OdDbObjectId(layerStateId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayerStateToBeRestored([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId)
	{
		try
		{
			layerStateToBeRestored(layerStateName, new OdDbObjectId(layerStateId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayerStateRestored([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId)
	{
		try
		{
			layerStateRestored(layerStateName, new OdDbObjectId(layerStateId, cMemoryOwn: false));
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

	private void SwigDirectorMethodabortLayerStateRestore([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId)
	{
		try
		{
			abortLayerStateRestore(layerStateName, new OdDbObjectId(layerStateId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayerStateToBeDeleted([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId)
	{
		try
		{
			layerStateToBeDeleted(layerStateName, new OdDbObjectId(layerStateId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayerStateDeleted([MarshalAs(UnmanagedType.LPWStr)] string layerStateName)
	{
		try
		{
			layerStateDeleted(layerStateName);
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

	private void SwigDirectorMethodabortLayerStateDelete([MarshalAs(UnmanagedType.LPWStr)] string layerStateName, IntPtr layerStateId)
	{
		try
		{
			abortLayerStateDelete(layerStateName, new OdDbObjectId(layerStateId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayerStateToBeRenamed([MarshalAs(UnmanagedType.LPWStr)] string oldLayerStateName, [MarshalAs(UnmanagedType.LPWStr)] string newLayerStateName)
	{
		try
		{
			layerStateToBeRenamed(oldLayerStateName, newLayerStateName);
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

	private void SwigDirectorMethodlayerStateRenamed([MarshalAs(UnmanagedType.LPWStr)] string oldLayerStateName, [MarshalAs(UnmanagedType.LPWStr)] string newLayerStateName)
	{
		try
		{
			layerStateRenamed(oldLayerStateName, newLayerStateName);
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

	private void SwigDirectorMethodabortLayerStateRename([MarshalAs(UnmanagedType.LPWStr)] string oldLayerStateName, [MarshalAs(UnmanagedType.LPWStr)] string newLayerStateName)
	{
		try
		{
			abortLayerStateRename(oldLayerStateName, newLayerStateName);
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
}
