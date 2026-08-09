using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdGsLayoutHelper : OdGsDevice
{
	public delegate IntPtr SwigDelegateOdGsLayoutHelper_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_1();

	public delegate void SwigDelegateOdGsLayoutHelper_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_3();

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_4();

	public delegate void SwigDelegateOdGsLayoutHelper_5(IntPtr pUserGiContext);

	public delegate void SwigDelegateOdGsLayoutHelper_6();

	public delegate void SwigDelegateOdGsLayoutHelper_7(IntPtr screenRect);

	public delegate bool SwigDelegateOdGsLayoutHelper_8();

	public delegate void SwigDelegateOdGsLayoutHelper_9(IntPtr pUpdatedRect);

	public delegate void SwigDelegateOdGsLayoutHelper_10();

	public delegate void SwigDelegateOdGsLayoutHelper_11(IntPtr outputRect);

	public delegate void SwigDelegateOdGsLayoutHelper_12(IntPtr outputRect);

	public delegate void SwigDelegateOdGsLayoutHelper_13(IntPtr outputRect);

	public delegate void SwigDelegateOdGsLayoutHelper_14(IntPtr outputRect);

	public delegate void SwigDelegateOdGsLayoutHelper_15();

	public delegate void SwigDelegateOdGsLayoutHelper_16();

	public delegate void SwigDelegateOdGsLayoutHelper_17(int bitsPerPixel, int xPixels, int yPixels);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_18(IntPtr pViewInfo, bool enableLayerVisibilityPerView);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_19(IntPtr pViewInfo);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_20();

	public delegate void SwigDelegateOdGsLayoutHelper_21(IntPtr pView);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_22();

	public delegate bool SwigDelegateOdGsLayoutHelper_23(IntPtr pModel);

	public delegate bool SwigDelegateOdGsLayoutHelper_24(IntPtr pFiler);

	public delegate bool SwigDelegateOdGsLayoutHelper_25(IntPtr pFiler);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_26();

	public delegate void SwigDelegateOdGsLayoutHelper_27(int viewIndex, IntPtr pView);

	public delegate bool SwigDelegateOdGsLayoutHelper_28(IntPtr pView);

	public delegate bool SwigDelegateOdGsLayoutHelper_29(int viewIndex);

	public delegate void SwigDelegateOdGsLayoutHelper_30();

	public delegate int SwigDelegateOdGsLayoutHelper_31();

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_32(int viewIndex);

	public delegate bool SwigDelegateOdGsLayoutHelper_33(uint backgroundColor);

	public delegate uint SwigDelegateOdGsLayoutHelper_34();

	public delegate void SwigDelegateOdGsLayoutHelper_35(IntPtr logicalPalette, int numColors);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_36(int numColors);

	public delegate void SwigDelegateOdGsLayoutHelper_37(IntPtr pImage, IntPtr region);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_38(bool createIfNotExist);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_39();

	public delegate void SwigDelegateOdGsLayoutHelper_40(IntPtr pManager);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_41();

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_42();

	public delegate void SwigDelegateOdGsLayoutHelper_43(IntPtr pView);

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_44();

	public delegate IntPtr SwigDelegateOdGsLayoutHelper_45();

	public delegate bool SwigDelegateOdGsLayoutHelper_46(IntPtr screenPt);

	public delegate bool SwigDelegateOdGsLayoutHelper_47(IntPtr id);

	public delegate void SwigDelegateOdGsLayoutHelper_48();

	public delegate bool SwigDelegateOdGsLayoutHelper_49();

	public delegate bool SwigDelegateOdGsLayoutHelper_50(IntPtr pStream, uint nFlags);

	public delegate bool SwigDelegateOdGsLayoutHelper_51(IntPtr pStream);

	public delegate bool SwigDelegateOdGsLayoutHelper_52(IntPtr pStream, uint nFlags);

	public delegate bool SwigDelegateOdGsLayoutHelper_53(IntPtr pStream);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsLayoutHelper_0 swigDelegate0;

	private SwigDelegateOdGsLayoutHelper_1 swigDelegate1;

	private SwigDelegateOdGsLayoutHelper_2 swigDelegate2;

	private SwigDelegateOdGsLayoutHelper_3 swigDelegate3;

	private SwigDelegateOdGsLayoutHelper_4 swigDelegate4;

	private SwigDelegateOdGsLayoutHelper_5 swigDelegate5;

	private SwigDelegateOdGsLayoutHelper_6 swigDelegate6;

	private SwigDelegateOdGsLayoutHelper_7 swigDelegate7;

	private SwigDelegateOdGsLayoutHelper_8 swigDelegate8;

	private SwigDelegateOdGsLayoutHelper_9 swigDelegate9;

	private SwigDelegateOdGsLayoutHelper_10 swigDelegate10;

	private SwigDelegateOdGsLayoutHelper_11 swigDelegate11;

	private SwigDelegateOdGsLayoutHelper_12 swigDelegate12;

	private SwigDelegateOdGsLayoutHelper_13 swigDelegate13;

	private SwigDelegateOdGsLayoutHelper_14 swigDelegate14;

	private SwigDelegateOdGsLayoutHelper_15 swigDelegate15;

	private SwigDelegateOdGsLayoutHelper_16 swigDelegate16;

	private SwigDelegateOdGsLayoutHelper_17 swigDelegate17;

	private SwigDelegateOdGsLayoutHelper_18 swigDelegate18;

	private SwigDelegateOdGsLayoutHelper_19 swigDelegate19;

	private SwigDelegateOdGsLayoutHelper_20 swigDelegate20;

	private SwigDelegateOdGsLayoutHelper_21 swigDelegate21;

	private SwigDelegateOdGsLayoutHelper_22 swigDelegate22;

	private SwigDelegateOdGsLayoutHelper_23 swigDelegate23;

	private SwigDelegateOdGsLayoutHelper_24 swigDelegate24;

	private SwigDelegateOdGsLayoutHelper_25 swigDelegate25;

	private SwigDelegateOdGsLayoutHelper_26 swigDelegate26;

	private SwigDelegateOdGsLayoutHelper_27 swigDelegate27;

	private SwigDelegateOdGsLayoutHelper_28 swigDelegate28;

	private SwigDelegateOdGsLayoutHelper_29 swigDelegate29;

	private SwigDelegateOdGsLayoutHelper_30 swigDelegate30;

	private SwigDelegateOdGsLayoutHelper_31 swigDelegate31;

	private SwigDelegateOdGsLayoutHelper_32 swigDelegate32;

	private SwigDelegateOdGsLayoutHelper_33 swigDelegate33;

	private SwigDelegateOdGsLayoutHelper_34 swigDelegate34;

	private SwigDelegateOdGsLayoutHelper_35 swigDelegate35;

	private SwigDelegateOdGsLayoutHelper_36 swigDelegate36;

	private SwigDelegateOdGsLayoutHelper_37 swigDelegate37;

	private SwigDelegateOdGsLayoutHelper_38 swigDelegate38;

	private SwigDelegateOdGsLayoutHelper_39 swigDelegate39;

	private SwigDelegateOdGsLayoutHelper_40 swigDelegate40;

	private SwigDelegateOdGsLayoutHelper_41 swigDelegate41;

	private SwigDelegateOdGsLayoutHelper_42 swigDelegate42;

	private SwigDelegateOdGsLayoutHelper_43 swigDelegate43;

	private SwigDelegateOdGsLayoutHelper_44 swigDelegate44;

	private SwigDelegateOdGsLayoutHelper_45 swigDelegate45;

	private SwigDelegateOdGsLayoutHelper_46 swigDelegate46;

	private SwigDelegateOdGsLayoutHelper_47 swigDelegate47;

	private SwigDelegateOdGsLayoutHelper_48 swigDelegate48;

	private SwigDelegateOdGsLayoutHelper_49 swigDelegate49;

	private SwigDelegateOdGsLayoutHelper_50 swigDelegate50;

	private SwigDelegateOdGsLayoutHelper_51 swigDelegate51;

	private SwigDelegateOdGsLayoutHelper_52 swigDelegate52;

	private SwigDelegateOdGsLayoutHelper_53 swigDelegate53;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiContext) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdGsDCRectDouble) };

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGsDCRect) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGsDCRectDouble) };

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[3]
	{
		typeof(int),
		typeof(int),
		typeof(int)
	};

	private static Type[] swigMethodTypes18 = new Type[2]
	{
		typeof(OdGsClientViewInfo),
		typeof(bool)
	};

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdGsClientViewInfo) };

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdGsModel) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(OdGsFilerGSS) };

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(int),
		typeof(OdGsView)
	};

	private static Type[] swigMethodTypes28 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[1] { typeof(int) };

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[2]
	{
		typeof(uint[]),
		typeof(int)
	};

	private static Type[] swigMethodTypes36 = new Type[1] { typeof(int).MakeByRefType() };

	private static Type[] swigMethodTypes37 = new Type[2]
	{
		typeof(OdGiRasterImage).MakeByRefType(),
		typeof(OdGsDCRect)
	};

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdGsUpdateManager) };

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(OdGsView) };

	private static Type[] swigMethodTypes44 = new Type[0];

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(OdGePoint2d) };

	private static Type[] swigMethodTypes47 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[0];

	private static Type[] swigMethodTypes50 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(uint)
	};

	private static Type[] swigMethodTypes51 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes52 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(uint)
	};

	private static Type[] swigMethodTypes53 = new Type[1] { typeof(OdStreamBuf) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsLayoutHelper(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsLayoutHelper obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdGsLayoutHelper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsLayoutHelper cast(OdRxObject pObj)
	{
		OdGsLayoutHelper rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsLayoutHelper>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_isASwigExplicitOdGsLayoutHelper(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_queryXSwigExplicitOdGsLayoutHelper(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsLayoutHelper createObject()
	{
		OdGsLayoutHelper rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsLayoutHelper>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbObjectId layoutId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_layoutId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsView activeView()
	{
		OdGsView rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_activeView(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void makeViewActive(OdGsView pView)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_makeViewActive(swigCPtr, OdGsView.getCPtr(pView));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsModel gsModel()
	{
		OdGsModel rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsModel>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_gsModel(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsDevice underlyingDevice()
	{
		OdGsDevice rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsDevice>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_underlyingDevice(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool setActiveViewport(OdGePoint2d screenPt)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_setActiveViewport__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(screenPt));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setActiveViewport(OdDbObjectId id)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_setActiveViewport__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(id));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void restoreGsViewDbLinkState()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_restoreGsViewDbLinkState(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool supportLayoutGsStateSaving()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_supportLayoutGsStateSaving(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool storeLayoutGsState(OdStreamBuf pStream, uint nFlags)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_storeLayoutGsState__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStream), nFlags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool storeLayoutGsState(OdStreamBuf pStream)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_storeLayoutGsState__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStream));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool extractLayoutIdForGsState(OdStreamBuf pStream, OdDbDatabase pDb, OdDbObjectId layoutObjId, uint nFlags)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_extractLayoutIdForGsState__SWIG_0(OdStreamBuf.getCPtr(pStream), OdDbDatabase.getCPtr(pDb), OdDbObjectId.getCPtr(layoutObjId), nFlags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool extractLayoutIdForGsState(OdStreamBuf pStream, OdDbDatabase pDb, OdDbObjectId layoutObjId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_extractLayoutIdForGsState__SWIG_1(OdStreamBuf.getCPtr(pStream), OdDbDatabase.getCPtr(pDb), OdDbObjectId.getCPtr(layoutObjId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool restoreLayoutGsState(OdStreamBuf pStream, uint nFlags)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_restoreLayoutGsState__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStream), nFlags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool restoreLayoutGsState(OdStreamBuf pStream)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_restoreLayoutGsState__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStream));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsLayoutHelper()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdGsLayoutHelper(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsLayoutHelper) != GetType();
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
		if (SwigDerivedClassHasMethod("properties", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodproperties;
		}
		if (SwigDerivedClassHasMethod("userGiContext", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoduserGiContext;
		}
		if (SwigDerivedClassHasMethod("setUserGiContext", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetUserGiContext;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodinvalidate__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("invalidate", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodinvalidate__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isValid", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodisValid;
		}
		if (SwigDerivedClassHasMethod("update", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodupdate__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("update", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodupdate__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("onSize", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodonSize__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("onSize", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodonSize__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getSize", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetSize__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getSize", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetSize__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("onRealizeForegroundPalette", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodonRealizeForegroundPalette;
		}
		if (SwigDerivedClassHasMethod("onRealizeBackgroundPalette", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodonRealizeBackgroundPalette;
		}
		if (SwigDerivedClassHasMethod("onDisplayChange", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodonDisplayChange;
		}
		if (SwigDerivedClassHasMethod("createView", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodcreateView__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createView", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodcreateView__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createView", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodcreateView__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("addView", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodaddView;
		}
		if (SwigDerivedClassHasMethod("createModel", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodcreateModel;
		}
		if (SwigDerivedClassHasMethod("isModelCompatible", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodisModelCompatible;
		}
		if (SwigDerivedClassHasMethod("saveDeviceState", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsaveDeviceState;
		}
		if (SwigDerivedClassHasMethod("loadDeviceState", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodloadDeviceState;
		}
		if (SwigDerivedClassHasMethod("gsFilerDeviceInterface", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodgsFilerDeviceInterface;
		}
		if (SwigDerivedClassHasMethod("insertView", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodinsertView;
		}
		if (SwigDerivedClassHasMethod("eraseView", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethoderaseView__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("eraseView", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethoderaseView__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("eraseAllViews", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethoderaseAllViews;
		}
		if (SwigDerivedClassHasMethod("numViews", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodnumViews;
		}
		if (SwigDerivedClassHasMethod("viewAt", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodviewAt;
		}
		if (SwigDerivedClassHasMethod("setBackgroundColor", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodsetBackgroundColor;
		}
		if (SwigDerivedClassHasMethod("getBackgroundColor", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodgetBackgroundColor;
		}
		if (SwigDerivedClassHasMethod("setLogicalPalette", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodsetLogicalPalette;
		}
		if (SwigDerivedClassHasMethod("getLogicalPalette", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodgetLogicalPalette;
		}
		if (SwigDerivedClassHasMethod("getSnapShot", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodgetSnapShot;
		}
		if (SwigDerivedClassHasMethod("getUpdateManager", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodgetUpdateManager__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getUpdateManager", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodgetUpdateManager__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setUpdateManager", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodsetUpdateManager;
		}
		if (SwigDerivedClassHasMethod("layoutId", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodlayoutId;
		}
		if (SwigDerivedClassHasMethod("activeView", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodactiveView;
		}
		if (SwigDerivedClassHasMethod("makeViewActive", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodmakeViewActive;
		}
		if (SwigDerivedClassHasMethod("gsModel", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodgsModel;
		}
		if (SwigDerivedClassHasMethod("underlyingDevice", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodunderlyingDevice;
		}
		if (SwigDerivedClassHasMethod("setActiveViewport", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodsetActiveViewport__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setActiveViewport", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodsetActiveViewport__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("restoreGsViewDbLinkState", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodrestoreGsViewDbLinkState;
		}
		if (SwigDerivedClassHasMethod("supportLayoutGsStateSaving", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodsupportLayoutGsStateSaving;
		}
		if (SwigDerivedClassHasMethod("storeLayoutGsState", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodstoreLayoutGsState__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("storeLayoutGsState", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodstoreLayoutGsState__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("restoreLayoutGsState", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodrestoreLayoutGsState__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("restoreLayoutGsState", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodrestoreLayoutGsState__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdGsLayoutHelper_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsLayoutHelper));
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

	private IntPtr SwigDirectorMethodproperties()
	{
		return OdRxDictionary.getCPtr(properties()).Handle;
	}

	private IntPtr SwigDirectorMethoduserGiContext()
	{
		return OdGiContext.getCPtr(userGiContext()).Handle;
	}

	private void SwigDirectorMethodsetUserGiContext(IntPtr pUserGiContext)
	{
		try
		{
			setUserGiContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiContext>(pUserGiContext, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodinvalidate__SWIG_0()
	{
		try
		{
			invalidate();
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

	private void SwigDirectorMethodinvalidate__SWIG_1(IntPtr screenRect)
	{
		try
		{
			invalidate(new OdGsDCRect(screenRect, cMemoryOwn: false));
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

	private bool SwigDirectorMethodisValid()
	{
		return isValid();
	}

	private void SwigDirectorMethodupdate__SWIG_0(IntPtr pUpdatedRect)
	{
		try
		{
			update((pUpdatedRect == IntPtr.Zero) ? null : new OdGsDCRect(pUpdatedRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodupdate__SWIG_1()
	{
		try
		{
			update();
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

	private void SwigDirectorMethodonSize__SWIG_0(IntPtr outputRect)
	{
		try
		{
			onSize(new OdGsDCRect(outputRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodonSize__SWIG_1(IntPtr outputRect)
	{
		try
		{
			onSize(new OdGsDCRectDouble(outputRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetSize__SWIG_0(IntPtr outputRect)
	{
		try
		{
			getSize(new OdGsDCRect(outputRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetSize__SWIG_1(IntPtr outputRect)
	{
		try
		{
			getSize(new OdGsDCRectDouble(outputRect, cMemoryOwn: false));
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

	private void SwigDirectorMethodonRealizeForegroundPalette()
	{
		try
		{
			onRealizeForegroundPalette();
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

	private void SwigDirectorMethodonRealizeBackgroundPalette()
	{
		try
		{
			onRealizeBackgroundPalette();
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

	private void SwigDirectorMethodonDisplayChange(int bitsPerPixel, int xPixels, int yPixels)
	{
		try
		{
			onDisplayChange(bitsPerPixel, xPixels, yPixels);
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

	private IntPtr SwigDirectorMethodcreateView__SWIG_0(IntPtr pViewInfo, bool enableLayerVisibilityPerView)
	{
		return OdGsView.getCPtr(createView((pViewInfo == IntPtr.Zero) ? null : new OdGsClientViewInfo(pViewInfo, cMemoryOwn: false), enableLayerVisibilityPerView)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateView__SWIG_1(IntPtr pViewInfo)
	{
		return OdGsView.getCPtr(createView((pViewInfo == IntPtr.Zero) ? null : new OdGsClientViewInfo(pViewInfo, cMemoryOwn: false))).Handle;
	}

	private IntPtr SwigDirectorMethodcreateView__SWIG_2()
	{
		return OdGsView.getCPtr(createView()).Handle;
	}

	private void SwigDirectorMethodaddView(IntPtr pView)
	{
		try
		{
			addView(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodcreateModel()
	{
		return OdGsModel.getCPtr(createModel()).Handle;
	}

	private bool SwigDirectorMethodisModelCompatible(IntPtr pModel)
	{
		return isModelCompatible(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsaveDeviceState(IntPtr pFiler)
	{
		return saveDeviceState(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodloadDeviceState(IntPtr pFiler)
	{
		return loadDeviceState(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsFilerGSS>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodgsFilerDeviceInterface()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGsFilerDeviceInterface.getCPtr(gsFilerDeviceInterface()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodinsertView(int viewIndex, IntPtr pView)
	{
		try
		{
			insertView(viewIndex, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethoderaseView__SWIG_0(IntPtr pView)
	{
		return eraseView(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethoderaseView__SWIG_1(int viewIndex)
	{
		return eraseView(viewIndex);
	}

	private void SwigDirectorMethoderaseAllViews()
	{
		try
		{
			eraseAllViews();
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

	private int SwigDirectorMethodnumViews()
	{
		return numViews();
	}

	private IntPtr SwigDirectorMethodviewAt(int viewIndex)
	{
		return OdGsView.getCPtr(viewAt(viewIndex)).Handle;
	}

	private bool SwigDirectorMethodsetBackgroundColor(uint backgroundColor)
	{
		return setBackgroundColor(backgroundColor);
	}

	private uint SwigDirectorMethodgetBackgroundColor()
	{
		return getBackgroundColor();
	}

	private void SwigDirectorMethodsetLogicalPalette(IntPtr logicalPalette, int numColors)
	{
		Func<uint[]> func = delegate
		{
			IntPtr intPtr = logicalPalette;
			if (intPtr == IntPtr.Zero)
			{
				return (uint[])null;
			}
			int num = 257;
			int[] array = new int[num];
			Marshal.Copy(intPtr, array, 0, num);
			return Array.ConvertAll(array, (int in_value) => (uint)in_value);
		};
		try
		{
			setLogicalPalette(func(), numColors);
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

	private IntPtr SwigDirectorMethodgetLogicalPalette(int numColors)
	{
		return ((Func<IntPtr>)delegate
		{
			int[] array = Array.ConvertAll(getLogicalPalette(out numColors), (uint in_value) => (int)in_value);
			int num = Marshal.SizeOf(array[0]) * array.Length;
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			Marshal.Copy(array, 0, intPtr, num);
			PointerHolder.Add(intPtr);
			return intPtr;
		})();
	}

	private void SwigDirectorMethodgetSnapShot(IntPtr pImage, IntPtr region)
	{
		OdSwigDirectorHelper.director_UnpackData(pImage, out var pOriginalObject, out var pFunction);
		OdGiRasterImage pImage2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiRasterImage>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			getSnapShot(ref pImage2, new OdGsDCRect(region, cMemoryOwn: false));
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
			IntPtr handle = OdGiRasterImage.getCPtr(pImage2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pImage);
		}
	}

	private IntPtr SwigDirectorMethodgetUpdateManager__SWIG_0(bool createIfNotExist)
	{
		return OdGsUpdateManager.getCPtr(getUpdateManager(createIfNotExist)).Handle;
	}

	private IntPtr SwigDirectorMethodgetUpdateManager__SWIG_1()
	{
		return OdGsUpdateManager.getCPtr(getUpdateManager()).Handle;
	}

	private void SwigDirectorMethodsetUpdateManager(IntPtr pManager)
	{
		try
		{
			setUpdateManager(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsUpdateManager>(pManager, bOwn: true, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodlayoutId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(layoutId()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodactiveView()
	{
		return OdGsView.getCPtr(activeView()).Handle;
	}

	private void SwigDirectorMethodmakeViewActive(IntPtr pView)
	{
		try
		{
			makeViewActive(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(pView, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodgsModel()
	{
		return OdGsModel.getCPtr(gsModel()).Handle;
	}

	private IntPtr SwigDirectorMethodunderlyingDevice()
	{
		return OdGsDevice.getCPtr(underlyingDevice()).Handle;
	}

	private bool SwigDirectorMethodsetActiveViewport__SWIG_0(IntPtr screenPt)
	{
		return setActiveViewport(new OdGePoint2d(screenPt, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodsetActiveViewport__SWIG_1(IntPtr id)
	{
		return setActiveViewport(new OdDbObjectId(id, cMemoryOwn: false));
	}

	private void SwigDirectorMethodrestoreGsViewDbLinkState()
	{
		try
		{
			restoreGsViewDbLinkState();
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

	private bool SwigDirectorMethodsupportLayoutGsStateSaving()
	{
		return supportLayoutGsStateSaving();
	}

	private bool SwigDirectorMethodstoreLayoutGsState__SWIG_0(IntPtr pStream, uint nFlags)
	{
		return storeLayoutGsState(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false), nFlags);
	}

	private bool SwigDirectorMethodstoreLayoutGsState__SWIG_1(IntPtr pStream)
	{
		return storeLayoutGsState(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodrestoreLayoutGsState__SWIG_0(IntPtr pStream, uint nFlags)
	{
		return restoreLayoutGsState(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false), nFlags);
	}

	private bool SwigDirectorMethodrestoreLayoutGsState__SWIG_1(IntPtr pStream)
	{
		return restoreLayoutGsState(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false));
	}
}
