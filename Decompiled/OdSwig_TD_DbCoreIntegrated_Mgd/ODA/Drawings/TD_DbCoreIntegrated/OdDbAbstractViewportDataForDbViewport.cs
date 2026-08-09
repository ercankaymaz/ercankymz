using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAbstractViewportDataForDbViewport : OdDbAbstractViewportData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAbstractViewportDataForDbViewport(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAbstractViewportDataForDbViewport obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAbstractViewportDataForDbViewport(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setView(OdRxObject pViewport, OdGePoint3d target, OdGeVector3d direction, OdGeVector3d upVector, double fieldWidth, double fieldHeight, bool perspective, OdGeVector2d viewOffset)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setView__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(target).Handle, OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fieldWidth, fieldHeight, perspective, OdGeVector2d.getCPtr(viewOffset).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setView(OdRxObject pViewport, OdGePoint3d target, OdGeVector3d direction, OdGeVector3d upVector, double fieldWidth, double fieldHeight, bool perspective)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setView__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(target).Handle, OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fieldWidth, fieldHeight, perspective);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGePoint3d target(OdRxObject pViewport)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_target(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGeVector3d direction(OdRxObject pViewport)
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_direction(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGeVector3d upVector(OdRxObject pViewport)
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_upVector(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double fieldWidth(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_fieldWidth(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double fieldHeight(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_fieldHeight(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGeVector2d viewOffset(OdRxObject pViewport)
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_viewOffset(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double viewTwist(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_viewTwist(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isPerspective(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isPerspective(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setLensLength(OdRxObject pViewport, double lensLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setLensLength(swigCPtr, OdRxObject.getCPtr(pViewport), lensLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double lensLength(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_lensLength(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isFrontClipOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isFrontClipOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setFrontClipOn(OdRxObject pViewport, bool frontClip)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setFrontClipOn(swigCPtr, OdRxObject.getCPtr(pViewport), frontClip);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isBackClipOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isBackClipOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setBackClipOn(OdRxObject pViewport, bool backClip)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setBackClipOn(swigCPtr, OdRxObject.getCPtr(pViewport), backClip);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isFrontClipAtEyeOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isFrontClipAtEyeOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setFrontClipAtEyeOn(OdRxObject pViewport, bool frontClipAtEye)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setFrontClipAtEyeOn(swigCPtr, OdRxObject.getCPtr(pViewport), frontClipAtEye);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double frontClipDistance(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_frontClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setFrontClipDistance(OdRxObject pViewport, double frontClipDistance)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setFrontClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport), frontClipDistance);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double backClipDistance(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_backClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setBackClipDistance(OdRxObject pViewport, double backClipDistance)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setBackClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport), backClipDistance);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setRenderMode(OdRxObject pViewport, OdDb_RenderMode mode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setRenderMode(swigCPtr, OdRxObject.getCPtr(pViewport), (int)mode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDb_RenderMode renderMode(OdRxObject pViewport)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_renderMode(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_RenderMode)result;
	}

	public override void setVisualStyle(OdRxObject pViewport, OdDbStub visualStyleId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setVisualStyle(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(visualStyleId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub visualStyle(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_visualStyle(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setBackground(OdRxObject pViewport, OdDbStub backgroundId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setBackground(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(backgroundId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub background(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_background(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void FrozenLayers(OdRxObject pViewport, OdDbStubPtrArray frozenLayers)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_FrozenLayers(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStubPtrArray.getCPtr(frozenLayers).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setFrozenLayers(OdRxObject pViewport, OdDbStubPtrArray frozenLayers)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setFrozenLayers(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStubPtrArray.getCPtr(frozenLayers).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool hasUcs(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_hasUcs(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void getUcs(OdRxObject pViewport, OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_getUcs(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDb_OrthographicView orthoUcs(OdRxObject pViewport, OdRxObject pDb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_orthoUcs__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdRxObject.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_OrthographicView)result;
	}

	public override OdDb_OrthographicView orthoUcs(OdRxObject pViewport)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_orthoUcs__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_OrthographicView)result;
	}

	public override OdDbStub ucsName(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_ucsName(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double elevation(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_elevation(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcs(OdRxObject pViewport, OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setUcs__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool setUcs(OdRxObject pViewport, OdDb_OrthographicView orthoUcs, OdRxObject pDb)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setUcs__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), (int)orthoUcs, OdRxObject.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool setUcs(OdRxObject pViewport, OdDb_OrthographicView orthoUcs)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setUcs__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewport), (int)orthoUcs);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool setUcs(OdRxObject pViewport, OdDbStub ucsId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setUcs__SWIG_3(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(ucsId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setElevation(OdRxObject pViewport, double elevation)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setElevation(swigCPtr, OdRxObject.getCPtr(pViewport), elevation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool viewExtents(OdRxObject pViewport, OdGeBoundBlock3d extents)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_viewExtents(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool plotExtents(OdRxObject pViewport, OdGeBoundBlock3d extents, bool bExtendOnly, bool bExtentsValid, OdGeMatrix3d pWorldToEye)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_plotExtents__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents), bExtendOnly, bExtentsValid, OdGeMatrix3d.getCPtr(pWorldToEye));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool plotExtents(OdRxObject pViewport, OdGeBoundBlock3d extents, bool bExtendOnly, bool bExtentsValid)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_plotExtents__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents), bExtendOnly, bExtentsValid);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool plotExtents(OdRxObject pViewport, OdGeBoundBlock3d extents, bool bExtendOnly)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_plotExtents__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents), bExtendOnly);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool plotExtents(OdRxObject pViewport, OdGeBoundBlock3d extents)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_plotExtents__SWIG_3(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeBoundBlock3d.getCPtr(extents));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdRxObject plotDataObject(OdRxObject pViewport, bool bOpenForWrite)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_plotDataObject__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), bOpenForWrite), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject plotDataObject(OdRxObject pViewport)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_plotDataObject__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdDbStub annotationScale(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_annotationScale(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isUcsSavedWithViewport(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isUcsSavedWithViewport(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsPerViewport(OdRxObject pViewport, bool ucsPerViewport)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setUcsPerViewport(swigCPtr, OdRxObject.getCPtr(pViewport), ucsPerViewport);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isUcsFollowModeOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isUcsFollowModeOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsFollowModeOn(OdRxObject pViewport, bool ucsFollowMode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setUcsFollowModeOn(swigCPtr, OdRxObject.getCPtr(pViewport), ucsFollowMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ushort circleSides(OdRxObject pViewport)
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_circleSides(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setCircleSides(OdRxObject pViewport, ushort circleSides)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setCircleSides(swigCPtr, OdRxObject.getCPtr(pViewport), circleSides);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isGridOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridOn(OdRxObject pViewport, bool gridOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setGridOn(swigCPtr, OdRxObject.getCPtr(pViewport), gridOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGeVector2d gridIncrement(OdRxObject pViewport)
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_gridIncrement(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridIncrement(OdRxObject pViewport, OdGeVector2d gridIncrement)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setGridIncrement(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeVector2d.getCPtr(gridIncrement).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridBoundToLimits(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isGridBoundToLimits(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridBoundToLimits(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setGridBoundToLimits(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridAdaptive(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isGridAdaptive(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridAdaptive(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setGridAdaptive(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridSubdivisionRestricted(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isGridSubdivisionRestricted(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridSubdivisionRestricted(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setGridSubdivisionRestricted(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isGridFollow(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isGridFollow(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridFollow(OdRxObject pViewport, bool gridDispFlag)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setGridFollow(swigCPtr, OdRxObject.getCPtr(pViewport), gridDispFlag);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override short gridMajor(OdRxObject pViewport)
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_gridMajor(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGridMajor(OdRxObject pViewport, short nMajor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setGridMajor(swigCPtr, OdRxObject.getCPtr(pViewport), nMajor);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isUcsIconVisible(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isUcsIconVisible(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsIconVisible(OdRxObject pViewport, bool bVisible)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setUcsIconVisible(swigCPtr, OdRxObject.getCPtr(pViewport), bVisible);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isUcsIconAtOrigin(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isUcsIconAtOrigin(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcsIconAtOrigin(OdRxObject pViewport, bool bAtOrigin)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setUcsIconAtOrigin(swigCPtr, OdRxObject.getCPtr(pViewport), bAtOrigin);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isSnapOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isSnapOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapOn(OdRxObject pViewport, bool iconVisible)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setSnapOn(swigCPtr, OdRxObject.getCPtr(pViewport), iconVisible);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isSnapIsometric(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isSnapIsometric(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapIsometric(OdRxObject pViewport, bool snapIsometric)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setSnapIsometric(swigCPtr, OdRxObject.getCPtr(pViewport), snapIsometric);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double snapAngle(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_snapAngle(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapAngle(OdRxObject pViewport, double snapAngle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setSnapAngle(swigCPtr, OdRxObject.getCPtr(pViewport), snapAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGePoint2d snapBase(OdRxObject pViewport)
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_snapBase(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapBase(OdRxObject pViewport, OdGePoint2d snapBase)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setSnapBase(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint2d.getCPtr(snapBase));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGeVector2d snapIncrement(OdRxObject pViewport)
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_snapIncrement(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapIncrement(OdRxObject pViewport, OdGeVector2d arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setSnapIncrement(swigCPtr, OdRxObject.getCPtr(pViewport), OdGeVector2d.getCPtr(arg1).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ushort snapIsoPair(OdRxObject pViewport)
	{
		ushort result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_snapIsoPair(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSnapIsoPair(OdRxObject pViewport, ushort snapIsoPair)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setSnapIsoPair(swigCPtr, OdRxObject.getCPtr(pViewport), snapIsoPair);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isDefaultLightingOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_isDefaultLightingOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setDefaultLightingOn(OdRxObject pViewport, bool isOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setDefaultLightingOn(swigCPtr, OdRxObject.getCPtr(pViewport), isOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiViewportTraits_DefaultLightingType defaultLightingType(OdRxObject pViewport)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_defaultLightingType(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiViewportTraits_DefaultLightingType)result;
	}

	public override void setDefaultLightingType(OdRxObject pViewport, OdGiViewportTraits_DefaultLightingType lightingType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setDefaultLightingType(swigCPtr, OdRxObject.getCPtr(pViewport), (int)lightingType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double brightness(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_brightness(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setBrightness(OdRxObject pViewport, double brightness)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setBrightness(swigCPtr, OdRxObject.getCPtr(pViewport), brightness);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double contrast(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_contrast(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setContrast(OdRxObject pViewport, double contrast)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setContrast(swigCPtr, OdRxObject.getCPtr(pViewport), contrast);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdCmColor ambientLightColor(OdRxObject pViewport)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_ambientLightColor(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setAmbientLightColor(OdRxObject pViewport, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setAmbientLightColor(swigCPtr, OdRxObject.getCPtr(pViewport), OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub sunId(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_sunId(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub setSun(OdRxObject pViewport, OdRxObject pSun)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setSun(swigCPtr, OdRxObject.getCPtr(pViewport), OdRxObject.getCPtr(pSun));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void toneOperatorParameters(OdRxObject pViewport, ref OdGiToneOperatorParameters params_)
	{
		IntPtr jarg = ((params_ == null) ? IntPtr.Zero : OdGiToneOperatorParameters.getCPtr(params_).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_toneOperatorParameters(swigCPtr, OdRxObject.getCPtr(pViewport), ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				params_ = null;
			}
			if (jarg != intPtr)
			{
				params_ = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGiToneOperatorParameters>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public override void setToneOperatorParameters(OdRxObject pViewport, OdGiToneOperatorParameters params_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setToneOperatorParameters(swigCPtr, OdRxObject.getCPtr(pViewport), OdGiToneOperatorParameters.getCPtr(params_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsView gsView(OdRxObject pViewport)
	{
		OdGsView rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdGsView>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_gsView(swigCPtr, OdRxObject.getCPtr(pViewport)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setGsView(OdRxObject pViewport, OdGsView pGsView)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_setGsView(swigCPtr, OdRxObject.getCPtr(pViewport), OdGsView.getCPtr(pGsView));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForDbViewport_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
