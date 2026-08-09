using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class odiv_DWGBodyRecordArray : IDisposable, IEnumerable, IEnumerable<odiv_DWGBodyRecord>
{
	public class odiv_DWGBodyRecordArrayEnumerator : IEnumerator, IEnumerator<odiv_DWGBodyRecord>, IDisposable
	{
		private odiv_DWGBodyRecordArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public odiv_DWGBodyRecord Current
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
				return (odiv_DWGBodyRecord)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public odiv_DWGBodyRecordArrayEnumerator(odiv_DWGBodyRecordArray collection)
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

	public odiv_DWGBodyRecord this[int index]
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
	public odiv_DWGBodyRecordArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(odiv_DWGBodyRecordArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~odiv_DWGBodyRecordArray()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_odiv_DWGBodyRecordArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public odiv_DWGBodyRecordArray(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (odiv_DWGBodyRecord item in c)
		{
			Add(item);
		}
	}

	public odiv_DWGBodyRecordArray(IEnumerable<odiv_DWGBodyRecord> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (odiv_DWGBodyRecord item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(odiv_DWGBodyRecord[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(odiv_DWGBodyRecord[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, odiv_DWGBodyRecord[] array, int arrayIndex, int count)
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

	public odiv_DWGBodyRecord[] ToArray()
	{
		odiv_DWGBodyRecord[] array = new odiv_DWGBodyRecord[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<odiv_DWGBodyRecord> IEnumerable<odiv_DWGBodyRecord>.GetEnumerator()
	{
		return new odiv_DWGBodyRecordArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new odiv_DWGBodyRecordArrayEnumerator(this);
	}

	public odiv_DWGBodyRecordArrayEnumerator GetEnumerator()
	{
		return new odiv_DWGBodyRecordArrayEnumerator(this);
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(odiv_DWGBodyRecord x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_Add(swigCPtr, odiv_DWGBodyRecord.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public odiv_DWGBodyRecordArray()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_odiv_DWGBodyRecordArray__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public odiv_DWGBodyRecordArray(odiv_DWGBodyRecordArray other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_odiv_DWGBodyRecordArray__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public odiv_DWGBodyRecordArray(int capacity)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_odiv_DWGBodyRecordArray__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private odiv_DWGBodyRecord getitemcopy(int index)
	{
		odiv_DWGBodyRecord result = new odiv_DWGBodyRecord(TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private odiv_DWGBodyRecord getitem(int index)
	{
		odiv_DWGBodyRecord result = new odiv_DWGBodyRecord(TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, odiv_DWGBodyRecord val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_setitem(swigCPtr, index, odiv_DWGBodyRecord.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(odiv_DWGBodyRecordArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public odiv_DWGBodyRecordArray GetRange(int index, int count)
	{
		return new odiv_DWGBodyRecordArray(TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_GetRange(swigCPtr, index, count), cMemoryOwn: true);
	}

	public void Insert(int index, odiv_DWGBodyRecord x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_Insert(swigCPtr, index, odiv_DWGBodyRecord.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, odiv_DWGBodyRecordArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static odiv_DWGBodyRecordArray Repeat(odiv_DWGBodyRecord value, int count)
	{
		return new odiv_DWGBodyRecordArray(TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_Repeat(odiv_DWGBodyRecord.getCPtr(value), count), cMemoryOwn: true);
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, odiv_DWGBodyRecordArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyRecordArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
