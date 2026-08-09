using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiFillData : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public LineWeight m_lweight
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_lweight_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (LineWeight)result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_lweight_set(swigCPtr, (int)value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGiFillType m_fillType
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_fillType_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdGiFillType)result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_fillType_set(swigCPtr, (int)value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGeVector3d m_fillNormal
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_fillNormal_get(swigCPtr);
			OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_fillNormal_set(swigCPtr, OdGeVector3d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGeVector3d m_pFillNormal
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_pFillNormal_get(swigCPtr);
			OdGeVector3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeVector3d(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_pFillNormal_set(swigCPtr, OdGeVector3d.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGiSubEntityTraits m_pTraits
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_pTraits_get(swigCPtr);
			OdGiSubEntityTraits result = ((intPtr == IntPtr.Zero) ? null : new OdGiSubEntityTraits(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_pTraits_set(swigCPtr, OdGiSubEntityTraits.getCPtr(value));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGiConveyorContext m_pDrawCtx
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_pDrawCtx_get(swigCPtr);
			OdGiConveyorContext_Internal result = ((intPtr == IntPtr.Zero) ? null : new OdGiConveyorContext_Internal(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_m_pDrawCtx_set(swigCPtr, value.GetInterfaceCPtr());
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiFillData(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiFillData obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiFillData()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiFillData(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiFillData(OdGiConveyorContext pDrawCtx, OdGiSubEntityTraits pTraits, LineWeight lweight, OdGiFillType fillType)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFillData__SWIG_0(pDrawCtx.GetInterfaceCPtr(), OdGiSubEntityTraits.getCPtr(pTraits), (int)lweight, (int)fillType), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiFillData(OdGiConveyorContext pDrawCtx, OdGiSubEntityTraits pTraits, LineWeight lweight)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFillData__SWIG_1(pDrawCtx.GetInterfaceCPtr(), OdGiSubEntityTraits.getCPtr(pTraits), (int)lweight), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiFillData(OdGiConveyorContext pDrawCtx, OdGiSubEntityTraits pTraits)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFillData__SWIG_2(pDrawCtx.GetInterfaceCPtr(), OdGiSubEntityTraits.getCPtr(pTraits)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(LineWeight lweight, OdGiFillType fillType, OdGeVector3d fillNormal)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillData_set(swigCPtr, (int)lweight, (int)fillType, OdGeVector3d.getCPtr(fillNormal));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
