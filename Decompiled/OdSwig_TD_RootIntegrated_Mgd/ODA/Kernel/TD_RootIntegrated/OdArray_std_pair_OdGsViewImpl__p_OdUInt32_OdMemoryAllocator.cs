using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator : IDisposable, IEnumerable, IList<std_pair_OdGsViewImpl__p_OdUInt32>, ICollection<std_pair_OdGsViewImpl__p_OdUInt32>, IEnumerable<std_pair_OdGsViewImpl__p_OdUInt32>
{
	public class OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocatorEnumerator : IEnumerator, IEnumerator<std_pair_OdGsViewImpl__p_OdUInt32>, IDisposable
	{
		private OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public std_pair_OdGsViewImpl__p_OdUInt32 Current
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
				return (std_pair_OdGsViewImpl__p_OdUInt32)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocatorEnumerator(OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator collection)
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

	public std_pair_OdGsViewImpl__p_OdUInt32 this[int index]
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
	public OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (std_pair_OdGsViewImpl__p_OdUInt32 item in c)
		{
			Add(item);
		}
	}

	public OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator other, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(int capacity, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(std_pair_OdGsViewImpl__p_OdUInt32[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(std_pair_OdGsViewImpl__p_OdUInt32[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, std_pair_OdGsViewImpl__p_OdUInt32[] array, int arrayIndex, int count)
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

	IEnumerator<std_pair_OdGsViewImpl__p_OdUInt32> IEnumerable<std_pair_OdGsViewImpl__p_OdUInt32>.GetEnumerator()
	{
		return new OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocatorEnumerator(this);
	}

	public OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(std_pair_OdGsViewImpl__p_OdUInt32 val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_Add(swigCPtr, std_pair_OdGsViewImpl__p_OdUInt32.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private std_pair_OdGsViewImpl__p_OdUInt32 getitemcopy(int index)
	{
		return new std_pair_OdGsViewImpl__p_OdUInt32(TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_getitemcopy(swigCPtr, index), cMemoryOwn: true);
	}

	private std_pair_OdGsViewImpl__p_OdUInt32 getitem(int index)
	{
		return new std_pair_OdGsViewImpl__p_OdUInt32(TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_getitem(swigCPtr, index), cMemoryOwn: false);
	}

	private void setitem(int index, std_pair_OdGsViewImpl__p_OdUInt32 val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_setitem(swigCPtr, index, std_pair_OdGsViewImpl__p_OdUInt32.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator GetRange(int index, int count)
	{
		OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator result = new OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, std_pair_OdGsViewImpl__p_OdUInt32 x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_Insert(swigCPtr, index, std_pair_OdGsViewImpl__p_OdUInt32.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator Repeat(std_pair_OdGsViewImpl__p_OdUInt32 value, int count)
	{
		OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator result = new OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_Repeat(std_pair_OdGsViewImpl__p_OdUInt32.getCPtr(value), count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetRange(int index, OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(std_pair_OdGsViewImpl__p_OdUInt32 value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_Contains(swigCPtr, std_pair_OdGsViewImpl__p_OdUInt32.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(std_pair_OdGsViewImpl__p_OdUInt32 value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_IndexOf(swigCPtr, std_pair_OdGsViewImpl__p_OdUInt32.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(std_pair_OdGsViewImpl__p_OdUInt32 value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_LastIndexOf(swigCPtr, std_pair_OdGsViewImpl__p_OdUInt32.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(std_pair_OdGsViewImpl__p_OdUInt32 value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_std_pair_OdGsViewImpl__p_OdUInt32_OdMemoryAllocator_Remove(swigCPtr, std_pair_OdGsViewImpl__p_OdUInt32.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
