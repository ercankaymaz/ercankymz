using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMultiClipBoundary_AbstractClipBoundaryArray : IDisposable, IEnumerable, IList<OdGiAbstractClipBoundary>, ICollection<OdGiAbstractClipBoundary>, IEnumerable<OdGiAbstractClipBoundary>
{
	public class OdGiMultiClipBoundary_AbstractClipBoundaryArrayEnumerator : IEnumerator, IEnumerator<OdGiAbstractClipBoundary>, IDisposable
	{
		private OdGiMultiClipBoundary_AbstractClipBoundaryArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdGiAbstractClipBoundary Current
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
				return (OdGiAbstractClipBoundary)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdGiMultiClipBoundary_AbstractClipBoundaryArrayEnumerator(OdGiMultiClipBoundary_AbstractClipBoundaryArray collection)
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

	public OdGiAbstractClipBoundary this[int index]
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
	public OdGiMultiClipBoundary_AbstractClipBoundaryArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMultiClipBoundary_AbstractClipBoundaryArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiMultiClipBoundary_AbstractClipBoundaryArray()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMultiClipBoundary_AbstractClipBoundaryArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiMultiClipBoundary_AbstractClipBoundaryArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdGiAbstractClipBoundary item in c)
		{
			Add(item);
		}
	}

	public OdGiMultiClipBoundary_AbstractClipBoundaryArray(bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMultiClipBoundary_AbstractClipBoundaryArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdGiMultiClipBoundary_AbstractClipBoundaryArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMultiClipBoundary_AbstractClipBoundaryArray(OdGiMultiClipBoundary_AbstractClipBoundaryArray other, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMultiClipBoundary_AbstractClipBoundaryArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdGiMultiClipBoundary_AbstractClipBoundaryArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMultiClipBoundary_AbstractClipBoundaryArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMultiClipBoundary_AbstractClipBoundaryArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdGiMultiClipBoundary_AbstractClipBoundaryArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdGiAbstractClipBoundary[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdGiAbstractClipBoundary[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdGiAbstractClipBoundary[] array, int arrayIndex, int count)
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

	IEnumerator<OdGiAbstractClipBoundary> IEnumerable<OdGiAbstractClipBoundary>.GetEnumerator()
	{
		return new OdGiMultiClipBoundary_AbstractClipBoundaryArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdGiMultiClipBoundary_AbstractClipBoundaryArrayEnumerator(this);
	}

	public OdGiMultiClipBoundary_AbstractClipBoundaryArrayEnumerator GetEnumerator()
	{
		return new OdGiMultiClipBoundary_AbstractClipBoundaryArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdGiAbstractClipBoundary val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_Add(swigCPtr, OdGiAbstractClipBoundary.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdGiAbstractClipBoundary getitemcopy(int index)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_getitemcopy(swigCPtr, index);
		OdGiAbstractClipBoundary result = ((intPtr == IntPtr.Zero) ? null : new OdGiAbstractClipBoundary(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdGiAbstractClipBoundary getitem(int index)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_getitem(swigCPtr, index);
		OdGiAbstractClipBoundary result = ((intPtr == IntPtr.Zero) ? null : new OdGiAbstractClipBoundary(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdGiAbstractClipBoundary val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_setitem(swigCPtr, index, OdGiAbstractClipBoundary.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdGiMultiClipBoundary_AbstractClipBoundaryArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiMultiClipBoundary_AbstractClipBoundaryArray GetRange(int index, int count)
	{
		OdGiMultiClipBoundary_AbstractClipBoundaryArray result = new OdGiMultiClipBoundary_AbstractClipBoundaryArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdGiAbstractClipBoundary x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_Insert(swigCPtr, index, OdGiAbstractClipBoundary.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdGiMultiClipBoundary_AbstractClipBoundaryArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGiMultiClipBoundary_AbstractClipBoundaryArray Repeat(OdGiAbstractClipBoundary value, int count)
	{
		OdGiMultiClipBoundary_AbstractClipBoundaryArray result = new OdGiMultiClipBoundary_AbstractClipBoundaryArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_Repeat(OdGiAbstractClipBoundary.getCPtr(value), count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdGiMultiClipBoundary_AbstractClipBoundaryArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdGiAbstractClipBoundary value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_Contains(swigCPtr, OdGiAbstractClipBoundary.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdGiAbstractClipBoundary value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_IndexOf(swigCPtr, OdGiAbstractClipBoundary.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdGiAbstractClipBoundary value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_LastIndexOf(swigCPtr, OdGiAbstractClipBoundary.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdGiAbstractClipBoundary value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMultiClipBoundary_AbstractClipBoundaryArray_Remove(swigCPtr, OdGiAbstractClipBoundary.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
