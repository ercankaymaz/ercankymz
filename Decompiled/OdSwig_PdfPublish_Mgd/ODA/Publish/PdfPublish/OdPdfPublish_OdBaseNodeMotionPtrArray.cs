using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdBaseNodeMotionPtrArray : IDisposable, IEnumerable, IList<OdPdfPublish_OdBaseNodeMotion>, ICollection<OdPdfPublish_OdBaseNodeMotion>, IEnumerable<OdPdfPublish_OdBaseNodeMotion>
{
	public class OdPdfPublish_OdBaseNodeMotionPtrArrayEnumerator : IEnumerator, IEnumerator<OdPdfPublish_OdBaseNodeMotion>, IDisposable
	{
		private OdPdfPublish_OdBaseNodeMotionPtrArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdPdfPublish_OdBaseNodeMotion Current
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
				return (OdPdfPublish_OdBaseNodeMotion)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdPdfPublish_OdBaseNodeMotionPtrArrayEnumerator(OdPdfPublish_OdBaseNodeMotionPtrArray collection)
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

	public OdPdfPublish_OdBaseNodeMotion this[int index]
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
	public OdPdfPublish_OdBaseNodeMotionPtrArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdBaseNodeMotionPtrArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPdfPublish_OdBaseNodeMotionPtrArray()
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdBaseNodeMotionPtrArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPdfPublish_OdBaseNodeMotionPtrArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdPdfPublish_OdBaseNodeMotion item in c)
		{
			Add(item);
		}
	}

	public OdPdfPublish_OdBaseNodeMotionPtrArray(bool bGCMemory_Own = false)
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdBaseNodeMotionPtrArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPdfPublish_OdBaseNodeMotionPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPdfPublish_OdBaseNodeMotionPtrArray(OdPdfPublish_OdBaseNodeMotionPtrArray other, bool bGCMemory_Own = false)
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdBaseNodeMotionPtrArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPdfPublish_OdBaseNodeMotionPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPdfPublish_OdBaseNodeMotionPtrArray(int capacity, bool bGCMemory_Own = false)
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdBaseNodeMotionPtrArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPdfPublish_OdBaseNodeMotionPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdPdfPublish_OdBaseNodeMotion[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdPdfPublish_OdBaseNodeMotion[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdPdfPublish_OdBaseNodeMotion[] array, int arrayIndex, int count)
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

	IEnumerator<OdPdfPublish_OdBaseNodeMotion> IEnumerable<OdPdfPublish_OdBaseNodeMotion>.GetEnumerator()
	{
		return new OdPdfPublish_OdBaseNodeMotionPtrArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdPdfPublish_OdBaseNodeMotionPtrArrayEnumerator(this);
	}

	public OdPdfPublish_OdBaseNodeMotionPtrArrayEnumerator GetEnumerator()
	{
		return new OdPdfPublish_OdBaseNodeMotionPtrArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_size(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_capacity(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_reserve(swigCPtr, n);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_resize(swigCPtr, logicalLength);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_Clear(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdPdfPublish_OdBaseNodeMotion val)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_Add(swigCPtr, OdPdfPublish_OdBaseNodeMotion.getCPtr(val));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdPdfPublish_OdBaseNodeMotion getitemcopy(int index)
	{
		OdPdfPublish_OdBaseNodeMotion result = Helpers.GetObject<OdPdfPublish_OdBaseNodeMotion>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: false);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdPdfPublish_OdBaseNodeMotion getitem(int index)
	{
		OdPdfPublish_OdBaseNodeMotion result = Helpers.GetObject<OdPdfPublish_OdBaseNodeMotion>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: false);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdPdfPublish_OdBaseNodeMotion val)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_setitem(swigCPtr, index, OdPdfPublish_OdBaseNodeMotion.getCPtr(val));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPdfPublish_OdBaseNodeMotionPtrArray GetRange(int index, int count)
	{
		OdPdfPublish_OdBaseNodeMotionPtrArray result = new OdPdfPublish_OdBaseNodeMotionPtrArray(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdPdfPublish_OdBaseNodeMotion x)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_Insert(swigCPtr, index, OdPdfPublish_OdBaseNodeMotion.getCPtr(x));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_RemoveAt(swigCPtr, index);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_RemoveRange(swigCPtr, index, count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdPdfPublish_OdBaseNodeMotionPtrArray Repeat(OdPdfPublish_OdBaseNodeMotion value, int count)
	{
		OdPdfPublish_OdBaseNodeMotionPtrArray result = new OdPdfPublish_OdBaseNodeMotionPtrArray(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_Repeat(OdPdfPublish_OdBaseNodeMotion.getCPtr(value), count), cMemoryOwn: false);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetRange(int index, OdPdfPublish_OdBaseNodeMotionPtrArray values)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_SetRange(swigCPtr, index, getCPtr(values));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdPdfPublish_OdBaseNodeMotion value)
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_Contains(swigCPtr, OdPdfPublish_OdBaseNodeMotion.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdPdfPublish_OdBaseNodeMotion value)
	{
		int result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_IndexOf(swigCPtr, OdPdfPublish_OdBaseNodeMotion.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdPdfPublish_OdBaseNodeMotion value)
	{
		int result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_LastIndexOf(swigCPtr, OdPdfPublish_OdBaseNodeMotion.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdPdfPublish_OdBaseNodeMotion value)
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBaseNodeMotionPtrArray_Remove(swigCPtr, OdPdfPublish_OdBaseNodeMotion.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
