using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbLayoutManagerReactor : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbLayoutManagerReactor_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbLayoutManagerReactor_1();

	public delegate void SwigDelegateOdDbLayoutManagerReactor_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_3([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_4([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_5([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_6([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_7([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_8([MarshalAs(UnmanagedType.LPWStr)] string oldLayoutName, IntPtr oldLayoutId, [MarshalAs(UnmanagedType.LPWStr)] string newLayoutName, IntPtr newLayoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_9([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_10([MarshalAs(UnmanagedType.LPWStr)] string oldLayoutName, [MarshalAs(UnmanagedType.LPWStr)] string newLayoutName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_11([MarshalAs(UnmanagedType.LPWStr)] string oldLayoutName, [MarshalAs(UnmanagedType.LPWStr)] string newLayoutName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_12([MarshalAs(UnmanagedType.LPWStr)] string oldLayoutName, [MarshalAs(UnmanagedType.LPWStr)] string newLayoutName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_13([MarshalAs(UnmanagedType.LPWStr)] string newLayoutName, IntPtr newLayoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_14([MarshalAs(UnmanagedType.LPWStr)] string newTableName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_15([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId);

	public delegate void SwigDelegateOdDbLayoutManagerReactor_16();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbLayoutManagerReactor_0 swigDelegate0;

	private SwigDelegateOdDbLayoutManagerReactor_1 swigDelegate1;

	private SwigDelegateOdDbLayoutManagerReactor_2 swigDelegate2;

	private SwigDelegateOdDbLayoutManagerReactor_3 swigDelegate3;

	private SwigDelegateOdDbLayoutManagerReactor_4 swigDelegate4;

	private SwigDelegateOdDbLayoutManagerReactor_5 swigDelegate5;

	private SwigDelegateOdDbLayoutManagerReactor_6 swigDelegate6;

	private SwigDelegateOdDbLayoutManagerReactor_7 swigDelegate7;

	private SwigDelegateOdDbLayoutManagerReactor_8 swigDelegate8;

	private SwigDelegateOdDbLayoutManagerReactor_9 swigDelegate9;

	private SwigDelegateOdDbLayoutManagerReactor_10 swigDelegate10;

	private SwigDelegateOdDbLayoutManagerReactor_11 swigDelegate11;

	private SwigDelegateOdDbLayoutManagerReactor_12 swigDelegate12;

	private SwigDelegateOdDbLayoutManagerReactor_13 swigDelegate13;

	private SwigDelegateOdDbLayoutManagerReactor_14 swigDelegate14;

	private SwigDelegateOdDbLayoutManagerReactor_15 swigDelegate15;

	private SwigDelegateOdDbLayoutManagerReactor_16 swigDelegate16;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes8 = new Type[4]
	{
		typeof(string),
		typeof(OdDbObjectId),
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes11 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes12 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(string),
		typeof(OdDbObjectId)
	};

	private static Type[] swigMethodTypes16 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLayoutManagerReactor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLayoutManagerReactor obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbLayoutManagerReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbLayoutManagerReactor()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbLayoutManagerReactor(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbLayoutManagerReactor cast(OdRxObject pObj)
	{
		OdDbLayoutManagerReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayoutManagerReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_isASwigExplicitOdDbLayoutManagerReactor(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_queryXSwigExplicitOdDbLayoutManagerReactor(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void layoutCreated(string layoutName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("layoutCreated", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutCreatedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutCreated(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layoutToBeRemoved(string layoutName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("layoutToBeRemoved", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutToBeRemovedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutToBeRemoved(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layoutRemoved(string layoutName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("layoutRemoved", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutRemovedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutRemoved(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortLayoutRemoved(string layoutName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("abortLayoutRemoved", swigMethodTypes6))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_abortLayoutRemovedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_abortLayoutRemoved(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layoutToBeCopied(string layoutName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("layoutToBeCopied", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutToBeCopiedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutToBeCopied(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layoutCopied(string oldLayoutName, OdDbObjectId oldLayoutId, string newLayoutName, OdDbObjectId newLayoutId)
	{
		if (SwigDerivedClassHasMethod("layoutCopied", swigMethodTypes8))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutCopiedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, oldLayoutName, OdDbObjectId.getCPtr(oldLayoutId), newLayoutName, OdDbObjectId.getCPtr(newLayoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutCopied(swigCPtr, oldLayoutName, OdDbObjectId.getCPtr(oldLayoutId), newLayoutName, OdDbObjectId.getCPtr(newLayoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortLayoutCopied(string layoutName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("abortLayoutCopied", swigMethodTypes9))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_abortLayoutCopiedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_abortLayoutCopied(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layoutToBeRenamed(string oldLayoutName, string newLayoutName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("layoutToBeRenamed", swigMethodTypes10))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutToBeRenamedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, oldLayoutName, newLayoutName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutToBeRenamed(swigCPtr, oldLayoutName, newLayoutName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layoutRenamed(string oldLayoutName, string newLayoutName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("layoutRenamed", swigMethodTypes11))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutRenamedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, oldLayoutName, newLayoutName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutRenamed(swigCPtr, oldLayoutName, newLayoutName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortLayoutRename(string oldLayoutName, string newLayoutName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("abortLayoutRename", swigMethodTypes12))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_abortLayoutRenameSwigExplicitOdDbLayoutManagerReactor(swigCPtr, oldLayoutName, newLayoutName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_abortLayoutRename(swigCPtr, oldLayoutName, newLayoutName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layoutSwitched(string newLayoutName, OdDbObjectId newLayoutId)
	{
		if (SwigDerivedClassHasMethod("layoutSwitched", swigMethodTypes13))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutSwitchedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, newLayoutName, OdDbObjectId.getCPtr(newLayoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutSwitched(swigCPtr, newLayoutName, OdDbObjectId.getCPtr(newLayoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void plotStyleTableChanged(string newTableName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("plotStyleTableChanged", swigMethodTypes14))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_plotStyleTableChangedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, newTableName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_plotStyleTableChanged(swigCPtr, newTableName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layoutToBeDeactivated(string layoutName, OdDbObjectId layoutId)
	{
		if (SwigDerivedClassHasMethod("layoutToBeDeactivated", swigMethodTypes15))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutToBeDeactivatedSwigExplicitOdDbLayoutManagerReactor(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutToBeDeactivated(swigCPtr, layoutName, OdDbObjectId.getCPtr(layoutId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void layoutsReordered()
	{
		if (SwigDerivedClassHasMethod("layoutsReordered", swigMethodTypes16))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutsReorderedSwigExplicitOdDbLayoutManagerReactor(swigCPtr);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_layoutsReordered(swigCPtr);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbLayoutManagerReactor createObject()
	{
		OdDbLayoutManagerReactor rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayoutManagerReactor>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("layoutCreated", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodlayoutCreated;
		}
		if (SwigDerivedClassHasMethod("layoutToBeRemoved", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodlayoutToBeRemoved;
		}
		if (SwigDerivedClassHasMethod("layoutRemoved", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodlayoutRemoved;
		}
		if (SwigDerivedClassHasMethod("abortLayoutRemoved", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodabortLayoutRemoved;
		}
		if (SwigDerivedClassHasMethod("layoutToBeCopied", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodlayoutToBeCopied;
		}
		if (SwigDerivedClassHasMethod("layoutCopied", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodlayoutCopied;
		}
		if (SwigDerivedClassHasMethod("abortLayoutCopied", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodabortLayoutCopied;
		}
		if (SwigDerivedClassHasMethod("layoutToBeRenamed", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodlayoutToBeRenamed;
		}
		if (SwigDerivedClassHasMethod("layoutRenamed", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodlayoutRenamed;
		}
		if (SwigDerivedClassHasMethod("abortLayoutRename", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodabortLayoutRename;
		}
		if (SwigDerivedClassHasMethod("layoutSwitched", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodlayoutSwitched;
		}
		if (SwigDerivedClassHasMethod("plotStyleTableChanged", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodplotStyleTableChanged;
		}
		if (SwigDerivedClassHasMethod("layoutToBeDeactivated", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodlayoutToBeDeactivated;
		}
		if (SwigDerivedClassHasMethod("layoutsReordered", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodlayoutsReordered;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayoutManagerReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbLayoutManagerReactor));
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

	private void SwigDirectorMethodlayoutCreated([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId)
	{
		try
		{
			layoutCreated(layoutName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayoutToBeRemoved([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId)
	{
		try
		{
			layoutToBeRemoved(layoutName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayoutRemoved([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId)
	{
		try
		{
			layoutRemoved(layoutName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodabortLayoutRemoved([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId)
	{
		try
		{
			abortLayoutRemoved(layoutName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayoutToBeCopied([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId)
	{
		try
		{
			layoutToBeCopied(layoutName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayoutCopied([MarshalAs(UnmanagedType.LPWStr)] string oldLayoutName, IntPtr oldLayoutId, [MarshalAs(UnmanagedType.LPWStr)] string newLayoutName, IntPtr newLayoutId)
	{
		try
		{
			layoutCopied(oldLayoutName, new OdDbObjectId(oldLayoutId, cMemoryOwn: false), newLayoutName, new OdDbObjectId(newLayoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodabortLayoutCopied([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId)
	{
		try
		{
			abortLayoutCopied(layoutName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayoutToBeRenamed([MarshalAs(UnmanagedType.LPWStr)] string oldLayoutName, [MarshalAs(UnmanagedType.LPWStr)] string newLayoutName, IntPtr layoutId)
	{
		try
		{
			layoutToBeRenamed(oldLayoutName, newLayoutName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayoutRenamed([MarshalAs(UnmanagedType.LPWStr)] string oldLayoutName, [MarshalAs(UnmanagedType.LPWStr)] string newLayoutName, IntPtr layoutId)
	{
		try
		{
			layoutRenamed(oldLayoutName, newLayoutName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodabortLayoutRename([MarshalAs(UnmanagedType.LPWStr)] string oldLayoutName, [MarshalAs(UnmanagedType.LPWStr)] string newLayoutName, IntPtr layoutId)
	{
		try
		{
			abortLayoutRename(oldLayoutName, newLayoutName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayoutSwitched([MarshalAs(UnmanagedType.LPWStr)] string newLayoutName, IntPtr newLayoutId)
	{
		try
		{
			layoutSwitched(newLayoutName, new OdDbObjectId(newLayoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodplotStyleTableChanged([MarshalAs(UnmanagedType.LPWStr)] string newTableName, IntPtr layoutId)
	{
		try
		{
			plotStyleTableChanged(newTableName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayoutToBeDeactivated([MarshalAs(UnmanagedType.LPWStr)] string layoutName, IntPtr layoutId)
	{
		try
		{
			layoutToBeDeactivated(layoutName, new OdDbObjectId(layoutId, cMemoryOwn: false));
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

	private void SwigDirectorMethodlayoutsReordered()
	{
		try
		{
			layoutsReordered();
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
