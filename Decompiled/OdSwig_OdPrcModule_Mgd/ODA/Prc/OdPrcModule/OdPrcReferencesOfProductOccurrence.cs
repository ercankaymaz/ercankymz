using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Prc.OdPrcModule;

public class OdPrcReferencesOfProductOccurrence : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcReferencesOfProductOccurrence(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcReferencesOfProductOccurrence obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcReferencesOfProductOccurrence()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcReferencesOfProductOccurrence(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcReferencesOfProductOccurrence()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcReferencesOfProductOccurrence(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcObjectIdArray getSonProductOccurrences()
	{
		OdPrcObjectIdArray result = new OdPrcObjectIdArray(OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_getSonProductOccurrences__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPrototype(OdPrcObjectId prototypeID)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_setPrototype(swigCPtr, OdPrcObjectId.getCPtr(prototypeID));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcObjectId getPrototypeID()
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_getPrototypeID(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearPrototype()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_clearPrototype(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcObjectId getExternalDataID()
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_getExternalDataID(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExternalData(OdPrcObjectId externalDataID)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_setExternalData(swigCPtr, OdPrcObjectId.getCPtr(externalDataID));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearExternalData()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_clearExternalData(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCorrespondingPartDefinition(OdPrcObjectId partID)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_setCorrespondingPartDefinition(swigCPtr, OdPrcObjectId.getCPtr(partID));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcObjectId getCorrespondingPartDefinition()
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_getCorrespondingPartDefinition(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearPartDefinition()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_clearPartDefinition(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isPrototypeInTheSameFileStructure(OdPrcUniqueId uuid)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_isPrototypeInTheSameFileStructure(swigCPtr, OdPrcUniqueId.getCPtr(uuid));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isExternalDataInTheSameFileStructure(OdPrcUniqueId uuid)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcReferencesOfProductOccurrence_isExternalDataInTheSameFileStructure(swigCPtr, OdPrcUniqueId.getCPtr(uuid));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
