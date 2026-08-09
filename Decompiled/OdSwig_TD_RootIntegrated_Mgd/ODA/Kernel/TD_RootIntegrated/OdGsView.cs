using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsView : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsView(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsView obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsView(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsView cast(OdRxObject pObj)
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsView createObject()
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsDevice device()
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_device(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiContext userGiContext()
	{
		OdGiContext rXObject = Helpers.GetRXObject<OdGiContext>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_userGiContext(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setUserGiContext(OdGiContext pUserGiContext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setUserGiContext(swigCPtr, OdGiContext.getCPtr(pUserGiContext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double lineweightToDcScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_lineweightToDcScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLineweightToDcScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setLineweightToDcScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineweightEnum(byte[] numLineweights, ushort altSourceLwds)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(numLineweights);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setLineweightEnum__SWIG_0(swigCPtr, intPtr, altSourceLwds);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void setLineweightEnum(byte[] numLineweights)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(numLineweights);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setLineweightEnum__SWIG_1(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void setViewport(OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setViewport__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setViewport(OdGsDCRect screenRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setViewport__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setViewport(OdGsDCRectDouble screenRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setViewport__SWIG_2(swigCPtr, OdGsDCRectDouble.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getViewport(OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getViewport__SWIG_0(swigCPtr, OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getViewport(OdGsDCRect screenRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getViewport__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getViewport(OdGsDCRectDouble screenRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getViewport__SWIG_2(swigCPtr, OdGsDCRectDouble.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setViewportClipRegion(OdGsDCPointArray[] numContours)
	{
		IntPtr intPtr = Helpers.MarshalDCClipRegion(numContours);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setViewportClipRegion__SWIG_0(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void viewportClipRegion(OdIntArray counts, OdGsDCPointArray vertices)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_viewportClipRegion__SWIG_0(swigCPtr, OdIntArray.getCPtr(counts).Handle, OdGsDCPointArray.getCPtr(vertices).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void viewportClipRegion(OdIntArray counts, OdGePoint2dArray vertices)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_viewportClipRegion__SWIG_1(swigCPtr, OdIntArray.getCPtr(counts).Handle, OdGePoint2dArray.getCPtr(vertices).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void removeViewportClipRegion()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_removeViewportClipRegion(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setViewport3dClipping(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setViewport3dClipping__SWIG_0(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setViewport3dClipping(OdGiClipBoundary pBoundary)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setViewport3dClipping__SWIG_1(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiClipBoundary viewport3dClipping(OdGiAbstractClipBoundary ppClipInfo)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_viewport3dClipping__SWIG_0(swigCPtr, OdGiAbstractClipBoundary.getCPtr(ppClipInfo).Handle);
		OdGiClipBoundary result = ((intPtr == IntPtr.Zero) ? null : new OdGiClipBoundary(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiClipBoundary viewport3dClipping()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_viewport3dClipping__SWIG_1(swigCPtr);
		OdGiClipBoundary result = ((intPtr == IntPtr.Zero) ? null : new OdGiClipBoundary(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void removeViewport3dClipping()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_removeViewport3dClipping(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setViewportBorderProperties(uint color, int width)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setViewportBorderProperties(swigCPtr, color, width);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getViewportBorderProperties(out uint color, out int width)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getViewportBorderProperties(swigCPtr, out color, out width);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setViewportBorderVisibility(bool visible)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setViewportBorderVisibility(swigCPtr, visible);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isViewportBorderVisible()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_isViewportBorderVisible(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setView(OdGePoint3d position, OdGePoint3d target, OdGeVector3d upVector, double fieldWidth, double fieldHeight, OdGsView_Projection projectionType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setView__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(position), OdGePoint3d.getCPtr(target), OdGeVector3d.getCPtr(upVector), fieldWidth, fieldHeight, (int)projectionType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setView(OdGePoint3d position, OdGePoint3d target, OdGeVector3d upVector, double fieldWidth, double fieldHeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setView__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(position), OdGePoint3d.getCPtr(target), OdGeVector3d.getCPtr(upVector), fieldWidth, fieldHeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d position()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_position(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d target()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_target(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d upVector()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_upVector(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double lensLength()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_lensLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setLensLength(double lensLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setLensLength(swigCPtr, lensLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isPerspective()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_isPerspective(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double fieldWidth()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_fieldWidth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double fieldHeight()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_fieldHeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEnableFrontClip(bool enable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setEnableFrontClip(swigCPtr, enable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isFrontClipped()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_isFrontClipped(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFrontClip(double frontClip)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setFrontClip(swigCPtr, frontClip);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double frontClip()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_frontClip(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEnableBackClip(bool enable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setEnableBackClip(swigCPtr, enable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isBackClipped()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_isBackClipped(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setBackClip(double backClip)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setBackClip(swigCPtr, backClip);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double backClip()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_backClip(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d viewingMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_viewingMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d projectionMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_projectionMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d screenMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_screenMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d worldToDeviceMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_worldToDeviceMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d objectToDeviceMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_objectToDeviceMatrix(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMode(OdGsView_RenderMode mode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setMode(swigCPtr, (int)mode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsView_RenderMode mode()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_mode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsView_RenderMode)result;
	}

	public virtual bool add(OdGiDrawable pSceneGraph, OdGsModel pModel)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_add(swigCPtr, OdGiDrawable.getCPtr(pSceneGraph), OdGsModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int numRootDrawables()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_numRootDrawables(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub rootDrawableIdAt(int i, ref OdGsModel pModelReturn)
	{
		IntPtr jarg = ((pModelReturn == null) ? IntPtr.Zero : OdGsModel.getCPtr(pModelReturn).Handle);
		IntPtr intPtr = jarg;
		try
		{
			IntPtr intPtr2 = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_rootDrawableIdAt__SWIG_0(swigCPtr, i, ref jarg);
			OdDbStub result = ((intPtr2 == IntPtr.Zero) ? null : new OdDbStub(intPtr2, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pModelReturn = null;
			}
			else if (jarg != intPtr)
			{
				pModelReturn = Helpers.GetRXObject<OdGsModel>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdDbStub rootDrawableIdAt(int i)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_rootDrawableIdAt__SWIG_1(swigCPtr, i);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDrawable rootDrawableAt(int i, ref OdGsModel pModelReturn)
	{
		IntPtr jarg = ((pModelReturn == null) ? IntPtr.Zero : OdGsModel.getCPtr(pModelReturn).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_rootDrawableAt__SWIG_0(swigCPtr, i, ref jarg), bOwn: true, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pModelReturn = null;
			}
			else if (jarg != intPtr)
			{
				pModelReturn = Helpers.GetRXObject<OdGsModel>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdGiDrawable rootDrawableAt(int i)
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_rootDrawableAt__SWIG_1(swigCPtr, i), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool erase(OdGiDrawable sceneGraph)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_erase(swigCPtr, OdGiDrawable.getCPtr(sceneGraph));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void eraseAll()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_eraseAll(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGsModel getModel(OdGiDrawable pDrawable)
	{
		OdGsModel rXObject = Helpers.GetRXObject<OdGsModel>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getModel(swigCPtr, OdGiDrawable.getCPtr(pDrawable)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsModelArray getModelList()
	{
		OdGsModelArray result = new OdGsModelArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getModelList(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void invalidate()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_invalidate__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidate(OdGsDCRect screenRect)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_invalidate__SWIG_1(swigCPtr, OdGsDCRect.getCPtr(screenRect));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isValid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_isValid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void update()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_update(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void beginInteractivity(double frameRateInHz)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_beginInteractivity(swigCPtr, frameRateInHz);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isInInteractivity()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_isInInteractivity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual double interactivityFrameRate()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_interactivityFrameRate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void endInteractivity()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_endInteractivity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void flush()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_flush(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void hide()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_hide(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void show()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_show(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isVisible()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_isVisible(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void freezeLayer(OdDbStub layerID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_freezeLayer(swigCPtr, OdDbStub.getCPtr(layerID));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void thawLayer(OdDbStub layerID)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_thawLayer(swigCPtr, OdDbStub.getCPtr(layerID));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void clearFrozenLayers()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_clearFrozenLayers(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void invalidateCachedViewportGeometry()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_invalidateCachedViewportGeometry(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void select(OdGsDCPoint[] pts, OdGsSelectionReactor pReactor, OdGsView_SelectionMode mode)
	{
		IntPtr intPtr = Helpers.MarshalOdGsDCPointArray(pts);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsView_select(swigCPtr, intPtr, OdGsSelectionReactor.getCPtr(pReactor), (int)mode);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public virtual void dolly(OdGeVector3d dollyVector)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_dolly__SWIG_0(swigCPtr, OdGeVector3d.getCPtr(dollyVector));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void dolly(double xDolly, double yDolly, double zDolly)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_dolly__SWIG_1(swigCPtr, xDolly, yDolly, zDolly);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void roll(double rollAngle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_roll(swigCPtr, rollAngle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void orbit(double xOrbit, double yOrbit)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_orbit(swigCPtr, xOrbit, yOrbit);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void zoom(double zoomFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_zoom(swigCPtr, zoomFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pan(double xPan, double yPan)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_pan(swigCPtr, xPan, yPan);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void zoomExtents(OdGePoint3d minPt, OdGePoint3d maxPt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_zoomExtents(swigCPtr, OdGePoint3d.getCPtr(minPt), OdGePoint3d.getCPtr(maxPt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void zoomWindow(OdGePoint2d lowerLeft, OdGePoint2d upperRight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_zoomWindow(swigCPtr, OdGePoint2d.getCPtr(lowerLeft), OdGePoint2d.getCPtr(upperRight));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool pointInView(OdGePoint3d pt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_pointInView(swigCPtr, OdGePoint3d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool extentsInView(OdGePoint3d minPt, OdGePoint3d maxPt)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_extentsInView(swigCPtr, OdGePoint3d.getCPtr(minPt), OdGePoint3d.getCPtr(maxPt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsView cloneView(bool cloneViewParameters, bool cloneGeometry)
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_cloneView__SWIG_0(swigCPtr, cloneViewParameters, cloneGeometry), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsView cloneView(bool cloneViewParameters)
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_cloneView__SWIG_1(swigCPtr, cloneViewParameters), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsView cloneView()
	{
		OdGsView rXObject = Helpers.GetRXObject<OdGsView>(TD_RootIntegrated_GlobalsPINVOKE.OdGsView_cloneView__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void viewParameters(OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_viewParameters(swigCPtr, getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool exceededBounds()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_exceededBounds(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableStereo(bool enabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_enableStereo(swigCPtr, enabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isStereoEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_isStereoEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setStereoParameters(double magnitude, double parallax)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setStereoParameters(swigCPtr, magnitude, parallax);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getStereoParameters(out double magnitude, out double parallax)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getStereoParameters(swigCPtr, out magnitude, out parallax);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void initLights(OdRxIterator pLightsIterator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_initLights(swigCPtr, OdRxIterator.getCPtr(pLightsIterator));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLinetypeScaleMultiplier(double linetypeScaleMultiplier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setLinetypeScaleMultiplier(swigCPtr, linetypeScaleMultiplier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double linetypeScaleMultiplier()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_linetypeScaleMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setAlternateLinetypeScaleMultiplier(double linetypeAlternateScaleMultiplier)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setAlternateLinetypeScaleMultiplier(swigCPtr, linetypeAlternateScaleMultiplier);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double linetypeAlternateScaleMultiplier()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_linetypeAlternateScaleMultiplier(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void clientViewInfo(OdGsClientViewInfo clientViewInfo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_clientViewInfo(swigCPtr, OdGsClientViewInfo.getCPtr(clientViewInfo));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setClearColor(OdGsView_ClearColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setClearColor(swigCPtr, (int)color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool pointInViewport(OdGePoint2d screenPoint)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_pointInViewport(swigCPtr, OdGePoint2d.getCPtr(screenPoint));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getNumPixelsInUnitSquare(OdGePoint3d point, OdGePoint2d pixelDensity, bool bUsePerspective)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getNumPixelsInUnitSquare__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(point), OdGePoint2d.getCPtr(pixelDensity), bUsePerspective);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getNumPixelsInUnitSquare(OdGePoint3d point, OdGePoint2d pixelDensity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getNumPixelsInUnitSquare__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(point), OdGePoint2d.getCPtr(pixelDensity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setBackground(OdDbStub backgroundId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setBackground(swigCPtr, OdDbStub.getCPtr(backgroundId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub background()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_background(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVisualStyle(OdDbStub visualStyleId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setVisualStyle__SWIG_0(swigCPtr, OdDbStub.getCPtr(visualStyleId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub visualStyle()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_visualStyle__SWIG_0(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVisualStyle(OdGiVisualStyle visualStyle)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_setVisualStyle__SWIG_1(swigCPtr, OdGiVisualStyle.getCPtr(visualStyle));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool visualStyle(ref OdGiVisualStyle visualStyle)
	{
		IntPtr jarg = ((visualStyle == null) ? IntPtr.Zero : OdGiVisualStyle.getCPtr(visualStyle).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_visualStyle__SWIG_1(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				visualStyle = null;
			}
			if (jarg != intPtr)
			{
				visualStyle = Helpers.GetRXObject<OdGiVisualStyle>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void enableDefaultLighting(bool bEnable, OdGsView_DefaultLightingType lightType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_enableDefaultLighting__SWIG_0(swigCPtr, bEnable, (int)lightType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void enableDefaultLighting(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_enableDefaultLighting__SWIG_1(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getSnapShot(ref OdGiRasterImage pImage, OdGsDCRect region)
	{
		IntPtr jarg = ((pImage == null) ? IntPtr.Zero : OdGiRasterImage.getCPtr(pImage).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getSnapShot(swigCPtr, ref jarg, OdGsDCRect.getCPtr(region));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pImage = null;
			}
			else if (jarg != intPtr)
			{
				pImage = Helpers.GetRXObject<OdGiRasterImage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void collide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize, OdGsCollisionDetectionContext pCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_collide__SWIG_0(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList, nCollisionWithListSize, OdGsCollisionDetectionContext.getCPtr(pCtx));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void collide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor, OdGiPathNode[] pCollisionWithList, uint nCollisionWithListSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_collide__SWIG_1(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList, nCollisionWithListSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void collide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor, OdGiPathNode[] pCollisionWithList)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_collide__SWIG_2(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor), pCollisionWithList);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void collide(OdGiPathNode[] pInputList, uint nInputListSize, OdGsCollisionDetectionReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_collide__SWIG_3(swigCPtr, pInputList, nInputListSize, OdGsCollisionDetectionReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rayTrace(OdGePoint3d rayOrigin, OdGeVector3d rayDirection, OdGsRayTraceReactor pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList, uint nObjectListSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_rayTrace__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection, pObjectList, nObjectListSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rayTrace(OdGePoint3d rayOrigin, OdGeVector3d rayDirection, OdGsRayTraceReactor pReactor, bool bSortedSelection, OdGiPathNode[] pObjectList)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_rayTrace__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection, pObjectList);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rayTrace(OdGePoint3d rayOrigin, OdGeVector3d rayDirection, OdGsRayTraceReactor pReactor, bool bSortedSelection)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_rayTrace__SWIG_2(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor), bSortedSelection);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rayTrace(OdGePoint3d rayOrigin, OdGeVector3d rayDirection, OdGsRayTraceReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_rayTrace__SWIG_3(swigCPtr, OdGePoint3d.getCPtr(rayOrigin), OdGeVector3d.getCPtr(rayDirection), OdGsRayTraceReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void enableAntiAliasing(uint nMode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_enableAntiAliasing(swigCPtr, nMode);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint antiAliasingMode()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_antiAliasingMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableSSAO(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_enableSSAO(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool ssaoMode()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_ssaoMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableRayTracedView(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsView_enableRayTracedView(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool rayTracedView()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_rayTracedView(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsView_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
