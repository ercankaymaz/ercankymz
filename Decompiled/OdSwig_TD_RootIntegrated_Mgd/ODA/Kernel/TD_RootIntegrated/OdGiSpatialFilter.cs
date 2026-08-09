using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSpatialFilter : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiSpatialFilter_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiSpatialFilter_1();

	public delegate void SwigDelegateOdGiSpatialFilter_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiSpatialFilter_3();

	public delegate IntPtr SwigDelegateOdGiSpatialFilter_4();

	public delegate IntPtr SwigDelegateOdGiSpatialFilter_5();

	public delegate IntPtr SwigDelegateOdGiSpatialFilter_6();

	public delegate void SwigDelegateOdGiSpatialFilter_7(IntPtr exts, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ);

	public delegate void SwigDelegateOdGiSpatialFilter_8(IntPtr exts, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ);

	public delegate void SwigDelegateOdGiSpatialFilter_9(IntPtr exts, bool bClipLowerZ, double dLowerZ);

	public delegate void SwigDelegateOdGiSpatialFilter_10(IntPtr exts, bool bClipLowerZ);

	public delegate void SwigDelegateOdGiSpatialFilter_11(IntPtr exts);

	public delegate void SwigDelegateOdGiSpatialFilter_12(IntPtr exts, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ);

	public delegate bool SwigDelegateOdGiSpatialFilter_13(uint opt);

	public delegate void SwigDelegateOdGiSpatialFilter_14(IntPtr pDrawCtx);

	public delegate void SwigDelegateOdGiSpatialFilter_15(IntPtr deviations);

	public delegate void SwigDelegateOdGiSpatialFilter_16(IntPtr pDeviation);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiSpatialFilter_0 swigDelegate0;

	private SwigDelegateOdGiSpatialFilter_1 swigDelegate1;

	private SwigDelegateOdGiSpatialFilter_2 swigDelegate2;

	private SwigDelegateOdGiSpatialFilter_3 swigDelegate3;

	private SwigDelegateOdGiSpatialFilter_4 swigDelegate4;

	private SwigDelegateOdGiSpatialFilter_5 swigDelegate5;

	private SwigDelegateOdGiSpatialFilter_6 swigDelegate6;

	private SwigDelegateOdGiSpatialFilter_7 swigDelegate7;

	private SwigDelegateOdGiSpatialFilter_8 swigDelegate8;

	private SwigDelegateOdGiSpatialFilter_9 swigDelegate9;

	private SwigDelegateOdGiSpatialFilter_10 swigDelegate10;

	private SwigDelegateOdGiSpatialFilter_11 swigDelegate11;

	private SwigDelegateOdGiSpatialFilter_12 swigDelegate12;

	private SwigDelegateOdGiSpatialFilter_13 swigDelegate13;

	private SwigDelegateOdGiSpatialFilter_14 swigDelegate14;

	private SwigDelegateOdGiSpatialFilter_15 swigDelegate15;

	private SwigDelegateOdGiSpatialFilter_16 swigDelegate16;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[5]
	{
		typeof(OdGeExtents2d),
		typeof(bool),
		typeof(double),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes8 = new Type[4]
	{
		typeof(OdGeExtents2d),
		typeof(bool),
		typeof(double),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdGeExtents2d),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGeExtents2d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGeExtents2d) };

	private static Type[] swigMethodTypes12 = new Type[5]
	{
		typeof(OdGeExtents2d),
		typeof(bool).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(bool).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGiConveyorContext) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDoubleArray) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdGiDeviation) };

	public static OdGiConveyorGeometry kNullGeometry
	{
		get
		{
			OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_kNullGeometry_get(), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_kNullGeometry_set(value.GetInterfaceCPtr());
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSpatialFilter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSpatialFilter obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSpatialFilter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdGiSpatialFilter()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSpatialFilter(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiSpatialFilter) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdGiSpatialFilter cast(OdRxObject pObj)
	{
		OdGiSpatialFilter rXObject = Helpers.GetRXObject<OdGiSpatialFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_isASwigExplicitOdGiSpatialFilter(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_queryXSwigExplicitOdGiSpatialFilter(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiSpatialFilter createObject()
	{
		OdGiSpatialFilter rXObject = Helpers.GetRXObject<OdGiSpatialFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiConveyorInput input()
	{
		OdGiConveyorInput_Internal result = new OdGiConveyorInput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_input(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorOutput insideOutput()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_insideOutput(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorOutput intersectsOutput()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_intersectsOutput(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorOutput disjointOutput()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_disjointOutput(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void set(OdGeExtents2d exts, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_set__SWIG_0(swigCPtr, OdGeExtents2d.getCPtr(exts), bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGeExtents2d exts, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_set__SWIG_1(swigCPtr, OdGeExtents2d.getCPtr(exts), bClipLowerZ, dLowerZ, bClipUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGeExtents2d exts, bool bClipLowerZ, double dLowerZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_set__SWIG_2(swigCPtr, OdGeExtents2d.getCPtr(exts), bClipLowerZ, dLowerZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGeExtents2d exts, bool bClipLowerZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_set__SWIG_3(swigCPtr, OdGeExtents2d.getCPtr(exts), bClipLowerZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGeExtents2d exts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_set__SWIG_4(swigCPtr, OdGeExtents2d.getCPtr(exts));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdGeExtents2d exts, out bool bClipLowerZ, out double dLowerZ, out bool bClipUpperZ, out double dUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_get(swigCPtr, OdGeExtents2d.getCPtr(exts), out bClipLowerZ, out dLowerZ, out bClipUpperZ, out dUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSimplifyOpt(uint opt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_isSimplifyOpt(swigCPtr, opt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDrawContext(OdGiConveyorContext pDrawCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_setDrawContext(swigCPtr, pDrawCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdDoubleArray deviations)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_setDeviation__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(deviations).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdGiDeviation pDeviation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_setDeviation__SWIG_1(swigCPtr, pDeviation.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("input", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinput;
		}
		if (SwigDerivedClassHasMethod("insideOutput", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodinsideOutput;
		}
		if (SwigDerivedClassHasMethod("intersectsOutput", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodintersectsOutput;
		}
		if (SwigDerivedClassHasMethod("disjointOutput", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoddisjointOutput;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodset__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodset__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodset__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodset__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodset__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodget;
		}
		if (SwigDerivedClassHasMethod("isSimplifyOpt", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodisSimplifyOpt;
		}
		if (SwigDerivedClassHasMethod("setDrawContext", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetDrawContext;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetDeviation__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetDeviation__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSpatialFilter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiSpatialFilter));
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

	private IntPtr SwigDirectorMethodinput()
	{
		return input().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodinsideOutput()
	{
		return insideOutput().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodintersectsOutput()
	{
		return intersectsOutput().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethoddisjointOutput()
	{
		return disjointOutput().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodset__SWIG_0(IntPtr exts, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		try
		{
			set(new OdGeExtents2d(exts, cMemoryOwn: false), bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
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

	private void SwigDirectorMethodset__SWIG_1(IntPtr exts, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		try
		{
			set(new OdGeExtents2d(exts, cMemoryOwn: false), bClipLowerZ, dLowerZ, bClipUpperZ);
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

	private void SwigDirectorMethodset__SWIG_2(IntPtr exts, bool bClipLowerZ, double dLowerZ)
	{
		try
		{
			set(new OdGeExtents2d(exts, cMemoryOwn: false), bClipLowerZ, dLowerZ);
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

	private void SwigDirectorMethodset__SWIG_3(IntPtr exts, bool bClipLowerZ)
	{
		try
		{
			set(new OdGeExtents2d(exts, cMemoryOwn: false), bClipLowerZ);
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

	private void SwigDirectorMethodset__SWIG_4(IntPtr exts)
	{
		try
		{
			set(new OdGeExtents2d(exts, cMemoryOwn: false));
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

	private void SwigDirectorMethodget(IntPtr exts, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		try
		{
			get(new OdGeExtents2d(exts, cMemoryOwn: false), out bClipLowerZ, out dLowerZ, out bClipUpperZ, out dUpperZ);
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

	private bool SwigDirectorMethodisSimplifyOpt(uint opt)
	{
		return isSimplifyOpt(opt);
	}

	private void SwigDirectorMethodsetDrawContext(IntPtr pDrawCtx)
	{
		try
		{
			setDrawContext(new OdGiConveyorContext_Internal(pDrawCtx, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDeviation__SWIG_0(IntPtr deviations)
	{
		try
		{
			setDeviation(new OdDoubleArray(deviations, cMemoryOwn: true));
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

	private void SwigDirectorMethodsetDeviation__SWIG_1(IntPtr pDeviation)
	{
		try
		{
			setDeviation(new OdGiDeviation_Internal(pDeviation, cMemoryOwn: false));
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
}
