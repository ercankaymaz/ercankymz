using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class BrepBuilderInitialEdgeArray : IDisposable, IEnumerable, IList<BrepBuilderInitialEdge>, ICollection<BrepBuilderInitialEdge>, IEnumerable<BrepBuilderInitialEdge>
{
	public class BrepBuilderInitialEdgeArrayEnumerator : IEnumerator, IEnumerator<BrepBuilderInitialEdge>, IDisposable
	{
		private BrepBuilderInitialEdgeArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public BrepBuilderInitialEdge Current
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
				return (BrepBuilderInitialEdge)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public BrepBuilderInitialEdgeArrayEnumerator(BrepBuilderInitialEdgeArray collection)
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

	public BrepBuilderInitialEdge this[int index]
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
	public BrepBuilderInitialEdgeArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderInitialEdgeArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderInitialEdgeArray()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_BrepBuilderInitialEdgeArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public BrepBuilderInitialEdgeArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (BrepBuilderInitialEdge item in c)
		{
			Add(item);
		}
	}

	public BrepBuilderInitialEdgeArray(bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialEdgeArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderInitialEdgeArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialEdgeArray(BrepBuilderInitialEdgeArray other, bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialEdgeArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderInitialEdgeArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialEdgeArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialEdgeArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderInitialEdgeArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(BrepBuilderInitialEdge[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(BrepBuilderInitialEdge[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, BrepBuilderInitialEdge[] array, int arrayIndex, int count)
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

	IEnumerator<BrepBuilderInitialEdge> IEnumerable<BrepBuilderInitialEdge>.GetEnumerator()
	{
		return new BrepBuilderInitialEdgeArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new BrepBuilderInitialEdgeArrayEnumerator(this);
	}

	public BrepBuilderInitialEdgeArrayEnumerator GetEnumerator()
	{
		return new BrepBuilderInitialEdgeArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_size(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_capacity(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_reserve(swigCPtr, n);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_resize(swigCPtr, logicalLength);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_Clear(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(BrepBuilderInitialEdge val)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_Add(swigCPtr, BrepBuilderInitialEdge.getCPtr(val));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private BrepBuilderInitialEdge getitemcopy(int index)
	{
		BrepBuilderInitialEdge result = new BrepBuilderInitialEdge(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private BrepBuilderInitialEdge getitem(int index)
	{
		BrepBuilderInitialEdge result = new BrepBuilderInitialEdge(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, BrepBuilderInitialEdge val)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_setitem(swigCPtr, index, BrepBuilderInitialEdge.getCPtr(val));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialEdgeArray GetRange(int index, int count)
	{
		BrepBuilderInitialEdgeArray result = new BrepBuilderInitialEdgeArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, BrepBuilderInitialEdge x)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_Insert(swigCPtr, index, BrepBuilderInitialEdge.getCPtr(x));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_RemoveAt(swigCPtr, index);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_RemoveRange(swigCPtr, index, count);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static BrepBuilderInitialEdgeArray Repeat(BrepBuilderInitialEdge value, int count)
	{
		BrepBuilderInitialEdgeArray result = new BrepBuilderInitialEdgeArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_Repeat(BrepBuilderInitialEdge.getCPtr(value), count), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetRange(int index, BrepBuilderInitialEdgeArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(BrepBuilderInitialEdge value)
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_Contains(swigCPtr, BrepBuilderInitialEdge.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(BrepBuilderInitialEdge value)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_IndexOf(swigCPtr, BrepBuilderInitialEdge.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(BrepBuilderInitialEdge value)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_LastIndexOf(swigCPtr, BrepBuilderInitialEdge.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(BrepBuilderInitialEdge value)
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialEdgeArray_Remove(swigCPtr, BrepBuilderInitialEdge.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
