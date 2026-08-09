using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcCombinationFunctionArray : IDisposable, IEnumerable, IList<OdPrcCombinationFunction>, ICollection<OdPrcCombinationFunction>, IEnumerable<OdPrcCombinationFunction>
{
	public class OdPrcCombinationFunctionArrayEnumerator : IEnumerator, IEnumerator<OdPrcCombinationFunction>, IDisposable
	{
		private OdPrcCombinationFunctionArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdPrcCombinationFunction Current
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
				return (OdPrcCombinationFunction)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdPrcCombinationFunctionArrayEnumerator(OdPrcCombinationFunctionArray collection)
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

	public OdPrcCombinationFunction this[int index]
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
	public OdPrcCombinationFunctionArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcCombinationFunctionArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcCombinationFunctionArray()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcCombinationFunctionArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcCombinationFunctionArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdPrcCombinationFunction item in c)
		{
			Add(item);
		}
	}

	public OdPrcCombinationFunctionArray(bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcCombinationFunctionArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcCombinationFunctionArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcCombinationFunctionArray(OdPrcCombinationFunctionArray other, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcCombinationFunctionArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcCombinationFunctionArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcCombinationFunctionArray(int capacity, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcCombinationFunctionArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcCombinationFunctionArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdPrcCombinationFunction[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdPrcCombinationFunction[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdPrcCombinationFunction[] array, int arrayIndex, int count)
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

	IEnumerator<OdPrcCombinationFunction> IEnumerable<OdPrcCombinationFunction>.GetEnumerator()
	{
		return new OdPrcCombinationFunctionArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdPrcCombinationFunctionArrayEnumerator(this);
	}

	public OdPrcCombinationFunctionArrayEnumerator GetEnumerator()
	{
		return new OdPrcCombinationFunctionArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_size(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_capacity(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_reserve(swigCPtr, n);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_resize(swigCPtr, logicalLength);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_Clear(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdPrcCombinationFunction val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_Add(swigCPtr, OdPrcCombinationFunction.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdPrcCombinationFunction getitemcopy(int index)
	{
		OdPrcCombinationFunction result = new OdPrcCombinationFunction(OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdPrcCombinationFunction getitem(int index)
	{
		OdPrcCombinationFunction result = new OdPrcCombinationFunction(OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdPrcCombinationFunction val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_setitem(swigCPtr, index, OdPrcCombinationFunction.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdPrcCombinationFunctionArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_AddRange(swigCPtr, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcCombinationFunctionArray GetRange(int index, int count)
	{
		OdPrcCombinationFunctionArray result = new OdPrcCombinationFunctionArray(OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdPrcCombinationFunction x)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_Insert(swigCPtr, index, OdPrcCombinationFunction.getCPtr(x));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdPrcCombinationFunctionArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_RemoveAt(swigCPtr, index);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_RemoveRange(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdPrcCombinationFunctionArray Repeat(OdPrcCombinationFunction value, int count)
	{
		OdPrcCombinationFunctionArray result = new OdPrcCombinationFunctionArray(OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_Repeat(OdPrcCombinationFunction.getCPtr(value), count), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_Reverse__SWIG_0(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdPrcCombinationFunctionArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_SetRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdPrcCombinationFunction value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_Contains(swigCPtr, OdPrcCombinationFunction.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdPrcCombinationFunction value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_IndexOf(swigCPtr, OdPrcCombinationFunction.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdPrcCombinationFunction value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_LastIndexOf(swigCPtr, OdPrcCombinationFunction.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdPrcCombinationFunction value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCombinationFunctionArray_Remove(swigCPtr, OdPrcCombinationFunction.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
