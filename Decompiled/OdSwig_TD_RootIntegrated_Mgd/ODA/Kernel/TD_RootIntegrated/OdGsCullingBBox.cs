using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsCullingBBox : OdGsCullingPrimitive
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsCullingBBox(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingBBox_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsCullingBBox obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsCullingBBox(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGsCullingBBox()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingBBox__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingBBox(OdGePoint3d min, OdGePoint3d max)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingBBox__SWIG_1(OdGePoint3d.getCPtr(min), OdGePoint3d.getCPtr(max)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingBBox(OdGeExtents3d ext)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingBBox__SWIG_2(OdGeExtents3d.getCPtr(ext)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingBBox(OdGsCullingBBox aabb)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingBBox__SWIG_3(getCPtr(aabb)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCullingBBox Assign(OdGeExtents3d ext)
	{
		OdGsCullingBBox result = new OdGsCullingBBox(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingBBox_Assign__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(ext)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsCullingBBox Assign(OdGsCullingBBox aabb)
	{
		OdGsCullingBBox result = new OdGsCullingBBox(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingBBox_Assign__SWIG_1(swigCPtr, getCPtr(aabb)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdGsCullingPrimitive_PrimitiveType primitiveType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingBBox_primitiveType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsCullingPrimitive_PrimitiveType)result;
	}
}
