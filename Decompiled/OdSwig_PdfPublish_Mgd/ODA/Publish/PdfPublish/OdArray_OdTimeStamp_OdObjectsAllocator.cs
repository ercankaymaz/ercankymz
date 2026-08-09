using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdArray_OdTimeStamp_OdObjectsAllocator : IDisposable, IEnumerable, IList<OdTimeStamp>, ICollection<OdTimeStamp>, IEnumerable<OdTimeStamp>
{
	public class OdArray_OdTimeStamp_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<OdTimeStamp>, IDisposable
	{
		private OdArray_OdTimeStamp_OdObjectsAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdTimeStamp Current
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
				return (OdTimeStamp)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_OdTimeStamp_OdObjectsAllocatorEnumerator(OdArray_OdTimeStamp_OdObjectsAllocator collection)
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

	public OdTimeStamp this[int index]
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
	public OdArray_OdTimeStamp_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_OdTimeStamp_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_OdTimeStamp_OdObjectsAllocator()
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
					PdfPublish_GlobalsPINVOKE.delete_OdArray_OdTimeStamp_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_OdTimeStamp_OdObjectsAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdTimeStamp item in c)
		{
			Add(item);
		}
	}

	public OdArray_OdTimeStamp_OdObjectsAllocator(bool bGCMemory_Own = false)
		: this(PdfPublish_GlobalsPINVOKE.new_OdArray_OdTimeStamp_OdObjectsAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdTimeStamp_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdTimeStamp_OdObjectsAllocator(OdArray_OdTimeStamp_OdObjectsAllocator other, bool bGCMemory_Own = false)
		: this(PdfPublish_GlobalsPINVOKE.new_OdArray_OdTimeStamp_OdObjectsAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdTimeStamp_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdTimeStamp_OdObjectsAllocator(int capacity, bool bGCMemory_Own = false)
		: this(PdfPublish_GlobalsPINVOKE.new_OdArray_OdTimeStamp_OdObjectsAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdTimeStamp_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdTimeStamp[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdTimeStamp[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdTimeStamp[] array, int arrayIndex, int count)
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

	IEnumerator<OdTimeStamp> IEnumerable<OdTimeStamp>.GetEnumerator()
	{
		return new OdArray_OdTimeStamp_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_OdTimeStamp_OdObjectsAllocatorEnumerator(this);
	}

	public OdArray_OdTimeStamp_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_OdTimeStamp_OdObjectsAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_size(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_capacity(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_reserve(swigCPtr, n);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_resize(swigCPtr, logicalLength);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_Clear(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdTimeStamp val)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_Add(swigCPtr, OdTimeStamp.getCPtr(val));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdTimeStamp getitemcopy(int index)
	{
		OdTimeStamp result = new OdTimeStamp(PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdTimeStamp getitem(int index)
	{
		OdTimeStamp result = new OdTimeStamp(PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_getitem(swigCPtr, index), cMemoryOwn: false);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdTimeStamp val)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_setitem(swigCPtr, index, OdTimeStamp.getCPtr(val));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_OdTimeStamp_OdObjectsAllocator values)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_AddRange(swigCPtr, getCPtr(values));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdTimeStamp_OdObjectsAllocator GetRange(int index, int count)
	{
		OdArray_OdTimeStamp_OdObjectsAllocator result = new OdArray_OdTimeStamp_OdObjectsAllocator(PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdTimeStamp x)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_Insert(swigCPtr, index, OdTimeStamp.getCPtr(x));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_OdTimeStamp_OdObjectsAllocator values)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_InsertRange(swigCPtr, index, getCPtr(values));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_RemoveAt(swigCPtr, index);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_RemoveRange(swigCPtr, index, count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_OdTimeStamp_OdObjectsAllocator Repeat(OdTimeStamp value, int count)
	{
		OdArray_OdTimeStamp_OdObjectsAllocator result = new OdArray_OdTimeStamp_OdObjectsAllocator(PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_Repeat(OdTimeStamp.getCPtr(value), count), cMemoryOwn: false);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_Reverse__SWIG_0(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_Reverse__SWIG_1(swigCPtr, index, count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_OdTimeStamp_OdObjectsAllocator values)
	{
		PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdTimeStamp value)
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_Contains(swigCPtr, OdTimeStamp.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdTimeStamp value)
	{
		int result = PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_IndexOf(swigCPtr, OdTimeStamp.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdTimeStamp value)
	{
		int result = PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_LastIndexOf(swigCPtr, OdTimeStamp.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdTimeStamp value)
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdArray_OdTimeStamp_OdObjectsAllocator_Remove(swigCPtr, OdTimeStamp.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
