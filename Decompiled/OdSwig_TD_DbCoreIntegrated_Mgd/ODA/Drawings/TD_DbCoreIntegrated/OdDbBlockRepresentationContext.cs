using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbBlockRepresentationContext : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbBlockRepresentationContext_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdDbBlockRepresentationContext_1();

	public delegate void SwigDelegateOdDbBlockRepresentationContext_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBlockRepresentationContext_0 swigDelegate0;

	private SwigDelegateOdDbBlockRepresentationContext_1 swigDelegate1;

	private SwigDelegateOdDbBlockRepresentationContext_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBlockRepresentationContext(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBlockRepresentationContext obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbBlockRepresentationContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public void init(OdDbDynBlockReference ref_, OdDbBlockReference dbref, OdDbEvalGraph gr)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_init(swigCPtr, OdDbDynBlockReference.getCPtr(ref_), OdDbBlockReference.getCPtr(dbref), OdDbEvalGraph.getCPtr(gr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void loadInstanceData(bool bRequireEvaluate)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_loadInstanceData__SWIG_0(swigCPtr, bRequireEvaluate);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void loadInstanceData()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_loadInstanceData__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void compactRepresentation()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_compactRepresentation(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool originalToRepresentationEntities(OdDbObjectId id, OdDbEntityPtrArray res)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_originalToRepresentationEntities(swigCPtr, OdDbObjectId.getCPtr(id), OdDbEntityPtrArray.getCPtr(res));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool originalToRepresentationObjects(OdDbObjectId id, OdDbObjPtrArray res)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_originalToRepresentationObjects(swigCPtr, OdDbObjectId.getCPtr(id), OdDbObjPtrArray.getCPtr(res));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool representationPathToOriginalPath(OdDbObjectIdArray arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_representationPathToOriginalPath(swigCPtr, OdDbObjectIdArray.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getAllEntities(OdDbEntityPtrArray arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getAllEntities(swigCPtr, OdDbEntityPtrArray.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void tagBlockRecord(OdDbBlockTableRecord repBTR, OdDbHandle originalBlockHandle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_tagBlockRecord(OdDbBlockTableRecord.getCPtr(repBTR), OdDbHandle.getCPtr(originalBlockHandle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void clearRepBlock(OdDbBlockTableRecord repRTR)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_clearRepBlock(OdDbBlockTableRecord.getCPtr(repRTR));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createRepresentation(bool copied, bool force)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_createRepresentation__SWIG_0(swigCPtr, copied, force);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createRepresentation(bool copied)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_createRepresentation__SWIG_1(swigCPtr, copied);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void createRepresentation()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_createRepresentation__SWIG_2(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void emptyEntityCache()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_emptyEntityCache(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addHistoryRecord(string name, OdDbEvalVariant value, uint node)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_addHistoryRecord(swigCPtr, name, OdDbEvalVariant.getCPtr(value), node);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbXrecord getHistoryRecord()
	{
		OdDbXrecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbXrecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getHistoryRecord(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool applyHistory(OdResBuf pRb)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_applyHistory(swigCPtr, OdResBuf.getCPtr(pRb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void updateRepresentation()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_updateRepresentation(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId getRepresentation()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getRepresentation(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getOriginal()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getOriginal(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbEvalExpr getRepresentationNode(uint id)
	{
		OdDbEvalExpr rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalExpr>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getRepresentationNode(swigCPtr, id), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbBlockReference getReference()
	{
		OdDbBlockReference rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockReference>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getReference(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbEvalGraph getGraph()
	{
		OdDbEvalGraph rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalGraph>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getGraph(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbBlockTableRecord getBlock()
	{
		OdDbBlockTableRecord rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockTableRecord>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getBlock(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void updateCachedData(OdDbBlockReference ref_, bool createMissingDictionaries)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_updateCachedData(swigCPtr, OdDbBlockReference.getCPtr(ref_), createMissingDictionaries);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void writeUndo(OdDbEvalGraph gr)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_writeUndo(swigCPtr, OdDbEvalGraph.getCPtr(gr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readUndo(OdDbObjectId refId, OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_readUndo(swigCPtr, OdDbObjectId.getCPtr(refId), OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbBlockRepresentationContext getRepresentationContext(OdDbBlockReference br, bool validate)
	{
		OdDbBlockRepresentationContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockRepresentationContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getRepresentationContext__SWIG_0(OdDbBlockReference.getCPtr(br), validate), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBlockRepresentationContext getRepresentationContext(OdDbBlockReference br)
	{
		OdDbBlockRepresentationContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockRepresentationContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getRepresentationContext__SWIG_1(OdDbBlockReference.getCPtr(br)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbAttribute getAttribute(OdDbAttributeDefinition arg0)
	{
		OdDbAttribute rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAttribute>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getAttribute(swigCPtr, OdDbAttributeDefinition.getCPtr(arg0)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGeMatrix3d getRelativeMatrix(OdGeMatrix3d m)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getRelativeMatrix(swigCPtr, OdGeMatrix3d.getCPtr(m)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeVector3d getRelativeOffset(OdGeVector3d v)
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getRelativeOffset(swigCPtr, OdGeVector3d.getCPtr(v)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getBlockData()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getBlockData(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId getBlockHData()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getBlockHData(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdResult tagEntitiesInBlock(OdDbObjectId blockId)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_tagEntitiesInBlock(OdDbObjectId.getCPtr(blockId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult makeNodeActive(uint id)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_makeNodeActive(swigCPtr, id);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setPropertyValue(string name, OdDbEvalVariant value, bool useBlockTransform)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_setPropertyValue__SWIG_0(swigCPtr, name, OdDbEvalVariant.getCPtr(value), useBlockTransform);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setPropertyValue(string name, OdDbEvalVariant value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_setPropertyValue__SWIG_1(swigCPtr, name, OdDbEvalVariant.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult evaluateActiveNode()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_evaluateActiveNode(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void removeRepresentationEntityFromCache(OdDbObjectId arg0, OdDbEntity arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_removeRepresentationEntityFromCache(swigCPtr, OdDbObjectId.getCPtr(arg0), OdDbEntity.getCPtr(arg1));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addRepresentationEntityToCache(OdDbObjectId arg0, OdDbEntity arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_addRepresentationEntityToCache(swigCPtr, OdDbObjectId.getCPtr(arg0), OdDbEntity.getCPtr(arg1));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void markContext(OdDbEvalContext ctx, OdDbBlockRepresentationContext_EvaluationMode arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_markContext(swigCPtr, OdDbEvalContext.getCPtr(ctx), (int)arg1);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void initializeNodes()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_initializeNodes(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isCreatingRepresentation()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_isCreatingRepresentation();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void setIsCreatingRepresentation(bool bIsCreatingRep)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_setIsCreatingRepresentation(bIsCreatingRep);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbBlockRepresentationContext createObject()
	{
		OdDbBlockRepresentationContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbBlockRepresentationContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_createObject(), bOwn: true, bTryAddToTransaction: true);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbBlockRepresentationContext_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBlockRepresentationContext));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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
