using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbDynBlockReferencePropertyArray : IDisposable, IEnumerable, IList<OdDbDynBlockReferenceProperty>, ICollection<OdDbDynBlockReferenceProperty>, IEnumerable<OdDbDynBlockReferenceProperty>
{
	public class OdDbDynBlockReferencePropertyArrayEnumerator : IEnumerator, IEnumerator<OdDbDynBlockReferenceProperty>, IDisposable
	{
		private OdDbDynBlockReferencePropertyArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdDbDynBlockReferenceProperty Current
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
				return (OdDbDynBlockReferenceProperty)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdDbDynBlockReferencePropertyArrayEnumerator(OdDbDynBlockReferencePropertyArray collection)
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

	public OdDbDynBlockReferenceProperty this[int index]
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
	public OdDbDynBlockReferencePropertyArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbDynBlockReferencePropertyArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbDynBlockReferencePropertyArray()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbDynBlockReferencePropertyArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbDynBlockReferencePropertyArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdDbDynBlockReferenceProperty item in c)
		{
			Add(item);
		}
	}

	public OdDbDynBlockReferencePropertyArray(bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDynBlockReferencePropertyArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdDbDynBlockReferencePropertyArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDynBlockReferencePropertyArray(OdDbDynBlockReferencePropertyArray other, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDynBlockReferencePropertyArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdDbDynBlockReferencePropertyArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDynBlockReferencePropertyArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbDynBlockReferencePropertyArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdDbDynBlockReferencePropertyArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdDbDynBlockReferenceProperty[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdDbDynBlockReferenceProperty[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdDbDynBlockReferenceProperty[] array, int arrayIndex, int count)
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

	IEnumerator<OdDbDynBlockReferenceProperty> IEnumerable<OdDbDynBlockReferenceProperty>.GetEnumerator()
	{
		return new OdDbDynBlockReferencePropertyArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdDbDynBlockReferencePropertyArrayEnumerator(this);
	}

	public OdDbDynBlockReferencePropertyArrayEnumerator GetEnumerator()
	{
		return new OdDbDynBlockReferencePropertyArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_size(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_capacity(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_reserve(swigCPtr, n);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_resize(swigCPtr, logicalLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_Clear(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdDbDynBlockReferenceProperty val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_Add(swigCPtr, OdDbDynBlockReferenceProperty.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdDbDynBlockReferenceProperty getitemcopy(int index)
	{
		OdDbDynBlockReferenceProperty rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDynBlockReferenceProperty>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private OdDbDynBlockReferenceProperty getitem(int index)
	{
		OdDbDynBlockReferenceProperty rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDynBlockReferenceProperty>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int index, OdDbDynBlockReferenceProperty val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_setitem(swigCPtr, index, OdDbDynBlockReferenceProperty.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbDynBlockReferencePropertyArray GetRange(int index, int count)
	{
		OdDbDynBlockReferencePropertyArray result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbDynBlockReferencePropertyArray>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_GetRange(swigCPtr, index, count), bOwn: false, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdDbDynBlockReferenceProperty x)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_Insert(swigCPtr, index, OdDbDynBlockReferenceProperty.getCPtr(x));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_RemoveAt(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_RemoveRange(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdDbDynBlockReferencePropertyArray Repeat(OdDbDynBlockReferenceProperty value, int count)
	{
		OdDbDynBlockReferencePropertyArray result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbDynBlockReferencePropertyArray>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_Repeat(OdDbDynBlockReferenceProperty.getCPtr(value), count), bOwn: false, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetRange(int index, OdDbDynBlockReferencePropertyArray values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdDbDynBlockReferenceProperty value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_Contains(swigCPtr, OdDbDynBlockReferenceProperty.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdDbDynBlockReferenceProperty value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_IndexOf(swigCPtr, OdDbDynBlockReferenceProperty.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdDbDynBlockReferenceProperty value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_LastIndexOf(swigCPtr, OdDbDynBlockReferenceProperty.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdDbDynBlockReferenceProperty value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbDynBlockReferencePropertyArray_Remove(swigCPtr, OdDbDynBlockReferenceProperty.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
