using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdRxValueHelpers_TD_DbCoreIntegrated : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxValueHelpers_TD_DbCoreIntegrated(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxValueHelpers_TD_DbCoreIntegrated obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRxValueHelpers_TD_DbCoreIntegrated()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdRxValueHelpers_TD_DbCoreIntegrated(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbDate(OdDbDate from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbDate(OdDbDate.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbDate rxvalue_cast_TD_DbCoreIntegrated_OdDbDate(OdRxValue from)
	{
		OdDbDate result = new OdDbDate(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbDate(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbDate()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbDate();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdCmColor(OdCmColor from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdCmColor(OdCmColor.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdCmColor rxvalue_cast_TD_DbCoreIntegrated_OdCmColor(OdRxValue from)
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdCmColor(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdCmColor()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdCmColor();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMTextPtr(OdDbMText from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMTextPtr(OdDbMText.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMText rxvalue_cast_TD_DbCoreIntegrated_OdDbMTextPtr(OdRxValue from)
	{
		OdDbMText rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMText>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMTextPtr(OdRxValue.getCPtr(from)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMTextPtr()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMTextPtr();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbObjectId(OdDbObjectId from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbObjectId(OdDbObjectId.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbObjectId rxvalue_cast_TD_DbCoreIntegrated_OdDbObjectId(OdRxValue from)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbObjectId(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbObjectId()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbObjectId();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__EndCaps(OdDb_EndCaps from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__EndCaps((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_EndCaps rxvalue_cast_TD_DbCoreIntegrated_OdDb__EndCaps(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__EndCaps(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_EndCaps)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__EndCaps()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__EndCaps();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdCellRange(OdCellRange from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdCellRange(OdCellRange.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdCellRange rxvalue_cast_TD_DbCoreIntegrated_OdCellRange(OdRxValue from)
	{
		OdCellRange result = new OdCellRange(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdCellRange(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdCellRange()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdCellRange();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdRectangle3d(OdRectangle3d from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdRectangle3d(OdRectangle3d.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRectangle3d rxvalue_cast_TD_DbCoreIntegrated_OdRectangle3d(OdRxValue from)
	{
		OdRectangle3d result = new OdRectangle3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdRectangle3d(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdRectangle3d()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdRectangle3d();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__XrefStatus(OdDb_XrefStatus from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__XrefStatus((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_XrefStatus rxvalue_cast_TD_DbCoreIntegrated_OdDb__XrefStatus(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__XrefStatus(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_XrefStatus)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__XrefStatus()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__XrefStatus();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbEvalVariant(OdDbEvalVariant from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbEvalVariant(OdDbEvalVariant.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbEvalVariant rxvalue_cast_TD_DbCoreIntegrated_OdDbEvalVariant(OdRxValue from)
	{
		OdDbEvalVariant result = new OdDbEvalVariant(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbEvalVariant(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbEvalVariant()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbEvalVariant();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__Visibility(OdDb_Visibility from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__Visibility((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_Visibility rxvalue_cast_TD_DbCoreIntegrated_OdDb__Visibility(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__Visibility(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Visibility)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__Visibility()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__Visibility();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__Poly3dType(OdDb_Poly3dType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__Poly3dType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_Poly3dType rxvalue_cast_TD_DbCoreIntegrated_OdDb__Poly3dType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__Poly3dType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Poly3dType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__Poly3dType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__Poly3dType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__Poly2dType(OdDb_Poly2dType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__Poly2dType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_Poly2dType rxvalue_cast_TD_DbCoreIntegrated_OdDb__Poly2dType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__Poly2dType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Poly2dType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__Poly2dType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__Poly2dType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbLoftOptions(OdDbLoftOptions from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbLoftOptions(OdDbLoftOptions.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbLoftOptions rxvalue_cast_TD_DbCoreIntegrated_OdDbLoftOptions(OdRxValue from)
	{
		OdDbLoftOptions result = new OdDbLoftOptions(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbLoftOptions(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbLoftOptions()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbLoftOptions();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__DwgVersion(DwgVersion from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__DwgVersion((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static DwgVersion rxvalue_cast_TD_DbCoreIntegrated_OdDb__DwgVersion(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__DwgVersion(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgVersion)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__DwgVersion()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__DwgVersion();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__JoinStyle(OdDb_JoinStyle from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__JoinStyle((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_JoinStyle rxvalue_cast_TD_DbCoreIntegrated_OdDb__JoinStyle(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__JoinStyle(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_JoinStyle)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__JoinStyle()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__JoinStyle();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbSweepOptions(OdDbSweepOptions from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbSweepOptions(OdDbSweepOptions.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbSweepOptions rxvalue_cast_TD_DbCoreIntegrated_OdDbSweepOptions(OdRxValue from)
	{
		OdDbSweepOptions result = new OdDbSweepOptions(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbSweepOptions(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbSweepOptions()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbSweepOptions();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__CollisionType(OdDb_CollisionType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__CollisionType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_CollisionType rxvalue_cast_TD_DbCoreIntegrated_OdDb__CollisionType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__CollisionType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_CollisionType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__CollisionType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__CollisionType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__FlowDirection(OdDb_FlowDirection from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__FlowDirection((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_FlowDirection rxvalue_cast_TD_DbCoreIntegrated_OdDb__FlowDirection(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__FlowDirection(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_FlowDirection)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__FlowDirection()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__FlowDirection();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbSection__State(OdDbSection_State from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbSection__State((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbSection_State rxvalue_cast_TD_DbCoreIntegrated_OdDbSection__State(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbSection__State(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbSection_State)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbSection__State()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbSection__State();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__PolyMeshType(OdDb_PolyMeshType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__PolyMeshType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_PolyMeshType rxvalue_cast_TD_DbCoreIntegrated_OdDb__PolyMeshType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__PolyMeshType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_PolyMeshType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__PolyMeshType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__PolyMeshType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__TextHorzMode(OdDb_TextHorzMode from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__TextHorzMode((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_TextHorzMode rxvalue_cast_TD_DbCoreIntegrated_OdDb__TextHorzMode(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__TextHorzMode(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_TextHorzMode)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__TextHorzMode()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__TextHorzMode();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__Vertex3dType(OdDb_Vertex3dType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__Vertex3dType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_Vertex3dType rxvalue_cast_TD_DbCoreIntegrated_OdDb__Vertex3dType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__Vertex3dType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Vertex3dType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__Vertex3dType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__Vertex3dType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__TextVertMode(OdDb_TextVertMode from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__TextVertMode((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_TextVertMode rxvalue_cast_TD_DbCoreIntegrated_OdDb__TextVertMode(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__TextVertMode(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_TextVertMode)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__TextVertMode()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__TextVertMode();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__Vertex2dType(OdDb_Vertex2dType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__Vertex2dType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_Vertex2dType rxvalue_cast_TD_DbCoreIntegrated_OdDb__Vertex2dType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__Vertex2dType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_Vertex2dType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__Vertex2dType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__Vertex2dType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__MaintReleaseVer(MaintReleaseVer from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__MaintReleaseVer((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static MaintReleaseVer rxvalue_cast_TD_DbCoreIntegrated_OdDb__MaintReleaseVer(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__MaintReleaseVer(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (MaintReleaseVer)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__MaintReleaseVer()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__MaintReleaseVer();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbLeader__AnnoType(OdDbLeader_AnnoType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbLeader__AnnoType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbLeader_AnnoType rxvalue_cast_TD_DbCoreIntegrated_OdDbLeader__AnnoType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbLeader__AnnoType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbLeader_AnnoType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbLeader__AnnoType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbLeader__AnnoType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbOle2Frame__Type(OdDbOle2Frame_Type from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbOle2Frame__Type((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbOle2Frame_Type rxvalue_cast_TD_DbCoreIntegrated_OdDbOle2Frame__Type(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbOle2Frame__Type(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbOle2Frame_Type)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbOle2Frame__Type()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbOle2Frame__Type();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__LoftNormalsType(OdDb_LoftNormalsType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__LoftNormalsType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_LoftNormalsType rxvalue_cast_TD_DbCoreIntegrated_OdDb__LoftNormalsType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__LoftNormalsType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_LoftNormalsType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__LoftNormalsType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__LoftNormalsType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbBlockTableRecordId(OdDbBlockTableRecordId from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbBlockTableRecordId(OdDbBlockTableRecordId.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbBlockTableRecordId rxvalue_cast_TD_DbCoreIntegrated_OdDbBlockTableRecordId(OdRxValue from)
	{
		OdDbBlockTableRecordId result = new OdDbBlockTableRecordId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbBlockTableRecordId(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbBlockTableRecordId()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbBlockTableRecordId();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__LineSpacingStyle(OdDb_LineSpacingStyle from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__LineSpacingStyle((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_LineSpacingStyle rxvalue_cast_TD_DbCoreIntegrated_OdDb__LineSpacingStyle(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__LineSpacingStyle(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_LineSpacingStyle)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__LineSpacingStyle()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__LineSpacingStyle();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMText__ColumnType(OdDbMText_ColumnType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMText__ColumnType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMText_ColumnType rxvalue_cast_TD_DbCoreIntegrated_OdDbMText__ColumnType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMText__ColumnType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMText_ColumnType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMText__ColumnType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMText__ColumnType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb3dPolylineVertexPtr(OdDb3dPolylineVertex from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb3dPolylineVertexPtr(OdDb3dPolylineVertex.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb3dPolylineVertex rxvalue_cast_TD_DbCoreIntegrated_OdDb3dPolylineVertexPtr(OdRxValue from)
	{
		OdDb3dPolylineVertex rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDb3dPolylineVertex>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb3dPolylineVertexPtr(OdRxValue.getCPtr(from)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb3dPolylineVertexPtr()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb3dPolylineVertexPtr();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__TableBreakOption(OdDb_TableBreakOption from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__TableBreakOption((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_TableBreakOption rxvalue_cast_TD_DbCoreIntegrated_OdDb__TableBreakOption(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__TableBreakOption(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_TableBreakOption)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__TableBreakOption()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__TableBreakOption();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__OrthographicView(OdDb_OrthographicView from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__OrthographicView((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_OrthographicView rxvalue_cast_TD_DbCoreIntegrated_OdDb__OrthographicView(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__OrthographicView(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_OrthographicView)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__OrthographicView()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__OrthographicView();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbHatch__HatchStyle(OdDbHatch_HatchStyle from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbHatch__HatchStyle((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbHatch_HatchStyle rxvalue_cast_TD_DbCoreIntegrated_OdDbHatch__HatchStyle(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbHatch__HatchStyle(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbHatch_HatchStyle)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbHatch__HatchStyle()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbHatch__HatchStyle();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbLight__LampColorType(OdDbLight_LampColorType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbLight__LampColorType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbLight_LampColorType rxvalue_cast_TD_DbCoreIntegrated_OdDbLight__LampColorType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbLight__LampColorType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbLight_LampColorType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbLight__LampColorType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbLight__LampColorType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbSpline__SplineType(OdDbSpline_SplineType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbSpline__SplineType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbSpline_SplineType rxvalue_cast_TD_DbCoreIntegrated_OdDbSpline__SplineType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbSpline__SplineType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbSpline_SplineType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbSpline__SplineType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbSpline__SplineType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__MeasurementValue(MeasurementValue from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__MeasurementValue((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static MeasurementValue rxvalue_cast_TD_DbCoreIntegrated_OdDb__MeasurementValue(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__MeasurementValue(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (MeasurementValue)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__MeasurementValue()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__MeasurementValue();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbHelix__ConstrainType(OdDbHelix_ConstrainType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbHelix__ConstrainType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbHelix_ConstrainType rxvalue_cast_TD_DbCoreIntegrated_OdDbHelix__ConstrainType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbHelix__ConstrainType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbHelix_ConstrainType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbHelix__ConstrainType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbHelix__ConstrainType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbOle2Frame__PlotQuality(OdDbOle2Frame_PlotQuality from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbOle2Frame__PlotQuality((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbOle2Frame_PlotQuality rxvalue_cast_TD_DbCoreIntegrated_OdDbOle2Frame__PlotQuality(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbOle2Frame__PlotQuality(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbOle2Frame_PlotQuality)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbOle2Frame__PlotQuality()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbOle2Frame__PlotQuality();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMText__FlowDirection(OdDbMText_FlowDirection from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMText__FlowDirection((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMText_FlowDirection rxvalue_cast_TD_DbCoreIntegrated_OdDbMText__FlowDirection(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMText__FlowDirection(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMText_FlowDirection)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMText__FlowDirection()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMText__FlowDirection();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbLight__LampColorPreset(OdDbLight_LampColorPreset from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbLight__LampColorPreset((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbLight_LampColorPreset rxvalue_cast_TD_DbCoreIntegrated_OdDbLight__LampColorPreset(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbLight__LampColorPreset(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbLight_LampColorPreset)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbLight__LampColorPreset()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbLight__LampColorPreset();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMText__AttachmentPoint(OdDbMText_AttachmentPoint from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMText__AttachmentPoint((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMText_AttachmentPoint rxvalue_cast_TD_DbCoreIntegrated_OdDbMText__AttachmentPoint(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMText__AttachmentPoint(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMText_AttachmentPoint)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMText__AttachmentPoint()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMText__AttachmentPoint();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbViewport__ShadePlotType(OdDbViewport_ShadePlotType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbViewport__ShadePlotType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbViewport_ShadePlotType rxvalue_cast_TD_DbCoreIntegrated_OdDbViewport__ShadePlotType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbViewport__ShadePlotType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbViewport_ShadePlotType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbViewport__ShadePlotType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbViewport__ShadePlotType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbHatch__HatchObjectType(OdDbHatch_HatchObjectType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbHatch__HatchObjectType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbHatch_HatchObjectType rxvalue_cast_TD_DbCoreIntegrated_OdDbHatch__HatchObjectType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbHatch__HatchObjectType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbHatch_HatchObjectType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbHatch__HatchObjectType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbHatch__HatchObjectType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbLight__GlyphDisplayType(OdDbLight_GlyphDisplayType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbLight__GlyphDisplayType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbLight_GlyphDisplayType rxvalue_cast_TD_DbCoreIntegrated_OdDbLight__GlyphDisplayType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbLight__GlyphDisplayType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbLight_GlyphDisplayType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbLight__GlyphDisplayType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbLight__GlyphDisplayType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbRenderGlobal__Procedure(OdDbRenderGlobal_Procedure from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbRenderGlobal__Procedure((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbRenderGlobal_Procedure rxvalue_cast_TD_DbCoreIntegrated_OdDbRenderGlobal__Procedure(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbRenderGlobal__Procedure(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbRenderGlobal_Procedure)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbRenderGlobal__Procedure()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbRenderGlobal__Procedure();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__PlotType(OdDbPlotSettings_PlotType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__PlotType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbPlotSettings_PlotType rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__PlotType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__PlotType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPlotSettings_PlotType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__PlotType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__PlotType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__DuplicateRecordCloning(OdDb_DuplicateRecordCloning from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__DuplicateRecordCloning((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_DuplicateRecordCloning rxvalue_cast_TD_DbCoreIntegrated_OdDb__DuplicateRecordCloning(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__DuplicateRecordCloning(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_DuplicateRecordCloning)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__DuplicateRecordCloning()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__DuplicateRecordCloning();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbHatch__HatchPatternType(OdDbHatch_HatchPatternType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbHatch__HatchPatternType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbHatch_HatchPatternType rxvalue_cast_TD_DbCoreIntegrated_OdDbHatch__HatchPatternType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbHatch__HatchPatternType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbHatch_HatchPatternType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbHatch__HatchPatternType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbHatch__HatchPatternType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__ContentType(OdDbMLeaderStyle_ContentType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__ContentType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMLeaderStyle_ContentType rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__ContentType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__ContentType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_ContentType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__ContentType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__ContentType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbLoftOptions__NormalOption(OdDbLoftOptions_NormalOption from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbLoftOptions__NormalOption((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbLoftOptions_NormalOption rxvalue_cast_TD_DbCoreIntegrated_OdDbLoftOptions__NormalOption(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbLoftOptions__NormalOption(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbLoftOptions_NormalOption)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbLoftOptions__NormalOption()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbLoftOptions__NormalOption();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__LeaderType(OdDbMLeaderStyle_LeaderType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__LeaderType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMLeaderStyle_LeaderType rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__LeaderType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__LeaderType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_LeaderType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__LeaderType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__LeaderType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbHatch__GradientPatternType(OdDbHatch_GradientPatternType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbHatch__GradientPatternType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbHatch_GradientPatternType rxvalue_cast_TD_DbCoreIntegrated_OdDbHatch__GradientPatternType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbHatch__GradientPatternType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbHatch_GradientPatternType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbHatch__GradientPatternType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbHatch__GradientPatternType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbRenderGlobal__Destination(OdDbRenderGlobal_Destination from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbRenderGlobal__Destination((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbRenderGlobal_Destination rxvalue_cast_TD_DbCoreIntegrated_OdDbRenderGlobal__Destination(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbRenderGlobal__Destination(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbRenderGlobal_Destination)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbRenderGlobal__Destination()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbRenderGlobal__Destination();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAngleType(OdDbMLeaderStyle_TextAngleType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAngleType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMLeaderStyle_TextAngleType rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAngleType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAngleType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_TextAngleType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAngleType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAngleType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDb__TableBreakFlowDirection(OdDb_TableBreakFlowDirection from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDb__TableBreakFlowDirection((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDb_TableBreakFlowDirection rxvalue_cast_TD_DbCoreIntegrated_OdDb__TableBreakFlowDirection(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDb__TableBreakFlowDirection(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDb_TableBreakFlowDirection)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDb__TableBreakFlowDirection()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDb__TableBreakFlowDirection();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__PlotRotation(OdDbPlotSettings_PlotRotation from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__PlotRotation((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbPlotSettings_PlotRotation rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__PlotRotation(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__PlotRotation(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPlotSettings_PlotRotation)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__PlotRotation()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__PlotRotation();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbViewport__StandardScaleType(OdDbViewport_StandardScaleType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbViewport__StandardScaleType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbViewport_StandardScaleType rxvalue_cast_TD_DbCoreIntegrated_OdDbViewport__StandardScaleType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbViewport__StandardScaleType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbViewport_StandardScaleType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbViewport__StandardScaleType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbViewport__StandardScaleType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__StdScaleType(OdDbPlotSettings_StdScaleType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__StdScaleType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbPlotSettings_StdScaleType rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__StdScaleType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__StdScaleType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPlotSettings_StdScaleType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__StdScaleType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__StdScaleType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotType(OdDbPlotSettings_ShadePlotType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbPlotSettings_ShadePlotType rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPlotSettings_ShadePlotType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__PlotPaperUnits(OdDbPlotSettings_PlotPaperUnits from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__PlotPaperUnits((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbPlotSettings_PlotPaperUnits rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__PlotPaperUnits(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__PlotPaperUnits(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPlotSettings_PlotPaperUnits)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__PlotPaperUnits()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__PlotPaperUnits();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__SegmentAngleType(OdDbMLeaderStyle_SegmentAngleType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__SegmentAngleType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMLeaderStyle_SegmentAngleType rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__SegmentAngleType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__SegmentAngleType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_SegmentAngleType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__SegmentAngleType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__SegmentAngleType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbBlockTableRecord__BlockScaling(OdDbBlockTableRecord_BlockScaling from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbBlockTableRecord__BlockScaling((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbBlockTableRecord_BlockScaling rxvalue_cast_TD_DbCoreIntegrated_OdDbBlockTableRecord__BlockScaling(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbBlockTableRecord__BlockScaling(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbBlockTableRecord_BlockScaling)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbBlockTableRecord__BlockScaling()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbBlockTableRecord__BlockScaling();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotResLevel(OdDbPlotSettings_ShadePlotResLevel from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotResLevel((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbPlotSettings_ShadePlotResLevel rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotResLevel(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotResLevel(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbPlotSettings_ShadePlotResLevel)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotResLevel()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbPlotSettings__ShadePlotResLevel();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbLight__PhysicalIntensityMethod(OdDbLight_PhysicalIntensityMethod from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbLight__PhysicalIntensityMethod((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbLight_PhysicalIntensityMethod rxvalue_cast_TD_DbCoreIntegrated_OdDbLight__PhysicalIntensityMethod(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbLight__PhysicalIntensityMethod(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbLight_PhysicalIntensityMethod)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbLight__PhysicalIntensityMethod()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbLight__PhysicalIntensityMethod();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentType(OdDbMLeaderStyle_TextAttachmentType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMLeaderStyle_TextAttachmentType rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_TextAttachmentType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAlignmentType(OdDbMLeaderStyle_TextAlignmentType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAlignmentType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMLeaderStyle_TextAlignmentType rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAlignmentType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAlignmentType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_TextAlignmentType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAlignmentType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAlignmentType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawLeaderOrderType(OdDbMLeaderStyle_DrawLeaderOrderType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawLeaderOrderType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMLeaderStyle_DrawLeaderOrderType rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawLeaderOrderType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawLeaderOrderType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_DrawLeaderOrderType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawLeaderOrderType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawLeaderOrderType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__BlockConnectionType(OdDbMLeaderStyle_BlockConnectionType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__BlockConnectionType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMLeaderStyle_BlockConnectionType rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__BlockConnectionType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__BlockConnectionType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_BlockConnectionType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__BlockConnectionType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__BlockConnectionType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawMLeaderOrderType(OdDbMLeaderStyle_DrawMLeaderOrderType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawMLeaderOrderType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMLeaderStyle_DrawMLeaderOrderType rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawMLeaderOrderType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawMLeaderOrderType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_DrawMLeaderOrderType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawMLeaderOrderType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__DrawMLeaderOrderType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbRapidRTRenderSettings__RenderTarget(OdDbRapidRTRenderSettings_RenderTarget from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbRapidRTRenderSettings__RenderTarget((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbRapidRTRenderSettings_RenderTarget rxvalue_cast_TD_DbCoreIntegrated_OdDbRapidRTRenderSettings__RenderTarget(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbRapidRTRenderSettings__RenderTarget(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbRapidRTRenderSettings_RenderTarget)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbRapidRTRenderSettings__RenderTarget()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbRapidRTRenderSettings__RenderTarget();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbGeoPositionMarker__OdTextAlignmentType(OdDbGeoPositionMarker_OdTextAlignmentType from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbGeoPositionMarker__OdTextAlignmentType((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbGeoPositionMarker_OdTextAlignmentType rxvalue_cast_TD_DbCoreIntegrated_OdDbGeoPositionMarker__OdTextAlignmentType(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbGeoPositionMarker__OdTextAlignmentType(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbGeoPositionMarker_OdTextAlignmentType)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbGeoPositionMarker__OdTextAlignmentType()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbGeoPositionMarker__OdTextAlignmentType();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentDirection(OdDbMLeaderStyle_TextAttachmentDirection from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentDirection((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMLeaderStyle_TextAttachmentDirection rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentDirection(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentDirection(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMLeaderStyle_TextAttachmentDirection)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentDirection()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMLeaderStyle__TextAttachmentDirection();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_DbCoreIntegrated_OdDbMentalRayRenderSettings__ShadowSamplingMultiplier(OdDbMentalRayRenderSettings_ShadowSamplingMultiplier from)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_create_TD_DbCoreIntegrated_OdDbMentalRayRenderSettings__ShadowSamplingMultiplier((int)from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbMentalRayRenderSettings_ShadowSamplingMultiplier rxvalue_cast_TD_DbCoreIntegrated_OdDbMentalRayRenderSettings__ShadowSamplingMultiplier(OdRxValue from)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_rxvalue_cast_TD_DbCoreIntegrated_OdDbMentalRayRenderSettings__ShadowSamplingMultiplier(OdRxValue.getCPtr(from));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMentalRayRenderSettings_ShadowSamplingMultiplier)result;
	}

	private static string getNativeTypeName_TD_DbCoreIntegrated_OdDbMentalRayRenderSettings__ShadowSamplingMultiplier()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_DbCoreIntegrated_getNativeTypeName_TD_DbCoreIntegrated_OdDbMentalRayRenderSettings__ShadowSamplingMultiplier();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxValueHelpers_TD_DbCoreIntegrated()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdRxValueHelpers_TD_DbCoreIntegrated(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
