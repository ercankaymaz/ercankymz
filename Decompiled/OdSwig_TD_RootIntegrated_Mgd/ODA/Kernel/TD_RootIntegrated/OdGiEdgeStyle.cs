using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiEdgeStyle : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiEdgeStyle_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiEdgeStyle_1();

	public delegate void SwigDelegateOdGiEdgeStyle_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiEdgeStyle_3(int model);

	public delegate int SwigDelegateOdGiEdgeStyle_4();

	public delegate void SwigDelegateOdGiEdgeStyle_5(uint nStyles);

	public delegate void SwigDelegateOdGiEdgeStyle_6(int flag, bool bEnable);

	public delegate uint SwigDelegateOdGiEdgeStyle_7();

	public delegate bool SwigDelegateOdGiEdgeStyle_8(int flag);

	public delegate void SwigDelegateOdGiEdgeStyle_9(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiEdgeStyle_10();

	public delegate IntPtr SwigDelegateOdGiEdgeStyle_11();

	public delegate void SwigDelegateOdGiEdgeStyle_12(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiEdgeStyle_13();

	public delegate IntPtr SwigDelegateOdGiEdgeStyle_14();

	public delegate void SwigDelegateOdGiEdgeStyle_15(int ltype);

	public delegate int SwigDelegateOdGiEdgeStyle_16();

	public delegate void SwigDelegateOdGiEdgeStyle_17(int ltype);

	public delegate int SwigDelegateOdGiEdgeStyle_18();

	public delegate void SwigDelegateOdGiEdgeStyle_19(double nAngle);

	public delegate double SwigDelegateOdGiEdgeStyle_20();

	public delegate void SwigDelegateOdGiEdgeStyle_21(uint nModifiers);

	public delegate void SwigDelegateOdGiEdgeStyle_22(int flag, bool bEnable);

	public delegate uint SwigDelegateOdGiEdgeStyle_23();

	public delegate bool SwigDelegateOdGiEdgeStyle_24(int flag);

	public delegate void SwigDelegateOdGiEdgeStyle_25(IntPtr color, bool bEnableModifier);

	public delegate IntPtr SwigDelegateOdGiEdgeStyle_26();

	public delegate IntPtr SwigDelegateOdGiEdgeStyle_27();

	public delegate void SwigDelegateOdGiEdgeStyle_28(double nLevel, bool bEnableModifier);

	public delegate double SwigDelegateOdGiEdgeStyle_29();

	public delegate void SwigDelegateOdGiEdgeStyle_30(int nWidth, bool bEnableModifier);

	public delegate int SwigDelegateOdGiEdgeStyle_31();

	public delegate void SwigDelegateOdGiEdgeStyle_32(int nAmount, bool bEnableModifier);

	public delegate int SwigDelegateOdGiEdgeStyle_33();

	public delegate void SwigDelegateOdGiEdgeStyle_34(int amount, bool bEnableModifier);

	public delegate int SwigDelegateOdGiEdgeStyle_35();

	public delegate void SwigDelegateOdGiEdgeStyle_36(int amount, bool bEnableModifier);

	public delegate int SwigDelegateOdGiEdgeStyle_37();

	public delegate void SwigDelegateOdGiEdgeStyle_38(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiEdgeStyle_39();

	public delegate IntPtr SwigDelegateOdGiEdgeStyle_40();

	public delegate void SwigDelegateOdGiEdgeStyle_41(short nWidth);

	public delegate short SwigDelegateOdGiEdgeStyle_42();

	public delegate void SwigDelegateOdGiEdgeStyle_43(int nHaloGap, bool bEnableModifier);

	public delegate int SwigDelegateOdGiEdgeStyle_44();

	public delegate void SwigDelegateOdGiEdgeStyle_45(ushort nIsolines);

	public delegate ushort SwigDelegateOdGiEdgeStyle_46();

	public delegate void SwigDelegateOdGiEdgeStyle_47(bool bHidePrecision);

	public delegate bool SwigDelegateOdGiEdgeStyle_48();

	public delegate void SwigDelegateOdGiEdgeStyle_49(int apply);

	public delegate int SwigDelegateOdGiEdgeStyle_50();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiEdgeStyle_0 swigDelegate0;

	private SwigDelegateOdGiEdgeStyle_1 swigDelegate1;

	private SwigDelegateOdGiEdgeStyle_2 swigDelegate2;

	private SwigDelegateOdGiEdgeStyle_3 swigDelegate3;

	private SwigDelegateOdGiEdgeStyle_4 swigDelegate4;

	private SwigDelegateOdGiEdgeStyle_5 swigDelegate5;

	private SwigDelegateOdGiEdgeStyle_6 swigDelegate6;

	private SwigDelegateOdGiEdgeStyle_7 swigDelegate7;

	private SwigDelegateOdGiEdgeStyle_8 swigDelegate8;

	private SwigDelegateOdGiEdgeStyle_9 swigDelegate9;

	private SwigDelegateOdGiEdgeStyle_10 swigDelegate10;

	private SwigDelegateOdGiEdgeStyle_11 swigDelegate11;

	private SwigDelegateOdGiEdgeStyle_12 swigDelegate12;

	private SwigDelegateOdGiEdgeStyle_13 swigDelegate13;

	private SwigDelegateOdGiEdgeStyle_14 swigDelegate14;

	private SwigDelegateOdGiEdgeStyle_15 swigDelegate15;

	private SwigDelegateOdGiEdgeStyle_16 swigDelegate16;

	private SwigDelegateOdGiEdgeStyle_17 swigDelegate17;

	private SwigDelegateOdGiEdgeStyle_18 swigDelegate18;

	private SwigDelegateOdGiEdgeStyle_19 swigDelegate19;

	private SwigDelegateOdGiEdgeStyle_20 swigDelegate20;

	private SwigDelegateOdGiEdgeStyle_21 swigDelegate21;

	private SwigDelegateOdGiEdgeStyle_22 swigDelegate22;

	private SwigDelegateOdGiEdgeStyle_23 swigDelegate23;

	private SwigDelegateOdGiEdgeStyle_24 swigDelegate24;

	private SwigDelegateOdGiEdgeStyle_25 swigDelegate25;

	private SwigDelegateOdGiEdgeStyle_26 swigDelegate26;

	private SwigDelegateOdGiEdgeStyle_27 swigDelegate27;

	private SwigDelegateOdGiEdgeStyle_28 swigDelegate28;

	private SwigDelegateOdGiEdgeStyle_29 swigDelegate29;

	private SwigDelegateOdGiEdgeStyle_30 swigDelegate30;

	private SwigDelegateOdGiEdgeStyle_31 swigDelegate31;

	private SwigDelegateOdGiEdgeStyle_32 swigDelegate32;

	private SwigDelegateOdGiEdgeStyle_33 swigDelegate33;

	private SwigDelegateOdGiEdgeStyle_34 swigDelegate34;

	private SwigDelegateOdGiEdgeStyle_35 swigDelegate35;

	private SwigDelegateOdGiEdgeStyle_36 swigDelegate36;

	private SwigDelegateOdGiEdgeStyle_37 swigDelegate37;

	private SwigDelegateOdGiEdgeStyle_38 swigDelegate38;

	private SwigDelegateOdGiEdgeStyle_39 swigDelegate39;

	private SwigDelegateOdGiEdgeStyle_40 swigDelegate40;

	private SwigDelegateOdGiEdgeStyle_41 swigDelegate41;

	private SwigDelegateOdGiEdgeStyle_42 swigDelegate42;

	private SwigDelegateOdGiEdgeStyle_43 swigDelegate43;

	private SwigDelegateOdGiEdgeStyle_44 swigDelegate44;

	private SwigDelegateOdGiEdgeStyle_45 swigDelegate45;

	private SwigDelegateOdGiEdgeStyle_46 swigDelegate46;

	private SwigDelegateOdGiEdgeStyle_47 swigDelegate47;

	private SwigDelegateOdGiEdgeStyle_48 swigDelegate48;

	private SwigDelegateOdGiEdgeStyle_49 swigDelegate49;

	private SwigDelegateOdGiEdgeStyle_50 swigDelegate50;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiEdgeStyle_EdgeModel) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGiEdgeStyle_EdgeStyle),
		typeof(bool)
	};

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGiEdgeStyle_EdgeStyle) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdCmColorBase) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdCmColorBase) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdGiEdgeStyle_LineType) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGiEdgeStyle_LineType) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes22 = new Type[2]
	{
		typeof(OdGiEdgeStyle_EdgeModifier),
		typeof(bool)
	};

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGiEdgeStyle_EdgeModifier) };

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(OdCmColorBase),
		typeof(bool)
	};

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[2]
	{
		typeof(double),
		typeof(bool)
	};

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[2]
	{
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[2]
	{
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[2]
	{
		typeof(OdGiEdgeStyle_JitterAmount),
		typeof(bool)
	};

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[2]
	{
		typeof(OdGiEdgeStyle_WiggleAmount),
		typeof(bool)
	};

	private static Type[] swigMethodTypes37 = new Type[0];

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdCmColorBase) };

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[0];

	private static Type[] swigMethodTypes41 = new Type[1] { typeof(short) };

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[2]
	{
		typeof(int),
		typeof(bool)
	};

	private static Type[] swigMethodTypes44 = new Type[0];

	private static Type[] swigMethodTypes45 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(OdGiEdgeStyle_EdgeStyleApply) };

	private static Type[] swigMethodTypes50 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiEdgeStyle(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiEdgeStyle obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiEdgeStyle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiEdgeStyle cast(OdRxObject pObj)
	{
		OdGiEdgeStyle rXObject = Helpers.GetRXObject<OdGiEdgeStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_isASwigExplicitOdGiEdgeStyle(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_queryXSwigExplicitOdGiEdgeStyle(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiEdgeStyle createObject()
	{
		OdGiEdgeStyle rXObject = Helpers.GetRXObject<OdGiEdgeStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void set(OdGiEdgeStyle style)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_set(swigCPtr, getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiEdgeStyle Assign(OdGiEdgeStyle style)
	{
		OdGiEdgeStyle rXObject = Helpers.GetRXObject<OdGiEdgeStyle>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_Assign(swigCPtr, getCPtr(style)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool IsEqual(OdGiEdgeStyle style)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_IsEqual(swigCPtr, getCPtr(style));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEdgeModel(OdGiEdgeStyle_EdgeModel model)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setEdgeModel(swigCPtr, (int)model);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiEdgeStyle_EdgeModel edgeModel()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_edgeModel(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiEdgeStyle_EdgeModel)result;
	}

	public virtual void setEdgeStyles(uint nStyles)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setEdgeStyles(swigCPtr, nStyles);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEdgeStyleFlag(OdGiEdgeStyle_EdgeStyle flag, bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setEdgeStyleFlag(swigCPtr, (int)flag, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint edgeStyles()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_edgeStyles(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isEdgeStyleFlagSet(OdGiEdgeStyle_EdgeStyle flag)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_isEdgeStyleFlagSet(swigCPtr, (int)flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setIntersectionColor(OdCmColorBase color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setIntersectionColor(swigCPtr, OdCmColorBase.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColorBase intersectionColor()
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_intersectionColor__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setObscuredColor(OdCmColorBase color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setObscuredColor(swigCPtr, OdCmColorBase.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColorBase obscuredColor()
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_obscuredColor__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setObscuredLinetype(OdGiEdgeStyle_LineType ltype)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setObscuredLinetype(swigCPtr, (int)ltype);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiEdgeStyle_LineType obscuredLinetype()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_obscuredLinetype(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiEdgeStyle_LineType)result;
	}

	public virtual void setIntersectionLinetype(OdGiEdgeStyle_LineType ltype)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setIntersectionLinetype(swigCPtr, (int)ltype);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiEdgeStyle_LineType intersectionLinetype()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_intersectionLinetype(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiEdgeStyle_LineType)result;
	}

	public virtual void setCreaseAngle(double nAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setCreaseAngle(swigCPtr, nAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double creaseAngle()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_creaseAngle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEdgeModifiers(uint nModifiers)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setEdgeModifiers(swigCPtr, nModifiers);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEdgeModifierFlag(OdGiEdgeStyle_EdgeModifier flag, bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setEdgeModifierFlag(swigCPtr, (int)flag, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint edgeModifiers()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_edgeModifiers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isEdgeModifierFlagSet(OdGiEdgeStyle_EdgeModifier flag)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_isEdgeModifierFlagSet(swigCPtr, (int)flag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEdgeColor(OdCmColorBase color, bool bEnableModifier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setEdgeColor(swigCPtr, OdCmColorBase.getCPtr(color), bEnableModifier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColorBase edgeColor()
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_edgeColor__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOpacityLevel(double nLevel, bool bEnableModifier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setOpacityLevel(swigCPtr, nLevel, bEnableModifier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double opacityLevel()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_opacityLevel(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEdgeWidth(int nWidth, bool bEnableModifier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setEdgeWidth(swigCPtr, nWidth, bEnableModifier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int edgeWidth()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_edgeWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setOverhangAmount(int nAmount, bool bEnableModifier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setOverhangAmount(swigCPtr, nAmount, bEnableModifier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int overhangAmount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_overhangAmount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setJitterAmount(OdGiEdgeStyle_JitterAmount amount, bool bEnableModifier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setJitterAmount(swigCPtr, (int)amount, bEnableModifier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiEdgeStyle_JitterAmount jitterAmount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_jitterAmount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiEdgeStyle_JitterAmount)result;
	}

	public virtual void setWiggleAmount(OdGiEdgeStyle_WiggleAmount amount, bool bEnableModifier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setWiggleAmount(swigCPtr, (int)amount, bEnableModifier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiEdgeStyle_WiggleAmount wiggleAmount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_wiggleAmount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiEdgeStyle_WiggleAmount)result;
	}

	public virtual void setSilhouetteColor(OdCmColorBase color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setSilhouetteColor(swigCPtr, OdCmColorBase.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColorBase silhouetteColor()
	{
		OdCmColorBase result = Helpers.GetObject<OdCmColorBase>(TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_silhouetteColor__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSilhouetteWidth(short nWidth)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setSilhouetteWidth(swigCPtr, nWidth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short silhouetteWidth()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_silhouetteWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHaloGap(int nHaloGap, bool bEnableModifier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setHaloGap(swigCPtr, nHaloGap, bEnableModifier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int haloGap()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_haloGap(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setIsolines(ushort nIsolines)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setIsolines(swigCPtr, nIsolines);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ushort isolines()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_isolines(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHidePrecision(bool bHidePrecision)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setHidePrecision(swigCPtr, bHidePrecision);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool hidePrecision()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_hidePrecision(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEdgeStyleApply(OdGiEdgeStyle_EdgeStyleApply apply)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_setEdgeStyleApply(swigCPtr, (int)apply);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiEdgeStyle_EdgeStyleApply edgeStyleApply()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_edgeStyleApply(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiEdgeStyle_EdgeStyleApply)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiEdgeStyle()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiEdgeStyle(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiEdgeStyle) != GetType();
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
		if (SwigDerivedClassHasMethod("setEdgeModel", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetEdgeModel;
		}
		if (SwigDerivedClassHasMethod("edgeModel", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodedgeModel;
		}
		if (SwigDerivedClassHasMethod("setEdgeStyles", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetEdgeStyles;
		}
		if (SwigDerivedClassHasMethod("setEdgeStyleFlag", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetEdgeStyleFlag;
		}
		if (SwigDerivedClassHasMethod("edgeStyles", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodedgeStyles;
		}
		if (SwigDerivedClassHasMethod("isEdgeStyleFlagSet", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodisEdgeStyleFlagSet;
		}
		if (SwigDerivedClassHasMethod("setIntersectionColor", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetIntersectionColor;
		}
		if (SwigDerivedClassHasMethod("intersectionColor", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodintersectionColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("intersectionColor", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodintersectionColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setObscuredColor", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetObscuredColor;
		}
		if (SwigDerivedClassHasMethod("obscuredColor", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodobscuredColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("obscuredColor", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodobscuredColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setObscuredLinetype", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetObscuredLinetype;
		}
		if (SwigDerivedClassHasMethod("obscuredLinetype", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodobscuredLinetype;
		}
		if (SwigDerivedClassHasMethod("setIntersectionLinetype", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetIntersectionLinetype;
		}
		if (SwigDerivedClassHasMethod("intersectionLinetype", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodintersectionLinetype;
		}
		if (SwigDerivedClassHasMethod("setCreaseAngle", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetCreaseAngle;
		}
		if (SwigDerivedClassHasMethod("creaseAngle", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodcreaseAngle;
		}
		if (SwigDerivedClassHasMethod("setEdgeModifiers", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetEdgeModifiers;
		}
		if (SwigDerivedClassHasMethod("setEdgeModifierFlag", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetEdgeModifierFlag;
		}
		if (SwigDerivedClassHasMethod("edgeModifiers", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodedgeModifiers;
		}
		if (SwigDerivedClassHasMethod("isEdgeModifierFlagSet", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodisEdgeModifierFlagSet;
		}
		if (SwigDerivedClassHasMethod("setEdgeColor", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetEdgeColor;
		}
		if (SwigDerivedClassHasMethod("edgeColor", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodedgeColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("edgeColor", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodedgeColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setOpacityLevel", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodsetOpacityLevel;
		}
		if (SwigDerivedClassHasMethod("opacityLevel", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodopacityLevel;
		}
		if (SwigDerivedClassHasMethod("setEdgeWidth", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodsetEdgeWidth;
		}
		if (SwigDerivedClassHasMethod("edgeWidth", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodedgeWidth;
		}
		if (SwigDerivedClassHasMethod("setOverhangAmount", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodsetOverhangAmount;
		}
		if (SwigDerivedClassHasMethod("overhangAmount", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodoverhangAmount;
		}
		if (SwigDerivedClassHasMethod("setJitterAmount", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodsetJitterAmount;
		}
		if (SwigDerivedClassHasMethod("jitterAmount", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodjitterAmount;
		}
		if (SwigDerivedClassHasMethod("setWiggleAmount", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodsetWiggleAmount;
		}
		if (SwigDerivedClassHasMethod("wiggleAmount", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodwiggleAmount;
		}
		if (SwigDerivedClassHasMethod("setSilhouetteColor", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodsetSilhouetteColor;
		}
		if (SwigDerivedClassHasMethod("silhouetteColor", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsilhouetteColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("silhouetteColor", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodsilhouetteColor__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setSilhouetteWidth", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodsetSilhouetteWidth;
		}
		if (SwigDerivedClassHasMethod("silhouetteWidth", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodsilhouetteWidth;
		}
		if (SwigDerivedClassHasMethod("setHaloGap", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodsetHaloGap;
		}
		if (SwigDerivedClassHasMethod("haloGap", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodhaloGap;
		}
		if (SwigDerivedClassHasMethod("setIsolines", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodsetIsolines;
		}
		if (SwigDerivedClassHasMethod("isolines", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodisolines;
		}
		if (SwigDerivedClassHasMethod("setHidePrecision", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodsetHidePrecision;
		}
		if (SwigDerivedClassHasMethod("hidePrecision", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodhidePrecision;
		}
		if (SwigDerivedClassHasMethod("setEdgeStyleApply", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodsetEdgeStyleApply;
		}
		if (SwigDerivedClassHasMethod("edgeStyleApply", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodedgeStyleApply;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiEdgeStyle_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiEdgeStyle));
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

	private void SwigDirectorMethodsetEdgeModel(int model)
	{
		try
		{
			setEdgeModel((OdGiEdgeStyle_EdgeModel)model);
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

	private int SwigDirectorMethodedgeModel()
	{
		return (int)edgeModel();
	}

	private void SwigDirectorMethodsetEdgeStyles(uint nStyles)
	{
		try
		{
			setEdgeStyles(nStyles);
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

	private void SwigDirectorMethodsetEdgeStyleFlag(int flag, bool bEnable)
	{
		try
		{
			setEdgeStyleFlag((OdGiEdgeStyle_EdgeStyle)flag, bEnable);
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

	private uint SwigDirectorMethodedgeStyles()
	{
		return edgeStyles();
	}

	private bool SwigDirectorMethodisEdgeStyleFlagSet(int flag)
	{
		return isEdgeStyleFlagSet((OdGiEdgeStyle_EdgeStyle)flag);
	}

	private void SwigDirectorMethodsetIntersectionColor(IntPtr color)
	{
		try
		{
			setIntersectionColor(Helpers.GetObject<OdCmColorBase>(color, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodintersectionColor__SWIG_0()
	{
		return OdCmColorBase.getCPtr(intersectionColor()).Handle;
	}

	private IntPtr SwigDirectorMethodintersectionColor__SWIG_1()
	{
		return OdCmColorBase.getCPtr(intersectionColor()).Handle;
	}

	private void SwigDirectorMethodsetObscuredColor(IntPtr color)
	{
		try
		{
			setObscuredColor(Helpers.GetObject<OdCmColorBase>(color, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodobscuredColor__SWIG_0()
	{
		return OdCmColorBase.getCPtr(obscuredColor()).Handle;
	}

	private IntPtr SwigDirectorMethodobscuredColor__SWIG_1()
	{
		return OdCmColorBase.getCPtr(obscuredColor()).Handle;
	}

	private void SwigDirectorMethodsetObscuredLinetype(int ltype)
	{
		try
		{
			setObscuredLinetype((OdGiEdgeStyle_LineType)ltype);
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

	private int SwigDirectorMethodobscuredLinetype()
	{
		return (int)obscuredLinetype();
	}

	private void SwigDirectorMethodsetIntersectionLinetype(int ltype)
	{
		try
		{
			setIntersectionLinetype((OdGiEdgeStyle_LineType)ltype);
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

	private int SwigDirectorMethodintersectionLinetype()
	{
		return (int)intersectionLinetype();
	}

	private void SwigDirectorMethodsetCreaseAngle(double nAngle)
	{
		try
		{
			setCreaseAngle(nAngle);
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

	private double SwigDirectorMethodcreaseAngle()
	{
		return creaseAngle();
	}

	private void SwigDirectorMethodsetEdgeModifiers(uint nModifiers)
	{
		try
		{
			setEdgeModifiers(nModifiers);
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

	private void SwigDirectorMethodsetEdgeModifierFlag(int flag, bool bEnable)
	{
		try
		{
			setEdgeModifierFlag((OdGiEdgeStyle_EdgeModifier)flag, bEnable);
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

	private uint SwigDirectorMethodedgeModifiers()
	{
		return edgeModifiers();
	}

	private bool SwigDirectorMethodisEdgeModifierFlagSet(int flag)
	{
		return isEdgeModifierFlagSet((OdGiEdgeStyle_EdgeModifier)flag);
	}

	private void SwigDirectorMethodsetEdgeColor(IntPtr color, bool bEnableModifier)
	{
		try
		{
			setEdgeColor(Helpers.GetObject<OdCmColorBase>(color, bOwn: false, bTryAddToTransaction: false), bEnableModifier);
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

	private IntPtr SwigDirectorMethodedgeColor__SWIG_0()
	{
		return OdCmColorBase.getCPtr(edgeColor()).Handle;
	}

	private IntPtr SwigDirectorMethodedgeColor__SWIG_1()
	{
		return OdCmColorBase.getCPtr(edgeColor()).Handle;
	}

	private void SwigDirectorMethodsetOpacityLevel(double nLevel, bool bEnableModifier)
	{
		try
		{
			setOpacityLevel(nLevel, bEnableModifier);
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

	private double SwigDirectorMethodopacityLevel()
	{
		return opacityLevel();
	}

	private void SwigDirectorMethodsetEdgeWidth(int nWidth, bool bEnableModifier)
	{
		try
		{
			setEdgeWidth(nWidth, bEnableModifier);
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

	private int SwigDirectorMethodedgeWidth()
	{
		return edgeWidth();
	}

	private void SwigDirectorMethodsetOverhangAmount(int nAmount, bool bEnableModifier)
	{
		try
		{
			setOverhangAmount(nAmount, bEnableModifier);
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

	private int SwigDirectorMethodoverhangAmount()
	{
		return overhangAmount();
	}

	private void SwigDirectorMethodsetJitterAmount(int amount, bool bEnableModifier)
	{
		try
		{
			setJitterAmount((OdGiEdgeStyle_JitterAmount)amount, bEnableModifier);
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

	private int SwigDirectorMethodjitterAmount()
	{
		return (int)jitterAmount();
	}

	private void SwigDirectorMethodsetWiggleAmount(int amount, bool bEnableModifier)
	{
		try
		{
			setWiggleAmount((OdGiEdgeStyle_WiggleAmount)amount, bEnableModifier);
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

	private int SwigDirectorMethodwiggleAmount()
	{
		return (int)wiggleAmount();
	}

	private void SwigDirectorMethodsetSilhouetteColor(IntPtr color)
	{
		try
		{
			setSilhouetteColor(Helpers.GetObject<OdCmColorBase>(color, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodsilhouetteColor__SWIG_0()
	{
		return OdCmColorBase.getCPtr(silhouetteColor()).Handle;
	}

	private IntPtr SwigDirectorMethodsilhouetteColor__SWIG_1()
	{
		return OdCmColorBase.getCPtr(silhouetteColor()).Handle;
	}

	private void SwigDirectorMethodsetSilhouetteWidth(short nWidth)
	{
		try
		{
			setSilhouetteWidth(nWidth);
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

	private short SwigDirectorMethodsilhouetteWidth()
	{
		return silhouetteWidth();
	}

	private void SwigDirectorMethodsetHaloGap(int nHaloGap, bool bEnableModifier)
	{
		try
		{
			setHaloGap(nHaloGap, bEnableModifier);
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

	private int SwigDirectorMethodhaloGap()
	{
		return haloGap();
	}

	private void SwigDirectorMethodsetIsolines(ushort nIsolines)
	{
		try
		{
			setIsolines(nIsolines);
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

	private ushort SwigDirectorMethodisolines()
	{
		return isolines();
	}

	private void SwigDirectorMethodsetHidePrecision(bool bHidePrecision)
	{
		try
		{
			setHidePrecision(bHidePrecision);
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

	private bool SwigDirectorMethodhidePrecision()
	{
		return hidePrecision();
	}

	private void SwigDirectorMethodsetEdgeStyleApply(int apply)
	{
		try
		{
			setEdgeStyleApply((OdGiEdgeStyle_EdgeStyleApply)apply);
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

	private int SwigDirectorMethodedgeStyleApply()
	{
		return (int)edgeStyleApply();
	}
}
