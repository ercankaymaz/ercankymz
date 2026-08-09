using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseHatchPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbBaseHatchPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBaseHatchPE_1();

	public delegate void SwigDelegateOdDbBaseHatchPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbBaseHatchPE_3(IntPtr pHatch);

	public delegate int SwigDelegateOdDbBaseHatchPE_4(IntPtr pHatch, int loopIndex);

	public delegate void SwigDelegateOdDbBaseHatchPE_5(IntPtr arg0, int loopIndex, IntPtr edgePtrs);

	public delegate void SwigDelegateOdDbBaseHatchPE_6(IntPtr arg0, int loopIndex, IntPtr vertices, IntPtr bulges);

	public delegate int SwigDelegateOdDbBaseHatchPE_7(IntPtr pHatch);

	public delegate bool SwigDelegateOdDbBaseHatchPE_8(IntPtr pHatch);

	public delegate bool SwigDelegateOdDbBaseHatchPE_9(IntPtr pHatch);

	public delegate bool SwigDelegateOdDbBaseHatchPE_10(IntPtr pHatch);

	public delegate bool SwigDelegateOdDbBaseHatchPE_11(IntPtr pHatch);

	public delegate bool SwigDelegateOdDbBaseHatchPE_12(IntPtr pHatch);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBaseHatchPE_0 swigDelegate0;

	private SwigDelegateOdDbBaseHatchPE_1 swigDelegate1;

	private SwigDelegateOdDbBaseHatchPE_2 swigDelegate2;

	private SwigDelegateOdDbBaseHatchPE_3 swigDelegate3;

	private SwigDelegateOdDbBaseHatchPE_4 swigDelegate4;

	private SwigDelegateOdDbBaseHatchPE_5 swigDelegate5;

	private SwigDelegateOdDbBaseHatchPE_6 swigDelegate6;

	private SwigDelegateOdDbBaseHatchPE_7 swigDelegate7;

	private SwigDelegateOdDbBaseHatchPE_8 swigDelegate8;

	private SwigDelegateOdDbBaseHatchPE_9 swigDelegate9;

	private SwigDelegateOdDbBaseHatchPE_10 swigDelegate10;

	private SwigDelegateOdDbBaseHatchPE_11 swigDelegate11;

	private SwigDelegateOdDbBaseHatchPE_12 swigDelegate12;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(int)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(int),
		typeof(OdArray_OdGeCurve2d__p_OdObjectsAllocator)
	};

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(OdRxObject),
		typeof(int),
		typeof(OdGePoint2dArray),
		typeof(OdDoubleArray)
	};

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseHatchPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseHatchPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseHatchPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBaseHatchPE cast(OdRxObject pObj)
	{
		OdDbBaseHatchPE rXObject = Helpers.GetRXObject<OdDbBaseHatchPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_isASwigExplicitOdDbBaseHatchPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_queryXSwigExplicitOdDbBaseHatchPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseHatchPE createObject()
	{
		OdDbBaseHatchPE rXObject = Helpers.GetRXObject<OdDbBaseHatchPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int numLoops(OdRxObject pHatch)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_numLoops(swigCPtr, OdRxObject.getCPtr(pHatch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int loopTypeAt(OdRxObject pHatch, int loopIndex)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_loopTypeAt(swigCPtr, OdRxObject.getCPtr(pHatch), loopIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getLoopAt(OdRxObject arg0, int loopIndex, OdArray_OdGeCurve2d__p_OdObjectsAllocator edgePtrs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_getLoopAt__SWIG_0(swigCPtr, OdRxObject.getCPtr(arg0), loopIndex, OdArray_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(edgePtrs));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getLoopAt(OdRxObject arg0, int loopIndex, OdGePoint2dArray vertices, OdDoubleArray bulges)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_getLoopAt__SWIG_1(swigCPtr, OdRxObject.getCPtr(arg0), loopIndex, OdGePoint2dArray.getCPtr(vertices).Handle, OdDoubleArray.getCPtr(bulges).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbBaseHatchPE_HatchStyle hatchStyle(OdRxObject pHatch)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_hatchStyle(swigCPtr, OdRxObject.getCPtr(pHatch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbBaseHatchPE_HatchStyle)result;
	}

	public virtual bool isGradient(OdRxObject pHatch)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_isGradient(swigCPtr, OdRxObject.getCPtr(pHatch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isSolidFill(OdRxObject pHatch)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_isSolidFill(swigCPtr, OdRxObject.getCPtr(pHatch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasBackgroundColor(OdRxObject pHatch)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_hasBackgroundColor(swigCPtr, OdRxObject.getCPtr(pHatch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isReallyHatch(OdRxObject pHatch)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_isReallyHatch(swigCPtr, OdRxObject.getCPtr(pHatch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isTooDense(OdRxObject pHatch)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_isTooDense(swigCPtr, OdRxObject.getCPtr(pHatch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBaseHatchPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseHatchPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBaseHatchPE) != GetType();
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
		if (SwigDerivedClassHasMethod("numLoops", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodnumLoops;
		}
		if (SwigDerivedClassHasMethod("loopTypeAt", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodloopTypeAt;
		}
		if (SwigDerivedClassHasMethod("getLoopAt", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetLoopAt__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getLoopAt", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetLoopAt__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("hatchStyle", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodhatchStyle;
		}
		if (SwigDerivedClassHasMethod("isGradient", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodisGradient;
		}
		if (SwigDerivedClassHasMethod("isSolidFill", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodisSolidFill;
		}
		if (SwigDerivedClassHasMethod("hasBackgroundColor", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodhasBackgroundColor;
		}
		if (SwigDerivedClassHasMethod("isReallyHatch", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodisReallyHatch;
		}
		if (SwigDerivedClassHasMethod("isTooDense", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodisTooDense;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseHatchPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBaseHatchPE));
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

	private int SwigDirectorMethodnumLoops(IntPtr pHatch)
	{
		return numLoops(Helpers.GetRXObject<OdRxObject>(pHatch, bOwn: true, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodloopTypeAt(IntPtr pHatch, int loopIndex)
	{
		return loopTypeAt(Helpers.GetRXObject<OdRxObject>(pHatch, bOwn: true, bTryAddToTransaction: false), loopIndex);
	}

	private void SwigDirectorMethodgetLoopAt__SWIG_0(IntPtr arg0, int loopIndex, IntPtr edgePtrs)
	{
		try
		{
			getLoopAt(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: true, bTryAddToTransaction: false), loopIndex, new OdArray_OdGeCurve2d__p_OdObjectsAllocator(edgePtrs, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetLoopAt__SWIG_1(IntPtr arg0, int loopIndex, IntPtr vertices, IntPtr bulges)
	{
		try
		{
			getLoopAt(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: true, bTryAddToTransaction: false), loopIndex, new OdGePoint2dArray(vertices, cMemoryOwn: true), new OdDoubleArray(bulges, cMemoryOwn: true));
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

	private int SwigDirectorMethodhatchStyle(IntPtr pHatch)
	{
		return (int)hatchStyle(Helpers.GetRXObject<OdRxObject>(pHatch, bOwn: true, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisGradient(IntPtr pHatch)
	{
		return isGradient(Helpers.GetRXObject<OdRxObject>(pHatch, bOwn: true, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisSolidFill(IntPtr pHatch)
	{
		return isSolidFill(Helpers.GetRXObject<OdRxObject>(pHatch, bOwn: true, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodhasBackgroundColor(IntPtr pHatch)
	{
		return hasBackgroundColor(Helpers.GetRXObject<OdRxObject>(pHatch, bOwn: true, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisReallyHatch(IntPtr pHatch)
	{
		return isReallyHatch(Helpers.GetRXObject<OdRxObject>(pHatch, bOwn: true, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisTooDense(IntPtr pHatch)
	{
		return isTooDense(Helpers.GetRXObject<OdRxObject>(pHatch, bOwn: true, bTryAddToTransaction: false));
	}
}
