using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxValueHelpers_TD_RootIntegrated : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxValueHelpers_TD_RootIntegrated(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxValueHelpers_TD_RootIntegrated obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRxValueHelpers_TD_RootIntegrated()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxValueHelpers_TD_RootIntegrated(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_int(int from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_int(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static int rxvalue_cast_TD_RootIntegrated_int(OdRxValue from)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_int(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_int()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_int();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_float(float from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_float(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static float rxvalue_cast_TD_RootIntegrated_float(OdRxValue from)
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_float(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_float()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_float();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_bool(bool from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_bool(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static bool rxvalue_cast_TD_RootIntegrated_bool(OdRxValue from)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_bool(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_bool()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_bool();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_short(short from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_short(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static short rxvalue_cast_TD_RootIntegrated_short(OdRxValue from)
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_short(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_short()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_short();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_char(char from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_char(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static char rxvalue_cast_TD_RootIntegrated_char(OdRxValue from)
	{
		char result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_char(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_char()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_char();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_long(int from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_long(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static int rxvalue_cast_TD_RootIntegrated_long(OdRxValue from)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_long(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_long()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_long();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_double(double from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_double(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static double rxvalue_cast_TD_RootIntegrated_double(OdRxValue from)
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_double(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_double()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_double();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdString(string from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdString(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string rxvalue_cast_TD_RootIntegrated_OdString(OdRxValue from)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdString(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdString();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdIntArray(OdIntArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdIntArray(OdIntArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdIntArray rxvalue_cast_TD_RootIntegrated_OdIntArray(OdRxValue from)
	{
		OdIntArray result = new OdIntArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdIntArray(OdRxValue.getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdIntArray()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdIntArray();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_signed_char(sbyte from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_signed_char(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static sbyte rxvalue_cast_TD_RootIntegrated_signed_char(OdRxValue from)
	{
		sbyte result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_signed_char(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_signed_char()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_signed_char();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_long_long(long from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_long_long(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static long rxvalue_cast_TD_RootIntegrated_long_long(OdRxValue from)
	{
		long result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_long_long(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_long_long()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_long_long();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdDbHandle(OdDbHandle from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdDbHandle(OdDbHandle.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDbHandle rxvalue_cast_TD_RootIntegrated_OdDbHandle(OdRxValue from)
	{
		OdDbHandle result = new OdDbHandle(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdDbHandle(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdDbHandle()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdDbHandle();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_char(OdArray_char_OdObjectsAllocator from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_char(OdArray_char_OdObjectsAllocator.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdArray_char_OdObjectsAllocator rxvalue_cast_TD_RootIntegrated_OdArray_char(OdRxValue from)
	{
		OdArray_char_OdObjectsAllocator result = new OdArray_char_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_char(OdRxValue.getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_char()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_char();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_int(OdArrayInt from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_int(OdArrayInt.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdArrayInt rxvalue_cast_TD_RootIntegrated_OdArray_int(OdRxValue from)
	{
		OdArrayInt result = new OdArrayInt(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_int(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_int()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_int();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_bool(OdBoolValuesArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_bool(OdBoolValuesArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdBoolValuesArray rxvalue_cast_TD_RootIntegrated_OdArray_bool(OdRxValue from)
	{
		OdBoolValuesArray result = new OdBoolValuesArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_bool(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_bool()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_bool();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdRxClass__p(OdRxClass from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdRxClass__p(OdRxClass.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxClass rxvalue_cast_TD_RootIntegrated_OdRxClass__p(OdRxValue from)
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdRxClass__p(OdRxValue.getCPtr(from)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdRxClass__p()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdRxClass__p();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_unsigned_char(byte from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_unsigned_char(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static byte rxvalue_cast_TD_RootIntegrated_unsigned_char(OdRxValue from)
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_unsigned_char(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_unsigned_char()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_unsigned_char();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdUInt64Array(OdUInt64Array from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdUInt64Array(OdUInt64Array.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdUInt64Array rxvalue_cast_TD_RootIntegrated_OdUInt64Array(OdRxValue from)
	{
		OdUInt64Array result = new OdUInt64Array(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdUInt64Array(OdRxValue.getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdUInt64Array()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdUInt64Array();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdAnsiString(string from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdAnsiString(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string rxvalue_cast_TD_RootIntegrated_OdAnsiString(OdRxValue from)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdAnsiString(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdAnsiString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdAnsiString();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_unsigned_int(uint from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_unsigned_int(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static uint rxvalue_cast_TD_RootIntegrated_unsigned_int(OdRxValue from)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_unsigned_int(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_unsigned_int()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_unsigned_int();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdRxObjectPtr(OdRxObject from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdRxObjectPtr(OdRxObject.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxObject rxvalue_cast_TD_RootIntegrated_OdRxObjectPtr(OdRxValue from)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdRxObjectPtr(OdRxValue.getCPtr(from)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdRxObjectPtr()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdRxObjectPtr();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdInt64Array(OdInt64Array from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdInt64Array(OdInt64Array.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdInt64Array rxvalue_cast_TD_RootIntegrated_OdInt64Array(OdRxValue from)
	{
		OdInt64Array result = new OdInt64Array(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdInt64Array(OdRxValue.getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdInt64Array()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdInt64Array();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_unsigned_long(uint from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_unsigned_long(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static uint rxvalue_cast_TD_RootIntegrated_unsigned_long(OdRxValue from)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_unsigned_long(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_unsigned_long()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_unsigned_long();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_long(OdLongArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_long(OdLongArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdLongArray rxvalue_cast_TD_RootIntegrated_OdArray_long(OdRxValue from)
	{
		OdLongArray result = new OdLongArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_long(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_long()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_long();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_short(OdShortArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_short(OdShortArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdShortArray rxvalue_cast_TD_RootIntegrated_OdArray_short(OdRxValue from)
	{
		OdShortArray result = new OdShortArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_short(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_short()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_short();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_const_char__p(string from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_const_char__p(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string rxvalue_cast_TD_RootIntegrated_const_char__p(OdRxValue from)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_const_char__p(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_const_char__p()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_const_char__p();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_unsigned_short(ushort from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_unsigned_short(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static ushort rxvalue_cast_TD_RootIntegrated_unsigned_short(OdRxValue from)
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_unsigned_short(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_unsigned_short()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_unsigned_short();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_double(OdDoubleValuesArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_double(OdDoubleValuesArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDoubleValuesArray rxvalue_cast_TD_RootIntegrated_OdArray_double(OdRxValue from)
	{
		OdDoubleValuesArray result = new OdDoubleValuesArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_double(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_double()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_double();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_float(OdFloatValuesArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_float(OdFloatValuesArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdFloatValuesArray rxvalue_cast_TD_RootIntegrated_OdArray_float(OdRxValue from)
	{
		OdFloatValuesArray result = new OdFloatValuesArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_float(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_float()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_float();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_const_OdChar__p(string from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_const_OdChar__p(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string rxvalue_cast_TD_RootIntegrated_const_OdChar__p(OdRxValue from)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_const_OdChar__p(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_const_OdChar__p()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_const_OdChar__p();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdGeDoubleArray(OdDoubleArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdGeDoubleArray(OdDoubleArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDoubleArray rxvalue_cast_TD_RootIntegrated_OdGeDoubleArray(OdRxValue from)
	{
		OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdGeDoubleArray(OdRxValue.getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdGeDoubleArray()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdGeDoubleArray();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdCmTransparency(OdCmTransparency from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdCmTransparency(OdCmTransparency.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdCmTransparency rxvalue_cast_TD_RootIntegrated_OdCmTransparency(OdRxValue from)
	{
		OdCmTransparency result = new OdCmTransparency(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdCmTransparency(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdCmTransparency()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdCmTransparency();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_unsigned_long_long(ulong from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_unsigned_long_long(from);
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static ulong rxvalue_cast_TD_RootIntegrated_unsigned_long_long(OdRxValue from)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_unsigned_long_long(OdRxValue.getCPtr(from));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_unsigned_long_long()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_unsigned_long_long();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_OdString(OdStringArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_OdString(OdStringArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdStringArray rxvalue_cast_TD_RootIntegrated_OdArray_OdString(OdRxValue from)
	{
		OdStringArray result = new OdStringArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_OdString(OdRxValue.getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_OdString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_OdString();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_OdRxValue(OdArray_OdRxValue_OdObjectsAllocator from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_OdRxValue(OdArray_OdRxValue_OdObjectsAllocator.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdArray_OdRxValue_OdObjectsAllocator rxvalue_cast_TD_RootIntegrated_OdArray_OdRxValue(OdRxValue from)
	{
		OdArray_OdRxValue_OdObjectsAllocator result = new OdArray_OdRxValue_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_OdRxValue(OdRxValue.getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_OdRxValue()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_OdRxValue();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_OdIntArray(OdArray_OdIntArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_OdIntArray(OdArray_OdIntArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdArray_OdIntArray rxvalue_cast_TD_RootIntegrated_OdArray_OdIntArray(OdRxValue from)
	{
		OdArray_OdIntArray result = new OdArray_OdIntArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_OdIntArray(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_OdIntArray()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_OdIntArray();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_long_long(OdLongLongArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_long_long(OdLongLongArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdLongLongArray rxvalue_cast_TD_RootIntegrated_OdArray_long_long(OdRxValue from)
	{
		OdLongLongArray result = new OdLongLongArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_long_long(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_long_long()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_long_long();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_OdAnsiString(OdAnsiStringArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_OdAnsiString(OdAnsiStringArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdAnsiStringArray rxvalue_cast_TD_RootIntegrated_OdArray_OdAnsiString(OdRxValue from)
	{
		OdAnsiStringArray result = new OdAnsiStringArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_OdAnsiString(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_OdAnsiString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_OdAnsiString();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_unsigned_int(OdUnsignedIntArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_unsigned_int(OdUnsignedIntArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdUnsignedIntArray rxvalue_cast_TD_RootIntegrated_OdArray_unsigned_int(OdRxValue from)
	{
		OdUnsignedIntArray result = new OdUnsignedIntArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_unsigned_int(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_unsigned_int()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_unsigned_int();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_signed_char(OdArray_OdInt8_OdObjectsAllocator from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_signed_char(OdArray_OdInt8_OdObjectsAllocator.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdArray_OdInt8_OdObjectsAllocator rxvalue_cast_TD_RootIntegrated_OdArray_signed_char(OdRxValue from)
	{
		OdArray_OdInt8_OdObjectsAllocator result = new OdArray_OdInt8_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_signed_char(OdRxValue.getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_signed_char()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_signed_char();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_OdArray_int(OdArrayInt2d from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_OdArray_int(OdArrayInt2d.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdArrayInt2d rxvalue_cast_TD_RootIntegrated_OdArray_OdArray_int(OdRxValue from)
	{
		OdArrayInt2d result = new OdArrayInt2d(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_OdArray_int(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_OdArray_int()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_OdArray_int();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_unsigned_long(OdUInt32ValuesArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_unsigned_long(OdUInt32ValuesArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdUInt32ValuesArray rxvalue_cast_TD_RootIntegrated_OdArray_unsigned_long(OdRxValue from)
	{
		OdUInt32ValuesArray result = new OdUInt32ValuesArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_unsigned_long(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_unsigned_long()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_unsigned_long();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_unsigned_char(OdArray_OdUInt8_OdObjectsAllocator from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_unsigned_char(OdArray_OdUInt8_OdObjectsAllocator.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdArray_OdUInt8_OdObjectsAllocator rxvalue_cast_TD_RootIntegrated_OdArray_unsigned_char(OdRxValue from)
	{
		OdArray_OdUInt8_OdObjectsAllocator result = new OdArray_OdUInt8_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_unsigned_char(OdRxValue.getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_unsigned_char()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_unsigned_char();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_unsigned_short(OdUInt16ValuesArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_unsigned_short(OdUInt16ValuesArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdUInt16ValuesArray rxvalue_cast_TD_RootIntegrated_OdArray_unsigned_short(OdRxValue from)
	{
		OdUInt16ValuesArray result = new OdUInt16ValuesArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_unsigned_short(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_unsigned_short()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_unsigned_short();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_OdGeDoubleArray(OdArray_OdDoubleArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_OdGeDoubleArray(OdArray_OdDoubleArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdArray_OdDoubleArray rxvalue_cast_TD_RootIntegrated_OdArray_OdGeDoubleArray(OdRxValue from)
	{
		OdArray_OdDoubleArray result = new OdArray_OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_OdGeDoubleArray(OdRxValue.getCPtr(from)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_OdGeDoubleArray()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_OdGeDoubleArray();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_OdArray_double(OdDoubleValuesArray2d from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_OdArray_double(OdDoubleValuesArray2d.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdDoubleValuesArray2d rxvalue_cast_TD_RootIntegrated_OdArray_OdArray_double(OdRxValue from)
	{
		OdDoubleValuesArray2d result = new OdDoubleValuesArray2d(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_OdArray_double(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_OdArray_double()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_OdArray_double();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdRxValue rxvalue_create_TD_RootIntegrated_OdArray_unsigned_long_long(OdUnsignedLongLongArray from)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_create_TD_RootIntegrated_OdArray_unsigned_long_long(OdUnsignedLongLongArray.getCPtr(from));
		OdRxValue result = ((intPtr == IntPtr.Zero) ? null : new OdRxValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static OdUnsignedLongLongArray rxvalue_cast_TD_RootIntegrated_OdArray_unsigned_long_long(OdRxValue from)
	{
		OdUnsignedLongLongArray result = new OdUnsignedLongLongArray(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_rxvalue_cast_TD_RootIntegrated_OdArray_unsigned_long_long(OdRxValue.getCPtr(from)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private static string getNativeTypeName_TD_RootIntegrated_OdArray_unsigned_long_long()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueHelpers_TD_RootIntegrated_getNativeTypeName_TD_RootIntegrated_OdArray_unsigned_long_long();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxValueHelpers_TD_RootIntegrated()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxValueHelpers_TD_RootIntegrated(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
