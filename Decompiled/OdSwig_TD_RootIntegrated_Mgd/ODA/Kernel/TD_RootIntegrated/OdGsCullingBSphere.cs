using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsCullingBSphere : OdGsCullingPrimitive
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsCullingBSphere(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingBSphere_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsCullingBSphere obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsCullingBSphere(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGsCullingBSphere()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingBSphere__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingBSphere(double radius, OdGePoint3d center)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingBSphere__SWIG_1(radius, OdGePoint3d.getCPtr(center)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingBSphere(OdGeSphere sphere)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingBSphere__SWIG_2(OdGeSphere.getCPtr(sphere)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingBSphere(OdGsCullingBSphere bsphere)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingBSphere__SWIG_3(getCPtr(bsphere)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingBSphere Assign(OdGeSphere sphere)
	{
		OdGsCullingBSphere result = new OdGsCullingBSphere(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingBSphere_Assign__SWIG_0(swigCPtr, OdGeSphere.getCPtr(sphere)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsCullingBSphere Assign(OdGsCullingBSphere bsphere)
	{
		OdGsCullingBSphere result = new OdGsCullingBSphere(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingBSphere_Assign__SWIG_1(swigCPtr, getCPtr(bsphere)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGsCullingPrimitive_PrimitiveType primitiveType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingBSphere_primitiveType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsCullingPrimitive_PrimitiveType)result;
	}
}
