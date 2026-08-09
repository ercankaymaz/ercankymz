using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdLyLayerGroup : OdLyLayerFilter
{
	public delegate IntPtr SwigDelegateOdLyLayerGroup_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdLyLayerGroup_1();

	public delegate void SwigDelegateOdLyLayerGroup_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdLyLayerGroup_3();

	public delegate bool SwigDelegateOdLyLayerGroup_4([MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate bool SwigDelegateOdLyLayerGroup_5();

	public delegate IntPtr SwigDelegateOdLyLayerGroup_6();

	public delegate IntPtr SwigDelegateOdLyLayerGroup_7();

	public delegate void SwigDelegateOdLyLayerGroup_8(IntPtr pLayerFilter);

	public delegate void SwigDelegateOdLyLayerGroup_9(IntPtr pLayerFilter);

	public delegate int SwigDelegateOdLyLayerGroup_10();

	public delegate bool SwigDelegateOdLyLayerGroup_11();

	public delegate bool SwigDelegateOdLyLayerGroup_12();

	public delegate bool SwigDelegateOdLyLayerGroup_13();

	public delegate bool SwigDelegateOdLyLayerGroup_14();

	public delegate bool SwigDelegateOdLyLayerGroup_15();

	public delegate bool SwigDelegateOdLyLayerGroup_16(IntPtr layer);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdLyLayerGroup_17();

	public delegate int SwigDelegateOdLyLayerGroup_18([MarshalAs(UnmanagedType.LPWStr)] string filterExpression);

	public delegate bool SwigDelegateOdLyLayerGroup_19(IntPtr pOther);

	public delegate int SwigDelegateOdLyLayerGroup_20(IntPtr pFiler);

	public delegate void SwigDelegateOdLyLayerGroup_21(IntPtr pFiler);

	public delegate void SwigDelegateOdLyLayerGroup_22(IntPtr layerId);

	public delegate void SwigDelegateOdLyLayerGroup_23(IntPtr layerId);

	public delegate IntPtr SwigDelegateOdLyLayerGroup_24();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdLyLayerGroup_0 swigDelegate0;

	private SwigDelegateOdLyLayerGroup_1 swigDelegate1;

	private SwigDelegateOdLyLayerGroup_2 swigDelegate2;

	private SwigDelegateOdLyLayerGroup_3 swigDelegate3;

	private SwigDelegateOdLyLayerGroup_4 swigDelegate4;

	private SwigDelegateOdLyLayerGroup_5 swigDelegate5;

	private SwigDelegateOdLyLayerGroup_6 swigDelegate6;

	private SwigDelegateOdLyLayerGroup_7 swigDelegate7;

	private SwigDelegateOdLyLayerGroup_8 swigDelegate8;

	private SwigDelegateOdLyLayerGroup_9 swigDelegate9;

	private SwigDelegateOdLyLayerGroup_10 swigDelegate10;

	private SwigDelegateOdLyLayerGroup_11 swigDelegate11;

	private SwigDelegateOdLyLayerGroup_12 swigDelegate12;

	private SwigDelegateOdLyLayerGroup_13 swigDelegate13;

	private SwigDelegateOdLyLayerGroup_14 swigDelegate14;

	private SwigDelegateOdLyLayerGroup_15 swigDelegate15;

	private SwigDelegateOdLyLayerGroup_16 swigDelegate16;

	private SwigDelegateOdLyLayerGroup_17 swigDelegate17;

	private SwigDelegateOdLyLayerGroup_18 swigDelegate18;

	private SwigDelegateOdLyLayerGroup_19 swigDelegate19;

	private SwigDelegateOdLyLayerGroup_20 swigDelegate20;

	private SwigDelegateOdLyLayerGroup_21 swigDelegate21;

	private SwigDelegateOdLyLayerGroup_22 swigDelegate22;

	private SwigDelegateOdLyLayerGroup_23 swigDelegate23;

	private SwigDelegateOdLyLayerGroup_24 swigDelegate24;

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

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes24 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdLyLayerGroup(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdLyLayerGroup obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdLyLayerGroup(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdLyLayerGroup cast(OdRxObject pObj)
	{
		OdLyLayerGroup rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerGroup>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_isASwigExplicitOdLyLayerGroup(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_queryXSwigExplicitOdLyLayerGroup(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdLyLayerGroup()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdLyLayerGroup(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdLyLayerGroup) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual void addLayerId(OdDbObjectId layerId)
	{
		if (SwigDerivedClassHasMethod("addLayerId", swigMethodTypes22))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_addLayerIdSwigExplicitOdLyLayerGroup(swigCPtr, OdDbObjectId.getCPtr(layerId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_addLayerId(swigCPtr, OdDbObjectId.getCPtr(layerId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeLayerId(OdDbObjectId layerId)
	{
		if (SwigDerivedClassHasMethod("removeLayerId", swigMethodTypes23))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_removeLayerIdSwigExplicitOdLyLayerGroup(swigCPtr, OdDbObjectId.getCPtr(layerId));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_removeLayerId(swigCPtr, OdDbObjectId.getCPtr(layerId));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectIdArray layerIds()
	{
		OdDbObjectIdArray result = new OdDbObjectIdArray(SwigDerivedClassHasMethod("layerIds", swigMethodTypes24) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_layerIdsSwigExplicitOdLyLayerGroup(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_layerIds(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdLyLayerGroup createObject()
	{
		OdLyLayerGroup rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdLyLayerGroup>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("addLayerId", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodaddLayerId;
		}
		if (SwigDerivedClassHasMethod("removeLayerId", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodremoveLayerId;
		}
		if (SwigDerivedClassHasMethod("layerIds", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodlayerIds;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdLyLayerGroup_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdLyLayerGroup));
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
		return OdLyLayerFilter.getCPtr(parent()).Handle;
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

	private void SwigDirectorMethodaddLayerId(IntPtr layerId)
	{
		try
		{
			addLayerId(new OdDbObjectId(layerId, cMemoryOwn: false));
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

	private void SwigDirectorMethodremoveLayerId(IntPtr layerId)
	{
		try
		{
			removeLayerId(new OdDbObjectId(layerId, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodlayerIds()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectIdArray.getCPtr(layerIds()).Handle;
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
}
