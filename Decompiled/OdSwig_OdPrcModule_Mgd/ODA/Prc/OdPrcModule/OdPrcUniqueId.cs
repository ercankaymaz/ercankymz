using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Prc.OdPrcModule;

public class OdPrcUniqueId : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcUniqueId(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcUniqueId obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcUniqueId()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcUniqueId(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcUniqueId()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUniqueId__SWIG_0(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdPrcUniqueId uid)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcUniqueId_IsEqual(swigCPtr, getCPtr(uid));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcUniqueId(uint id0, uint id1, uint id2, uint id3)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUniqueId__SWIG_1(id0, id1, id2, id3), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setID(uint id0, uint id1, uint id2, uint id3)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUniqueId_setID(swigCPtr, id0, id1, id2, id3);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getID(out uint id0, out uint id1, out uint id2, out uint id3)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUniqueId_getID(swigCPtr, out id0, out id1, out id2, out id3);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isNonZero()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcUniqueId_isNonZero(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdPrcUniqueId generateUID()
	{
		OdPrcUniqueId result = new OdPrcUniqueId(OdPrcModule_GlobalsPINVOKE.OdPrcUniqueId_generateUID(), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void prcOut(OdPrcUncompressedFiler pStream, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUniqueId_prcOut(swigCPtr, OdPrcUncompressedFiler.getCPtr(pStream), pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcUncompressedFiler pStream, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUniqueId_prcIn(swigCPtr, OdPrcUncompressedFiler.getCPtr(pStream), pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void writeCompressed(OdPrcCompressedFiler pStream, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUniqueId_writeCompressed(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream), pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void readCompressed(OdPrcCompressedFiler pStream, string pName)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUniqueId_readCompressed(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream), pName);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
