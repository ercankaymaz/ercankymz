using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Prc.OdPrcModule;

public class PrcExportVisualStyleParams : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public PrcExportColorComponentBehavior m_AmbientColorBehavior
	{
		get
		{
			int result = OdPrcModule_GlobalsPINVOKE.PrcExportVisualStyleParams_m_AmbientColorBehavior_get(swigCPtr);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (PrcExportColorComponentBehavior)result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.PrcExportVisualStyleParams_m_AmbientColorBehavior_set(swigCPtr, (int)value);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public PrcExportVisualStyleParams(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(PrcExportVisualStyleParams obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~PrcExportVisualStyleParams()
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
					OdPrcModule_GlobalsPINVOKE.delete_PrcExportVisualStyleParams(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public PrcExportVisualStyleParams()
		: this(OdPrcModule_GlobalsPINVOKE.new_PrcExportVisualStyleParams(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
