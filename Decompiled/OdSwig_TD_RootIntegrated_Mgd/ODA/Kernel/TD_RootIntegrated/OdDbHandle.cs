using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbHandle : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbHandle(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbHandle obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbHandle()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbHandle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static explicit operator ulong(OdDbHandle h)
	{
		return h.ToUInt64();
	}

	public override string ToString()
	{
		if (swigCPtr.Handle == IntPtr.Zero)
		{
			return "Empty";
		}
		return ToUInt64().ToString("X");
	}

	public OdDbHandle()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbHandle__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbHandle(OdDbHandle value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbHandle__SWIG_1(getCPtr(value)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbHandle(ulong value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbHandle__SWIG_2(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbHandle(string value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbHandle__SWIG_3(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbHandle(int value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbHandle__SWIG_4(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbHandle Assign(ulong value)
	{
		OdDbHandle result = new OdDbHandle(TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_Assign__SWIG_0(swigCPtr, value), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbHandle Assign(string value)
	{
		OdDbHandle result = new OdDbHandle(TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_Assign__SWIG_1(swigCPtr, value), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbHandle Assign(OdDbHandle value)
	{
		OdDbHandle result = new OdDbHandle(TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_Assign__SWIG_2(swigCPtr, getCPtr(value)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbHandle Assign(int value)
	{
		OdDbHandle result = new OdDbHandle(TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_Assign__SWIG_3(swigCPtr, value), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ulong ToUInt64()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_ToUInt64(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string ascii()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_ascii(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isNull()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_isNull(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(ulong value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_IsEqual(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(ulong value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_IsNotEqual(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbHandle Add(long value)
	{
		OdDbHandle result = new OdDbHandle(TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_Add__SWIG_0(swigCPtr, value), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void bytes(ref byte[] bytes)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(bytes);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdDbHandle_bytes(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			bytes = Helpers.UnMarshalbyteFixedArray(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}
	}
}
