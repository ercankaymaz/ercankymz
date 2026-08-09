using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbLayoutManager : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbLayoutManager_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbLayoutManager_1();

	public delegate void SwigDelegateOdDbLayoutManager_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbLayoutManager_3(IntPtr pDb, IntPtr layoutId);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLayoutManager_4(IntPtr pDb, bool allowModel);

	public delegate IntPtr SwigDelegateOdDbLayoutManager_5(IntPtr pDb);

	public delegate IntPtr SwigDelegateOdDbLayoutManager_6(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate void SwigDelegateOdDbLayoutManager_7(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string delname);

	public delegate IntPtr SwigDelegateOdDbLayoutManager_8(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string newname, IntPtr pBlockTableRecId);

	public delegate IntPtr SwigDelegateOdDbLayoutManager_9(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string newname);

	public delegate void SwigDelegateOdDbLayoutManager_10(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string oldname, [MarshalAs(UnmanagedType.LPWStr)] string newname);

	public delegate IntPtr SwigDelegateOdDbLayoutManager_11(IntPtr pDb, IntPtr pLayout, [MarshalAs(UnmanagedType.LPWStr)] string newname, int newTabOrder);

	public delegate IntPtr SwigDelegateOdDbLayoutManager_12(IntPtr pDb, IntPtr pLayout, [MarshalAs(UnmanagedType.LPWStr)] string newname);

	public delegate IntPtr SwigDelegateOdDbLayoutManager_13(IntPtr clipId);

	public delegate bool SwigDelegateOdDbLayoutManager_14(IntPtr pDb, int index);

	public delegate int SwigDelegateOdDbLayoutManager_15(IntPtr pDb);

	public delegate void SwigDelegateOdDbLayoutManager_16(IntPtr newObj);

	public delegate void SwigDelegateOdDbLayoutManager_17(IntPtr delObj);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbLayoutManager_0 swigDelegate0;

	private SwigDelegateOdDbLayoutManager_1 swigDelegate1;

	private SwigDelegateOdDbLayoutManager_2 swigDelegate2;

	private SwigDelegateOdDbLayoutManager_3 swigDelegate3;

	private SwigDelegateOdDbLayoutManager_4 swigDelegate4;

	private SwigDelegateOdDbLayoutManager_5 swigDelegate5;

	private SwigDelegateOdDbLayoutManager_6 swigDelegate6;

	private SwigDelegateOdDbLayoutManager_7 swigDelegate7;

	private SwigDelegateOdDbLayoutManager_8 swigDelegate8;

	private SwigDelegateOdDbLayoutManager_9 swigDelegate9;

	private SwigDelegateOdDbLayoutManager_10 swigDelegate10;

	private SwigDelegateOdDbLayoutManager_11 swigDelegate11;

	private SwigDelegateOdDbLayoutManager_12 swigDelegate12;

	private SwigDelegateOdDbLayoutManager_13 swigDelegate13;

	private SwigDelegateOdDbLayoutManager_14 swigDelegate14;

	private SwigDelegateOdDbLayoutManager_15 swigDelegate15;

	private SwigDelegateOdDbLayoutManager_16 swigDelegate16;

	private SwigDelegateOdDbLayoutManager_17 swigDelegate17;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(string)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(string)
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(string)
	};

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes11 = new Type[4]
	{
		typeof(OdDbDatabase),
		typeof(OdDbLayout),
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes12 = new Type[3]
	{
		typeof(OdDbDatabase),
		typeof(OdDbLayout),
		typeof(string)
	};

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(OdDbDatabase),
		typeof(int)
	};

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDbDatabase) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbLayoutManagerReactor) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdDbLayoutManagerReactor) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLayoutManager(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLayoutManager obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbLayoutManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbLayoutManager cast(OdRxObject pObj)
	{
		OdDbLayoutManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayoutManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_isASwigExplicitOdDbLayoutManager(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_queryXSwigExplicitOdDbLayoutManager(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setCurrentLayout(OdDbDatabase pDb, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("setCurrentLayout", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_setCurrentLayoutSwigExplicitOdDbLayoutManager(swigCPtr, OdDbDatabase.getCPtr(pDb), OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_setCurrentLayout(swigCPtr, OdDbDatabase.getCPtr(pDb), OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string findActiveLayout(OdDbDatabase pDb, bool allowModel)
	{
		string result = (SwigDerivedClassHasMethod("findActiveLayout", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_findActiveLayoutSwigExplicitOdDbLayoutManager(swigCPtr, OdDbDatabase.getCPtr(pDb), allowModel) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_findActiveLayout(swigCPtr, OdDbDatabase.getCPtr(pDb), allowModel));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getActiveLayoutBTRId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("getActiveLayoutBTRId", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_getActiveLayoutBTRIdSwigExplicitOdDbLayoutManager(swigCPtr, OdDbDatabase.getCPtr(pDb)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_getActiveLayoutBTRId(swigCPtr, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId findLayoutNamed(OdDbDatabase pDb, string name)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("findLayoutNamed", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_findLayoutNamedSwigExplicitOdDbLayoutManager(swigCPtr, OdDbDatabase.getCPtr(pDb), name) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_findLayoutNamed(swigCPtr, OdDbDatabase.getCPtr(pDb), name), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void deleteLayout(OdDbDatabase pDb, string delname)
	{
		if (SwigDerivedClassHasMethod("deleteLayout", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_deleteLayoutSwigExplicitOdDbLayoutManager(swigCPtr, OdDbDatabase.getCPtr(pDb), delname);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_deleteLayout(swigCPtr, OdDbDatabase.getCPtr(pDb), delname);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId createLayout(OdDbDatabase pDb, string newname, OdDbObjectId pBlockTableRecId)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("createLayout", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_createLayoutSwigExplicitOdDbLayoutManager__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pDb), newname, OdDbObjectId.getCPtr(pBlockTableRecId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_createLayout__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pDb), newname, OdDbObjectId.getCPtr(pBlockTableRecId)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId createLayout(OdDbDatabase pDb, string newname)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("createLayout", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_createLayoutSwigExplicitOdDbLayoutManager__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pDb), newname) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_createLayout__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pDb), newname), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void renameLayout(OdDbDatabase pDb, string oldname, string newname)
	{
		if (SwigDerivedClassHasMethod("renameLayout", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_renameLayoutSwigExplicitOdDbLayoutManager(swigCPtr, OdDbDatabase.getCPtr(pDb), oldname, newname);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_renameLayout(swigCPtr, OdDbDatabase.getCPtr(pDb), oldname, newname);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId cloneLayout(OdDbDatabase pDb, OdDbLayout pLayout, string newname, int newTabOrder)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("cloneLayout", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_cloneLayoutSwigExplicitOdDbLayoutManager__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pDb), OdDbLayout.getCPtr(pLayout), newname, newTabOrder) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_cloneLayout__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pDb), OdDbLayout.getCPtr(pLayout), newname, newTabOrder), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId cloneLayout(OdDbDatabase pDb, OdDbLayout pLayout, string newname)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("cloneLayout", swigMethodTypes12) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_cloneLayoutSwigExplicitOdDbLayoutManager__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pDb), OdDbLayout.getCPtr(pLayout), newname) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_cloneLayout__SWIG_1(swigCPtr, OdDbDatabase.getCPtr(pDb), OdDbLayout.getCPtr(pLayout), newname), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getNonRectVPIdFromClipId(OdDbObjectId clipId)
	{
		OdDbObjectId result = new OdDbObjectId(SwigDerivedClassHasMethod("getNonRectVPIdFromClipId", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_getNonRectVPIdFromClipIdSwigExplicitOdDbLayoutManager(swigCPtr, OdDbObjectId.getCPtr(clipId)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_getNonRectVPIdFromClipId(swigCPtr, OdDbObjectId.getCPtr(clipId)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isVpnumClipped(OdDbDatabase pDb, int index)
	{
		bool result = (SwigDerivedClassHasMethod("isVpnumClipped", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_isVpnumClippedSwigExplicitOdDbLayoutManager(swigCPtr, OdDbDatabase.getCPtr(pDb), index) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_isVpnumClipped(swigCPtr, OdDbDatabase.getCPtr(pDb), index));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int countLayouts(OdDbDatabase pDb)
	{
		int result = (SwigDerivedClassHasMethod("countLayouts", swigMethodTypes15) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_countLayoutsSwigExplicitOdDbLayoutManager(swigCPtr, OdDbDatabase.getCPtr(pDb)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_countLayouts(swigCPtr, OdDbDatabase.getCPtr(pDb)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addReactor(OdDbLayoutManagerReactor newObj)
	{
		if (SwigDerivedClassHasMethod("addReactor", swigMethodTypes16))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_addReactorSwigExplicitOdDbLayoutManager(swigCPtr, OdDbLayoutManagerReactor.getCPtr(newObj));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_addReactor(swigCPtr, OdDbLayoutManagerReactor.getCPtr(newObj));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeReactor(OdDbLayoutManagerReactor delObj)
	{
		if (SwigDerivedClassHasMethod("removeReactor", swigMethodTypes17))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_removeReactorSwigExplicitOdDbLayoutManager(swigCPtr, OdDbLayoutManagerReactor.getCPtr(delObj));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_removeReactor(swigCPtr, OdDbLayoutManagerReactor.getCPtr(delObj));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void fireLayoutsReordered()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_fireLayoutsReordered(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbLayoutManager createObject()
	{
		OdDbLayoutManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayoutManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("setCurrentLayout", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetCurrentLayout;
		}
		if (SwigDerivedClassHasMethod("findActiveLayout", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodfindActiveLayout;
		}
		if (SwigDerivedClassHasMethod("getActiveLayoutBTRId", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetActiveLayoutBTRId;
		}
		if (SwigDerivedClassHasMethod("findLayoutNamed", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodfindLayoutNamed;
		}
		if (SwigDerivedClassHasMethod("deleteLayout", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddeleteLayout;
		}
		if (SwigDerivedClassHasMethod("createLayout", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcreateLayout__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createLayout", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcreateLayout__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("renameLayout", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodrenameLayout;
		}
		if (SwigDerivedClassHasMethod("cloneLayout", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcloneLayout__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("cloneLayout", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodcloneLayout__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getNonRectVPIdFromClipId", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetNonRectVPIdFromClipId;
		}
		if (SwigDerivedClassHasMethod("isVpnumClipped", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodisVpnumClipped;
		}
		if (SwigDerivedClassHasMethod("countLayouts", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodcountLayouts;
		}
		if (SwigDerivedClassHasMethod("addReactor", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodaddReactor;
		}
		if (SwigDerivedClassHasMethod("removeReactor", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodremoveReactor;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManager_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbLayoutManager));
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

	private void SwigDirectorMethodsetCurrentLayout(IntPtr pDb, IntPtr layoutId)
	{
		try
		{
			setCurrentLayout(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfindActiveLayout(IntPtr pDb, bool allowModel)
	{
		return findActiveLayout(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), allowModel);
	}

	private IntPtr SwigDirectorMethodgetActiveLayoutBTRId(IntPtr pDb)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(getActiveLayoutBTRId(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodfindLayoutNamed(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(findLayoutNamed(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), name)).Handle;
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

	private void SwigDirectorMethoddeleteLayout(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string delname)
	{
		try
		{
			deleteLayout(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), delname);
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

	private IntPtr SwigDirectorMethodcreateLayout__SWIG_0(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string newname, IntPtr pBlockTableRecId)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(createLayout(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), newname, (pBlockTableRecId == IntPtr.Zero) ? null : new OdDbObjectId(pBlockTableRecId, cMemoryOwn: false))).Handle;
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

	private IntPtr SwigDirectorMethodcreateLayout__SWIG_1(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string newname)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(createLayout(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), newname)).Handle;
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

	private void SwigDirectorMethodrenameLayout(IntPtr pDb, [MarshalAs(UnmanagedType.LPWStr)] string oldname, [MarshalAs(UnmanagedType.LPWStr)] string newname)
	{
		try
		{
			renameLayout(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), oldname, newname);
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

	private IntPtr SwigDirectorMethodcloneLayout__SWIG_0(IntPtr pDb, IntPtr pLayout, [MarshalAs(UnmanagedType.LPWStr)] string newname, int newTabOrder)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(cloneLayout(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayout>(pLayout, bOwn: false, bTryAddToTransaction: false), newname, newTabOrder)).Handle;
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

	private IntPtr SwigDirectorMethodcloneLayout__SWIG_1(IntPtr pDb, IntPtr pLayout, [MarshalAs(UnmanagedType.LPWStr)] string newname)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(cloneLayout(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayout>(pLayout, bOwn: false, bTryAddToTransaction: false), newname)).Handle;
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

	private IntPtr SwigDirectorMethodgetNonRectVPIdFromClipId(IntPtr clipId)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(getNonRectVPIdFromClipId(new OdDbObjectId(clipId, cMemoryOwn: false))).Handle;
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

	private bool SwigDirectorMethodisVpnumClipped(IntPtr pDb, int index)
	{
		return isVpnumClipped(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false), index);
	}

	private int SwigDirectorMethodcountLayouts(IntPtr pDb)
	{
		return countLayouts(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(pDb, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodaddReactor(IntPtr newObj)
	{
		try
		{
			addReactor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayoutManagerReactor>(newObj, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodremoveReactor(IntPtr delObj)
	{
		try
		{
			removeReactor(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayoutManagerReactor>(delObj, bOwn: false, bTryAddToTransaction: false));
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
