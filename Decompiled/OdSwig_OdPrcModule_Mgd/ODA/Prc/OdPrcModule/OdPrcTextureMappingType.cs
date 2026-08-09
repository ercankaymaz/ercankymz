using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Prc.OdPrcModule;

public class OdPrcTextureMappingType : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcTextureMappingType(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcTextureMappingType obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcTextureMappingType()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcTextureMappingType(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcTextureMappingType()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcTextureMappingType(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTextureMappingType_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTextureMappingType_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcTransformation3d cartesianTransformation3d()
	{
		IntPtr intPtr = OdPrcModule_GlobalsPINVOKE.OdPrcTextureMappingType_cartesianTransformation3d__SWIG_0(swigCPtr);
		OdPrcTransformation3d result = ((intPtr == IntPtr.Zero) ? null : new OdPrcTransformation3d(intPtr, cMemoryOwn: false));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public EPRCTextureMappingType eMappingType()
	{
		EPRCTextureMappingType result = OdPrcModule_GlobalsPINVOKE.OdPrcTextureMappingType_eMappingType__SWIG_0(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEMappingOperator(uint eMappingOperator)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTextureMappingType_setEMappingOperator(swigCPtr, eMappingOperator);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint eMappingOperator()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcTextureMappingType_eMappingOperator(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void seteMappingType(EPRCTextureMappingType value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcTextureMappingType_seteMappingType(swigCPtr, (int)value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
