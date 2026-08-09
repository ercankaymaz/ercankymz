using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxValue : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxValue(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxValue obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRxValue()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxValue(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdRxValue Assign(OdRxValue rhs)
	{
		return new OdRxValue(TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_Assign(swigCPtr, getCPtr(rhs)), cMemoryOwn: false);
	}

	public OdRxValueType type()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_type(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxValue empty()
	{
		return new OdRxValue(TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_empty(), cMemoryOwn: false);
	}

	public bool isVaries()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_isVaries(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxValue varies()
	{
		return new OdRxValue(TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_varies(), cMemoryOwn: false);
	}

	public string toString(OdRxValueType_StringFormat format)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_toString__SWIG_0(swigCPtr, (int)format);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string toString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_toString__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdRxValue value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_IsEqual(swigCPtr, getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdRxValue value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_IsNotEqual(swigCPtr, getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string typePath()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_typePath(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxValue unbox(OdRxObject pO)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_unbox__SWIG_0(OdRxObject.getCPtr(pO));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxEnumTag getEnumTag()
	{
		OdRxEnumTag rXObject = Helpers.GetRXObject<OdRxEnumTag>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_getEnumTag(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public uint serializeOut(IntPtr pBytes, out uint maxBytesToWrite)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_serializeOut(swigCPtr, pBytes, out maxBytesToWrite);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint serializeIn(IntPtr pBytes, uint maxBytesToRead)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_serializeIn(swigCPtr, pBytes, maxBytesToRead);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxValue create()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_create__SWIG_0();
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxValue create(OdRxValue from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_create__SWIG_1(getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdRxValue create(OdRxValueType type, OdRxValue value)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValue_create__SWIG_2(OdRxValueType.getCPtr(type), getCPtr(value));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
