using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSubEntityTraitsWrapper : OdGiSubEntityTraits
{
	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_1();

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_3(ushort color);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_4(IntPtr color);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_5(IntPtr layerId);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_6(IntPtr lineTypeId);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_7(IntPtr selectionMarker);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_8(int fillType);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_9(IntPtr pNormal);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_10();

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_11(int lineWeight);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_12(double lineTypeScale);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_13();

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_14(double thickness);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_15(int plotStyleNameType, IntPtr plotStyleNameId);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_16(int plotStyleNameType);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_17(IntPtr materialId);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_18(IntPtr pMapper);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_19(IntPtr visualStyleId);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_20(IntPtr transparency);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_21(uint drawFlags);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_22(uint lockFlags);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_23(bool bSelectionFlag);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_24(int shadowFlags);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_25(bool bSectionableFlag);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_26(int selectionFlags);

	public delegate ushort SwigDelegateOdGiSubEntityTraitsWrapper_27();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_28();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_29();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_30();

	public delegate int SwigDelegateOdGiSubEntityTraitsWrapper_31();

	public delegate bool SwigDelegateOdGiSubEntityTraitsWrapper_32(IntPtr normal);

	public delegate int SwigDelegateOdGiSubEntityTraitsWrapper_33();

	public delegate double SwigDelegateOdGiSubEntityTraitsWrapper_34();

	public delegate double SwigDelegateOdGiSubEntityTraitsWrapper_35();

	public delegate int SwigDelegateOdGiSubEntityTraitsWrapper_36();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_37();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_38();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_39();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_40();

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_41();

	public delegate uint SwigDelegateOdGiSubEntityTraitsWrapper_42();

	public delegate uint SwigDelegateOdGiSubEntityTraitsWrapper_43();

	public delegate bool SwigDelegateOdGiSubEntityTraitsWrapper_44();

	public delegate int SwigDelegateOdGiSubEntityTraitsWrapper_45();

	public delegate bool SwigDelegateOdGiSubEntityTraitsWrapper_46();

	public delegate int SwigDelegateOdGiSubEntityTraitsWrapper_47();

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_48(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_49();

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_50(IntPtr pLSMod);

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_51();

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_52(IntPtr pFill);

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_53();

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_54(IntPtr pAuxData);

	public delegate IntPtr SwigDelegateOdGiSubEntityTraitsWrapper_55();

	public delegate bool SwigDelegateOdGiSubEntityTraitsWrapper_56(IntPtr pOverride);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_57();

	public delegate bool SwigDelegateOdGiSubEntityTraitsWrapper_58(IntPtr pOverride);

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_59();

	public delegate uint SwigDelegateOdGiSubEntityTraitsWrapper_60();

	public delegate void SwigDelegateOdGiSubEntityTraitsWrapper_61(IntPtr lightId);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiSubEntityTraitsWrapper_0 swigDelegate0;

	private SwigDelegateOdGiSubEntityTraitsWrapper_1 swigDelegate1;

	private SwigDelegateOdGiSubEntityTraitsWrapper_2 swigDelegate2;

	private SwigDelegateOdGiSubEntityTraitsWrapper_3 swigDelegate3;

	private SwigDelegateOdGiSubEntityTraitsWrapper_4 swigDelegate4;

	private SwigDelegateOdGiSubEntityTraitsWrapper_5 swigDelegate5;

	private SwigDelegateOdGiSubEntityTraitsWrapper_6 swigDelegate6;

	private SwigDelegateOdGiSubEntityTraitsWrapper_7 swigDelegate7;

	private SwigDelegateOdGiSubEntityTraitsWrapper_8 swigDelegate8;

	private SwigDelegateOdGiSubEntityTraitsWrapper_9 swigDelegate9;

	private SwigDelegateOdGiSubEntityTraitsWrapper_10 swigDelegate10;

	private SwigDelegateOdGiSubEntityTraitsWrapper_11 swigDelegate11;

	private SwigDelegateOdGiSubEntityTraitsWrapper_12 swigDelegate12;

	private SwigDelegateOdGiSubEntityTraitsWrapper_13 swigDelegate13;

	private SwigDelegateOdGiSubEntityTraitsWrapper_14 swigDelegate14;

	private SwigDelegateOdGiSubEntityTraitsWrapper_15 swigDelegate15;

	private SwigDelegateOdGiSubEntityTraitsWrapper_16 swigDelegate16;

	private SwigDelegateOdGiSubEntityTraitsWrapper_17 swigDelegate17;

	private SwigDelegateOdGiSubEntityTraitsWrapper_18 swigDelegate18;

	private SwigDelegateOdGiSubEntityTraitsWrapper_19 swigDelegate19;

	private SwigDelegateOdGiSubEntityTraitsWrapper_20 swigDelegate20;

	private SwigDelegateOdGiSubEntityTraitsWrapper_21 swigDelegate21;

	private SwigDelegateOdGiSubEntityTraitsWrapper_22 swigDelegate22;

	private SwigDelegateOdGiSubEntityTraitsWrapper_23 swigDelegate23;

	private SwigDelegateOdGiSubEntityTraitsWrapper_24 swigDelegate24;

	private SwigDelegateOdGiSubEntityTraitsWrapper_25 swigDelegate25;

	private SwigDelegateOdGiSubEntityTraitsWrapper_26 swigDelegate26;

	private SwigDelegateOdGiSubEntityTraitsWrapper_27 swigDelegate27;

	private SwigDelegateOdGiSubEntityTraitsWrapper_28 swigDelegate28;

	private SwigDelegateOdGiSubEntityTraitsWrapper_29 swigDelegate29;

	private SwigDelegateOdGiSubEntityTraitsWrapper_30 swigDelegate30;

	private SwigDelegateOdGiSubEntityTraitsWrapper_31 swigDelegate31;

	private SwigDelegateOdGiSubEntityTraitsWrapper_32 swigDelegate32;

	private SwigDelegateOdGiSubEntityTraitsWrapper_33 swigDelegate33;

	private SwigDelegateOdGiSubEntityTraitsWrapper_34 swigDelegate34;

	private SwigDelegateOdGiSubEntityTraitsWrapper_35 swigDelegate35;

	private SwigDelegateOdGiSubEntityTraitsWrapper_36 swigDelegate36;

	private SwigDelegateOdGiSubEntityTraitsWrapper_37 swigDelegate37;

	private SwigDelegateOdGiSubEntityTraitsWrapper_38 swigDelegate38;

	private SwigDelegateOdGiSubEntityTraitsWrapper_39 swigDelegate39;

	private SwigDelegateOdGiSubEntityTraitsWrapper_40 swigDelegate40;

	private SwigDelegateOdGiSubEntityTraitsWrapper_41 swigDelegate41;

	private SwigDelegateOdGiSubEntityTraitsWrapper_42 swigDelegate42;

	private SwigDelegateOdGiSubEntityTraitsWrapper_43 swigDelegate43;

	private SwigDelegateOdGiSubEntityTraitsWrapper_44 swigDelegate44;

	private SwigDelegateOdGiSubEntityTraitsWrapper_45 swigDelegate45;

	private SwigDelegateOdGiSubEntityTraitsWrapper_46 swigDelegate46;

	private SwigDelegateOdGiSubEntityTraitsWrapper_47 swigDelegate47;

	private SwigDelegateOdGiSubEntityTraitsWrapper_48 swigDelegate48;

	private SwigDelegateOdGiSubEntityTraitsWrapper_49 swigDelegate49;

	private SwigDelegateOdGiSubEntityTraitsWrapper_50 swigDelegate50;

	private SwigDelegateOdGiSubEntityTraitsWrapper_51 swigDelegate51;

	private SwigDelegateOdGiSubEntityTraitsWrapper_52 swigDelegate52;

	private SwigDelegateOdGiSubEntityTraitsWrapper_53 swigDelegate53;

	private SwigDelegateOdGiSubEntityTraitsWrapper_54 swigDelegate54;

	private SwigDelegateOdGiSubEntityTraitsWrapper_55 swigDelegate55;

	private SwigDelegateOdGiSubEntityTraitsWrapper_56 swigDelegate56;

	private SwigDelegateOdGiSubEntityTraitsWrapper_57 swigDelegate57;

	private SwigDelegateOdGiSubEntityTraitsWrapper_58 swigDelegate58;

	private SwigDelegateOdGiSubEntityTraitsWrapper_59 swigDelegate59;

	private SwigDelegateOdGiSubEntityTraitsWrapper_60 swigDelegate60;

	private SwigDelegateOdGiSubEntityTraitsWrapper_61 swigDelegate61;

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
	public OdGiSubEntityTraitsWrapper(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSubEntityTraitsWrapper obj)
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
					throw new MethodAccessException("C++ destructor does not have public access");
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual void setColor(ushort n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setColor(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setTrueColor(OdCmEntityColor n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setTrueColor(swigCPtr, OdCmEntityColor.getCPtr(n));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLayer(OdDbStub n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setLayer(swigCPtr, OdDbStub.getCPtr(n));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineType(OdDbStub n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setLineType(swigCPtr, OdDbStub.getCPtr(n));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSelectionMarker(IntPtr n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setSelectionMarker(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setFillType(OdGiFillType n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setFillType(swigCPtr, (int)n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setFillPlane(OdGeVector3d n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setFillPlane__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(n));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void setFillPlane()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setFillPlane__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineWeight(LineWeight n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setLineWeight(swigCPtr, (int)n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineTypeScale(double n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setLineTypeScale__SWIG_0(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void setLineTypeScale()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setLineTypeScale__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setThickness(double n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setThickness(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setPlotStyleName(PlotStyleNameType n, OdDbStub m)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setPlotStyleName__SWIG_0(swigCPtr, (int)n, OdDbStub.getCPtr(m));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void setPlotStyleName(PlotStyleNameType n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setPlotStyleName__SWIG_1(swigCPtr, (int)n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setMaterial(OdDbStub n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setMaterial(swigCPtr, OdDbStub.getCPtr(n));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setMapper(OdGiMapper n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setMapper(swigCPtr, OdGiMapper.getCPtr(n));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setVisualStyle(OdDbStub n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setVisualStyle(swigCPtr, OdDbStub.getCPtr(n));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setTransparency(OdCmTransparency transparency)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setTransparency(swigCPtr, OdCmTransparency.getCPtr(transparency));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setDrawFlags(uint drawFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setDrawFlags(swigCPtr, drawFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSelectionGeom(bool bSelectionFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setSelectionGeom(swigCPtr, bSelectionFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setShadowFlags(OdGiSubEntityTraits_ShadowFlags shadowFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setShadowFlags(swigCPtr, (int)shadowFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSectionable(bool bSectionableFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setSectionable(swigCPtr, bSectionableFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSelectionFlags(OdGiSubEntityTraits_SelectionFlags selectionFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setSelectionFlags(swigCPtr, (int)selectionFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setSecondaryTrueColor(OdCmEntityColor n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setSecondaryTrueColor(swigCPtr, OdCmEntityColor.getCPtr(n));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void setLineStyleModifiers(OdGiDgLinetypeModifiers pLSMod)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_setLineStyleModifiers(swigCPtr, OdGiDgLinetypeModifiers.getCPtr(pLSMod));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual ushort color()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_color(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdCmEntityColor trueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_trueColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub layer()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_layer(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub lineType()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_lineType(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiFillType fillType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_fillType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFillType)result;
	}

	public new virtual bool fillPlane(OdGeVector3d n)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_fillPlane(swigCPtr, OdGeVector3d.getCPtr(n));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual LineWeight lineWeight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_lineWeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public new virtual double lineTypeScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_lineTypeScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual double thickness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_thickness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual PlotStyleNameType plotStyleNameType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_plotStyleNameType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PlotStyleNameType)result;
	}

	public new virtual OdDbStub plotStyleNameId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_plotStyleNameId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub material()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_material(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiMapper mapper()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_mapper(swigCPtr);
		OdGiMapper result = ((intPtr == IntPtr.Zero) ? null : new OdGiMapper(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdDbStub visualStyle()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_visualStyle(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdCmTransparency transparency()
	{
		OdCmTransparency result = new OdCmTransparency(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_transparency(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint drawFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_drawFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool selectionGeom()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_selectionGeom(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiSubEntityTraits_ShadowFlags shadowFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_shadowFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_ShadowFlags)result;
	}

	public new virtual bool sectionable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_sectionable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiSubEntityTraits_SelectionFlags selectionFlags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_selectionFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_SelectionFlags)result;
	}

	public new virtual OdCmEntityColor secondaryTrueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_secondaryTrueColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGiDgLinetypeModifiers lineStyleModifiers()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_lineStyleModifiers(swigCPtr);
		OdGiDgLinetypeModifiers result = ((intPtr == IntPtr.Zero) ? null : new OdGiDgLinetypeModifiers(intPtr, cMemoryOwn: false));
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsWrapper_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiSubEntityTraitsWrapper));
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
