using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxAttributeCollection : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxAttributeCollection(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxAttributeCollection obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRxAttributeCollection()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxAttributeCollection(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdRxAttributeCollection()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxAttributeCollection(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int count()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxAttributeCollection_count(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxAttribute getAt(int index)
	{
		OdRxAttribute rXObject = Helpers.GetRXObject<OdRxAttribute>(TD_RootIntegrated_GlobalsPINVOKE.OdRxAttributeCollection_getAt__SWIG_0(swigCPtr, index), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxAttribute get(OdRxClass type)
	{
		OdRxAttribute rXObject = Helpers.GetRXObject<OdRxAttribute>(TD_RootIntegrated_GlobalsPINVOKE.OdRxAttributeCollection_get__SWIG_0(swigCPtr, OdRxClass.getCPtr(type)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult add(OdRxAttribute attribute)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxAttributeCollection_add(swigCPtr, OdRxAttribute.getCPtr(attribute));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult override_(OdRxAttribute attribute)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxAttributeCollection_override_(swigCPtr, OdRxAttribute.getCPtr(attribute));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult remove(OdRxAttribute attribute)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxAttributeCollection_remove(swigCPtr, OdRxAttribute.getCPtr(attribute));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}
}
