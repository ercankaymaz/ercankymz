using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxValueTypeDesc_TD_RootIntegrated : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxValueTypeDesc_TD_RootIntegrated(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxValueTypeDesc_TD_RootIntegrated obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRxValueTypeDesc_TD_RootIntegrated()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxValueTypeDesc_TD_RootIntegrated(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static OdRxValueType value_Desc_int()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_int(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_float()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_float(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_bool()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_bool(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_short()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_short(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_char()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_char(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_long()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_long(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_double()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_double(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdString()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdString(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdIntArray()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdIntArray(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_signed_char()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_signed_char(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_long_long()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_long_long(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdDbHandle()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdDbHandle(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_char()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_char(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_int()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_int(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_bool()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_bool(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdRxClass__p()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdRxClass__p(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_unsigned_char()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_unsigned_char(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdUInt64Array()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdUInt64Array(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdAnsiString()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdAnsiString(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_unsigned_int()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_unsigned_int(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdRxObjectPtr()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdRxObjectPtr(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdInt64Array()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdInt64Array(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_unsigned_long()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_unsigned_long(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_long()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_long(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_short()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_short(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_const_char__p()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_const_char__p(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_unsigned_short()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_unsigned_short(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_double()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_double(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_float()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_float(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_const_OdChar__p()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_const_OdChar__p(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdGeDoubleArray()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdGeDoubleArray(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdCmTransparency()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdCmTransparency(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_unsigned_long_long()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_unsigned_long_long(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_OdString()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_OdString(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_OdRxValue()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_OdRxValue(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_OdIntArray()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_OdIntArray(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_long_long()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_long_long(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_OdAnsiString()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_OdAnsiString(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_unsigned_int()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_unsigned_int(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_signed_char()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_signed_char(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_OdArray_int()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_OdArray_int(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_unsigned_long()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_unsigned_long(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_unsigned_char()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_unsigned_char(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_unsigned_short()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_unsigned_short(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_OdGeDoubleArray()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_OdGeDoubleArray(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_OdArray_double()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_OdArray_double(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxValueType value_Desc_OdArray_unsigned_long_long()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueTypeDesc_TD_RootIntegrated_value_Desc_OdArray_unsigned_long_long(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxValueTypeDesc_TD_RootIntegrated()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxValueTypeDesc_TD_RootIntegrated(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
