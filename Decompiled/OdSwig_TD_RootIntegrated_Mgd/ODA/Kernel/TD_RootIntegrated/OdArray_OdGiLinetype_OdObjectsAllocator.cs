using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdArray_OdGiLinetype_OdObjectsAllocator : IDisposable, IEnumerable, IList<OdGiLinetype>, ICollection<OdGiLinetype>, IEnumerable<OdGiLinetype>
{
	public class OdArray_OdGiLinetype_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<OdGiLinetype>, IDisposable
	{
		private OdArray_OdGiLinetype_OdObjectsAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdGiLinetype Current
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
				return (OdGiLinetype)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_OdGiLinetype_OdObjectsAllocatorEnumerator(OdArray_OdGiLinetype_OdObjectsAllocator collection)
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

	public OdGiLinetype this[int index]
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
	public OdArray_OdGiLinetype_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_OdGiLinetype_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_OdGiLinetype_OdObjectsAllocator()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdArray_OdGiLinetype_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_OdGiLinetype_OdObjectsAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdGiLinetype item in c)
		{
			Add(item);
		}
	}

	public OdArray_OdGiLinetype_OdObjectsAllocator(bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_OdGiLinetype_OdObjectsAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdGiLinetype_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdGiLinetype_OdObjectsAllocator(OdArray_OdGiLinetype_OdObjectsAllocator other, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_OdGiLinetype_OdObjectsAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdGiLinetype_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdGiLinetype_OdObjectsAllocator(int capacity, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_OdGiLinetype_OdObjectsAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdGiLinetype_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdGiLinetype[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdGiLinetype[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdGiLinetype[] array, int arrayIndex, int count)
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

	IEnumerator<OdGiLinetype> IEnumerable<OdGiLinetype>.GetEnumerator()
	{
		return new OdArray_OdGiLinetype_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_OdGiLinetype_OdObjectsAllocatorEnumerator(this);
	}

	public OdArray_OdGiLinetype_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_OdGiLinetype_OdObjectsAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdGiLinetype val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_Add(swigCPtr, OdGiLinetype.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdGiLinetype getitemcopy(int index)
	{
		OdGiLinetype result = new OdGiLinetype(TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdGiLinetype getitem(int index)
	{
		OdGiLinetype result = new OdGiLinetype(TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdGiLinetype val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_setitem(swigCPtr, index, OdGiLinetype.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_OdGiLinetype_OdObjectsAllocator values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdGiLinetype_OdObjectsAllocator GetRange(int index, int count)
	{
		OdArray_OdGiLinetype_OdObjectsAllocator result = new OdArray_OdGiLinetype_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdGiLinetype x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_Insert(swigCPtr, index, OdGiLinetype.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_OdGiLinetype_OdObjectsAllocator values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_OdGiLinetype_OdObjectsAllocator Repeat(OdGiLinetype value, int count)
	{
		OdArray_OdGiLinetype_OdObjectsAllocator result = new OdArray_OdGiLinetype_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_Repeat(OdGiLinetype.getCPtr(value), count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_OdGiLinetype_OdObjectsAllocator values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdGiLinetype value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_Contains(swigCPtr, OdGiLinetype.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdGiLinetype value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_IndexOf(swigCPtr, OdGiLinetype.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdGiLinetype value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_LastIndexOf(swigCPtr, OdGiLinetype.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdGiLinetype value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiLinetype_OdObjectsAllocator_Remove(swigCPtr, OdGiLinetype.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
