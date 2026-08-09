using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiOrthoClipper : OdGiConveyorNode
{
	public delegate IntPtr SwigDelegateOdGiOrthoClipper_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiOrthoClipper_1();

	public delegate void SwigDelegateOdGiOrthoClipper_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiOrthoClipper_3();

	public delegate IntPtr SwigDelegateOdGiOrthoClipper_4();

	public delegate void SwigDelegateOdGiOrthoClipper_5(IntPtr nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ);

	public delegate void SwigDelegateOdGiOrthoClipper_6(IntPtr nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ);

	public delegate void SwigDelegateOdGiOrthoClipper_7(IntPtr nPoints, bool bClipLowerZ, double dLowerZ);

	public delegate void SwigDelegateOdGiOrthoClipper_8(IntPtr nPoints, bool bClipLowerZ);

	public delegate void SwigDelegateOdGiOrthoClipper_9(IntPtr nPoints);

	public delegate void SwigDelegateOdGiOrthoClipper_10(IntPtr points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ);

	public delegate void SwigDelegateOdGiOrthoClipper_11(IntPtr points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ);

	public delegate void SwigDelegateOdGiOrthoClipper_12(IntPtr points, bool bClipLowerZ, double dLowerZ);

	public delegate void SwigDelegateOdGiOrthoClipper_13(IntPtr points, bool bClipLowerZ);

	public delegate void SwigDelegateOdGiOrthoClipper_14(IntPtr points);

	public delegate void SwigDelegateOdGiOrthoClipper_15(IntPtr points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ);

	public delegate void SwigDelegateOdGiOrthoClipper_16(IntPtr deviations);

	public delegate void SwigDelegateOdGiOrthoClipper_17(IntPtr pDeviation);

	public delegate void SwigDelegateOdGiOrthoClipper_18(IntPtr pDrawCtx);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiOrthoClipper_0 swigDelegate0;

	private SwigDelegateOdGiOrthoClipper_1 swigDelegate1;

	private SwigDelegateOdGiOrthoClipper_2 swigDelegate2;

	private SwigDelegateOdGiOrthoClipper_3 swigDelegate3;

	private SwigDelegateOdGiOrthoClipper_4 swigDelegate4;

	private SwigDelegateOdGiOrthoClipper_5 swigDelegate5;

	private SwigDelegateOdGiOrthoClipper_6 swigDelegate6;

	private SwigDelegateOdGiOrthoClipper_7 swigDelegate7;

	private SwigDelegateOdGiOrthoClipper_8 swigDelegate8;

	private SwigDelegateOdGiOrthoClipper_9 swigDelegate9;

	private SwigDelegateOdGiOrthoClipper_10 swigDelegate10;

	private SwigDelegateOdGiOrthoClipper_11 swigDelegate11;

	private SwigDelegateOdGiOrthoClipper_12 swigDelegate12;

	private SwigDelegateOdGiOrthoClipper_13 swigDelegate13;

	private SwigDelegateOdGiOrthoClipper_14 swigDelegate14;

	private SwigDelegateOdGiOrthoClipper_15 swigDelegate15;

	private SwigDelegateOdGiOrthoClipper_16 swigDelegate16;

	private SwigDelegateOdGiOrthoClipper_17 swigDelegate17;

	private SwigDelegateOdGiOrthoClipper_18 swigDelegate18;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[5]
	{
		typeof(OdGePoint2d[]),
		typeof(bool),
		typeof(double),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(OdGePoint2d[]),
		typeof(bool),
		typeof(double),
		typeof(bool)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdGePoint2d[]),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdGePoint2d[]),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGePoint2d[]) };

	private static Type[] swigMethodTypes10 = new Type[5]
	{
		typeof(OdGePoint2dArray),
		typeof(bool),
		typeof(double),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes11 = new Type[4]
	{
		typeof(OdGePoint2dArray),
		typeof(bool),
		typeof(double),
		typeof(bool)
	};

	private static Type[] swigMethodTypes12 = new Type[3]
	{
		typeof(OdGePoint2dArray),
		typeof(bool),
		typeof(double)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdGePoint2dArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGePoint2dArray) };

	private static Type[] swigMethodTypes15 = new Type[5]
	{
		typeof(OdGePoint2dArray),
		typeof(bool).MakeByRefType(),
		typeof(double).MakeByRefType(),
		typeof(bool).MakeByRefType(),
		typeof(double).MakeByRefType()
	};

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDoubleArray) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGiDeviation) };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdGiConveyorContext) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiOrthoClipper(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiOrthoClipper obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiOrthoClipper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiOrthoClipper cast(OdRxObject pObj)
	{
		OdGiOrthoClipper rXObject = Helpers.GetRXObject<OdGiOrthoClipper>(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_isASwigExplicitOdGiOrthoClipper(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_queryXSwigExplicitOdGiOrthoClipper(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiOrthoClipper createObject()
	{
		OdGiOrthoClipper rXObject = Helpers.GetRXObject<OdGiOrthoClipper>(TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void set(OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_set__SWIG_0(swigCPtr, intPtr, bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_set__SWIG_1(swigCPtr, intPtr, bClipLowerZ, dLowerZ, bClipUpperZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(OdGePoint2d[] nPoints, bool bClipLowerZ, double dLowerZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_set__SWIG_2(swigCPtr, intPtr, bClipLowerZ, dLowerZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(OdGePoint2d[] nPoints, bool bClipLowerZ)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_set__SWIG_3(swigCPtr, intPtr, bClipLowerZ);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(OdGePoint2d[] nPoints)
	{
		IntPtr intPtr = Helpers.MarshalPoint2dArray(nPoints);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_set__SWIG_4(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void set(OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_set__SWIG_5(swigCPtr, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_set__SWIG_6(swigCPtr, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ, bClipUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGePoint2dArray points, bool bClipLowerZ, double dLowerZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_set__SWIG_7(swigCPtr, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ, dLowerZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGePoint2dArray points, bool bClipLowerZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_set__SWIG_8(swigCPtr, OdGePoint2dArray.getCPtr(points).Handle, bClipLowerZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGePoint2dArray points)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_set__SWIG_9(swigCPtr, OdGePoint2dArray.getCPtr(points).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdGePoint2dArray points, out bool bClipLowerZ, out double dLowerZ, out bool bClipUpperZ, out double dUpperZ)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_get(swigCPtr, OdGePoint2dArray.getCPtr(points).Handle, out bClipLowerZ, out dLowerZ, out bClipUpperZ, out dUpperZ);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdDoubleArray deviations)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_setDeviation__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(deviations).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdGiDeviation pDeviation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_setDeviation__SWIG_1(swigCPtr, pDeviation.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDrawContext(OdGiConveyorContext pDrawCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_setDrawContext(swigCPtr, pDrawCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiOrthoClipper()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiOrthoClipper(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiOrthoClipper) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		if (SwigDerivedClassHasMethod("output", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodoutput;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodset__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodset__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodset__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodset__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodset__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodset__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodset__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodset__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodset__SWIG_8;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodset__SWIG_9;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodget;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetDeviation__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetDeviation__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setDrawContext", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetDrawContext;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiOrthoClipper_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiOrthoClipper));
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

	private IntPtr SwigDirectorMethodoutput()
	{
		return output().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodset__SWIG_0(IntPtr nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		try
		{
			set(Helpers.UnMarshalPoint2dArray(nPoints), bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
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

	private void SwigDirectorMethodset__SWIG_1(IntPtr nPoints, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		try
		{
			set(Helpers.UnMarshalPoint2dArray(nPoints), bClipLowerZ, dLowerZ, bClipUpperZ);
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

	private void SwigDirectorMethodset__SWIG_2(IntPtr nPoints, bool bClipLowerZ, double dLowerZ)
	{
		try
		{
			set(Helpers.UnMarshalPoint2dArray(nPoints), bClipLowerZ, dLowerZ);
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

	private void SwigDirectorMethodset__SWIG_3(IntPtr nPoints, bool bClipLowerZ)
	{
		try
		{
			set(Helpers.UnMarshalPoint2dArray(nPoints), bClipLowerZ);
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

	private void SwigDirectorMethodset__SWIG_4(IntPtr nPoints)
	{
		try
		{
			set(Helpers.UnMarshalPoint2dArray(nPoints));
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

	private void SwigDirectorMethodset__SWIG_5(IntPtr points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		try
		{
			set(new OdGePoint2dArray(points, cMemoryOwn: true), bClipLowerZ, dLowerZ, bClipUpperZ, dUpperZ);
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

	private void SwigDirectorMethodset__SWIG_6(IntPtr points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ)
	{
		try
		{
			set(new OdGePoint2dArray(points, cMemoryOwn: true), bClipLowerZ, dLowerZ, bClipUpperZ);
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

	private void SwigDirectorMethodset__SWIG_7(IntPtr points, bool bClipLowerZ, double dLowerZ)
	{
		try
		{
			set(new OdGePoint2dArray(points, cMemoryOwn: true), bClipLowerZ, dLowerZ);
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

	private void SwigDirectorMethodset__SWIG_8(IntPtr points, bool bClipLowerZ)
	{
		try
		{
			set(new OdGePoint2dArray(points, cMemoryOwn: true), bClipLowerZ);
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

	private void SwigDirectorMethodset__SWIG_9(IntPtr points)
	{
		try
		{
			set(new OdGePoint2dArray(points, cMemoryOwn: true));
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

	private void SwigDirectorMethodget(IntPtr points, bool bClipLowerZ, double dLowerZ, bool bClipUpperZ, double dUpperZ)
	{
		try
		{
			get(new OdGePoint2dArray(points, cMemoryOwn: true), out bClipLowerZ, out dLowerZ, out bClipUpperZ, out dUpperZ);
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
}
