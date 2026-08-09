using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_BrepBuilderFiller;

public class BrepBuilderComplexArray : IDisposable, IEnumerable, IList<BrepBuilderShellsArray>, ICollection<BrepBuilderShellsArray>, IEnumerable<BrepBuilderShellsArray>
{
	public class BrepBuilderComplexArrayEnumerator : IEnumerator, IEnumerator<BrepBuilderShellsArray>, IDisposable
	{
		private BrepBuilderComplexArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public BrepBuilderShellsArray Current
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
				return (BrepBuilderShellsArray)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public BrepBuilderComplexArrayEnumerator(BrepBuilderComplexArray collection)
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

	public BrepBuilderShellsArray this[int index]
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
	public BrepBuilderComplexArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(BrepBuilderComplexArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~BrepBuilderComplexArray()
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
					TD_BrepBuilderFiller_GlobalsPINVOKE.delete_BrepBuilderComplexArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public BrepBuilderComplexArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (BrepBuilderShellsArray item in c)
		{
			Add(item);
		}
	}

	public BrepBuilderComplexArray(bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderComplexArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderComplexArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderComplexArray(BrepBuilderComplexArray other, bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderComplexArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderComplexArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderComplexArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_BrepBuilderFiller_GlobalsPINVOKE.new_BrepBuilderComplexArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new BrepBuilderComplexArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(BrepBuilderShellsArray[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(BrepBuilderShellsArray[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, BrepBuilderShellsArray[] array, int arrayIndex, int count)
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

	IEnumerator<BrepBuilderShellsArray> IEnumerable<BrepBuilderShellsArray>.GetEnumerator()
	{
		return new BrepBuilderComplexArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new BrepBuilderComplexArrayEnumerator(this);
	}

	public BrepBuilderComplexArrayEnumerator GetEnumerator()
	{
		return new BrepBuilderComplexArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_size(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_capacity(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_reserve(swigCPtr, n);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_resize(swigCPtr, logicalLength);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_Clear(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(BrepBuilderShellsArray val)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_Add(swigCPtr, BrepBuilderShellsArray.getCPtr(val));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private BrepBuilderShellsArray getitemcopy(int index)
	{
		return new BrepBuilderShellsArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
	}

	private BrepBuilderShellsArray getitem(int index)
	{
		return new BrepBuilderShellsArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_getitem(swigCPtr, index), cMemoryOwn: false);
	}

	private void setitem(int index, BrepBuilderShellsArray val)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_setitem(swigCPtr, index, BrepBuilderShellsArray.getCPtr(val));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(BrepBuilderComplexArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public BrepBuilderComplexArray GetRange(int index, int count)
	{
		return new BrepBuilderComplexArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
	}

	public void Insert(int index, BrepBuilderShellsArray x)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_Insert(swigCPtr, index, BrepBuilderShellsArray.getCPtr(x));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, BrepBuilderComplexArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_RemoveAt(swigCPtr, index);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_RemoveRange(swigCPtr, index, count);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static BrepBuilderComplexArray Repeat(BrepBuilderShellsArray value, int count)
	{
		return new BrepBuilderComplexArray(TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_Repeat(BrepBuilderShellsArray.getCPtr(value), count), cMemoryOwn: true);
	}

	public void Reverse()
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_Reverse__SWIG_0(swigCPtr);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, BrepBuilderComplexArray values)
	{
		TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(BrepBuilderShellsArray value)
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_Contains(swigCPtr, BrepBuilderShellsArray.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(BrepBuilderShellsArray value)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_IndexOf(swigCPtr, BrepBuilderShellsArray.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(BrepBuilderShellsArray value)
	{
		int result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_LastIndexOf(swigCPtr, BrepBuilderShellsArray.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(BrepBuilderShellsArray value)
	{
		bool result = TD_BrepBuilderFiller_GlobalsPINVOKE.BrepBuilderComplexArray_Remove(swigCPtr, BrepBuilderShellsArray.getCPtr(value));
		if (TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_BrepBuilderFiller_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
