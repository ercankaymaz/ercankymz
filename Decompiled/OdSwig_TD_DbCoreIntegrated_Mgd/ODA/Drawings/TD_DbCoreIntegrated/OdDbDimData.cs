using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDimData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbDimData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDimData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbDimData()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDimData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbDimData()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDimData__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private static IntPtr SwigConstructOdDbDimData(OdDbDimension pDim, TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate setDimFunc, uint bitFlags, IntPtr appData, TD_DbCoreIntegrated_Globals.DimDataSetCustomStringFuncPtrDelegate setCustomStringFunc)
	{
		TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegateNative dimDataSetValueFuncPtrDelegateNative = null;
		if (setDimFunc != null)
		{
			dimDataSetValueFuncPtrDelegateNative = (IntPtr pThis, IntPtr pEnt, double newValue, IntPtr offset) => setDimFunc(OdMarshalHelper.PtrToObject<OdDbDimData>(pThis), OdMarshalHelper.PtrToObject<OdDbEntity>(pEnt), newValue, OdMarshalHelper.PtrToObject<OdGeVector3d>(offset));
		}
		IntPtr jarg = ((setDimFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dimDataSetValueFuncPtrDelegateNative));
		DelegateHolder.Add(dimDataSetValueFuncPtrDelegateNative);
		TD_DbCoreIntegrated_Globals.DimDataSetCustomStringFuncPtrDelegateNative dimDataSetCustomStringFuncPtrDelegateNative = null;
		if (setCustomStringFunc != null)
		{
			dimDataSetCustomStringFuncPtrDelegateNative = (IntPtr pThis, IntPtr pEnt, IntPtr sCustomString, IntPtr offset) => setCustomStringFunc(OdMarshalHelper.PtrToObject<OdDbDimData>(pThis), OdMarshalHelper.PtrToObject<OdDbEntity>(pEnt), OdString2StringConvHelper.OdStringToString(sCustomString), OdMarshalHelper.PtrToObject<OdGeVector3d>(offset));
		}
		IntPtr jarg2 = ((setCustomStringFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dimDataSetCustomStringFuncPtrDelegateNative));
		DelegateHolder.Add(dimDataSetCustomStringFuncPtrDelegateNative);
		return TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDimData__SWIG_1(OdDbDimension.getCPtr(pDim), jarg, bitFlags, appData, jarg2);
	}

	public OdDbDimData(OdDbDimension pDim, TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate setDimFunc, uint bitFlags, IntPtr appData, TD_DbCoreIntegrated_Globals.DimDataSetCustomStringFuncPtrDelegate setCustomStringFunc)
		: this(SwigConstructOdDbDimData(pDim, setDimFunc, bitFlags, appData, setCustomStringFunc), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private static IntPtr SwigConstructOdDbDimData(OdDbDimension pDim, TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate setDimFunc, uint bitFlags, IntPtr appData)
	{
		TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegateNative dimDataSetValueFuncPtrDelegateNative = null;
		if (setDimFunc != null)
		{
			dimDataSetValueFuncPtrDelegateNative = (IntPtr pThis, IntPtr pEnt, double newValue, IntPtr offset) => setDimFunc(OdMarshalHelper.PtrToObject<OdDbDimData>(pThis), OdMarshalHelper.PtrToObject<OdDbEntity>(pEnt), newValue, OdMarshalHelper.PtrToObject<OdGeVector3d>(offset));
		}
		IntPtr jarg = ((setDimFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dimDataSetValueFuncPtrDelegateNative));
		DelegateHolder.Add(dimDataSetValueFuncPtrDelegateNative);
		return TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDimData__SWIG_2(OdDbDimension.getCPtr(pDim), jarg, bitFlags, appData);
	}

	public OdDbDimData(OdDbDimension pDim, TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate setDimFunc, uint bitFlags, IntPtr appData)
		: this(SwigConstructOdDbDimData(pDim, setDimFunc, bitFlags, appData), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private static IntPtr SwigConstructOdDbDimData(OdDbDimension pDim, TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate setDimFunc, uint bitFlags)
	{
		TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegateNative dimDataSetValueFuncPtrDelegateNative = null;
		if (setDimFunc != null)
		{
			dimDataSetValueFuncPtrDelegateNative = (IntPtr pThis, IntPtr pEnt, double newValue, IntPtr offset) => setDimFunc(OdMarshalHelper.PtrToObject<OdDbDimData>(pThis), OdMarshalHelper.PtrToObject<OdDbEntity>(pEnt), newValue, OdMarshalHelper.PtrToObject<OdGeVector3d>(offset));
		}
		IntPtr jarg = ((setDimFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dimDataSetValueFuncPtrDelegateNative));
		DelegateHolder.Add(dimDataSetValueFuncPtrDelegateNative);
		return TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDimData__SWIG_3(OdDbDimension.getCPtr(pDim), jarg, bitFlags);
	}

	public OdDbDimData(OdDbDimension pDim, TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate setDimFunc, uint bitFlags)
		: this(SwigConstructOdDbDimData(pDim, setDimFunc, bitFlags), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private static IntPtr SwigConstructOdDbDimData(OdDbDimension pDim, TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate setDimFunc)
	{
		TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegateNative dimDataSetValueFuncPtrDelegateNative = null;
		if (setDimFunc != null)
		{
			dimDataSetValueFuncPtrDelegateNative = (IntPtr pThis, IntPtr pEnt, double newValue, IntPtr offset) => setDimFunc(OdMarshalHelper.PtrToObject<OdDbDimData>(pThis), OdMarshalHelper.PtrToObject<OdDbEntity>(pEnt), newValue, OdMarshalHelper.PtrToObject<OdGeVector3d>(offset));
		}
		IntPtr jarg = ((setDimFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dimDataSetValueFuncPtrDelegateNative));
		DelegateHolder.Add(dimDataSetValueFuncPtrDelegateNative);
		return TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDimData__SWIG_4(OdDbDimension.getCPtr(pDim), jarg);
	}

	public OdDbDimData(OdDbDimension pDim, TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate setDimFunc)
		: this(SwigConstructOdDbDimData(pDim, setDimFunc), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDimData(OdDbDimension pDim)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDimData__SWIG_5(OdDbDimension.getCPtr(pDim)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDimData(OdDbDimData arg0)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDimData__SWIG_6(getCPtr(arg0)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDimData Assign(OdDbDimData arg0)
	{
		OdDbDimData result = new OdDbDimData(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_Assign(swigCPtr, getCPtr(arg0)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbDimension dimension()
	{
		OdDbDimension rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDimension>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_dimension(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setDimension(OdDbDimension pDim)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimension(swigCPtr, OdDbDimension.getCPtr(pDim));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId ownerId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_ownerId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setOwnerId(OdDbObjectId objId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setOwnerId(swigCPtr, OdDbObjectId.getCPtr(objId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint bitFlags()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_bitFlags(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBitFlags(uint flags)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setBitFlags(swigCPtr, flags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDimFocal()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isDimFocal(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimFocal(bool focal)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimFocal(swigCPtr, focal);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDimEditable()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isDimEditable(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimEditable(bool editable)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimEditable(swigCPtr, editable);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDimInvisible()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isDimInvisible(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimInvisible(bool invisible)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimInvisible(swigCPtr, invisible);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDimHideIfValueIsZero()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isDimHideIfValueIsZero(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimHideIfValueIsZero(bool hide)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimHideIfValueIsZero(swigCPtr, hide);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr appData()
	{
		IntPtr result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_appData(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAppData(IntPtr appData)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setAppData(swigCPtr, appData);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate dimValueFunc()
	{
		IntPtr nativeCallback = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_dimValueFunc(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = (OdDbDimData pThis, OdDbEntity pEnt, double newValue, OdGeVector3d offset) => (Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegateNative)) as TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbDimData>(pThis), OdMarshalHelper.ObjectToPtr<OdDbEntity>(pEnt), newValue, OdMarshalHelper.ObjectToPtr<OdGeVector3d>(offset));
		}
		return result;
	}

	public void setDimValueFunc(TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegate funcPtr)
	{
		TD_DbCoreIntegrated_Globals.DimDataSetValueFuncPtrDelegateNative dimDataSetValueFuncPtrDelegateNative = null;
		if (funcPtr != null)
		{
			dimDataSetValueFuncPtrDelegateNative = (IntPtr pThis, IntPtr pEnt, double newValue, IntPtr offset) => funcPtr(OdMarshalHelper.PtrToObject<OdDbDimData>(pThis), OdMarshalHelper.PtrToObject<OdDbEntity>(pEnt), newValue, OdMarshalHelper.PtrToObject<OdGeVector3d>(offset));
		}
		IntPtr jarg = ((funcPtr == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dimDataSetValueFuncPtrDelegateNative));
		DelegateHolder.Add(dimDataSetValueFuncPtrDelegateNative);
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimValueFunc(swigCPtr, jarg);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_DbCoreIntegrated_Globals.DimDataSetCustomStringFuncPtrDelegate customStringFunc()
	{
		IntPtr nativeCallback = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_customStringFunc(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_DbCoreIntegrated_Globals.DimDataSetCustomStringFuncPtrDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = (OdDbDimData pThis, OdDbEntity pEnt, string sCustomString, OdGeVector3d offset) => (Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_DbCoreIntegrated_Globals.DimDataSetCustomStringFuncPtrDelegateNative)) as TD_DbCoreIntegrated_Globals.DimDataSetCustomStringFuncPtrDelegateNative)(OdMarshalHelper.ObjectToPtr<OdDbDimData>(pThis), OdMarshalHelper.ObjectToPtr<OdDbEntity>(pEnt), OdString2StringConvHelper.StringToOdString(sCustomString), OdMarshalHelper.ObjectToPtr<OdGeVector3d>(offset));
		}
		return result;
	}

	public void setCustomStringFunc(TD_DbCoreIntegrated_Globals.DimDataSetCustomStringFuncPtrDelegate funcPtr)
	{
		TD_DbCoreIntegrated_Globals.DimDataSetCustomStringFuncPtrDelegateNative dimDataSetCustomStringFuncPtrDelegateNative = null;
		if (funcPtr != null)
		{
			dimDataSetCustomStringFuncPtrDelegateNative = (IntPtr pThis, IntPtr pEnt, IntPtr sCustomString, IntPtr offset) => funcPtr(OdMarshalHelper.PtrToObject<OdDbDimData>(pThis), OdMarshalHelper.PtrToObject<OdDbEntity>(pEnt), OdString2StringConvHelper.OdStringToString(sCustomString), OdMarshalHelper.PtrToObject<OdGeVector3d>(offset));
		}
		IntPtr jarg = ((funcPtr == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dimDataSetCustomStringFuncPtrDelegateNative));
		DelegateHolder.Add(dimDataSetCustomStringFuncPtrDelegateNative);
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setCustomStringFunc(swigCPtr, jarg);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDimResultantLength()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isDimResultantLength(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimResultantLength(bool bValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimResultantLength(swigCPtr, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDimDeltaLength()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isDimDeltaLength(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimDeltaLength(bool bValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimDeltaLength(swigCPtr, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDimResultantAngle()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isDimResultantAngle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimResultantAngle(bool bValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimResultantAngle(swigCPtr, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDimDeltaAngle()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isDimDeltaAngle(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimDeltaAngle(bool bValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimDeltaAngle(swigCPtr, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDimRadius()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isDimRadius(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDimRadius(bool bValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setDimRadius(swigCPtr, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isCustomDimValue()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isCustomDimValue(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCustomDimValue(bool custom)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setCustomDimValue(swigCPtr, custom);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isConstrained()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isConstrained(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setConstrain(bool bValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setConstrain(swigCPtr, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isCustomString()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_isCustomString(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setCustomString(bool bValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDimData_setCustomString(swigCPtr, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
