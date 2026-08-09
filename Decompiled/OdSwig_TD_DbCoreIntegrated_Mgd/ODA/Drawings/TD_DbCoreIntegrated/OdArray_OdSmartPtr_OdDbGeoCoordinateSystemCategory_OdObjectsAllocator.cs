using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator : IDisposable, IEnumerable, IList<OdDbGeoCoordinateSystemCategory>, ICollection<OdDbGeoCoordinateSystemCategory>, IEnumerable<OdDbGeoCoordinateSystemCategory>
{
	public class OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<OdDbGeoCoordinateSystemCategory>, IDisposable
	{
		private OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdDbGeoCoordinateSystemCategory Current
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
				return (OdDbGeoCoordinateSystemCategory)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocatorEnumerator(OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator collection)
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

	public OdDbGeoCoordinateSystemCategory this[int index]
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
	public OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdDbGeoCoordinateSystemCategory item in c)
		{
			Add(item);
		}
	}

	public OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator(bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator(OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator other, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator(int capacity, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdDbGeoCoordinateSystemCategory[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdDbGeoCoordinateSystemCategory[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdDbGeoCoordinateSystemCategory[] array, int arrayIndex, int count)
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

	IEnumerator<OdDbGeoCoordinateSystemCategory> IEnumerable<OdDbGeoCoordinateSystemCategory>.GetEnumerator()
	{
		return new OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocatorEnumerator(this);
	}

	public OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_size(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_capacity(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_reserve(swigCPtr, n);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_resize(swigCPtr, logicalLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_Clear(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdDbGeoCoordinateSystemCategory val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_Add(swigCPtr, OdDbGeoCoordinateSystemCategory.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdDbGeoCoordinateSystemCategory getitemcopy(int index)
	{
		OdDbGeoCoordinateSystemCategory rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemCategory>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private OdDbGeoCoordinateSystemCategory getitem(int index)
	{
		OdDbGeoCoordinateSystemCategory rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGeoCoordinateSystemCategory>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int index, OdDbGeoCoordinateSystemCategory val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_setitem(swigCPtr, index, OdDbGeoCoordinateSystemCategory.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_AddRange(swigCPtr, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator GetRange(int index, int count)
	{
		OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_GetRange(swigCPtr, index, count), bOwn: false, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdDbGeoCoordinateSystemCategory x)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_Insert(swigCPtr, index, OdDbGeoCoordinateSystemCategory.getCPtr(x));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_RemoveAt(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_RemoveRange(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator Repeat(OdDbGeoCoordinateSystemCategory value, int count)
	{
		OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_Repeat(OdDbGeoCoordinateSystemCategory.getCPtr(value), count), bOwn: false, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_Reverse__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdDbGeoCoordinateSystemCategory value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_Contains(swigCPtr, OdDbGeoCoordinateSystemCategory.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdDbGeoCoordinateSystemCategory value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_IndexOf(swigCPtr, OdDbGeoCoordinateSystemCategory.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdDbGeoCoordinateSystemCategory value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_LastIndexOf(swigCPtr, OdDbGeoCoordinateSystemCategory.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdDbGeoCoordinateSystemCategory value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdSmartPtr_OdDbGeoCoordinateSystemCategory_OdObjectsAllocator_Remove(swigCPtr, OdDbGeoCoordinateSystemCategory.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
