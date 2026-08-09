using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class BrepBuilderShellsArray : IDisposable, IEnumerable, IList<BrepBuilderInitialSurfaceArray>, ICollection<BrepBuilderInitialSurfaceArray>, IEnumerable<BrepBuilderInitialSurfaceArray>
{
	public class BrepBuilderShellsArrayEnumerator : IEnumerator, IEnumerator<BrepBuilderInitialSurfaceArray>, IDisposable
	{
		private BrepBuilderShellsArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public BrepBuilderInitialSurfaceArray Current
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
				return (BrepBuilderInitialSurfaceArray)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public BrepBuilderShellsArrayEnumerator(BrepBuilderShellsArray collection)
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

	public BrepBuilderInitialSurfaceArray this[int index]
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
	public BrepBuilderShellsArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderShellsArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderShellsArray()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_BrepBuilderShellsArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public BrepBuilderShellsArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (BrepBuilderInitialSurfaceArray item in c)
		{
			Add(item);
		}
	}

	public BrepBuilderShellsArray(bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderShellsArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderShellsArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderShellsArray(BrepBuilderShellsArray other, bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderShellsArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderShellsArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderShellsArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderShellsArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderShellsArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(BrepBuilderInitialSurfaceArray[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(BrepBuilderInitialSurfaceArray[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, BrepBuilderInitialSurfaceArray[] array, int arrayIndex, int count)
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

	IEnumerator<BrepBuilderInitialSurfaceArray> IEnumerable<BrepBuilderInitialSurfaceArray>.GetEnumerator()
	{
		return new BrepBuilderShellsArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new BrepBuilderShellsArrayEnumerator(this);
	}

	public BrepBuilderShellsArrayEnumerator GetEnumerator()
	{
		return new BrepBuilderShellsArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_size(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_capacity(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_reserve(swigCPtr, n);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_resize(swigCPtr, logicalLength);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_Clear(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(BrepBuilderInitialSurfaceArray val)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_Add(swigCPtr, BrepBuilderInitialSurfaceArray.getCPtr(val).Handle);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private BrepBuilderInitialSurfaceArray getitemcopy(int index)
	{
		BrepBuilderInitialSurfaceArray result = new BrepBuilderInitialSurfaceArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_getitemcopy(swigCPtr, index), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private BrepBuilderInitialSurfaceArray getitem(int index)
	{
		BrepBuilderInitialSurfaceArray result = new BrepBuilderInitialSurfaceArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, BrepBuilderInitialSurfaceArray val)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_setitem(swigCPtr, index, BrepBuilderInitialSurfaceArray.getCPtr(val).Handle);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(BrepBuilderShellsArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderShellsArray GetRange(int index, int count)
	{
		return new BrepBuilderShellsArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
	}

	public void Insert(int index, BrepBuilderInitialSurfaceArray x)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_Insert(swigCPtr, index, BrepBuilderInitialSurfaceArray.getCPtr(x).Handle);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, BrepBuilderShellsArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_RemoveAt(swigCPtr, index);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_RemoveRange(swigCPtr, index, count);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static BrepBuilderShellsArray Repeat(BrepBuilderInitialSurfaceArray value, int count)
	{
		return new BrepBuilderShellsArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_Repeat(BrepBuilderInitialSurfaceArray.getCPtr(value).Handle, count), cMemoryOwn: true);
	}

	public void Reverse()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_Reverse__SWIG_0(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, BrepBuilderShellsArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(BrepBuilderInitialSurfaceArray value)
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_Contains(swigCPtr, BrepBuilderInitialSurfaceArray.getCPtr(value).Handle);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(BrepBuilderInitialSurfaceArray value)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_IndexOf(swigCPtr, BrepBuilderInitialSurfaceArray.getCPtr(value).Handle);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(BrepBuilderInitialSurfaceArray value)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_LastIndexOf(swigCPtr, BrepBuilderInitialSurfaceArray.getCPtr(value).Handle);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(BrepBuilderInitialSurfaceArray value)
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderShellsArray_Remove(swigCPtr, BrepBuilderInitialSurfaceArray.getCPtr(value).Handle);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
