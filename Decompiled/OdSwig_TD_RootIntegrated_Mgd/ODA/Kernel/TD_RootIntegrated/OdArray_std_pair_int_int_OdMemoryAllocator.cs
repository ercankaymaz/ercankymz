using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdArray_std_pair_int_int_OdMemoryAllocator : IDisposable, IEnumerable, IList<std_pair_int_int>, ICollection<std_pair_int_int>, IEnumerable<std_pair_int_int>
{
	public class OdArray_std_pair_int_int_OdMemoryAllocatorEnumerator : IEnumerator, IEnumerator<std_pair_int_int>, IDisposable
	{
		private OdArray_std_pair_int_int_OdMemoryAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public std_pair_int_int Current
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
				return (std_pair_int_int)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_std_pair_int_int_OdMemoryAllocatorEnumerator(OdArray_std_pair_int_int_OdMemoryAllocator collection)
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

	public std_pair_int_int this[int index]
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
	public OdArray_std_pair_int_int_OdMemoryAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_std_pair_int_int_OdMemoryAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_std_pair_int_int_OdMemoryAllocator()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdArray_std_pair_int_int_OdMemoryAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_std_pair_int_int_OdMemoryAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (std_pair_int_int item in c)
		{
			Add(item);
		}
	}

	public OdArray_std_pair_int_int_OdMemoryAllocator(bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_std_pair_int_int_OdMemoryAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_std_pair_int_int_OdMemoryAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_std_pair_int_int_OdMemoryAllocator(OdArray_std_pair_int_int_OdMemoryAllocator other, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_std_pair_int_int_OdMemoryAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_std_pair_int_int_OdMemoryAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_std_pair_int_int_OdMemoryAllocator(int capacity, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_std_pair_int_int_OdMemoryAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_std_pair_int_int_OdMemoryAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(std_pair_int_int[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(std_pair_int_int[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, std_pair_int_int[] array, int arrayIndex, int count)
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

	IEnumerator<std_pair_int_int> IEnumerable<std_pair_int_int>.GetEnumerator()
	{
		return new OdArray_std_pair_int_int_OdMemoryAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_std_pair_int_int_OdMemoryAllocatorEnumerator(this);
	}

	public OdArray_std_pair_int_int_OdMemoryAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_std_pair_int_int_OdMemoryAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_int_int_OdMemoryAllocator_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_int_int_OdMemoryAllocator_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private std_pair_int_int getitem(int index)
	{
		return new std_pair_int_int(TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_int_int_OdMemoryAllocator_getitem(swigCPtr, index), cMemoryOwn: false);
	}

	public OdArray_std_pair_int_int_OdMemoryAllocator GetRange(int index, int count)
	{
		OdArray_std_pair_int_int_OdMemoryAllocator result = new OdArray_std_pair_int_int_OdMemoryAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_int_int_OdMemoryAllocator_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Contains(std_pair_int_int value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_int_int_OdMemoryAllocator_Contains(swigCPtr, std_pair_int_int.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(std_pair_int_int value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_int_int_OdMemoryAllocator_IndexOf(swigCPtr, std_pair_int_int.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, std_pair_int_int val)
	{
		throw new Exception("Not avaliable in C++ API");
	}

	private std_pair_int_int getitemcopy(int index)
	{
		throw new Exception("Not avaliable in C++ API");
	}

	private void reserve(uint n)
	{
		throw new Exception("Not avaliable in C++ API");
	}

	public void Insert(int index, std_pair_int_int x)
	{
		throw new Exception("Not avaliable in C++ API");
	}

	public void RemoveAt(int index)
	{
		throw new Exception("Not avaliable in C++ API");
	}

	public bool Remove(std_pair_int_int value)
	{
		throw new Exception("Not avaliable in C++ API");
	}

	public void Clear()
	{
		throw new Exception("Not avaliable in C++ API");
	}

	public void Add(std_pair_int_int value)
	{
		throw new Exception("Not avaliable in C++ API");
	}
}
