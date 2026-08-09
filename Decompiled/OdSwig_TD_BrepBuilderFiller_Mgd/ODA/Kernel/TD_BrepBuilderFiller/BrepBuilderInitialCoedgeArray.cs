using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class BrepBuilderInitialCoedgeArray : IDisposable, IEnumerable, IList<BrepBuilderInitialCoedge>, ICollection<BrepBuilderInitialCoedge>, IEnumerable<BrepBuilderInitialCoedge>
{
	public class BrepBuilderInitialCoedgeArrayEnumerator : IEnumerator, IEnumerator<BrepBuilderInitialCoedge>, IDisposable
	{
		private BrepBuilderInitialCoedgeArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public BrepBuilderInitialCoedge Current
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
				return (BrepBuilderInitialCoedge)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public BrepBuilderInitialCoedgeArrayEnumerator(BrepBuilderInitialCoedgeArray collection)
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

	public BrepBuilderInitialCoedge this[int index]
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
	public BrepBuilderInitialCoedgeArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderInitialCoedgeArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderInitialCoedgeArray()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_BrepBuilderInitialCoedgeArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public BrepBuilderInitialCoedgeArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (BrepBuilderInitialCoedge item in c)
		{
			Add(item);
		}
	}

	public BrepBuilderInitialCoedgeArray(bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialCoedgeArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderInitialCoedgeArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialCoedgeArray(BrepBuilderInitialCoedgeArray other, bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialCoedgeArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderInitialCoedgeArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialCoedgeArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialCoedgeArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderInitialCoedgeArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(BrepBuilderInitialCoedge[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(BrepBuilderInitialCoedge[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, BrepBuilderInitialCoedge[] array, int arrayIndex, int count)
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

	IEnumerator<BrepBuilderInitialCoedge> IEnumerable<BrepBuilderInitialCoedge>.GetEnumerator()
	{
		return new BrepBuilderInitialCoedgeArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new BrepBuilderInitialCoedgeArrayEnumerator(this);
	}

	public BrepBuilderInitialCoedgeArrayEnumerator GetEnumerator()
	{
		return new BrepBuilderInitialCoedgeArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_size(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_capacity(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_reserve(swigCPtr, n);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_resize(swigCPtr, logicalLength);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_Clear(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(BrepBuilderInitialCoedge val)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_Add(swigCPtr, BrepBuilderInitialCoedge.getCPtr(val));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private BrepBuilderInitialCoedge getitemcopy(int index)
	{
		BrepBuilderInitialCoedge result = new BrepBuilderInitialCoedge(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private BrepBuilderInitialCoedge getitem(int index)
	{
		BrepBuilderInitialCoedge result = new BrepBuilderInitialCoedge(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, BrepBuilderInitialCoedge val)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_setitem(swigCPtr, index, BrepBuilderInitialCoedge.getCPtr(val));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(BrepBuilderInitialCoedgeArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialCoedgeArray GetRange(int index, int count)
	{
		BrepBuilderInitialCoedgeArray result = new BrepBuilderInitialCoedgeArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, BrepBuilderInitialCoedge x)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_Insert(swigCPtr, index, BrepBuilderInitialCoedge.getCPtr(x));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, BrepBuilderInitialCoedgeArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_RemoveAt(swigCPtr, index);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_RemoveRange(swigCPtr, index, count);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static BrepBuilderInitialCoedgeArray Repeat(BrepBuilderInitialCoedge value, int count)
	{
		BrepBuilderInitialCoedgeArray result = new BrepBuilderInitialCoedgeArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_Repeat(BrepBuilderInitialCoedge.getCPtr(value), count), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_Reverse__SWIG_0(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, BrepBuilderInitialCoedgeArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(BrepBuilderInitialCoedge value)
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_Contains(swigCPtr, BrepBuilderInitialCoedge.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(BrepBuilderInitialCoedge value)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_IndexOf(swigCPtr, BrepBuilderInitialCoedge.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(BrepBuilderInitialCoedge value)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_LastIndexOf(swigCPtr, BrepBuilderInitialCoedge.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(BrepBuilderInitialCoedge value)
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialCoedgeArray_Remove(swigCPtr, BrepBuilderInitialCoedge.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
