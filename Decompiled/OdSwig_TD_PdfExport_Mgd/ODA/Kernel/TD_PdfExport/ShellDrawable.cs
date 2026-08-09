using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class ShellDrawable : OdGiDrawableImpl_OdGiDrawable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ShellDrawable(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_PdfExport_GlobalsPINVOKE.ShellDrawable_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(ShellDrawable obj)
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
					TD_PdfExport_GlobalsPINVOKE.delete_ShellDrawable(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public int numVertices()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.ShellDrawable_numVertices(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGePoint3d vertexList()
	{
		IntPtr intPtr = TD_PdfExport_GlobalsPINVOKE.ShellDrawable_vertexList(swigCPtr);
		OdGePoint3d result = ((intPtr == IntPtr.Zero) ? null : new OdGePoint3d(intPtr, cMemoryOwn: false));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int faceListSize()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.ShellDrawable_faceListSize(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int faceList()
	{
		int result = TD_PdfExport_GlobalsPINVOKE.ShellDrawable_faceList(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public EdgeData edgeData()
	{
		EdgeData result = TD_PdfExport_GlobalsPINVOKE.ShellDrawable_edgeData(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiFaceData faceData()
	{
		IntPtr intPtr = TD_PdfExport_GlobalsPINVOKE.ShellDrawable_faceData(swigCPtr);
		OdGiFaceData result = ((intPtr == IntPtr.Zero) ? null : new OdGiFaceData(intPtr, cMemoryOwn: false));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
