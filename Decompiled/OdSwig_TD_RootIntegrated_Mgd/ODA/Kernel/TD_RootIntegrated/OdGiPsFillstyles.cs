using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPsFillstyles : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPsFillstyles(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPsFillstyles obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPsFillstyles()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPsFillstyles(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiPsFillstyles()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPsFillstyles(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdHatchPattern getGiDefinitions(OdHatchPattern pPats, double scale, uint nFirst, uint nPats)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_getGiDefinitions__SWIG_0(swigCPtr, OdHatchPattern.getCPtr(pPats), scale, nFirst, nPats);
		OdHatchPattern result = ((intPtr == IntPtr.Zero) ? null : new OdHatchPattern(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdHatchPattern getGiDefinitions(OdHatchPattern pPats, double scale, uint nFirst)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_getGiDefinitions__SWIG_1(swigCPtr, OdHatchPattern.getCPtr(pPats), scale, nFirst);
		OdHatchPattern result = ((intPtr == IntPtr.Zero) ? null : new OdHatchPattern(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdHatchPattern getGiDefinitions(OdHatchPattern pPats, double scale)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_getGiDefinitions__SWIG_2(swigCPtr, OdHatchPattern.getCPtr(pPats), scale);
		OdHatchPattern result = ((intPtr == IntPtr.Zero) ? null : new OdHatchPattern(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdHatchPattern getGiDefinition(OdPs_FillStyle psFs, OdHatchPattern pPat, double scale)
	{
		OdHatchPattern result = new OdHatchPattern(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_getGiDefinition(swigCPtr, (int)psFs, OdHatchPattern.getCPtr(pPat), scale), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array rasterizeFillstyle(OdPs_FillStyle psFs, uint nOffsetX, uint nOffsetY, uint nWidth, uint nHeight, byte fpValue)
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyle__SWIG_0(swigCPtr, (int)psFs, nOffsetX, nOffsetY, nWidth, nHeight, fpValue), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array rasterizeFillstyle(OdPs_FillStyle psFs, uint nOffsetX, uint nOffsetY, uint nWidth, uint nHeight)
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyle__SWIG_1(swigCPtr, (int)psFs, nOffsetX, nOffsetY, nWidth, nHeight), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array rasterizeFillstyle(OdPs_FillStyle psFs, uint nOffsetX, uint nOffsetY, uint nWidth)
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyle__SWIG_2(swigCPtr, (int)psFs, nOffsetX, nOffsetY, nWidth), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array rasterizeFillstyle(OdPs_FillStyle psFs, uint nOffsetX, uint nOffsetY)
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyle__SWIG_3(swigCPtr, (int)psFs, nOffsetX, nOffsetY), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array rasterizeFillstyle(OdPs_FillStyle psFs, uint nOffsetX)
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyle__SWIG_4(swigCPtr, (int)psFs, nOffsetX), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array rasterizeFillstyle(OdPs_FillStyle psFs)
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyle__SWIG_5(swigCPtr, (int)psFs), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRasterImage rasterizeFillstyleImage(OdPs_FillStyle psFs, uint nOffsetX, uint nOffsetY, uint nWidth, uint nHeight, uint backgroundColor, uint foregroundColor)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyleImage__SWIG_0(swigCPtr, (int)psFs, nOffsetX, nOffsetY, nWidth, nHeight, backgroundColor, foregroundColor), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage rasterizeFillstyleImage(OdPs_FillStyle psFs, uint nOffsetX, uint nOffsetY, uint nWidth, uint nHeight, uint backgroundColor)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyleImage__SWIG_1(swigCPtr, (int)psFs, nOffsetX, nOffsetY, nWidth, nHeight, backgroundColor), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage rasterizeFillstyleImage(OdPs_FillStyle psFs, uint nOffsetX, uint nOffsetY, uint nWidth, uint nHeight)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyleImage__SWIG_2(swigCPtr, (int)psFs, nOffsetX, nOffsetY, nWidth, nHeight), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage rasterizeFillstyleImage(OdPs_FillStyle psFs, uint nOffsetX, uint nOffsetY, uint nWidth)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyleImage__SWIG_3(swigCPtr, (int)psFs, nOffsetX, nOffsetY, nWidth), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage rasterizeFillstyleImage(OdPs_FillStyle psFs, uint nOffsetX, uint nOffsetY)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyleImage__SWIG_4(swigCPtr, (int)psFs, nOffsetX, nOffsetY), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage rasterizeFillstyleImage(OdPs_FillStyle psFs, uint nOffsetX)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyleImage__SWIG_5(swigCPtr, (int)psFs, nOffsetX), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImage rasterizeFillstyleImage(OdPs_FillStyle psFs)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPsFillstyles_rasterizeFillstyleImage__SWIG_6(swigCPtr, (int)psFs), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}
}
