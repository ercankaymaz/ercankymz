using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_PDFToolkit;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class PDF2PRCExportParams : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdRxDictionary m_extraOptions
	{
		get
		{
			OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_extraOptions_get(swigCPtr), bOwn: true, bTryAddToTransaction: true);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		set
		{
			IntPtr jarg = ((value == null) ? IntPtr.Zero : OdRxDictionary.getCPtr(value).Handle);
			TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_extraOptions_set(swigCPtr, ref jarg);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_compressionLevel
	{
		get
		{
			uint result = TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_compressionLevel_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_compressionLevel_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGeMatrix3d m_bodyTransformationMatr
	{
		get
		{
			IntPtr intPtr = TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_bodyTransformationMatr_get(swigCPtr);
			OdGeMatrix3d result = ((intPtr == IntPtr.Zero) ? null : new OdGeMatrix3d(intPtr, cMemoryOwn: false));
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_bodyTransformationMatr_set(swigCPtr, OdGeMatrix3d.getCPtr(value));
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdDoubleArray m_arrDeviation
	{
		get
		{
			OdDoubleArray result = new OdDoubleArray(TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_arrDeviation_get(swigCPtr), cMemoryOwn: false);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_arrDeviation_set(swigCPtr, OdDoubleArray.getCPtr(value).Handle);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public bool m_exportAsBrep
	{
		get
		{
			bool result = TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_exportAsBrep_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_exportAsBrep_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_viewportIdx
	{
		get
		{
			uint result = TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_viewportIdx_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_viewportIdx_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_viewIdx
	{
		get
		{
			uint result = TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_viewIdx_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_viewIdx_set(swigCPtr, value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGiSubEntityTraitsData m_pTraitsData
	{
		get
		{
			IntPtr intPtr = TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_pTraitsData_get(swigCPtr);
			OdGiSubEntityTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiSubEntityTraitsData(intPtr, cMemoryOwn: false));
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_pTraitsData_set(swigCPtr, OdGiSubEntityTraitsData.getCPtr(value));
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public OdGiSubEntityTraitsData m_pByBlockTraitsData
	{
		get
		{
			IntPtr intPtr = TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_pByBlockTraitsData_get(swigCPtr);
			OdGiSubEntityTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiSubEntityTraitsData(intPtr, cMemoryOwn: false));
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_pByBlockTraitsData_set(swigCPtr, OdGiSubEntityTraitsData.getCPtr(value));
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public PDF3D_ENUMS_PrcExportColorComponentBehavior m_ExportAmbientColorBehavior
	{
		get
		{
			int result = TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_ExportAmbientColorBehavior_get(swigCPtr);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (PDF3D_ENUMS_PrcExportColorComponentBehavior)result;
		}
		set
		{
			TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_m_ExportAmbientColorBehavior_set(swigCPtr, (int)value);
			if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public PDF2PRCExportParams(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(PDF2PRCExportParams obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~PDF2PRCExportParams()
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
					TD_PdfExport_GlobalsPINVOKE.delete_PDF2PRCExportParams(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public PDF2PRCExportParams()
		: this(TD_PdfExport_GlobalsPINVOKE.new_PDF2PRCExportParams(), cMemoryOwn: true)
	{
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPRCCompression(PDF3D_ENUMS_PRCCompressionLevel compressionLevel, bool bCompressBrep, bool bCompressTessellation)
	{
		TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_setPRCCompression(swigCPtr, (int)compressionLevel, bCompressBrep, bCompressTessellation);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasPrcBrepCompression(out PDF3D_ENUMS_PRCCompressionLevel compressionLev)
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_hasPrcBrepCompression(swigCPtr, out compressionLev);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasPrcTessellationCompression()
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.PDF2PRCExportParams_hasPrcTessellationCompression(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
