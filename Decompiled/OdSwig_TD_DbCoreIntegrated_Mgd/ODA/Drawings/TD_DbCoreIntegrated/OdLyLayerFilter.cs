using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdLyLayerFilter : OdRxObject
{
	public delegate IntPtr SwigDelegateOdLyLayerFilter_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdLyLayerFilter_1();

	public delegate void SwigDelegateOdLyLayerFilter_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdLyLayerFilter_3();

	public delegate bool SwigDelegateOdLyLayerFilter_4([MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate bool SwigDelegateOdLyLayerFilter_5();

	public delegate IntPtr SwigDelegateOdLyLayerFilter_6();

	public delegate IntPtr SwigDelegateOdLyLayerFilter_7();

	public delegate void SwigDelegateOdLyLayerFilter_8(IntPtr pLayerFilter);

	public delegate void SwigDelegateOdLyLayerFilter_9(IntPtr pLayerFilter);

	public delegate int SwigDelegateOdLyLayerFilter_10();

	public delegate bool SwigDelegateOdLyLayerFilter_11();

	public delegate bool SwigDelegateOdLyLayerFilter_12();

	public delegate bool SwigDelegateOdLyLayerFilter_13();

	public delegate bool SwigDelegateOdLyLayerFilter_14();

	public delegate bool SwigDelegateOdLyLayerFilter_15();

	public delegate bool SwigDelegateOdLyLayerFilter_16(IntPtr layer);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdLyLayerFilter_17();

	public delegate int SwigDelegateOdLyLayerFilter_18([MarshalAs(UnmanagedType.LPWStr)] string filterExpression);

	public delegate bool SwigDelegateOdLyLayerFilter_19(IntPtr pOther);

	public delegate int SwigDelegateOdLyLayerFilter_20(IntPtr pFiler);

	public delegate void SwigDelegateOdLyLayerFilter_21(IntPtr pFiler);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdLyLayerFilter_0 swigDelegate0;

	private SwigDelegateOdLyLayerFilter_1 swigDelegate1;

	private SwigDelegateOdLyLayerFilter_2 swigDelegate2;

	private SwigDelegateOdLyLayerFilter_3 swigDelegate3;

	private SwigDelegateOdLyLayerFilter_4 swigDelegate4;

	private SwigDelegateOdLyLayerFilter_5 swigDelegate5;

	private SwigDelegateOdLyLayerFilter_6 swigDelegate6;

	private SwigDelegateOdLyLayerFilter_7 swigDelegate7;

	private SwigDelegateOdLyLayerFilter_8 swigDelegate8;

	private SwigDelegateOdLyLayerFilter_9 swigDelegate9;

	private SwigDelegateOdLyLayerFilter_10 swigDelegate10;

	private SwigDelegateOdLyLayerFilter_11 swigDelegate11;

	private SwigDelegateOdLyLayerFilter_12 swigDelegate12;

	private SwigDelegateOdLyLayerFilter_13 swigDelegate13;

	private SwigDelegateOdLyLayerFilter_14 swigDelegate14;

	private SwigDelegateOdLyLayerFilter_15 swigDelegate15;

	private SwigDelegateOdLyLayerFilter_16 swigDelegate16;

	private SwigDelegateOdLyLayerFilter_17 swigDelegate17;

	private SwigDelegateOdLyLayerFilter_18 swigDelegate18;

	private SwigDelegateOdLyLayerFilter_19 swigDelegate19;

	private SwigDelegateOdLyLayerFilter_20 swigDelegate20;

	private SwigDelegateOdLyLayerFilter_21 swigDelegate21;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdLyLayerFilter) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdLyLayerFilter) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbLayerTableRecord) };

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdLyLayerFilter) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdDbDxfFiler) };

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdDbDxfFiler) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdLyLayerFilter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdLyLayerFilter obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdLyLayerFilter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdLyLayerFilter cast(OdRxObject pObj)
	{
		OdLyLayerFilter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerFilter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_isASwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_queryXSwigExplicitOdLyLayerFilter(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdLyLayerFilter()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdLyLayerFilter(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdLyLayerFilter) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual string name()
	{
		string result = (SwigDerivedClassHasMethod("name", swigMethodTypes3) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_nameSwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_name(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setName(string name)
	{
		bool result = (SwigDerivedClassHasMethod("setName", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_setNameSwigExplicitOdLyLayerFilter(swigCPtr, name) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_setName(swigCPtr, name));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool allowRename()
	{
		bool result = (SwigDerivedClassHasMethod("allowRename", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_allowRenameSwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_allowRename(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdLyLayerFilter parent()
	{
		OdLyLayerFilter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerFilter>(SwigDerivedClassHasMethod("parent", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_parentSwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_parent(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdLyLayerFilterArray getNestedFilters()
	{
		OdLyLayerFilterArray result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdLyLayerFilterArray>(SwigDerivedClassHasMethod("getNestedFilters", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_getNestedFiltersSwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_getNestedFilters(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addNested(OdLyLayerFilter pLayerFilter)
	{
		if (SwigDerivedClassHasMethod("addNested", swigMethodTypes8))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_addNestedSwigExplicitOdLyLayerFilter(swigCPtr, getCPtr(pLayerFilter));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_addNested(swigCPtr, getCPtr(pLayerFilter));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeNested(OdLyLayerFilter pLayerFilter)
	{
		if (SwigDerivedClassHasMethod("removeNested", swigMethodTypes9))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_removeNestedSwigExplicitOdLyLayerFilter(swigCPtr, getCPtr(pLayerFilter));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_removeNested(swigCPtr, getCPtr(pLayerFilter));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult generateNested()
	{
		int result = (SwigDerivedClassHasMethod("generateNested", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_generateNestedSwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_generateNested(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool dynamicallyGenerated()
	{
		bool result = (SwigDerivedClassHasMethod("dynamicallyGenerated", swigMethodTypes11) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_dynamicallyGeneratedSwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_dynamicallyGenerated(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool allowNested()
	{
		bool result = (SwigDerivedClassHasMethod("allowNested", swigMethodTypes12) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_allowNestedSwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_allowNested(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool allowDelete()
	{
		bool result = (SwigDerivedClassHasMethod("allowDelete", swigMethodTypes13) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_allowDeleteSwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_allowDelete(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isProxy()
	{
		bool result = (SwigDerivedClassHasMethod("isProxy", swigMethodTypes14) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_isProxySwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_isProxy(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isIdFilter()
	{
		bool result = (SwigDerivedClassHasMethod("isIdFilter", swigMethodTypes15) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_isIdFilterSwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_isIdFilter(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool filter(OdDbLayerTableRecord layer)
	{
		bool result = (SwigDerivedClassHasMethod("filter", swigMethodTypes16) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_filterSwigExplicitOdLyLayerFilter(swigCPtr, OdDbLayerTableRecord.getCPtr(layer)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_filter(swigCPtr, OdDbLayerTableRecord.getCPtr(layer)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string filterExpression()
	{
		string result = (SwigDerivedClassHasMethod("filterExpression", swigMethodTypes17) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_filterExpressionSwigExplicitOdLyLayerFilter(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_filterExpression(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdLyBoolExpr filterExpressionTree()
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_filterExpressionTree(swigCPtr);
		OdLyBoolExpr result = ((intPtr == IntPtr.Zero) ? null : new OdLyBoolExpr(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setFilterExpression(string filterExpression)
	{
		int result = (SwigDerivedClassHasMethod("setFilterExpression", swigMethodTypes18) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_setFilterExpressionSwigExplicitOdLyLayerFilter(swigCPtr, filterExpression) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_setFilterExpression(swigCPtr, filterExpression));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool compareTo(OdLyLayerFilter pOther)
	{
		bool result = (SwigDerivedClassHasMethod("compareTo", swigMethodTypes19) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_compareToSwigExplicitOdLyLayerFilter(swigCPtr, getCPtr(pOther)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_compareTo(swigCPtr, getCPtr(pOther)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult readFrom(OdDbDxfFiler pFiler)
	{
		int result = (SwigDerivedClassHasMethod("readFrom", swigMethodTypes20) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_readFromSwigExplicitOdLyLayerFilter(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_readFrom(swigCPtr, OdDbDxfFiler.getCPtr(pFiler)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void writeTo(OdDbDxfFiler pFiler)
	{
		if (SwigDerivedClassHasMethod("writeTo", swigMethodTypes21))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_writeToSwigExplicitOdLyLayerFilter(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_writeTo(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdLyLayerFilter createObject()
	{
		OdLyLayerFilter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerFilter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("name", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodname;
		}
		if (SwigDerivedClassHasMethod("setName", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetName;
		}
		if (SwigDerivedClassHasMethod("allowRename", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodallowRename;
		}
		if (SwigDerivedClassHasMethod("parent", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodparent;
		}
		if (SwigDerivedClassHasMethod("getNestedFilters", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetNestedFilters;
		}
		if (SwigDerivedClassHasMethod("addNested", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodaddNested;
		}
		if (SwigDerivedClassHasMethod("removeNested", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodremoveNested;
		}
		if (SwigDerivedClassHasMethod("generateNested", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgenerateNested;
		}
		if (SwigDerivedClassHasMethod("dynamicallyGenerated", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethoddynamicallyGenerated;
		}
		if (SwigDerivedClassHasMethod("allowNested", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodallowNested;
		}
		if (SwigDerivedClassHasMethod("allowDelete", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodallowDelete;
		}
		if (SwigDerivedClassHasMethod("isProxy", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodisProxy;
		}
		if (SwigDerivedClassHasMethod("isIdFilter", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodisIdFilter;
		}
		if (SwigDerivedClassHasMethod("filter", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodfilter;
		}
		if (SwigDerivedClassHasMethod("filterExpression", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodfilterExpression;
		}
		if (SwigDerivedClassHasMethod("setFilterExpression", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetFilterExpression;
		}
		if (SwigDerivedClassHasMethod("compareTo", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodcompareTo;
		}
		if (SwigDerivedClassHasMethod("readFrom", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodreadFrom;
		}
		if (SwigDerivedClassHasMethod("writeTo", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodwriteTo;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerFilter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdLyLayerFilter));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodname()
	{
		return name();
	}

	private bool SwigDirectorMethodsetName([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return setName(name);
	}

	private bool SwigDirectorMethodallowRename()
	{
		return allowRename();
	}

	private IntPtr SwigDirectorMethodparent()
	{
		return getCPtr(parent()).Handle;
	}

	private IntPtr SwigDirectorMethodgetNestedFilters()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdLyLayerFilterArray.getCPtr(getNestedFilters()).Handle;
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

	private void SwigDirectorMethodaddNested(IntPtr pLayerFilter)
	{
		try
		{
			addNested(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerFilter>(pLayerFilter, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodremoveNested(IntPtr pLayerFilter)
	{
		try
		{
			removeNested(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerFilter>(pLayerFilter, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodgenerateNested()
	{
		return (int)generateNested();
	}

	private bool SwigDirectorMethoddynamicallyGenerated()
	{
		return dynamicallyGenerated();
	}

	private bool SwigDirectorMethodallowNested()
	{
		return allowNested();
	}

	private bool SwigDirectorMethodallowDelete()
	{
		return allowDelete();
	}

	private bool SwigDirectorMethodisProxy()
	{
		return isProxy();
	}

	private bool SwigDirectorMethodisIdFilter()
	{
		return isIdFilter();
	}

	private bool SwigDirectorMethodfilter(IntPtr layer)
	{
		return filter(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayerTableRecord>(layer, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfilterExpression()
	{
		return filterExpression();
	}

	private int SwigDirectorMethodsetFilterExpression([MarshalAs(UnmanagedType.LPWStr)] string filterExpression)
	{
		return (int)setFilterExpression(filterExpression);
	}

	private bool SwigDirectorMethodcompareTo(IntPtr pOther)
	{
		return compareTo(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerFilter>(pOther, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodreadFrom(IntPtr pFiler)
	{
		return (int)readFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodwriteTo(IntPtr pFiler)
	{
		try
		{
			writeTo(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDxfFiler>(pFiler, bOwn: false, bTryAddToTransaction: false));
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
