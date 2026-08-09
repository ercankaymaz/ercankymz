using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcViewNode : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdPrcObjectId view
	{
		get
		{
			IntPtr intPtr = OdPrcModule_GlobalsPINVOKE.OdPrcViewNode_view_get(swigCPtr);
			OdPrcObjectId result = ((intPtr == IntPtr.Zero) ? null : new OdPrcObjectId(intPtr, cMemoryOwn: false));
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcViewNode_view_set(swigCPtr, OdPrcObjectId.getCPtr(value));
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGeMatrix3d matrix
	{
		get
		{
			IntPtr intPtr = OdPrcModule_GlobalsPINVOKE.OdPrcViewNode_matrix_get(swigCPtr);
			OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcViewNode_matrix_set(swigCPtr, OdGeMatrix3d.getCPtr(value));
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdPrcObjectIdArray path
	{
		get
		{
			OdPrcObjectIdArray result = new OdPrcObjectIdArray(OdPrcModule_GlobalsPINVOKE.OdPrcViewNode_path_get(swigCPtr), cMemoryOwn: false);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcViewNode_path_set(swigCPtr, OdPrcObjectIdArray.getCPtr(value).Handle);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcViewNode(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcViewNode obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcViewNode()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcViewNode(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcViewNode()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcViewNode(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
