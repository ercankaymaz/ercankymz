using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGeoCoordinateSystemTransformerPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystemTransformerPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbGeoCoordinateSystemTransformerPE_1();

	public delegate void SwigDelegateOdDbGeoCoordinateSystemTransformerPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemTransformerPE_3([MarshalAs(UnmanagedType.LPWStr)] string sourceCoordSysId, [MarshalAs(UnmanagedType.LPWStr)] string targetCoordSysId, IntPtr pointIn, IntPtr pointOut);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemTransformerPE_4([MarshalAs(UnmanagedType.LPWStr)] string sourceCoordSysId, [MarshalAs(UnmanagedType.LPWStr)] string targetCoordSysId, IntPtr pointsIn, IntPtr pointsOut);

	public delegate int SwigDelegateOdDbGeoCoordinateSystemTransformerPE_5([MarshalAs(UnmanagedType.LPWStr)] string sourceCoordSysId, [MarshalAs(UnmanagedType.LPWStr)] string targetCoordSysId, IntPtr pCoordSysTransformer);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbGeoCoordinateSystemTransformerPE_0 swigDelegate0;

	private SwigDelegateOdDbGeoCoordinateSystemTransformerPE_1 swigDelegate1;

	private SwigDelegateOdDbGeoCoordinateSystemTransformerPE_2 swigDelegate2;

	private SwigDelegateOdDbGeoCoordinateSystemTransformerPE_3 swigDelegate3;

	private SwigDelegateOdDbGeoCoordinateSystemTransformerPE_4 swigDelegate4;

	private SwigDelegateOdDbGeoCoordinateSystemTransformerPE_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(string),
		typeof(string),
		typeof(OdGePoint3d),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes4 = new Type[4]
	{
		typeof(string),
		typeof(string),
		typeof(OdGePoint3dArray),
		typeof(OdGePoint3dArray)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(OdDbGeoCoordinateSystemTransformer).MakeByRefType()
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGeoCoordinateSystemTransformerPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGeoCoordinateSystemTransformerPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGeoCoordinateSystemTransformerPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbGeoCoordinateSystemTransformerPE cast(OdRxObject pObj)
	{
		OdDbGeoCoordinateSystemTransformerPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemTransformerPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_isASwigExplicitOdDbGeoCoordinateSystemTransformerPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_queryXSwigExplicitOdDbGeoCoordinateSystemTransformerPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbGeoCoordinateSystemTransformerPE createObject()
	{
		OdDbGeoCoordinateSystemTransformerPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemTransformerPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult transformPoint(string sourceCoordSysId, string targetCoordSysId, OdGePoint3d pointIn, OdGePoint3d pointOut)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_transformPoint(swigCPtr, sourceCoordSysId, targetCoordSysId, OdGePoint3d.getCPtr(pointIn), OdGePoint3d.getCPtr(pointOut));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult transformPoints(string sourceCoordSysId, string targetCoordSysId, OdGePoint3dArray pointsIn, OdGePoint3dArray pointsOut)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_transformPoints(swigCPtr, sourceCoordSysId, targetCoordSysId, OdGePoint3dArray.getCPtr(pointsIn).Handle, OdGePoint3dArray.getCPtr(pointsOut).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult create(string sourceCoordSysId, string targetCoordSysId, ref OdDbGeoCoordinateSystemTransformer pCoordSysTransformer)
	{
		IntPtr jarg = ((pCoordSysTransformer == null) ? IntPtr.Zero : OdDbGeoCoordinateSystemTransformer.getCPtr(pCoordSysTransformer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_create(swigCPtr, sourceCoordSysId, targetCoordSysId, ref jarg);
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
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("transformPoint", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtransformPoint;
		}
		if (SwigDerivedClassHasMethod("transformPoints", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodtransformPoints;
		}
		if (SwigDerivedClassHasMethod("create", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcreate;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGeoCoordinateSystemTransformerPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGeoCoordinateSystemTransformerPE));
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

	private int SwigDirectorMethodtransformPoint([MarshalAs(UnmanagedType.LPWStr)] string sourceCoordSysId, [MarshalAs(UnmanagedType.LPWStr)] string targetCoordSysId, IntPtr pointIn, IntPtr pointOut)
	{
		return (int)transformPoint(sourceCoordSysId, targetCoordSysId, new OdGePoint3d(pointIn, cMemoryOwn: false), new OdGePoint3d(pointOut, cMemoryOwn: false));
	}

	private int SwigDirectorMethodtransformPoints([MarshalAs(UnmanagedType.LPWStr)] string sourceCoordSysId, [MarshalAs(UnmanagedType.LPWStr)] string targetCoordSysId, IntPtr pointsIn, IntPtr pointsOut)
	{
		return (int)transformPoints(sourceCoordSysId, targetCoordSysId, new OdGePoint3dArray(pointsIn, cMemoryOwn: true), new OdGePoint3dArray(pointsOut, cMemoryOwn: true));
	}

	private int SwigDirectorMethodcreate([MarshalAs(UnmanagedType.LPWStr)] string sourceCoordSysId, [MarshalAs(UnmanagedType.LPWStr)] string targetCoordSysId, IntPtr pCoordSysTransformer)
	{
		OdSwigDirectorHelper.director_UnpackData(pCoordSysTransformer, out var pOriginalObject, out var pFunction);
		OdDbGeoCoordinateSystemTransformer pCoordSysTransformer2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemTransformer>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)create(sourceCoordSysId, targetCoordSysId, ref pCoordSysTransformer2);
		}
		finally
		{
			IntPtr handle = OdDbGeoCoordinateSystemTransformer.getCPtr(pCoordSysTransformer2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pCoordSysTransformer);
		}
	}
}
