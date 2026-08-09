using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbBlockElement : OdDbEvalConnectable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBlockElement(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBlockElement obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbBlockElement(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBlockElement cast(OdRxObject pObj)
	{
		OdDbBlockElement rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockElement>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbBlockElement createObject()
	{
		OdDbBlockElement rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockElement>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dwgOutFields(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void dxfOutFields(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void adjacentEdgeAdded(uint fromId, uint toId, bool isInvertible)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_adjacentEdgeAdded(swigCPtr, fromId, toId, isInvertible);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void addedToGraph(OdDbEvalGraph pGraph)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_addedToGraph(swigCPtr, OdDbEvalGraph.getCPtr(pGraph));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void adjacentNodeRemoved(uint arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_adjacentNodeRemoved(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool evaluate(OdDbEvalContext arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_evaluate(swigCPtr, OdDbEvalContext.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool connectionAllowed(string arg0, uint arg1, string arg2)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_connectionAllowed(swigCPtr, arg0, arg1, arg2);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool connectTo(string arg0, uint arg1, string arg2)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_connectTo(swigCPtr, arg0, arg1, arg2);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool disconnectFrom(string arg0, uint arg1, string arg2)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_disconnectFrom(swigCPtr, arg0, arg1, arg2);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool hasConnectionNamed(string arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_hasConnectionNamed(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool getConnectedNames(string arg0, uint arg1, OdStringArray arg2)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getConnectedNames(swigCPtr, arg0, arg1, OdStringArray.getCPtr(arg2).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool getConnectedObjects(string arg0, OdDbEvalNodeIdArray arg1)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getConnectedObjects(swigCPtr, arg0, OdDbEvalNodeIdArray.getCPtr(arg1));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void getConnectionNames(OdStringArray arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getConnectionNames(swigCPtr, OdStringArray.getCPtr(arg0).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override DwgDataType getConnectionType(string name)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getConnectionType(swigCPtr, name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgDataType)result;
	}

	public override OdDbEvalVariant getConnectionValue(string name)
	{
		OdDbEvalVariant result = new OdDbEvalVariant(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getConnectionValue(swigCPtr, name), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string name()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_name(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setName(string arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_setName(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint alertState()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_alertState(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void auditAlertState()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_auditAlertState(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual DwgVersion getInstanceVersion()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getInstanceVersion(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	public virtual MaintReleaseVer getInstanceMaintenanceVersion()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getInstanceMaintenanceVersion(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (MaintReleaseVer)result;
	}

	public virtual void getStretchPoints(OdGePoint3dArray points)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getStretchPoints(swigCPtr, OdGePoint3dArray.getCPtr(points).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void moveStretchPointsAt(OdIntArray indices, OdGeVector3d offset)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_moveStretchPointsAt(swigCPtr, OdIntArray.getCPtr(indices).Handle, OdGeVector3d.getCPtr(offset));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool historyRequired()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_historyRequired(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isNameUnique(OdDbEvalGraph graph, string name, ref string prefix)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(prefix);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_isNameUnique__SWIG_0(OdDbEvalGraph.getCPtr(graph), name, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				prefix = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static bool isNameUnique(OdDbEvalGraph graph, string name)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_isNameUnique__SWIG_1(OdDbEvalGraph.getCPtr(graph), name);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasInstanceData()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_hasInstanceData(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadInstanceData(OdResBuf arg0, bool bRequireEvaluate)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_loadInstanceData__SWIG_0(swigCPtr, OdResBuf.getCPtr(arg0), bRequireEvaluate);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadInstanceData(OdResBuf arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_loadInstanceData__SWIG_1(swigCPtr, OdResBuf.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResBuf saveInstanceData()
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_saveInstanceData(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isMemberOfCurrentVisibilitySet()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_isMemberOfCurrentVisibilitySet(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMemberOfCurrentVisibilitySet(bool arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_setMemberOfCurrentVisibilitySet(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void transformDefinitionBy(OdGeMatrix3d arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_transformDefinitionBy(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult transformBy(OdGeMatrix3d arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public override void modified(OdDbObject pObject)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_modified(swigCPtr, OdDbObject.getCPtr(pObject));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult sync(OdDbBlockElementEntity arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_sync(swigCPtr, OdDbBlockElementEntity.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbObjectId getEntity()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getEntity(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxClass getRxEntity()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getRxEntity(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool onBeginEdit(OdDbBlockTableRecord arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_onBeginEdit(swigCPtr, OdDbBlockTableRecord.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void onBeginEditEnded(OdDbObjectId entityId, OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_onBeginEditEnded(swigCPtr, OdDbObjectId.getCPtr(entityId), OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onBeginSaveStarted(OdDbObjectId entityId, OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_onBeginSaveStarted(swigCPtr, OdDbObjectId.getCPtr(entityId), OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void onBeginSaveEnded(OdDbObjectId entityId, OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_onBeginSaveEnded(swigCPtr, OdDbObjectId.getCPtr(entityId), OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool onEndEdit(OdDbBlockTableRecord arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_onEndEdit(swigCPtr, OdDbBlockTableRecord.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void onEndEditStarted(OdDbObjectId entityId, OdDbObjectId blockId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_onEndEditStarted(swigCPtr, OdDbObjectId.getCPtr(entityId), OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockElement_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
