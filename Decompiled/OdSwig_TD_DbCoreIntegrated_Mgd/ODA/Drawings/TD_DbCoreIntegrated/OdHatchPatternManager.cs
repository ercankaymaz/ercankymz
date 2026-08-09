using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdHatchPatternManager : OdRxObject
{
	public delegate IntPtr SwigDelegateOdHatchPatternManager_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdHatchPatternManager_1();

	public delegate void SwigDelegateOdHatchPatternManager_2(IntPtr pSource);

	public delegate void SwigDelegateOdHatchPatternManager_3(IntPtr pServices);

	public delegate int SwigDelegateOdHatchPatternManager_4(int hatchPatternType, [MarshalAs(UnmanagedType.LPWStr)] string hatchPatternName, int measurementValue, IntPtr hatchPattern);

	public delegate void SwigDelegateOdHatchPatternManager_5(int hatchPatternType, [MarshalAs(UnmanagedType.LPWStr)] string hatchPatternName, IntPtr hatchPattern, int measurementValue);

	public delegate void SwigDelegateOdHatchPatternManager_6(int hatchPatternType, [MarshalAs(UnmanagedType.LPWStr)] string hatchPatternName, IntPtr hatchPattern);

	public delegate int SwigDelegateOdHatchPatternManager_7(int hatchPatternType, int measurementValue, IntPtr patternNames);

	public delegate void SwigDelegateOdHatchPatternManager_8();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdHatchPatternManager_0 swigDelegate0;

	private SwigDelegateOdHatchPatternManager_1 swigDelegate1;

	private SwigDelegateOdHatchPatternManager_2 swigDelegate2;

	private SwigDelegateOdHatchPatternManager_3 swigDelegate3;

	private SwigDelegateOdHatchPatternManager_4 swigDelegate4;

	private SwigDelegateOdHatchPatternManager_5 swigDelegate5;

	private SwigDelegateOdHatchPatternManager_6 swigDelegate6;

	private SwigDelegateOdHatchPatternManager_7 swigDelegate7;

	private SwigDelegateOdHatchPatternManager_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbHostAppServices) };

	private static Type[] swigMethodTypes4 = new Type[4]
	{
		typeof(OdDbHatch_HatchPatternType),
		typeof(string),
		typeof(MeasurementValue),
		typeof(OdHatchPattern)
	};

	private static Type[] swigMethodTypes5 = new Type[4]
	{
		typeof(OdDbHatch_HatchPatternType),
		typeof(string),
		typeof(OdHatchPattern),
		typeof(MeasurementValue)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdDbHatch_HatchPatternType),
		typeof(string),
		typeof(OdHatchPattern)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdDbHatch_HatchPatternType),
		typeof(MeasurementValue),
		typeof(OdStringArray)
	};

	private static Type[] swigMethodTypes8 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdHatchPatternManager(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdHatchPatternManager obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdHatchPatternManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdHatchPatternManager()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdHatchPatternManager(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdHatchPatternManager) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdHatchPatternManager cast(OdRxObject pObj)
	{
		OdHatchPatternManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdHatchPatternManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_isASwigExplicitOdHatchPatternManager(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_queryXSwigExplicitOdHatchPatternManager(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdHatchPatternManager createObject()
	{
		OdHatchPatternManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdHatchPatternManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setApplicationService(OdDbHostAppServices pServices)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_setApplicationService(swigCPtr, OdDbHostAppServices.getCPtr(pServices));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult retrievePattern(OdDbHatch_HatchPatternType hatchPatternType, string hatchPatternName, MeasurementValue measurementValue, OdHatchPattern hatchPattern)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_retrievePattern(swigCPtr, (int)hatchPatternType, hatchPatternName, (int)measurementValue, OdHatchPattern.getCPtr(hatchPattern).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void appendPattern(OdDbHatch_HatchPatternType hatchPatternType, string hatchPatternName, OdHatchPattern hatchPattern, MeasurementValue measurementValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_appendPattern__SWIG_0(swigCPtr, (int)hatchPatternType, hatchPatternName, OdHatchPattern.getCPtr(hatchPattern).Handle, (int)measurementValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void appendPattern(OdDbHatch_HatchPatternType hatchPatternType, string hatchPatternName, OdHatchPattern hatchPattern)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_appendPattern__SWIG_1(swigCPtr, (int)hatchPatternType, hatchPatternName, OdHatchPattern.getCPtr(hatchPattern).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult retrievePatternList(OdDbHatch_HatchPatternType hatchPatternType, MeasurementValue measurementValue, OdStringArray patternNames)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_retrievePatternList(swigCPtr, (int)hatchPatternType, (int)measurementValue, OdStringArray.getCPtr(patternNames).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void reset()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_reset(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("setApplicationService", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetApplicationService;
		}
		if (SwigDerivedClassHasMethod("retrievePattern", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodretrievePattern;
		}
		if (SwigDerivedClassHasMethod("appendPattern", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodappendPattern__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("appendPattern", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodappendPattern__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("retrievePatternList", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodretrievePatternList;
		}
		if (SwigDerivedClassHasMethod("reset", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodreset;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdHatchPatternManager_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdHatchPatternManager));
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

	private void SwigDirectorMethodsetApplicationService(IntPtr pServices)
	{
		try
		{
			setApplicationService(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHostAppServices>(pServices, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodretrievePattern(int hatchPatternType, [MarshalAs(UnmanagedType.LPWStr)] string hatchPatternName, int measurementValue, IntPtr hatchPattern)
	{
		return (int)retrievePattern((OdDbHatch_HatchPatternType)hatchPatternType, hatchPatternName, (MeasurementValue)measurementValue, new OdHatchPattern(hatchPattern, cMemoryOwn: true));
	}

	private void SwigDirectorMethodappendPattern__SWIG_0(int hatchPatternType, [MarshalAs(UnmanagedType.LPWStr)] string hatchPatternName, IntPtr hatchPattern, int measurementValue)
	{
		try
		{
			appendPattern((OdDbHatch_HatchPatternType)hatchPatternType, hatchPatternName, new OdHatchPattern(hatchPattern, cMemoryOwn: true), (MeasurementValue)measurementValue);
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

	private void SwigDirectorMethodappendPattern__SWIG_1(int hatchPatternType, [MarshalAs(UnmanagedType.LPWStr)] string hatchPatternName, IntPtr hatchPattern)
	{
		try
		{
			appendPattern((OdDbHatch_HatchPatternType)hatchPatternType, hatchPatternName, new OdHatchPattern(hatchPattern, cMemoryOwn: true));
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

	private int SwigDirectorMethodretrievePatternList(int hatchPatternType, int measurementValue, IntPtr patternNames)
	{
		return (int)retrievePatternList((OdDbHatch_HatchPatternType)hatchPatternType, (MeasurementValue)measurementValue, new OdStringArray(patternNames, cMemoryOwn: true));
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
}
