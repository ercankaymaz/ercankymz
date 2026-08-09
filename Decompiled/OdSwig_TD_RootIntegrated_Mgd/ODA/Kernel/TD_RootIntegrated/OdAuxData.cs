using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdAuxData : IDisposable
{
	public class Data : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public uint _n
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdAuxData_Data__n_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdAuxData_Data__n_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public IntPtr _p
		{
			get
			{
				IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdAuxData_Data__p_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdAuxData_Data__p_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Data(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Data obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Data()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdAuxData_Data(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public Data()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdAuxData_Data(), cMemoryOwn: true)
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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdAuxData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdAuxData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdAuxData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdAuxData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdAuxData()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdAuxData(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public IntPtr getPtr()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdAuxData_getPtr__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
