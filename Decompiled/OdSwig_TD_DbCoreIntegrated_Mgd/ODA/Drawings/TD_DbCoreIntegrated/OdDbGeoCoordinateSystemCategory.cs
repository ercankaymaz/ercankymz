using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoCoordinateSystemCategory : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystemCategory_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystemCategory_1();

	public delegate void SwigDelegateOdDbGeoCoordinateSystemCategory_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemCategory_3(IntPtr sCategoryId);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemCategory_4(int nNum);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemCategory_5(int nIndex, IntPtr pCoordSys);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemCategory_6(IntPtr arrIds);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemCategory_7(int nNum);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemCategory_8(int nIndex, IntPtr pCoordSys);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemCategory_9(IntPtr arrIds);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoCoordinateSystemCategory_0 swigDelegate0;

	private SwigDelegateOdDbGeoCoordinateSystemCategory_1 swigDelegate1;

	private SwigDelegateOdDbGeoCoordinateSystemCategory_2 swigDelegate2;

	private SwigDelegateOdDbGeoCoordinateSystemCategory_3 swigDelegate3;

	private SwigDelegateOdDbGeoCoordinateSystemCategory_4 swigDelegate4;

	private SwigDelegateOdDbGeoCoordinateSystemCategory_5 swigDelegate5;

	private SwigDelegateOdDbGeoCoordinateSystemCategory_6 swigDelegate6;

	private SwigDelegateOdDbGeoCoordinateSystemCategory_7 swigDelegate7;

	private SwigDelegateOdDbGeoCoordinateSystemCategory_8 swigDelegate8;

	private SwigDelegateOdDbGeoCoordinateSystemCategory_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(int).MakeByRefType() };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(int),
		typeof(OdDbGeoCoordinateSystem).MakeByRefType()
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdStringArray) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(int).MakeByRefType() };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(int),
		typeof(OdDbGeoVerticalCoordinateSystem).MakeByRefType()
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdStringArray) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoCoordinateSystemCategory(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoCoordinateSystemCategory obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoCoordinateSystemCategory(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoCoordinateSystemCategory cast(OdRxObject pObj)
	{
		OdDbGeoCoordinateSystemCategory rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemCategory>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_isASwigExplicitOdDbGeoCoordinateSystemCategory(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_queryXSwigExplicitOdDbGeoCoordinateSystemCategory(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoCoordinateSystemCategory createObject()
	{
		OdDbGeoCoordinateSystemCategory rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemCategory>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getId(ref string sCategoryId)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sCategoryId);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_getId(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				sCategoryId = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getNumOfCoordinateSystem(out int nNum)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_getNumOfCoordinateSystem(swigCPtr, out nNum);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getCoordinateSystemAt(int nIndex, ref OdDbGeoCoordinateSystem pCoordSys)
	{
		IntPtr jarg = ((pCoordSys == null) ? IntPtr.Zero : OdDbGeoCoordinateSystem.getCPtr(pCoordSys).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_getCoordinateSystemAt(swigCPtr, nIndex, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pCoordSys = null;
			}
			else if (jarg != intPtr)
			{
				pCoordSys = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystem>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getCoordinateSystemIds(OdStringArray arrIds)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_getCoordinateSystemIds(swigCPtr, OdStringArray.getCPtr(arrIds).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getNumOfVerticalCoordinateSystem(out int nNum)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_getNumOfVerticalCoordinateSystem(swigCPtr, out nNum);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getVerticalCoordinateSystemAt(int nIndex, ref OdDbGeoVerticalCoordinateSystem pCoordSys)
	{
		IntPtr jarg = ((pCoordSys == null) ? IntPtr.Zero : OdDbGeoVerticalCoordinateSystem.getCPtr(pCoordSys).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_getVerticalCoordinateSystemAt(swigCPtr, nIndex, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pCoordSys = null;
			}
			else if (jarg != intPtr)
			{
				pCoordSys = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoVerticalCoordinateSystem>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getVerticalCoordinateSystemIds(OdStringArray arrIds)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_getVerticalCoordinateSystemIds(swigCPtr, OdStringArray.getCPtr(arrIds).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult createAll(OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator arrCategories)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_createAll(OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator.getCPtr(arrCategories));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getId", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetId;
		}
		if (SwigDerivedClassHasMethod("getNumOfCoordinateSystem", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetNumOfCoordinateSystem;
		}
		if (SwigDerivedClassHasMethod("getCoordinateSystemAt", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetCoordinateSystemAt;
		}
		if (SwigDerivedClassHasMethod("getCoordinateSystemIds", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetCoordinateSystemIds;
		}
		if (SwigDerivedClassHasMethod("getNumOfVerticalCoordinateSystem", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetNumOfVerticalCoordinateSystem;
		}
		if (SwigDerivedClassHasMethod("getVerticalCoordinateSystemAt", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetVerticalCoordinateSystemAt;
		}
		if (SwigDerivedClassHasMethod("getVerticalCoordinateSystemIds", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetVerticalCoordinateSystemIds;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemCategory_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoCoordinateSystemCategory));
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

	private int SwigDirectorMethodgetId(IntPtr sCategoryId)
	{
		OdSwigDirectorHelper.director_UnpackData(sCategoryId, out var pOriginalObject, out var pFunction);
		string sCategoryId2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sCategoryId2;
		try
		{
			return (int)getId(ref sCategoryId2);
		}
		finally
		{
			if (sCategoryId2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sCategoryId2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sCategoryId);
		}
	}

	private int SwigDirectorMethodgetNumOfCoordinateSystem(int nNum)
	{
		return (int)getNumOfCoordinateSystem(out nNum);
	}

	private int SwigDirectorMethodgetCoordinateSystemAt(int nIndex, IntPtr pCoordSys)
	{
		OdSwigDirectorHelper.director_UnpackData(pCoordSys, out var pOriginalObject, out var pFunction);
		OdDbGeoCoordinateSystem pCoordSys2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystem>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getCoordinateSystemAt(nIndex, ref pCoordSys2);
		}
		finally
		{
			IntPtr handle = OdDbGeoCoordinateSystem.getCPtr(pCoordSys2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pCoordSys);
		}
	}

	private int SwigDirectorMethodgetCoordinateSystemIds(IntPtr arrIds)
	{
		return (int)getCoordinateSystemIds(new OdStringArray(arrIds, cMemoryOwn: true));
	}

	private int SwigDirectorMethodgetNumOfVerticalCoordinateSystem(int nNum)
	{
		return (int)getNumOfVerticalCoordinateSystem(out nNum);
	}

	private int SwigDirectorMethodgetVerticalCoordinateSystemAt(int nIndex, IntPtr pCoordSys)
	{
		OdSwigDirectorHelper.director_UnpackData(pCoordSys, out var pOriginalObject, out var pFunction);
		OdDbGeoVerticalCoordinateSystem pCoordSys2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoVerticalCoordinateSystem>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getVerticalCoordinateSystemAt(nIndex, ref pCoordSys2);
		}
		finally
		{
			IntPtr handle = OdDbGeoVerticalCoordinateSystem.getCPtr(pCoordSys2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pCoordSys);
		}
	}

	private int SwigDirectorMethodgetVerticalCoordinateSystemIds(IntPtr arrIds)
	{
		return (int)getVerticalCoordinateSystemIds(new OdStringArray(arrIds, cMemoryOwn: true));
	}
}
