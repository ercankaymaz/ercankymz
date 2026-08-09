using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbIdPair : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbIdPair(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbIdPair obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbIdPair()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbIdPair(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbIdPair()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbIdPair__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbIdPair(OdDbIdPair source)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbIdPair__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbIdPair(OdDbObjectId key)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbIdPair__SWIG_2(OdDbObjectId.getCPtr(key)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbIdPair(OdDbObjectId key, OdDbObjectId value, bool cloned, bool ownerXlated, bool primary)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbIdPair__SWIG_3(OdDbObjectId.getCPtr(key), OdDbObjectId.getCPtr(value), cloned, ownerXlated, primary), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbIdPair(OdDbObjectId key, OdDbObjectId value, bool cloned, bool ownerXlated)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbIdPair__SWIG_4(OdDbObjectId.getCPtr(key), OdDbObjectId.getCPtr(value), cloned, ownerXlated), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbIdPair(OdDbObjectId key, OdDbObjectId value, bool cloned)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbIdPair__SWIG_5(OdDbObjectId.getCPtr(key), OdDbObjectId.getCPtr(value), cloned), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbIdPair(OdDbObjectId key, OdDbObjectId value)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbIdPair__SWIG_6(OdDbObjectId.getCPtr(key), OdDbObjectId.getCPtr(value)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId key()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_key(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId value()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_value(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isCloned()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_isCloned(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPrimary()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_isPrimary(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isOwnerXlated()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_isOwnerXlated(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbIdPair set(OdDbObjectId key, OdDbObjectId value, bool cloned, bool ownerXlated, bool arg4)
	{
		OdDbIdPair result = new OdDbIdPair(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_set__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(key), OdDbObjectId.getCPtr(value), cloned, ownerXlated, arg4), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbIdPair set(OdDbObjectId key, OdDbObjectId value, bool cloned, bool ownerXlated)
	{
		OdDbIdPair result = new OdDbIdPair(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_set__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(key), OdDbObjectId.getCPtr(value), cloned, ownerXlated), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbIdPair set(OdDbObjectId key, OdDbObjectId value, bool cloned)
	{
		OdDbIdPair result = new OdDbIdPair(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_set__SWIG_2(swigCPtr, OdDbObjectId.getCPtr(key), OdDbObjectId.getCPtr(value), cloned), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbIdPair set(OdDbObjectId key, OdDbObjectId value)
	{
		OdDbIdPair result = new OdDbIdPair(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_set__SWIG_3(swigCPtr, OdDbObjectId.getCPtr(key), OdDbObjectId.getCPtr(value)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setKey(OdDbObjectId key)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_setKey(swigCPtr, OdDbObjectId.getCPtr(key));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setValue(OdDbObjectId value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_setValue(swigCPtr, OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCloned(bool cloned)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_setCloned(swigCPtr, cloned);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPrimary(bool primary)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_setPrimary(swigCPtr, primary);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOwnerXlated(bool ownerXlated)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbIdPair_setOwnerXlated(swigCPtr, ownerXlated);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
