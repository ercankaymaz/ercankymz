using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class ExRasterModule : OdRxRasterServices
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ExRasterModule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(ExRasterModule obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_ExRasterModule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new virtual OdGiRasterImage loadRasterImage(string filename, uint[] pFlagsChain)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_loadRasterImage__SWIG_0(swigCPtr, filename, Helpers.MarshalUInt32FixedArray(pFlagsChain)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGiRasterImage loadRasterImage(string filename)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_loadRasterImage__SWIG_1(swigCPtr, filename), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdGiRasterImage loadRasterImage(OdStreamBuf pStreamBuf, uint[] pFlagsChain)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_loadRasterImage__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf), Helpers.MarshalUInt32FixedArray(pFlagsChain)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGiRasterImage loadRasterImage(OdStreamBuf pStreamBuf)
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_loadRasterImage__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual bool saveRasterImage(OdGiRasterImage rasterImage, string filename, uint[] pFlagsChain)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_saveRasterImage__SWIG_0(swigCPtr, OdGiRasterImage.getCPtr(rasterImage), filename, Helpers.MarshalUInt32FixedArray(pFlagsChain));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool saveRasterImage(OdGiRasterImage rasterImage, OdStreamBuf pStream, uint type, uint[] pFlagsChain)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_saveRasterImage__SWIG_1(swigCPtr, OdGiRasterImage.getCPtr(rasterImage), OdStreamBuf.getCPtr(pStream), type, Helpers.MarshalUInt32FixedArray(pFlagsChain));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool saveRasterImage(OdGiRasterImage rasterImage, string filename, uint type, uint[] pFlagsChain)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_saveRasterImage__SWIG_2(swigCPtr, OdGiRasterImage.getCPtr(rasterImage), filename, type, Helpers.MarshalUInt32FixedArray(pFlagsChain));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool convertRasterImage(OdGiRasterImage pRaster, uint type, OdStreamBuf pStreamBuf, uint[] pFlagsChain)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_convertRasterImage__SWIG_0(swigCPtr, OdGiRasterImage.getCPtr(pRaster), type, OdStreamBuf.getCPtr(pStreamBuf), Helpers.MarshalUInt32FixedArray(pFlagsChain));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool convertRasterImage(OdGiRasterImage pRaster, uint type, OdStreamBuf pStreamBuf)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_convertRasterImage__SWIG_1(swigCPtr, OdGiRasterImage.getCPtr(pRaster), type, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool convertRasterImage(OdStreamBuf pSrcStream, OdStreamBuf pDstStream, uint type, uint[] pFlagsChainSrc, uint[] pFlagsChainDst)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_convertRasterImage__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pSrcStream), OdStreamBuf.getCPtr(pDstStream), type, Helpers.MarshalUInt32FixedArray(pFlagsChainSrc), Helpers.MarshalUInt32FixedArray(pFlagsChainDst));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool convertRasterImage(OdStreamBuf pSrcStream, OdStreamBuf pDstStream, uint type, uint[] pFlagsChainSrc)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_convertRasterImage__SWIG_3(swigCPtr, OdStreamBuf.getCPtr(pSrcStream), OdStreamBuf.getCPtr(pDstStream), type, Helpers.MarshalUInt32FixedArray(pFlagsChainSrc));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool convertRasterImage(OdStreamBuf pSrcStream, OdStreamBuf pDstStream, uint type)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_convertRasterImage__SWIG_4(swigCPtr, OdStreamBuf.getCPtr(pSrcStream), OdStreamBuf.getCPtr(pDstStream), type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual OdUInt32Array getRasterImageTypes()
	{
		OdUInt32Array result = new OdUInt32Array(TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_getRasterImageTypes(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual string mapTypeToExtension(uint type, string psFilterName)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_mapTypeToExtension(swigCPtr, type, psFilterName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint mapExtensionToType(string extension)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_mapExtensionToType(swigCPtr, extension);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint getImageFormat(string filename)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_getImageFormat__SWIG_0(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual uint getImageFormat(OdStreamBuf pStreamBuf)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_getImageFormat__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void initApp()
	{
		TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_initApp(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void uninitApp()
	{
		TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_uninitApp(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.ExRasterModule_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
