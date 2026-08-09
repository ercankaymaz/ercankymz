using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbGripData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGripData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGripData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbGripData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbGripData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbGripData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbGripData__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbGripData(OdDbGripData arg0)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbGripData__SWIG_1(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbGripData Assign(OdDbGripData arg0)
	{
		OdDbGripData result = Helpers.GetObject<OdDbGripData>(TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_Assign(swigCPtr, getCPtr(arg0)), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d gripPoint()
	{
		OdGePoint3d result = new OdGePoint3d(TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_gripPoint(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGripPoint(OdGePoint3d pt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setGripPoint(swigCPtr, OdGePoint3d.getCPtr(pt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr appData()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_appData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAppData(IntPtr pAppData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setAppData(swigCPtr, pAppData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxClass appDataOdRxClass()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_appDataOdRxClass(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setAppDataOdRxClass(OdRxClass pClass)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setAppDataOdRxClass(swigCPtr, OdRxClass.getCPtr(pClass));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_RootIntegrated_Globals.GripOperationPtrDelegate hotGripFunc()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_hotGripFunc(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.GripOperationPtrDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = (OdDbGripData pThis, OdDbStub entId, int iContextFlags) => (Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.GripOperationPtrDelegateNative)) as TD_RootIntegrated_Globals.GripOperationPtrDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbGripData>(pThis), OdMarshalHelper.ObjectToPtr<OdDbStub>(entId), iContextFlags);
		}
		return result;
	}

	public void setHotGripFunc(TD_RootIntegrated_Globals.GripOperationPtrDelegate pf)
	{
		TD_RootIntegrated_Globals.GripOperationPtrDelegateNative gripOperationPtrDelegateNative = null;
		if (pf != null)
		{
			gripOperationPtrDelegateNative = (IntPtr pThis, IntPtr entId, int iContextFlags) => pf(OdMarshalHelper.PtrToObject<OdDbGripData>(pThis), OdMarshalHelper.PtrToObject<OdDbStub>(entId), iContextFlags);
		}
		IntPtr jarg = ((pf == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(gripOperationPtrDelegateNative));
		DelegateHolder.Add(gripOperationPtrDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setHotGripFunc(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_RootIntegrated_Globals.GripOperationPtrDelegate hoverFunc()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_hoverFunc(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.GripOperationPtrDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = (OdDbGripData pThis, OdDbStub entId, int iContextFlags) => (Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.GripOperationPtrDelegateNative)) as TD_RootIntegrated_Globals.GripOperationPtrDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbGripData>(pThis), OdMarshalHelper.ObjectToPtr<OdDbStub>(entId), iContextFlags);
		}
		return result;
	}

	public void setHoverFunc(TD_RootIntegrated_Globals.GripOperationPtrDelegate pf)
	{
		TD_RootIntegrated_Globals.GripOperationPtrDelegateNative gripOperationPtrDelegateNative = null;
		if (pf != null)
		{
			gripOperationPtrDelegateNative = (IntPtr pThis, IntPtr entId, int iContextFlags) => pf(OdMarshalHelper.PtrToObject<OdDbGripData>(pThis), OdMarshalHelper.PtrToObject<OdDbStub>(entId), iContextFlags);
		}
		IntPtr jarg = ((pf == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(gripOperationPtrDelegateNative));
		DelegateHolder.Add(gripOperationPtrDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setHoverFunc(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_RootIntegrated_Globals.GripWorldDrawPtrDelegate worldDraw()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_worldDraw(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.GripWorldDrawPtrDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = (OdDbGripData pThis, OdGiWorldDraw pWd, OdDbStub entId, OdDbGripOperations_DrawType type, OdGePoint3d imageGripPoint, double dGripSize) => (Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.GripWorldDrawPtrDelegateNative)) as TD_RootIntegrated_Globals.GripWorldDrawPtrDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbGripData>(pThis), OdMarshalHelper.ObjectToPtr<OdGiWorldDraw>(pWd), OdMarshalHelper.ObjectToPtr<OdDbStub>(entId), type, OdMarshalHelper.ObjectToPtr<OdGePoint3d>(imageGripPoint), dGripSize);
		}
		return result;
	}

	public void setWorldDraw(TD_RootIntegrated_Globals.GripWorldDrawPtrDelegate pf)
	{
		TD_RootIntegrated_Globals.GripWorldDrawPtrDelegateNative gripWorldDrawPtrDelegateNative = null;
		if (pf != null)
		{
			gripWorldDrawPtrDelegateNative = (IntPtr pThis, IntPtr pWd, IntPtr entId, OdDbGripOperations_DrawType type, IntPtr imageGripPoint, double dGripSize) => pf(OdMarshalHelper.PtrToObject<OdDbGripData>(pThis), OdMarshalHelper.PtrToObject<OdGiWorldDraw>(pWd), OdMarshalHelper.PtrToObject<OdDbStub>(entId), type, OdMarshalHelper.PtrToObject<OdGePoint3d>(imageGripPoint), dGripSize);
		}
		IntPtr jarg = ((pf == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(gripWorldDrawPtrDelegateNative));
		DelegateHolder.Add(gripWorldDrawPtrDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setWorldDraw(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_RootIntegrated_Globals.GripViewportDrawPtrDelegate viewportDraw()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_viewportDraw(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.GripViewportDrawPtrDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = delegate(OdDbGripData pThis, OdGiViewportDraw pWd, OdDbStub entId, OdDbGripOperations_DrawType type, OdGePoint3d imageGripPoint, int gripSize)
			{
				(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.GripViewportDrawPtrDelegateNative)) as TD_RootIntegrated_Globals.GripViewportDrawPtrDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbGripData>(pThis), OdMarshalHelper.ObjectToPtr<OdGiViewportDraw>(pWd), OdMarshalHelper.ObjectToPtr<OdDbStub>(entId), type, OdMarshalHelper.ObjectToPtr<OdGePoint3d>(imageGripPoint), gripSize);
			};
		}
		return result;
	}

	public void setViewportDraw(TD_RootIntegrated_Globals.GripViewportDrawPtrDelegate pf)
	{
		TD_RootIntegrated_Globals.GripViewportDrawPtrDelegateNative gripViewportDrawPtrDelegateNative = null;
		if (pf != null)
		{
			gripViewportDrawPtrDelegateNative = delegate(IntPtr pThis, IntPtr pWd, IntPtr entId, OdDbGripOperations_DrawType type, IntPtr imageGripPoint, int gripSize)
			{
				pf(OdMarshalHelper.PtrToObject<OdDbGripData>(pThis), OdMarshalHelper.PtrToObject<OdGiViewportDraw>(pWd), OdMarshalHelper.PtrToObject<OdDbStub>(entId), type, OdMarshalHelper.PtrToObject<OdGePoint3d>(imageGripPoint), gripSize);
			};
		}
		IntPtr jarg = ((pf == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(gripViewportDrawPtrDelegateNative));
		DelegateHolder.Add(gripViewportDrawPtrDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setViewportDraw(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_RootIntegrated_Globals.GripOpStatusPtrDelegate gripOpStatFunc()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_gripOpStatFunc(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.GripOpStatusPtrDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = delegate(OdDbGripData pThis, OdDbStub entId, OdDbGripOperations_GripStatus status)
			{
				(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.GripOpStatusPtrDelegateNative)) as TD_RootIntegrated_Globals.GripOpStatusPtrDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbGripData>(pThis), OdMarshalHelper.ObjectToPtr<OdDbStub>(entId), status);
			};
		}
		return result;
	}

	public void setGripOpStatFunc(TD_RootIntegrated_Globals.GripOpStatusPtrDelegate pf)
	{
		TD_RootIntegrated_Globals.GripOpStatusPtrDelegateNative gripOpStatusPtrDelegateNative = null;
		if (pf != null)
		{
			gripOpStatusPtrDelegateNative = delegate(IntPtr pThis, IntPtr entId, OdDbGripOperations_GripStatus status)
			{
				pf(OdMarshalHelper.PtrToObject<OdDbGripData>(pThis), OdMarshalHelper.PtrToObject<OdDbStub>(entId), status);
			};
		}
		IntPtr jarg = ((pf == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(gripOpStatusPtrDelegateNative));
		DelegateHolder.Add(gripOpStatusPtrDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setGripOpStatFunc(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_RootIntegrated_Globals.GripToolTipPtrDelegate toolTipFunc()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_toolTipFunc(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.GripToolTipPtrDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = (OdDbGripData pThis) => Marshal.PtrToStringUni((Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.GripToolTipPtrDelegateNative)) as TD_RootIntegrated_Globals.GripToolTipPtrDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbGripData>(pThis)));
		}
		return result;
	}

	public void setToolTipFunc(TD_RootIntegrated_Globals.GripToolTipPtrDelegate pf)
	{
		TD_RootIntegrated_Globals.GripToolTipPtrDelegateNative gripToolTipPtrDelegateNative = null;
		if (pf != null)
		{
			gripToolTipPtrDelegateNative = (IntPtr pThis) => Marshal.StringToCoTaskMemUni(pf(OdMarshalHelper.PtrToObject<OdDbGripData>(pThis)));
		}
		IntPtr jarg = ((pf == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(gripToolTipPtrDelegateNative));
		DelegateHolder.Add(gripToolTipPtrDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setToolTipFunc(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d alternateBasePoint()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_alternateBasePoint(swigCPtr);
		OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAlternateBasePoint(OdGePoint3d altBasePt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setAlternateBasePoint(swigCPtr, OdGePoint3d.getCPtr(altBasePt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint bitFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_bitFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBitFlags(uint flags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setBitFlags(swigCPtr, flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool skipWhenShared()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_skipWhenShared(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSkipWhenShared(bool skip)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setSkipWhenShared(swigCPtr, skip);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isRubberBandLineDisabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_isRubberBandLineDisabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void disableRubberBandLine(bool disable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_disableRubberBandLine(swigCPtr, disable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool areModeKeywordsDisabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_areModeKeywordsDisabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void disableModeKeywords(bool disable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_disableModeKeywords(swigCPtr, disable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool drawAtDragImageGripPoint()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_drawAtDragImageGripPoint(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDrawAtDragImageGripPoint(bool atDragPoint)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setDrawAtDragImageGripPoint(swigCPtr, atDragPoint);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool triggerGrip()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_triggerGrip(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTriggerGrip(bool trigger)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setTriggerGrip(swigCPtr, trigger);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool forcedPickOn()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_forcedPickOn(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setForcedPickOn(bool on)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setForcedPickOn(swigCPtr, on);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool mapGripHotToRtClk()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_mapGripHotToRtClk(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMapGripHotToRtClk(bool on)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setMapGripHotToRtClk(swigCPtr, on);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool gizmosEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_gizmosEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGizmosEnabled(bool on)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setGizmosEnabled(swigCPtr, on);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool gripIsPerViewport()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_gripIsPerViewport(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGripIsPerViewport(bool on)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setGripIsPerViewport(swigCPtr, on);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_RootIntegrated_Globals.GripRtClkHandlerDelegate rtClk()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_rtClk(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.GripRtClkHandlerDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = delegate(OdDbGripDataArray hotGrips, OdDbStubPtrArray ents, ref string menuName, ref IntPtr menu, ref TD_RootIntegrated_Globals.ContextMenuItemIndexPtrDelegate cb)
			{
				TD_RootIntegrated_Globals.GripRtClkHandlerDelegateNative gripRtClkHandlerDelegateNative = Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.GripRtClkHandlerDelegateNative)) as TD_RootIntegrated_Globals.GripRtClkHandlerDelegateNative;
				IntPtr handle = OdDbGripDataArray.getCPtr(hotGrips).Handle;
				IntPtr ents2 = OdMarshalHelper.ObjectToPtr<OdDbStubPtrArray>(ents);
				IntPtr intPtr = OdString2StringConvHelper.StringToOdString(menuName);
				TD_RootIntegrated_Globals.ContextMenuItemIndexPtrDelegate cb_csharpTemp = cb;
				TD_RootIntegrated_Globals.ContextMenuItemIndexPtrDelegateNative cb_nativeTemp = null;
				if (cb_csharpTemp != null)
				{
					cb_nativeTemp = delegate(uint itemIndex)
					{
						cb_csharpTemp(itemIndex);
					};
				}
				TD_RootIntegrated_Globals.ContextMenuItemIndexPtrDelegateNative contextMenuItemIndexPtrDelegateNative = cb_nativeTemp;
				try
				{
					return gripRtClkHandlerDelegateNative(handle, ents2, intPtr, ref menu, ref cb_nativeTemp);
				}
				finally
				{
					menuName = OdString2StringConvHelper.OdStringToString(intPtr);
					if (contextMenuItemIndexPtrDelegateNative != cb_nativeTemp)
					{
						if (cb_nativeTemp != null)
						{
							cb = delegate(uint itemIndex)
							{
								cb_nativeTemp(itemIndex);
							};
						}
						else
						{
							cb = null;
						}
					}
				}
			};
		}
		return result;
	}

	public void setRtClk(TD_RootIntegrated_Globals.GripRtClkHandlerDelegate pf)
	{
		TD_RootIntegrated_Globals.GripRtClkHandlerDelegateNative gripRtClkHandlerDelegateNative = null;
		if (pf != null)
		{
			gripRtClkHandlerDelegateNative = delegate(IntPtr hotGrips, IntPtr ents, IntPtr menuName, ref IntPtr menu, ref TD_RootIntegrated_Globals.ContextMenuItemIndexPtrDelegateNative cb)
			{
				OdDbGripDataArray hotGrips2 = new OdDbGripDataArray(hotGrips, cMemoryOwn: false);
				OdDbStubPtrArray ents2 = OdMarshalHelper.PtrToObject<OdDbStubPtrArray>(ents);
				string menuName2 = OdString2StringConvHelper.OdStringToString(menuName);
				string text = menuName2;
				TD_RootIntegrated_Globals.ContextMenuItemIndexPtrDelegateNative cb_nativeTemp = cb;
				TD_RootIntegrated_Globals.ContextMenuItemIndexPtrDelegate cb_csharpTemp = null;
				if (cb_nativeTemp != null)
				{
					cb_csharpTemp = delegate(uint itemIndex)
					{
						cb_nativeTemp(itemIndex);
					};
				}
				TD_RootIntegrated_Globals.ContextMenuItemIndexPtrDelegate contextMenuItemIndexPtrDelegate = cb_csharpTemp;
				try
				{
					return pf(hotGrips2, ents2, ref menuName2, ref menu, ref cb_csharpTemp);
				}
				finally
				{
					if (text != menuName2)
					{
						OdString2StringConvHelper.AssignStringToOdString(menuName, menuName2);
					}
					if (contextMenuItemIndexPtrDelegate != cb_csharpTemp)
					{
						if (cb_csharpTemp != null)
						{
							cb = delegate(uint itemIndex)
							{
								cb_csharpTemp(itemIndex);
							};
						}
						else
						{
							cb = null;
						}
					}
				}
			};
		}
		IntPtr jarg = ((pf == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(gripRtClkHandlerDelegateNative));
		DelegateHolder.Add(gripRtClkHandlerDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_setRtClk(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbGripData_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
