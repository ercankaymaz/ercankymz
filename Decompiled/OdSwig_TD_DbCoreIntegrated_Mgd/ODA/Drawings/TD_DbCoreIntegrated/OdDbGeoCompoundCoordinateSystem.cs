using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoCompoundCoordinateSystem : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoCompoundCoordinateSystem_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoCompoundCoordinateSystem_1();

	public delegate void SwigDelegateOdDbGeoCompoundCoordinateSystem_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoCompoundCoordinateSystem_3(IntPtr pCoordSys);

	public delegate int SwigDelegateOdDbGeoCompoundCoordinateSystem_4(IntPtr pCoordSys);

	public delegate int SwigDelegateOdDbGeoCompoundCoordinateSystem_5(IntPtr sXml);

	public delegate int SwigDelegateOdDbGeoCompoundCoordinateSystem_6(IntPtr sWkt);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoCompoundCoordinateSystem_0 swigDelegate0;

	private SwigDelegateOdDbGeoCompoundCoordinateSystem_1 swigDelegate1;

	private SwigDelegateOdDbGeoCompoundCoordinateSystem_2 swigDelegate2;

	private SwigDelegateOdDbGeoCompoundCoordinateSystem_3 swigDelegate3;

	private SwigDelegateOdDbGeoCompoundCoordinateSystem_4 swigDelegate4;

	private SwigDelegateOdDbGeoCompoundCoordinateSystem_5 swigDelegate5;

	private SwigDelegateOdDbGeoCompoundCoordinateSystem_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbGeoCoordinateSystem).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbGeoVerticalCoordinateSystem).MakeByRefType() };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string).MakeByRefType() };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoCompoundCoordinateSystem(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoCompoundCoordinateSystem obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoCompoundCoordinateSystem(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoCompoundCoordinateSystem cast(OdRxObject pObj)
	{
		OdDbGeoCompoundCoordinateSystem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCompoundCoordinateSystem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_isASwigExplicitOdDbGeoCompoundCoordinateSystem(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_queryXSwigExplicitOdDbGeoCompoundCoordinateSystem(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoCompoundCoordinateSystem createObject()
	{
		OdDbGeoCompoundCoordinateSystem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCompoundCoordinateSystem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbGeoCompoundCoordinateSystem()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGeoCompoundCoordinateSystem(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbGeoCompoundCoordinateSystem) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual OdResult getGeodeticCoordinateSystem(ref OdDbGeoCoordinateSystem pCoordSys)
	{
		IntPtr jarg = ((pCoordSys == null) ? IntPtr.Zero : OdDbGeoCoordinateSystem.getCPtr(pCoordSys).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_getGeodeticCoordinateSystem(swigCPtr, ref jarg);
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

	public virtual OdResult getVerticalCoordinateSystem(ref OdDbGeoVerticalCoordinateSystem pCoordSys)
	{
		IntPtr jarg = ((pCoordSys == null) ? IntPtr.Zero : OdDbGeoVerticalCoordinateSystem.getCPtr(pCoordSys).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_getVerticalCoordinateSystem(swigCPtr, ref jarg);
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

	public virtual OdResult getXmlRepresentation(ref string sXml)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sXml);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_getXmlRepresentation(swigCPtr, ref jarg);
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
				sXml = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getWktRepresentation(ref string sWkt)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sWkt);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_getWktRepresentation(swigCPtr, ref jarg);
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
				sWkt = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static OdResult create(string sCoordSysIdOrFullDef, ref OdDbGeoCompoundCoordinateSystem pCoordSys)
	{
		IntPtr jarg = ((pCoordSys == null) ? IntPtr.Zero : getCPtr(pCoordSys).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_create(sCoordSysIdOrFullDef, ref jarg);
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
				pCoordSys = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCompoundCoordinateSystem>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult verify(string sCoordSysId, string sVerticalCoordSysId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_verify(sCoordSysId, sVerticalCoordSysId);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getGeodeticCoordinateSystem", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetGeodeticCoordinateSystem;
		}
		if (SwigDerivedClassHasMethod("getVerticalCoordinateSystem", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetVerticalCoordinateSystem;
		}
		if (SwigDerivedClassHasMethod("getXmlRepresentation", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetXmlRepresentation;
		}
		if (SwigDerivedClassHasMethod("getWktRepresentation", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetWktRepresentation;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCompoundCoordinateSystem_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoCompoundCoordinateSystem));
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

	private int SwigDirectorMethodgetGeodeticCoordinateSystem(IntPtr pCoordSys)
	{
		OdSwigDirectorHelper.director_UnpackData(pCoordSys, out var pOriginalObject, out var pFunction);
		OdDbGeoCoordinateSystem pCoordSys2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystem>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getGeodeticCoordinateSystem(ref pCoordSys2);
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

	private int SwigDirectorMethodgetVerticalCoordinateSystem(IntPtr pCoordSys)
	{
		OdSwigDirectorHelper.director_UnpackData(pCoordSys, out var pOriginalObject, out var pFunction);
		OdDbGeoVerticalCoordinateSystem pCoordSys2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoVerticalCoordinateSystem>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getVerticalCoordinateSystem(ref pCoordSys2);
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

	private int SwigDirectorMethodgetXmlRepresentation(IntPtr sXml)
	{
		OdSwigDirectorHelper.director_UnpackData(sXml, out var pOriginalObject, out var pFunction);
		string sXml2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sXml2;
		try
		{
			return (int)getXmlRepresentation(ref sXml2);
		}
		finally
		{
			if (sXml2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sXml2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sXml);
		}
	}

	private int SwigDirectorMethodgetWktRepresentation(IntPtr sWkt)
	{
		OdSwigDirectorHelper.director_UnpackData(sWkt, out var pOriginalObject, out var pFunction);
		string sWkt2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sWkt2;
		try
		{
			return (int)getWktRepresentation(ref sWkt2);
		}
		finally
		{
			if (sWkt2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sWkt2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sWkt);
		}
	}
}
