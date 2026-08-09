using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcCrossingPointsCrvIntersectionArray : IDisposable, IEnumerable, IList<OdPrcCrossingPointsCrvIntersection>, ICollection<OdPrcCrossingPointsCrvIntersection>, IEnumerable<OdPrcCrossingPointsCrvIntersection>
{
	public class OdPrcCrossingPointsCrvIntersectionArrayEnumerator : IEnumerator, IEnumerator<OdPrcCrossingPointsCrvIntersection>, IDisposable
	{
		private OdPrcCrossingPointsCrvIntersectionArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdPrcCrossingPointsCrvIntersection Current
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
				return (OdPrcCrossingPointsCrvIntersection)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdPrcCrossingPointsCrvIntersectionArrayEnumerator(OdPrcCrossingPointsCrvIntersectionArray collection)
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

	public OdPrcCrossingPointsCrvIntersection this[int index]
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
	public OdPrcCrossingPointsCrvIntersectionArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcCrossingPointsCrvIntersectionArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcCrossingPointsCrvIntersectionArray()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcCrossingPointsCrvIntersectionArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcCrossingPointsCrvIntersectionArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdPrcCrossingPointsCrvIntersection item in c)
		{
			Add(item);
		}
	}

	public OdPrcCrossingPointsCrvIntersectionArray(bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcCrossingPointsCrvIntersectionArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcCrossingPointsCrvIntersectionArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcCrossingPointsCrvIntersectionArray(OdPrcCrossingPointsCrvIntersectionArray other, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcCrossingPointsCrvIntersectionArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcCrossingPointsCrvIntersectionArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcCrossingPointsCrvIntersectionArray(int capacity, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcCrossingPointsCrvIntersectionArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcCrossingPointsCrvIntersectionArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdPrcCrossingPointsCrvIntersection[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdPrcCrossingPointsCrvIntersection[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdPrcCrossingPointsCrvIntersection[] array, int arrayIndex, int count)
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

	IEnumerator<OdPrcCrossingPointsCrvIntersection> IEnumerable<OdPrcCrossingPointsCrvIntersection>.GetEnumerator()
	{
		return new OdPrcCrossingPointsCrvIntersectionArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdPrcCrossingPointsCrvIntersectionArrayEnumerator(this);
	}

	public OdPrcCrossingPointsCrvIntersectionArrayEnumerator GetEnumerator()
	{
		return new OdPrcCrossingPointsCrvIntersectionArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_size(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_capacity(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_reserve(swigCPtr, n);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_resize(swigCPtr, logicalLength);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_Clear(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdPrcCrossingPointsCrvIntersection val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_Add(swigCPtr, OdPrcCrossingPointsCrvIntersection.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdPrcCrossingPointsCrvIntersection getitemcopy(int index)
	{
		OdPrcCrossingPointsCrvIntersection result = new OdPrcCrossingPointsCrvIntersection(OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdPrcCrossingPointsCrvIntersection getitem(int index)
	{
		OdPrcCrossingPointsCrvIntersection result = new OdPrcCrossingPointsCrvIntersection(OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdPrcCrossingPointsCrvIntersection val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_setitem(swigCPtr, index, OdPrcCrossingPointsCrvIntersection.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdPrcCrossingPointsCrvIntersectionArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_AddRange(swigCPtr, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcCrossingPointsCrvIntersectionArray GetRange(int index, int count)
	{
		OdPrcCrossingPointsCrvIntersectionArray result = new OdPrcCrossingPointsCrvIntersectionArray(OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdPrcCrossingPointsCrvIntersection x)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_Insert(swigCPtr, index, OdPrcCrossingPointsCrvIntersection.getCPtr(x));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdPrcCrossingPointsCrvIntersectionArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_RemoveAt(swigCPtr, index);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_RemoveRange(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdPrcCrossingPointsCrvIntersectionArray Repeat(OdPrcCrossingPointsCrvIntersection value, int count)
	{
		OdPrcCrossingPointsCrvIntersectionArray result = new OdPrcCrossingPointsCrvIntersectionArray(OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_Repeat(OdPrcCrossingPointsCrvIntersection.getCPtr(value), count), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_Reverse__SWIG_0(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdPrcCrossingPointsCrvIntersectionArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_SetRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdPrcCrossingPointsCrvIntersection value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_Contains(swigCPtr, OdPrcCrossingPointsCrvIntersection.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdPrcCrossingPointsCrvIntersection value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_IndexOf(swigCPtr, OdPrcCrossingPointsCrvIntersection.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdPrcCrossingPointsCrvIntersection value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_LastIndexOf(swigCPtr, OdPrcCrossingPointsCrvIntersection.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdPrcCrossingPointsCrvIntersection value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCrossingPointsCrvIntersectionArray_Remove(swigCPtr, OdPrcCrossingPointsCrvIntersection.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
