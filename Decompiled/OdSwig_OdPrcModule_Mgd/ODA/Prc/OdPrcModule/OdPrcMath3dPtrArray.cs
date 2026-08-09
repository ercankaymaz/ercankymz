using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcMath3dPtrArray : IDisposable, IEnumerable, IList<OdPrcMath3d>, ICollection<OdPrcMath3d>, IEnumerable<OdPrcMath3d>
{
	public class OdPrcMath3dPtrArrayEnumerator : IEnumerator, IEnumerator<OdPrcMath3d>, IDisposable
	{
		private OdPrcMath3dPtrArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdPrcMath3d Current
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
				return (OdPrcMath3d)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdPrcMath3dPtrArrayEnumerator(OdPrcMath3dPtrArray collection)
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

	public OdPrcMath3d this[int index]
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
	public OdPrcMath3dPtrArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcMath3dPtrArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcMath3dPtrArray()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcMath3dPtrArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcMath3dPtrArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdPrcMath3d item in c)
		{
			Add(item);
		}
	}

	public OdPrcMath3dPtrArray(bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcMath3dPtrArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcMath3dPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcMath3dPtrArray(OdPrcMath3dPtrArray other, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcMath3dPtrArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcMath3dPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcMath3dPtrArray(int capacity, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcMath3dPtrArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcMath3dPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdPrcMath3d[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdPrcMath3d[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdPrcMath3d[] array, int arrayIndex, int count)
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

	IEnumerator<OdPrcMath3d> IEnumerable<OdPrcMath3d>.GetEnumerator()
	{
		return new OdPrcMath3dPtrArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdPrcMath3dPtrArrayEnumerator(this);
	}

	public OdPrcMath3dPtrArrayEnumerator GetEnumerator()
	{
		return new OdPrcMath3dPtrArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_size(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_capacity(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_reserve(swigCPtr, n);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_resize(swigCPtr, logicalLength);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_Clear(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdPrcMath3d val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_Add(swigCPtr, OdPrcMath3d.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdPrcMath3d getitemcopy(int index)
	{
		OdPrcMath3d rXObject = Helpers.GetRXObject<OdPrcMath3d>(OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private OdPrcMath3d getitem(int index)
	{
		OdPrcMath3d rXObject = Helpers.GetRXObject<OdPrcMath3d>(OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int index, OdPrcMath3d val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_setitem(swigCPtr, index, OdPrcMath3d.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdPrcMath3dPtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_AddRange(swigCPtr, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcMath3dPtrArray GetRange(int index, int count)
	{
		OdPrcMath3dPtrArray result = Helpers.GetObject<OdPrcMath3dPtrArray>(OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_GetRange(swigCPtr, index, count), bOwn: false, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdPrcMath3d x)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_Insert(swigCPtr, index, OdPrcMath3d.getCPtr(x));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdPrcMath3dPtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_RemoveAt(swigCPtr, index);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_RemoveRange(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdPrcMath3dPtrArray Repeat(OdPrcMath3d value, int count)
	{
		OdPrcMath3dPtrArray result = Helpers.GetObject<OdPrcMath3dPtrArray>(OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_Repeat(OdPrcMath3d.getCPtr(value), count), bOwn: false, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_Reverse__SWIG_0(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdPrcMath3dPtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_SetRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdPrcMath3d value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_Contains(swigCPtr, OdPrcMath3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdPrcMath3d value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_IndexOf(swigCPtr, OdPrcMath3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdPrcMath3d value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_LastIndexOf(swigCPtr, OdPrcMath3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdPrcMath3d value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcMath3dPtrArray_Remove(swigCPtr, OdPrcMath3d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
