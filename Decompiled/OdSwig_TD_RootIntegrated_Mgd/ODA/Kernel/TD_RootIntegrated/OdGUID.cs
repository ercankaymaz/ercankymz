using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGUID : IDisposable
{
	public class StringFormat : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public StringFormat(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(StringFormat obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~StringFormat()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGUID_StringFormat(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public StringFormat()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGUID_StringFormat(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGUID kNull
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGUID_kNull_get();
			OdGUID result = ((intPtr == IntPtr.Zero) ? null : new OdGUID(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGUID(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGUID obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGUID()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGUID(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGUID()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGUID__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGUID(OdGUID other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGUID__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGUID(uint arg0, ushort arg1, ushort arg2, byte arg3, byte arg4, byte arg5, byte arg6, byte arg7, byte arg8, byte arg9, byte arg10)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGUID__SWIG_2(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGUID(string value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGUID__SWIG_3(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGUID Assign(OdGUID other)
	{
		OdGUID result = new OdGUID(TD_RootIntegrated_GlobalsPINVOKE.OdGUID_Assign__SWIG_0(swigCPtr, getCPtr(other)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGUID Assign(string other)
	{
		OdGUID result = new OdGUID(TD_RootIntegrated_GlobalsPINVOKE.OdGUID_Assign__SWIG_1(swigCPtr, other), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdGUID arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGUID_IsEqual(swigCPtr, getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGUID arg0)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGUID_IsNotEqual(swigCPtr, getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string toString(OdGUID_StringFormat_Enum format)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGUID_toString__SWIG_0(swigCPtr, (int)format);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string toString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGUID_toString__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
