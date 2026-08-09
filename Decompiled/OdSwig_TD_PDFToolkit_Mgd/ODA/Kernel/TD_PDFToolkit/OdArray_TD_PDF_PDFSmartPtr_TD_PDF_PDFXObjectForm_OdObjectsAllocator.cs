using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator : IDisposable, IEnumerable, IList<TD_PDF_PDFXObjectForm>, ICollection<TD_PDF_PDFXObjectForm>, IEnumerable<TD_PDF_PDFXObjectForm>
{
	public class OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<TD_PDF_PDFXObjectForm>, IDisposable
	{
		private OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public TD_PDF_PDFXObjectForm Current
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
				return (TD_PDF_PDFXObjectForm)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocatorEnumerator(OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator collection)
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

	public TD_PDF_PDFXObjectForm this[int index]
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
	public OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (TD_PDF_PDFXObjectForm item in c)
		{
			Add(item);
		}
	}

	public OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(bool bGCMemory_Own = false)
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator other, bool bGCMemory_Own = false)
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(int capacity, bool bGCMemory_Own = false)
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(TD_PDF_PDFXObjectForm[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(TD_PDF_PDFXObjectForm[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, TD_PDF_PDFXObjectForm[] array, int arrayIndex, int count)
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

	IEnumerator<TD_PDF_PDFXObjectForm> IEnumerable<TD_PDF_PDFXObjectForm>.GetEnumerator()
	{
		return new OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocatorEnumerator(this);
	}

	public OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_size(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_capacity(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_reserve(swigCPtr, n);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_resize(swigCPtr, logicalLength);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Clear(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(TD_PDF_PDFXObjectForm val)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Add(swigCPtr, TD_PDF_PDFXObjectForm.getCPtr(val));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private TD_PDF_PDFXObjectForm getitemcopy(int index)
	{
		TD_PDF_PDFXObjectForm result = Helpers.GetObject<TD_PDF_PDFXObjectForm>(TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private TD_PDF_PDFXObjectForm getitem(int index)
	{
		TD_PDF_PDFXObjectForm result = Helpers.GetObject<TD_PDF_PDFXObjectForm>(TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, TD_PDF_PDFXObjectForm val)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_setitem(swigCPtr, index, TD_PDF_PDFXObjectForm.getCPtr(val));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator values)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_AddRange(swigCPtr, getCPtr(values));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator GetRange(int index, int count)
	{
		OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator result = new OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, TD_PDF_PDFXObjectForm x)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Insert(swigCPtr, index, TD_PDF_PDFXObjectForm.getCPtr(x));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator values)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_RemoveAt(swigCPtr, index);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_RemoveRange(swigCPtr, index, count);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator Repeat(TD_PDF_PDFXObjectForm value, int count)
	{
		OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator result = new OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator(TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Repeat(TD_PDF_PDFXObjectForm.getCPtr(value), count), cMemoryOwn: false);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Reverse__SWIG_0(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator values)
	{
		TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(TD_PDF_PDFXObjectForm value)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Contains(swigCPtr, TD_PDF_PDFXObjectForm.getCPtr(value));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(TD_PDF_PDFXObjectForm value)
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_IndexOf(swigCPtr, TD_PDF_PDFXObjectForm.getCPtr(value));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(TD_PDF_PDFXObjectForm value)
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_LastIndexOf(swigCPtr, TD_PDF_PDFXObjectForm.getCPtr(value));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(TD_PDF_PDFXObjectForm value)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.OdArray_TD_PDF_PDFSmartPtr_TD_PDF_PDFXObjectForm_OdObjectsAllocator_Remove(swigCPtr, TD_PDF_PDFXObjectForm.getCPtr(value));
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
