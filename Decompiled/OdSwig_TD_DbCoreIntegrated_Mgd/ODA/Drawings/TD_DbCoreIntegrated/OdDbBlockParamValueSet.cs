using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbBlockParamValueSet : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbBlockParamValueSet_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBlockParamValueSet_1();

	public delegate void SwigDelegateOdDbBlockParamValueSet_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbBlockParamValueSet_3(double value, double initial);

	public delegate bool SwigDelegateOdDbBlockParamValueSet_4(double value);

	public delegate double SwigDelegateOdDbBlockParamValueSet_5(double value, double initial);

	public delegate double SwigDelegateOdDbBlockParamValueSet_6(double value);

	public delegate void SwigDelegateOdDbBlockParamValueSet_7(IntPtr pFiler);

	public delegate void SwigDelegateOdDbBlockParamValueSet_8(IntPtr pFiler);

	public delegate void SwigDelegateOdDbBlockParamValueSet_9(IntPtr pFiler, short arg1, short arg2, short arg3, short arg4);

	public delegate void SwigDelegateOdDbBlockParamValueSet_10(IntPtr pFiler, short arg1, short arg2, short arg3, short arg4);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBlockParamValueSet_0 swigDelegate0;

	private SwigDelegateOdDbBlockParamValueSet_1 swigDelegate1;

	private SwigDelegateOdDbBlockParamValueSet_2 swigDelegate2;

	private SwigDelegateOdDbBlockParamValueSet_3 swigDelegate3;

	private SwigDelegateOdDbBlockParamValueSet_4 swigDelegate4;

	private SwigDelegateOdDbBlockParamValueSet_5 swigDelegate5;

	private SwigDelegateOdDbBlockParamValueSet_6 swigDelegate6;

	private SwigDelegateOdDbBlockParamValueSet_7 swigDelegate7;

	private SwigDelegateOdDbBlockParamValueSet_8 swigDelegate8;

	private SwigDelegateOdDbBlockParamValueSet_9 swigDelegate9;

	private SwigDelegateOdDbBlockParamValueSet_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbDwgFiler) };

	private static Type[] swigMethodTypes9 = new Type[5]
	{
		typeof(OdDbDxfFiler),
		typeof(short),
		typeof(short),
		typeof(short),
		typeof(short)
	};

	private static Type[] swigMethodTypes10 = new Type[5]
	{
		typeof(OdDbDxfFiler),
		typeof(short),
		typeof(short),
		typeof(short),
		typeof(short)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBlockParamValueSet(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBlockParamValueSet obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbBlockParamValueSet(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBlockParamValueSet cast(OdRxObject pObj)
	{
		OdDbBlockParamValueSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockParamValueSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_isASwigExplicitOdDbBlockParamValueSet(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_queryXSwigExplicitOdDbBlockParamValueSet(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbBlockParamValueSet()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBlockParamValueSet__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBlockParamValueSet) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDbBlockParamValueSet(OdDbBlockParamValueSet arg0)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbBlockParamValueSet__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBlockParamValueSet) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDbBlockParamValueSet Assign(OdDbBlockParamValueSet arg0)
	{
		OdDbBlockParamValueSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockParamValueSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_Assign(swigCPtr, getCPtr(arg0)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void assign(OdDbBlockParamValueSet vs)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_assign(swigCPtr, getCPtr(vs));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool angDir()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_angDir(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAngDir(bool arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setAngDir(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool angular()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_angular(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAngular(bool arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setAngular(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double maximum()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_maximum(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMaximum(double value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setMaximum__SWIG_0(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMaximum(double value, bool useMaximum)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setMaximum__SWIG_1(swigCPtr, value, useMaximum);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool useMaximum()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_useMaximum(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUseMaximum(bool u)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setUseMaximum(swigCPtr, u);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double minimum()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_minimum(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMinimum(double value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setMinimum__SWIG_0(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setMinimum(double value, bool useMinimum)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setMinimum__SWIG_1(swigCPtr, value, useMinimum);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool useMinimum()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_useMinimum(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUseMinimum(bool u)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setUseMinimum(swigCPtr, u);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double increment()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_increment(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIncrement(double value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setIncrement__SWIG_0(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIncrement(double value, bool useIncrement)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setIncrement__SWIG_1(swigCPtr, value, useIncrement);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool useIncrement()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_useIncrement(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUseIncrement(bool u)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setUseIncrement(swigCPtr, u);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool useValueList()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_useValueList(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUseValueList(bool arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setUseValueList(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDoubleArray valueList()
	{
		OdDoubleArray result = new OdDoubleArray(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_valueList(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setValueList(OdDoubleArray l)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setValueList__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(l).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setValueList(OdDoubleArray l, bool useValueList)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_setValueList__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(l).Handle, useValueList);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool valueIsLegal(double value, double initial)
	{
		bool result = (SwigDerivedClassHasMethod("valueIsLegal", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_valueIsLegalSwigExplicitOdDbBlockParamValueSet__SWIG_0(swigCPtr, value, initial) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_valueIsLegal__SWIG_0(swigCPtr, value, initial));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool valueIsLegal(double value)
	{
		bool result = (SwigDerivedClassHasMethod("valueIsLegal", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_valueIsLegalSwigExplicitOdDbBlockParamValueSet__SWIG_1(swigCPtr, value) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_valueIsLegal__SWIG_1(swigCPtr, value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double closestLegalValue(double value, double initial)
	{
		double result = (SwigDerivedClassHasMethod("closestLegalValue", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_closestLegalValueSwigExplicitOdDbBlockParamValueSet__SWIG_0(swigCPtr, value, initial) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_closestLegalValue__SWIG_0(swigCPtr, value, initial));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double closestLegalValue(double value)
	{
		double result = (SwigDerivedClassHasMethod("closestLegalValue", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_closestLegalValueSwigExplicitOdDbBlockParamValueSet__SWIG_1(swigCPtr, value) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_closestLegalValue__SWIG_1(swigCPtr, value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDoubleArray sortedValueListIncluding(double value)
	{
		OdDoubleArray result = new OdDoubleArray(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_sortedValueListIncluding(swigCPtr, value), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void updateValue(double value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_updateValue(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void dwgInFieldsHelper(OdDbDwgFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dwgInFieldsHelper", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_dwgInFieldsHelperSwigExplicitOdDbBlockParamValueSet(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_dwgInFieldsHelper(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void dwgOutFieldsHelper(OdDbDwgFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("dwgOutFieldsHelper", swigMethodTypes8))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_dwgOutFieldsHelperSwigExplicitOdDbBlockParamValueSet(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_dwgOutFieldsHelper(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void dxfInFieldsHelper(OdDbDxfFiler pFiler, short arg1, short arg2, short arg3, short arg4)
	{
		if (SwigDerivedClassHasMethod("dxfInFieldsHelper", swigMethodTypes9))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_dxfInFieldsHelperSwigExplicitOdDbBlockParamValueSet(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), arg1, arg2, arg3, arg4);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_dxfInFieldsHelper(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), arg1, arg2, arg3, arg4);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void dxfOutFieldsHelper(OdDbDxfFiler pFiler, short arg1, short arg2, short arg3, short arg4)
	{
		if (SwigDerivedClassHasMethod("dxfOutFieldsHelper", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_dxfOutFieldsHelperSwigExplicitOdDbBlockParamValueSet(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), arg1, arg2, arg3, arg4);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_dxfOutFieldsHelper(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), arg1, arg2, arg3, arg4);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbBlockParamValueSet createObject()
	{
		OdDbBlockParamValueSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockParamValueSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("valueIsLegal", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodvalueIsLegal__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("valueIsLegal", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodvalueIsLegal__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("closestLegalValue", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodclosestLegalValue__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("closestLegalValue", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodclosestLegalValue__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("dwgInFieldsHelper", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddwgInFieldsHelper;
		}
		if (SwigDerivedClassHasMethod("dwgOutFieldsHelper", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddwgOutFieldsHelper;
		}
		if (SwigDerivedClassHasMethod("dxfInFieldsHelper", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethoddxfInFieldsHelper;
		}
		if (SwigDerivedClassHasMethod("dxfOutFieldsHelper", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethoddxfOutFieldsHelper;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockParamValueSet_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBlockParamValueSet));
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

	private bool SwigDirectorMethodvalueIsLegal__SWIG_0(double value, double initial)
	{
		return valueIsLegal(value, initial);
	}

	private bool SwigDirectorMethodvalueIsLegal__SWIG_1(double value)
	{
		return valueIsLegal(value);
	}

	private double SwigDirectorMethodclosestLegalValue__SWIG_0(double value, double initial)
	{
		return closestLegalValue(value, initial);
	}

	private double SwigDirectorMethodclosestLegalValue__SWIG_1(double value)
	{
		return closestLegalValue(value);
	}

	private void SwigDirectorMethoddwgInFieldsHelper(IntPtr pFiler)
	{
		try
		{
			dwgInFieldsHelper(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethoddwgOutFieldsHelper(IntPtr pFiler)
	{
		try
		{
			dwgOutFieldsHelper(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethoddxfInFieldsHelper(IntPtr pFiler, short arg1, short arg2, short arg3, short arg4)
	{
		try
		{
			dxfInFieldsHelper(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false), arg1, arg2, arg3, arg4);
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

	private void SwigDirectorMethoddxfOutFieldsHelper(IntPtr pFiler, short arg1, short arg2, short arg3, short arg4)
	{
		try
		{
			dxfOutFieldsHelper(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false), arg1, arg2, arg3, arg4);
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
