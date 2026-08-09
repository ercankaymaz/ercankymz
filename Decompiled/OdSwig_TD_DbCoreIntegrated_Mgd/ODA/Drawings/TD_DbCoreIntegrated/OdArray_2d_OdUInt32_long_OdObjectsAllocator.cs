using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdArray_2d_OdUInt32_long_OdObjectsAllocator : IDisposable, IEnumerable, IList<OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator>, ICollection<OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator>, IEnumerable<OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator>
{
	public class OdArray_2d_OdUInt32_long_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator>, IDisposable
	{
		private OdArray_2d_OdUInt32_long_OdObjectsAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator Current
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
				return (OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_2d_OdUInt32_long_OdObjectsAllocatorEnumerator(OdArray_2d_OdUInt32_long_OdObjectsAllocator collection)
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

	public OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator this[int index]
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
	public OdArray_2d_OdUInt32_long_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_2d_OdUInt32_long_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_2d_OdUInt32_long_OdObjectsAllocator()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdArray_2d_OdUInt32_long_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_2d_OdUInt32_long_OdObjectsAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator item in c)
		{
			Add(item);
		}
	}

	public OdArray_2d_OdUInt32_long_OdObjectsAllocator(bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdArray_2d_OdUInt32_long_OdObjectsAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_2d_OdUInt32_long_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_2d_OdUInt32_long_OdObjectsAllocator(OdArray_2d_OdUInt32_long_OdObjectsAllocator other, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdArray_2d_OdUInt32_long_OdObjectsAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_2d_OdUInt32_long_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_2d_OdUInt32_long_OdObjectsAllocator(int capacity, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdArray_2d_OdUInt32_long_OdObjectsAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_2d_OdUInt32_long_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator[] array, int arrayIndex, int count)
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

	IEnumerator<OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator> IEnumerable<OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator>.GetEnumerator()
	{
		return new OdArray_2d_OdUInt32_long_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_2d_OdUInt32_long_OdObjectsAllocatorEnumerator(this);
	}

	public OdArray_2d_OdUInt32_long_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_2d_OdUInt32_long_OdObjectsAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_size(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_capacity(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_reserve(swigCPtr, n);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_resize(swigCPtr, logicalLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_Clear(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_Add(swigCPtr, OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator.getCPtr(val).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator getitemcopy(int index)
	{
		OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator result = new OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_getitemcopy(swigCPtr, index), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator getitem(int index)
	{
		OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator result = new OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_setitem(swigCPtr, index, OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator.getCPtr(val).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_2d_OdUInt32_long_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_AddRange(swigCPtr, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_2d_OdUInt32_long_OdObjectsAllocator GetRange(int index, int count)
	{
		OdArray_2d_OdUInt32_long_OdObjectsAllocator result = new OdArray_2d_OdUInt32_long_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator x)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_Insert(swigCPtr, index, OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator.getCPtr(x).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_2d_OdUInt32_long_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_RemoveAt(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_RemoveRange(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_2d_OdUInt32_long_OdObjectsAllocator Repeat(OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator value, int count)
	{
		OdArray_2d_OdUInt32_long_OdObjectsAllocator result = new OdArray_2d_OdUInt32_long_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_Repeat(OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator.getCPtr(value).Handle, count), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_Reverse__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_2d_OdUInt32_long_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_Contains(swigCPtr, OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator.getCPtr(value).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_IndexOf(swigCPtr, OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator.getCPtr(value).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_LastIndexOf(swigCPtr, OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator.getCPtr(value).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_2d_OdUInt32_long_OdObjectsAllocator_Remove(swigCPtr, OdArray_std_pair_OdUInt32_long_OdGeNurbCurve3d_OdObjectsAllocator.getCPtr(value).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
