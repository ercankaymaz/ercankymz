using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcContentSingleAttribute : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcContentSingleAttribute(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcContentSingleAttribute obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcContentSingleAttribute()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcContentSingleAttribute(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcContentSingleAttribute()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcContentSingleAttribute__SWIG_0(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcOut(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void prcIn(OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcAttributeEntry attributeEntry()
	{
		OdPrcAttributeEntry result = new OdPrcAttributeEntry(OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_attributeEntry__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcContentSingleAttribute(OdPrcContentSingleAttribute source)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcContentSingleAttribute__SWIG_1(getCPtr(source)), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcContentSingleAttribute Assign(OdPrcContentSingleAttribute source)
	{
		OdPrcContentSingleAttribute result = new OdPrcContentSingleAttribute(OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_Assign(swigCPtr, getCPtr(source)), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setData(int data)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_setData__SWIG_0(swigCPtr, data);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setData(double data)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_setData__SWIG_1(swigCPtr, data);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setData(OdTimeStamp data)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_setData__SWIG_2(swigCPtr, OdTimeStamp.getCPtr(data));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setData(uint data)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_setData__SWIG_3(swigCPtr, data);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setData(string data)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_setData__SWIG_4(swigCPtr, data);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void empty()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_empty(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public EPRCModellerAttributeType getType()
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_getType(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (EPRCModellerAttributeType)result;
	}

	public int getDataInt32()
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_getDataInt32(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getDataDouble()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_getDataDouble(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getDataUInt32()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_getDataUInt32(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdTimeStamp getDataTime()
	{
		OdTimeStamp result = new OdTimeStamp(OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_getDataTime(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getDataStr()
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_getDataStr(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setattributeEntry(OdPrcAttributeEntry value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentSingleAttribute_setattributeEntry(swigCPtr, OdPrcAttributeEntry.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
