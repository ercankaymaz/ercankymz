using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbEntityHyperlinkPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_1();

	public delegate void SwigDelegateOdDbEntityHyperlinkPE_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_3(IntPtr pObject, bool oneOnly, bool ignoreBlockDefinition);

	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_4(IntPtr pObject, bool oneOnly);

	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_5(IntPtr pObject);

	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_6(IntPtr pObject, bool oneOnly, bool ignoreBlockDefinition);

	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_7(IntPtr pObject, bool oneOnly);

	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_8(IntPtr pObject);

	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_9(IntPtr objectIds, bool oneOnly, bool ignoreBlockDefinition);

	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_10(IntPtr objectIds, bool oneOnly);

	public delegate IntPtr SwigDelegateOdDbEntityHyperlinkPE_11(IntPtr objectIds);

	public delegate void SwigDelegateOdDbEntityHyperlinkPE_12(IntPtr pObject, IntPtr pHCO);

	public delegate uint SwigDelegateOdDbEntityHyperlinkPE_13(IntPtr pObject, bool ignoreBlockDefinition);

	public delegate uint SwigDelegateOdDbEntityHyperlinkPE_14(IntPtr pObject);

	public delegate uint SwigDelegateOdDbEntityHyperlinkPE_15(IntPtr idContainers, bool ignoreBlockDefinition);

	public delegate uint SwigDelegateOdDbEntityHyperlinkPE_16(IntPtr idContainers);

	public delegate bool SwigDelegateOdDbEntityHyperlinkPE_17(IntPtr pObject, bool ignoreBlockDefinition);

	public delegate bool SwigDelegateOdDbEntityHyperlinkPE_18(IntPtr pObject);

	public delegate bool SwigDelegateOdDbEntityHyperlinkPE_19(IntPtr objectIds, bool ignoreBlockDefinition);

	public delegate bool SwigDelegateOdDbEntityHyperlinkPE_20(IntPtr objectIds);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbEntityHyperlinkPE_0 swigDelegate0;

	private SwigDelegateOdDbEntityHyperlinkPE_1 swigDelegate1;

	private SwigDelegateOdDbEntityHyperlinkPE_2 swigDelegate2;

	private SwigDelegateOdDbEntityHyperlinkPE_3 swigDelegate3;

	private SwigDelegateOdDbEntityHyperlinkPE_4 swigDelegate4;

	private SwigDelegateOdDbEntityHyperlinkPE_5 swigDelegate5;

	private SwigDelegateOdDbEntityHyperlinkPE_6 swigDelegate6;

	private SwigDelegateOdDbEntityHyperlinkPE_7 swigDelegate7;

	private SwigDelegateOdDbEntityHyperlinkPE_8 swigDelegate8;

	private SwigDelegateOdDbEntityHyperlinkPE_9 swigDelegate9;

	private SwigDelegateOdDbEntityHyperlinkPE_10 swigDelegate10;

	private SwigDelegateOdDbEntityHyperlinkPE_11 swigDelegate11;

	private SwigDelegateOdDbEntityHyperlinkPE_12 swigDelegate12;

	private SwigDelegateOdDbEntityHyperlinkPE_13 swigDelegate13;

	private SwigDelegateOdDbEntityHyperlinkPE_14 swigDelegate14;

	private SwigDelegateOdDbEntityHyperlinkPE_15 swigDelegate15;

	private SwigDelegateOdDbEntityHyperlinkPE_16 swigDelegate16;

	private SwigDelegateOdDbEntityHyperlinkPE_17 swigDelegate17;

	private SwigDelegateOdDbEntityHyperlinkPE_18 swigDelegate18;

	private SwigDelegateOdDbEntityHyperlinkPE_19 swigDelegate19;

	private SwigDelegateOdDbEntityHyperlinkPE_20 swigDelegate20;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes9 = new Type[3]
	{
		typeof(OdDbStubPtrArray),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdDbStubPtrArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDbStubPtrArray) };

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbHyperlinkCollection)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(OdDbStubPtrArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbStubPtrArray) };

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(OdDbStubPtrArray),
		typeof(bool)
	};

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdDbStubPtrArray) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbEntityHyperlinkPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbEntityHyperlinkPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbEntityHyperlinkPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbEntityHyperlinkPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbEntityHyperlinkPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbEntityHyperlinkPE) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdDbEntityHyperlinkPE cast(OdRxObject pObj)
	{
		OdDbEntityHyperlinkPE rXObject = Helpers.GetRXObject<OdDbEntityHyperlinkPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_isASwigExplicitOdDbEntityHyperlinkPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_queryXSwigExplicitOdDbEntityHyperlinkPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbEntityHyperlinkPE createObject()
	{
		OdDbEntityHyperlinkPE rXObject = Helpers.GetRXObject<OdDbEntityHyperlinkPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHyperlinkCollection getHyperlinkCollection(OdRxObject pObject, bool oneOnly, bool ignoreBlockDefinition)
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollection__SWIG_0(swigCPtr, OdRxObject.getCPtr(pObject), oneOnly, ignoreBlockDefinition), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHyperlinkCollection getHyperlinkCollection(OdRxObject pObject, bool oneOnly)
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollection__SWIG_1(swigCPtr, OdRxObject.getCPtr(pObject), oneOnly), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHyperlinkCollection getHyperlinkCollection(OdRxObject pObject)
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollection__SWIG_2(swigCPtr, OdRxObject.getCPtr(pObject)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHyperlinkCollection getHyperlinkCollectionEx(OdRxObject pObject, bool oneOnly, bool ignoreBlockDefinition)
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(SwigDerivedClassHasMethod("getHyperlinkCollectionEx", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollectionExSwigExplicitOdDbEntityHyperlinkPE__SWIG_0(swigCPtr, OdRxObject.getCPtr(pObject), oneOnly, ignoreBlockDefinition) : TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollectionEx__SWIG_0(swigCPtr, OdRxObject.getCPtr(pObject), oneOnly, ignoreBlockDefinition), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHyperlinkCollection getHyperlinkCollectionEx(OdRxObject pObject, bool oneOnly)
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(SwigDerivedClassHasMethod("getHyperlinkCollectionEx", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollectionExSwigExplicitOdDbEntityHyperlinkPE__SWIG_1(swigCPtr, OdRxObject.getCPtr(pObject), oneOnly) : TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollectionEx__SWIG_1(swigCPtr, OdRxObject.getCPtr(pObject), oneOnly), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHyperlinkCollection getHyperlinkCollectionEx(OdRxObject pObject)
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(SwigDerivedClassHasMethod("getHyperlinkCollectionEx", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollectionExSwigExplicitOdDbEntityHyperlinkPE__SWIG_2(swigCPtr, OdRxObject.getCPtr(pObject)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollectionEx__SWIG_2(swigCPtr, OdRxObject.getCPtr(pObject)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHyperlinkCollection getHyperlinkCollection(OdDbStubPtrArray objectIds, bool oneOnly, bool ignoreBlockDefinition)
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollection__SWIG_3(swigCPtr, objectIds, oneOnly, ignoreBlockDefinition), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHyperlinkCollection getHyperlinkCollection(OdDbStubPtrArray objectIds, bool oneOnly)
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollection__SWIG_4(swigCPtr, objectIds, oneOnly), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbHyperlinkCollection getHyperlinkCollection(OdDbStubPtrArray objectIds)
	{
		OdDbHyperlinkCollection rXObject = Helpers.GetRXObject<OdDbHyperlinkCollection>(TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCollection__SWIG_5(swigCPtr, objectIds), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setHyperlinkCollection(OdRxObject pObject, OdDbHyperlinkCollection pHCO)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_setHyperlinkCollection(swigCPtr, OdRxObject.getCPtr(pObject), OdDbHyperlinkCollection.getCPtr(pHCO));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getHyperlinkCount(OdRxObject pObject, bool ignoreBlockDefinition)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCount__SWIG_0(swigCPtr, OdRxObject.getCPtr(pObject), ignoreBlockDefinition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getHyperlinkCount(OdRxObject pObject)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCount__SWIG_1(swigCPtr, OdRxObject.getCPtr(pObject));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getHyperlinkCount(OdDbStubPtrArray idContainers, bool ignoreBlockDefinition)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCount__SWIG_2(swigCPtr, idContainers, ignoreBlockDefinition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getHyperlinkCount(OdDbStubPtrArray idContainers)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getHyperlinkCount__SWIG_3(swigCPtr, idContainers);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasHyperlink(OdRxObject pObject, bool ignoreBlockDefinition)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_hasHyperlink__SWIG_0(swigCPtr, OdRxObject.getCPtr(pObject), ignoreBlockDefinition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasHyperlink(OdRxObject pObject)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_hasHyperlink__SWIG_1(swigCPtr, OdRxObject.getCPtr(pObject));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasHyperlink(OdDbStubPtrArray objectIds, bool ignoreBlockDefinition)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_hasHyperlink__SWIG_2(swigCPtr, objectIds, ignoreBlockDefinition);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasHyperlink(OdDbStubPtrArray objectIds)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_hasHyperlink__SWIG_3(swigCPtr, objectIds);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getHyperlinkCollection", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetHyperlinkCollection__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCollection", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetHyperlinkCollection__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCollection", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetHyperlinkCollection__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCollectionEx", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetHyperlinkCollectionEx__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCollectionEx", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetHyperlinkCollectionEx__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCollectionEx", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetHyperlinkCollectionEx__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCollection", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetHyperlinkCollection__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCollection", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetHyperlinkCollection__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCollection", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetHyperlinkCollection__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("setHyperlinkCollection", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetHyperlinkCollection;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCount", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetHyperlinkCount__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCount", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodgetHyperlinkCount__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCount", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetHyperlinkCount__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getHyperlinkCount", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetHyperlinkCount__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("hasHyperlink", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodhasHyperlink__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("hasHyperlink", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodhasHyperlink__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("hasHyperlink", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodhasHyperlink__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("hasHyperlink", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodhasHyperlink__SWIG_3;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbEntityHyperlinkPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbEntityHyperlinkPE));
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

	private IntPtr SwigDirectorMethodgetHyperlinkCollection__SWIG_0(IntPtr pObject, bool oneOnly, bool ignoreBlockDefinition)
	{
		return OdDbHyperlinkCollection.getCPtr(getHyperlinkCollection(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), oneOnly, ignoreBlockDefinition)).Handle;
	}

	private IntPtr SwigDirectorMethodgetHyperlinkCollection__SWIG_1(IntPtr pObject, bool oneOnly)
	{
		return OdDbHyperlinkCollection.getCPtr(getHyperlinkCollection(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), oneOnly)).Handle;
	}

	private IntPtr SwigDirectorMethodgetHyperlinkCollection__SWIG_2(IntPtr pObject)
	{
		return OdDbHyperlinkCollection.getCPtr(getHyperlinkCollection(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetHyperlinkCollectionEx__SWIG_0(IntPtr pObject, bool oneOnly, bool ignoreBlockDefinition)
	{
		return OdDbHyperlinkCollection.getCPtr(getHyperlinkCollectionEx(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), oneOnly, ignoreBlockDefinition)).Handle;
	}

	private IntPtr SwigDirectorMethodgetHyperlinkCollectionEx__SWIG_1(IntPtr pObject, bool oneOnly)
	{
		return OdDbHyperlinkCollection.getCPtr(getHyperlinkCollectionEx(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), oneOnly)).Handle;
	}

	private IntPtr SwigDirectorMethodgetHyperlinkCollectionEx__SWIG_2(IntPtr pObject)
	{
		return OdDbHyperlinkCollection.getCPtr(getHyperlinkCollectionEx(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetHyperlinkCollection__SWIG_3(IntPtr objectIds, bool oneOnly, bool ignoreBlockDefinition)
	{
		OdDbStubPtrArray objectIds2 = new OdDbStubPtrArray(objectIds, cMemoryOwn: true);
		return OdDbHyperlinkCollection.getCPtr(getHyperlinkCollection(objectIds2, oneOnly, ignoreBlockDefinition)).Handle;
	}

	private IntPtr SwigDirectorMethodgetHyperlinkCollection__SWIG_4(IntPtr objectIds, bool oneOnly)
	{
		OdDbStubPtrArray objectIds2 = new OdDbStubPtrArray(objectIds, cMemoryOwn: true);
		return OdDbHyperlinkCollection.getCPtr(getHyperlinkCollection(objectIds2, oneOnly)).Handle;
	}

	private IntPtr SwigDirectorMethodgetHyperlinkCollection__SWIG_5(IntPtr objectIds)
	{
		OdDbStubPtrArray objectIds2 = new OdDbStubPtrArray(objectIds, cMemoryOwn: true);
		return OdDbHyperlinkCollection.getCPtr(getHyperlinkCollection(objectIds2)).Handle;
	}

	private void SwigDirectorMethodsetHyperlinkCollection(IntPtr pObject, IntPtr pHCO)
	{
		try
		{
			setHyperlinkCollection(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdDbHyperlinkCollection>(pHCO, bOwn: false, bTryAddToTransaction: false));
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

	private uint SwigDirectorMethodgetHyperlinkCount__SWIG_0(IntPtr pObject, bool ignoreBlockDefinition)
	{
		return getHyperlinkCount(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), ignoreBlockDefinition);
	}

	private uint SwigDirectorMethodgetHyperlinkCount__SWIG_1(IntPtr pObject)
	{
		return getHyperlinkCount(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodgetHyperlinkCount__SWIG_2(IntPtr idContainers, bool ignoreBlockDefinition)
	{
		OdDbStubPtrArray idContainers2 = new OdDbStubPtrArray(idContainers, cMemoryOwn: true);
		return getHyperlinkCount(idContainers2, ignoreBlockDefinition);
	}

	private uint SwigDirectorMethodgetHyperlinkCount__SWIG_3(IntPtr idContainers)
	{
		OdDbStubPtrArray idContainers2 = new OdDbStubPtrArray(idContainers, cMemoryOwn: true);
		return getHyperlinkCount(idContainers2);
	}

	private bool SwigDirectorMethodhasHyperlink__SWIG_0(IntPtr pObject, bool ignoreBlockDefinition)
	{
		return hasHyperlink(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false), ignoreBlockDefinition);
	}

	private bool SwigDirectorMethodhasHyperlink__SWIG_1(IntPtr pObject)
	{
		return hasHyperlink(Helpers.GetRXObject<OdRxObject>(pObject, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodhasHyperlink__SWIG_2(IntPtr objectIds, bool ignoreBlockDefinition)
	{
		OdDbStubPtrArray objectIds2 = new OdDbStubPtrArray(objectIds, cMemoryOwn: true);
		return hasHyperlink(objectIds2, ignoreBlockDefinition);
	}

	private bool SwigDirectorMethodhasHyperlink__SWIG_3(IntPtr objectIds)
	{
		OdDbStubPtrArray objectIds2 = new OdDbStubPtrArray(objectIds, cMemoryOwn: true);
		return hasHyperlink(objectIds2);
	}
}
