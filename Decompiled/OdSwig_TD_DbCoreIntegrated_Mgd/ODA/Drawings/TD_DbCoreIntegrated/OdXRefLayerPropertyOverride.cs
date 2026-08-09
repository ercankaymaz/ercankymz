using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdXRefLayerPropertyOverride : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdXRefLayerPropertyOverride(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdXRefLayerPropertyOverride obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdXRefLayerPropertyOverride()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdXRefLayerPropertyOverride(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static bool hasXRefLayerOverride(OdDbObjectId hostLayerId, OdXRefLayerPropertyOverride_XRefLayerPropertyOverrideType p)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_hasXRefLayerOverride__SWIG_0(OdDbObjectId.getCPtr(hostLayerId), (int)p);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool hasAnyXRefLayerOverrides(OdDbObjectId hostLayerId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_hasAnyXRefLayerOverrides__SWIG_0(OdDbObjectId.getCPtr(hostLayerId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool hasAnyXRefLayerOverrides(OdDbDatabase pHostDb)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_hasAnyXRefLayerOverrides__SWIG_1(OdDbDatabase.getCPtr(pHostDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool hasXRefLayerOverride(OdDbBlockReference pRef)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_hasXRefLayerOverride__SWIG_1(OdDbBlockReference.getCPtr(pRef));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void addXRefLayerOverride(OdDbObjectId hostLayerId, OdXRefLayerPropertyOverride_XRefLayerPropertyOverrideType p)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_addXRefLayerOverride__SWIG_0(OdDbObjectId.getCPtr(hostLayerId), (int)p);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void addXRefLayerOverride(OdDbObject hostLayer, OdXRefLayerPropertyOverride_XRefLayerPropertyOverrideType p)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_addXRefLayerOverride__SWIG_1(OdDbObject.getCPtr(hostLayer), (int)p);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void removeXRefLayerOverride(OdDbObjectId hostLayerId, OdXRefLayerPropertyOverride_XRefLayerPropertyOverrideType p)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_removeXRefLayerOverride__SWIG_0(OdDbObjectId.getCPtr(hostLayerId), (int)p);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void removeXRefLayerOverride(OdDbDatabase pHostDb, OdXRefLayerPropertyOverride_XRefLayerPropertyOverrideType p)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_removeXRefLayerOverride__SWIG_1(OdDbDatabase.getCPtr(pHostDb), (int)p);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void removeXRefLayerOverrides(OdDbObjectId hostLayerId)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_removeXRefLayerOverrides__SWIG_0(OdDbObjectId.getCPtr(hostLayerId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void removeXRefLayerOverrides(OdDbDatabase pHostDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_removeXRefLayerOverrides__SWIG_1(OdDbDatabase.getCPtr(pHostDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void enableXRefLayerPropertyOverrideRecording()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_enableXRefLayerPropertyOverrideRecording();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void disableXRefLayerPropertyOverrideRecording()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_disableXRefLayerPropertyOverrideRecording();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool isXRefLayerPropertyOverrideRecordingEnabled()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdXRefLayerPropertyOverride_isXRefLayerPropertyOverrideRecordingEnabled();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdXRefLayerPropertyOverride()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdXRefLayerPropertyOverride(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
