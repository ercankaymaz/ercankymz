using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAbstractViewportDataForDbViewTabRec : OdDbAbstractViewportDataForAbstractViewTabRec
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAbstractViewportDataForDbViewTabRec(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAbstractViewportDataForDbViewTabRec obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAbstractViewportDataForDbViewTabRec(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbAbstractViewportDataForDbViewTabRec cast(OdRxObject pObj)
	{
		OdDbAbstractViewportDataForDbViewTabRec rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAbstractViewportDataForDbViewTabRec>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbAbstractViewportDataForDbViewTabRec createObject()
	{
		OdDbAbstractViewportDataForDbViewTabRec rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAbstractViewportDataForDbViewTabRec>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool hasUcs(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_hasUcs(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool viewExtents(OdRxObject pViewport, OdGeBoundBlock3d extents)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_viewExtents(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isUcsSavedWithViewport(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isUcsSavedWithViewport(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsPerViewport(OdRxObject pViewport, bool ucsPerViewport)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setUcsPerViewport(swigCPtr, OdRxObject.getCPtr(pViewport), ucsPerViewport);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isUcsFollowModeOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isUcsFollowModeOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsFollowModeOn(OdRxObject pViewport, bool ucsFollowMode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setUcsFollowModeOn(swigCPtr, OdRxObject.getCPtr(pViewport), ucsFollowMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ushort circleSides(OdRxObject pViewport)
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_circleSides(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setCircleSides(OdRxObject pViewport, ushort circleSides)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setCircleSides(swigCPtr, OdRxObject.getCPtr(pViewport), circleSides);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isGridOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridOn(OdRxObject pViewport, bool gridOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setGridOn(swigCPtr, OdRxObject.getCPtr(pViewport), gridOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGeVector2d gridIncrement(OdRxObject pViewport)
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_gridIncrement(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridIncrement(OdRxObject pViewport, OdGeVector2d gridIncrement)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setGridIncrement(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeVector2d.getCPtr(gridIncrement).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridBoundToLimits(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isGridBoundToLimits(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridBoundToLimits(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setGridBoundToLimits(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridAdaptive(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isGridAdaptive(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridAdaptive(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setGridAdaptive(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridSubdivisionRestricted(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isGridSubdivisionRestricted(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridSubdivisionRestricted(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setGridSubdivisionRestricted(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridFollow(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isGridFollow(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridFollow(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setGridFollow(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override short gridMajor(OdRxObject pViewport)
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_gridMajor(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridMajor(OdRxObject pViewport, short nMajor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setGridMajor(swigCPtr, OdRxObject.getCPtr(pViewport), nMajor);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isUcsIconVisible(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isUcsIconVisible(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsIconVisible(OdRxObject pViewport, bool iconVisible)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setUcsIconVisible(swigCPtr, OdRxObject.getCPtr(pViewport), iconVisible);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isUcsIconAtOrigin(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isUcsIconAtOrigin(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsIconAtOrigin(OdRxObject pViewport, bool atOrigin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setUcsIconAtOrigin(swigCPtr, OdRxObject.getCPtr(pViewport), atOrigin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isSnapOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isSnapOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapOn(OdRxObject pViewport, bool atOrigin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setSnapOn(swigCPtr, OdRxObject.getCPtr(pViewport), atOrigin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isSnapIsometric(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_isSnapIsometric(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapIsometric(OdRxObject pViewport, bool snapIsometric)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setSnapIsometric(swigCPtr, OdRxObject.getCPtr(pViewport), snapIsometric);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double snapAngle(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_snapAngle(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapAngle(OdRxObject pViewport, double snapAngle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setSnapAngle(swigCPtr, OdRxObject.getCPtr(pViewport), snapAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGePoint2d snapBase(OdRxObject pViewport)
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_snapBase(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapBase(OdRxObject pViewport, OdGePoint2d snapBase)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setSnapBase(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint2d.getCPtr(snapBase));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGeVector2d snapIncrement(OdRxObject pViewport)
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_snapIncrement(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapIncrement(OdRxObject pViewport, OdGeVector2d snapIncrement)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setSnapIncrement(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeVector2d.getCPtr(snapIncrement).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ushort snapIsoPair(OdRxObject pViewport)
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_snapIsoPair(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapIsoPair(OdRxObject pViewport, ushort snapIncrement)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setSnapIsoPair(swigCPtr, OdRxObject.getCPtr(pViewport), snapIncrement);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsView gsView(OdRxObject pViewport)
	{
		OdGsView rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_gsView(swigCPtr, OdRxObject.getCPtr(pViewport)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setGsView(OdRxObject pViewport, OdGsView pGsView)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_setGsView(swigCPtr, OdRxObject.getCPtr(pViewport), OdGsView.getCPtr(pGsView));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewTabRec_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
