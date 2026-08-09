using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdUInt8Vector : IDisposable, IEnumerable, IList<byte>, ICollection<byte>, IEnumerable<byte>
{
	public class OdUInt8VectorEnumerator : IEnumerator, IEnumerator<byte>, IDisposable
	{
		private OdUInt8Vector collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public byte Current
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
				return (byte)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdUInt8VectorEnumerator(OdUInt8Vector collection)
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

	public byte this[int index]
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
	public OdUInt8Vector(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdUInt8Vector obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdUInt8Vector()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdUInt8Vector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdUInt8Vector(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (byte item in c)
		{
			Add(item);
		}
	}

	public OdUInt8Vector()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdUInt8Vector__SWIG_0(), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdUInt8Vector(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdUInt8Vector(OdUInt8Vector other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdUInt8Vector__SWIG_1(getCPtr(other)), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdUInt8Vector(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdUInt8Vector(int capacity)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdUInt8Vector__SWIG_2(capacity), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdUInt8Vector(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(byte[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(byte[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, byte[] array, int arrayIndex, int count)
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

	IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
	{
		return new OdUInt8VectorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdUInt8VectorEnumerator(this);
	}

	public OdUInt8VectorEnumerator GetEnumerator()
	{
		return new OdUInt8VectorEnumerator(this);
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(byte x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_Add(swigCPtr, x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private byte getitemcopy(int index)
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_getitemcopy(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private byte getitem(int index)
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_getitem(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, byte val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_setitem(swigCPtr, index, val);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdUInt8Vector values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdUInt8Vector GetRange(int index, int count)
	{
		OdUInt8Vector result = new OdUInt8Vector(TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, byte x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_Insert(swigCPtr, index, x);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdUInt8Vector values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdUInt8Vector Repeat(byte value, int count)
	{
		OdUInt8Vector result = new OdUInt8Vector(TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_Repeat(value, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdUInt8Vector values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(byte value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_Contains(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(byte value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_IndexOf(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(byte value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_LastIndexOf(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(byte value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdUInt8Vector_Remove(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
