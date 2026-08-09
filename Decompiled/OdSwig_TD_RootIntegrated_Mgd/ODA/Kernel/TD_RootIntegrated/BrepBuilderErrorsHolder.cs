using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class BrepBuilderErrorsHolder : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public OdResult m_errorCode
	{
		get
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_errorCode_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_errorCode_set(swigCPtr, (int)value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_complexId
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_complexId_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_complexId_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_shellId
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_shellId_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_shellId_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_faceId
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_faceId_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_faceId_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_loopId
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_loopId_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_loopId_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_edgeId
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_edgeId_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_edgeId_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public uint m_coedgeId
	{
		get
		{
			uint result = TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_coedgeId_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_coedgeId_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public string m_errorMessage
	{
		get
		{
			string result = TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_errorMessage_get(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		set
		{
			TD_RootIntegrated_GlobalsPINVOKE.BrepBuilderErrorsHolder_m_errorMessage_set(swigCPtr, value);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public BrepBuilderErrorsHolder(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderErrorsHolder obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderErrorsHolder()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_BrepBuilderErrorsHolder(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public BrepBuilderErrorsHolder()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_BrepBuilderErrorsHolder__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderErrorsHolder(OdResult errCode, string errMsg, uint complexId, uint shellId, uint faceId, uint loopId, uint edgeId, uint coedgeId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_BrepBuilderErrorsHolder__SWIG_1((int)errCode, errMsg, complexId, shellId, faceId, loopId, edgeId, coedgeId), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderErrorsHolder(OdResult errCode, string errMsg, uint complexId, uint shellId, uint faceId, uint loopId, uint edgeId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_BrepBuilderErrorsHolder__SWIG_2((int)errCode, errMsg, complexId, shellId, faceId, loopId, edgeId), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderErrorsHolder(OdResult errCode, string errMsg, uint complexId, uint shellId, uint faceId, uint loopId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_BrepBuilderErrorsHolder__SWIG_3((int)errCode, errMsg, complexId, shellId, faceId, loopId), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderErrorsHolder(OdResult errCode, string errMsg, uint complexId, uint shellId, uint faceId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_BrepBuilderErrorsHolder__SWIG_4((int)errCode, errMsg, complexId, shellId, faceId), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderErrorsHolder(OdResult errCode, string errMsg, uint complexId, uint shellId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_BrepBuilderErrorsHolder__SWIG_5((int)errCode, errMsg, complexId, shellId), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderErrorsHolder(OdResult errCode, string errMsg, uint complexId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_BrepBuilderErrorsHolder__SWIG_6((int)errCode, errMsg, complexId), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderErrorsHolder(OdResult errCode, string errMsg)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_BrepBuilderErrorsHolder__SWIG_7((int)errCode, errMsg), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderErrorsHolder(OdResult errCode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_BrepBuilderErrorsHolder__SWIG_8((int)errCode), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
