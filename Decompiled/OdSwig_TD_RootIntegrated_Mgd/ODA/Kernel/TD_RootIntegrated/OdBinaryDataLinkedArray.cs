using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBinaryDataLinkedArray : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public int Count => (int)size();

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdBinaryDataLinkedArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBinaryDataLinkedArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdBinaryDataLinkedArray()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBinaryDataLinkedArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdBinaryDataLinkedArray()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBinaryDataLinkedArray__SWIG_0(16), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdBinaryDataLinkedArray(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdBinaryDataLinkedArray(int pageSize)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBinaryDataLinkedArray__SWIG_0(pageSize), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdBinaryDataLinkedArray(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdBinaryData x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_Add(swigCPtr, OdBinaryData.getCPtr(x).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void freeExtra()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_freeExtra(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdBinaryData removeLast()
	{
		OdBinaryData result = new OdBinaryData(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_removeLast(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBinaryDataLinkedArrayIterator begin()
	{
		OdBinaryDataLinkedArrayIterator result = new OdBinaryDataLinkedArrayIterator(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_begin(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBinaryDataLinkedArrayIterator end()
	{
		OdBinaryDataLinkedArrayIterator result = new OdBinaryDataLinkedArrayIterator(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_end(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBinaryDataLinkedArrayIterator find(OdBinaryData val)
	{
		OdBinaryDataLinkedArrayIterator result = new OdBinaryDataLinkedArrayIterator(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_find(swigCPtr, OdBinaryData.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool contains(OdBinaryData val)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_contains(swigCPtr, OdBinaryData.getCPtr(val).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBinaryDataLinkedArrayIterator insert(OdBinaryDataLinkedArrayIterator before, OdBinaryData val)
	{
		OdBinaryDataLinkedArrayIterator result = new OdBinaryDataLinkedArrayIterator(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_insert(swigCPtr, OdBinaryDataLinkedArrayIterator.getCPtr(before), OdBinaryData.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBinaryData remove(OdBinaryDataLinkedArrayIterator at)
	{
		OdBinaryData result = new OdBinaryData(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_remove(swigCPtr, OdBinaryDataLinkedArrayIterator.getCPtr(at)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBinaryData first()
	{
		OdBinaryData result = new OdBinaryData(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_first(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBinaryData last()
	{
		OdBinaryData result = new OdBinaryData(TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_last(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBinaryDataLinkedArray_empty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
