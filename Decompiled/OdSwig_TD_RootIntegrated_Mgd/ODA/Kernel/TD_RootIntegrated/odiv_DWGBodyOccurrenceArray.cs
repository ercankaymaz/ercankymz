using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class odiv_DWGBodyOccurrenceArray : IDisposable, IEnumerable, IEnumerable<odiv_DWGBodyOccurrence>
{
	public class odiv_DWGBodyOccurrenceArrayEnumerator : IEnumerator, IEnumerator<odiv_DWGBodyOccurrence>, IDisposable
	{
		private odiv_DWGBodyOccurrenceArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public odiv_DWGBodyOccurrence Current
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
				return (odiv_DWGBodyOccurrence)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public odiv_DWGBodyOccurrenceArrayEnumerator(odiv_DWGBodyOccurrenceArray collection)
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

	public odiv_DWGBodyOccurrence this[int index]
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
	public odiv_DWGBodyOccurrenceArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(odiv_DWGBodyOccurrenceArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~odiv_DWGBodyOccurrenceArray()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_odiv_DWGBodyOccurrenceArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public odiv_DWGBodyOccurrenceArray(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (odiv_DWGBodyOccurrence item in c)
		{
			Add(item);
		}
	}

	public odiv_DWGBodyOccurrenceArray(IEnumerable<odiv_DWGBodyOccurrence> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (odiv_DWGBodyOccurrence item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(odiv_DWGBodyOccurrence[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(odiv_DWGBodyOccurrence[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, odiv_DWGBodyOccurrence[] array, int arrayIndex, int count)
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

	public odiv_DWGBodyOccurrence[] ToArray()
	{
		odiv_DWGBodyOccurrence[] array = new odiv_DWGBodyOccurrence[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<odiv_DWGBodyOccurrence> IEnumerable<odiv_DWGBodyOccurrence>.GetEnumerator()
	{
		return new odiv_DWGBodyOccurrenceArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new odiv_DWGBodyOccurrenceArrayEnumerator(this);
	}

	public odiv_DWGBodyOccurrenceArrayEnumerator GetEnumerator()
	{
		return new odiv_DWGBodyOccurrenceArrayEnumerator(this);
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(odiv_DWGBodyOccurrence x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_Add(swigCPtr, odiv_DWGBodyOccurrence.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public odiv_DWGBodyOccurrenceArray()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_odiv_DWGBodyOccurrenceArray__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public odiv_DWGBodyOccurrenceArray(odiv_DWGBodyOccurrenceArray other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_odiv_DWGBodyOccurrenceArray__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public odiv_DWGBodyOccurrenceArray(int capacity)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_odiv_DWGBodyOccurrenceArray__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private odiv_DWGBodyOccurrence getitemcopy(int index)
	{
		odiv_DWGBodyOccurrence result = new odiv_DWGBodyOccurrence(TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private odiv_DWGBodyOccurrence getitem(int index)
	{
		odiv_DWGBodyOccurrence result = new odiv_DWGBodyOccurrence(TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, odiv_DWGBodyOccurrence val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_setitem(swigCPtr, index, odiv_DWGBodyOccurrence.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(odiv_DWGBodyOccurrenceArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public odiv_DWGBodyOccurrenceArray GetRange(int index, int count)
	{
		return new odiv_DWGBodyOccurrenceArray(TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_GetRange(swigCPtr, index, count), cMemoryOwn: true);
	}

	public void Insert(int index, odiv_DWGBodyOccurrence x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_Insert(swigCPtr, index, odiv_DWGBodyOccurrence.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, odiv_DWGBodyOccurrenceArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static odiv_DWGBodyOccurrenceArray Repeat(odiv_DWGBodyOccurrence value, int count)
	{
		return new odiv_DWGBodyOccurrenceArray(TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_Repeat(odiv_DWGBodyOccurrence.getCPtr(value), count), cMemoryOwn: true);
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, odiv_DWGBodyOccurrenceArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.odiv_DWGBodyOccurrenceArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
