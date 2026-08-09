using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDimensionRecomputePE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbDimensionRecomputePE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDimensionRecomputePE_1();

	public delegate void SwigDelegateOdDbDimensionRecomputePE_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbDimensionRecomputePE_3(IntPtr pDimension);

	public delegate void SwigDelegateOdDbDimensionRecomputePE_4(IntPtr pDimension, IntPtr ctx);

	public delegate void SwigDelegateOdDbDimensionRecomputePE_5(IntPtr pDimension, IntPtr formattedMeasurement, double measurementValue, [MarshalAs(UnmanagedType.LPWStr)] string dimensionText);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDimensionRecomputePE_0 swigDelegate0;

	private SwigDelegateOdDbDimensionRecomputePE_1 swigDelegate1;

	private SwigDelegateOdDbDimensionRecomputePE_2 swigDelegate2;

	private SwigDelegateOdDbDimensionRecomputePE_3 swigDelegate3;

	private SwigDelegateOdDbDimensionRecomputePE_4 swigDelegate4;

	private SwigDelegateOdDbDimensionRecomputePE_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbDimension) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbDimension),
		typeof(OdDbDimensionObjectContextData)
	};

	private static Type[] swigMethodTypes5 = new Type[4]
	{
		typeof(OdDbDimension),
		typeof(string).MakeByRefType(),
		typeof(double),
		typeof(string)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDimensionRecomputePE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDimensionRecomputePE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDimensionRecomputePE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbDimensionRecomputePE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDimensionRecomputePE(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public static void setMeasurementValue(OdDbDimension pDimension, double measurementValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_setMeasurementValue(OdDbDimension.getCPtr(pDimension), measurementValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void resetDimBlockInsertParams(OdDbDimension pDimension)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_resetDimBlockInsertParams(OdDbDimension.getCPtr(pDimension));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new static OdDbDimensionRecomputePE cast(OdRxObject pObj)
	{
		OdDbDimensionRecomputePE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDimensionRecomputePE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_isASwigExplicitOdDbDimensionRecomputePE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_queryXSwigExplicitOdDbDimensionRecomputePE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbDimensionRecomputePE createObject()
	{
		OdDbDimensionRecomputePE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDimensionRecomputePE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void recomputeDimMeasurement(OdDbDimension pDimension)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_recomputeDimMeasurement(swigCPtr, OdDbDimension.getCPtr(pDimension));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void recomputeDimBlock(OdDbDimension pDimension, OdDbDimensionObjectContextData ctx)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_recomputeDimBlock(swigCPtr, OdDbDimension.getCPtr(pDimension), OdDbDimensionObjectContextData.getCPtr(ctx));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void formatMeasurement(OdDbDimension pDimension, ref string formattedMeasurement, double measurementValue, string dimensionText)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(formattedMeasurement);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_formatMeasurement(swigCPtr, OdDbDimension.getCPtr(pDimension), ref jarg, measurementValue, dimensionText);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				formattedMeasurement = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("recomputeDimMeasurement", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodrecomputeDimMeasurement;
		}
		if (SwigDerivedClassHasMethod("recomputeDimBlock", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodrecomputeDimBlock;
		}
		if (SwigDerivedClassHasMethod("formatMeasurement", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodformatMeasurement;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimensionRecomputePE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDimensionRecomputePE));
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

	private void SwigDirectorMethodrecomputeDimMeasurement(IntPtr pDimension)
	{
		try
		{
			recomputeDimMeasurement(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDimension>(pDimension, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodrecomputeDimBlock(IntPtr pDimension, IntPtr ctx)
	{
		try
		{
			recomputeDimBlock(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDimension>(pDimension, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDimensionObjectContextData>(ctx, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodformatMeasurement(IntPtr pDimension, IntPtr formattedMeasurement, double measurementValue, [MarshalAs(UnmanagedType.LPWStr)] string dimensionText)
	{
		OdSwigDirectorHelper.director_UnpackData(formattedMeasurement, out var pOriginalObject, out var pFunction);
		string formattedMeasurement2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = formattedMeasurement2;
		try
		{
			formatMeasurement(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDimension>(pDimension, bOwn: false, bTryAddToTransaction: false), ref formattedMeasurement2, measurementValue, dimensionText);
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
		finally
		{
			if (formattedMeasurement2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(formattedMeasurement2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(formattedMeasurement);
		}
	}
}
