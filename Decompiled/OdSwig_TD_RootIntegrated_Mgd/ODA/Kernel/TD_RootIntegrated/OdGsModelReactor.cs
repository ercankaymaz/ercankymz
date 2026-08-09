using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsModelReactor : IDisposable
{
	public delegate bool SwigDelegateOdGsModelReactor_0(IntPtr pModel, IntPtr pAdded, IntPtr pParent);

	public delegate bool SwigDelegateOdGsModelReactor_1(IntPtr pModel, IntPtr pAdded, IntPtr parentID);

	public delegate bool SwigDelegateOdGsModelReactor_2(IntPtr pModel, IntPtr pErased, IntPtr pParent);

	public delegate bool SwigDelegateOdGsModelReactor_3(IntPtr pModel, IntPtr pErased, IntPtr parentID);

	public delegate bool SwigDelegateOdGsModelReactor_4(IntPtr pModel, IntPtr pModified, IntPtr pParent);

	public delegate bool SwigDelegateOdGsModelReactor_5(IntPtr pModel, IntPtr pModified, IntPtr parentID);

	public delegate bool SwigDelegateOdGsModelReactor_6(IntPtr pModel, IntPtr pUnerased, IntPtr pParent);

	public delegate bool SwigDelegateOdGsModelReactor_7(IntPtr pModel, IntPtr pUnerased, IntPtr parentID);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGsModelReactor_0 swigDelegate0;

	private SwigDelegateOdGsModelReactor_1 swigDelegate1;

	private SwigDelegateOdGsModelReactor_2 swigDelegate2;

	private SwigDelegateOdGsModelReactor_3 swigDelegate3;

	private SwigDelegateOdGsModelReactor_4 swigDelegate4;

	private SwigDelegateOdGsModelReactor_5 swigDelegate5;

	private SwigDelegateOdGsModelReactor_6 swigDelegate6;

	private SwigDelegateOdGsModelReactor_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[3]
	{
		typeof(OdGsModel),
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes1 = new Type[3]
	{
		typeof(OdGsModel),
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes2 = new Type[3]
	{
		typeof(OdGsModel),
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdGsModel),
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdGsModel),
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdGsModel),
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdGsModel),
		typeof(OdGiDrawable),
		typeof(OdGiDrawable)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdGsModel),
		typeof(OdGiDrawable),
		typeof(OdDbStub)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsModelReactor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsModelReactor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsModelReactor()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsModelReactor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsModelReactor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsModelReactor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsModelReactor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual bool onAdded(OdGsModel pModel, OdGiDrawable pAdded, OdGiDrawable pParent)
	{
		bool result = (SwigDerivedClassHasMethod("onAdded", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onAddedSwigExplicitOdGsModelReactor__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pAdded), OdGiDrawable.getCPtr(pParent)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onAdded__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pAdded), OdGiDrawable.getCPtr(pParent)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onAdded(OdGsModel pModel, OdGiDrawable pAdded, OdDbStub parentID)
	{
		bool result = (SwigDerivedClassHasMethod("onAdded", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onAddedSwigExplicitOdGsModelReactor__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pAdded), OdDbStub.getCPtr(parentID)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onAdded__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pAdded), OdDbStub.getCPtr(parentID)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onErased(OdGsModel pModel, OdGiDrawable pErased, OdGiDrawable pParent)
	{
		bool result = (SwigDerivedClassHasMethod("onErased", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onErasedSwigExplicitOdGsModelReactor__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pErased), OdGiDrawable.getCPtr(pParent)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onErased__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pErased), OdGiDrawable.getCPtr(pParent)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onErased(OdGsModel pModel, OdGiDrawable pErased, OdDbStub parentID)
	{
		bool result = (SwigDerivedClassHasMethod("onErased", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onErasedSwigExplicitOdGsModelReactor__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pErased), OdDbStub.getCPtr(parentID)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onErased__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pErased), OdDbStub.getCPtr(parentID)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onModified(OdGsModel pModel, OdGiDrawable pModified, OdGiDrawable pParent)
	{
		bool result = (SwigDerivedClassHasMethod("onModified", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onModifiedSwigExplicitOdGsModelReactor__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pModified), OdGiDrawable.getCPtr(pParent)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onModified__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pModified), OdGiDrawable.getCPtr(pParent)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onModified(OdGsModel pModel, OdGiDrawable pModified, OdDbStub parentID)
	{
		bool result = (SwigDerivedClassHasMethod("onModified", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onModifiedSwigExplicitOdGsModelReactor__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pModified), OdDbStub.getCPtr(parentID)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onModified__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pModified), OdDbStub.getCPtr(parentID)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onUnerased(OdGsModel pModel, OdGiDrawable pUnerased, OdGiDrawable pParent)
	{
		bool result = (SwigDerivedClassHasMethod("onUnerased", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onUnerasedSwigExplicitOdGsModelReactor__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnerased), OdGiDrawable.getCPtr(pParent)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onUnerased__SWIG_0(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnerased), OdGiDrawable.getCPtr(pParent)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool onUnerased(OdGsModel pModel, OdGiDrawable pUnerased, OdDbStub parentID)
	{
		bool result = (SwigDerivedClassHasMethod("onUnerased", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onUnerasedSwigExplicitOdGsModelReactor__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnerased), OdDbStub.getCPtr(parentID)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_onUnerased__SWIG_1(swigCPtr, OdGsModel.getCPtr(pModel), OdGiDrawable.getCPtr(pUnerased), OdDbStub.getCPtr(parentID)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("onAdded", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodonAdded__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("onAdded", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodonAdded__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("onErased", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodonErased__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("onErased", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodonErased__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("onModified", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodonModified__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("onModified", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodonModified__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("onUnerased", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodonUnerased__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("onUnerased", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodonUnerased__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsModelReactor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsModelReactor));
	}

	private bool SwigDirectorMethodonAdded__SWIG_0(IntPtr pModel, IntPtr pAdded, IntPtr pParent)
	{
		return onAdded(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pAdded, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodonAdded__SWIG_1(IntPtr pModel, IntPtr pAdded, IntPtr parentID)
	{
		return onAdded(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pAdded, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodonErased__SWIG_0(IntPtr pModel, IntPtr pErased, IntPtr pParent)
	{
		return onErased(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pErased, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodonErased__SWIG_1(IntPtr pModel, IntPtr pErased, IntPtr parentID)
	{
		return onErased(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pErased, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodonModified__SWIG_0(IntPtr pModel, IntPtr pModified, IntPtr pParent)
	{
		return onModified(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pModified, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodonModified__SWIG_1(IntPtr pModel, IntPtr pModified, IntPtr parentID)
	{
		return onModified(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pModified, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodonUnerased__SWIG_0(IntPtr pModel, IntPtr pUnerased, IntPtr pParent)
	{
		return onUnerased(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pUnerased, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pParent, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodonUnerased__SWIG_1(IntPtr pModel, IntPtr pUnerased, IntPtr parentID)
	{
		return onUnerased(Helpers.GetRXObject<OdGsModel>(pModel, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiDrawable>(pUnerased, bOwn: false, bTryAddToTransaction: false), (parentID == IntPtr.Zero) ? null : new OdDbStub(parentID, cMemoryOwn: false));
	}
}
