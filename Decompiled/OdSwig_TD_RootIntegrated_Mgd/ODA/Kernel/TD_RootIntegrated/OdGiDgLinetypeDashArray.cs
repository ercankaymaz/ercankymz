using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDgLinetypeDashArray : IDisposable, IEnumerable, IList<OdGiDgLinetypeDash>, ICollection<OdGiDgLinetypeDash>, IEnumerable<OdGiDgLinetypeDash>
{
	public class OdGiDgLinetypeDashArrayEnumerator : IEnumerator, IEnumerator<OdGiDgLinetypeDash>, IDisposable
	{
		private OdGiDgLinetypeDashArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdGiDgLinetypeDash Current
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
				return (OdGiDgLinetypeDash)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdGiDgLinetypeDashArrayEnumerator(OdGiDgLinetypeDashArray collection)
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

	public OdGiDgLinetypeDash this[int index]
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
	public OdGiDgLinetypeDashArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDgLinetypeDashArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiDgLinetypeDashArray()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDgLinetypeDashArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiDgLinetypeDashArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdGiDgLinetypeDash item in c)
		{
			Add(item);
		}
	}

	public OdGiDgLinetypeDashArray(bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetypeDashArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdGiDgLinetypeDashArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDgLinetypeDashArray(OdGiDgLinetypeDashArray other, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetypeDashArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdGiDgLinetypeDashArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDgLinetypeDashArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetypeDashArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdGiDgLinetypeDashArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdGiDgLinetypeDash[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdGiDgLinetypeDash[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdGiDgLinetypeDash[] array, int arrayIndex, int count)
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

	IEnumerator<OdGiDgLinetypeDash> IEnumerable<OdGiDgLinetypeDash>.GetEnumerator()
	{
		return new OdGiDgLinetypeDashArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdGiDgLinetypeDashArrayEnumerator(this);
	}

	public OdGiDgLinetypeDashArrayEnumerator GetEnumerator()
	{
		return new OdGiDgLinetypeDashArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdGiDgLinetypeDash val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_Add(swigCPtr, OdGiDgLinetypeDash.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdGiDgLinetypeDash getitemcopy(int index)
	{
		OdGiDgLinetypeDash result = new OdGiDgLinetypeDash(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdGiDgLinetypeDash getitem(int index)
	{
		OdGiDgLinetypeDash result = new OdGiDgLinetypeDash(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdGiDgLinetypeDash val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_setitem(swigCPtr, index, OdGiDgLinetypeDash.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdGiDgLinetypeDashArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiDgLinetypeDashArray GetRange(int index, int count)
	{
		OdGiDgLinetypeDashArray result = new OdGiDgLinetypeDashArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdGiDgLinetypeDash x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_Insert(swigCPtr, index, OdGiDgLinetypeDash.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdGiDgLinetypeDashArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGiDgLinetypeDashArray Repeat(OdGiDgLinetypeDash value, int count)
	{
		OdGiDgLinetypeDashArray result = new OdGiDgLinetypeDashArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_Repeat(OdGiDgLinetypeDash.getCPtr(value), count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdGiDgLinetypeDashArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdGiDgLinetypeDash value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_Contains(swigCPtr, OdGiDgLinetypeDash.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdGiDgLinetypeDash value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_IndexOf(swigCPtr, OdGiDgLinetypeDash.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdGiDgLinetypeDash value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_LastIndexOf(swigCPtr, OdGiDgLinetypeDash.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdGiDgLinetypeDash value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeDashArray_Remove(swigCPtr, OdGiDgLinetypeDash.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
