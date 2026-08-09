using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDb3dSolidPyramidParams : OdDb3dSolidGeomParams
{
	private object locker = new object();

	private HandleRef swigCPtr;

	public double height
	{
		get
		{
			double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidPyramidParams_height_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidPyramidParams_height_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public int sides
	{
		get
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidPyramidParams_sides_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidPyramidParams_sides_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double radius
	{
		get
		{
			double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidPyramidParams_radius_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidPyramidParams_radius_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public double topRadius
	{
		get
		{
			double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidPyramidParams_topRadius_get(swigCPtr);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidPyramidParams_topRadius_set(swigCPtr, value);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDb3dSolidPyramidParams(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidPyramidParams_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDb3dSolidPyramidParams obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDb3dSolidPyramidParams(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public bool isTruncated()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDb3dSolidPyramidParams_isTruncated(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDb3dSolidPyramidParams()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDb3dSolidPyramidParams(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
