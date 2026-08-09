using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDgLinetype : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDgLinetype(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDgLinetype obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiDgLinetype()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDgLinetype(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiDgLinetype()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetype(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isContinuous()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_isContinuous(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isByBlock()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_isByBlock(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setByBlock(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_setByBlock(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isByLayer()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_isByLayer(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setByLayer(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_setByLayer(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double patternLength()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_patternLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPatternLength(double dPatLen)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_setPatternLength(swigCPtr, dPatLen);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint numItems()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_numItems(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNumItems(uint count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_setNumItems(swigCPtr, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void itemAt(uint index, OdGiDgLinetypeItem item)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_itemAt__SWIG_0(swigCPtr, index, OdGiDgLinetypeItem.getCPtr(item));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDgLinetypeItem itemAt(uint index)
	{
		OdGiDgLinetypeItem result = new OdGiDgLinetypeItem(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_itemAt__SWIG_1(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setItemAt(uint index, OdGiDgLinetypeItem item)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_setItemAt(swigCPtr, index, OdGiDgLinetypeItem.getCPtr(item));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void items(OdGiDgLinetypeItemArray items)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_items(swigCPtr, OdGiDgLinetypeItemArray.getCPtr(items));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setItems(OdGiDgLinetypeItemArray items)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetype_setItems(swigCPtr, OdGiDgLinetypeItemArray.getCPtr(items));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
