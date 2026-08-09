using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdBoolVector : IDisposable, IEnumerable, IList<bool>, ICollection<bool>, IEnumerable<bool>
{
	public class OdBoolVectorEnumerator : IEnumerator, IEnumerator<bool>, IDisposable
	{
		private OdBoolVector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public bool Current
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
				return (bool)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdBoolVectorEnumerator(OdBoolVector collection)
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

	public bool this[int index]
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
	public OdBoolVector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdBoolVector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdBoolVector()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdBoolVector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdBoolVector(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (bool item in c)
		{
			Add(item);
		}
	}

	public OdBoolVector()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBoolVector__SWIG_0(), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdBoolVector(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdBoolVector(OdBoolVector other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBoolVector__SWIG_1(getCPtr(other)), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdBoolVector(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdBoolVector(int capacity)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdBoolVector__SWIG_2(capacity), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdBoolVector(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(bool[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(bool[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, bool[] array, int arrayIndex, int count)
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

	IEnumerator<bool> IEnumerable<bool>.GetEnumerator()
	{
		return new OdBoolVectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdBoolVectorEnumerator(this);
	}

	public OdBoolVectorEnumerator GetEnumerator()
	{
		return new OdBoolVectorEnumerator(this);
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(bool x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_Add(swigCPtr, x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private bool getitemcopy(int index)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_getitemcopy(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private bool getitem(int index)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_getitem(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, bool val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_setitem(swigCPtr, index, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdBoolVector values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdBoolVector GetRange(int index, int count)
	{
		OdBoolVector result = new OdBoolVector(TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, bool x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_Insert(swigCPtr, index, x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdBoolVector values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdBoolVector Repeat(bool value, int count)
	{
		OdBoolVector result = new OdBoolVector(TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_Repeat(value, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdBoolVector values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(bool value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_Contains(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(bool value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_IndexOf(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(bool value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_LastIndexOf(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(bool value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdBoolVector_Remove(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
