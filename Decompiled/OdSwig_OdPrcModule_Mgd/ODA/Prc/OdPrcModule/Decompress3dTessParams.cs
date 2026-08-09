using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Prc.OdPrcModule;

public class Decompress3dTessParams : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public bool bStoreNormals
	{
		get
		{
			bool result = OdPrcModule_GlobalsPINVOKE.Decompress3dTessParams_bStoreNormals_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.Decompress3dTessParams_bStoreNormals_set(swigCPtr, value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool bOverwriteCreaseAngle
	{
		get
		{
			bool result = OdPrcModule_GlobalsPINVOKE.Decompress3dTessParams_bOverwriteCreaseAngle_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.Decompress3dTessParams_bOverwriteCreaseAngle_set(swigCPtr, value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double dCreaseAngle
	{
		get
		{
			double result = OdPrcModule_GlobalsPINVOKE.Decompress3dTessParams_dCreaseAngle_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.Decompress3dTessParams_dCreaseAngle_set(swigCPtr, value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public Decompress3dTessParams(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(Decompress3dTessParams obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~Decompress3dTessParams()
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
					OdPrcModule_GlobalsPINVOKE.delete_Decompress3dTessParams(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public Decompress3dTessParams()
		: this(OdPrcModule_GlobalsPINVOKE.new_Decompress3dTessParams(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
