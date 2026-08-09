using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbUnderlayDefinition : OdDbObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbUnderlayDefinition(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbUnderlayDefinition obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbUnderlayDefinition(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbUnderlayDefinition cast(OdRxObject pObj)
	{
		OdDbUnderlayDefinition rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnderlayDefinition>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbUnderlayDefinition createObject()
	{
		OdDbUnderlayDefinition rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnderlayDefinition>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setSourceFileName(string name)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_setSourceFileName(swigCPtr, name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string getSourceFileName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_getSourceFileName(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getActiveFileName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_getActiveFileName(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setItemName(string item)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_setItemName(swigCPtr, item);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string getItemName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_getItemName(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUnderlayItem(string sourceFileName, string activeFileName, OdDbUnderlayItem pItem)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_setUnderlayItem(swigCPtr, sourceFileName, activeFileName, OdDbUnderlayItem.getCPtr(pItem));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbUnderlayItem getUnderlayItem()
	{
		OdDbUnderlayItem rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnderlayItem>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_getUnderlayItem(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult load(string password)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_load(swigCPtr, password);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void unload()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_unload(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isLoaded()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_isLoaded(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static string dictionaryKey(OdRxClass underlayDefinitionType)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_dictionaryKey(OdRxClass.getCPtr(underlayDefinitionType));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId postDefinitionToDb(OdDbDatabase pDb, string defName)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_postDefinitionToDb(swigCPtr, OdDbDatabase.getCPtr(pDb), defName), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void applyPartialUndo(OdDbDwgFiler pFiler, OdRxClass pClass)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_applyPartialUndo(swigCPtr, OdDbDwgFiler.getCPtr(pFiler), OdRxClass.getCPtr(pClass));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObject SubWblockClone(ref OdDbIdMapping ownerIdMap, OdDbObject pOwner, bool bPrimary)
	{
		IntPtr jarg = ((ownerIdMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(ownerIdMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_SubWblockClone(swigCPtr, ref jarg, OdDbObject.getCPtr(pOwner), bPrimary), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				ownerIdMap = null;
			}
			if (jarg != intPtr)
			{
				ownerIdMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbUnderlayDefinition_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
