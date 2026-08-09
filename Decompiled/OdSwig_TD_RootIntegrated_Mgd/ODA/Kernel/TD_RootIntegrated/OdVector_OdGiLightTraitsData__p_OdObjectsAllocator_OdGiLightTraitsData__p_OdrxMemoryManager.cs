using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager : IDisposable, IEnumerable, IList<OdGiLightTraitsData>, ICollection<OdGiLightTraitsData>, IEnumerable<OdGiLightTraitsData>
{
	public class OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManagerEnumerator : IEnumerator, IEnumerator<OdGiLightTraitsData>, IDisposable
	{
		private OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdGiLightTraitsData Current
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
				return (OdGiLightTraitsData)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManagerEnumerator(OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager collection)
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

	public OdGiLightTraitsData this[int index]
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
	public OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdGiLightTraitsData item in c)
		{
			Add(item);
		}
	}

	public OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager__SWIG_0(), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager(OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager__SWIG_1(getCPtr(other)), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager(int capacity)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager__SWIG_2(capacity), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdGiLightTraitsData[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdGiLightTraitsData[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdGiLightTraitsData[] array, int arrayIndex, int count)
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

	IEnumerator<OdGiLightTraitsData> IEnumerable<OdGiLightTraitsData>.GetEnumerator()
	{
		return new OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManagerEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManagerEnumerator(this);
	}

	public OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManagerEnumerator GetEnumerator()
	{
		return new OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManagerEnumerator(this);
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdGiLightTraitsData x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_Add(swigCPtr, OdGiLightTraitsData.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdGiLightTraitsData getitemcopy(int index)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_getitemcopy(swigCPtr, index);
		OdGiLightTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiLightTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdGiLightTraitsData getitem(int index)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_getitem(swigCPtr, index);
		OdGiLightTraitsData result = ((intPtr == IntPtr.Zero) ? null : new OdGiLightTraitsData(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdGiLightTraitsData val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_setitem(swigCPtr, index, OdGiLightTraitsData.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdVectorOdGiLightTraitsDataPtr values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_AddRange(swigCPtr, OdVectorOdGiLightTraitsDataPtr.getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdVectorOdGiLightTraitsDataPtr GetRange(int index, int count)
	{
		OdVectorOdGiLightTraitsDataPtr result = new OdVectorOdGiLightTraitsDataPtr(TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdGiLightTraitsData x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_Insert(swigCPtr, index, OdGiLightTraitsData.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdVectorOdGiLightTraitsDataPtr values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_InsertRange(swigCPtr, index, OdVectorOdGiLightTraitsDataPtr.getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdVectorOdGiLightTraitsDataPtr Repeat(OdGiLightTraitsData value, int count)
	{
		OdVectorOdGiLightTraitsDataPtr result = new OdVectorOdGiLightTraitsDataPtr(TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_Repeat(OdGiLightTraitsData.getCPtr(value), count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdVectorOdGiLightTraitsDataPtr values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_SetRange(swigCPtr, index, OdVectorOdGiLightTraitsDataPtr.getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdGiLightTraitsData value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_Contains(swigCPtr, OdGiLightTraitsData.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdGiLightTraitsData value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_IndexOf(swigCPtr, OdGiLightTraitsData.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdGiLightTraitsData value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_LastIndexOf(swigCPtr, OdGiLightTraitsData.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdGiLightTraitsData value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdGiLightTraitsData__p_OdObjectsAllocator_OdGiLightTraitsData__p_OdrxMemoryManager_Remove(swigCPtr, OdGiLightTraitsData.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
