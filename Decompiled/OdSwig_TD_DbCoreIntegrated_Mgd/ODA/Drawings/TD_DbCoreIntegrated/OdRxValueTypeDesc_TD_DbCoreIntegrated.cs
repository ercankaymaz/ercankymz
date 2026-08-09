using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdRxValueTypeDesc_TD_DbCoreIntegrated : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxValueTypeDesc_TD_DbCoreIntegrated(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxValueTypeDesc_TD_DbCoreIntegrated obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRxValueTypeDesc_TD_DbCoreIntegrated()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdRxValueTypeDesc_TD_DbCoreIntegrated(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdRxValueType value_Desc_OdDbDate()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbDate(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdCmColor()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdCmColor(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMTextPtr()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMTextPtr(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbObjectId()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbObjectId(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__EndCaps()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__EndCaps(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdCellRange()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdCellRange(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdRectangle3d()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdRectangle3d(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__XrefStatus()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__XrefStatus(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbEvalVariant()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbEvalVariant(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__Visibility()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__Visibility(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__Poly3dType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__Poly3dType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__Poly2dType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__Poly2dType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbLoftOptions()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbLoftOptions(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__DwgVersion()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__DwgVersion(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__JoinStyle()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__JoinStyle(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbSweepOptions()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbSweepOptions(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__CollisionType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__CollisionType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__FlowDirection()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__FlowDirection(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbSection__State()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbSection__State(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__PolyMeshType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__PolyMeshType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__TextHorzMode()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__TextHorzMode(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__Vertex3dType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__Vertex3dType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__TextVertMode()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__TextVertMode(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__Vertex2dType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__Vertex2dType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__MaintReleaseVer()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__MaintReleaseVer(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbLeader__AnnoType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbLeader__AnnoType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbOle2Frame__Type()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbOle2Frame__Type(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__LoftNormalsType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__LoftNormalsType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbBlockTableRecordId()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbBlockTableRecordId(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__LineSpacingStyle()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__LineSpacingStyle(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMText__ColumnType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMText__ColumnType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb3dPolylineVertexPtr()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb3dPolylineVertexPtr(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__TableBreakOption()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__TableBreakOption(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__OrthographicView()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__OrthographicView(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbHatch__HatchStyle()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbHatch__HatchStyle(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbLight__LampColorType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbLight__LampColorType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbSpline__SplineType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbSpline__SplineType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__MeasurementValue()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__MeasurementValue(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbHelix__ConstrainType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbHelix__ConstrainType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbOle2Frame__PlotQuality()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbOle2Frame__PlotQuality(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMText__FlowDirection()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMText__FlowDirection(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbLight__LampColorPreset()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbLight__LampColorPreset(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMText__AttachmentPoint()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMText__AttachmentPoint(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbViewport__ShadePlotType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbViewport__ShadePlotType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbHatch__HatchObjectType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbHatch__HatchObjectType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbLight__GlyphDisplayType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbLight__GlyphDisplayType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbRenderGlobal__Procedure()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbRenderGlobal__Procedure(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbPlotSettings__PlotType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbPlotSettings__PlotType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__DuplicateRecordCloning()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__DuplicateRecordCloning(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbHatch__HatchPatternType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbHatch__HatchPatternType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMLeaderStyle__ContentType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMLeaderStyle__ContentType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbLoftOptions__NormalOption()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbLoftOptions__NormalOption(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMLeaderStyle__LeaderType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMLeaderStyle__LeaderType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbHatch__GradientPatternType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbHatch__GradientPatternType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbRenderGlobal__Destination()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbRenderGlobal__Destination(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMLeaderStyle__TextAngleType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMLeaderStyle__TextAngleType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDb__TableBreakFlowDirection()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDb__TableBreakFlowDirection(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbPlotSettings__PlotRotation()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbPlotSettings__PlotRotation(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbViewport__StandardScaleType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbViewport__StandardScaleType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbPlotSettings__StdScaleType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbPlotSettings__StdScaleType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbPlotSettings__ShadePlotType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbPlotSettings__ShadePlotType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbPlotSettings__PlotPaperUnits()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbPlotSettings__PlotPaperUnits(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMLeaderStyle__SegmentAngleType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMLeaderStyle__SegmentAngleType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbBlockTableRecord__BlockScaling()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbBlockTableRecord__BlockScaling(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbPlotSettings__ShadePlotResLevel()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbPlotSettings__ShadePlotResLevel(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbLight__PhysicalIntensityMethod()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbLight__PhysicalIntensityMethod(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMLeaderStyle__TextAttachmentType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMLeaderStyle__TextAttachmentType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMLeaderStyle__TextAlignmentType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMLeaderStyle__TextAlignmentType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMLeaderStyle__DrawLeaderOrderType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMLeaderStyle__DrawLeaderOrderType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMLeaderStyle__BlockConnectionType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMLeaderStyle__BlockConnectionType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMLeaderStyle__DrawMLeaderOrderType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMLeaderStyle__DrawMLeaderOrderType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbRapidRTRenderSettings__RenderTarget()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbRapidRTRenderSettings__RenderTarget(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbGeoPositionMarker__OdTextAlignmentType()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbGeoPositionMarker__OdTextAlignmentType(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMLeaderStyle__TextAttachmentDirection()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMLeaderStyle__TextAttachmentDirection(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbMentalRayRenderSettings__ShadowSamplingMultiplier()
	{
		OdRxValueType rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxValueType>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_DbCoreIntegrated_value_Desc_OdDbMentalRayRenderSettings__ShadowSamplingMultiplier(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxValueTypeDesc_TD_DbCoreIntegrated()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdRxValueTypeDesc_TD_DbCoreIntegrated(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
