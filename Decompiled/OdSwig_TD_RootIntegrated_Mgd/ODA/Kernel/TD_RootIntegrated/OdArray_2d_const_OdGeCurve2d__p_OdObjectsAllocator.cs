using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator : IDisposable, IEnumerable, IList<OdArray_const_OdGeCurve2d__p_OdObjectsAllocator>, ICollection<OdArray_const_OdGeCurve2d__p_OdObjectsAllocator>, IEnumerable<OdArray_const_OdGeCurve2d__p_OdObjectsAllocator>
{
	public class OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<OdArray_const_OdGeCurve2d__p_OdObjectsAllocator>, IDisposable
	{
		private OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdArray_const_OdGeCurve2d__p_OdObjectsAllocator Current
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
				return (OdArray_const_OdGeCurve2d__p_OdObjectsAllocator)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocatorEnumerator(OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator collection)
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

	public OdArray_const_OdGeCurve2d__p_OdObjectsAllocator this[int index]
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
	public OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdArray_const_OdGeCurve2d__p_OdObjectsAllocator item in c)
		{
			Add(item);
		}
	}

	public OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator other, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(int capacity, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdArray_const_OdGeCurve2d__p_OdObjectsAllocator[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdArray_const_OdGeCurve2d__p_OdObjectsAllocator[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdArray_const_OdGeCurve2d__p_OdObjectsAllocator[] array, int arrayIndex, int count)
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

	IEnumerator<OdArray_const_OdGeCurve2d__p_OdObjectsAllocator> IEnumerable<OdArray_const_OdGeCurve2d__p_OdObjectsAllocator>.GetEnumerator()
	{
		return new OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocatorEnumerator(this);
	}

	public OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdArray_const_OdGeCurve2d__p_OdObjectsAllocator val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_Add(swigCPtr, OdArray_const_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(val).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdArray_const_OdGeCurve2d__p_OdObjectsAllocator getitemcopy(int index)
	{
		OdArray_const_OdGeCurve2d__p_OdObjectsAllocator result = new OdArray_const_OdGeCurve2d__p_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_getitemcopy(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdArray_const_OdGeCurve2d__p_OdObjectsAllocator getitem(int index)
	{
		OdArray_const_OdGeCurve2d__p_OdObjectsAllocator result = new OdArray_const_OdGeCurve2d__p_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdArray_const_OdGeCurve2d__p_OdObjectsAllocator val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_setitem(swigCPtr, index, OdArray_const_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(val).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator GetRange(int index, int count)
	{
		return new OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_GetRange(swigCPtr, index, count), cMemoryOwn: false);
	}

	public void Insert(int index, OdArray_const_OdGeCurve2d__p_OdObjectsAllocator x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_Insert(swigCPtr, index, OdArray_const_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(x).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator Repeat(OdArray_const_OdGeCurve2d__p_OdObjectsAllocator value, int count)
	{
		return new OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_Repeat(OdArray_const_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(value).Handle, count), cMemoryOwn: true);
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdArray_const_OdGeCurve2d__p_OdObjectsAllocator value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_Contains(swigCPtr, OdArray_const_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(value).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdArray_const_OdGeCurve2d__p_OdObjectsAllocator value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_IndexOf(swigCPtr, OdArray_const_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(value).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdArray_const_OdGeCurve2d__p_OdObjectsAllocator value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_LastIndexOf(swigCPtr, OdArray_const_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(value).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdArray_const_OdGeCurve2d__p_OdObjectsAllocator value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_2d_const_OdGeCurve2d__p_OdObjectsAllocator_Remove(swigCPtr, OdArray_const_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(value).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
