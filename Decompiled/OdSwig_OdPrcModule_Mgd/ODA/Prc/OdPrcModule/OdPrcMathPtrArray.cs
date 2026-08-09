using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcMathPtrArray : IDisposable, IEnumerable, IList<OdPrcMath>, ICollection<OdPrcMath>, IEnumerable<OdPrcMath>
{
	public class OdPrcMathPtrArrayEnumerator : IEnumerator, IEnumerator<OdPrcMath>, IDisposable
	{
		private OdPrcMathPtrArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdPrcMath Current
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
				return (OdPrcMath)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdPrcMathPtrArrayEnumerator(OdPrcMathPtrArray collection)
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

	public OdPrcMath this[int index]
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
	public OdPrcMathPtrArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcMathPtrArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcMathPtrArray()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcMathPtrArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcMathPtrArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdPrcMath item in c)
		{
			Add(item);
		}
	}

	public OdPrcMathPtrArray(bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcMathPtrArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcMathPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcMathPtrArray(OdPrcMathPtrArray other, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcMathPtrArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcMathPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcMathPtrArray(int capacity, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcMathPtrArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcMathPtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdPrcMath[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdPrcMath[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdPrcMath[] array, int arrayIndex, int count)
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

	IEnumerator<OdPrcMath> IEnumerable<OdPrcMath>.GetEnumerator()
	{
		return new OdPrcMathPtrArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdPrcMathPtrArrayEnumerator(this);
	}

	public OdPrcMathPtrArrayEnumerator GetEnumerator()
	{
		return new OdPrcMathPtrArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_size(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_capacity(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_reserve(swigCPtr, n);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_resize(swigCPtr, logicalLength);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_Clear(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdPrcMath val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_Add(swigCPtr, OdPrcMath.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdPrcMath getitemcopy(int index)
	{
		OdPrcMath rXObject = Helpers.GetRXObject<OdPrcMath>(OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private OdPrcMath getitem(int index)
	{
		OdPrcMath rXObject = Helpers.GetRXObject<OdPrcMath>(OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int index, OdPrcMath val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_setitem(swigCPtr, index, OdPrcMath.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdPrcMathPtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_AddRange(swigCPtr, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcMathPtrArray GetRange(int index, int count)
	{
		OdPrcMathPtrArray result = Helpers.GetObject<OdPrcMathPtrArray>(OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_GetRange(swigCPtr, index, count), bOwn: false, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdPrcMath x)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_Insert(swigCPtr, index, OdPrcMath.getCPtr(x));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdPrcMathPtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_RemoveAt(swigCPtr, index);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_RemoveRange(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdPrcMathPtrArray Repeat(OdPrcMath value, int count)
	{
		OdPrcMathPtrArray result = Helpers.GetObject<OdPrcMathPtrArray>(OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_Repeat(OdPrcMath.getCPtr(value), count), bOwn: false, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_Reverse__SWIG_0(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdPrcMathPtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_SetRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdPrcMath value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_Contains(swigCPtr, OdPrcMath.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdPrcMath value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_IndexOf(swigCPtr, OdPrcMath.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdPrcMath value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_LastIndexOf(swigCPtr, OdPrcMath.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdPrcMath value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcMathPtrArray_Remove(swigCPtr, OdPrcMath.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
