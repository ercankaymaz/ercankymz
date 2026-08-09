using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDatabase : OdDbObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDatabase(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDatabase obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDatabase(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbDatabase cast(OdRxObject pObj)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbDatabase createObject()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbHostAppServices appServices()
	{
		OdDbHostAppServices rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHostAppServices>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_appServices(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void initialize(MeasurementValue measurement)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_initialize__SWIG_0(swigCPtr, (int)measurement);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void initialize()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_initialize__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId addOdDbObject(OdDbObject pObject, OdDbObjectId ownerId, OdDbHandle handle)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_addOdDbObject__SWIG_0(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObjectId.getCPtr(ownerId), OdDbHandle.getCPtr(handle)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId addOdDbObject(OdDbObject pObject, OdDbObjectId ownerId)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_addOdDbObject__SWIG_1(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObjectId.getCPtr(ownerId)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId addOdDbObject(OdDbObject pObject)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_addOdDbObject__SWIG_2(swigCPtr, OdDbObject.getCPtr(pObject)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool newRegApp(string regAppName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_newRegApp(swigCPtr, regAppName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getBlockTableId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getBlockTableId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLayerTableId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLayerTableId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getTextStyleTableId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTextStyleTableId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLinetypeTableId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLinetypeTableId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getViewTableId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getViewTableId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getUCSTableId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSTableId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getViewportTableId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getViewportTableId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getRegAppTableId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getRegAppTableId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getDimStyleTableId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDimStyleTableId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getMLStyleDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMLStyleDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getMLStyleDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMLStyleDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getGroupDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getGroupDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getGroupDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getGroupDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLayoutDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLayoutDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLayoutDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLayoutDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getPlotStyleNameDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPlotStyleNameDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getPlotStyleNameDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPlotStyleNameDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getNamedObjectsDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getNamedObjectsDictionaryId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getPlotSettingsDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPlotSettingsDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getPlotSettingsDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPlotSettingsDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getColorDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getColorDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getColorDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getColorDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getMaterialDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMaterialDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getMaterialDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMaterialDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getVisualStyleDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVisualStyleDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getVisualStyleDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVisualStyleDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getTableStyleDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTableStyleDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getTableStyleDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTableStyleDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getScaleListDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getScaleListDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getScaleListDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getScaleListDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId tablestyle()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_tablestyle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTablestyle(OdDbObjectId objectId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTablestyle(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId getMLeaderStyleDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMLeaderStyleDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getMLeaderStyleDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMLeaderStyleDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId mleaderstyle()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_mleaderstyle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMLeaderstyle(OdDbObjectId objectId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMLeaderstyle(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId getDetailViewStyleDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDetailViewStyleDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getDetailViewStyleDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDetailViewStyleDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId detailViewStyle()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_detailViewStyle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDetailViewStyle(OdDbObjectId objectId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDetailViewStyle(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId getSectionViewStyleDictionaryId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSectionViewStyleDictionaryId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getSectionViewStyleDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSectionViewStyleDictionaryId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId sectionViewStyle()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_sectionViewStyle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSectionViewStyle(OdDbObjectId objectId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSectionViewStyle(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId getRegAppAcadId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getRegAppAcadId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLinetypeContinuousId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLinetypeContinuousId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLinetypeByLayerId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLinetypeByLayerId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLinetypeByBlockId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLinetypeByBlockId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getModelSpaceId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getModelSpaceId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getPaperSpaceId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPaperSpaceId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getTextStyleStandardId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTextStyleStandardId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getDimStyleStandardId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDimStyleStandardId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLayerZeroId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLayerZeroId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLayerDefpointsId(bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLayerDefpointsId__SWIG_0(swigCPtr, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLayerDefpointsId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLayerDefpointsId__SWIG_1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLayerAdskId(OdDb_LayerAdskType layerType, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLayerAdskId__SWIG_0(swigCPtr, (int)layerType, createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getLayerAdskId(OdDb_LayerAdskType layerType)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLayerAdskId__SWIG_1(swigCPtr, (int)layerType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getSectionManager()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSectionManager(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getPointCloudDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPointCloudDictionaryId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string classDxfName(OdRxClass pClass)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_classDxfName(swigCPtr, OdRxClass.getCPtr(pClass));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getOdDbObjectId(OdDbHandle objHandle, bool createIfNotFound, uint xRefId)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getOdDbObjectId__SWIG_0(swigCPtr, OdDbHandle.getCPtr(objHandle), createIfNotFound, xRefId), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getOdDbObjectId(OdDbHandle objHandle, bool createIfNotFound)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getOdDbObjectId__SWIG_1(swigCPtr, OdDbHandle.getCPtr(objHandle), createIfNotFound), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getOdDbObjectId(OdDbHandle objHandle)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getOdDbObjectId__SWIG_2(swigCPtr, OdDbHandle.getCPtr(objHandle)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void writeFile(OdStreamBuf pStreamBuf, OdDb_SaveType fileType, DwgVersion fileVersion, bool saveThumbnailImage, int dxfPrecision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_writeFile__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), (int)fileType, (int)fileVersion, saveThumbnailImage, dxfPrecision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void writeFile(OdStreamBuf pStreamBuf, OdDb_SaveType fileType, DwgVersion fileVersion, bool saveThumbnailImage)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_writeFile__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), (int)fileType, (int)fileVersion, saveThumbnailImage);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void writeFile(OdStreamBuf pStreamBuf, OdDb_SaveType fileType, DwgVersion fileVersion)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_writeFile__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), (int)fileType, (int)fileVersion);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void writeFile(string filename, OdDb_SaveType fileType, DwgVersion fileVersion, bool saveThumbnailImage, int dxfPrecision)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_writeFile__SWIG_3(swigCPtr, filename, (int)fileType, (int)fileVersion, saveThumbnailImage, dxfPrecision);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void writeFile(string filename, OdDb_SaveType fileType, DwgVersion fileVersion, bool saveThumbnailImage)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_writeFile__SWIG_4(swigCPtr, filename, (int)fileType, (int)fileVersion, saveThumbnailImage);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void writeFile(string filename, OdDb_SaveType fileType, DwgVersion fileVersion)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_writeFile__SWIG_5(swigCPtr, filename, (int)fileType, (int)fileVersion);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void save(OdStreamBuf pStreamBuf, bool saveThumbnailImage)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_save__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), saveThumbnailImage);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void save(OdStreamBuf pStreamBuf)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_save__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void save(string filename, bool saveThumbnailImage)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_save__SWIG_2(swigCPtr, filename, saveThumbnailImage);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void save(string filename)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_save__SWIG_3(swigCPtr, filename);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readFile(OdStreamBuf pStreamBuf, bool partialLoad, OdDbAuditInfo pAuditInfo, string password, bool allowCPConversion)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_readFile__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), partialLoad, OdDbAuditInfo.getCPtr(pAuditInfo), password, allowCPConversion);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readFile(OdStreamBuf pStreamBuf, bool partialLoad, OdDbAuditInfo pAuditInfo, string password)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_readFile__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), partialLoad, OdDbAuditInfo.getCPtr(pAuditInfo), password);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readFile(OdStreamBuf pStreamBuf, bool partialLoad, OdDbAuditInfo pAuditInfo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_readFile__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), partialLoad, OdDbAuditInfo.getCPtr(pAuditInfo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readFile(OdStreamBuf pStreamBuf, bool partialLoad)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_readFile__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), partialLoad);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readFile(OdStreamBuf pStreamBuf)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_readFile__SWIG_4(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readFile(string filename, bool partialLoad, Oda_FileShareMode shareMode, string password, bool allowCPConversion)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_readFile__SWIG_5(swigCPtr, filename, partialLoad, (int)shareMode, password, allowCPConversion);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readFile(string filename, bool partialLoad, Oda_FileShareMode shareMode, string password)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_readFile__SWIG_6(swigCPtr, filename, partialLoad, (int)shareMode, password);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readFile(string filename, bool partialLoad, Oda_FileShareMode shareMode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_readFile__SWIG_7(swigCPtr, filename, partialLoad, (int)shareMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readFile(string filename, bool partialLoad)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_readFile__SWIG_8(swigCPtr, filename, partialLoad);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readFile(string filename)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_readFile__SWIG_9(swigCPtr, filename);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void closeInput()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_closeInput(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int approxNumObjects()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_approxNumObjects(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public DwgVersion version(out MaintReleaseVer pMaintReleaseVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_version__SWIG_0(swigCPtr, out pMaintReleaseVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public DwgVersion version()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_version__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public int numberOfSaves()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_numberOfSaves(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public DwgVersion lastSavedAsVersion(out MaintReleaseVer pMaintReleaseVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_lastSavedAsVersion__SWIG_0(swigCPtr, out pMaintReleaseVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public DwgVersion lastSavedAsVersion()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_lastSavedAsVersion__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public OdDb_SaveType originalFileType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_originalFileType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_SaveType)result;
	}

	public DwgVersion originalFileVersion(out MaintReleaseVer pMaintReleaseVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_originalFileVersion__SWIG_0(swigCPtr, out pMaintReleaseVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public DwgVersion originalFileVersion()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_originalFileVersion__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public DwgVersion originalFileSavedByVersion(out MaintReleaseVer pMaintReleaseVer)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_originalFileSavedByVersion__SWIG_0(swigCPtr, out pMaintReleaseVer);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public DwgVersion originalFileSavedByVersion()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_originalFileSavedByVersion__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public void addReactor(OdDbDatabaseReactor pReactor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_addReactor(swigCPtr, OdDbDatabaseReactor.getCPtr(pReactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeReactor(OdDbDatabaseReactor pReactor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_removeReactor(swigCPtr, OdDbDatabaseReactor.getCPtr(pReactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int dimfit()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimfit(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int dimunit()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimunit(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimfit(int val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimfit(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDimunit(int val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimunit(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deepCloneObjects(OdDbObjectIdArray objectIds, OdDbObjectId ownerId, ref OdDbIdMapping idMap, bool deferXlation)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_deepCloneObjects__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(objectIds), OdDbObjectId.getCPtr(ownerId), ref jarg, deferXlation);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void deepCloneObjects(OdDbObjectIdArray objectIds, OdDbObjectId ownerId, ref OdDbIdMapping idMap)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_deepCloneObjects__SWIG_1(swigCPtr, OdDbObjectIdArray.getCPtr(objectIds), OdDbObjectId.getCPtr(ownerId), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void wblockCloneObjects(OdDbObjectIdArray objectIds, OdDbObjectId ownerId, ref OdDbIdMapping idMap, OdDb_DuplicateRecordCloning duplicateRecordCloning, bool deferXlation)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_wblockCloneObjects__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(objectIds), OdDbObjectId.getCPtr(ownerId), ref jarg, (int)duplicateRecordCloning, deferXlation);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void wblockCloneObjects(OdDbObjectIdArray objectIds, OdDbObjectId ownerId, ref OdDbIdMapping idMap, OdDb_DuplicateRecordCloning duplicateRecordCloning)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_wblockCloneObjects__SWIG_1(swigCPtr, OdDbObjectIdArray.getCPtr(objectIds), OdDbObjectId.getCPtr(ownerId), ref jarg, (int)duplicateRecordCloning);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void abortDeepClone(ref OdDbIdMapping idMap)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_abortDeepClone(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override void audit(OdDbAuditInfo pAuditInfo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_audit(swigCPtr, OdDbAuditInfo.getCPtr(pAuditInfo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void startTransaction()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_startTransaction(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool flushAllTransactedChanges()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_flushAllTransactedChanges(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void endTransaction()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_endTransaction(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void abortTransaction()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_abortTransaction(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int numActiveTransactions()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_numActiveTransactions(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void addTransactionReactor(OdDbTransactionReactor reactor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_addTransactionReactor(swigCPtr, OdDbTransactionReactor.getCPtr(reactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeTransactionReactor(OdDbTransactionReactor reactor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_removeTransactionReactor(swigCPtr, OdDbTransactionReactor.getCPtr(reactor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr thumbnailBitmap(out uint dataLength)
	{
		IntPtr result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_thumbnailBitmap(swigCPtr, out dataLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setThumbnailBitmap(IntPtr pBMPData, uint dataLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setThumbnailBitmap(swigCPtr, pBMPData, dataLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool retainOriginalThumbnailBitmap()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_retainOriginalThumbnailBitmap(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRetainOriginalThumbnailBitmap(bool retain)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setRetainOriginalThumbnailBitmap(swigCPtr, retain);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool getDIMANNO()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDIMANNO(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbDate getTDCREATE()
	{
		OdDbDate result = new OdDbDate(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTDCREATE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbDate getTDUPDATE()
	{
		OdDbDate result = new OdDbDate(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTDUPDATE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getCGEOCS()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCGEOCS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void resetTimes()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_resetTimes(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResBuf getSysVar(string name)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSysVar(swigCPtr, name), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setSysVar(string name, OdResBuf pValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSysVar(swigCPtr, name, OdResBuf.getCPtr(pValue));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbHandle handseed()
	{
		OdDbHandle result = new OdDbHandle(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_handseed(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getDimstyleData(OdDbDimStyleTableRecord pDestination)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDimstyleData(swigCPtr, OdDbDimStyleTableRecord.getCPtr(pDestination));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult getDimstyleChildData(OdRxClass pDimClass, OdDbDimStyleTableRecord pRec, OdDbObjectId style)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDimstyleChildData(swigCPtr, OdRxClass.getCPtr(pDimClass), OdDbDimStyleTableRecord.getCPtr(pRec), OdDbObjectId.getCPtr(style));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdDbObjectId getDimstyleChildId(OdRxClass pDimClass, OdDbObjectId parentStyle)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDimstyleChildId(swigCPtr, OdRxClass.getCPtr(pDimClass), OdDbObjectId.getCPtr(parentStyle)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getDimstyleParentId(OdDbObjectId childStyle)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDimstyleParentId(swigCPtr, OdDbObjectId.getCPtr(childStyle)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimstyleData(OdDbDimStyleTableRecord pSource)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimstyleData__SWIG_0(swigCPtr, OdDbDimStyleTableRecord.getCPtr(pSource));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDimstyleData(OdDbObjectId objectId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimstyleData__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void loadLineTypeFile(string ltName, string filename, OdDb_DuplicateLinetypeLoading dlt, OdDb_TextFileEncoding encode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_loadLineTypeFile__SWIG_0(swigCPtr, ltName, filename, (int)dlt, (int)encode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void loadLineTypeFile(string ltName, string filename, OdDb_DuplicateLinetypeLoading dlt)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_loadLineTypeFile__SWIG_1(swigCPtr, ltName, filename, (int)dlt);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void loadLineTypeFile(string ltName, string filename)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_loadLineTypeFile__SWIG_2(swigCPtr, ltName, filename);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string originalFilename()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_originalFilename(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFilename()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getFilename(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFilename(string fileName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setFilename(swigCPtr, fileName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void purge(OdDbObjectIdArray objectIds)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_purge__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(objectIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void purge(OdDbObjectIdGraph objectIds)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_purge__SWIG_1(swigCPtr, OdDbObjectIdGraph.getCPtr(objectIds));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void countHardReferences(OdDbObjectIdArray objectIds, OdUInt32Array counts)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_countHardReferences(swigCPtr, OdDbObjectIdArray.getCPtr(objectIds), OdUInt32Array.getCPtr(counts).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId currentLayoutId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_currentLayoutId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setCurrentLayout(string layoutName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCurrentLayout__SWIG_0(swigCPtr, layoutName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCurrentLayout(OdDbObjectId layoutId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCurrentLayout__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(layoutId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string findActiveLayout(bool allowModel)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_findActiveLayout(swigCPtr, allowModel);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getActiveLayoutBTRId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getActiveLayoutBTRId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId currentSpaceId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_currentSpaceId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId findLayoutNamed(string layoutName)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_findLayoutNamed(swigCPtr, layoutName), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void deleteLayout(string layoutName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_deleteLayout(swigCPtr, layoutName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId createLayout(string layoutName, OdDbObjectId pBlockTableRecId)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_createLayout__SWIG_0(swigCPtr, layoutName, OdDbObjectId.getCPtr(pBlockTableRecId)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId createLayout(string layoutName)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_createLayout__SWIG_1(swigCPtr, layoutName), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int countLayouts()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_countLayouts(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void renameLayout(string oldName, string newName)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_renameLayout(swigCPtr, oldName, newName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void startUndoRecord()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_startUndoRecord(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasUndo()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_hasUndo(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void undo()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_undo(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void blockUndoRecording(bool bBegin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_blockUndoRecording(swigCPtr, bBegin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isUndoBlockStarted()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_isUndoBlockStarted(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUndoMark()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUndoMark(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasUndoMark()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_hasUndoMark(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void undoBack()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_undoBack(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int getUNDOMARKS()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUNDOMARKS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearUndo()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_clearUndo(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasRedo()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_hasRedo(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearRedo()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_clearRedo(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void redo()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_redo(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void auditDatabase(OdDbAuditInfo pAuditInfo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_auditDatabase(swigCPtr, OdDbAuditInfo.getCPtr(pAuditInfo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void applyPartialUndo(OdDbDwgFiler pUndoFiler, OdRxClass pClassObj)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_applyPartialUndo(swigCPtr, OdDbDwgFiler.getCPtr(pUndoFiler), OdRxClass.getCPtr(pClassObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new OdDbDwgFiler undoFiler()
	{
		OdDbDwgFiler rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDwgFiler>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_undoFiler(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObjectId insert(string destinationBlockName, OdDbDatabase pSource, bool preserveSourceDatabase)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_insert__SWIG_0(swigCPtr, destinationBlockName, getCPtr(pSource), preserveSourceDatabase), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId insert(string destinationBlockName, OdDbDatabase pSource)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_insert__SWIG_1(swigCPtr, destinationBlockName, getCPtr(pSource)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId insert(string sourceBlockName, string destinationBlockName, OdDbDatabase pSource, bool preserveSourceDatabase)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_insert__SWIG_2(swigCPtr, sourceBlockName, destinationBlockName, getCPtr(pSource), preserveSourceDatabase), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId insert(string sourceBlockName, string destinationBlockName, OdDbDatabase pSource)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_insert__SWIG_3(swigCPtr, sourceBlockName, destinationBlockName, getCPtr(pSource)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void insert(OdGeMatrix3d xfm, OdDbDatabase pSource, bool preserveSourceDatabase)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_insert__SWIG_4(swigCPtr, OdGeMatrix3d.getCPtr(xfm), getCPtr(pSource), preserveSourceDatabase);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void insert(OdGeMatrix3d xfm, OdDbDatabase pSource)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_insert__SWIG_5(swigCPtr, OdGeMatrix3d.getCPtr(xfm), getCPtr(pSource));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDatabase wblock(OdDbObjectIdArray outObjIds, OdGePoint3d basePoint)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_wblock__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(outObjIds), OdGePoint3d.getCPtr(basePoint)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbDatabase wblock(OdDbObjectId blockId)
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_wblock__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(blockId)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbDatabase wblock()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_wblock__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void wblock(OdDbDatabase pOutputDb, OdDbObjectIdArray outObjIds, OdGePoint3d basePoint, OdDb_DuplicateRecordCloning drc)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_wblock__SWIG_3(swigCPtr, getCPtr(pOutputDb), OdDbObjectIdArray.getCPtr(outObjIds), OdGePoint3d.getCPtr(basePoint), (int)drc);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObject subWblockClone(ref OdDbIdMapping ownerIdMap, OdDbObject arg1)
	{
		IntPtr jarg = ((ownerIdMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(ownerIdMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_subWblockClone__SWIG_0(swigCPtr, ref jarg, OdDbObject.getCPtr(arg1)), bOwn: true, bTryAddToTransaction: true);
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

	public void setSecurityParams(OdSecurityParams secParams, bool setDbMod)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSecurityParams__SWIG_0(swigCPtr, OdSecurityParams.getCPtr(secParams), setDbMod);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSecurityParams(OdSecurityParams secParams)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSecurityParams__SWIG_1(swigCPtr, OdSecurityParams.getCPtr(secParams));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool securityParams(OdSecurityParams secParams)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_securityParams(swigCPtr, OdSecurityParams.getCPtr(secParams));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdFileDependencyManager fileDependencyManager()
	{
		OdFileDependencyManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_fileDependencyManager(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObjectContextManager objectContextManager()
	{
		OdDbObjectContextManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_objectContextManager(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbLayerStateManager getLayerStateManager()
	{
		OdDbLayerStateManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbLayerStateManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLayerStateManager(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void updateExt(bool bExact)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_updateExt__SWIG_0(swigCPtr, bExact);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void updateExt()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_updateExt__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isEMR()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_isEMR(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId xrefBlockId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_xrefBlockId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPartiallyOpened()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_isPartiallyOpened(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDatabaseLoading()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_isDatabaseLoading(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDatabaseConverting()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_isDatabaseConverting(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbAuditInfo auditInfo()
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_auditInfo(swigCPtr);
		OdDbAuditInfo result = ((intPtr == IntPtr.Zero) ? null : new OdDbAuditInfo(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCurrentUCS(OdDb_OrthographicView viewType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCurrentUCS__SWIG_0(swigCPtr, (int)viewType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCurrentUCS(OdDbObjectId ucsId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCurrentUCS__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(ucsId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCurrentUCS(OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCurrentUCS__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d getUCSBASEORG(OdDb_OrthographicView viewType)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSBASEORG(swigCPtr, (int)viewType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setUCSBASEORG(OdDb_OrthographicView viewType, OdGePoint3d origin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUCSBASEORG(swigCPtr, (int)viewType, OdGePoint3d.getCPtr(origin));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d getPUCSBASEORG(OdDb_OrthographicView viewType)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSBASEORG(swigCPtr, (int)viewType), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPUCSBASEORG(OdDb_OrthographicView viewType, OdGePoint3d origin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPUCSBASEORG(swigCPtr, (int)viewType, OdGePoint3d.getCPtr(origin));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void restoreOriginalXrefSymbols()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_restoreOriginalXrefSymbols(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void restoreForwardingXrefSymbols()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_restoreForwardingXrefSymbols(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isValidLineWeight(int weight)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_isValidLineWeight(weight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static LineWeight getNearestLineWeight(int weight)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getNearestLineWeight(weight);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public OdDbObjectId byLayerMaterialId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_byLayerMaterialId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId byBlockMaterialId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_byBlockMaterialId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId globalMaterialId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_globalMaterialId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId activeViewportId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_activeViewportId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbUnitsFormatter formatter()
	{
		OdDbUnitsFormatter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnitsFormatter>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_formatter(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void enableGraphicsFlush(bool bEnable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_enableGraphicsFlush(swigCPtr, bEnable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void flushGraphics()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_flushGraphics(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isMultiThreadedMode()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_isMultiThreadedMode(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public MultiThreadedMode multiThreadedMode()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_multiThreadedMode(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (MultiThreadedMode)result;
	}

	public virtual void setMultiThreadedMode(MultiThreadedMode arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMultiThreadedMode(swigCPtr, (int)arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCannoscale(OdDbAnnotationScale val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCannoscale(swigCPtr, OdDbAnnotationScale.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbAnnotationScale cannoscale()
	{
		OdDbAnnotationScale rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAnnotationScale>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_cannoscale(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObjectId dataLinkDictionaryId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dataLinkDictionaryId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbDictionary dataLinkDictionary(OdDb_OpenMode mode)
	{
		OdDbDictionary rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDictionary>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dataLinkDictionary(swigCPtr, (int)mode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool usingCoreOnly()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_usingCoreOnly(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool enqueuePaging(OdDbObjectId id)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_enqueuePaging(swigCPtr, OdDbObjectId.getCPtr(id));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool pageObjects()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_pageObjects(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int indexingMode()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_indexingMode(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setIndexingMode(int nIndexingModeBitFlags)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setIndexingMode(swigCPtr, nIndexingModeBitFlags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isPerObjectConverting()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_isPerObjectConverting(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbAppInfoRecordSet getAppInfo()
	{
		OdDbAppInfoRecordSet result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbAppInfoRecordSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getAppInfo(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbAppInfoRecordSet getAppInfoHistory()
	{
		OdDbAppInfoRecordSet result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbAppInfoRecordSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getAppInfoHistory(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult SubGetClassID(IntPtr pClsid)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_SubGetClassID(swigCPtr, pClsid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getHPPATHWIDTH()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHPPATHWIDTH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getHPCACHEAREA()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHPCACHEAREA(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getANGBASE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getANGBASE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getANGDIR()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getANGDIR(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getORTHOMODE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getORTHOMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getREGENMODE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getREGENMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getFILLMODE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getFILLMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getQTEXTMODE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getQTEXTMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getMIRRTEXT()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMIRRTEXT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getLTSCALE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLTSCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getATTMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getATTMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getTRACEWID()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTRACEWID(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getCLAYER()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCLAYER(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getCELTYPE()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCELTYPE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor getCECOLOR()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCECOLOR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getCELTSCALE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCELTSCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getCHAMFERA()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCHAMFERA(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getCHAMFERB()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCHAMFERB(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getCHAMFERC()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCHAMFERC(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getCHAMFERD()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCHAMFERD(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getDISPSILH()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDISPSILH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getDIMSTYLE()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDIMSTYLE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getDIMASO()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDIMASO(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getDIMSHO()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDIMSHO(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getLUNITS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLUNITS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getLUPREC()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLUPREC(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getSKETCHINC()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSKETCHINC(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getFILLETRAD()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getFILLETRAD(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getAUNITS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getAUNITS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getAUPREC()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getAUPREC(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getTHICKNESS()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTHICKNESS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getSKPOLY()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSKPOLY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getPDMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPDMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getPDSIZE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPDSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getPLINEWID()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPLINEWID(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getSPLFRAME()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSPLFRAME(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSPLINETYPE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSPLINETYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSPLINESEGS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSPLINESEGS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSURFTAB1()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSURFTAB1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSURFTAB2()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSURFTAB2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSURFTYPE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSURFTYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSURFU()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSURFU(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSURFV()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSURFV(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getUSERI1()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSERI1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getUSERI2()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSERI2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getUSERI3()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSERI3(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getUSERI4()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSERI4(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getUSERI5()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSERI5(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getUSERR1()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSERR1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getUSERR2()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSERR2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getUSERR3()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSERR3(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getUSERR4()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSERR4(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getPDFUNDERLAYSHADEDMODE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPDFUNDERLAYSHADEDMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getUSERR5()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSERR5(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getWORLDVIEW()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getWORLDVIEW(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSHADEDGE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSHADEDGE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSHADEDIF()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSHADEDIF(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getMAXACTVP()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMAXACTVP(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getUNITMODE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUNITMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getVISRETAIN()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVISRETAIN(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getPLINEGEN()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPLINEGEN(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getPSLTSCALE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPSLTSCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getTREEDEPTH()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTREEDEPTH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getCMLSTYLE()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCMLSTYLE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getCMLJUST()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCMLJUST(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getCMLSCALE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCMLSCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getPROXYGRAPHICS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPROXYGRAPHICS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual MeasurementValue getMEASUREMENT()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMEASUREMENT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (MeasurementValue)result;
	}

	public virtual LineWeight getCELWEIGHT()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCELWEIGHT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual bool getLWDISPLAY()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLWDISPLAY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual UnitsValue getINSUNITS()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getINSUNITS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (UnitsValue)result;
	}

	public virtual ushort getTSTACKALIGN()
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTSTACKALIGN(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ushort getTSTACKSIZE()
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTSTACKSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getHYPERLINKBASE()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHYPERLINKBASE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getXEDIT()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getXEDIT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getEXTNAMES()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getEXTNAMES(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getPSVPSCALE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPSVPSCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getOLESTARTUP()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getOLESTARTUP(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getPELLIPSE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPELLIPSE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ushort getISOLINES()
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getISOLINES(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ushort getTEXTQLTY()
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTEXTQLTY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getFACETRES()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getFACETRES(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getPUCSBASE()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSBASE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getUCSBASE()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSBASE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte getSOLIDHIST()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSOLIDHIST(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte getSHOWHIST()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSHOWHIST(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDb_LoftParamType getLOFTPARAM()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLOFTPARAM(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_LoftParamType)result;
	}

	public virtual OdDb_LoftNormalsType getLOFTNORMALS()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLOFTNORMALS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_LoftNormalsType)result;
	}

	public virtual double getLOFTANG1()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLOFTANG1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getLOFTANG2()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLOFTANG2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getLOFTMAG1()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLOFTMAG1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getLOFTMAG2()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLOFTMAG2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getLATITUDE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLATITUDE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getLONGITUDE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLONGITUDE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getNORTHDIRECTION()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getNORTHDIRECTION(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDb_TimeZone getTIMEZONE()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTIMEZONE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_TimeZone)result;
	}

	public virtual sbyte getLIGHTGLYPHDISPLAY()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLIGHTGLYPHDISPLAY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte getTILEMODELIGHTSYNCH()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTILEMODELIGHTSYNCH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor getINTERFERECOLOR()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getINTERFERECOLOR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getINTERFEREOBJVS()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getINTERFEREOBJVS(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getINTERFEREVPVS()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getINTERFEREVPVS(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getDRAGVS()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDRAGVS(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiSubEntityTraits_ShadowFlags getCSHADOW()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCSHADOW(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiSubEntityTraits_ShadowFlags)result;
	}

	public virtual double getSHADOWPLANELOCATION()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSHADOWPLANELOCATION(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getCAMERADISPLAY()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCAMERADISPLAY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getLENSLENGTH()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLENSLENGTH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getCAMERAHEIGHT()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCAMERAHEIGHT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getSTEPSPERSEC()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSTEPSPERSEC(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getSTEPSIZE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSTEPSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double get3DDWFPREC()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_get3DDWFPREC(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getCMATERIAL()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCMATERIAL(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getREALWORLDSCALE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getREALWORLDSCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getDYNCONSTRAINTDISPLAY()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDYNCONSTRAINTDISPLAY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getMATERIALFBX()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMATERIALFBX(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbDate getTDUCREATE()
	{
		OdDbDate result = new OdDbDate(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTDUCREATE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbDate getTDUUPDATE()
	{
		OdDbDate result = new OdDbDate(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTDUUPDATE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbDate getTDINDWG()
	{
		OdDbDate result = new OdDbDate(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTDINDWG(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbDate getTDUSRTIMER()
	{
		OdDbDate result = new OdDbDate(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTDUSRTIMER(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getPSTYLEMODE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPSTYLEMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCodePageId getDWGCODEPAGE()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDWGCODEPAGE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdCodePageId)result;
	}

	public virtual long getREQUIREDVERSIONS()
	{
		long result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getREQUIREDVERSIONS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getTRACECURRENT()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTRACECURRENT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual byte getTRACEMODE()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTRACEMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual byte getTRACEDISPLAYMODE()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTRACEDISPLAYMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getUCSORG()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSORG(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d getUCSXDIR()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSXDIR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d getUCSYDIR()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSYDIR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPUCSORG()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSORG(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d getPUCSXDIR()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSXDIR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d getPUCSYDIR()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSYDIR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getINSBASE()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getINSBASE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getEXTMIN()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getEXTMIN(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getEXTMAX()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getEXTMAX(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint2d getLIMMIN()
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLIMMIN(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint2d getLIMMAX()
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLIMMAX(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getMENUNAME()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMENUNAME(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getELEVATION()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getELEVATION(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getPELEVATION()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPELEVATION(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getLIMCHECK()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLIMCHECK(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getUSRTIMER()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUSRTIMER(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPINSBASE()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPINSBASE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getPLIMCHECK()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPLIMCHECK(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPEXTMIN()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPEXTMIN(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPEXTMAX()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPEXTMAX(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint2d getPLIMMIN()
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPLIMMIN(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint2d getPLIMMAX()
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPLIMMAX(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getUCSNAME()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSNAME(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getPUCSNAME()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSNAME(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDb_EndCaps getENDCAPS()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getENDCAPS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_EndCaps)result;
	}

	public virtual OdDb_JoinStyle getJOINSTYLE()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getJOINSTYLE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_JoinStyle)result;
	}

	public virtual string getSTYLESHEET()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSTYLESHEET(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual PlotStyleNameType getCEPSNTYPE()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCEPSNTYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PlotStyleNameType)result;
	}

	public virtual OdDbObjectId getCEPSNID()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCEPSNID(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getFINGERPRINTGUID()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getFINGERPRINTGUID(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getVERSIONGUID()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVERSIONGUID(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getPUCSORTHOVIEW()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSORTHOVIEW(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPUCSORGTOP()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSORGTOP(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPUCSORGBOTTOM()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSORGBOTTOM(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPUCSORGLEFT()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSORGLEFT(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPUCSORGRIGHT()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSORGRIGHT(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPUCSORGFRONT()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSORGFRONT(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPUCSORGBACK()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPUCSORGBACK(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getUCSORTHOVIEW()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSORTHOVIEW(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getUCSORGTOP()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSORGTOP(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getUCSORGBOTTOM()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSORGBOTTOM(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getUCSORGLEFT()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSORGLEFT(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getUCSORGRIGHT()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSORGRIGHT(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getUCSORGFRONT()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSORGFRONT(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getUCSORGBACK()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUCSORGBACK(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte getDGNFRAME()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDGNFRAME(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getDBCSTATE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDBCSTATE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getINTERSECTIONCOLOR()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getINTERSECTIONCOLOR(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getINTERSECTIONDISPLAY()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getINTERSECTIONDISPLAY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getHALOGAP()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHALOGAP(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getOBSCUREDCOLOR()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getOBSCUREDCOLOR(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getOBSCUREDLTYPE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getOBSCUREDLTYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getINDEXCTL()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getINDEXCTL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getPROJECTNAME()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPROJECTNAME(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSORTENTS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSORTENTS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getDIMASSOC()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDIMASSOC(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getHIDETEXT()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHIDETEXT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getPSOLWIDTH()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPSOLWIDTH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getPSOLHEIGHT()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPSOLHEIGHT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getCTABLESTYLE()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCTABLESTYLE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getANNOALLVISIBLE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getANNOALLVISIBLE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte getANNOTATIVEDWG()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getANNOTATIVEDWG(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getMSLTSCALE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMSLTSCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getLAYEREVAL()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLAYEREVAL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getLAYERNOTIFY()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLAYERNOTIFY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getLIGHTINGUNITS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLIGHTINGUNITS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getLIGHTSINBLOCKS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getLIGHTSINBLOCKS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte getDRAWORDERCTL()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDRAWORDERCTL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getHPINHERIT()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHPINHERIT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint2d getHPORIGIN()
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHPORIGIN(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getFIELDEVAL()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getFIELDEVAL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getMSOLESCALE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMSOLESCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getUPDATETHUMBNAIL()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getUPDATETHUMBNAIL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getDXEVAL()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDXEVAL(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getGEOLATLONGFORMAT()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getGEOLATLONGFORMAT(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getGEOMARKERVISIBILITY()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getGEOMARKERVISIBILITY(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getPREVIEWTYPE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPREVIEWTYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getEXPORTMODELSPACE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getEXPORTMODELSPACE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getEXPORTPAPERSPACE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getEXPORTPAPERSPACE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getEXPORTPAGESETUP()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getEXPORTPAGESETUP(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getMESHTYPE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMESHTYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getSKYSTATUS()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSKYSTATUS(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getVSACURVATUREHIGH()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVSACURVATUREHIGH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getVSACURVATURELOW()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVSACURVATURELOW(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getVSACURVATURETYPE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVSACURVATURETYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getVSADRAFTANGLEHIGH()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVSADRAFTANGLEHIGH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getVSADRAFTANGLELOW()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVSADRAFTANGLELOW(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getVSAZEBRACOLOR1()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVSAZEBRACOLOR1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getVSAZEBRACOLOR2()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVSAZEBRACOLOR2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getVSAZEBRADIRECTION()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVSAZEBRADIRECTION(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getVSAZEBRASIZE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVSAZEBRASIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getVSAZEBRATYPE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVSAZEBRATYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getHPLAYER()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHPLAYER(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getMIRRHATCH()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMIRRHATCH(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmTransparency getHPTRANSPARENCY()
	{
		OdCmTransparency result = new OdCmTransparency(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHPTRANSPARENCY(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor getHPCOLOR()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHPCOLOR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmColor getHPBACKGROUNDCOLOR()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getHPBACKGROUNDCOLOR(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmTransparency getCETRANSPARENCY()
	{
		OdCmTransparency result = new OdCmTransparency(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCETRANSPARENCY(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getCVIEWDETAILSTYLE()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCVIEWDETAILSTYLE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getCVIEWSECTIONSTYLE()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCVIEWSECTIONSTYLE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getWIPEOUTFRAME()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getWIPEOUTFRAME(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getPOINTCLOUDCLIPFRAME()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPOINTCLOUDCLIPFRAME(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getMLEADERSCALE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getMLEADERSCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getVIEWUPDATEAUTO()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getVIEWUPDATEAUTO(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getGEOMARKPOSITIONSIZE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getGEOMARKPOSITIONSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getPOINTCLOUDPOINTSIZE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPOINTCLOUDPOINTSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getDIMLAYER()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDIMLAYER(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getSECTIONOFFSETINC()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSECTIONOFFSETINC(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getSECTIONTHICKNESSINC()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getSECTIONTHICKNESSINC(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getXREFOVERRIDE()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getXREFOVERRIDE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getCENTERCROSSGAP()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCENTERCROSSGAP(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getCENTERCROSSSIZE()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCENTERCROSSSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getCENTEREXE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCENTEREXE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getCENTERLAYER()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCENTERLAYER(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getCENTERLTSCALE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCENTERLTSCALE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getCENTERLTYPE()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCENTERLTYPE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getCENTERLTYPEFILE()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCENTERLTYPEFILE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getCENTERMARKEXE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCENTERMARKEXE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbAnnotationScale getCANNOSCALE()
	{
		OdDbAnnotationScale rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAnnotationScale>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCANNOSCALE(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbObjectId getCMLEADERSTYLE()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getCMLEADERSTYLE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double getTEXTSIZE()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTEXTSIZE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectId getTEXTSTYLE()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTEXTSTYLE(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getTILEMODE()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getTILEMODE(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual sbyte getDWFFRAME()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getDWFFRAME(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getFRAME()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getFRAME(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getPDFFRAME()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getPDFFRAME(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short getXCLIPFRAME()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_getXCLIPFRAME(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHPPATHWIDTH(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHPPATHWIDTH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHPCACHEAREA(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHPCACHEAREA(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setANGBASE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setANGBASE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setANGDIR(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setANGDIR(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setORTHOMODE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setORTHOMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setREGENMODE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setREGENMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFILLMODE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setFILLMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setQTEXTMODE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setQTEXTMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMIRRTEXT(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMIRRTEXT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLTSCALE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLTSCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setATTMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setATTMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTRACEWID(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTRACEWID(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCLAYER(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCLAYER(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCELTYPE(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCELTYPE(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCECOLOR(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCECOLOR(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCELTSCALE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCELTSCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCHAMFERA(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCHAMFERA(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCHAMFERB(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCHAMFERB(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCHAMFERC(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCHAMFERC(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCHAMFERD(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCHAMFERD(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDISPSILH(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDISPSILH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDIMSTYLE(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDIMSTYLE(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDIMASO(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDIMASO(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDIMSHO(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDIMSHO(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLUNITS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLUNITS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLUPREC(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLUPREC(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSKETCHINC(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSKETCHINC(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFILLETRAD(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setFILLETRAD(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setAUNITS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setAUNITS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setAUPREC(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setAUPREC(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTHICKNESS(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTHICKNESS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSKPOLY(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSKPOLY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPDMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPDMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPDSIZE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPDSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPLINEWID(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPLINEWID(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSPLFRAME(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSPLFRAME(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSPLINETYPE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSPLINETYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSPLINESEGS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSPLINESEGS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSURFTAB1(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSURFTAB1(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSURFTAB2(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSURFTAB2(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSURFTYPE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSURFTYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSURFU(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSURFU(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSURFV(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSURFV(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSERI1(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSERI1(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSERI2(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSERI2(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSERI3(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSERI3(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSERI4(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSERI4(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSERI5(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSERI5(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSERR1(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSERR1(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSERR2(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSERR2(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSERR3(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSERR3(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSERR4(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSERR4(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPDFUNDERLAYSHADEDMODE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPDFUNDERLAYSHADEDMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSERR5(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSERR5(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setWORLDVIEW(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setWORLDVIEW(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSHADEDGE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSHADEDGE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSHADEDIF(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSHADEDIF(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMAXACTVP(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMAXACTVP(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUNITMODE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUNITMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVISRETAIN(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVISRETAIN(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPLINEGEN(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPLINEGEN(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPSLTSCALE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPSLTSCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTREEDEPTH(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTREEDEPTH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCMLSTYLE(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCMLSTYLE(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCMLJUST(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCMLJUST(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCMLSCALE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCMLSCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPROXYGRAPHICS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPROXYGRAPHICS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMEASUREMENT(MeasurementValue val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMEASUREMENT(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCELWEIGHT(LineWeight val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCELWEIGHT(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLWDISPLAY(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLWDISPLAY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setINSUNITS(UnitsValue val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setINSUNITS(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTSTACKALIGN(ushort val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTSTACKALIGN(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTSTACKSIZE(ushort val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTSTACKSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHYPERLINKBASE(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHYPERLINKBASE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setXEDIT(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setXEDIT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEXTNAMES(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setEXTNAMES(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPSVPSCALE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPSVPSCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setOLESTARTUP(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setOLESTARTUP(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPELLIPSE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPELLIPSE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setISOLINES(ushort val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setISOLINES(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTEXTQLTY(ushort val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTEXTQLTY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFACETRES(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setFACETRES(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPUCSBASE(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPUCSBASE(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUCSBASE(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUCSBASE(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSOLIDHIST(sbyte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSOLIDHIST(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSHOWHIST(sbyte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSHOWHIST(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLOFTPARAM(OdDb_LoftParamType val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLOFTPARAM(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLOFTNORMALS(OdDb_LoftNormalsType val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLOFTNORMALS(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLOFTANG1(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLOFTANG1(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLOFTANG2(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLOFTANG2(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLOFTMAG1(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLOFTMAG1(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLOFTMAG2(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLOFTMAG2(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLATITUDE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLATITUDE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLONGITUDE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLONGITUDE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setNORTHDIRECTION(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setNORTHDIRECTION(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTIMEZONE(OdDb_TimeZone val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTIMEZONE(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLIGHTGLYPHDISPLAY(sbyte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLIGHTGLYPHDISPLAY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTILEMODELIGHTSYNCH(sbyte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTILEMODELIGHTSYNCH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setINTERFERECOLOR(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setINTERFERECOLOR(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setINTERFEREOBJVS(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setINTERFEREOBJVS(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setINTERFEREVPVS(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setINTERFEREVPVS(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDRAGVS(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDRAGVS(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCSHADOW(OdGiSubEntityTraits_ShadowFlags val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCSHADOW(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSHADOWPLANELOCATION(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSHADOWPLANELOCATION(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCAMERADISPLAY(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCAMERADISPLAY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLENSLENGTH(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLENSLENGTH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCAMERAHEIGHT(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCAMERAHEIGHT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSTEPSPERSEC(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSTEPSPERSEC(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSTEPSIZE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSTEPSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void set3DDWFPREC(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_set3DDWFPREC(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCMATERIAL(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCMATERIAL(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setREALWORLDSCALE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setREALWORLDSCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDYNCONSTRAINTDISPLAY(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDYNCONSTRAINTDISPLAY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMATERIALFBX(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMATERIALFBX(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setINSBASE(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setINSBASE(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEXTMIN(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setEXTMIN(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEXTMAX(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setEXTMAX(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLIMMIN(OdGePoint2d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLIMMIN(swigCPtr, OdGePoint2d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLIMMAX(OdGePoint2d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLIMMAX(swigCPtr, OdGePoint2d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMENUNAME(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMENUNAME(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setELEVATION(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setELEVATION(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPELEVATION(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPELEVATION(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLIMCHECK(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLIMCHECK(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUSRTIMER(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUSRTIMER(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPINSBASE(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPINSBASE(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPLIMCHECK(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPLIMCHECK(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPEXTMIN(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPEXTMIN(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPEXTMAX(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPEXTMAX(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPLIMMIN(OdGePoint2d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPLIMMIN(swigCPtr, OdGePoint2d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPLIMMAX(OdGePoint2d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPLIMMAX(swigCPtr, OdGePoint2d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUCSNAME(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUCSNAME(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPUCSNAME(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPUCSNAME(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setENDCAPS(OdDb_EndCaps val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setENDCAPS(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setJOINSTYLE(OdDb_JoinStyle val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setJOINSTYLE(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSTYLESHEET(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSTYLESHEET(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCEPSNTYPE(PlotStyleNameType val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCEPSNTYPE(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCEPSNID(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCEPSNID(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFINGERPRINTGUID(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setFINGERPRINTGUID(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVERSIONGUID(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVERSIONGUID(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPUCSORTHOVIEW(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPUCSORTHOVIEW(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPUCSORGTOP(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPUCSORGTOP(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPUCSORGBOTTOM(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPUCSORGBOTTOM(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPUCSORGLEFT(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPUCSORGLEFT(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPUCSORGRIGHT(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPUCSORGRIGHT(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPUCSORGFRONT(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPUCSORGFRONT(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPUCSORGBACK(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPUCSORGBACK(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUCSORTHOVIEW(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUCSORTHOVIEW(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUCSORGTOP(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUCSORGTOP(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUCSORGBOTTOM(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUCSORGBOTTOM(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUCSORGLEFT(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUCSORGLEFT(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUCSORGRIGHT(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUCSORGRIGHT(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUCSORGFRONT(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUCSORGFRONT(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUCSORGBACK(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUCSORGBACK(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDGNFRAME(sbyte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDGNFRAME(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDBCSTATE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDBCSTATE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setINTERSECTIONCOLOR(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setINTERSECTIONCOLOR(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setINTERSECTIONDISPLAY(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setINTERSECTIONDISPLAY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHALOGAP(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHALOGAP(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setOBSCUREDCOLOR(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setOBSCUREDCOLOR(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setOBSCUREDLTYPE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setOBSCUREDLTYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setINDEXCTL(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setINDEXCTL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPROJECTNAME(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPROJECTNAME(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSORTENTS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSORTENTS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDIMASSOC(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDIMASSOC(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHIDETEXT(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHIDETEXT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPSOLWIDTH(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPSOLWIDTH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPSOLHEIGHT(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPSOLHEIGHT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCTABLESTYLE(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCTABLESTYLE(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setANNOALLVISIBLE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setANNOALLVISIBLE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setANNOTATIVEDWG(sbyte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setANNOTATIVEDWG(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMSLTSCALE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMSLTSCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLAYEREVAL(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLAYEREVAL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLAYERNOTIFY(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLAYERNOTIFY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLIGHTINGUNITS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLIGHTINGUNITS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLIGHTSINBLOCKS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setLIGHTSINBLOCKS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDRAWORDERCTL(sbyte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDRAWORDERCTL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHPINHERIT(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHPINHERIT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHPORIGIN(OdGePoint2d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHPORIGIN(swigCPtr, OdGePoint2d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFIELDEVAL(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setFIELDEVAL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMSOLESCALE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMSOLESCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setUPDATETHUMBNAIL(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setUPDATETHUMBNAIL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDXEVAL(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDXEVAL(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGEOLATLONGFORMAT(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setGEOLATLONGFORMAT(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGEOMARKERVISIBILITY(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setGEOMARKERVISIBILITY(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPREVIEWTYPE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPREVIEWTYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEXPORTMODELSPACE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setEXPORTMODELSPACE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEXPORTPAPERSPACE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setEXPORTPAPERSPACE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setEXPORTPAGESETUP(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setEXPORTPAGESETUP(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMESHTYPE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMESHTYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSKYSTATUS(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSKYSTATUS(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVSACURVATUREHIGH(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVSACURVATUREHIGH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVSACURVATURELOW(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVSACURVATURELOW(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVSACURVATURETYPE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVSACURVATURETYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVSADRAFTANGLEHIGH(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVSADRAFTANGLEHIGH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVSADRAFTANGLELOW(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVSADRAFTANGLELOW(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVSAZEBRACOLOR1(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVSAZEBRACOLOR1(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVSAZEBRACOLOR2(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVSAZEBRACOLOR2(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVSAZEBRADIRECTION(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVSAZEBRADIRECTION(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVSAZEBRASIZE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVSAZEBRASIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVSAZEBRATYPE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVSAZEBRATYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHPLAYER(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHPLAYER(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMIRRHATCH(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMIRRHATCH(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHPTRANSPARENCY(OdCmTransparency val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHPTRANSPARENCY(swigCPtr, OdCmTransparency.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHPCOLOR(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHPCOLOR(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setHPBACKGROUNDCOLOR(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setHPBACKGROUNDCOLOR(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCETRANSPARENCY(OdCmTransparency val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCETRANSPARENCY(swigCPtr, OdCmTransparency.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCVIEWDETAILSTYLE(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCVIEWDETAILSTYLE(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCVIEWSECTIONSTYLE(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCVIEWSECTIONSTYLE(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setWIPEOUTFRAME(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setWIPEOUTFRAME(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPOINTCLOUDCLIPFRAME(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPOINTCLOUDCLIPFRAME(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMLEADERSCALE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setMLEADERSCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVIEWUPDATEAUTO(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setVIEWUPDATEAUTO(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setGEOMARKPOSITIONSIZE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setGEOMARKPOSITIONSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPOINTCLOUDPOINTSIZE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPOINTCLOUDPOINTSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDIMLAYER(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDIMLAYER(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSECTIONOFFSETINC(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSECTIONOFFSETINC(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSECTIONTHICKNESSINC(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setSECTIONTHICKNESSINC(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setXREFOVERRIDE(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setXREFOVERRIDE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCENTERCROSSGAP(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCENTERCROSSGAP(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCENTERCROSSSIZE(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCENTERCROSSSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCENTEREXE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCENTEREXE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCENTERLAYER(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCENTERLAYER(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCENTERLTSCALE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCENTERLTSCALE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCENTERLTYPE(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCENTERLTYPE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCENTERLTYPEFILE(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCENTERLTYPEFILE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCENTERMARKEXE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCENTERMARKEXE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCANNOSCALE(OdDbAnnotationScale val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCANNOSCALE(swigCPtr, OdDbAnnotationScale.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setCMLEADERSTYLE(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setCMLEADERSTYLE(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTEXTSIZE(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTEXTSIZE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTEXTSTYLE(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTEXTSTYLE(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTILEMODE(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setTILEMODE(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDWFFRAME(sbyte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDWFFRAME(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setFRAME(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setFRAME(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPDFFRAME(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setPDFFRAME(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setXCLIPFRAME(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setXCLIPFRAME(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimadec()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimadec(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimadec(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimadec(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimalt()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimalt(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimalt(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimalt(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ushort dimaltd()
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimaltd(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimaltd(ushort val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimaltd(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimaltf()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimaltf(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimaltf(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimaltf(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimaltrnd()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimaltrnd(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimaltrnd(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimaltrnd(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimalttd()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimalttd(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimalttd(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimalttd(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte dimalttz()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimalttz(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimalttz(byte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimalttz(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimaltu()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimaltu(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimaltu(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimaltu(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte dimaltz()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimaltz(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimaltz(byte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimaltz(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string dimapost()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimapost(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimapost(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimapost(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimasz()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimasz(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimasz(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimasz(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimaunit()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimaunit(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimaunit(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimaunit(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimazin()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimazin(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimazin(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimazin(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimcen()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimcen(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimcen(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimcen(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor dimclrd()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimclrd(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimclrd(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimclrd(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor dimclre()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimclre(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimclre(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimclre(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor dimclrt()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimclrt(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimclrt(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimclrt(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimdec()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimdec(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimdec(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimdec(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimdle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimdle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimdle(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimdle(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimdli()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimdli(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimdli(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimdli(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimdsep()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimdsep(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimdsep(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimdsep(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimexe()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimexe(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimexe(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimexe(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimexo()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimexo(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimexo(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimexo(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimfrac()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimfrac(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimfrac(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimfrac(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimgap()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimgap(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimgap(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimgap(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ushort dimjust()
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimjust(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimjust(ushort val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimjust(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbHardPointerId dimldrblk()
	{
		OdDbHardPointerId result = new OdDbHardPointerId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimldrblk(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimldrblk(OdDbHardPointerId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimldrblk(swigCPtr, OdDbHardPointerId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimlfac()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimlfac(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimlfac(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimlfac(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimlim()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimlim(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimlim(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimlim(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimlunit()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimlunit(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimlunit(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimlunit(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual LineWeight dimlwd()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimlwd(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual void setDimlwd(LineWeight val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimlwd(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual LineWeight dimlwe()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimlwe(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual void setDimlwe(LineWeight val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimlwe(swigCPtr, (int)val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string dimpost()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimpost(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimpost(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimpost(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimrnd()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimrnd(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimrnd(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimrnd(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimsah()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimsah(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimsah(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimsah(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimscale()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimscale(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimscale(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimscale(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimsd1()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimsd1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimsd1(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimsd1(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimsd2()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimsd2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimsd2(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimsd2(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimse1()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimse1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimse1(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimse1(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimse2()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimse2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimse2(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimse2(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimtad()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtad(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtad(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtad(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimtdec()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtdec(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtdec(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtdec(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimtfac()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtfac(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtfac(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtfac(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimtih()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtih(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtih(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtih(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimtm()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtm(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtm(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtm(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimtoh()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtoh(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtoh(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtoh(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimtol()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtol(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtol(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtol(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte dimtolj()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtolj(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtolj(byte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtolj(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimtp()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtp(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtp(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtp(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimtsz()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtsz(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtsz(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtsz(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimtvp()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtvp(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtvp(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtvp(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId dimtxsty()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtxsty(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtxsty(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtxsty(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimtxt()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtxt(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtxt(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtxt(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte dimtzin()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtzin(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtzin(byte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtzin(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimupt()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimupt(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimupt(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimupt(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual byte dimzin()
	{
		byte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimzin(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimzin(byte val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimzin(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimfxl()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimfxl(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimfxl(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimfxl(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimfxlon()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimfxlon(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimfxlon(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimfxlon(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimjogang()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimjogang(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimjogang(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimjogang(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimtfill()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtfill(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtfill(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtfill(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmColor dimtfillclr()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtfillclr(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtfillclr(OdCmColor val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtfillclr(swigCPtr, OdCmColor.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimarcsym()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimarcsym(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimarcsym(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimarcsym(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId dimltype()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimltype(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimltype(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimltype(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId dimltex1()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimltex1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimltex1(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimltex1(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbObjectId dimltex2()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimltex2(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimltex2(OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimltex2(swigCPtr, OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimtxtdirection()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtxtdirection(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtxtdirection(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtxtdirection(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimmzf()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimmzf(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimmzf(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimmzf(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string dimmzs()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimmzs(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimmzs(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimmzs(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double dimaltmzf()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimaltmzf(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimaltmzf(double val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimaltmzf(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string dimaltmzs()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimaltmzs(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimaltmzs(string val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimaltmzs(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbHardPointerId dimblk()
	{
		OdDbHardPointerId result = new OdDbHardPointerId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimblk(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimblk(OdDbHardPointerId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimblk(swigCPtr, OdDbHardPointerId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbHardPointerId dimblk1()
	{
		OdDbHardPointerId result = new OdDbHardPointerId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimblk1(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimblk1(OdDbHardPointerId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimblk1(swigCPtr, OdDbHardPointerId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbHardPointerId dimblk2()
	{
		OdDbHardPointerId result = new OdDbHardPointerId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimblk2(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimblk2(OdDbHardPointerId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimblk2(swigCPtr, OdDbHardPointerId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimatfit()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimatfit(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimatfit(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimatfit(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimsoxd()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimsoxd(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimsoxd(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimsoxd(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimtix()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtix(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtix(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtix(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual short dimtmove()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtmove(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtmove(short val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtmove(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool dimtofl()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_dimtofl(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDimtofl(bool val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDatabase_setDimtofl(swigCPtr, val);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
