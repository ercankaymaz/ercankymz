using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeomRef : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeomRef_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeomRef_1();

	public delegate void SwigDelegateOdDbGeomRef_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbGeomRef_3();

	public delegate bool SwigDelegateOdDbGeomRef_4();

	public delegate bool SwigDelegateOdDbGeomRef_5();

	public delegate IntPtr SwigDelegateOdDbGeomRef_6();

	public delegate int SwigDelegateOdDbGeomRef_7();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeomRef_0 swigDelegate0;

	private SwigDelegateOdDbGeomRef_1 swigDelegate1;

	private SwigDelegateOdDbGeomRef_2 swigDelegate2;

	private SwigDelegateOdDbGeomRef_3 swigDelegate3;

	private SwigDelegateOdDbGeomRef_4 swigDelegate4;

	private SwigDelegateOdDbGeomRef_5 swigDelegate5;

	private SwigDelegateOdDbGeomRef_6 swigDelegate6;

	private SwigDelegateOdDbGeomRef_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeomRef(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeomRef obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeomRef(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeomRef cast(OdRxObject pObj)
	{
		OdDbGeomRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeomRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_isASwigExplicitOdDbGeomRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_queryXSwigExplicitOdDbGeomRef(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void reset()
	{
		if (SwigDerivedClassHasMethod("reset", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_resetSwigExplicitOdDbGeomRef(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_reset(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isValid()
	{
		bool result = (SwigDerivedClassHasMethod("isValid", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_isValidSwigExplicitOdDbGeomRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_isValid(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isEmpty()
	{
		bool result = (SwigDerivedClassHasMethod("isEmpty", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_isEmptySwigExplicitOdDbGeomRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_isEmpty(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbEntity createEntity()
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(SwigDerivedClassHasMethod("createEntity", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_createEntitySwigExplicitOdDbGeomRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_createEntity(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult evaluateAndCacheGeometry()
	{
		int result = (SwigDerivedClassHasMethod("evaluateAndCacheGeometry", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_evaluateAndCacheGeometrySwigExplicitOdDbGeomRef(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_evaluateAndCacheGeometry(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbGeomRef createObject()
	{
		OdDbGeomRef rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeomRef>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeomRef_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeomRef));
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
}
