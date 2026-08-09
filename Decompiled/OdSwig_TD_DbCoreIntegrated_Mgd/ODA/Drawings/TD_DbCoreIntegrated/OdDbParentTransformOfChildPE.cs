using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbParentTransformOfChildPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbParentTransformOfChildPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbParentTransformOfChildPE_1();

	public delegate void SwigDelegateOdDbParentTransformOfChildPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbParentTransformOfChildPE_3(IntPtr pThisParent, IntPtr childId, IntPtr arg2);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbParentTransformOfChildPE_0 swigDelegate0;

	private SwigDelegateOdDbParentTransformOfChildPE_1 swigDelegate1;

	private SwigDelegateOdDbParentTransformOfChildPE_2 swigDelegate2;

	private SwigDelegateOdDbParentTransformOfChildPE_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectId),
		typeof(OdGeMatrix3d)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbParentTransformOfChildPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbParentTransformOfChildPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbParentTransformOfChildPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbParentTransformOfChildPE cast(OdRxObject pObj)
	{
		OdDbParentTransformOfChildPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbParentTransformOfChildPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_isASwigExplicitOdDbParentTransformOfChildPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_queryXSwigExplicitOdDbParentTransformOfChildPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbParentTransformOfChildPE createObject()
	{
		OdDbParentTransformOfChildPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbParentTransformOfChildPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getParentTransformOfChild(OdDbObject pThisParent, OdDbObjectId childId, OdGeMatrix3d arg2)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_getParentTransformOfChild(swigCPtr, OdDbObject.getCPtr(pThisParent), OdDbObjectId.getCPtr(childId), OdGeMatrix3d.getCPtr(arg2));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getParentTransformOfChild", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetParentTransformOfChild;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParentTransformOfChildPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbParentTransformOfChildPE));
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

	private int SwigDirectorMethodgetParentTransformOfChild(IntPtr pThisParent, IntPtr childId, IntPtr arg2)
	{
		return (int)getParentTransformOfChild(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pThisParent, bOwn: false, bTryAddToTransaction: false), new OdDbObjectId(childId, cMemoryOwn: false), new OdGeMatrix3d(arg2, cMemoryOwn: false));
	}
}
