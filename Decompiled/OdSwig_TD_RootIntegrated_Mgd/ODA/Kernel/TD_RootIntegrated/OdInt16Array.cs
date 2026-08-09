using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdInt16Array : IDisposable, IEnumerable, IList<short>, ICollection<short>, IEnumerable<short>
{
	public class OdInt16ArrayEnumerator : IEnumerator, IEnumerator<short>, IDisposable
	{
		private OdInt16Array collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public short Current
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
				return (short)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdInt16ArrayEnumerator(OdInt16Array collection)
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

	public short this[int index]
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
	public OdInt16Array(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdInt16Array obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdInt16Array()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdInt16Array(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdInt16Array(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (short item in c)
		{
			Add(item);
		}
	}

	public OdInt16Array(bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdInt16Array__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdInt16Array(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdInt16Array(OdInt16Array other, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdInt16Array__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdInt16Array(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdInt16Array(int capacity, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdInt16Array__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdInt16Array(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(short[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(short[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, short[] array, int arrayIndex, int count)
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

	IEnumerator<short> IEnumerable<short>.GetEnumerator()
	{
		return new OdInt16ArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdInt16ArrayEnumerator(this);
	}

	public OdInt16ArrayEnumerator GetEnumerator()
	{
		return new OdInt16ArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(short val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_Add(swigCPtr, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private short getitemcopy(int index)
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_getitemcopy(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private short getitem(int index)
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_getitem(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, short val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_setitem(swigCPtr, index, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdInt16Array values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdInt16Array GetRange(int index, int count)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_GetRange(swigCPtr, index, count);
		OdInt16Array result = ((intPtr == IntPtr.Zero) ? null : new OdInt16Array(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, short x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_Insert(swigCPtr, index, x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdInt16Array values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdInt16Array Repeat(short value, int count)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_Repeat(value, count);
		OdInt16Array result = ((intPtr == IntPtr.Zero) ? null : new OdInt16Array(intPtr, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdInt16Array values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(short value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_Contains(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(short value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_IndexOf(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(short value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_LastIndexOf(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(short value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdInt16Array_Remove(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
