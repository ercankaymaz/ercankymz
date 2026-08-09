using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class HandlePairsArray : IDisposable, IEnumerable, IList<std_pair_OdDbHandle_OdDbObjectId>, ICollection<std_pair_OdDbHandle_OdDbObjectId>, IEnumerable<std_pair_OdDbHandle_OdDbObjectId>
{
	public class HandlePairsArrayEnumerator : IEnumerator, IEnumerator<std_pair_OdDbHandle_OdDbObjectId>, IDisposable
	{
		private HandlePairsArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public std_pair_OdDbHandle_OdDbObjectId Current
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
				return (std_pair_OdDbHandle_OdDbObjectId)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public HandlePairsArrayEnumerator(HandlePairsArray collection)
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

	public std_pair_OdDbHandle_OdDbObjectId this[int index]
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
	public HandlePairsArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(HandlePairsArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~HandlePairsArray()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_HandlePairsArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public HandlePairsArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (std_pair_OdDbHandle_OdDbObjectId item in c)
		{
			Add(item);
		}
	}

	public HandlePairsArray(bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_HandlePairsArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new HandlePairsArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public HandlePairsArray(HandlePairsArray other, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_HandlePairsArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new HandlePairsArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public HandlePairsArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_HandlePairsArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new HandlePairsArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(std_pair_OdDbHandle_OdDbObjectId[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(std_pair_OdDbHandle_OdDbObjectId[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, std_pair_OdDbHandle_OdDbObjectId[] array, int arrayIndex, int count)
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

	IEnumerator<std_pair_OdDbHandle_OdDbObjectId> IEnumerable<std_pair_OdDbHandle_OdDbObjectId>.GetEnumerator()
	{
		return new HandlePairsArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new HandlePairsArrayEnumerator(this);
	}

	public HandlePairsArrayEnumerator GetEnumerator()
	{
		return new HandlePairsArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_size(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_capacity(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_reserve(swigCPtr, n);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_resize(swigCPtr, logicalLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_Clear(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(std_pair_OdDbHandle_OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_Add(swigCPtr, std_pair_OdDbHandle_OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private std_pair_OdDbHandle_OdDbObjectId getitemcopy(int index)
	{
		return new std_pair_OdDbHandle_OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
	}

	private std_pair_OdDbHandle_OdDbObjectId getitem(int index)
	{
		return new std_pair_OdDbHandle_OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_getitem(swigCPtr, index), cMemoryOwn: false);
	}

	private void setitem(int index, std_pair_OdDbHandle_OdDbObjectId val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_setitem(swigCPtr, index, std_pair_OdDbHandle_OdDbObjectId.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public HandlePairsArray GetRange(int index, int count)
	{
		HandlePairsArray result = new HandlePairsArray(TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, std_pair_OdDbHandle_OdDbObjectId x)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_Insert(swigCPtr, index, std_pair_OdDbHandle_OdDbObjectId.getCPtr(x));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_RemoveAt(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_RemoveRange(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static HandlePairsArray Repeat(std_pair_OdDbHandle_OdDbObjectId value, int count)
	{
		HandlePairsArray result = new HandlePairsArray(TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_Repeat(std_pair_OdDbHandle_OdDbObjectId.getCPtr(value), count), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void SetRange(int index, HandlePairsArray values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(std_pair_OdDbHandle_OdDbObjectId value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_Contains(swigCPtr, std_pair_OdDbHandle_OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(std_pair_OdDbHandle_OdDbObjectId value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_IndexOf(swigCPtr, std_pair_OdDbHandle_OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(std_pair_OdDbHandle_OdDbObjectId value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_LastIndexOf(swigCPtr, std_pair_OdDbHandle_OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(std_pair_OdDbHandle_OdDbObjectId value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.HandlePairsArray_Remove(swigCPtr, std_pair_OdDbHandle_OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
