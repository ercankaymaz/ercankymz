using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public class OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator : IDisposable, IEnumerable, IList<OdSelectionSet>, ICollection<OdSelectionSet>, IEnumerable<OdSelectionSet>
{
	public class OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<OdSelectionSet>, IDisposable
	{
		private OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdSelectionSet Current
		{
			get
			{
				if (currentIndex == -1)
				{
					throw new InvalidOperationException("Enumeration not started.");
				}
				if (currentIndex > currentSize - 1)
				{
					throw new InvalidOperationException("Enumeration finished.");
				}
				if (currentObject == null)
				{
					throw new InvalidOperationException("Collection modified.");
				}
				return (OdSelectionSet)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocatorEnumerator(OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator collection)
		{
			collectionRef = collection;
			currentIndex = -1;
			currentObject = null;
			currentSize = collectionRef.Count;
		}

		public bool MoveNext()
		{
			int count = collectionRef.Count;
			int num;
			if (currentIndex + 1 < count)
			{
				num = ((count == currentSize) ? 1 : 0);
				if (num != 0)
				{
					currentIndex++;
					currentObject = collectionRef[currentIndex];
					return (byte)num != 0;
				}
			}
			else
			{
				num = 0;
			}
			currentObject = null;
			return (byte)num != 0;
		}

		public void Reset()
		{
			currentIndex = -1;
			currentObject = null;
			if (collectionRef.Count != currentSize)
			{
				throw new InvalidOperationException("Collection modified.");
			}
		}

		public void Dispose()
		{
			currentIndex = -1;
			currentObject = null;
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public OdSelectionSet this[int index]
	{
		get
		{
			return getitem(index);
		}
		set
		{
			setitem(index, value);
		}
	}

	public int Capacity
	{
		get
		{
			return (int)capacity();
		}
		set
		{
			if (value < size())
			{
				throw new ArgumentOutOfRangeException("Capacity");
			}
			reserve((uint)value);
		}
	}

	public int Count => (int)size();

	public bool IsSynchronized => false;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator()
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
					TD_PdfExport_GlobalsPINVOKE.delete_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdSelectionSet item in c)
		{
			Add(item);
		}
	}

	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(bool bGCMemory_Own = false)
		: this(TD_PdfExport_GlobalsPINVOKE.new_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator other, bool bGCMemory_Own = false)
		: this(TD_PdfExport_GlobalsPINVOKE.new_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(int capacity, bool bGCMemory_Own = false)
		: this(TD_PdfExport_GlobalsPINVOKE.new_OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdSelectionSet[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdSelectionSet[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdSelectionSet[] array, int arrayIndex, int count)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index", "Value is less than zero");
		}
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count", "Value is less than zero");
		}
		if (array.Rank > 1)
		{
			throw new ArgumentException("Multi dimensional array.", "array");
		}
		if (index + count > Count || arrayIndex + count > array.Length)
		{
			throw new ArgumentException("Number of elements to copy is too large.");
		}
		for (int i = 0; i < count; i++)
		{
			array.SetValue(getitemcopy(index + i), arrayIndex + i);
		}
	}

	IEnumerator<OdSelectionSet> IEnumerable<OdSelectionSet>.GetEnumerator()
	{
		return new OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocatorEnumerator(this);
	}

	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_size(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_capacity(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_reserve(swigCPtr, n);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_resize(swigCPtr, logicalLength);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Clear(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdSelectionSet val)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Add(swigCPtr, OdSelectionSet.getCPtr(val));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdSelectionSet getitemcopy(int index)
	{
		OdSelectionSet rXObject = Helpers.GetRXObject<OdSelectionSet>(TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private OdSelectionSet getitem(int index)
	{
		OdSelectionSet rXObject = Helpers.GetRXObject<OdSelectionSet>(TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int index, OdSelectionSet val)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_setitem(swigCPtr, index, OdSelectionSet.getCPtr(val));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator values)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_AddRange(swigCPtr, getCPtr(values));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator GetRange(int index, int count)
	{
		OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator result = Helpers.GetObject<OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator>(TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_GetRange(swigCPtr, index, count), bOwn: false, bTryAddToTransaction: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdSelectionSet x)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Insert(swigCPtr, index, OdSelectionSet.getCPtr(x));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator values)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_RemoveAt(swigCPtr, index);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_RemoveRange(swigCPtr, index, count);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator Repeat(OdSelectionSet value, int count)
	{
		OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator result = Helpers.GetObject<OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator>(TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Repeat(OdSelectionSet.getCPtr(value), count), bOwn: false, bTryAddToTransaction: false);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Reverse__SWIG_0(swigCPtr);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator values)
	{
		TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdSelectionSet value)
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Contains(swigCPtr, OdSelectionSet.getCPtr(value));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdSelectionSet value)
	{
		int result = TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_IndexOf(swigCPtr, OdSelectionSet.getCPtr(value));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdSelectionSet value)
	{
		int result = TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_LastIndexOf(swigCPtr, OdSelectionSet.getCPtr(value));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdSelectionSet value)
	{
		bool result = TD_PdfExport_GlobalsPINVOKE.OdArray_OdSmartPtr_OdSelectionSet_OdObjectsAllocator_Remove(swigCPtr, OdSelectionSet.getCPtr(value));
		if (TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PdfExport_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
