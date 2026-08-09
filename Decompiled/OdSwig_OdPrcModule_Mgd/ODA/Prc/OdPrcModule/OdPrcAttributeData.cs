using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Prc.OdPrcModule;

public class OdPrcAttributeData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcAttributeData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcAttributeData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcAttributeData()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcAttributeData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcAttributeData()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcAttributeData(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcAttributeData_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcAttributeData_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcAttributeArray attributes()
	{
		OdPrcAttributeArray result = new OdPrcAttributeArray(OdPrcModule_GlobalsPINVOKE.OdPrcAttributeData_attributes__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
