using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager : IDisposable, IEnumerable, IList<OdDbStub>, ICollection<OdDbStub>, IEnumerable<OdDbStub>
{
	public class OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManagerEnumerator : IEnumerator, IEnumerator<OdDbStub>, IDisposable
	{
		private OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdDbStub Current
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
				return (OdDbStub)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManagerEnumerator(OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager collection)
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

	public OdDbStub this[int index]
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
	public OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdDbStub item in c)
		{
			Add(item);
		}
	}

	public OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager__SWIG_0(), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager(OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager__SWIG_1(getCPtr(other)), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager(int capacity)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager__SWIG_2(capacity), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdDbStub[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdDbStub[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdDbStub[] array, int arrayIndex, int count)
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

	IEnumerator<OdDbStub> IEnumerable<OdDbStub>.GetEnumerator()
	{
		return new OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManagerEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManagerEnumerator(this);
	}

	public OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManagerEnumerator GetEnumerator()
	{
		return new OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManagerEnumerator(this);
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdDbStub x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_Add(swigCPtr, OdDbStub.getCPtr(x).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdDbStub getitemcopy(int index)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_getitemcopy(swigCPtr, index);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdDbStub getitem(int index)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_getitem(swigCPtr, index);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdDbStub val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_setitem(swigCPtr, index, OdDbStub.getCPtr(val).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdVectorOdDbStubPtr values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_AddRange(swigCPtr, OdVectorOdDbStubPtr.getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdVectorOdDbStubPtr GetRange(int index, int count)
	{
		OdVectorOdDbStubPtr result = new OdVectorOdDbStubPtr(TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdDbStub x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_Insert(swigCPtr, index, OdDbStub.getCPtr(x).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdVectorOdDbStubPtr values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_InsertRange(swigCPtr, index, OdVectorOdDbStubPtr.getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdVectorOdDbStubPtr Repeat(OdDbStub value, int count)
	{
		OdVectorOdDbStubPtr result = new OdVectorOdDbStubPtr(TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_Repeat(OdDbStub.getCPtr(value).Handle, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdVectorOdDbStubPtr values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_SetRange(swigCPtr, index, OdVectorOdDbStubPtr.getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdDbStub value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_Contains(swigCPtr, OdDbStub.getCPtr(value).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdDbStub value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_IndexOf(swigCPtr, OdDbStub.getCPtr(value).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdDbStub value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_LastIndexOf(swigCPtr, OdDbStub.getCPtr(value).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdDbStub value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdVector_OdDbStub__p_OdObjectsAllocator_OdDbStub__p_OdrxMemoryManager_Remove(swigCPtr, OdDbStub.getCPtr(value).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
