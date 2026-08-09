using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcContentExtendedEntityReferencePtrArray : IDisposable, IEnumerable, IList<OdPrcContentExtendedEntityReference>, ICollection<OdPrcContentExtendedEntityReference>, IEnumerable<OdPrcContentExtendedEntityReference>
{
	public class OdPrcContentExtendedEntityReferencePtrArrayEnumerator : IEnumerator, IEnumerator<OdPrcContentExtendedEntityReference>, IDisposable
	{
		private OdPrcContentExtendedEntityReferencePtrArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdPrcContentExtendedEntityReference Current
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
				return (OdPrcContentExtendedEntityReference)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdPrcContentExtendedEntityReferencePtrArrayEnumerator(OdPrcContentExtendedEntityReferencePtrArray collection)
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

	public OdPrcContentExtendedEntityReference this[int index]
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
	public OdPrcContentExtendedEntityReferencePtrArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcContentExtendedEntityReferencePtrArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcContentExtendedEntityReferencePtrArray()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcContentExtendedEntityReferencePtrArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcContentExtendedEntityReferencePtrArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdPrcContentExtendedEntityReference item in c)
		{
			Add(item);
		}
	}

	public OdPrcContentExtendedEntityReferencePtrArray(bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcContentExtendedEntityReferencePtrArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcContentExtendedEntityReferencePtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcContentExtendedEntityReferencePtrArray(OdPrcContentExtendedEntityReferencePtrArray other, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcContentExtendedEntityReferencePtrArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcContentExtendedEntityReferencePtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcContentExtendedEntityReferencePtrArray(int capacity, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcContentExtendedEntityReferencePtrArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcContentExtendedEntityReferencePtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdPrcContentExtendedEntityReference[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdPrcContentExtendedEntityReference[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdPrcContentExtendedEntityReference[] array, int arrayIndex, int count)
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

	IEnumerator<OdPrcContentExtendedEntityReference> IEnumerable<OdPrcContentExtendedEntityReference>.GetEnumerator()
	{
		return new OdPrcContentExtendedEntityReferencePtrArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdPrcContentExtendedEntityReferencePtrArrayEnumerator(this);
	}

	public OdPrcContentExtendedEntityReferencePtrArrayEnumerator GetEnumerator()
	{
		return new OdPrcContentExtendedEntityReferencePtrArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_size(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_capacity(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_reserve(swigCPtr, n);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_resize(swigCPtr, logicalLength);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_Clear(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdPrcContentExtendedEntityReference val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_Add(swigCPtr, OdPrcContentExtendedEntityReference.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdPrcContentExtendedEntityReference getitemcopy(int index)
	{
		OdPrcContentExtendedEntityReference rXObject = Helpers.GetRXObject<OdPrcContentExtendedEntityReference>(OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private OdPrcContentExtendedEntityReference getitem(int index)
	{
		OdPrcContentExtendedEntityReference rXObject = Helpers.GetRXObject<OdPrcContentExtendedEntityReference>(OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int index, OdPrcContentExtendedEntityReference val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_setitem(swigCPtr, index, OdPrcContentExtendedEntityReference.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdPrcContentExtendedEntityReferencePtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_AddRange(swigCPtr, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcContentExtendedEntityReferencePtrArray GetRange(int index, int count)
	{
		OdPrcContentExtendedEntityReferencePtrArray result = Helpers.GetObject<OdPrcContentExtendedEntityReferencePtrArray>(OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_GetRange(swigCPtr, index, count), bOwn: false, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdPrcContentExtendedEntityReference x)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_Insert(swigCPtr, index, OdPrcContentExtendedEntityReference.getCPtr(x));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdPrcContentExtendedEntityReferencePtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_RemoveAt(swigCPtr, index);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_RemoveRange(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdPrcContentExtendedEntityReferencePtrArray Repeat(OdPrcContentExtendedEntityReference value, int count)
	{
		OdPrcContentExtendedEntityReferencePtrArray result = Helpers.GetObject<OdPrcContentExtendedEntityReferencePtrArray>(OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_Repeat(OdPrcContentExtendedEntityReference.getCPtr(value), count), bOwn: false, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_Reverse__SWIG_0(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdPrcContentExtendedEntityReferencePtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_SetRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdPrcContentExtendedEntityReference value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_Contains(swigCPtr, OdPrcContentExtendedEntityReference.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdPrcContentExtendedEntityReference value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_IndexOf(swigCPtr, OdPrcContentExtendedEntityReference.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdPrcContentExtendedEntityReference value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_LastIndexOf(swigCPtr, OdPrcContentExtendedEntityReference.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdPrcContentExtendedEntityReference value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcContentExtendedEntityReferencePtrArray_Remove(swigCPtr, OdPrcContentExtendedEntityReference.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
