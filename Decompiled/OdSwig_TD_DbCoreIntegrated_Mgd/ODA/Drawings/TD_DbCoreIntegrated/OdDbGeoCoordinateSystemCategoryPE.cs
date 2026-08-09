using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoCoordinateSystemCategoryPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystemCategoryPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystemCategoryPE_1();

	public delegate void SwigDelegateOdDbGeoCoordinateSystemCategoryPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemCategoryPE_3(IntPtr arrCategories);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoCoordinateSystemCategoryPE_0 swigDelegate0;

	private SwigDelegateOdDbGeoCoordinateSystemCategoryPE_1 swigDelegate1;

	private SwigDelegateOdDbGeoCoordinateSystemCategoryPE_2 swigDelegate2;

	private SwigDelegateOdDbGeoCoordinateSystemCategoryPE_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoCoordinateSystemCategoryPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoCoordinateSystemCategoryPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoCoordinateSystemCategoryPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoCoordinateSystemCategoryPE cast(OdRxObject pObj)
	{
		OdDbGeoCoordinateSystemCategoryPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemCategoryPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_isASwigExplicitOdDbGeoCoordinateSystemCategoryPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_queryXSwigExplicitOdDbGeoCoordinateSystemCategoryPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoCoordinateSystemCategoryPE createObject()
	{
		OdDbGeoCoordinateSystemCategoryPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemCategoryPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult createAll(OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator arrCategories)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_createAll(swigCPtr, OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator.getCPtr(arrCategories));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("createAll", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcreateAll;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategoryPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoCoordinateSystemCategoryPE));
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

	private int SwigDirectorMethodcreateAll(IntPtr arrCategories)
	{
		return (int)createAll(new OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator(arrCategories, cMemoryOwn: false));
	}
}
