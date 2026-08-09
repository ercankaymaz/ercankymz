using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbEntityPtrArray : IDisposable, IEnumerable, IList<OdDbEntity>, ICollection<OdDbEntity>, IEnumerable<OdDbEntity>
{
	public class OdDbEntityPtrArrayEnumerator : IEnumerator, IEnumerator<OdDbEntity>, IDisposable
	{
		private OdDbEntityPtrArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdDbEntity Current
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
				return (OdDbEntity)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdDbEntityPtrArrayEnumerator(OdDbEntityPtrArray collection)
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

	public OdDbEntity this[int index]
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
	public OdDbEntityPtrArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbEntityPtrArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbEntityPtrArray()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbEntityPtrArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbEntityPtrArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdDbEntity item in c)
		{
			Add(item);
		}
	}

	public OdDbEntityPtrArray(bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbEntityPtrArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdDbEntityPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbEntityPtrArray(OdDbEntityPtrArray other, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbEntityPtrArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdDbEntityPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbEntityPtrArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbEntityPtrArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdDbEntityPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdDbEntity[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdDbEntity[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdDbEntity[] array, int arrayIndex, int count)
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

	IEnumerator<OdDbEntity> IEnumerable<OdDbEntity>.GetEnumerator()
	{
		return new OdDbEntityPtrArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdDbEntityPtrArrayEnumerator(this);
	}

	public OdDbEntityPtrArrayEnumerator GetEnumerator()
	{
		return new OdDbEntityPtrArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_size(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_capacity(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_reserve(swigCPtr, n);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_resize(swigCPtr, logicalLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_Clear(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdDbEntity val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_Add(swigCPtr, OdDbEntity.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdDbEntity getitemcopy(int index)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private OdDbEntity getitem(int index)
	{
		OdDbEntity rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int index, OdDbEntity val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_setitem(swigCPtr, index, OdDbEntity.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdDbEntityPtrArray values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbEntityPtrArray GetRange(int index, int count)
	{
		OdDbEntityPtrArray result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbEntityPtrArray>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_GetRange(swigCPtr, index, count), bOwn: false, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdDbEntity x)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_Insert(swigCPtr, index, OdDbEntity.getCPtr(x));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdDbEntityPtrArray values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_RemoveAt(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_RemoveRange(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbEntityPtrArray Repeat(OdDbEntity value, int count)
	{
		OdDbEntityPtrArray result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbEntityPtrArray>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_Repeat(OdDbEntity.getCPtr(value), count), bOwn: false, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_Reverse__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdDbEntityPtrArray values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdDbEntity value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_Contains(swigCPtr, OdDbEntity.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdDbEntity value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_IndexOf(swigCPtr, OdDbEntity.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdDbEntity value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_LastIndexOf(swigCPtr, OdDbEntity.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdDbEntity value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbEntityPtrArray_Remove(swigCPtr, OdDbEntity.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
