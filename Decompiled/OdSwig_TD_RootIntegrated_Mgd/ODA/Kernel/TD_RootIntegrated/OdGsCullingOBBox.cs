using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsCullingOBBox : OdGsCullingPrimitive
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsCullingOBBox(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingOBBox_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsCullingOBBox obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsCullingOBBox(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGsCullingOBBox()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingOBBox__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingOBBox(OdGePoint3d base_, OdGeVector3d xAxis, OdGeVector3d yAxis, OdGeVector3d zAxis)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingOBBox__SWIG_1(OdGePoint3d.getCPtr(base_), OdGeVector3d.getCPtr(xAxis), OdGeVector3d.getCPtr(yAxis), OdGeVector3d.getCPtr(zAxis)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingOBBox(OdGeBoundBlock3d bb)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingOBBox__SWIG_2(OdGeBoundBlock3d.getCPtr(bb)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingOBBox(OdGsCullingOBBox obb)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingOBBox__SWIG_3(getCPtr(obb)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingOBBox Assign(OdGeBoundBlock3d bb)
	{
		OdGsCullingOBBox result = new OdGsCullingOBBox(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingOBBox_Assign__SWIG_0(swigCPtr, OdGeBoundBlock3d.getCPtr(bb)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsCullingOBBox Assign(OdGsCullingOBBox obb)
	{
		OdGsCullingOBBox result = new OdGsCullingOBBox(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingOBBox_Assign__SWIG_1(swigCPtr, getCPtr(obb)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGsCullingPrimitive_PrimitiveType primitiveType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingOBBox_primitiveType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsCullingPrimitive_PrimitiveType)result;
	}
}
