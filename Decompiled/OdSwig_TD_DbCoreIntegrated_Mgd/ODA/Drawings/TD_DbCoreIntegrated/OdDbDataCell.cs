using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDataCell : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbDataCell_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbDataCell_1();

	public delegate void SwigDelegateOdDbDataCell_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbDataCell_3();

	public delegate void SwigDelegateOdDbDataCell_4(IntPtr cell);

	public delegate void SwigDelegateOdDbDataCell_5(bool b);

	public delegate void SwigDelegateOdDbDataCell_6(int i);

	public delegate void SwigDelegateOdDbDataCell_7(double d);

	public delegate void SwigDelegateOdDbDataCell_8([MarshalAs(UnmanagedType.LPWStr)] string str);

	public delegate void SwigDelegateOdDbDataCell_9(IntPtr pt);

	public delegate void SwigDelegateOdDbDataCell_10(IntPtr vec);

	public delegate void SwigDelegateOdDbDataCell_11(IntPtr id);

	public delegate void SwigDelegateOdDbDataCell_12(IntPtr id);

	public delegate void SwigDelegateOdDbDataCell_13(IntPtr id);

	public delegate void SwigDelegateOdDbDataCell_14(IntPtr id);

	public delegate void SwigDelegateOdDbDataCell_15(IntPtr id);

	public delegate void SwigDelegateOdDbDataCell_16(IntPtr cell);

	public delegate void SwigDelegateOdDbDataCell_17(bool b);

	public delegate void SwigDelegateOdDbDataCell_18(int i);

	public delegate void SwigDelegateOdDbDataCell_19(double d);

	public delegate void SwigDelegateOdDbDataCell_20(IntPtr str);

	public delegate void SwigDelegateOdDbDataCell_21(IntPtr pt);

	public delegate void SwigDelegateOdDbDataCell_22(IntPtr vec);

	public delegate void SwigDelegateOdDbDataCell_23(IntPtr id);

	public delegate void SwigDelegateOdDbDataCell_24(IntPtr id);

	public delegate void SwigDelegateOdDbDataCell_25(IntPtr id);

	public delegate void SwigDelegateOdDbDataCell_26(IntPtr id);

	public delegate void SwigDelegateOdDbDataCell_27(IntPtr id);

	public delegate int SwigDelegateOdDbDataCell_28();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbDataCell_0 swigDelegate0;

	private SwigDelegateOdDbDataCell_1 swigDelegate1;

	private SwigDelegateOdDbDataCell_2 swigDelegate2;

	private SwigDelegateOdDbDataCell_3 swigDelegate3;

	private SwigDelegateOdDbDataCell_4 swigDelegate4;

	private SwigDelegateOdDbDataCell_5 swigDelegate5;

	private SwigDelegateOdDbDataCell_6 swigDelegate6;

	private SwigDelegateOdDbDataCell_7 swigDelegate7;

	private SwigDelegateOdDbDataCell_8 swigDelegate8;

	private SwigDelegateOdDbDataCell_9 swigDelegate9;

	private SwigDelegateOdDbDataCell_10 swigDelegate10;

	private SwigDelegateOdDbDataCell_11 swigDelegate11;

	private SwigDelegateOdDbDataCell_12 swigDelegate12;

	private SwigDelegateOdDbDataCell_13 swigDelegate13;

	private SwigDelegateOdDbDataCell_14 swigDelegate14;

	private SwigDelegateOdDbDataCell_15 swigDelegate15;

	private SwigDelegateOdDbDataCell_16 swigDelegate16;

	private SwigDelegateOdDbDataCell_17 swigDelegate17;

	private SwigDelegateOdDbDataCell_18 swigDelegate18;

	private SwigDelegateOdDbDataCell_19 swigDelegate19;

	private SwigDelegateOdDbDataCell_20 swigDelegate20;

	private SwigDelegateOdDbDataCell_21 swigDelegate21;

	private SwigDelegateOdDbDataCell_22 swigDelegate22;

	private SwigDelegateOdDbDataCell_23 swigDelegate23;

	private SwigDelegateOdDbDataCell_24 swigDelegate24;

	private SwigDelegateOdDbDataCell_25 swigDelegate25;

	private SwigDelegateOdDbDataCell_26 swigDelegate26;

	private SwigDelegateOdDbDataCell_27 swigDelegate27;

	private SwigDelegateOdDbDataCell_28 swigDelegate28;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbDataCell) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdDbHardOwnershipId) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdDbSoftOwnershipId) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbHardPointerId) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDbSoftPointerId) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbDataCell).MakeByRefType() };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(bool).MakeByRefType() };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(int).MakeByRefType() };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(double).MakeByRefType() };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(string).MakeByRefType() };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdDbHardOwnershipId) };

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(OdDbSoftOwnershipId) };

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdDbHardPointerId) };

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(OdDbSoftPointerId) };

	private static Type[] swigMethodTypes28 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDataCell(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDataCell obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDataCell(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbDataCell cast(OdRxObject pObj)
	{
		OdDbDataCell rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataCell>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_isASwigExplicitOdDbDataCell(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_queryXSwigExplicitOdDbDataCell(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbDataCell()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDataCell(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbDataCell) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual void init()
	{
		if (SwigDerivedClassHasMethod("init", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_initSwigExplicitOdDbDataCell(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_init(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdDbDataCell cell)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_0(swigCPtr, getCPtr(cell));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_0(swigCPtr, getCPtr(cell));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(bool b)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_1(swigCPtr, b);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_1(swigCPtr, b);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(int i)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes6))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_2(swigCPtr, i);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_2(swigCPtr, i);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(double d)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_3(swigCPtr, d);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_3(swigCPtr, d);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(string str)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes8))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_4(swigCPtr, str);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_4(swigCPtr, str);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGePoint3d pt)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes9))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_5(swigCPtr, OdGePoint3d.getCPtr(pt));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_5(swigCPtr, OdGePoint3d.getCPtr(pt));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdGeVector3d vec)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_6(swigCPtr, OdGeVector3d.getCPtr(vec));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_6(swigCPtr, OdGeVector3d.getCPtr(vec));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdDbObjectId id)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes11))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_7(swigCPtr, OdDbObjectId.getCPtr(id));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_7(swigCPtr, OdDbObjectId.getCPtr(id));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdDbHardOwnershipId id)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_8(swigCPtr, OdDbHardOwnershipId.getCPtr(id));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_8(swigCPtr, OdDbHardOwnershipId.getCPtr(id));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdDbSoftOwnershipId id)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes13))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_9(swigCPtr, OdDbSoftOwnershipId.getCPtr(id));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_9(swigCPtr, OdDbSoftOwnershipId.getCPtr(id));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdDbHardPointerId id)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes14))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_10(swigCPtr, OdDbHardPointerId.getCPtr(id));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_10(swigCPtr, OdDbHardPointerId.getCPtr(id));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set(OdDbSoftPointerId id)
	{
		if (SwigDerivedClassHasMethod("set", swigMethodTypes15))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_setSwigExplicitOdDbDataCell__SWIG_11(swigCPtr, OdDbSoftPointerId.getCPtr(id));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_set__SWIG_11(swigCPtr, OdDbSoftPointerId.getCPtr(id));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(ref OdDbDataCell cell)
	{
		IntPtr jarg = ((cell == null) ? IntPtr.Zero : getCPtr(cell).Handle);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("get", swigMethodTypes16))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_0(swigCPtr, ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_0(swigCPtr, ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				cell = null;
			}
			if (jarg != intPtr)
			{
				cell = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataCell>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void get(out bool b)
	{
		if (SwigDerivedClassHasMethod("get", swigMethodTypes17))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_1(swigCPtr, out b);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_1(swigCPtr, out b);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(out int i)
	{
		if (SwigDerivedClassHasMethod("get", swigMethodTypes18))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_2(swigCPtr, out i);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_2(swigCPtr, out i);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(out double d)
	{
		if (SwigDerivedClassHasMethod("get", swigMethodTypes19))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_3(swigCPtr, out d);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_3(swigCPtr, out d);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(ref string str)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(str);
		IntPtr intPtr = jarg;
		try
		{
			if (SwigDerivedClassHasMethod("get", swigMethodTypes20))
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_4(swigCPtr, ref jarg);
			}
			else
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_4(swigCPtr, ref jarg);
			}
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				str = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual void get(OdGePoint3d pt)
	{
		if (SwigDerivedClassHasMethod("get", swigMethodTypes21))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_5(swigCPtr, OdGePoint3d.getCPtr(pt));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_5(swigCPtr, OdGePoint3d.getCPtr(pt));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdGeVector3d vec)
	{
		if (SwigDerivedClassHasMethod("get", swigMethodTypes22))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_6(swigCPtr, OdGeVector3d.getCPtr(vec));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_6(swigCPtr, OdGeVector3d.getCPtr(vec));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdDbObjectId id)
	{
		if (SwigDerivedClassHasMethod("get", swigMethodTypes23))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_7(swigCPtr, OdDbObjectId.getCPtr(id));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_7(swigCPtr, OdDbObjectId.getCPtr(id));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdDbHardOwnershipId id)
	{
		if (SwigDerivedClassHasMethod("get", swigMethodTypes24))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_8(swigCPtr, OdDbHardOwnershipId.getCPtr(id));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_8(swigCPtr, OdDbHardOwnershipId.getCPtr(id));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdDbSoftOwnershipId id)
	{
		if (SwigDerivedClassHasMethod("get", swigMethodTypes25))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_9(swigCPtr, OdDbSoftOwnershipId.getCPtr(id));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_9(swigCPtr, OdDbSoftOwnershipId.getCPtr(id));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdDbHardPointerId id)
	{
		if (SwigDerivedClassHasMethod("get", swigMethodTypes26))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_10(swigCPtr, OdDbHardPointerId.getCPtr(id));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_10(swigCPtr, OdDbHardPointerId.getCPtr(id));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void get(OdDbSoftPointerId id)
	{
		if (SwigDerivedClassHasMethod("get", swigMethodTypes27))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getSwigExplicitOdDbDataCell__SWIG_11(swigCPtr, OdDbSoftPointerId.getCPtr(id));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_get__SWIG_11(swigCPtr, OdDbSoftPointerId.getCPtr(id));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbDataCell_CellType type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes28) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_typeSwigExplicitOdDbDataCell(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_type(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbDataCell_CellType)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbDataCell createObject()
	{
		OdDbDataCell rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataCell>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("init", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinit;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodset__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodset__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodset__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodset__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodset__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodset__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodset__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodset__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodset__SWIG_8;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodset__SWIG_9;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodset__SWIG_10;
		}
		if (SwigDerivedClassHasMethod("set", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodset__SWIG_11;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodget__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodget__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodget__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodget__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodget__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodget__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodget__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodget__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodget__SWIG_8;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodget__SWIG_9;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodget__SWIG_10;
		}
		if (SwigDerivedClassHasMethod("get", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodget__SWIG_11;
		}
		if (SwigDerivedClassHasMethod("type", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodtype;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCell_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbDataCell));
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

	private void SwigDirectorMethodinit()
	{
		try
		{
			init();
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

	private void SwigDirectorMethodset__SWIG_0(IntPtr cell)
	{
		try
		{
			set(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataCell>(cell, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodset__SWIG_1(bool b)
	{
		try
		{
			set(b);
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

	private void SwigDirectorMethodset__SWIG_2(int i)
	{
		try
		{
			set(i);
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

	private void SwigDirectorMethodset__SWIG_3(double d)
	{
		try
		{
			set(d);
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

	private void SwigDirectorMethodset__SWIG_4([MarshalAs(UnmanagedType.LPWStr)] string str)
	{
		try
		{
			set(str);
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

	private void SwigDirectorMethodset__SWIG_5(IntPtr pt)
	{
		try
		{
			set(new OdGePoint3d(pt, cMemoryOwn: false));
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

	private void SwigDirectorMethodset__SWIG_6(IntPtr vec)
	{
		try
		{
			set(new OdGeVector3d(vec, cMemoryOwn: false));
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

	private void SwigDirectorMethodset__SWIG_7(IntPtr id)
	{
		try
		{
			set(new OdDbObjectId(id, cMemoryOwn: false));
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

	private void SwigDirectorMethodset__SWIG_8(IntPtr id)
	{
		try
		{
			set(new OdDbHardOwnershipId(id, cMemoryOwn: false));
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

	private void SwigDirectorMethodset__SWIG_9(IntPtr id)
	{
		try
		{
			set(new OdDbSoftOwnershipId(id, cMemoryOwn: false));
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

	private void SwigDirectorMethodset__SWIG_10(IntPtr id)
	{
		try
		{
			set(new OdDbHardPointerId(id, cMemoryOwn: false));
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

	private void SwigDirectorMethodset__SWIG_11(IntPtr id)
	{
		try
		{
			set(new OdDbSoftPointerId(id, cMemoryOwn: false));
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

	private void SwigDirectorMethodget__SWIG_0(IntPtr cell)
	{
		OdSwigDirectorHelper.director_UnpackData(cell, out var pOriginalObject, out var pFunction);
		OdDbDataCell cell2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataCell>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			get(ref cell2);
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
			IntPtr handle = getCPtr(cell2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(cell);
		}
	}

	private void SwigDirectorMethodget__SWIG_1(bool b)
	{
		try
		{
			get(out b);
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

	private void SwigDirectorMethodget__SWIG_2(int i)
	{
		try
		{
			get(out i);
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

	private void SwigDirectorMethodget__SWIG_3(double d)
	{
		try
		{
			get(out d);
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

	private void SwigDirectorMethodget__SWIG_4(IntPtr str)
	{
		OdSwigDirectorHelper.director_UnpackData(str, out var pOriginalObject, out var pFunction);
		string str2 = Marshal.PtrToStringUni(pOriginalObject);
		string text = str2;
		try
		{
			get(ref str2);
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
			if (str2 != text)
			{
				IntPtr intPtr = Marshal.StringToCoTaskMemUni(str2);
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, intPtr);
				Marshal.FreeCoTaskMem(intPtr);
			}
			OdSwigDirectorHelper.director_freeData(str);
		}
	}

	private void SwigDirectorMethodget__SWIG_5(IntPtr pt)
	{
		try
		{
			get(new OdGePoint3d(pt, cMemoryOwn: false));
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

	private void SwigDirectorMethodget__SWIG_6(IntPtr vec)
	{
		try
		{
			get(new OdGeVector3d(vec, cMemoryOwn: false));
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

	private void SwigDirectorMethodget__SWIG_7(IntPtr id)
	{
		try
		{
			get(new OdDbObjectId(id, cMemoryOwn: false));
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

	private void SwigDirectorMethodget__SWIG_8(IntPtr id)
	{
		try
		{
			get(new OdDbHardOwnershipId(id, cMemoryOwn: false));
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

	private void SwigDirectorMethodget__SWIG_9(IntPtr id)
	{
		try
		{
			get(new OdDbSoftOwnershipId(id, cMemoryOwn: false));
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

	private void SwigDirectorMethodget__SWIG_10(IntPtr id)
	{
		try
		{
			get(new OdDbHardPointerId(id, cMemoryOwn: false));
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

	private void SwigDirectorMethodget__SWIG_11(IntPtr id)
	{
		try
		{
			get(new OdDbSoftPointerId(id, cMemoryOwn: false));
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

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}
}
