using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSubEntityTraits : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_1();

	public delegate void SwigDelegateOdGiSubEntityTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiSubEntityTraits_3(ushort color);

	public delegate void SwigDelegateOdGiSubEntityTraits_4(IntPtr color);

	public delegate void SwigDelegateOdGiSubEntityTraits_5(IntPtr layerId);

	public delegate void SwigDelegateOdGiSubEntityTraits_6(IntPtr lineTypeId);

	public delegate void SwigDelegateOdGiSubEntityTraits_7(IntPtr selectionMarker);

	public delegate void SwigDelegateOdGiSubEntityTraits_8(int fillType);

	public delegate void SwigDelegateOdGiSubEntityTraits_9(IntPtr pNormal);

	public delegate void SwigDelegateOdGiSubEntityTraits_10();

	public delegate void SwigDelegateOdGiSubEntityTraits_11(int lineWeight);

	public delegate void SwigDelegateOdGiSubEntityTraits_12(double lineTypeScale);

	public delegate void SwigDelegateOdGiSubEntityTraits_13();

	public delegate void SwigDelegateOdGiSubEntityTraits_14(double thickness);

	public delegate void SwigDelegateOdGiSubEntityTraits_15(int plotStyleNameType, IntPtr plotStyleNameId);

	public delegate void SwigDelegateOdGiSubEntityTraits_16(int plotStyleNameType);

	public delegate void SwigDelegateOdGiSubEntityTraits_17(IntPtr materialId);

	public delegate void SwigDelegateOdGiSubEntityTraits_18(IntPtr pMapper);

	public delegate void SwigDelegateOdGiSubEntityTraits_19(IntPtr visualStyleId);

	public delegate void SwigDelegateOdGiSubEntityTraits_20(IntPtr transparency);

	public delegate void SwigDelegateOdGiSubEntityTraits_21(uint drawFlags);

	public delegate void SwigDelegateOdGiSubEntityTraits_22(uint lockFlags);

	public delegate void SwigDelegateOdGiSubEntityTraits_23(bool bSelectionFlag);

	public delegate void SwigDelegateOdGiSubEntityTraits_24(int shadowFlags);

	public delegate void SwigDelegateOdGiSubEntityTraits_25(bool bSectionableFlag);

	public delegate void SwigDelegateOdGiSubEntityTraits_26(int selectionFlags);

	public delegate ushort SwigDelegateOdGiSubEntityTraits_27();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_28();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_29();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_30();

	public delegate int SwigDelegateOdGiSubEntityTraits_31();

	public delegate bool SwigDelegateOdGiSubEntityTraits_32(IntPtr normal);

	public delegate int SwigDelegateOdGiSubEntityTraits_33();

	public delegate double SwigDelegateOdGiSubEntityTraits_34();

	public delegate double SwigDelegateOdGiSubEntityTraits_35();

	public delegate int SwigDelegateOdGiSubEntityTraits_36();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_37();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_38();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_39();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_40();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_41();

	public delegate uint SwigDelegateOdGiSubEntityTraits_42();

	public delegate uint SwigDelegateOdGiSubEntityTraits_43();

	public delegate bool SwigDelegateOdGiSubEntityTraits_44();

	public delegate int SwigDelegateOdGiSubEntityTraits_45();

	public delegate bool SwigDelegateOdGiSubEntityTraits_46();

	public delegate int SwigDelegateOdGiSubEntityTraits_47();

	public delegate void SwigDelegateOdGiSubEntityTraits_48(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_49();

	public delegate void SwigDelegateOdGiSubEntityTraits_50(IntPtr pLSMod);

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_51();

	public delegate void SwigDelegateOdGiSubEntityTraits_52(IntPtr pFill);

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_53();

	public delegate void SwigDelegateOdGiSubEntityTraits_54(IntPtr pAuxData);

	public delegate IntPtr SwigDelegateOdGiSubEntityTraits_55();

	public delegate bool SwigDelegateOdGiSubEntityTraits_56(IntPtr pOverride);

	public delegate void SwigDelegateOdGiSubEntityTraits_57();

	public delegate bool SwigDelegateOdGiSubEntityTraits_58(IntPtr pOverride);

	public delegate void SwigDelegateOdGiSubEntityTraits_59();

	public delegate uint SwigDelegateOdGiSubEntityTraits_60();

	public delegate void SwigDelegateOdGiSubEntityTraits_61(IntPtr lightId);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiSubEntityTraits_0 swigDelegate0;

	private SwigDelegateOdGiSubEntityTraits_1 swigDelegate1;

	private SwigDelegateOdGiSubEntityTraits_2 swigDelegate2;

	private SwigDelegateOdGiSubEntityTraits_3 swigDelegate3;

	private SwigDelegateOdGiSubEntityTraits_4 swigDelegate4;

	private SwigDelegateOdGiSubEntityTraits_5 swigDelegate5;

	private SwigDelegateOdGiSubEntityTraits_6 swigDelegate6;

	private SwigDelegateOdGiSubEntityTraits_7 swigDelegate7;

	private SwigDelegateOdGiSubEntityTraits_8 swigDelegate8;

	private SwigDelegateOdGiSubEntityTraits_9 swigDelegate9;

	private SwigDelegateOdGiSubEntityTraits_10 swigDelegate10;

	private SwigDelegateOdGiSubEntityTraits_11 swigDelegate11;

	private SwigDelegateOdGiSubEntityTraits_12 swigDelegate12;

	private SwigDelegateOdGiSubEntityTraits_13 swigDelegate13;

	private SwigDelegateOdGiSubEntityTraits_14 swigDelegate14;

	private SwigDelegateOdGiSubEntityTraits_15 swigDelegate15;

	private SwigDelegateOdGiSubEntityTraits_16 swigDelegate16;

	private SwigDelegateOdGiSubEntityTraits_17 swigDelegate17;

	private SwigDelegateOdGiSubEntityTraits_18 swigDelegate18;

	private SwigDelegateOdGiSubEntityTraits_19 swigDelegate19;

	private SwigDelegateOdGiSubEntityTraits_20 swigDelegate20;

	private SwigDelegateOdGiSubEntityTraits_21 swigDelegate21;

	private SwigDelegateOdGiSubEntityTraits_22 swigDelegate22;

	private SwigDelegateOdGiSubEntityTraits_23 swigDelegate23;

	private SwigDelegateOdGiSubEntityTraits_24 swigDelegate24;

	private SwigDelegateOdGiSubEntityTraits_25 swigDelegate25;

	private SwigDelegateOdGiSubEntityTraits_26 swigDelegate26;

	private SwigDelegateOdGiSubEntityTraits_27 swigDelegate27;

	private SwigDelegateOdGiSubEntityTraits_28 swigDelegate28;

	private SwigDelegateOdGiSubEntityTraits_29 swigDelegate29;

	private SwigDelegateOdGiSubEntityTraits_30 swigDelegate30;

	private SwigDelegateOdGiSubEntityTraits_31 swigDelegate31;

	private SwigDelegateOdGiSubEntityTraits_32 swigDelegate32;

	private SwigDelegateOdGiSubEntityTraits_33 swigDelegate33;

	private SwigDelegateOdGiSubEntityTraits_34 swigDelegate34;

	private SwigDelegateOdGiSubEntityTraits_35 swigDelegate35;

	private SwigDelegateOdGiSubEntityTraits_36 swigDelegate36;

	private SwigDelegateOdGiSubEntityTraits_37 swigDelegate37;

	private SwigDelegateOdGiSubEntityTraits_38 swigDelegate38;

	private SwigDelegateOdGiSubEntityTraits_39 swigDelegate39;

	private SwigDelegateOdGiSubEntityTraits_40 swigDelegate40;

	private SwigDelegateOdGiSubEntityTraits_41 swigDelegate41;

	private SwigDelegateOdGiSubEntityTraits_42 swigDelegate42;

	private SwigDelegateOdGiSubEntityTraits_43 swigDelegate43;

	private SwigDelegateOdGiSubEntityTraits_44 swigDelegate44;

	private SwigDelegateOdGiSubEntityTraits_45 swigDelegate45;

	private SwigDelegateOdGiSubEntityTraits_46 swigDelegate46;

	private SwigDelegateOdGiSubEntityTraits_47 swigDelegate47;

	private SwigDelegateOdGiSubEntityTraits_48 swigDelegate48;

	private SwigDelegateOdGiSubEntityTraits_49 swigDelegate49;

	private SwigDelegateOdGiSubEntityTraits_50 swigDelegate50;

	private SwigDelegateOdGiSubEntityTraits_51 swigDelegate51;

	private SwigDelegateOdGiSubEntityTraits_52 swigDelegate52;

	private SwigDelegateOdGiSubEntityTraits_53 swigDelegate53;

	private SwigDelegateOdGiSubEntityTraits_54 swigDelegate54;

	private SwigDelegateOdGiSubEntityTraits_55 swigDelegate55;

	private SwigDelegateOdGiSubEntityTraits_56 swigDelegate56;

	private SwigDelegateOdGiSubEntityTraits_57 swigDelegate57;

	private SwigDelegateOdGiSubEntityTraits_58 swigDelegate58;

	private SwigDelegateOdGiSubEntityTraits_59 swigDelegate59;

	private SwigDelegateOdGiSubEntityTraits_60 swigDelegate60;

	private SwigDelegateOdGiSubEntityTraits_61 swigDelegate61;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(ushort) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(IntPtr) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGiFillType) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(LineWeight) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(PlotStyleNameType),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(PlotStyleNameType) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdGiMapper) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdCmTransparency) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGiSubEntityTraits_ShadowFlags) };

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdGiSubEntityTraits_SelectionFlags) };

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[0];

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[0];

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[0];

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[0];

	private static Type[] swigMethodTypes48 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes49 = new Type[0];

	private static Type[] swigMethodTypes50 = new Type[1] { typeof(OdGiDgLinetypeModifiers) };

	private static Type[] swigMethodTypes51 = new Type[0];

	private static Type[] swigMethodTypes52 = new Type[1] { typeof(OdGiFill) };

	private static Type[] swigMethodTypes53 = new Type[0];

	private static Type[] swigMethodTypes54 = new Type[1] { typeof(OdGiAuxiliaryData) };

	private static Type[] swigMethodTypes55 = new Type[0];

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(OdGiLineweightOverride) };

	private static Type[] swigMethodTypes57 = new Type[0];

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(OdGiPalette) };

	private static Type[] swigMethodTypes59 = new Type[0];

	private static Type[] swigMethodTypes60 = new Type[0];

	private static Type[] swigMethodTypes61 = new Type[1] { typeof(OdDbStub) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSubEntityTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSubEntityTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSubEntityTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiSubEntityTraits cast(OdRxObject pObj)
	{
		OdGiSubEntityTraits rXObject = Helpers.GetRXObject<OdGiSubEntityTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_isASwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_queryXSwigExplicitOdGiSubEntityTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiSubEntityTraits createObject()
	{
		OdGiSubEntityTraits rXObject = Helpers.GetRXObject<OdGiSubEntityTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setColor(ushort color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setColor(swigCPtr, color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTrueColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setTrueColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLayer(OdDbStub layerId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLayer(swigCPtr, OdDbStub.getCPtr(layerId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineType(OdDbStub lineTypeId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLineType(swigCPtr, OdDbStub.getCPtr(lineTypeId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSelectionMarker(IntPtr selectionMarker)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setSelectionMarker(swigCPtr, selectionMarker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFillType(OdGiFillType fillType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setFillType(swigCPtr, (int)fillType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFillPlane(OdGeVector3d pNormal)
	{
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes9))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setFillPlaneSwigExplicitOdGiSubEntityTraits__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(pNormal));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setFillPlane__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(pNormal));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFillPlane()
	{
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes10))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setFillPlaneSwigExplicitOdGiSubEntityTraits__SWIG_1(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setFillPlane__SWIG_1(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineWeight(LineWeight lineWeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLineWeight(swigCPtr, (int)lineWeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineTypeScale(double lineTypeScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLineTypeScale__SWIG_0(swigCPtr, lineTypeScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineTypeScale()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLineTypeScale__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setThickness(double thickness)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setThickness(swigCPtr, thickness);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPlotStyleName(PlotStyleNameType plotStyleNameType, OdDbStub plotStyleNameId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setPlotStyleName__SWIG_0(swigCPtr, (int)plotStyleNameType, OdDbStub.getCPtr(plotStyleNameId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPlotStyleName(PlotStyleNameType plotStyleNameType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setPlotStyleName__SWIG_1(swigCPtr, (int)plotStyleNameType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMaterial(OdDbStub materialId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setMaterial(swigCPtr, OdDbStub.getCPtr(materialId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMapper pMapper)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setMapper(swigCPtr, OdGiMapper.getCPtr(pMapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVisualStyle(OdDbStub visualStyleId)
	{
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes19))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setVisualStyleSwigExplicitOdGiSubEntityTraits(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setVisualStyle(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTransparency(OdCmTransparency transparency)
	{
		if (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes20))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setTransparencySwigExplicitOdGiSubEntityTraits(swigCPtr, OdCmTransparency.getCPtr(transparency));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setTransparency(swigCPtr, OdCmTransparency.getCPtr(transparency));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDrawFlags(uint drawFlags)
	{
		if (SwigDerivedClassHasMethod("setDrawFlags", swigMethodTypes21))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setDrawFlagsSwigExplicitOdGiSubEntityTraits(swigCPtr, drawFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setDrawFlags(swigCPtr, drawFlags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLockFlags(uint lockFlags)
	{
		if (SwigDerivedClassHasMethod("setLockFlags", swigMethodTypes22))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLockFlagsSwigExplicitOdGiSubEntityTraits(swigCPtr, lockFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLockFlags(swigCPtr, lockFlags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSelectionGeom(bool bSelectionFlag)
	{
		if (SwigDerivedClassHasMethod("setSelectionGeom", swigMethodTypes23))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setSelectionGeomSwigExplicitOdGiSubEntityTraits(swigCPtr, bSelectionFlag);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setSelectionGeom(swigCPtr, bSelectionFlag);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setShadowFlags(OdGiSubEntityTraits_ShadowFlags shadowFlags)
	{
		if (SwigDerivedClassHasMethod("setShadowFlags", swigMethodTypes24))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setShadowFlagsSwigExplicitOdGiSubEntityTraits(swigCPtr, (int)shadowFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setShadowFlags(swigCPtr, (int)shadowFlags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSectionable(bool bSectionableFlag)
	{
		if (SwigDerivedClassHasMethod("setSectionable", swigMethodTypes25))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setSectionableSwigExplicitOdGiSubEntityTraits(swigCPtr, bSectionableFlag);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setSectionable(swigCPtr, bSectionableFlag);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSelectionFlags(OdGiSubEntityTraits_SelectionFlags selectionFlags)
	{
		if (SwigDerivedClassHasMethod("setSelectionFlags", swigMethodTypes26))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setSelectionFlagsSwigExplicitOdGiSubEntityTraits(swigCPtr, (int)selectionFlags);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setSelectionFlags(swigCPtr, (int)selectionFlags);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ushort color()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_color(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor trueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_trueColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub layer()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_layer(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub lineType()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_lineType(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiFillType fillType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_fillType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFillType)result;
	}

	public virtual bool fillPlane(OdGeVector3d normal)
	{
		bool result = (SwigDerivedClassHasMethod("fillPlane", swigMethodTypes32) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_fillPlaneSwigExplicitOdGiSubEntityTraits(swigCPtr, OdGeVector3d.getCPtr(normal)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_fillPlane(swigCPtr, OdGeVector3d.getCPtr(normal)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual LineWeight lineWeight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_lineWeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual double lineTypeScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_lineTypeScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double thickness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_thickness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual PlotStyleNameType plotStyleNameType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_plotStyleNameType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PlotStyleNameType)result;
	}

	public virtual OdDbStub plotStyleNameId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_plotStyleNameId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub material()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_material(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMapper mapper()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_mapper(swigCPtr);
		OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub visualStyle()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("visualStyle", swigMethodTypes40) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_visualStyleSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_visualStyle(swigCPtr));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmTransparency transparency()
	{
		OdCmTransparency result = new OdCmTransparency(SwigDerivedClassHasMethod("transparency", swigMethodTypes41) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_transparencySwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_transparency(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint drawFlags()
	{
		uint result = (SwigDerivedClassHasMethod("drawFlags", swigMethodTypes42) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_drawFlagsSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_drawFlags(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint lockFlags()
	{
		uint result = (SwigDerivedClassHasMethod("lockFlags", swigMethodTypes43) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_lockFlagsSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_lockFlags(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool selectionGeom()
	{
		bool result = (SwigDerivedClassHasMethod("selectionGeom", swigMethodTypes44) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_selectionGeomSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_selectionGeom(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSubEntityTraits_ShadowFlags shadowFlags()
	{
		int result = (SwigDerivedClassHasMethod("shadowFlags", swigMethodTypes45) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_shadowFlagsSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_shadowFlags(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_ShadowFlags)result;
	}

	public virtual bool sectionable()
	{
		bool result = (SwigDerivedClassHasMethod("sectionable", swigMethodTypes46) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_sectionableSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_sectionable(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSubEntityTraits_SelectionFlags selectionFlags()
	{
		int result = (SwigDerivedClassHasMethod("selectionFlags", swigMethodTypes47) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_selectionFlagsSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_selectionFlags(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_SelectionFlags)result;
	}

	public virtual void setSecondaryTrueColor(OdCmEntityColor color)
	{
		if (SwigDerivedClassHasMethod("setSecondaryTrueColor", swigMethodTypes48))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setSecondaryTrueColorSwigExplicitOdGiSubEntityTraits(swigCPtr, OdCmEntityColor.getCPtr(color));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setSecondaryTrueColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor secondaryTrueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("secondaryTrueColor", swigMethodTypes49) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_secondaryTrueColorSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_secondaryTrueColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLineStyleModifiers(OdGiDgLinetypeModifiers pLSMod)
	{
		if (SwigDerivedClassHasMethod("setLineStyleModifiers", swigMethodTypes50))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLineStyleModifiersSwigExplicitOdGiSubEntityTraits(swigCPtr, OdGiDgLinetypeModifiers.getCPtr(pLSMod));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setLineStyleModifiers(swigCPtr, OdGiDgLinetypeModifiers.getCPtr(pLSMod));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiDgLinetypeModifiers lineStyleModifiers()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("lineStyleModifiers", swigMethodTypes51) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_lineStyleModifiersSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_lineStyleModifiers(swigCPtr));
		OdGiDgLinetypeModifiers result = ((intPtr == IntPtr.Zero) ? null : new OdGiDgLinetypeModifiers(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFill(OdGiFill pFill)
	{
		if (SwigDerivedClassHasMethod("setFill", swigMethodTypes52))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setFillSwigExplicitOdGiSubEntityTraits(swigCPtr, OdGiFill.getCPtr(pFill));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setFill(swigCPtr, OdGiFill.getCPtr(pFill));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiFill fill()
	{
		OdGiFill rXObject = Helpers.GetRXObject<OdGiFill>(SwigDerivedClassHasMethod("fill", swigMethodTypes53) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_fillSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_fill(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setAuxData(OdGiAuxiliaryData pAuxData)
	{
		if (SwigDerivedClassHasMethod("setAuxData", swigMethodTypes54))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setAuxDataSwigExplicitOdGiSubEntityTraits(swigCPtr, OdGiAuxiliaryData.getCPtr(pAuxData));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setAuxData(swigCPtr, OdGiAuxiliaryData.getCPtr(pAuxData));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiAuxiliaryData auxData()
	{
		OdGiAuxiliaryData rXObject = Helpers.GetRXObject<OdGiAuxiliaryData>(SwigDerivedClassHasMethod("auxData", swigMethodTypes55) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_auxDataSwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_auxData(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool pushLineweightOverride(OdGiLineweightOverride pOverride)
	{
		bool result = (SwigDerivedClassHasMethod("pushLineweightOverride", swigMethodTypes56) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_pushLineweightOverrideSwigExplicitOdGiSubEntityTraits(swigCPtr, OdGiLineweightOverride.getCPtr(pOverride)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_pushLineweightOverride(swigCPtr, OdGiLineweightOverride.getCPtr(pOverride)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void popLineweightOverride()
	{
		if (SwigDerivedClassHasMethod("popLineweightOverride", swigMethodTypes57))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_popLineweightOverrideSwigExplicitOdGiSubEntityTraits(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_popLineweightOverride(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool pushPaletteOverride(OdGiPalette pOverride)
	{
		bool result = (SwigDerivedClassHasMethod("pushPaletteOverride", swigMethodTypes58) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_pushPaletteOverrideSwigExplicitOdGiSubEntityTraits(swigCPtr, OdGiPalette.getCPtr(pOverride)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_pushPaletteOverride(swigCPtr, OdGiPalette.getCPtr(pOverride)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void popPaletteOverride()
	{
		if (SwigDerivedClassHasMethod("popPaletteOverride", swigMethodTypes59))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_popPaletteOverrideSwigExplicitOdGiSubEntityTraits(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_popPaletteOverride(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint setupForEntity()
	{
		uint result = (SwigDerivedClassHasMethod("setupForEntity", swigMethodTypes60) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setupForEntitySwigExplicitOdGiSubEntityTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_setupForEntity(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addLight(OdDbStub lightId)
	{
		if (SwigDerivedClassHasMethod("addLight", swigMethodTypes61))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_addLightSwigExplicitOdGiSubEntityTraits(swigCPtr, OdDbStub.getCPtr(lightId));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_addLight(swigCPtr, OdDbStub.getCPtr(lightId));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSubEntityTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSubEntityTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiSubEntityTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetColor;
		}
		if (SwigDerivedClassHasMethod("setTrueColor", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetTrueColor;
		}
		if (SwigDerivedClassHasMethod("setLayer", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetLayer;
		}
		if (SwigDerivedClassHasMethod("setLineType", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetLineType;
		}
		if (SwigDerivedClassHasMethod("setSelectionMarker", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetSelectionMarker;
		}
		if (SwigDerivedClassHasMethod("setFillType", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetFillType;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetFillPlane__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setFillPlane", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetFillPlane__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setLineWeight", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetLineWeight;
		}
		if (SwigDerivedClassHasMethod("setLineTypeScale", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetLineTypeScale__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setLineTypeScale", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetLineTypeScale__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setThickness", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetThickness;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetPlotStyleName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetPlotStyleName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetMaterial;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetMapper;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetVisualStyle;
		}
		if (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetTransparency;
		}
		if (SwigDerivedClassHasMethod("setDrawFlags", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetDrawFlags;
		}
		if (SwigDerivedClassHasMethod("setLockFlags", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetLockFlags;
		}
		if (SwigDerivedClassHasMethod("setSelectionGeom", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetSelectionGeom;
		}
		if (SwigDerivedClassHasMethod("setShadowFlags", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsetShadowFlags;
		}
		if (SwigDerivedClassHasMethod("setSectionable", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetSectionable;
		}
		if (SwigDerivedClassHasMethod("setSelectionFlags", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetSelectionFlags;
		}
		if (SwigDerivedClassHasMethod("color", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodcolor;
		}
		if (SwigDerivedClassHasMethod("trueColor", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodtrueColor;
		}
		if (SwigDerivedClassHasMethod("layer", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodlayer;
		}
		if (SwigDerivedClassHasMethod("lineType", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodlineType;
		}
		if (SwigDerivedClassHasMethod("fillType", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodfillType;
		}
		if (SwigDerivedClassHasMethod("fillPlane", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodfillPlane;
		}
		if (SwigDerivedClassHasMethod("lineWeight", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodlineWeight;
		}
		if (SwigDerivedClassHasMethod("lineTypeScale", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodlineTypeScale;
		}
		if (SwigDerivedClassHasMethod("thickness", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodthickness;
		}
		if (SwigDerivedClassHasMethod("plotStyleNameType", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodplotStyleNameType;
		}
		if (SwigDerivedClassHasMethod("plotStyleNameId", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodplotStyleNameId;
		}
		if (SwigDerivedClassHasMethod("material", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodmaterial;
		}
		if (SwigDerivedClassHasMethod("mapper", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodmapper;
		}
		if (SwigDerivedClassHasMethod("visualStyle", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodvisualStyle;
		}
		if (SwigDerivedClassHasMethod("transparency", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodtransparency;
		}
		if (SwigDerivedClassHasMethod("drawFlags", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethoddrawFlags;
		}
		if (SwigDerivedClassHasMethod("lockFlags", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodlockFlags;
		}
		if (SwigDerivedClassHasMethod("selectionGeom", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodselectionGeom;
		}
		if (SwigDerivedClassHasMethod("shadowFlags", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodshadowFlags;
		}
		if (SwigDerivedClassHasMethod("sectionable", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodsectionable;
		}
		if (SwigDerivedClassHasMethod("selectionFlags", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodselectionFlags;
		}
		if (SwigDerivedClassHasMethod("setSecondaryTrueColor", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodsetSecondaryTrueColor;
		}
		if (SwigDerivedClassHasMethod("secondaryTrueColor", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodsecondaryTrueColor;
		}
		if (SwigDerivedClassHasMethod("setLineStyleModifiers", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodsetLineStyleModifiers;
		}
		if (SwigDerivedClassHasMethod("lineStyleModifiers", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodlineStyleModifiers;
		}
		if (SwigDerivedClassHasMethod("setFill", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodsetFill;
		}
		if (SwigDerivedClassHasMethod("fill", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodfill;
		}
		if (SwigDerivedClassHasMethod("setAuxData", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodsetAuxData;
		}
		if (SwigDerivedClassHasMethod("auxData", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodauxData;
		}
		if (SwigDerivedClassHasMethod("pushLineweightOverride", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodpushLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("popLineweightOverride", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodpopLineweightOverride;
		}
		if (SwigDerivedClassHasMethod("pushPaletteOverride", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodpushPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("popPaletteOverride", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodpopPaletteOverride;
		}
		if (SwigDerivedClassHasMethod("setupForEntity", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodsetupForEntity;
		}
		if (SwigDerivedClassHasMethod("addLight", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodaddLight;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiSubEntityTraits));
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

	private void SwigDirectorMethodsetColor(ushort color)
	{
		try
		{
			setColor(color);
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

	private void SwigDirectorMethodsetTrueColor(IntPtr color)
	{
		try
		{
			setTrueColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetLayer(IntPtr layerId)
	{
		try
		{
			setLayer((layerId == IntPtr.Zero) ? null : new OdDbStub(layerId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetLineType(IntPtr lineTypeId)
	{
		try
		{
			setLineType((lineTypeId == IntPtr.Zero) ? null : new OdDbStub(lineTypeId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetSelectionMarker(IntPtr selectionMarker)
	{
		try
		{
			setSelectionMarker(selectionMarker);
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

	private void SwigDirectorMethodsetFillType(int fillType)
	{
		try
		{
			setFillType((OdGiFillType)fillType);
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

	private void SwigDirectorMethodsetFillPlane__SWIG_0(IntPtr pNormal)
	{
		try
		{
			setFillPlane((pNormal == IntPtr.Zero) ? null : new OdGeVector3d(pNormal, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetFillPlane__SWIG_1()
	{
		try
		{
			setFillPlane();
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

	private void SwigDirectorMethodsetLineWeight(int lineWeight)
	{
		try
		{
			setLineWeight((LineWeight)lineWeight);
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

	private void SwigDirectorMethodsetLineTypeScale__SWIG_0(double lineTypeScale)
	{
		try
		{
			setLineTypeScale(lineTypeScale);
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

	private void SwigDirectorMethodsetLineTypeScale__SWIG_1()
	{
		try
		{
			setLineTypeScale();
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

	private void SwigDirectorMethodsetThickness(double thickness)
	{
		try
		{
			setThickness(thickness);
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

	private void SwigDirectorMethodsetPlotStyleName__SWIG_0(int plotStyleNameType, IntPtr plotStyleNameId)
	{
		try
		{
			setPlotStyleName((PlotStyleNameType)plotStyleNameType, (plotStyleNameId == IntPtr.Zero) ? null : new OdDbStub(plotStyleNameId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetPlotStyleName__SWIG_1(int plotStyleNameType)
	{
		try
		{
			setPlotStyleName((PlotStyleNameType)plotStyleNameType);
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

	private void SwigDirectorMethodsetMaterial(IntPtr materialId)
	{
		try
		{
			setMaterial((materialId == IntPtr.Zero) ? null : new OdDbStub(materialId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper(IntPtr pMapper)
	{
		try
		{
			setMapper((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetVisualStyle(IntPtr visualStyleId)
	{
		try
		{
			setVisualStyle((visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetTransparency(IntPtr transparency)
	{
		try
		{
			setTransparency(new OdCmTransparency(transparency, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDrawFlags(uint drawFlags)
	{
		try
		{
			setDrawFlags(drawFlags);
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

	private void SwigDirectorMethodsetLockFlags(uint lockFlags)
	{
		try
		{
			setLockFlags(lockFlags);
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

	private void SwigDirectorMethodsetSelectionGeom(bool bSelectionFlag)
	{
		try
		{
			setSelectionGeom(bSelectionFlag);
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

	private void SwigDirectorMethodsetShadowFlags(int shadowFlags)
	{
		try
		{
			setShadowFlags((OdGiSubEntityTraits_ShadowFlags)shadowFlags);
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

	private void SwigDirectorMethodsetSectionable(bool bSectionableFlag)
	{
		try
		{
			setSectionable(bSectionableFlag);
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

	private void SwigDirectorMethodsetSelectionFlags(int selectionFlags)
	{
		try
		{
			setSelectionFlags((OdGiSubEntityTraits_SelectionFlags)selectionFlags);
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

	private ushort SwigDirectorMethodcolor()
	{
		return color();
	}

	private IntPtr SwigDirectorMethodtrueColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(trueColor()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodlayer()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(layer()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodlineType()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(lineType()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private int SwigDirectorMethodfillType()
	{
		return (int)fillType();
	}

	private bool SwigDirectorMethodfillPlane(IntPtr normal)
	{
		return fillPlane(new OdGeVector3d(normal, cMemoryOwn: false));
	}

	private int SwigDirectorMethodlineWeight()
	{
		return (int)lineWeight();
	}

	private double SwigDirectorMethodlineTypeScale()
	{
		return lineTypeScale();
	}

	private double SwigDirectorMethodthickness()
	{
		return thickness();
	}

	private int SwigDirectorMethodplotStyleNameType()
	{
		return (int)plotStyleNameType();
	}

	private IntPtr SwigDirectorMethodplotStyleNameId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(plotStyleNameId()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodmaterial()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(material()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodmapper()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiMapper.getCPtr(mapper()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodvisualStyle()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(visualStyle()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodtransparency()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmTransparency.getCPtr(transparency()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private uint SwigDirectorMethoddrawFlags()
	{
		return drawFlags();
	}

	private uint SwigDirectorMethodlockFlags()
	{
		return lockFlags();
	}

	private bool SwigDirectorMethodselectionGeom()
	{
		return selectionGeom();
	}

	private int SwigDirectorMethodshadowFlags()
	{
		return (int)shadowFlags();
	}

	private bool SwigDirectorMethodsectionable()
	{
		return sectionable();
	}

	private int SwigDirectorMethodselectionFlags()
	{
		return (int)selectionFlags();
	}

	private void SwigDirectorMethodsetSecondaryTrueColor(IntPtr color)
	{
		try
		{
			setSecondaryTrueColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodsecondaryTrueColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(secondaryTrueColor()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetLineStyleModifiers(IntPtr pLSMod)
	{
		try
		{
			setLineStyleModifiers((pLSMod == IntPtr.Zero) ? null : new OdGiDgLinetypeModifiers(pLSMod, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodlineStyleModifiers()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiDgLinetypeModifiers.getCPtr(lineStyleModifiers()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetFill(IntPtr pFill)
	{
		try
		{
			setFill(Helpers.GetRXObject<OdGiFill>(pFill, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodfill()
	{
		return OdGiFill.getCPtr(fill()).Handle;
	}

	private void SwigDirectorMethodsetAuxData(IntPtr pAuxData)
	{
		try
		{
			setAuxData(Helpers.GetRXObject<OdGiAuxiliaryData>(pAuxData, bOwn: true, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodauxData()
	{
		return OdGiAuxiliaryData.getCPtr(auxData()).Handle;
	}

	private bool SwigDirectorMethodpushLineweightOverride(IntPtr pOverride)
	{
		return pushLineweightOverride((pOverride == IntPtr.Zero) ? null : new OdGiLineweightOverride(pOverride, cMemoryOwn: false));
	}

	private void SwigDirectorMethodpopLineweightOverride()
	{
		try
		{
			popLineweightOverride();
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

	private bool SwigDirectorMethodpushPaletteOverride(IntPtr pOverride)
	{
		return pushPaletteOverride(Helpers.GetRXObject<OdGiPalette>(pOverride, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodpopPaletteOverride()
	{
		try
		{
			popPaletteOverride();
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

	private uint SwigDirectorMethodsetupForEntity()
	{
		return setupForEntity();
	}

	private void SwigDirectorMethodaddLight(IntPtr lightId)
	{
		try
		{
			addLight((lightId == IntPtr.Zero) ? null : new OdDbStub(lightId, cMemoryOwn: false));
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
