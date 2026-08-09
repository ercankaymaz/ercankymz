using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbLayerStateManager : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbLayerStateManager_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbLayerStateManager_1();

	public delegate void SwigDelegateOdDbLayerStateManager_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbLayerStateManager_0 swigDelegate0;

	private SwigDelegateOdDbLayerStateManager_1 swigDelegate1;

	private SwigDelegateOdDbLayerStateManager_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	public const int kUndefDoNothing = 0;

	public const int kUndefTurnOff = 1;

	public const int kUndefFreeze = 2;

	public const int kRestoreAsOverrides = 4;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLayerStateManager(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLayerStateManager obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbLayerStateManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbLayerStateManager cast(OdRxObject pObj)
	{
		OdDbLayerStateManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayerStateManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_isASwigExplicitOdDbLayerStateManager(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_queryXSwigExplicitOdDbLayerStateManager(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbLayerStateManager()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbLayerStateManager(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbLayerStateManager) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public bool addReactor(OdDbLayerStateManagerReactor pReactor)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_addReactor(swigCPtr, OdDbLayerStateManagerReactor.getCPtr(pReactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool removeReactor(OdDbLayerStateManagerReactor pReactor)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_removeReactor(swigCPtr, OdDbLayerStateManagerReactor.getCPtr(pReactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId layerStatesDictionaryId(bool bCreateIfNotPresent)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_layerStatesDictionaryId__SWIG_0(swigCPtr, bCreateIfNotPresent), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId layerStatesDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_layerStatesDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasLayerState(string sName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_hasLayerState(swigCPtr, sName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult saveLayerState(string sName, OdDbLayerStateManager_LayerStateMask mask)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_saveLayerState__SWIG_0(swigCPtr, sName, (int)mask);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult restoreLayerState(string sName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_restoreLayerState__SWIG_0(swigCPtr, sName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setLayerStateMask(string sName, OdDbLayerStateManager_LayerStateMask mask)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_setLayerStateMask(swigCPtr, sName, (int)mask);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getLayerStateMask(string sName, out OdDbLayerStateManager_LayerStateMask returnMask)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_getLayerStateMask(swigCPtr, sName, out returnMask);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult deleteLayerState(string sName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_deleteLayerState(swigCPtr, sName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult renameLayerState(string sName, string sNewName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_renameLayerState(swigCPtr, sName, sNewName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult importLayerState(OdStreamBuf pStreamBuf)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_importLayerState__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult importLayerState(OdStreamBuf pStreamBuf, ref string sName)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sName);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_importLayerState__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				sName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public OdResult exportLayerState(string sNameToExport, OdStreamBuf pStreamBuf)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_exportLayerState(swigCPtr, sNameToExport, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult saveLayerState(string sName, OdDbLayerStateManager_LayerStateMask mask, OdDbObjectId idVp)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_saveLayerState__SWIG_1(swigCPtr, sName, (int)mask, OdDbObjectId.getCPtr(idVp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult restoreLayerState(string sName, OdDbObjectId idVp, int nRestoreFlags, out OdDbLayerStateManager_LayerStateMask pClientMask)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_restoreLayerState__SWIG_1(swigCPtr, sName, OdDbObjectId.getCPtr(idVp), nRestoreFlags, out pClientMask);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult restoreLayerState(string sName, OdDbObjectId idVp, int nRestoreFlags)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_restoreLayerState__SWIG_2(swigCPtr, sName, OdDbObjectId.getCPtr(idVp), nRestoreFlags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult restoreLayerState(string sName, OdDbObjectId idVp)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_restoreLayerState__SWIG_3(swigCPtr, sName, OdDbObjectId.getCPtr(idVp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setLayerStateDescription(string sName, string sDesc)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_setLayerStateDescription(swigCPtr, sName, sDesc);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getLayerStateDescription(string sName, ref string sDesc)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sDesc);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_getLayerStateDescription(swigCPtr, sName, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				sDesc = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public bool layerStateHasViewportData(string sName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_layerStateHasViewportData(swigCPtr, sName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult importLayerStateFromDb(string pStateName, OdDbDatabase pDb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_importLayerStateFromDb(swigCPtr, pStateName, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getLayerStateNames(OdStringArray lsArray, bool bIncludeHidden, bool bIncludeXref)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_getLayerStateNames__SWIG_0(swigCPtr, OdStringArray.getCPtr(lsArray).Handle, bIncludeHidden, bIncludeXref);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getLayerStateNames(OdStringArray lsArray, bool bIncludeHidden)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_getLayerStateNames__SWIG_1(swigCPtr, OdStringArray.getCPtr(lsArray).Handle, bIncludeHidden);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getLayerStateNames(OdStringArray lsArray)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_getLayerStateNames__SWIG_2(swigCPtr, OdStringArray.getCPtr(lsArray).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getLastRestoredLayerState(ref string sName, OdDbObjectId restoredLSId)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(sName);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_getLastRestoredLayerState(swigCPtr, ref jarg, OdDbObjectId.getCPtr(restoredLSId));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				sName = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public OdResult getLayerStateLayers(OdStringArray layerArray, string sName, bool bInvert)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_getLayerStateLayers__SWIG_0(swigCPtr, OdStringArray.getCPtr(layerArray).Handle, sName, bInvert);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getLayerStateLayers(OdStringArray layerArray, string sName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_getLayerStateLayers__SWIG_1(swigCPtr, OdStringArray.getCPtr(layerArray).Handle, sName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool compareLayerStateToDb(string sName, OdDbObjectId idVp)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_compareLayerStateToDb(swigCPtr, sName, OdDbObjectId.getCPtr(idVp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult addLayerStateLayers(string sName, OdDbObjectIdArray layerIds)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_addLayerStateLayers(swigCPtr, sName, OdDbObjectIdArray.getCPtr(layerIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult removeLayerStateLayers(string sName, OdStringArray layerNames)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_removeLayerStateLayers(swigCPtr, sName, OdStringArray.getCPtr(layerNames).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool isDependentLayerState(string sName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_isDependentLayerState(swigCPtr, sName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbDatabase getDatabase()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_getDatabase(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbLayerStateManager createObject()
	{
		OdDbLayerStateManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayerStateManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerStateManager_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbLayerStateManager));
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
}
