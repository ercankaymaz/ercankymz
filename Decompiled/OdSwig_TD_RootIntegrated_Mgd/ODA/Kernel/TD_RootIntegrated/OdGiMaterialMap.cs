using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMaterialMap : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdGiMaterialMap kNull
	{
		get
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_kNull_get();
			OdGiMaterialMap result = ((intPtr == IntPtr.Zero) ? null : new OdGiMaterialMap(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMaterialMap(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMaterialMap obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiMaterialMap()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialMap(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiMaterialMap()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialMap(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSource(OdGiMaterialMap_Source source)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_setSource(swigCPtr, (int)source);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSourceFileName(string filename)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_setSourceFileName(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBlendFactor(double blendFactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_setBlendFactor(swigCPtr, blendFactor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBrightness(double brightness)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_setBrightness(swigCPtr, brightness);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setInverted(bool bInvert)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_setInverted(swigCPtr, bInvert);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setInvertedBrightness(bool bInvert)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_setInvertedBrightness(swigCPtr, bInvert);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRawImage(bool bRaw)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_setRawImage(swigCPtr, bRaw);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTexture(OdGiMaterialTexture pTexture)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_setTexture(swigCPtr, OdGiMaterialTexture.getCPtr(pTexture));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMapper mapper()
	{
		OdGiMapper result = new OdGiMapper(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_mapper__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialMap_Source source()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_source(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiMaterialMap_Source)result;
	}

	public string sourceFileName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_sourceFileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double blendFactor()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_blendFactor(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double brightness()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_brightness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInverted()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_isInverted(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isInvertedBrightness()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_isInvertedBrightness(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isRawImage()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_isRawImage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMapper(OdGiMapper mapper)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_setMapper(swigCPtr, OdGiMapper.getCPtr(mapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMaterialTexture texture()
	{
		OdGiMaterialTexture rXObject = Helpers.GetRXObject<OdGiMaterialTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_texture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool IsEqual(OdGiMaterialMap other)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_IsEqual(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGiMaterialMap other)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_IsNotEqual(swigCPtr, getCPtr(other));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialMap Assign(OdGiMaterialMap mmap)
	{
		OdGiMaterialMap result = new OdGiMaterialMap(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialMap_Assign(swigCPtr, getCPtr(mmap)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
