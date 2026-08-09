using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbLayerState : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLayerState(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLayerState obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbLayerState()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbLayerState(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdDbObjectId dictionaryId(OdDbDatabase pDb, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_dictionaryId__SWIG_0(OdDbDatabase.getCPtr(pDb), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbObjectId dictionaryId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_dictionaryId__SWIG_1(OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool has(OdDbDatabase pDb, string layerStateName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_has(OdDbDatabase.getCPtr(pDb), layerStateName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void save(OdDbDatabase pDb, string layerStateName, int layerStateMask, OdDbObjectId viewportId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_save__SWIG_0(OdDbDatabase.getCPtr(pDb), layerStateName, layerStateMask, OdDbObjectId.getCPtr(viewportId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void save(OdDbDatabase pDb, string layerStateName, int layerStateMask)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_save__SWIG_1(OdDbDatabase.getCPtr(pDb), layerStateName, layerStateMask);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void restore(OdDbDatabase pDb, string layerStateName, int flags, int layerStateMask, OdDbObjectId viewportId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_restore__SWIG_0(OdDbDatabase.getCPtr(pDb), layerStateName, flags, layerStateMask, OdDbObjectId.getCPtr(viewportId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void restore(OdDbDatabase pDb, string layerStateName, int flags, int layerStateMask)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_restore__SWIG_1(OdDbDatabase.getCPtr(pDb), layerStateName, flags, layerStateMask);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void restore(OdDbDatabase pDb, string layerStateName, int flags)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_restore__SWIG_2(OdDbDatabase.getCPtr(pDb), layerStateName, flags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void restore(OdDbDatabase pDb, string layerStateName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_restore__SWIG_3(OdDbDatabase.getCPtr(pDb), layerStateName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void setMask(OdDbDatabase pDb, string layerStateName, int layerStateMask)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_setMask(OdDbDatabase.getCPtr(pDb), layerStateName, layerStateMask);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static int mask(OdDbDatabase pDb, string layerStateName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_mask(OdDbDatabase.getCPtr(pDb), layerStateName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void remove(OdDbDatabase pDb, string layerStateName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_remove(OdDbDatabase.getCPtr(pDb), layerStateName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void rename(OdDbDatabase pDb, string oldName, string newName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_rename(OdDbDatabase.getCPtr(pDb), oldName, newName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbLayerState_ImportResult importData(OdDbDatabase pDb, OdStreamBuf pStreamBuf, out string pName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_importData__SWIG_0(OdDbDatabase.getCPtr(pDb), OdStreamBuf.getCPtr(pStreamBuf), out pName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbLayerState_ImportResult)result;
	}

	public static OdDbLayerState_ImportResult importData(OdDbDatabase pDb, OdStreamBuf pStreamBuf)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_importData__SWIG_1(OdDbDatabase.getCPtr(pDb), OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbLayerState_ImportResult)result;
	}

	public static void exportData(OdDbDatabase pDb, string layerStateName, OdStreamBuf pStreamBuf)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_exportData(OdDbDatabase.getCPtr(pDb), layerStateName, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void setDescription(OdDbDatabase pDb, string layerStateName, string description)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_setDescription(OdDbDatabase.getCPtr(pDb), layerStateName, description);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static string description(OdDbDatabase pDb, string layerStateName)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_description(OdDbDatabase.getCPtr(pDb), layerStateName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool hasViewportData(OdDbDatabase pDb, string layerStateName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_hasViewportData(OdDbDatabase.getCPtr(pDb), layerStateName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdResult addLayerStateLayers(string sName, OdDbObjectIdArray layerIds)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_addLayerStateLayers(sName, OdDbObjectIdArray.getCPtr(layerIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult removeLayerStateLayers(OdDbDatabase pDb, string sName, OdStringArray layerNames)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_removeLayerStateLayers(OdDbDatabase.getCPtr(pDb), sName, OdStringArray.getCPtr(layerNames).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult saveGroup(OdDbDatabase pDb, string sName, OdDbObjectIdArray pLayers, int mask, int includedLayersState, int otherLayersState)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_saveGroup__SWIG_0(OdDbDatabase.getCPtr(pDb), sName, OdDbObjectIdArray.getCPtr(pLayers), mask, includedLayersState, otherLayersState);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult saveGroup(OdDbDatabase pDb, string sName, OdDbObjectIdArray pLayers, int mask, int includedLayersState)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_saveGroup__SWIG_1(OdDbDatabase.getCPtr(pDb), sName, OdDbObjectIdArray.getCPtr(pLayers), mask, includedLayersState);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult saveGroup(OdDbDatabase pDb, string sName, OdDbObjectIdArray pLayers, int mask)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_saveGroup__SWIG_2(OdDbDatabase.getCPtr(pDb), sName, OdDbObjectIdArray.getCPtr(pLayers), mask);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult saveGroup(OdDbDatabase pDb, string sName, OdDbObjectIdArray pLayers)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbLayerState_saveGroup__SWIG_3(OdDbDatabase.getCPtr(pDb), sName, OdDbObjectIdArray.getCPtr(pLayers));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbLayerState()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbLayerState(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
