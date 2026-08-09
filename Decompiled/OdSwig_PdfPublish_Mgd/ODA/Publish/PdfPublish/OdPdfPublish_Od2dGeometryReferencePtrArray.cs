using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_Od2dGeometryReferencePtrArray : IDisposable, IEnumerable, IList<OdPdfPublish_Od2dGeometryReference>, ICollection<OdPdfPublish_Od2dGeometryReference>, IEnumerable<OdPdfPublish_Od2dGeometryReference>
{
	public class OdPdfPublish_Od2dGeometryReferencePtrArrayEnumerator : IEnumerator, IEnumerator<OdPdfPublish_Od2dGeometryReference>, IDisposable
	{
		private OdPdfPublish_Od2dGeometryReferencePtrArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdPdfPublish_Od2dGeometryReference Current
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
				return (OdPdfPublish_Od2dGeometryReference)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdPdfPublish_Od2dGeometryReferencePtrArrayEnumerator(OdPdfPublish_Od2dGeometryReferencePtrArray collection)
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

	public OdPdfPublish_Od2dGeometryReference this[int index]
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
	public OdPdfPublish_Od2dGeometryReferencePtrArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_Od2dGeometryReferencePtrArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPdfPublish_Od2dGeometryReferencePtrArray()
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_Od2dGeometryReferencePtrArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPdfPublish_Od2dGeometryReferencePtrArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdPdfPublish_Od2dGeometryReference item in c)
		{
			Add(item);
		}
	}

	public OdPdfPublish_Od2dGeometryReferencePtrArray(bool bGCMemory_Own = false)
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_Od2dGeometryReferencePtrArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPdfPublish_Od2dGeometryReferencePtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPdfPublish_Od2dGeometryReferencePtrArray(OdPdfPublish_Od2dGeometryReferencePtrArray other, bool bGCMemory_Own = false)
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_Od2dGeometryReferencePtrArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPdfPublish_Od2dGeometryReferencePtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPdfPublish_Od2dGeometryReferencePtrArray(int capacity, bool bGCMemory_Own = false)
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_Od2dGeometryReferencePtrArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPdfPublish_Od2dGeometryReferencePtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdPdfPublish_Od2dGeometryReference[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdPdfPublish_Od2dGeometryReference[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdPdfPublish_Od2dGeometryReference[] array, int arrayIndex, int count)
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

	IEnumerator<OdPdfPublish_Od2dGeometryReference> IEnumerable<OdPdfPublish_Od2dGeometryReference>.GetEnumerator()
	{
		return new OdPdfPublish_Od2dGeometryReferencePtrArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdPdfPublish_Od2dGeometryReferencePtrArrayEnumerator(this);
	}

	public OdPdfPublish_Od2dGeometryReferencePtrArrayEnumerator GetEnumerator()
	{
		return new OdPdfPublish_Od2dGeometryReferencePtrArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_size(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_capacity(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_reserve(swigCPtr, n);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_resize(swigCPtr, logicalLength);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_Clear(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdPdfPublish_Od2dGeometryReference val)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_Add(swigCPtr, OdPdfPublish_Od2dGeometryReference.getCPtr(val));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdPdfPublish_Od2dGeometryReference getitemcopy(int index)
	{
		OdPdfPublish_Od2dGeometryReference rXObject = Helpers.GetRXObject<OdPdfPublish_Od2dGeometryReference>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private OdPdfPublish_Od2dGeometryReference getitem(int index)
	{
		OdPdfPublish_Od2dGeometryReference rXObject = Helpers.GetRXObject<OdPdfPublish_Od2dGeometryReference>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int index, OdPdfPublish_Od2dGeometryReference val)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_setitem(swigCPtr, index, OdPdfPublish_Od2dGeometryReference.getCPtr(val));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdPdfPublish_Od2dGeometryReferencePtrArray values)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_AddRange(swigCPtr, getCPtr(values));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPdfPublish_Od2dGeometryReferencePtrArray GetRange(int index, int count)
	{
		OdPdfPublish_Od2dGeometryReferencePtrArray result = Helpers.GetObject<OdPdfPublish_Od2dGeometryReferencePtrArray>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_GetRange(swigCPtr, index, count), bOwn: false, bTryAddToTransaction: false);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdPdfPublish_Od2dGeometryReference x)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_Insert(swigCPtr, index, OdPdfPublish_Od2dGeometryReference.getCPtr(x));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdPdfPublish_Od2dGeometryReferencePtrArray values)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_RemoveAt(swigCPtr, index);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_RemoveRange(swigCPtr, index, count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdPdfPublish_Od2dGeometryReferencePtrArray Repeat(OdPdfPublish_Od2dGeometryReference value, int count)
	{
		OdPdfPublish_Od2dGeometryReferencePtrArray result = Helpers.GetObject<OdPdfPublish_Od2dGeometryReferencePtrArray>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_Repeat(OdPdfPublish_Od2dGeometryReference.getCPtr(value), count), bOwn: false, bTryAddToTransaction: false);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_Reverse__SWIG_0(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdPdfPublish_Od2dGeometryReferencePtrArray values)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_SetRange(swigCPtr, index, getCPtr(values));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdPdfPublish_Od2dGeometryReference value)
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_Contains(swigCPtr, OdPdfPublish_Od2dGeometryReference.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdPdfPublish_Od2dGeometryReference value)
	{
		int result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_IndexOf(swigCPtr, OdPdfPublish_Od2dGeometryReference.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdPdfPublish_Od2dGeometryReference value)
	{
		int result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_LastIndexOf(swigCPtr, OdPdfPublish_Od2dGeometryReference.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdPdfPublish_Od2dGeometryReference value)
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReferencePtrArray_Remove(swigCPtr, OdPdfPublish_Od2dGeometryReference.getCPtr(value));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
