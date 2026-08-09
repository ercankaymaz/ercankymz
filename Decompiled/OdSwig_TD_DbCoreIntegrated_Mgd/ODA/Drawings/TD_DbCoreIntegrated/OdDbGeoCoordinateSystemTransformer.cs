using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoCoordinateSystemTransformer : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystemTransformer_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystemTransformer_1();

	public delegate void SwigDelegateOdDbGeoCoordinateSystemTransformer_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemTransformer_3(IntPtr sSourceCoordSysId);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemTransformer_4(IntPtr sTargetCoordSysId);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemTransformer_5(IntPtr ptIn, IntPtr ptOut);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemTransformer_6(IntPtr arrPtIn, IntPtr arrPtOut);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoCoordinateSystemTransformer_0 swigDelegate0;

	private SwigDelegateOdDbGeoCoordinateSystemTransformer_1 swigDelegate1;

	private SwigDelegateOdDbGeoCoordinateSystemTransformer_2 swigDelegate2;

	private SwigDelegateOdDbGeoCoordinateSystemTransformer_3 swigDelegate3;

	private SwigDelegateOdDbGeoCoordinateSystemTransformer_4 swigDelegate4;

	private SwigDelegateOdDbGeoCoordinateSystemTransformer_5 swigDelegate5;

	private SwigDelegateOdDbGeoCoordinateSystemTransformer_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGePoint3dArray),
		typeof(OdGePoint3dArray)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoCoordinateSystemTransformer(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoCoordinateSystemTransformer obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoCoordinateSystemTransformer(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoCoordinateSystemTransformer cast(OdRxObject pObj)
	{
		OdDbGeoCoordinateSystemTransformer rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemTransformer>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_isASwigExplicitOdDbGeoCoordinateSystemTransformer(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_queryXSwigExplicitOdDbGeoCoordinateSystemTransformer(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoCoordinateSystemTransformer createObject()
	{
		OdDbGeoCoordinateSystemTransformer rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemTransformer>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getSourceCoordinateSystemId(ref string sSourceCoordSysId)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sSourceCoordSysId);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_getSourceCoordinateSystemId(swigCPtr, ref jarg);
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
				sSourceCoordSysId = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getTargetCoordinateSystemId(ref string sTargetCoordSysId)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sTargetCoordSysId);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_getTargetCoordinateSystemId(swigCPtr, ref jarg);
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
				sTargetCoordSysId = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult transformPoint(OdGePoint3d ptIn, OdGePoint3d ptOut)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_transformPoint__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(ptIn), OdGePoint3d.getCPtr(ptOut));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult transformPoints(OdGePoint3dArray arrPtIn, OdGePoint3dArray arrPtOut)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_transformPoints__SWIG_0(swigCPtr, OdGePoint3dArray.getCPtr(arrPtIn).Handle, OdGePoint3dArray.getCPtr(arrPtOut).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult transformPoint(string sSourceCoordSysId, string sTargetCoordSysId, OdGePoint3d ptIn, OdGePoint3d ptOut)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_transformPoint__SWIG_1(sSourceCoordSysId, sTargetCoordSysId, OdGePoint3d.getCPtr(ptIn), OdGePoint3d.getCPtr(ptOut));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult transformPoints(string sSourceCoordSysId, string sTargetCoordSysId, OdGePoint3dArray arrPtIn, OdGePoint3dArray arrPtOut)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_transformPoints__SWIG_1(sSourceCoordSysId, sTargetCoordSysId, OdGePoint3dArray.getCPtr(arrPtIn).Handle, OdGePoint3dArray.getCPtr(arrPtOut).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult create(string sSourceCoordSysId, string sTargetCoordSysId, ref OdDbGeoCoordinateSystemTransformer pCoordSysTransformer)
	{
		IntPtr jarg = ((pCoordSysTransformer == null) ? IntPtr.Zero : getCPtr(pCoordSysTransformer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_create(sSourceCoordSysId, sTargetCoordSysId, ref jarg);
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
				pCoordSysTransformer = null;
			}
			else if (jarg != intPtr)
			{
				pCoordSysTransformer = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemTransformer>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getSourceCoordinateSystemId", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetSourceCoordinateSystemId;
		}
		if (SwigDerivedClassHasMethod("getTargetCoordinateSystemId", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetTargetCoordinateSystemId;
		}
		if (SwigDerivedClassHasMethod("transformPoint", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodtransformPoint__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("transformPoints", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodtransformPoints__SWIG_0;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformer_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoCoordinateSystemTransformer));
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

	private int SwigDirectorMethodgetSourceCoordinateSystemId(IntPtr sSourceCoordSysId)
	{
		OdSwigDirectorHelper.director_UnpackData(sSourceCoordSysId, out var pOriginalObject, out var pFunction);
		string sSourceCoordSysId2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sSourceCoordSysId2;
		try
		{
			return (int)getSourceCoordinateSystemId(ref sSourceCoordSysId2);
		}
		finally
		{
			if (sSourceCoordSysId2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sSourceCoordSysId2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sSourceCoordSysId);
		}
	}

	private int SwigDirectorMethodgetTargetCoordinateSystemId(IntPtr sTargetCoordSysId)
	{
		OdSwigDirectorHelper.director_UnpackData(sTargetCoordSysId, out var pOriginalObject, out var pFunction);
		string sTargetCoordSysId2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = sTargetCoordSysId2;
		try
		{
			return (int)getTargetCoordinateSystemId(ref sTargetCoordSysId2);
		}
		finally
		{
			if (sTargetCoordSysId2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(sTargetCoordSysId2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(sTargetCoordSysId);
		}
	}

	private int SwigDirectorMethodtransformPoint__SWIG_0(IntPtr ptIn, IntPtr ptOut)
	{
		return (int)transformPoint(new OdGePoint3d(ptIn, cMemoryOwn: false), new OdGePoint3d(ptOut, cMemoryOwn: false));
	}

	private int SwigDirectorMethodtransformPoints__SWIG_0(IntPtr arrPtIn, IntPtr arrPtOut)
	{
		return (int)transformPoints(new OdGePoint3dArray(arrPtIn, cMemoryOwn: true), new OdGePoint3dArray(arrPtOut, cMemoryOwn: true));
	}
}
