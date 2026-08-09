using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator : IDisposable, IEnumerable, IList<OdGiShellToolkit.OdGiShellEdgeVisibilityDescription>, ICollection<OdGiShellToolkit.OdGiShellEdgeVisibilityDescription>, IEnumerable<OdGiShellToolkit.OdGiShellEdgeVisibilityDescription>
{
	public class OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<OdGiShellToolkit.OdGiShellEdgeVisibilityDescription>, IDisposable
	{
		private OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdGiShellToolkit.OdGiShellEdgeVisibilityDescription Current
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
				return (OdGiShellToolkit.OdGiShellEdgeVisibilityDescription)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocatorEnumerator(OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator collection)
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

	public OdGiShellToolkit.OdGiShellEdgeVisibilityDescription this[int index]
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
	public OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdGiShellToolkit.OdGiShellEdgeVisibilityDescription item in c)
		{
			Add(item);
		}
	}

	public OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator other, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(int capacity, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdGiShellToolkit.OdGiShellEdgeVisibilityDescription[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdGiShellToolkit.OdGiShellEdgeVisibilityDescription[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdGiShellToolkit.OdGiShellEdgeVisibilityDescription[] array, int arrayIndex, int count)
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

	IEnumerator<OdGiShellToolkit.OdGiShellEdgeVisibilityDescription> IEnumerable<OdGiShellToolkit.OdGiShellEdgeVisibilityDescription>.GetEnumerator()
	{
		return new OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocatorEnumerator(this);
	}

	public OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdGiShellToolkit.OdGiShellEdgeVisibilityDescription val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_Add(swigCPtr, OdGiShellToolkit.OdGiShellEdgeVisibilityDescription.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdGiShellToolkit.OdGiShellEdgeVisibilityDescription getitemcopy(int index)
	{
		OdGiShellToolkit.OdGiShellEdgeVisibilityDescription result = new OdGiShellToolkit.OdGiShellEdgeVisibilityDescription(TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdGiShellToolkit.OdGiShellEdgeVisibilityDescription getitem(int index)
	{
		OdGiShellToolkit.OdGiShellEdgeVisibilityDescription result = new OdGiShellToolkit.OdGiShellEdgeVisibilityDescription(TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdGiShellToolkit.OdGiShellEdgeVisibilityDescription val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_setitem(swigCPtr, index, OdGiShellToolkit.OdGiShellEdgeVisibilityDescription.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator GetRange(int index, int count)
	{
		OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator result = new OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdGiShellToolkit.OdGiShellEdgeVisibilityDescription x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_Insert(swigCPtr, index, OdGiShellToolkit.OdGiShellEdgeVisibilityDescription.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator Repeat(OdGiShellToolkit.OdGiShellEdgeVisibilityDescription value, int count)
	{
		OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator result = new OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator(TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_Repeat(OdGiShellToolkit.OdGiShellEdgeVisibilityDescription.getCPtr(value), count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdGiShellToolkit.OdGiShellEdgeVisibilityDescription value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_Contains(swigCPtr, OdGiShellToolkit.OdGiShellEdgeVisibilityDescription.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdGiShellToolkit.OdGiShellEdgeVisibilityDescription value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_IndexOf(swigCPtr, OdGiShellToolkit.OdGiShellEdgeVisibilityDescription.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdGiShellToolkit.OdGiShellEdgeVisibilityDescription value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_LastIndexOf(swigCPtr, OdGiShellToolkit.OdGiShellEdgeVisibilityDescription.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdGiShellToolkit.OdGiShellEdgeVisibilityDescription value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdArray_OdGiShellToolkit_OdGiShellEdgeVisibilityDescription_OdObjectsAllocator_Remove(swigCPtr, OdGiShellToolkit.OdGiShellEdgeVisibilityDescription.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
