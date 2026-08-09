using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsModel : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGsModel_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsModel_1();

	public delegate void SwigDelegateOdGsModel_2(IntPtr pSource);

	public delegate void SwigDelegateOdGsModel_3(IntPtr openDrawableFn);

	public delegate void SwigDelegateOdGsModel_4(IntPtr pAdded, IntPtr pParent);

	public delegate void SwigDelegateOdGsModel_5(IntPtr pAdded, IntPtr parentID);

	public delegate void SwigDelegateOdGsModel_6(IntPtr pModified, IntPtr pParent);

	public delegate void SwigDelegateOdGsModel_7(IntPtr pModified, IntPtr parentID);

	public delegate void SwigDelegateOdGsModel_8(IntPtr pModified, IntPtr parentID);

	public delegate void SwigDelegateOdGsModel_9(IntPtr pErased, IntPtr pParent);

	public delegate void SwigDelegateOdGsModel_10(IntPtr pErased, IntPtr parentID);

	public delegate void SwigDelegateOdGsModel_11(IntPtr pUnerased, IntPtr pParent);

	public delegate void SwigDelegateOdGsModel_12(IntPtr pUnerased, IntPtr parentID);

	public delegate void SwigDelegateOdGsModel_13(int hint);

	public delegate void SwigDelegateOdGsModel_14(IntPtr pView);

	public delegate void SwigDelegateOdGsModel_15(IntPtr pDevice);

	public delegate void SwigDelegateOdGsModel_16(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdGsModel_17();

	public delegate void SwigDelegateOdGsModel_18(IntPtr path, bool bDoIt, uint nStyle, IntPtr pView);

	public delegate void SwigDelegateOdGsModel_19(IntPtr path, bool bDoIt, uint nStyle);

	public delegate void SwigDelegateOdGsModel_20(IntPtr path, bool bDoIt);

	public delegate void SwigDelegateOdGsModel_21(IntPtr path);

	public delegate void SwigDelegateOdGsModel_22(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle, IntPtr pView);

	public delegate void SwigDelegateOdGsModel_23(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle);

	public delegate void SwigDelegateOdGsModel_24(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt);

	public delegate void SwigDelegateOdGsModel_25(IntPtr path, IntPtr pMarkers, uint nMarkers);

	public delegate void SwigDelegateOdGsModel_26(IntPtr path, bool bDoIt, bool bSelectHidden, IntPtr pView);

	public delegate void SwigDelegateOdGsModel_27(IntPtr path, bool bDoIt, bool bSelectHidden);

	public delegate void SwigDelegateOdGsModel_28(IntPtr path, bool bDoIt);

	public delegate void SwigDelegateOdGsModel_29(IntPtr path);

	public delegate void SwigDelegateOdGsModel_30(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden, IntPtr pView);

	public delegate void SwigDelegateOdGsModel_31(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden);

	public delegate void SwigDelegateOdGsModel_32(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt);

	public delegate void SwigDelegateOdGsModel_33(IntPtr path, IntPtr pMarkers, uint nMarkers);

	public delegate void SwigDelegateOdGsModel_34(IntPtr path, bool bDoIt, IntPtr xForm, IntPtr pView);

	public delegate void SwigDelegateOdGsModel_35(IntPtr path, bool bDoIt, IntPtr xForm);

	public delegate void SwigDelegateOdGsModel_36(IntPtr path, bool bDoIt);

	public delegate void SwigDelegateOdGsModel_37(IntPtr path);

	public delegate void SwigDelegateOdGsModel_38(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm, IntPtr pView);

	public delegate void SwigDelegateOdGsModel_39(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm);

	public delegate void SwigDelegateOdGsModel_40(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt);

	public delegate void SwigDelegateOdGsModel_41(IntPtr path, IntPtr pMarkers, uint nMarkers);

	public delegate bool SwigDelegateOdGsModel_42(IntPtr path, IntPtr xForm, IntPtr pView);

	public delegate bool SwigDelegateOdGsModel_43(IntPtr path, IntPtr xForm);

	public delegate void SwigDelegateOdGsModel_44(int renderType);

	public delegate int SwigDelegateOdGsModel_45();

	public delegate void SwigDelegateOdGsModel_46(int mode);

	public delegate void SwigDelegateOdGsModel_47();

	public delegate int SwigDelegateOdGsModel_48();

	public delegate void SwigDelegateOdGsModel_49(bool bEnable);

	public delegate bool SwigDelegateOdGsModel_50();

	public delegate void SwigDelegateOdGsModel_51(IntPtr backgroundId);

	public delegate IntPtr SwigDelegateOdGsModel_52();

	public delegate void SwigDelegateOdGsModel_53(IntPtr visualStyleId);

	public delegate IntPtr SwigDelegateOdGsModel_54();

	public delegate void SwigDelegateOdGsModel_55(IntPtr visualStyle);

	public delegate bool SwigDelegateOdGsModel_56(IntPtr visualStyle);

	public delegate void SwigDelegateOdGsModel_57(IntPtr pReactor);

	public delegate void SwigDelegateOdGsModel_58(IntPtr pReactor);

	public delegate void SwigDelegateOdGsModel_59(bool bEnable);

	public delegate bool SwigDelegateOdGsModel_60();

	public delegate bool SwigDelegateOdGsModel_61(IntPtr points, IntPtr upVector);

	public delegate bool SwigDelegateOdGsModel_62(IntPtr points, IntPtr upVector, double dTop, double dBottom);

	public delegate void SwigDelegateOdGsModel_63(IntPtr visualStyleId);

	public delegate void SwigDelegateOdGsModel_64(bool bEnable);

	public delegate bool SwigDelegateOdGsModel_65();

	public delegate void SwigDelegateOdGsModel_66(bool bEnable);

	public delegate bool SwigDelegateOdGsModel_67();

	public delegate void SwigDelegateOdGsModel_68(bool bEnable);

	public delegate bool SwigDelegateOdGsModel_69();

	public delegate void SwigDelegateOdGsModel_70(bool bEnable);

	public delegate bool SwigDelegateOdGsModel_71();

	public delegate void SwigDelegateOdGsModel_72(bool bEnable);

	public delegate bool SwigDelegateOdGsModel_73();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsModel_0 swigDelegate0;

	private SwigDelegateOdGsModel_1 swigDelegate1;

	private SwigDelegateOdGsModel_2 swigDelegate2;

	private SwigDelegateOdGsModel_3 swigDelegate3;

	private SwigDelegateOdGsModel_4 swigDelegate4;

	private SwigDelegateOdGsModel_5 swigDelegate5;

	private SwigDelegateOdGsModel_6 swigDelegate6;

	private SwigDelegateOdGsModel_7 swigDelegate7;

	private SwigDelegateOdGsModel_8 swigDelegate8;

	private SwigDelegateOdGsModel_9 swigDelegate9;

	private SwigDelegateOdGsModel_10 swigDelegate10;

	private SwigDelegateOdGsModel_11 swigDelegate11;

	private SwigDelegateOdGsModel_12 swigDelegate12;

	private SwigDelegateOdGsModel_13 swigDelegate13;

	private SwigDelegateOdGsModel_14 swigDelegate14;

	private SwigDelegateOdGsModel_15 swigDelegate15;

	private SwigDelegateOdGsModel_16 swigDelegate16;

	private SwigDelegateOdGsModel_17 swigDelegate17;

	private SwigDelegateOdGsModel_18 swigDelegate18;

	private SwigDelegateOdGsModel_19 swigDelegate19;

	private SwigDelegateOdGsModel_20 swigDelegate20;

	private SwigDelegateOdGsModel_21 swigDelegate21;

	private SwigDelegateOdGsModel_22 swigDelegate22;

	private SwigDelegateOdGsModel_23 swigDelegate23;

	private SwigDelegateOdGsModel_24 swigDelegate24;

	private SwigDelegateOdGsModel_25 swigDelegate25;

	private SwigDelegateOdGsModel_26 swigDelegate26;

	private SwigDelegateOdGsModel_27 swigDelegate27;

	private SwigDelegateOdGsModel_28 swigDelegate28;

	private SwigDelegateOdGsModel_29 swigDelegate29;

	private SwigDelegateOdGsModel_30 swigDelegate30;

	private SwigDelegateOdGsModel_31 swigDelegate31;

	private SwigDelegateOdGsModel_32 swigDelegate32;

	private SwigDelegateOdGsModel_33 swigDelegate33;

	private SwigDelegateOdGsModel_34 swigDelegate34;

	private SwigDelegateOdGsModel_35 swigDelegate35;

	private SwigDelegateOdGsModel_36 swigDelegate36;

	private SwigDelegateOdGsModel_37 swigDelegate37;

	private SwigDelegateOdGsModel_38 swigDelegate38;

	private SwigDelegateOdGsModel_39 swigDelegate39;

	private SwigDelegateOdGsModel_40 swigDelegate40;

	private SwigDelegateOdGsModel_41 swigDelegate41;

	private SwigDelegateOdGsModel_42 swigDelegate42;

	private SwigDelegateOdGsModel_43 swigDelegate43;

	private SwigDelegateOdGsModel_44 swigDelegate44;

	private SwigDelegateOdGsModel_45 swigDelegate45;

	private SwigDelegateOdGsModel_46 swigDelegate46;

	private SwigDelegateOdGsModel_47 swigDelegate47;

	private SwigDelegateOdGsModel_48 swigDelegate48;

	private SwigDelegateOdGsModel_49 swigDelegate49;

	private SwigDelegateOdGsModel_50 swigDelegate50;

	private SwigDelegateOdGsModel_51 swigDelegate51;

	private SwigDelegateOdGsModel_52 swigDelegate52;

	private SwigDelegateOdGsModel_53 swigDelegate53;

	private SwigDelegateOdGsModel_54 swigDelegate54;

	private SwigDelegateOdGsModel_55 swigDelegate55;

	private SwigDelegateOdGsModel_56 swigDelegate56;

	private SwigDelegateOdGsModel_57 swigDelegate57;

	private SwigDelegateOdGsModel_58 swigDelegate58;

	private SwigDelegateOdGsModel_59 swigDelegate59;

	private SwigDelegateOdGsModel_60 swigDelegate60;

	private SwigDelegateOdGsModel_61 swigDelegate61;

	private SwigDelegateOdGsModel_62 swigDelegate62;

	private SwigDelegateOdGsModel_63 swigDelegate63;

	private SwigDelegateOdGsModel_64 swigDelegate64;

	private SwigDelegateOdGsModel_65 swigDelegate65;

	private SwigDelegateOdGsModel_66 swigDelegate66;

	private SwigDelegateOdGsModel_67 swigDelegate67;

	private SwigDelegateOdGsModel_68 swigDelegate68;

	private SwigDelegateOdGsModel_69 swigDelegate69;

	private SwigDelegateOdGsModel_70 swigDelegate70;

	private SwigDelegateOdGsModel_71 swigDelegate71;

	private SwigDelegateOdGsModel_72 swigDelegate72;

	private SwigDelegateOdGsModel_73 swigDelegate73;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegate) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGsModel_InvalidationHint) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdGsDevice) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(uint),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes19 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(uint)
	};

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(OdGiPathNode),
		typeof(bool)
	};

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGiPathNode) };

	private static Type[] swigMethodTypes22 = new Type[6]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(uint),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes23 = new Type[5]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(uint)
	};

	private static Type[] swigMethodTypes24 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes25 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes26 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(bool),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes27 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes28 = new Type[2]
	{
		typeof(OdGiPathNode),
		typeof(bool)
	};

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(OdGiPathNode) };

	private static Type[] swigMethodTypes30 = new Type[6]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(bool),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes31 = new Type[5]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes32 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes33 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes34 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(OdGsMatrixParam),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes35 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(bool),
		typeof(OdGsMatrixParam)
	};

	private static Type[] swigMethodTypes36 = new Type[2]
	{
		typeof(OdGiPathNode),
		typeof(bool)
	};

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(OdGiPathNode) };

	private static Type[] swigMethodTypes38 = new Type[6]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(OdGsMatrixParam),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes39 = new Type[5]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool),
		typeof(OdGsMatrixParam)
	};

	private static Type[] swigMethodTypes40 = new Type[4]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes41 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(IntPtr[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes42 = new Type[3]
	{
		typeof(OdGiPathNode),
		typeof(OdGsMatrixParam),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes43 = new Type[2]
	{
		typeof(OdGiPathNode),
		typeof(OdGsMatrixParam)
	};

	private static Type[] swigMethodTypes44 = new Type[1] { typeof(OdGsModel_RenderType) };

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(OdGsView_RenderMode) };

	private static Type[] swigMethodTypes47 = new Type[0];

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes54 = new Type[0];

	private static Type[] swigMethodTypes55 = new Type[1] { typeof(OdGiVisualStyle) };

	private static Type[] swigMethodTypes56 = new Type[1] { typeof(OdGiVisualStyle).MakeByRefType() };

	private static Type[] swigMethodTypes57 = new Type[1] { typeof(OdGsModelReactor) };

	private static Type[] swigMethodTypes58 = new Type[1] { typeof(OdGsModelReactor) };

	private static Type[] swigMethodTypes59 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes60 = new Type[0];

	private static Type[] swigMethodTypes61 = new Type[2]
	{
		typeof(OdGePoint3dArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes62 = new Type[4]
	{
		typeof(OdGePoint3dArray),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes63 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes64 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes65 = new Type[0];

	private static Type[] swigMethodTypes66 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes67 = new Type[0];

	private static Type[] swigMethodTypes68 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes69 = new Type[0];

	private static Type[] swigMethodTypes70 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes71 = new Type[0];

	private static Type[] swigMethodTypes72 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes73 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsModel(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsModel obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsModel(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsModel cast(OdRxObject pObj)
	{
		OdGsModel rXObject = Helpers.GetRXObject<OdGsModel>(TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_isASwigExplicitOdGsModel(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_queryXSwigExplicitOdGsModel(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsModel createObject()
	{
		OdGsModel rXObject = Helpers.GetRXObject<OdGsModel>(TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setOpenDrawableFn(TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegate openDrawableFn)
	{
		TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegateNative odGiOpenDrawableFnDelegateNative = null;
		if (openDrawableFn != null)
		{
			odGiOpenDrawableFnDelegateNative = (IntPtr id) => OdMarshalHelper.ObjectToPtr<OdGiDrawable>(openDrawableFn(OdMarshalHelper.PtrToObject<OdDbStub>(id)));
		}
		IntPtr jarg = ((openDrawableFn == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(odGiOpenDrawableFnDelegateNative));
		DelegateHolder.Add(odGiOpenDrawableFnDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setOpenDrawableFn(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onAdded1(OdGiDrawable pAdded, OdGiDrawable pParent)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onAdded1(swigCPtr, OdGiDrawable.getCPtr(pAdded), OdGiDrawable.getCPtr(pParent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onAdded2(OdGiDrawable pAdded, OdDbStub parentID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onAdded2(swigCPtr, OdGiDrawable.getCPtr(pAdded), OdDbStub.getCPtr(parentID));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onModified1(OdGiDrawable pModified, OdGiDrawable pParent)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onModified1(swigCPtr, OdGiDrawable.getCPtr(pModified), OdGiDrawable.getCPtr(pParent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onModified2(OdGiDrawable pModified, OdDbStub parentID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onModified2(swigCPtr, OdGiDrawable.getCPtr(pModified), OdDbStub.getCPtr(parentID));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onModifiedGraphics(OdGiDrawable pModified, OdDbStub parentID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onModifiedGraphics(swigCPtr, OdGiDrawable.getCPtr(pModified), OdDbStub.getCPtr(parentID));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onErased1(OdGiDrawable pErased, OdGiDrawable pParent)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onErased1(swigCPtr, OdGiDrawable.getCPtr(pErased), OdGiDrawable.getCPtr(pParent));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onErased2(OdGiDrawable pErased, OdDbStub parentID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onErased2(swigCPtr, OdGiDrawable.getCPtr(pErased), OdDbStub.getCPtr(parentID));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onUnerased1(OdGiDrawable pUnerased, OdGiDrawable pParent)
	{
		if (SwigDerivedClassHasMethod("onUnerased1", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onUnerased1SwigExplicitOdGsModel(swigCPtr, OdGiDrawable.getCPtr(pUnerased), OdGiDrawable.getCPtr(pParent));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onUnerased1(swigCPtr, OdGiDrawable.getCPtr(pUnerased), OdGiDrawable.getCPtr(pParent));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onUnerased2(OdGiDrawable pUnerased, OdDbStub parentID)
	{
		if (SwigDerivedClassHasMethod("onUnerased2", swigMethodTypes12))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onUnerased2SwigExplicitOdGsModel(swigCPtr, OdGiDrawable.getCPtr(pUnerased), OdDbStub.getCPtr(parentID));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_onUnerased2(swigCPtr, OdGiDrawable.getCPtr(pUnerased), OdDbStub.getCPtr(parentID));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidate(OdGsModel_InvalidationHint hint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_invalidate(swigCPtr, (int)hint);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidate2(OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_invalidate2(swigCPtr, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidateVisible(OdGsDevice pDevice)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_invalidateVisible(swigCPtr, OdGsDevice.getCPtr(pDevice));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTransform(OdGeMatrix3d arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setTransform(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d transform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_transform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void highlight1(OdGiPathNode path, bool bDoIt, uint nStyle, OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_highlight1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, nStyle, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdGiPathNode path, bool bDoIt, uint nStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_highlight__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, nStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdGiPathNode path, bool bDoIt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_highlight__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdGiPathNode path)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_highlight__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight2(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, uint nStyle, OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_highlight2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, uint nStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_highlight__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_highlight__SWIG_4(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_highlight__SWIG_5(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hide1(OdGiPathNode path, bool bDoIt, bool bSelectHidden, OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_hide1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, bSelectHidden, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hide(OdGiPathNode path, bool bDoIt, bool bSelectHidden)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_hide__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, bSelectHidden);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hide(OdGiPathNode path, bool bDoIt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_hide__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hide(OdGiPathNode path)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_hide__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hide2(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden, OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_hide2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hide(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_hide__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hide(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_hide__SWIG_4(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hide(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_hide__SWIG_5(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransform1(OdGiPathNode path, bool bDoIt, OdGsMatrixParam xForm, OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_externalTransform1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, OdGsMatrixParam.getCPtr(xForm), OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransform(OdGiPathNode path, bool bDoIt, OdGsMatrixParam xForm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_externalTransform__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt, OdGsMatrixParam.getCPtr(xForm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransform(OdGiPathNode path, bool bDoIt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_externalTransform__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), bDoIt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransform(OdGiPathNode path)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_externalTransform__SWIG_2(swigCPtr, OdGiPathNode.getCPtr(path));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransform2(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, OdGsMatrixParam xForm, OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_externalTransform2(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm), OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransform(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt, OdGsMatrixParam xForm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_externalTransform__SWIG_3(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, OdGsMatrixParam.getCPtr(xForm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransform(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers, bool bDoIt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_externalTransform__SWIG_4(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalTransform(OdGiPathNode path, IntPtr[] pMarkers, uint nMarkers)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_externalTransform__SWIG_5(swigCPtr, OdGiPathNode.getCPtr(path), Helpers.MarshalIntPtrFixedArray(pMarkers), nMarkers);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool getExternalTransform(OdGiPathNode path, OdGsMatrixParam xForm, OdGsView pView)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_getExternalTransform__SWIG_0(swigCPtr, OdGiPathNode.getCPtr(path), xForm, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getExternalTransform(OdGiPathNode path, OdGsMatrixParam xForm)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_getExternalTransform__SWIG_1(swigCPtr, OdGiPathNode.getCPtr(path), xForm);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRenderType(OdGsModel_RenderType renderType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setRenderType(swigCPtr, (int)renderType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsModel_RenderType renderType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_renderType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsModel_RenderType)result;
	}

	public virtual void setRenderModeOverride(OdGsView_RenderMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setRenderModeOverride__SWIG_0(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setRenderModeOverride()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setRenderModeOverride__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsView_RenderMode renderModeOverride()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_renderModeOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsView_RenderMode)result;
	}

	public virtual void setViewClippingOverride(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setViewClippingOverride(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool viewClippingOverride()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_viewClippingOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackground(OdDbStub backgroundId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setBackground(swigCPtr, OdDbStub.getCPtr(backgroundId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub background()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_background(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVisualStyle1(OdDbStub visualStyleId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setVisualStyle1(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub visualStyle1()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_visualStyle1(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVisualStyle2(OdGiVisualStyle visualStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setVisualStyle2(swigCPtr, OdGiVisualStyle.getCPtr(visualStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool VisualStyle2(ref OdGiVisualStyle visualStyle)
	{
		IntPtr jarg = ((visualStyle == null) ? IntPtr.Zero : OdGiVisualStyle.getCPtr(visualStyle).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_VisualStyle2(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				visualStyle = null;
			}
			if (jarg != intPtr)
			{
				visualStyle = Helpers.GetRXObject<OdGiVisualStyle>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void addModelReactor(OdGsModelReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_addModelReactor(swigCPtr, OdGsModelReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeModelReactor(OdGsModelReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_removeModelReactor(swigCPtr, OdGsModelReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEnableSectioning(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setEnableSectioning(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSectioningEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_isSectioningEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setSectioning1(OdGePoint3dArray points, OdGeVector3d upVector)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setSectioning1(swigCPtr, OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(upVector));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setSectioning2(OdGePoint3dArray points, OdGeVector3d upVector, double dTop, double dBottom)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setSectioning2(swigCPtr, OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(upVector), dTop, dBottom);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSectioningVisualStyle(OdDbStub visualStyleId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setSectioningVisualStyle(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEnableLinetypes(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setEnableLinetypes(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isLinetypesEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_isLinetypesEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSelectable(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setSelectable(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSelectable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_isSelectable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEnableViewExtentsCalculation(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setEnableViewExtentsCalculation(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isViewExtentsCalculationEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_isViewExtentsCalculationEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEnableLightsInBlocks(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setEnableLightsInBlocks(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isLightsInBlocksEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_isLightsInBlocksEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setViewSectioningOverride(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_setViewSectioningOverride(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool viewSectioningOverride()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_viewSectioningOverride(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsModel()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsModel(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsModel) != GetType();
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
		if (SwigDerivedClassHasMethod("setOpenDrawableFn", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetOpenDrawableFn;
		}
		if (SwigDerivedClassHasMethod("onAdded1", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodonAdded1;
		}
		if (SwigDerivedClassHasMethod("onAdded2", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodonAdded2;
		}
		if (SwigDerivedClassHasMethod("onModified1", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodonModified1;
		}
		if (SwigDerivedClassHasMethod("onModified2", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodonModified2;
		}
		if (SwigDerivedClassHasMethod("onModifiedGraphics", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodonModifiedGraphics;
		}
		if (SwigDerivedClassHasMethod("onErased1", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodonErased1;
		}
		if (SwigDerivedClassHasMethod("onErased2", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodonErased2;
		}
		if (SwigDerivedClassHasMethod("onUnerased1", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodonUnerased1;
		}
		if (SwigDerivedClassHasMethod("onUnerased2", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodonUnerased2;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodinvalidate;
		}
		if (SwigDerivedClassHasMethod("invalidate2", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodinvalidate2;
		}
		if (SwigDerivedClassHasMethod("invalidateVisible", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodinvalidateVisible;
		}
		if (SwigDerivedClassHasMethod("setTransform", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetTransform;
		}
		if (SwigDerivedClassHasMethod("transform", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodtransform;
		}
		if (SwigDerivedClassHasMethod("highlight1", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodhighlight1;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodhighlight__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodhighlight__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodhighlight__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("highlight2", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodhighlight2;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodhighlight__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodhighlight__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("highlight", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodhighlight__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("hide1", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodhide1;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodhide__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodhide__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodhide__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("hide2", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodhide2;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodhide__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodhide__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("hide", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodhide__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("externalTransform1", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodexternalTransform1;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodexternalTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodexternalTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodexternalTransform__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("externalTransform2", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodexternalTransform2;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodexternalTransform__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodexternalTransform__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("externalTransform", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodexternalTransform__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("getExternalTransform", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodgetExternalTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getExternalTransform", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodgetExternalTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setRenderType", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodsetRenderType;
		}
		if (SwigDerivedClassHasMethod("renderType", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodrenderType;
		}
		if (SwigDerivedClassHasMethod("setRenderModeOverride", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodsetRenderModeOverride__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setRenderModeOverride", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodsetRenderModeOverride__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("renderModeOverride", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodrenderModeOverride;
		}
		if (SwigDerivedClassHasMethod("setViewClippingOverride", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodsetViewClippingOverride;
		}
		if (SwigDerivedClassHasMethod("viewClippingOverride", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodviewClippingOverride;
		}
		if (SwigDerivedClassHasMethod("setBackground", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodsetBackground;
		}
		if (SwigDerivedClassHasMethod("background", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodbackground;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle1", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodsetVisualStyle1;
		}
		if (SwigDerivedClassHasMethod("visualStyle1", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodvisualStyle1;
		}
		if (SwigDerivedClassHasMethod("setVisualStyle2", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodsetVisualStyle2;
		}
		if (SwigDerivedClassHasMethod("VisualStyle2", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodVisualStyle2;
		}
		if (SwigDerivedClassHasMethod("addModelReactor", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodaddModelReactor;
		}
		if (SwigDerivedClassHasMethod("removeModelReactor", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodremoveModelReactor;
		}
		if (SwigDerivedClassHasMethod("setEnableSectioning", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodsetEnableSectioning;
		}
		if (SwigDerivedClassHasMethod("isSectioningEnabled", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodisSectioningEnabled;
		}
		if (SwigDerivedClassHasMethod("setSectioning1", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodsetSectioning1;
		}
		if (SwigDerivedClassHasMethod("setSectioning2", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodsetSectioning2;
		}
		if (SwigDerivedClassHasMethod("setSectioningVisualStyle", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodsetSectioningVisualStyle;
		}
		if (SwigDerivedClassHasMethod("setEnableLinetypes", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodsetEnableLinetypes;
		}
		if (SwigDerivedClassHasMethod("isLinetypesEnabled", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodisLinetypesEnabled;
		}
		if (SwigDerivedClassHasMethod("setSelectable", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodsetSelectable;
		}
		if (SwigDerivedClassHasMethod("isSelectable", swigMethodTypes67))
		{
			swigDelegate67 = SwigDirectorMethodisSelectable;
		}
		if (SwigDerivedClassHasMethod("setEnableViewExtentsCalculation", swigMethodTypes68))
		{
			swigDelegate68 = SwigDirectorMethodsetEnableViewExtentsCalculation;
		}
		if (SwigDerivedClassHasMethod("isViewExtentsCalculationEnabled", swigMethodTypes69))
		{
			swigDelegate69 = SwigDirectorMethodisViewExtentsCalculationEnabled;
		}
		if (SwigDerivedClassHasMethod("setEnableLightsInBlocks", swigMethodTypes70))
		{
			swigDelegate70 = SwigDirectorMethodsetEnableLightsInBlocks;
		}
		if (SwigDerivedClassHasMethod("isLightsInBlocksEnabled", swigMethodTypes71))
		{
			swigDelegate71 = SwigDirectorMethodisLightsInBlocksEnabled;
		}
		if (SwigDerivedClassHasMethod("setViewSectioningOverride", swigMethodTypes72))
		{
			swigDelegate72 = SwigDirectorMethodsetViewSectioningOverride;
		}
		if (SwigDerivedClassHasMethod("viewSectioningOverride", swigMethodTypes73))
		{
			swigDelegate73 = SwigDirectorMethodviewSectioningOverride;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModel_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66, swigDelegate67, swigDelegate68, swigDelegate69, swigDelegate70, swigDelegate71, swigDelegate72, swigDelegate73);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsModel));
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

	private void SwigDirectorMethodsetOpenDrawableFn(IntPtr openDrawableFn)
	{
		try
		{
			setOpenDrawableFn(((Func<TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegate>)delegate
			{
				IntPtr nativeCallback = openDrawableFn;
				TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegate result = null;
				if (nativeCallback != IntPtr.Zero)
				{
					result = (OdDbStub id) => OdMarshalHelper.PtrToObject<OdGiDrawable>((Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegateNative)) as TD_RootIntegrated_Globals.OdGiOpenDrawableFnDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbStub>(id)));
				}
				return result;
			})());
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

	private void SwigDirectorMethodonAdded1(IntPtr pAdded, IntPtr pParent)
	{
		try
		{
			onAdded1(Helpers.GetRXObject<OdGiDrawable>(pAdded, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonAdded2(IntPtr pAdded, IntPtr parentID)
	{
		try
		{
			onAdded2(Helpers.GetRXObject<OdGiDrawable>(pAdded, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
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

	private void SwigDirectorMethodonModified1(IntPtr pModified, IntPtr pParent)
	{
		try
		{
			onModified1(Helpers.GetRXObject<OdGiDrawable>(pModified, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonModified2(IntPtr pModified, IntPtr parentID)
	{
		try
		{
			onModified2(Helpers.GetRXObject<OdGiDrawable>(pModified, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
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

	private void SwigDirectorMethodonModifiedGraphics(IntPtr pModified, IntPtr parentID)
	{
		try
		{
			onModifiedGraphics(Helpers.GetRXObject<OdGiDrawable>(pModified, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
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

	private void SwigDirectorMethodonErased1(IntPtr pErased, IntPtr pParent)
	{
		try
		{
			onErased1(Helpers.GetRXObject<OdGiDrawable>(pErased, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonErased2(IntPtr pErased, IntPtr parentID)
	{
		try
		{
			onErased2(Helpers.GetRXObject<OdGiDrawable>(pErased, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
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

	private void SwigDirectorMethodonUnerased1(IntPtr pUnerased, IntPtr pParent)
	{
		try
		{
			onUnerased1(Helpers.GetRXObject<OdGiDrawable>(pUnerased, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodonUnerased2(IntPtr pUnerased, IntPtr parentID)
	{
		try
		{
			onUnerased2(Helpers.GetRXObject<OdGiDrawable>(pUnerased, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
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

	private void SwigDirectorMethodinvalidate(int hint)
	{
		try
		{
			invalidate((OdGsModel_InvalidationHint)hint);
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

	private void SwigDirectorMethodinvalidate2(IntPtr pView)
	{
		try
		{
			invalidate2(Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodinvalidateVisible(IntPtr pDevice)
	{
		try
		{
			invalidateVisible(Helpers.GetRXObject<OdGsDevice>(pDevice, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsetTransform(IntPtr arg0)
	{
		try
		{
			setTransform(new OdGeMatrix3d(arg0, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodtransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(transform()).Handle;
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

	private void SwigDirectorMethodhighlight1(IntPtr path, bool bDoIt, uint nStyle, IntPtr pView)
	{
		try
		{
			highlight1(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, nStyle, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodhighlight__SWIG_0(IntPtr path, bool bDoIt, uint nStyle)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, nStyle);
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

	private void SwigDirectorMethodhighlight__SWIG_1(IntPtr path, bool bDoIt)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false), bDoIt);
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

	private void SwigDirectorMethodhighlight__SWIG_2(IntPtr path)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false));
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

	private void SwigDirectorMethodhighlight2(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle, IntPtr pView)
	{
		try
		{
			highlight2(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodhighlight__SWIG_3(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, uint nStyle)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, nStyle);
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

	private void SwigDirectorMethodhighlight__SWIG_4(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
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

	private void SwigDirectorMethodhighlight__SWIG_5(IntPtr path, IntPtr pMarkers, uint nMarkers)
	{
		try
		{
			highlight(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers);
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

	private void SwigDirectorMethodhide1(IntPtr path, bool bDoIt, bool bSelectHidden, IntPtr pView)
	{
		try
		{
			hide1(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, bSelectHidden, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodhide__SWIG_0(IntPtr path, bool bDoIt, bool bSelectHidden)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, bSelectHidden);
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

	private void SwigDirectorMethodhide__SWIG_1(IntPtr path, bool bDoIt)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false), bDoIt);
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

	private void SwigDirectorMethodhide__SWIG_2(IntPtr path)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false));
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

	private void SwigDirectorMethodhide2(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden, IntPtr pView)
	{
		try
		{
			hide2(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodhide__SWIG_3(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, bool bSelectHidden)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, bSelectHidden);
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

	private void SwigDirectorMethodhide__SWIG_4(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
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

	private void SwigDirectorMethodhide__SWIG_5(IntPtr path, IntPtr pMarkers, uint nMarkers)
	{
		try
		{
			hide(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers);
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

	private void SwigDirectorMethodexternalTransform1(IntPtr path, bool bDoIt, IntPtr xForm, IntPtr pView)
	{
		try
		{
			externalTransform1(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, Helpers.GetRXObject<OdGsMatrixParam>(xForm, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexternalTransform__SWIG_0(IntPtr path, bool bDoIt, IntPtr xForm)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false), bDoIt, Helpers.GetRXObject<OdGsMatrixParam>(xForm, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexternalTransform__SWIG_1(IntPtr path, bool bDoIt)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false), bDoIt);
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

	private void SwigDirectorMethodexternalTransform__SWIG_2(IntPtr path)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false));
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

	private void SwigDirectorMethodexternalTransform2(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm, IntPtr pView)
	{
		try
		{
			externalTransform2(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, Helpers.GetRXObject<OdGsMatrixParam>(xForm, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexternalTransform__SWIG_3(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt, IntPtr xForm)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt, Helpers.GetRXObject<OdGsMatrixParam>(xForm, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodexternalTransform__SWIG_4(IntPtr path, IntPtr pMarkers, uint nMarkers, bool bDoIt)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers, bDoIt);
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

	private void SwigDirectorMethodexternalTransform__SWIG_5(IntPtr path, IntPtr pMarkers, uint nMarkers)
	{
		try
		{
			externalTransform(new OdGiPathNode(path, cMemoryOwn: false), Helpers.UnMarshalIntPtrFixedArray(pMarkers), nMarkers);
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

	private bool SwigDirectorMethodgetExternalTransform__SWIG_0(IntPtr path, IntPtr xForm, IntPtr pView)
	{
		OdGsMatrixParam xForm2 = new OdGsMatrixParam(xForm, cMemoryOwn: true);
		return getExternalTransform(new OdGiPathNode(path, cMemoryOwn: false), xForm2, Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodgetExternalTransform__SWIG_1(IntPtr path, IntPtr xForm)
	{
		OdGsMatrixParam xForm2 = new OdGsMatrixParam(xForm, cMemoryOwn: true);
		return getExternalTransform(new OdGiPathNode(path, cMemoryOwn: false), xForm2);
	}

	private void SwigDirectorMethodsetRenderType(int renderType)
	{
		try
		{
			setRenderType((OdGsModel_RenderType)renderType);
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

	private int SwigDirectorMethodrenderType()
	{
		return (int)renderType();
	}

	private void SwigDirectorMethodsetRenderModeOverride__SWIG_0(int mode)
	{
		try
		{
			setRenderModeOverride((OdGsView_RenderMode)mode);
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

	private void SwigDirectorMethodsetRenderModeOverride__SWIG_1()
	{
		try
		{
			setRenderModeOverride();
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

	private int SwigDirectorMethodrenderModeOverride()
	{
		return (int)renderModeOverride();
	}

	private void SwigDirectorMethodsetViewClippingOverride(bool bEnable)
	{
		try
		{
			setViewClippingOverride(bEnable);
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

	private bool SwigDirectorMethodviewClippingOverride()
	{
		return viewClippingOverride();
	}

	private void SwigDirectorMethodsetBackground(IntPtr backgroundId)
	{
		try
		{
			setBackground((backgroundId == IntPtr.Zero) ? null : new OdDbStub(backgroundId, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodbackground()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(background()).Handle;
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

	private void SwigDirectorMethodsetVisualStyle1(IntPtr visualStyleId)
	{
		try
		{
			setVisualStyle1((visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodvisualStyle1()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(visualStyle1()).Handle;
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

	private void SwigDirectorMethodsetVisualStyle2(IntPtr visualStyle)
	{
		try
		{
			setVisualStyle2(Helpers.GetRXObject<OdGiVisualStyle>(visualStyle, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodVisualStyle2(IntPtr visualStyle)
	{
		OdSwigDirectorHelper.director_UnpackData(visualStyle, out var pOriginalObject, out var pFunction);
		OdGiVisualStyle visualStyle2 = Helpers.GetRXObject<OdGiVisualStyle>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return VisualStyle2(ref visualStyle2);
		}
		finally
		{
			IntPtr handle = OdGiVisualStyle.getCPtr(visualStyle2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(visualStyle);
		}
	}

	private void SwigDirectorMethodaddModelReactor(IntPtr pReactor)
	{
		try
		{
			addModelReactor((pReactor == IntPtr.Zero) ? null : new OdGsModelReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethodremoveModelReactor(IntPtr pReactor)
	{
		try
		{
			removeModelReactor((pReactor == IntPtr.Zero) ? null : new OdGsModelReactor(pReactor, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetEnableSectioning(bool bEnable)
	{
		try
		{
			setEnableSectioning(bEnable);
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

	private bool SwigDirectorMethodisSectioningEnabled()
	{
		return isSectioningEnabled();
	}

	private bool SwigDirectorMethodsetSectioning1(IntPtr points, IntPtr upVector)
	{
		return setSectioning1(new OdGePoint3dArray(points, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodsetSectioning2(IntPtr points, IntPtr upVector, double dTop, double dBottom)
	{
		return setSectioning2(new OdGePoint3dArray(points, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), dTop, dBottom);
	}

	private void SwigDirectorMethodsetSectioningVisualStyle(IntPtr visualStyleId)
	{
		try
		{
			setSectioningVisualStyle((visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetEnableLinetypes(bool bEnable)
	{
		try
		{
			setEnableLinetypes(bEnable);
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

	private bool SwigDirectorMethodisLinetypesEnabled()
	{
		return isLinetypesEnabled();
	}

	private void SwigDirectorMethodsetSelectable(bool bEnable)
	{
		try
		{
			setSelectable(bEnable);
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

	private bool SwigDirectorMethodisSelectable()
	{
		return isSelectable();
	}

	private void SwigDirectorMethodsetEnableViewExtentsCalculation(bool bEnable)
	{
		try
		{
			setEnableViewExtentsCalculation(bEnable);
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

	private bool SwigDirectorMethodisViewExtentsCalculationEnabled()
	{
		return isViewExtentsCalculationEnabled();
	}

	private void SwigDirectorMethodsetEnableLightsInBlocks(bool bEnable)
	{
		try
		{
			setEnableLightsInBlocks(bEnable);
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

	private bool SwigDirectorMethodisLightsInBlocksEnabled()
	{
		return isLightsInBlocksEnabled();
	}

	private void SwigDirectorMethodsetViewSectioningOverride(bool bEnable)
	{
		try
		{
			setViewSectioningOverride(bEnable);
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

	private bool SwigDirectorMethodviewSectioningOverride()
	{
		return viewSectioningOverride();
	}
}
