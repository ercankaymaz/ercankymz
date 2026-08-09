using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAbstractViewportDataForDbVpTabRec : OdDbAbstractViewportDataForAbstractViewTabRec
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAbstractViewportDataForDbVpTabRec(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAbstractViewportDataForDbVpTabRec obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAbstractViewportDataForDbVpTabRec(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbAbstractViewportDataForDbVpTabRec cast(OdRxObject pObj)
	{
		OdDbAbstractViewportDataForDbVpTabRec rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAbstractViewportDataForDbVpTabRec>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbAbstractViewportDataForDbVpTabRec createObject()
	{
		OdDbAbstractViewportDataForDbVpTabRec rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAbstractViewportDataForDbVpTabRec>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGePoint2d lowerLeftCorner(OdRxObject pVpFrom)
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_lowerLeftCorner(swigCPtr, OdRxObject.getCPtr(pVpFrom)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGePoint2d upperRightCorner(OdRxObject pVpFrom)
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_upperRightCorner(swigCPtr, OdRxObject.getCPtr(pVpFrom)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setViewport(OdRxObject pVpTo, OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setViewport(swigCPtr, OdRxObject.getCPtr(pVpTo), OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool hasViewport(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_hasViewport(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool viewExtents(OdRxObject pVp, OdGeBoundBlock3d extents)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_viewExtents(swigCPtr, OdRxObject.getCPtr(pVp), OdGeBoundBlock3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool hasUcs(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_hasUcs(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void getUcs(OdRxObject pVpFrom, OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_getUcs(swigCPtr, OdRxObject.getCPtr(pVpFrom), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDb_OrthographicView orthoUcs(OdRxObject pVpFrom)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_orthoUcs(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_OrthographicView)result;
	}

	public override OdDbStub ucsName(OdRxObject pVpFrom)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_ucsName(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double elevation(OdRxObject pVpFrom)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_elevation(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isUcsSavedWithViewport(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isUcsSavedWithViewport(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsPerViewport(OdRxObject pVpTo, bool ucsvp)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setUcsPerViewport(swigCPtr, OdRxObject.getCPtr(pVpTo), ucsvp);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isUcsFollowModeOn(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isUcsFollowModeOn(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsFollowModeOn(OdRxObject pVpTo, bool bOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setUcsFollowModeOn(swigCPtr, OdRxObject.getCPtr(pVpTo), bOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ushort circleSides(OdRxObject pVpFrom)
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_circleSides(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setCircleSides(OdRxObject pVpTo, ushort arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setCircleSides(swigCPtr, OdRxObject.getCPtr(pVpTo), arg1);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridOn(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isGridOn(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridOn(OdRxObject pVpTo, bool bOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setGridOn(swigCPtr, OdRxObject.getCPtr(pVpTo), bOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGeVector2d gridIncrement(OdRxObject pVpFrom)
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_gridIncrement(swigCPtr, OdRxObject.getCPtr(pVpFrom)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridIncrement(OdRxObject pVpTo, OdGeVector2d arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setGridIncrement(swigCPtr, OdRxObject.getCPtr(pVpTo), OdGeVector2d.getCPtr(arg1).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridBoundToLimits(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isGridBoundToLimits(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridBoundToLimits(OdRxObject pVpTo, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setGridBoundToLimits(swigCPtr, OdRxObject.getCPtr(pVpTo), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridAdaptive(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isGridAdaptive(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridAdaptive(OdRxObject pVpTo, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setGridAdaptive(swigCPtr, OdRxObject.getCPtr(pVpTo), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridSubdivisionRestricted(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isGridSubdivisionRestricted(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridSubdivisionRestricted(OdRxObject pVpTo, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setGridSubdivisionRestricted(swigCPtr, OdRxObject.getCPtr(pVpTo), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridFollow(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isGridFollow(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridFollow(OdRxObject pVpTo, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setGridFollow(swigCPtr, OdRxObject.getCPtr(pVpTo), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override short gridMajor(OdRxObject pVpFrom)
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_gridMajor(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridMajor(OdRxObject pVpTo, short nMajor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setGridMajor(swigCPtr, OdRxObject.getCPtr(pVpTo), nMajor);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isUcsIconVisible(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isUcsIconVisible(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsIconVisible(OdRxObject pVpTo, bool bVisible)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setUcsIconVisible(swigCPtr, OdRxObject.getCPtr(pVpTo), bVisible);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isUcsIconAtOrigin(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isUcsIconAtOrigin(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsIconAtOrigin(OdRxObject pVpTo, bool bAtOrigin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setUcsIconAtOrigin(swigCPtr, OdRxObject.getCPtr(pVpTo), bAtOrigin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isSnapOn(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isSnapOn(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapOn(OdRxObject pVpTo, bool bOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setSnapOn(swigCPtr, OdRxObject.getCPtr(pVpTo), bOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isSnapIsometric(OdRxObject pVpFrom)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_isSnapIsometric(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapIsometric(OdRxObject pVpTo, bool bIsometric)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setSnapIsometric(swigCPtr, OdRxObject.getCPtr(pVpTo), bIsometric);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double snapAngle(OdRxObject pVpFrom)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_snapAngle(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapAngle(OdRxObject pVpTo, double arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setSnapAngle(swigCPtr, OdRxObject.getCPtr(pVpTo), arg1);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGePoint2d snapBase(OdRxObject pVpFrom)
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_snapBase(swigCPtr, OdRxObject.getCPtr(pVpFrom)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapBase(OdRxObject pVpTo, OdGePoint2d arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setSnapBase(swigCPtr, OdRxObject.getCPtr(pVpTo), OdGePoint2d.getCPtr(arg1));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGeVector2d snapIncrement(OdRxObject pVpFrom)
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_snapIncrement(swigCPtr, OdRxObject.getCPtr(pVpFrom)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapIncrement(OdRxObject pVpTo, OdGeVector2d arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setSnapIncrement(swigCPtr, OdRxObject.getCPtr(pVpTo), OdGeVector2d.getCPtr(arg1).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ushort snapIsoPair(OdRxObject pVpFrom)
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_snapIsoPair(swigCPtr, OdRxObject.getCPtr(pVpFrom));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapIsoPair(OdRxObject pVpTo, ushort arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setSnapIsoPair(swigCPtr, OdRxObject.getCPtr(pVpTo), arg1);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsView gsView(OdRxObject pViewport)
	{
		OdGsView rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_gsView(swigCPtr, OdRxObject.getCPtr(pViewport)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setGsView(OdRxObject pViewport, OdGsView pGsView)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_setGsView(swigCPtr, OdRxObject.getCPtr(pViewport), OdGsView.getCPtr(pGsView));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdRxObject plotDataObject(OdRxObject pViewport, bool bOpenForWrite)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_plotDataObject__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), bOpenForWrite), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject plotDataObject(OdRxObject pViewport)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_plotDataObject__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbVpTabRec_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
