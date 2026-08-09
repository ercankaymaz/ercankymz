using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDataCellArray : IDisposable, IEnumerable, IList<OdDbDataCell>, ICollection<OdDbDataCell>, IEnumerable<OdDbDataCell>
{
	public class OdDbDataCellArrayEnumerator : IEnumerator, IEnumerator<OdDbDataCell>, IDisposable
	{
		private OdDbDataCellArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdDbDataCell Current
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
				return (OdDbDataCell)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdDbDataCellArrayEnumerator(OdDbDataCellArray collection)
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

	public OdDbDataCell this[int index]
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
	public OdDbDataCellArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDataCellArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbDataCellArray()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDataCellArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbDataCellArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdDbDataCell item in c)
		{
			Add(item);
		}
	}

	public OdDbDataCellArray(bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDataCellArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdDbDataCellArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDataCellArray(OdDbDataCellArray other, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDataCellArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdDbDataCellArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDataCellArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDataCellArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdDbDataCellArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdDbDataCell[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdDbDataCell[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdDbDataCell[] array, int arrayIndex, int count)
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

	IEnumerator<OdDbDataCell> IEnumerable<OdDbDataCell>.GetEnumerator()
	{
		return new OdDbDataCellArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdDbDataCellArrayEnumerator(this);
	}

	public OdDbDataCellArrayEnumerator GetEnumerator()
	{
		return new OdDbDataCellArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_size(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_capacity(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_reserve(swigCPtr, n);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_resize(swigCPtr, logicalLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_Clear(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdDbDataCell val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_Add(swigCPtr, OdDbDataCell.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdDbDataCell getitemcopy(int index)
	{
		OdDbDataCell rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataCell>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private OdDbDataCell getitem(int index)
	{
		OdDbDataCell rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDataCell>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int index, OdDbDataCell val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_setitem(swigCPtr, index, OdDbDataCell.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdDbDataCellArray values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDataCellArray GetRange(int index, int count)
	{
		OdDbDataCellArray result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbDataCellArray>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_GetRange(swigCPtr, index, count), bOwn: false, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdDbDataCell x)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_Insert(swigCPtr, index, OdDbDataCell.getCPtr(x));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdDbDataCellArray values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_RemoveAt(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_RemoveRange(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbDataCellArray Repeat(OdDbDataCell value, int count)
	{
		OdDbDataCellArray result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbDataCellArray>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_Repeat(OdDbDataCell.getCPtr(value), count), bOwn: false, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_Reverse__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdDbDataCellArray values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdDbDataCell value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_Contains(swigCPtr, OdDbDataCell.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdDbDataCell value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_IndexOf(swigCPtr, OdDbDataCell.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdDbDataCell value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_LastIndexOf(swigCPtr, OdDbDataCell.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdDbDataCell value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDataCellArray_Remove(swigCPtr, OdDbDataCell.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
