using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseGeoDataExportPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbBaseGeoDataExportPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBaseGeoDataExportPE_1();

	public delegate void SwigDelegateOdDbBaseGeoDataExportPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbBaseGeoDataExportPE_3(IntPtr arg0, IntPtr arg1, int arg2, int arg3);

	public delegate int SwigDelegateOdDbBaseGeoDataExportPE_4(IntPtr arg0, IntPtr arg1, IntPtr arg2);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBaseGeoDataExportPE_0 swigDelegate0;

	private SwigDelegateOdDbBaseGeoDataExportPE_1 swigDelegate1;

	private SwigDelegateOdDbBaseGeoDataExportPE_2 swigDelegate2;

	private SwigDelegateOdDbBaseGeoDataExportPE_3 swigDelegate3;

	private SwigDelegateOdDbBaseGeoDataExportPE_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdRxObject),
		typeof(string).MakeByRefType(),
		typeof(int).MakeByRefType(),
		typeof(int).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(OdGePoint2dArray),
		typeof(OdGePoint2dArray)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseGeoDataExportPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseGeoDataExportPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseGeoDataExportPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBaseGeoDataExportPE cast(OdRxObject pObj)
	{
		OdDbBaseGeoDataExportPE rXObject = Helpers.GetRXObject<OdDbBaseGeoDataExportPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_isASwigExplicitOdDbBaseGeoDataExportPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_queryXSwigExplicitOdDbBaseGeoDataExportPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult getGeoDataParams(OdRxObject arg0, ref string arg1, out int arg2, out int arg3)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(arg1);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("getGeoDataParams", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_getGeoDataParamsSwigExplicitOdDbBaseGeoDataExportPE(swigCPtr, OdRxObject.getCPtr(arg0), ref jarg, out arg2, out arg3) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_getGeoDataParams(swigCPtr, OdRxObject.getCPtr(arg0), ref jarg, out arg2, out arg3));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				arg1 = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual OdResult getGeoExtents(OdRxObject arg0, OdGePoint2dArray arg1, OdGePoint2dArray arg2)
	{
		int result = (SwigDerivedClassHasMethod("getGeoExtents", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_getGeoExtentsSwigExplicitOdDbBaseGeoDataExportPE(swigCPtr, OdRxObject.getCPtr(arg0), OdGePoint2dArray.getCPtr(arg1).Handle, OdGePoint2dArray.getCPtr(arg2).Handle) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_getGeoExtents(swigCPtr, OdRxObject.getCPtr(arg0), OdGePoint2dArray.getCPtr(arg1).Handle, OdGePoint2dArray.getCPtr(arg2).Handle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbBaseGeoDataExportPE createObject()
	{
		OdDbBaseGeoDataExportPE rXObject = Helpers.GetRXObject<OdDbBaseGeoDataExportPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("getGeoDataParams", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetGeoDataParams;
		}
		if (SwigDerivedClassHasMethod("getGeoExtents", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetGeoExtents;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseGeoDataExportPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBaseGeoDataExportPE));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodgetGeoDataParams(IntPtr arg0, IntPtr arg1, int arg2, int arg3)
	{
		OdSwigDirectorHelper.director_UnpackData(arg1, out var pOriginalObject, out var pFunction);
		string arg4 = Marshal.PtrToStringUni(pOriginalObject);
		string text = arg4;
		try
		{
			return (int)getGeoDataParams(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), ref arg4, out arg2, out arg3);
		}
		finally
		{
			if (arg4 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(arg4);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(arg1);
		}
	}

	private int SwigDirectorMethodgetGeoExtents(IntPtr arg0, IntPtr arg1, IntPtr arg2)
	{
		return (int)getGeoExtents(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), new OdGePoint2dArray(arg1, cMemoryOwn: true), new OdGePoint2dArray(arg2, cMemoryOwn: true));
	}
}
