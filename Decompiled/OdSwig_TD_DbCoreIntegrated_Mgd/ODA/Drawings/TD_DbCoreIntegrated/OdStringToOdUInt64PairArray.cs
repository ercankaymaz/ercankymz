using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdStringToOdUInt64PairArray : IDisposable, IEnumerable, IList<OdStringToOdUInt64Pair>, ICollection<OdStringToOdUInt64Pair>, IEnumerable<OdStringToOdUInt64Pair>
{
	public class OdStringToOdUInt64PairArrayEnumerator : IEnumerator, IEnumerator<OdStringToOdUInt64Pair>, IDisposable
	{
		private OdStringToOdUInt64PairArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdStringToOdUInt64Pair Current
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
				return (OdStringToOdUInt64Pair)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdStringToOdUInt64PairArrayEnumerator(OdStringToOdUInt64PairArray collection)
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

	public OdStringToOdUInt64Pair this[int index]
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
	public OdStringToOdUInt64PairArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdStringToOdUInt64PairArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdStringToOdUInt64PairArray()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdStringToOdUInt64PairArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdStringToOdUInt64PairArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdStringToOdUInt64Pair item in c)
		{
			Add(item);
		}
	}

	public OdStringToOdUInt64PairArray(bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdStringToOdUInt64PairArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdStringToOdUInt64PairArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdStringToOdUInt64PairArray(OdStringToOdUInt64PairArray other, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdStringToOdUInt64PairArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdStringToOdUInt64PairArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdStringToOdUInt64PairArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdStringToOdUInt64PairArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdStringToOdUInt64PairArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdStringToOdUInt64Pair[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdStringToOdUInt64Pair[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdStringToOdUInt64Pair[] array, int arrayIndex, int count)
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

	IEnumerator<OdStringToOdUInt64Pair> IEnumerable<OdStringToOdUInt64Pair>.GetEnumerator()
	{
		return new OdStringToOdUInt64PairArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdStringToOdUInt64PairArrayEnumerator(this);
	}

	public OdStringToOdUInt64PairArrayEnumerator GetEnumerator()
	{
		return new OdStringToOdUInt64PairArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_size(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_capacity(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_reserve(swigCPtr, n);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_resize(swigCPtr, logicalLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_Clear(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdStringToOdUInt64Pair val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_Add(swigCPtr, OdStringToOdUInt64Pair.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdStringToOdUInt64Pair getitemcopy(int index)
	{
		OdStringToOdUInt64Pair result = new OdStringToOdUInt64Pair(TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdStringToOdUInt64Pair getitem(int index)
	{
		OdStringToOdUInt64Pair result = new OdStringToOdUInt64Pair(TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdStringToOdUInt64Pair val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_setitem(swigCPtr, index, OdStringToOdUInt64Pair.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_AddRange(swigCPtr, OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator.getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator GetRange(int index, int count)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_GetRange(swigCPtr, index, count);
		OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator result = ((intPtr == IntPtr.Zero) ? null : new OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdStringToOdUInt64Pair x)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_Insert(swigCPtr, index, OdStringToOdUInt64Pair.getCPtr(x));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_InsertRange(swigCPtr, index, OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator.getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_RemoveAt(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_RemoveRange(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator Repeat(OdStringToOdUInt64Pair value, int count)
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_Repeat(OdStringToOdUInt64Pair.getCPtr(value), count);
		OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator result = ((intPtr == IntPtr.Zero) ? null : new OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator(intPtr, cMemoryOwn: true));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_Reverse__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_SetRange(swigCPtr, index, OdArray_std_pair_OdString_OdUInt64_OdObjectsAllocator.getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdStringToOdUInt64Pair value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_Contains(swigCPtr, OdStringToOdUInt64Pair.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdStringToOdUInt64Pair value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_IndexOf(swigCPtr, OdStringToOdUInt64Pair.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdStringToOdUInt64Pair value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_LastIndexOf(swigCPtr, OdStringToOdUInt64Pair.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdStringToOdUInt64Pair value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdStringToOdUInt64PairArray_Remove(swigCPtr, OdStringToOdUInt64Pair.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
