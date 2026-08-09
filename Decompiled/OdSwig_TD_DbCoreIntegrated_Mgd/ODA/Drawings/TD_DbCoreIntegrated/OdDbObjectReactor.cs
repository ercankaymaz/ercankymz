using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbObjectReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbObjectReactor_1();

	public delegate void SwigDelegateOdDbObjectReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbObjectReactor_3(IntPtr pObject);

	public delegate void SwigDelegateOdDbObjectReactor_4(IntPtr pObject, IntPtr pNewObject);

	public delegate void SwigDelegateOdDbObjectReactor_5(IntPtr pObject, bool erasing);

	public delegate void SwigDelegateOdDbObjectReactor_6(IntPtr pObject);

	public delegate void SwigDelegateOdDbObjectReactor_7(IntPtr pObject);

	public delegate void SwigDelegateOdDbObjectReactor_8(IntPtr pObject);

	public delegate void SwigDelegateOdDbObjectReactor_9(IntPtr pObject);

	public delegate void SwigDelegateOdDbObjectReactor_10(IntPtr pObject);

	public delegate void SwigDelegateOdDbObjectReactor_11(IntPtr pObject, IntPtr pSubObj);

	public delegate void SwigDelegateOdDbObjectReactor_12(IntPtr pObject);

	public delegate void SwigDelegateOdDbObjectReactor_13(IntPtr pObject);

	public delegate void SwigDelegateOdDbObjectReactor_14(IntPtr pObject);

	public delegate void SwigDelegateOdDbObjectReactor_15(IntPtr pObject);

	public delegate void SwigDelegateOdDbObjectReactor_16(IntPtr objectId);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbObjectReactor_0 swigDelegate0;

	private SwigDelegateOdDbObjectReactor_1 swigDelegate1;

	private SwigDelegateOdDbObjectReactor_2 swigDelegate2;

	private SwigDelegateOdDbObjectReactor_3 swigDelegate3;

	private SwigDelegateOdDbObjectReactor_4 swigDelegate4;

	private SwigDelegateOdDbObjectReactor_5 swigDelegate5;

	private SwigDelegateOdDbObjectReactor_6 swigDelegate6;

	private SwigDelegateOdDbObjectReactor_7 swigDelegate7;

	private SwigDelegateOdDbObjectReactor_8 swigDelegate8;

	private SwigDelegateOdDbObjectReactor_9 swigDelegate9;

	private SwigDelegateOdDbObjectReactor_10 swigDelegate10;

	private SwigDelegateOdDbObjectReactor_11 swigDelegate11;

	private SwigDelegateOdDbObjectReactor_12 swigDelegate12;

	private SwigDelegateOdDbObjectReactor_13 swigDelegate13;

	private SwigDelegateOdDbObjectReactor_14 swigDelegate14;

	private SwigDelegateOdDbObjectReactor_15 swigDelegate15;

	private SwigDelegateOdDbObjectReactor_16 swigDelegate16;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbObjectId) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbObjectReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectReactor obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbObjectReactor()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectReactor(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbObjectReactor cast(OdRxObject pObj)
	{
		OdDbObjectReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_isASwigExplicitOdDbObjectReactor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_queryXSwigExplicitOdDbObjectReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectReactor createObject()
	{
		OdDbObjectReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void cancelled(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("cancelled", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_cancelledSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_cancelled(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void copied(OdDbObject pObject, OdDbObject pNewObject)
	{
		if (SwigDerivedClassHasMethod("copied", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_copiedSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObject.getCPtr(pNewObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_copied(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObject.getCPtr(pNewObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void erased(OdDbObject pObject, bool erasing)
	{
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_erasedSwigExplicitOdDbObjectReactor__SWIG_0(swigCPtr, OdDbObject.getCPtr(pObject), erasing);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_erased__SWIG_0(swigCPtr, OdDbObject.getCPtr(pObject), erasing);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void erased(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes6))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_erasedSwigExplicitOdDbObjectReactor__SWIG_1(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_erased__SWIG_1(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void goodbye(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("goodbye", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_goodbyeSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_goodbye(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void openedForModify(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("openedForModify", swigMethodTypes8))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_openedForModifySwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_openedForModify(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void modified(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("modified", swigMethodTypes9))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_modifiedSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_modified(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void modifiedGraphics(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("modifiedGraphics", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_modifiedGraphicsSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_modifiedGraphics(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void subObjModified(OdDbObject pObject, OdDbObject pSubObj)
	{
		if (SwigDerivedClassHasMethod("subObjModified", swigMethodTypes11))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_subObjModifiedSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObject.getCPtr(pSubObj));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_subObjModified(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObject.getCPtr(pSubObj));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void modifyUndone(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("modifyUndone", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_modifyUndoneSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_modifyUndone(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void modifiedXData(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("modifiedXData", swigMethodTypes13))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_modifiedXDataSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_modifiedXData(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void unappended(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("unappended", swigMethodTypes14))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_unappendedSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_unappended(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void reappended(OdDbObject pObject)
	{
		if (SwigDerivedClassHasMethod("reappended", swigMethodTypes15))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_reappendedSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_reappended(swigCPtr, OdDbObject.getCPtr(pObject));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void objectClosed(OdDbObjectId objectId)
	{
		if (SwigDerivedClassHasMethod("objectClosed", swigMethodTypes16))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_objectClosedSwigExplicitOdDbObjectReactor(swigCPtr, OdDbObjectId.getCPtr(objectId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_objectClosed(swigCPtr, OdDbObjectId.getCPtr(objectId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbObjectReactor findReactor(OdDbObject pObject, OdRxClass pKeyClass)
	{
		OdDbObjectReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_findReactor(OdDbObject.getCPtr(pObject), OdRxClass.getCPtr(pKeyClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("cancelled", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcancelled;
		}
		if (SwigDerivedClassHasMethod("copied", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcopied;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethoderased__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("erased", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoderased__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("goodbye", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgoodbye;
		}
		if (SwigDerivedClassHasMethod("openedForModify", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodopenedForModify;
		}
		if (SwigDerivedClassHasMethod("modified", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodmodified;
		}
		if (SwigDerivedClassHasMethod("modifiedGraphics", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodmodifiedGraphics;
		}
		if (SwigDerivedClassHasMethod("subObjModified", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsubObjModified;
		}
		if (SwigDerivedClassHasMethod("modifyUndone", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodmodifyUndone;
		}
		if (SwigDerivedClassHasMethod("modifiedXData", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodmodifiedXData;
		}
		if (SwigDerivedClassHasMethod("unappended", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodunappended;
		}
		if (SwigDerivedClassHasMethod("reappended", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodreappended;
		}
		if (SwigDerivedClassHasMethod("objectClosed", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodobjectClosed;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbObjectReactor));
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

	private void SwigDirectorMethodcancelled(IntPtr pObject)
	{
		try
		{
			cancelled(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodcopied(IntPtr pObject, IntPtr pNewObject)
	{
		try
		{
			copied(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pNewObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethoderased__SWIG_0(IntPtr pObject, bool erasing)
	{
		try
		{
			erased(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), erasing);
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

	private void SwigDirectorMethoderased__SWIG_1(IntPtr pObject)
	{
		try
		{
			erased(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodgoodbye(IntPtr pObject)
	{
		try
		{
			goodbye(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodopenedForModify(IntPtr pObject)
	{
		try
		{
			openedForModify(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodmodified(IntPtr pObject)
	{
		try
		{
			modified(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodmodifiedGraphics(IntPtr pObject)
	{
		try
		{
			modifiedGraphics(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsubObjModified(IntPtr pObject, IntPtr pSubObj)
	{
		try
		{
			subObjModified(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubObj, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodmodifyUndone(IntPtr pObject)
	{
		try
		{
			modifyUndone(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodmodifiedXData(IntPtr pObject)
	{
		try
		{
			modifiedXData(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodunappended(IntPtr pObject)
	{
		try
		{
			unappended(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodreappended(IntPtr pObject)
	{
		try
		{
			reappended(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodobjectClosed(IntPtr objectId)
	{
		try
		{
			objectClosed(new OdDbObjectId(objectId, cMemoryOwn: false));
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
