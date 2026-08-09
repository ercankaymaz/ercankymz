using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAbstractViewportDataForAbstractViewTabRec : OdDbAbstractViewportData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAbstractViewportDataForAbstractViewTabRec(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAbstractViewportDataForAbstractViewTabRec obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAbstractViewportDataForAbstractViewTabRec(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbAbstractViewportDataForAbstractViewTabRec cast(OdRxObject pObj)
	{
		OdDbAbstractViewportDataForAbstractViewTabRec rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAbstractViewportDataForAbstractViewTabRec>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbAbstractViewportDataForAbstractViewTabRec createObject()
	{
		OdDbAbstractViewportDataForAbstractViewTabRec rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbAbstractViewportDataForAbstractViewTabRec>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void setView(OdRxObject pViewport, OdGePoint3d target, OdGeVector3d direction, OdGeVector3d upVector, double fieldWidth, double fieldHeight, bool isPerspective, OdGeVector2d viewOffset)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setView__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(target).Handle, OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fieldWidth, fieldHeight, isPerspective, OdGeVector2d.getCPtr(viewOffset).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setView(OdRxObject pViewport, OdGePoint3d target, OdGeVector3d direction, OdGeVector3d upVector, double fieldWidth, double fieldHeight, bool isPerspective)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setView__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(target).Handle, OdGeVector3d.getCPtr(direction), OdGeVector3d.getCPtr(upVector), fieldWidth, fieldHeight, isPerspective);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGePoint3d target(OdRxObject pViewport)
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_target(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGeVector3d direction(OdRxObject pViewport)
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_direction(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGeVector3d upVector(OdRxObject pViewport)
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_upVector(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double fieldWidth(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_fieldWidth(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double fieldHeight(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_fieldHeight(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdGeVector2d viewOffset(OdRxObject pViewport)
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_viewOffset(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override double viewTwist(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_viewTwist(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isPerspective(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_isPerspective(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setLensLength(OdRxObject pViewport, double lensLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setLensLength(swigCPtr, OdRxObject.getCPtr(pViewport), lensLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double lensLength(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_lensLength(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isFrontClipOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_isFrontClipOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setFrontClipOn(OdRxObject pViewport, bool frontClip)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setFrontClipOn(swigCPtr, OdRxObject.getCPtr(pViewport), frontClip);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isBackClipOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_isBackClipOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setBackClipOn(OdRxObject pViewport, bool backClip)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setBackClipOn(swigCPtr, OdRxObject.getCPtr(pViewport), backClip);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isFrontClipAtEyeOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_isFrontClipAtEyeOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setFrontClipAtEyeOn(OdRxObject pViewport, bool frontClipAtEye)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setFrontClipAtEyeOn(swigCPtr, OdRxObject.getCPtr(pViewport), frontClipAtEye);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double frontClipDistance(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_frontClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setFrontClipDistance(OdRxObject pViewport, double frontClipDistance)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setFrontClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport), frontClipDistance);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double backClipDistance(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_backClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setBackClipDistance(OdRxObject pViewport, double backClipDistance)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setBackClipDistance(swigCPtr, OdRxObject.getCPtr(pViewport), backClipDistance);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void setRenderMode(OdRxObject pViewport, OdDb_RenderMode renderMode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setRenderMode(swigCPtr, OdRxObject.getCPtr(pViewport), (int)renderMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDb_RenderMode renderMode(OdRxObject pViewport)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_renderMode(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_RenderMode)result;
	}

	public override void setVisualStyle(OdRxObject pViewport, OdDbStub visualStyleId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setVisualStyle(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(visualStyleId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub visualStyle(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_visualStyle(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setBackground(OdRxObject pViewport, OdDbStub backgroundId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setBackground(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(backgroundId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub background(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_background(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool hasUcs(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_hasUcs(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void getUcs(OdRxObject pViewport, OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_getUcs(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDb_OrthographicView orthoUcs(OdRxObject pViewport, OdRxObject pDb)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_orthoUcs__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdRxObject.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_OrthographicView)result;
	}

	public override OdDb_OrthographicView orthoUcs(OdRxObject pViewport)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_orthoUcs__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_OrthographicView)result;
	}

	public override double elevation(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_elevation(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setUcs(OdRxObject pViewport, OdGePoint3d origin, OdGeVector3d xAxis, OdGeVector3d yAxis)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setUcs__SWIG_0(swigCPtr, OdRxObject.getCPtr(pViewport), OdGePoint3d.getCPtr(origin), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool setUcs(OdRxObject pViewport, OdDb_OrthographicView orthoUcs, OdRxObject pDb)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setUcs__SWIG_1(swigCPtr, OdRxObject.getCPtr(pViewport), (int)orthoUcs, OdRxObject.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool setUcs(OdRxObject pViewport, OdDb_OrthographicView orthoUcs)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setUcs__SWIG_2(swigCPtr, OdRxObject.getCPtr(pViewport), (int)orthoUcs);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub ucsName(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_ucsName(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool setUcs(OdRxObject pViewport, OdDbStub ucsId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setUcs__SWIG_3(swigCPtr, OdRxObject.getCPtr(pViewport), OdDbStub.getCPtr(ucsId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setElevation(OdRxObject pViewport, double elevation)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setElevation(swigCPtr, OdRxObject.getCPtr(pViewport), elevation);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isDefaultLightingOn(OdRxObject pViewport)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_isDefaultLightingOn(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setDefaultLightingOn(OdRxObject pViewport, bool isOn)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setDefaultLightingOn(swigCPtr, OdRxObject.getCPtr(pViewport), isOn);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGiViewportTraits_DefaultLightingType defaultLightingType(OdRxObject pViewport)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_defaultLightingType(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiViewportTraits_DefaultLightingType)result;
	}

	public override void setDefaultLightingType(OdRxObject pViewport, OdGiViewportTraits_DefaultLightingType lightingType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setDefaultLightingType(swigCPtr, OdRxObject.getCPtr(pViewport), (int)lightingType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double brightness(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_brightness(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setBrightness(OdRxObject pViewport, double brightness)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setBrightness(swigCPtr, OdRxObject.getCPtr(pViewport), brightness);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override double contrast(OdRxObject pViewport)
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_contrast(swigCPtr, OdRxObject.getCPtr(pViewport));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setContrast(OdRxObject pViewport, double contrast)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setContrast(swigCPtr, OdRxObject.getCPtr(pViewport), contrast);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdCmColor ambientLightColor(OdRxObject pViewport)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_ambientLightColor(swigCPtr, OdRxObject.getCPtr(pViewport)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setAmbientLightColor(OdRxObject pViewport, OdCmColor color)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setAmbientLightColor(swigCPtr, OdRxObject.getCPtr(pViewport), OdCmColor.getCPtr(color));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdDbStub sunId(OdRxObject pViewport)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_sunId(swigCPtr, OdRxObject.getCPtr(pViewport));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub setSun(OdRxObject pViewport, OdRxObject pSun)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setSun(swigCPtr, OdRxObject.getCPtr(pViewport), OdRxObject.getCPtr(pSun));
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
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_toneOperatorParameters(swigCPtr, OdRxObject.getCPtr(pViewport), ref jarg);
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_setToneOperatorParameters(swigCPtr, OdRxObject.getCPtr(pViewport), OdGiToneOperatorParameters.getCPtr(params_));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAbstractViewportDataForAbstractViewTabRec_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
