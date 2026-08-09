using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class BrepBuilderInitialSurfaceArray : IDisposable, IEnumerable, IList<BrepBuilderInitialSurface>, ICollection<BrepBuilderInitialSurface>, IEnumerable<BrepBuilderInitialSurface>
{
	public class BrepBuilderInitialSurfaceArrayEnumerator : IEnumerator, IEnumerator<BrepBuilderInitialSurface>, IDisposable
	{
		private BrepBuilderInitialSurfaceArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public BrepBuilderInitialSurface Current
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
				return (BrepBuilderInitialSurface)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public BrepBuilderInitialSurfaceArrayEnumerator(BrepBuilderInitialSurfaceArray collection)
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

	public BrepBuilderInitialSurface this[int index]
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
	public BrepBuilderInitialSurfaceArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderInitialSurfaceArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderInitialSurfaceArray()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_BrepBuilderInitialSurfaceArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public BrepBuilderInitialSurfaceArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (BrepBuilderInitialSurface item in c)
		{
			Add(item);
		}
	}

	public BrepBuilderInitialSurfaceArray(bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialSurfaceArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderInitialSurfaceArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialSurfaceArray(BrepBuilderInitialSurfaceArray other, bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialSurfaceArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderInitialSurfaceArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialSurfaceArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderInitialSurfaceArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderInitialSurfaceArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(BrepBuilderInitialSurface[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(BrepBuilderInitialSurface[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, BrepBuilderInitialSurface[] array, int arrayIndex, int count)
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

	IEnumerator<BrepBuilderInitialSurface> IEnumerable<BrepBuilderInitialSurface>.GetEnumerator()
	{
		return new BrepBuilderInitialSurfaceArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new BrepBuilderInitialSurfaceArrayEnumerator(this);
	}

	public BrepBuilderInitialSurfaceArrayEnumerator GetEnumerator()
	{
		return new BrepBuilderInitialSurfaceArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_size(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_capacity(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_reserve(swigCPtr, n);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_resize(swigCPtr, logicalLength);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_Clear(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(BrepBuilderInitialSurface val)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_Add(swigCPtr, BrepBuilderInitialSurface.getCPtr(val));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private BrepBuilderInitialSurface getitemcopy(int index)
	{
		BrepBuilderInitialSurface result = new BrepBuilderInitialSurface(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private BrepBuilderInitialSurface getitem(int index)
	{
		BrepBuilderInitialSurface result = new BrepBuilderInitialSurface(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, BrepBuilderInitialSurface val)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_setitem(swigCPtr, index, BrepBuilderInitialSurface.getCPtr(val));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(BrepBuilderInitialSurfaceArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderInitialSurfaceArray GetRange(int index, int count)
	{
		BrepBuilderInitialSurfaceArray result = new BrepBuilderInitialSurfaceArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, BrepBuilderInitialSurface x)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_Insert(swigCPtr, index, BrepBuilderInitialSurface.getCPtr(x));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, BrepBuilderInitialSurfaceArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_RemoveAt(swigCPtr, index);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_RemoveRange(swigCPtr, index, count);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static BrepBuilderInitialSurfaceArray Repeat(BrepBuilderInitialSurface value, int count)
	{
		BrepBuilderInitialSurfaceArray result = new BrepBuilderInitialSurfaceArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_Repeat(BrepBuilderInitialSurface.getCPtr(value), count), cMemoryOwn: false);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_Reverse__SWIG_0(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, BrepBuilderInitialSurfaceArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(BrepBuilderInitialSurface value)
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_Contains(swigCPtr, BrepBuilderInitialSurface.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(BrepBuilderInitialSurface value)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_IndexOf(swigCPtr, BrepBuilderInitialSurface.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(BrepBuilderInitialSurface value)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_LastIndexOf(swigCPtr, BrepBuilderInitialSurface.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(BrepBuilderInitialSurface value)
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderInitialSurfaceArray_Remove(swigCPtr, BrepBuilderInitialSurface.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
