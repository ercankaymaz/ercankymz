using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSubentRef : OdDbGeomRef
{
	public delegate IntPtr SwigDelegateOdDbSubentRef_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbSubentRef_1();

	public delegate void SwigDelegateOdDbSubentRef_2(IntPtr src);

	public delegate void SwigDelegateOdDbSubentRef_3();

	public delegate bool SwigDelegateOdDbSubentRef_4();

	public delegate bool SwigDelegateOdDbSubentRef_5();

	public delegate IntPtr SwigDelegateOdDbSubentRef_6();

	public delegate int SwigDelegateOdDbSubentRef_7();

	public delegate IntPtr SwigDelegateOdDbSubentRef_8();

	public delegate IntPtr SwigDelegateOdDbSubentRef_9();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbSubentRef_0 swigDelegate0;

	private SwigDelegateOdDbSubentRef_1 swigDelegate1;

	private SwigDelegateOdDbSubentRef_2 swigDelegate2;

	private SwigDelegateOdDbSubentRef_3 swigDelegate3;

	private SwigDelegateOdDbSubentRef_4 swigDelegate4;

	private SwigDelegateOdDbSubentRef_5 swigDelegate5;

	private SwigDelegateOdDbSubentRef_6 swigDelegate6;

	private SwigDelegateOdDbSubentRef_7 swigDelegate7;

	private SwigDelegateOdDbSubentRef_8 swigDelegate8;

	private SwigDelegateOdDbSubentRef_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSubentRef(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSubentRef obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSubentRef(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbSubentRef cast(OdRxObject pObj)
	{
		OdDbSubentRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSubentRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_isASwigExplicitOdDbSubentRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_queryXSwigExplicitOdDbSubentRef(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbSubentRef createObject(OdDbCompoundObjectId compId, OdDbSubentId subent)
	{
		OdDbSubentRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSubentRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_createObject__SWIG_0(OdDbCompoundObjectId.getCPtr(compId), OdDbSubentId.getCPtr(subent)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbSubentRef createObject(OdDbCompoundObjectId compId)
	{
		OdDbSubentRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSubentRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_createObject__SWIG_1(OdDbCompoundObjectId.getCPtr(compId)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbSubentRef Assign(OdDbSubentRef src)
	{
		OdDbSubentRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSubentRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_Assign(swigCPtr, getCPtr(src)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void copyFrom(OdRxObject src)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_copyFromSwigExplicitOdDbSubentRef(swigCPtr, OdRxObject.getCPtr(src));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_copyFrom(swigCPtr, OdRxObject.getCPtr(src));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void reset()
	{
		if (SwigDerivedClassHasMethod("reset", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_resetSwigExplicitOdDbSubentRef(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_reset(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isValid()
	{
		bool result = (SwigDerivedClassHasMethod("isValid", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_isValidSwigExplicitOdDbSubentRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_isValid(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEmpty()
	{
		bool result = (SwigDerivedClassHasMethod("isEmpty", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_isEmptySwigExplicitOdDbSubentRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_isEmpty(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbCompoundObjectId entity()
	{
		OdDbCompoundObjectId rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCompoundObjectId>(SwigDerivedClassHasMethod("entity", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_entitySwigExplicitOdDbSubentRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_entity(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbSubentId subentId()
	{
		OdDbSubentId result = new OdDbSubentId(SwigDerivedClassHasMethod("subentId", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_subentIdSwigExplicitOdDbSubentRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_subentId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbEntity createEntity()
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(SwigDerivedClassHasMethod("createEntity", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_createEntitySwigExplicitOdDbSubentRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_createEntity(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult evaluateAndCacheGeometry()
	{
		int result = (SwigDerivedClassHasMethod("evaluateAndCacheGeometry", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_evaluateAndCacheGeometrySwigExplicitOdDbSubentRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_evaluateAndCacheGeometry(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbSubentRef createObject()
	{
		OdDbSubentRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSubentRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_createObject__SWIG_4(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("reset", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodreset;
		}
		if (SwigDerivedClassHasMethod("isValid", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisValid;
		}
		if (SwigDerivedClassHasMethod("isEmpty", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodisEmpty;
		}
		if (SwigDerivedClassHasMethod("createEntity", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcreateEntity;
		}
		if (SwigDerivedClassHasMethod("evaluateAndCacheGeometry", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodevaluateAndCacheGeometry;
		}
		if (SwigDerivedClassHasMethod("entity", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodentity;
		}
		if (SwigDerivedClassHasMethod("subentId", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsubentId;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSubentRef_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbSubentRef));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr src)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(src, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodreset()
	{
		try
		{
			reset();
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

	private bool SwigDirectorMethodisValid()
	{
		return isValid();
	}

	private bool SwigDirectorMethodisEmpty()
	{
		return isEmpty();
	}

	private IntPtr SwigDirectorMethodcreateEntity()
	{
		return OdDbEntity.getCPtr(createEntity()).Handle;
	}

	private int SwigDirectorMethodevaluateAndCacheGeometry()
	{
		return (int)evaluateAndCacheGeometry();
	}

	private IntPtr SwigDirectorMethodentity()
	{
		return OdDbCompoundObjectId.getCPtr(entity()).Handle;
	}

	private IntPtr SwigDirectorMethodsubentId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbSubentId.getCPtr(subentId()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}
