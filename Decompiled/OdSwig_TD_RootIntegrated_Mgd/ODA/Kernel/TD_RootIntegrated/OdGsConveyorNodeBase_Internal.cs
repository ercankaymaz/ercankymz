using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsConveyorNodeBase_Internal : OdGiConveyorInput, OdGsConveyorNodeBase, OdGiConveyorOutput, IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsConveyorNodeBase_Internal(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsConveyorNodeBase_Internal obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsConveyorNodeBase_Internal()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsConveyorNodeBase_Internal(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGiConveyorInput.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGsConveyorNodeBase_Internal_OdGiConveyorInput_GetInterfaceCPtr(swigCPtr.Handle));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGsConveyorNodeBase.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGsConveyorNodeBase_Internal_OdGsConveyorNodeBase_GetInterfaceCPtr(swigCPtr.Handle));
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef OdGiConveyorOutput.GetInterfaceCPtr()
	{
		return new HandleRef(this, TD_RootIntegrated_GlobalsPINVOKE.OdGsConveyorNodeBase_Internal_OdGiConveyorOutput_GetInterfaceCPtr(swigCPtr.Handle));
	}

	public virtual void addSourceNode(OdGiConveyorOutput sourceNode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsConveyorNodeBase_Internal_addSourceNode(swigCPtr, sourceNode.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeSourceNode(OdGiConveyorOutput sourceNode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsConveyorNodeBase_Internal_removeSourceNode(swigCPtr, sourceNode.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDestGeometry(OdGiConveyorGeometry destGeometry)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsConveyorNodeBase_Internal_setDestGeometry(swigCPtr, destGeometry.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiConveyorGeometry destGeometry()
	{
		OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGsConveyorNodeBase_Internal_destGeometry(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void updateLink()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsConveyorNodeBase_Internal_updateLink__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void updateLink(OdGiConveyorGeometry pGeometry)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsConveyorNodeBase_Internal_updateLink__SWIG_1(swigCPtr, pGeometry.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiConveyorGeometry optionalGeometry()
	{
		OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGsConveyorNodeBase_Internal_optionalGeometry(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
